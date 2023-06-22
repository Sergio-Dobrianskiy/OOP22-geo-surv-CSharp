using GeoSurv.Testa;
using GeoSurv.Dobrianskiy;
using GeoSurv.Motta;

namespace Test;

[TestClass]
public class TestPlayer
{
    private Player player;

    [TestInitialize]
    public void SetUp()
    {
        Handler handler = new Handler();
        player = new Player(0, 0, handler);
    }

    [TestMethod]
    public void TestGetExperience()
    {
        int expectedExperience = 0;
        int actualExperience = player.GetExperience();
        Assert.AreEqual(expectedExperience, actualExperience);
    }

    [TestMethod]
    public void TestGetLife()
    {
        int expectedLife = 100;
        int actualLife = player.GetLife();
        Assert.AreEqual(expectedLife, actualLife);
    }
}