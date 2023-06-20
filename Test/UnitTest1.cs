namespace Test;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        Assert.AreEqual(1, 1);
    }
    
    [TestMethod]
    public void TestMethod2()
    {
        Assert.IsFalse(1==2);
    }

}