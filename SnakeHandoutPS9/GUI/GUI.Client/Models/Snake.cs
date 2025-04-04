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
    [JsonRequired]
    [JsonInclude]
    public int ID { get; private set; }

    /// <summary>
    /// Property storing the snake name
    /// </summary>
    [JsonPropertyName("name")]
    [JsonRequired]
    [JsonInclude]
    public string Name { get; private set; } 

    /// <summary>
    /// Property storing a list of all vertices that make of the snake.
    /// </summary>
    [JsonPropertyName("body")]
    [JsonRequired]
    [JsonInclude]
    public List<Point2D> Body { get; private set; }

    /// <summary>
    ///   Represents the snakes orientation in the form of a Point2D object.
    /// </summary>
    [JsonPropertyName("dir")]
    [JsonRequired]
    [JsonInclude]
    public Point2D Direction { get; private set; }

    /// <summary>
    ///   An integer representing the player's score (i.e. the number of powerups eaten).
    /// </summary>
    [JsonPropertyName("score")]
    [JsonRequired]
    [JsonInclude]
    public int Score { get; private set; }

    /// <summary>
    ///   Indicates that the snake has died (single event) on the frame that the 
    ///   server sends.
    /// </summary>
    [JsonPropertyName("died")]
    [JsonRequired]
    [JsonInclude]
    public bool Died { get; private set; }

    /// <summary>
    ///   A boolean indicating whether the snake is actively dead or alive so that it 
    ///   can be drawn accordingly.
    /// </summary>
    [JsonPropertyName("alive")]
    [JsonRequired]
    [JsonInclude]
    public bool Alive { get; private set; }

    /// <summary>
    ///   Boolean indicating that the player has disconnected on the frame sent by the 
    ///   server that this information was sent from. This only occurs once.
    /// </summary>
    [JsonPropertyName("dc")]
    [JsonRequired]
    [JsonInclude]
    public bool DidDisconnect { get; private set; }

    /// <summary>
    ///   Boolean indicating that the player has connected on the frame sent by the 
    ///   server that this information was sent from. This only occurs once.
    /// </summary>
    [JsonPropertyName("join")]
    [JsonRequired]
    [JsonInclude]
    public bool DidConnect { get; private set; }

    /// <summary>
    ///   Creates a snake with the following default values:
    ///   - ID = 0
    ///   - Name = string.Empty
    ///   - Body = new empty List of Point2D objects
    ///   - Direction = Point2D()
    ///   - Score = 0
    ///   - Died = false
    ///   - Alive = true
    ///   - DidDisconnect = false
    ///   - DidConnect = false
    /// </summary>
    public Snake()
    {
        ID = 0;
        Name = string.Empty;
        Body = new List<Point2D>();
        Direction = new Point2D();
        Score = 0;
        Died = false;
        Alive = true;
        DidDisconnect = false;
        DidConnect = false;
    }
}


