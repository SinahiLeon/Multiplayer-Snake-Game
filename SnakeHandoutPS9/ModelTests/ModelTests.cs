// <summary>
//   This is a class used to test model class methods.
// </summary>
// <author> D. Mason Hair and Sinahi Leon </author>
// <data> 4/3/2025 </date>

using System.Text.Json;
using GUI.Client.Models;

namespace ModelTests;

/// <summary>
///   Test class for testing all model objects that are in the GUI project.
/// </summary>
[TestClass]
public sealed class ModelTests
{
    // =============================
    // ---- Point2D class Tests ----
    // =============================

    /// <summary>
    ///   Tests that deserialization works for this class.
    /// </summary>
    [TestMethod]
    public void Point2D_SerializeAndDeserialize_Valid()
    {
        string expectedJson = "{\"X\":111,\"Y\":222}";

        Point2D? point2D = JsonSerializer.Deserialize<Point2D>(expectedJson);

        string newJson = JsonSerializer.Serialize(point2D);

        Assert.AreEqual(expectedJson, newJson);
    }

    // =============================
    // ---- Powerup class Tests ----
    // =============================

    /// <summary>
    ///   Tests that deserialization works for this class.
    /// </summary>
    [TestMethod]
    public void Powerup_SerializeAndDeserialize_Valid()
    {
        string expectedJson = "{\"power\":1,\"loc\":{\"X\":100,\"Y\":200},\"died\":false}";

        Powerup? powerup = JsonSerializer.Deserialize<Powerup>(expectedJson);

        string newJson = JsonSerializer.Serialize(powerup);

        Assert.AreEqual(expectedJson, newJson);
    }


    // =============================
    // ---- Wall class Tests ----
    // =============================

    /// <summary>
    ///   Tests that deserialization works for this class.
    /// </summary>
    [TestMethod]
    public void Wall_SerializeAndDeserialize_Valid()
    {
        string expectedJson = "{\"wall\":1,\"p1\":{\"X\":50,\"Y\":190},\"p2\":{\"X\":170,\"Y\":120}}";

        Wall? wall = JsonSerializer.Deserialize<Wall>(expectedJson);

        string newJson = JsonSerializer.Serialize(wall);

        Assert.AreEqual(expectedJson, newJson);
    }

    // =============================
    // ---- Snake class Tests ----
    // =============================

    /// <summary>
    ///   Tests that deserialization works for this class.
    /// </summary>
    [TestMethod]
    public void Snake_SerializeAndDeserialize_Valid()
    {
        string expectedJson = "{\"snake\":0,\"name\":\"Travis\",\"body\":[{\"X\":-689,\"Y\":462},{\"X\":-809,\"Y\":462}],\"dir\":{\"X\":-1,\"Y\":0},\"score\":0,\"died\":false,\"alive\":true,\"dc\":false,\"join\":false}";

        Snake? snake = JsonSerializer.Deserialize<Snake>(expectedJson);

        string newJson = JsonSerializer.Serialize(snake);

        Assert.AreEqual(expectedJson, newJson);
    }
}
