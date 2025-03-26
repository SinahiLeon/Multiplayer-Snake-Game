// <copyright file="ChatServer.cs" company="UofU-CS3500">
// Copyright (c) 2024 UofU-CS3500. All rights reserved.
// </copyright>
// <author>Sinahi Leon and D. Mason Hair</author>
// <date>3/21/2025</date>
// <summary>
// A multi-client chat server that accepts connections, assigns usernames based on the
// first message received, and broadcasts subsequent messages to all connected clients
// while also stating the sender's name.
// </summary>

using CS3500.Networking;
using System.Text;

namespace CS3500.Chatting;

/// <summary>
///   A simple ChatServer that handles clients separately and replies with a static message.
/// </summary>
public partial class ChatServer
{
    /// <summary>
    /// List of all currently connected clients.
    /// </summary>
    private static List<NetworkConnection> clients = new List<NetworkConnection>();

    /// <summary>
    ///   The main program.
    /// </summary>
    /// <param name="args"> ignored. </param>
    /// <returns> A Task. Not really used. </returns>
    private static void Main( string[] args )
    {
        Server.StartServer( HandleConnect, 11_000 );
        Console.Read(); // don't stop the program.
    }


    /// <summary>
    /// Handles an incoming client connection. The first message is treated as the client's name.
    /// All subsequent messages are broadcast to all other connected clients, prefixed by the sender's name.
    /// </summary>
    /// <param name="connection">The network connection to the client.</param>
    private static void HandleConnect(NetworkConnection connection)
    {
        // handle all messages until disconnect.
        try
        {
            var name = connection.ReadLine();

            lock (clients)
            {
                clients.Add(connection);
            }

            while (true)
            {
               
                    var message = connection.ReadLine();

                lock (clients)
                {
                    foreach (var client in clients)
                    {
                        //Thread.Sleep(5000);   //TODO remove this

                        client.Send($"{name} says: {message}");
                    }
                }
            }
        }
        catch (Exception)
        {
            lock (clients)
            {
                clients.Remove(connection);
                connection.Disconnect();
            }
        }
    }
}