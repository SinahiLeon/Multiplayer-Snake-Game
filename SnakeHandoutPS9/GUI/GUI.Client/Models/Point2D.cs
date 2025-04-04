namespace GUI.Client.Models;

using System;
using System.Text.Json.Serialization;

/// <summary>
///   An object storing X and Y coordinates for 2D space.
/// </summary>
public class Point2D
{

    /// <summary>
    ///   The X coordinate in 2D space.
    /// </summary>
    [JsonRequired]
    [JsonInclude] 
    public int X {  get; private set; }

    /// <summary>
    ///   The Y coordinate in 2D space.
    /// </summary>
    [JsonRequired]
    [JsonInclude]
    public int Y { get; private set; }

	/// <summary>
	///   Constructs a Point2D object with X=0 and Y=0.
	/// </summary>
	public Point2D()
	{
		X = 0;
		Y = 0;
	}
}
