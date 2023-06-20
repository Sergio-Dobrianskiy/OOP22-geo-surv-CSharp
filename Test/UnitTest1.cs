using GeoSurv.Dobrianskiy;
using GeoSurv.Motta;

namespace Test;

[TestClass]
public class UnitTest1
{
    #region "TestMotta"
    [TestMethod]
    public void TestMethod1()
    {
        Handler h = new Handler();
        Life l = new Life(0, 0, h);
        Assert.IsInstanceOfType(l,typeof(Life));
    }
    
    [TestMethod]
    public void TestMethod2()
    {
        Assert.IsFalse(1==2);
    }
    #endregion

    #region "TestDobrianskiy"

    #endregion
    
    #region "TestTesta"

    #endregion
}