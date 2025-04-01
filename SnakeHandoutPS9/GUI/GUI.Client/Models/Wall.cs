using System;

public class Wall
{
    public int ID { get; private set; }

    public Point2D P1 { get; set; }

    public Point2D P2 { get; set; } 

    public Wall()
    {
        P1 = new();
        P2 = new();
    }

}
