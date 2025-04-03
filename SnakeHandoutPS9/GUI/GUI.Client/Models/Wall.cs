namespace GUI.Client.Models;

using System;
using System.Text.Json.Serialization;

/// <summary>
///   This class represents the data used for a wall object. 
///   Includes the ID and the start and endpoints of the wall.
/// </summary>
public class Wall
{

    /// <summary>
    ///   Property storing the wall ID for access.
    /// </summary>
    [JsonPropertyName("wall")]
    [JsonRequired]
    [JsonInclude]
    public int ID { get; private set; }

    /// <summary>
    ///   Point2D object representing the first endpoint of the wall.
    /// </summary>
    [JsonPropertyName("p1")]
    [JsonRequired]
    [JsonInclude]
    public Point2D P1 { get; set; }

    /// <summary>
    ///   Point2D object representing the second endpoint of the wall.
    /// </summary>
    [JsonPropertyName("p2")]
    [JsonRequired]
    [JsonInclude]
    public Point2D P2 { get; set; } 

    /// <summary>
    ///   Constructs a wall with a default starting and endpoints 
    ///   (both Point2D objects at X=0 and Y=0).
    /// </summary>
    public Wall()
    {
        ID = 0;
        P1 = new();
        P2 = new();
    }
}
