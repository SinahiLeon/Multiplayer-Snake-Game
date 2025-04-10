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
    ///   Determines whether the world has walls, a player ID, and world 
    ///   size for this session after connecting to the server.
    /// </summary>
    private bool worldInitialized;

    /// <summary>
    /// Returns whether the client is connected or not.
    /// </summary>
    public bool IsConnected { 
        get
        {
            return clientConnection.IsConnected;
        } 
    }

    /// <summary>
    ///   Builds a new NetworkController class. With a new connection used by the GUI.
    /// </summary>
    /// <param name="world"> World used by this controller and the GUI </param>
    public NetworkController(World world)
    {
        this.world = world;
        clientConnection = new NetworkConnection();
    }

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
            lock(world)
                world.PlayerID = playerID;
            int worldSize = int.Parse(clientConnection.ReadLine());
            lock(world)
                world.Size = worldSize;
            string nextLine = string.Empty;

            // Loop runs as long as walls are received and breaks when first non-wall object is sent from server. 
            while (true)
            {
                try
                {
                    // Assuming server will not send null hence, wall is nullable here
                    nextLine = clientConnection.ReadLine();
                    Wall? wall = JsonSerializer.Deserialize<Wall>(nextLine);
                    if (wall != null)
                    {
                        lock(world)
                            world.Walls[wall.ID] = wall;
                    }
                }
                catch 
                {
                    break;
                }
            }

            worldInitialized = true; // Allows for command requests to go through.
            AddSnakeOrPowerup(nextLine);
            HandleServer();
        }
        catch { }
    }

    /// <summary>
    ///   Requests that the server change the state of the client's snake. This method takes 
    ///   either LEFT, RIGHT, UP, DOWN, or NONE from the Direction enum. Based on the given 
    ///   parameter, a request will be made to the server via this controller. A request cannot 
    ///   be made until the world has a player ID, wall, and a world size. If the world hasn't 
    ///   been initialized with these things, the command will not be sent.
    /// </summary>
    /// <param name="direction"> 
    ///   This enables the GUI to send server requests via a direction enum. The specfic direction 
    ///   chosen will represent the command to be sent.
    /// </param>
    public void CommandRequest(Direction direction)
    {
        if (worldInitialized)
        {
            string directionStringForm = direction.ToString().ToLower();
            clientConnection.Send("{\"moving\":\"" + directionStringForm + "\"}");
        }
    }

    /// <summary>
    ///   Handles the input from the server and updates the model accordingly.
    /// </summary>
    private void HandleServer()
    {
        try
        {
            while (true)
            {
                var json = clientConnection.ReadLine();

                AddSnakeOrPowerup(json);
            }
        } catch { }
    }
    
    /// <summary>
    ///   Attempts to add the deserialized JSON to the world. Expects the JSON to either 
    ///   be a powerup or a snake. If the given JSON is neither, the world will not be 
    ///   updated.
    /// </summary>
    /// <param name="json">
    ///   JSON string representing either a powerup or snake object.
    /// </param>
    private void AddSnakeOrPowerup(string json)
    {
        // Tries to deserialize the given json as a powerup. If that fails, tries to
        // deserialize as a snake. If that fails, do nothing. In all cases where
        // deserialization is successful, adds the new object to the world.
        try
        {
            Powerup? powerup = JsonSerializer.Deserialize<Powerup>(json);
            if (powerup != null)
            {
                lock(world)
                    world.Powerups[powerup.ID] = powerup;
            }
        }
        catch
        {
            try
            {
                Snake? snake = JsonSerializer.Deserialize<Snake>(json);
                if (snake != null)
                {
                    lock(world)
                        world.Snakes[snake.ID] = snake;
                }
            }
            catch { }
        }
    }
}
