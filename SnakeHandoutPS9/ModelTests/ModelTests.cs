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
}
