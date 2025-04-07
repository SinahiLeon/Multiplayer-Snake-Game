// <summary>
//   This class is the controller for the snake game client and manages
//   input from the server and GUI while also updating the model accordingly.
//   Parses JSON objects recieved by the server after initilaizing the model
//   after the GUI connects.
// </summary>
// <author> D. Mason Hair and Sinahi Leon </author>
// <data> 4/3/2025 </date>

using GUI.Client.Models;
using System.Net.Sockets;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;

namespace GUI.Client.Controllers;

/// <summary>
///   This class is the controller for the snake game client and manages
///   input from the server and GUI while also updating the model accordingly.
///   Parses JSON objects recieved by the server after initilaizing the model
///   after the GUI connects.
/// </summary>
public class NetworkController
{
    /// <summary>
    ///   A network connection on the client side to recieve and 
    ///   send data to the server.
    /// </summary>
    private NetworkConnection clientConnection;

    /// <summary>
    /// World object that stores all the information used in this game.
    /// </summary>
    private World world;

    /// <summary>
    ///   Builds a new NetworkController class. With a new connection used by the GUI.
    /// </summary>
    /// /// <param name="world"> World used by this controller and the GUI </param>
    public NetworkController(World world)
    {
        this.world = world;
        clientConnection = new NetworkConnection();
    }


    // TODO FINISH: Make a connect method to connect to the server so that the controller can begin communicating with the server.


    /// <summary>
    ///   Try to connect to the given host:port. 
    /// </summary>
    /// <param name="host"> The URL or IP address, e.g., www.cs.utah.edu, or  127.0.0.1. </param>
    /// <param name="port"> The port, e.g., 11000. </param>
    /// <param name="playerName"> The name of the player </param>
    public void Connect(string host, int port, string playerName)
    {
        try
        {
            clientConnection.Connect(host, port);
            clientConnection.Send(playerName.Trim());

            int playerID = int.Parse(clientConnection.ReadLine());
            int worldSize = int.Parse(clientConnection.ReadLine());

            // Loop runs as long as walls are received and breaks when first non-wall object is sent from server. 
            while (true)
            {
                try
                {
                    // Assuming server will not send null hence, wall is nullable here
                    Wall? wall = JsonSerializer.Deserialize<Wall>(clientConnection.ReadLine());     
                }
                catch {
                    break;
                }
            }


        }
        catch { }
    }
    private void HandleServer()
    {

    }
    
}
