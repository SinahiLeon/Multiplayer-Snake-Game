// <summary>
//   Stores the logic for updating the database storing scores. 
//   Updates the database based on models to be updated given 
//   from the controller.
// </summary>
// <author> D. Mason Hair and Sinahi Leon </author>
// <data> 4/16/2025 </date>

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
    /// 
    /// </summary>
    /// <returns></returns>
    private MySQLConnection SendCommand(string text)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = text;
            MySqlDataReader reader = command.ExecuteReader(); 

        }

    }


    //TODO: 
    // add new game to table
    // add new player to table
    // update player in table
    // update game in table

}


