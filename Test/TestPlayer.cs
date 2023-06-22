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
}