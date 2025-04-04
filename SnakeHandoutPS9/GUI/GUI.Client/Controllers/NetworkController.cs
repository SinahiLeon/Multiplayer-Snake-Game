// <summary>
//   This class is the controller for the snake game client and manages
//   input from the server and GUI while also updating the model accordingly.
//   Parses JSON objects recieved by the server after initilaizing the model
//   after the GUI connects.
// </summary>
// <author> D. Mason Hair and Sinahi Leon </author>
// <data> 4/3/2025 </date>

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
    ///   Builds a new NetworkController class. With a new connection used by the GUI.
    /// </summary>
    public NetworkController()
    {
        clientConnection = new NetworkConnection();
    }


    // TODO FINISH: Make a connect method to connect to the server so that the controller can begin communicating with the server.

    
}
