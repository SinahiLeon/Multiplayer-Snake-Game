using CS3500.Networking;


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

        if (recivedLine.Contains("GET"))
        {

            Console.WriteLine(recivedLine);

            string response = "<html>" +
                             "<body>" +

                             "<table border=10>" +

                             "<tr>" + "<td> Player name: Ahmad </td>" + "</tr>" +
                             "<tr>" + "<td> Player socre: 20 </td>" + "</tr>" +



                             "</tabe>" +



                             "</body>" +


                             "</html>";
            connection.Send(httpOkHeader + response);
        }

        else if (recivedLine.Contains("GET /SomePage"))
        {

            // server the some Page

            connection.Send(httpOkHeader + "Some Page Html page ");
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