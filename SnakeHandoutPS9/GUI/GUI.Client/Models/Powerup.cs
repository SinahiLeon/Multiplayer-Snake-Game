using System.Text.Json.Serialization;

namespace GUI.Client.Models;

/// <summary>
///   Stores the required data for a powerup including its 
///   ID, whether it died, and its coordinates as a Point2D object.
/// </summary>
public class Powerup
{
    /// <summary>
    ///   Unique id used to identify this powerup.
    /// </summary>
    [JsonPropertyName("power")]
    public int ID { get; private set; }

    /// <summary>
    ///   Stores the 2-dimensional location of this powerup.
    /// </summary>
    [JsonPropertyName("loc")]
    public Point2D Location { get; set; }

    /// <summary>
    ///   Boolean indicating if a powerup was collected by the player.
    /// </summary>
    [JsonPropertyName("died")]
    public bool IsCollected { get; set; }

    /// <summary>
    ///   Constructs a new Point2D object at the default location of X=0 and Y=0.
    /// </summary>
    public Powerup()
    {
        ID = 0;
        Location = new();
    }
}
