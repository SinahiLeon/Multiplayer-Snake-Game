// <summary>
//   Stores the logic for updating the database storing scores. 
//   Updates the database based on models to be updated given 
//   from the controller.
// </summary>
// <author> D. Mason Hair and Sinahi Leon </author>
// <data> 4/16/2025 </date>

using MySql.Data.MySqlClient;

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
    public const string connectionString = "server=atr.eng.utah.edu;" +
        "database=u1312051;uid=u1312051;password=Sinahi123";

    /// <summary>
    ///   Private method used for sending SQL queries.
    /// </summary>
    /// <param name="text"> The command in string form to be sent. </param>
    private void SendCommand(string text)
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


    //TODO: 
    // add new game to table
    // add new player to table
    // update player in table
    // update game in table

}


