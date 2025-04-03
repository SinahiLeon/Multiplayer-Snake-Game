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
    [JsonRequired]
    [JsonInclude]
    public int ID { get; private set; }

    /// <summary>
    ///   Stores the 2-dimensional location of this powerup.
    /// </summary>
    [JsonPropertyName("loc")]
    [JsonRequired]
    [JsonInclude]
    public Point2D Location { get; set; }

    /// <summary>
    ///   Boolean indicating if a powerup was collected by the player.
    /// </summary>
    [JsonPropertyName("died")]
    [JsonRequired]
    [JsonInclude]
    public bool IsCollected { get; set; }

    /// <summary>
    ///   Zero argument constructor that constructs a powerup with default values:
    ///   ID = 0, Location = 0,0 and IsCollected = false
    /// </summary>
    public Powerup()
    {
        ID = 0;
        Location = new();
        IsCollected = false;
    }
}
