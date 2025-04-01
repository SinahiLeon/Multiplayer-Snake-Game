using System;

public class Point2D
{
	public int X {  get; set; }
	public int Y { get; set; }

	// Initialized to (0,0)
	public Point2D() { };

	public Point2D(int x, int y)
	{
		X = x;
		Y = y;
	}
}
