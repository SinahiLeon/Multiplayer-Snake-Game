namespace GUI.Client.Controllers;

/// <summary>
///   Used for helping the drawing method choose a color for a snake.
/// </summary>
public class ColorChooser
{
    /// <summary>
    ///   Enter any positive integer and get a color back as a string.
    /// </summary>
    public static string ChooseColor(int id)
    {
        int modulasValue = id % 8;
        switch(modulasValue)
        {
            case 0: return $"rgb(0, 0, 255)";
            case 1: return $"rgb(255, 255, 255)";
            case 2: return $"rgb(0, 255, 0)";
            case 3: return $"rgb(255, 255, 0)";
            case 4: return $"rgb(100, 100, 100)";
            case 5: return $"rgb(230, 80, 0)";
            case 6: return $"rgb(23, 236, 236)";
            default: return $"rgb(0, 100, 0)";
        }
    }
}
