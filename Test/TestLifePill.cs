using GeoSurv.Dobrianskiy;
using GeoSurv.Motta;

namespace Test;

[TestClass]
public class TestLifePill
{
    [TestMethod]
    public void TestLife()
    {
        Handler h = new Handler();
        Life l = new Life(0, 0, h);
        Assert.IsInstanceOfType(l,typeof(Life));
    }
}