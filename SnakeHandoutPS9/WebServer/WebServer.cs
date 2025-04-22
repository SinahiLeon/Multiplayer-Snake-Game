// <summary>
//   Defines a webserver to display game high scores for a snake game.
// </summary>
// <author> D. Mason Hair and Sinahi Leon </author>
// <data> 4/22/2025 </date>

using GUI.Client.Controllers;
using MySql.Data.MySqlClient;
using System.Xml.Linq;

namespace WebServer;

/// <summary>
///   A simple Http server example.
/// </summary>
public class WebServer
{
    /// <summary>
    /// The connection string for connecting to our database.
    /// </summary>
    private const string connectionString = "server=atr.eng.utah.edu;" +
        "database=u1312051;uid=u1312051;password=Sinahi123";

    /// <summary>
    /// The http OK header used to indicate that the page was found and 
    /// used to specify attributes of the page that this server will send.
    /// </summary>
    private const string httpOkHeader =
        "HTTP/1.1 200 OK\r\n" +
        "Connection: close\r\n" +
        "Content-Type: text/html; charset=UTF-8\r\n" +
        "\r\n";

    /// <summary>
    /// The http Bad header used to indicate that the page was not found and 
    /// used to specify attributes of the page that this server will send.
    /// </summary>
    private const string httpBadHeader =
        "HTTP/1.1 404 Not Found\r\n" +
        "Connection: close\r\n" +
        "Content-Type: text/html; charset=UTF-8\r\n" +
        "\r\n";

    /// <summary>
    ///   The main program.
    /// </summary>
    /// <param name="args"> ignored. </param>
    /// <returns> A Task. Not really used. </returns>
    private static void Main(string[] args)
    {
        Server.StartServer(HandleConnect, 80);
        Console.Read(); // don't stop the program.
    }

    /// <summary>
    ///   Handles the client connection to this server.
    /// </summary>
    /// <param name="connection"> The client connection that this server uses to communicate with the client. </param>
    private static void HandleConnect(NetworkConnection connection)
    {
        string recivedLine = connection.ReadLine();

        // If a specific game page is requrested send the game page.
        if (recivedLine.StartsWith("GET /games?gid="))
        {
            // split on the '=' so we can extract what comes after. 
            string gameIDParsed = recivedLine.Split('=')[1].Split(' ')[0];

            // if the gameID can be converted to an int, store this as gameID, else go to else
            if (int.TryParse(gameIDParsed, out int gameID))
            {
                string response = "<html><h3>Stats for Game " + gameID + "</h3><table border='1'><thead><tr><td>Player ID</td><td>Player " +
                    "Name</td><td>Max Score</td><td>Enter Time</td><td>Leave Time</td></tr></thead><tbody>";

                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using var command = new MySqlCommand($"SELECT PlayerID, Name, MaxScore, StartTime, EndTime FROM Players WHERE GameID = {gameID}", conn);
                    using var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int playerID = reader.GetInt32("PlayerID");
                        string name = reader.GetString("Name");
                        int maxScore = reader.GetInt32("MaxScore");

                        string? startTime = reader["StartTime"].ToString();
                        if (startTime == null)
                            startTime = "TBD";

                        string? endTime = reader["EndTime"].ToString();
                        if (endTime == null)
                            endTime = "TBD";

                        response += $"<tr><td>{playerID}</td><td>{name}</td><td>{maxScore}</td><td>{startTime}</td><td>{endTime}</td></tr>";
                    }

                    response += "</tbody></table></html>";
                    connection.Send(httpOkHeader + response);
                }
            }
        }
        // If the games page is requrested send the games page.
        else if (recivedLine.Equals("GET /games HTTP/1.1"))
        {
            string response = "<html><h3>All Games </h3><table border='1'><thead><tr><td>ID</td><td>Start" +
                "<td>End</td></tr></thead><tbody>";

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using var command = new MySqlCommand($"SELECT GameID, StartTime, EndTime FROM Games", conn);
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    response += $"<tr><td><a href=\"/games?gid={reader["GameID"]}\">{reader["GameID"]}</a></td><td>{reader["StartTime"]}</td><td>{reader["EndTime"]}</td></tr>";
                }

                response += "</tbody></table></html>";
                connection.Send(httpOkHeader + response);
            }
        }
        // If the home page is requested, send the home page.
        else if (recivedLine.Equals("GET / HTTP/1.1"))
        {
            string response = "<html>" +
                "<h3>Welcome to the Snake Games Database!</h3>" +
                "<a href=\"/games\">View Games</a>" +
                "</html>";
            int contentLength = System.Text.Encoding.ASCII.GetByteCount(response);

            connection.Send(httpOkHeader + response);
        }
        // If an invalid page is requested, send the invalid page.
        else
        {
            connection.Send(httpBadHeader + "<html><h1>404 Page Not Found</h1></html>");
        }

        //always disconnect
        connection.Disconnect();
    }
}