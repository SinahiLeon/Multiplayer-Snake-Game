using CS3500.Networking;
using GUI.Client.Controllers;
using MySql.Data.MySqlClient;
using System.Xml.Linq;
using WebServer;


/// <summary>
///   A simple Http server example.
/// </summary>
public class HttpServerExample
{
    /// <summary>
    /// The connection string for connecting to our database.
    /// </summary>
    private const string connectionString = "server=atr.eng.utah.edu;" +
        "database=u1312051;uid=u1312051;password=Sinahi123";


    private const string httpOkHeader =
        "HTTP/1.1 200 OK\r\n" +
        "Connection: close\r\n" +
        "Content-Type: text/html; charset=UTF-8\r\n\r\n";

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



    private static void HandleConnect(NetworkConnection connection)
    {



        // do an sql connection 
        // query the needed information. 



        string recivedLine = connection.ReadLine();

        if (recivedLine.Contains("GET /games?gid="))    // ADDED
        {

            Console.WriteLine(recivedLine);

            // split on the '=' so we can extract what comes after. 
            string gameIDParsed = recivedLine.Split('=')[1];   // ADDED

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

            else if (recivedLine.Contains("GET /games"))
            {

                // server the some Page
                string response = "<html><h3>All Games </h3><table border='1'><thead><tr><td>ID</td><td>Start" +
                    "<td>End</td></tr></thead><tbody>";


                using (var conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using var command = new MySqlCommand($"SELECT GameID, StartTime, EndTime FROM Games", conn);
                    using var reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        connection.Send(httpOkHeader + "Some Page Html page ");
                    }
                    response += $"<tr><td>{playerID}</td><td>{name}</td><td>{maxScore}</td><td>{startTime}</td><td>{endTime}</td></tr>";

                }
            }
            else
            {
                //serve not found page. 
                connection.Send(httpBadHeader);
            }

            //always disconnect
            connection.Disconnect();
        }
    }
}