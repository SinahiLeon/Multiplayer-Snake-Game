// <summary>
// This class stores all the information needed for the
// world where players may collect powerups to grow. The 
// constructor and shallow copy constructor code was 
// derived from the GameLab solution. 
// </summary>
// <author> D. Mason Hair and Sinahi Leon </author>
// <data> 4/3/2025 </date>

using System.Drawing;
using System.Numerics;
using System.Text.Json.Serialization;

namespace GUI.Client.Models;

/// <summary>
/// This class stores all the information needed for the 
/// world where players may collect powerups to grow.
/// </summary>
 public class World
{
    /// <summary>
    ///   Unique id used to identify the player.
    /// </summary>
    public int PlayerID { get; set; }

    /// <summary>
    /// Stores an int that represents the size of the world. 
    /// </summary>
    public int Size { get; set; }

    /// <summary>
    /// Dictionary where the snake's int ID is the key and the Snake object is the value.
    /// </summary>
    public Dictionary<int, Snake> Snakes { get; private set; }

    /// <summary>
    /// Dictionary where the snake's int ID is the key and the Snake object is the value.
    /// </summary>
    public Dictionary<int, Wall> Walls { get; private set; }


    /// <summary>
    /// Dictionary where the snake's int ID is the key and the Snake object is the value.
    /// </summary>
    public Dictionary<int, Powerup> Powerups { get; private set; }

    /// <summary>
    /// Creates a new world with the given size
    /// </summary>
    /// <param name="size"> size of the world to be constructed </param>
    public World(int size)
    {
        Size = size;
        Snakes = new Dictionary<int, Snake>();
        Walls = new Dictionary<int, Wall>();
        Powerups = new Dictionary<int, Powerup>();
    }

    /// <summary>
    /// Shallow copy constructor that makes a copy of 
    /// all the information from the world.
    /// </summary>
    /// <param name="world"> world to be copied </param>
    public World(World world)
    {
        Size = world.Size;
        Snakes = new(world.Snakes);
        Walls = new(world.Walls);
        Powerups = new(world.Powerups);
    }

}



