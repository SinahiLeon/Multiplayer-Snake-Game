using System.Text.Json.Serialization;

namespace GUI.Client.Models;

/// <summary>
/// This class represents all the data required to 
/// indicate the state of the snake and all data
/// required to draw the snake. 
/// </summary>
public class Snake
{
    /// <summary>
    ///   Property storing the snake ID for access.
    /// </summary>
    [JsonPropertyName("snake")]
    public int ID { get; private set; }

    /// <summary>
    /// Property storing the snake name
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } 

    /// <summary>
    /// Property storing the 
    /// </summary>
    [JsonPropertyName("body")]
    public List<Point2D> Body { get; private set; } 


}


