// <summary>
//   Stores the logic for updating the database storing scores. 
//   Updates the database based on models to be updated given 
//   from the controller.
// </summary>
// <author> D. Mason Hair and Sinahi Leon </author>
// <data> 4/16/2025 </date>

using System.Data;
using MySql.Data.MySqlClient;
using static System.Net.Mime.MediaTypeNames;
using GUI.Client.Models;

namespace GUI.Client.Controllers;

/// <summary>
///   Stores the logic for updating the database storing scores. 
///   Updates the database based on models to be updated given 
///   from the controller.
/// </summary>
public class DatabaseManager
{

    /// <summary>
    /// The connection string for connecting to our database.
    /// </summary>
    private const string connectionString = "server=atr.eng.utah.edu;" +
        "database=u1312051;uid=u1312051;password=Sinahi123";

    /// <summary>
    ///   Private method used for sending SQL queries.
    /// </summary>
    /// <param name="text"> The command in string form to be sent. </param>
    private static void SendCommand(string text)
    {
        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = text;
                command.ExecuteNonQuery();
            }
        }
        catch { }
    }

    /// <summary>
    ///   Adds a new game entity to the MySQL table with the start time that this 
    ///   method was called in the database and returns the GameID of that object.
    /// </summary>
    /// <returns> Returns the GameID for the new game created. </returns>
    public static int AddGame()
    {
        string currentTime = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss");

        SendCommand($"insert into Games (StartTime) values (\"{currentTime}\")");

        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select last_insert_id()";
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                return (int)reader["GameID"];
            }
        }
    }

    /// <summary>
    ///   Sets the end time of the game in the database to be when this method is called.
    /// </summary>
    /// <param name="gameID">
    ///   ID of the game to have its end time updated. 
    /// </param>
    public static void SetGameEndTime(int gameID)
    {
        string currentTime = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss");

        SendCommand($"update Games set EndTime = {currentTime} where GameID = {gameID}");
    }

    /// <summary>
    ///  Adds a new Snake player to the MSQL table with the parameters of GameID and 
    ///  playerID and with those it also initializes the player object with a name
    ///  and start time. 
    /// </summary>
    /// <param name="gameID"> ID of the game we are adding a player to. </param>
    /// <param name="player"> User being added to the game. </param>
    public static void AddPlayer(int gameID, Snake player)
    {
        string currentTime = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss");

        SendCommand($"insert into Players (GameID, PlayerID, Name, StartTime) values ({gameID}, {player.ID}, \"{player.Name}\", \"{currentTime}\")");
    }

    /// <summary>
    ///   Updates the maximum score of this snake/player of the game given in the 
    ///   database with the score contained within the snake model given.
    /// </summary>
    /// <param name="gameID">
    ///   ID of the game for which the player max score to be updated belongs to. 
    /// </param>
    /// <param name="player">
    ///   The player as a snake to have its max score updated.
    /// </param>
    public static void UpdateMaxScore(int gameID, Snake player)
    {
        SendCommand($"update Players set MaxScore = {player.MaxScore} where GameID = {gameID} and PlayerID = {player.ID}");
    }

    /// <summary>
    ///   Sets the end time of the player in the database to be when this method is called.
    /// </summary>
    /// <param name="gameID">
    ///   ID of the game for which the player end time to be updated belongs to. 
    /// </param>
    /// <param name="player">
    ///   The player as a snake to have its end time updated.
    /// </param>
    public static void SetPlayerEndTime(int gameID, Snake player)
    {
        string currentTime = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss");

        SendCommand($"update Players set EndTime = {currentTime} where GameID = {gameID} and PlayerID = {player.ID}");
    }
}


