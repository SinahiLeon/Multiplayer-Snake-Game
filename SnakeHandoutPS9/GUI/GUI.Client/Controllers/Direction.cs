// <summary>
//   This is an enum used to represent directions that the GUI
//   can choose  for the purposes of instructing the server on
//   what movement command to perform. Also restricts the number
//   of movement opitions.
// </summary>
// <author> D. Mason Hair and Sinahi Leon </author>
// <data> 4/8/2025 </date>

namespace GUI.Client.Controllers;

/// <summary>
///   Enum to represent possible direction commands for the view 
///   and controller to use.
/// </summary>
public enum Direction
{
    /// <summary>
    ///   Represents the up direction command in 2D space.
    /// </summary>
    UP,
    /// <summary>
    ///   Represents the down direction command in 2D space.
    /// </summary>
    DOWN,
    /// <summary>
    ///   Represents the left direction command in 2D space.
    /// </summary>
    LEFT,
    /// <summary>
    ///   Represents the right direction command in 2D space.
    /// </summary>
    RIGHT,
    /// <summary>
    ///   Represents no direction command in 2D space.
    /// </summary>
    NONE
}


