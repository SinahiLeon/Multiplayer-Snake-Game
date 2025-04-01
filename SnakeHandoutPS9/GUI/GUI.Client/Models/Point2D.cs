namespace GUI.Client.Models;

using System;

/// <summary>
///   An object storing X and Y coordinates for 2D space.
/// </summary>
public class Point2D
{

	/// <summary>
	///   The X coordinate in 2D space.
	/// </summary>
	public int X {  get; set; }

    /// <summary>
    ///   The Y coordinate in 2D space.
    /// </summary>
    public int Y { get; set; }

	/// <summary>
	///   Constructs a Point2D object with X=0 and Y=0.
	/// </summary>
	public Point2D() { }

    /// <summary>
    ///   Constructs a Point2D object with the given X and Y parameters.
    /// </summary>
    /// <param name="x"> Integer representing the X coordinate. </param>
    /// <param name="y"> Integer representing the Y coordinate. </param>
    public Point2D(int x, int y)
	{
		X = x;
		Y = y;
	}
}
