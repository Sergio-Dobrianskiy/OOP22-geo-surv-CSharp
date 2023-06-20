using GeoSurv.Dobrianskiy;
using GeoSurv.Motta;

namespace Test;

[TestClass]
public class TestMonsters
{
    [TestMethod]
    public void TestMonster()
    {
        Handler handler = new Handler();
        Player player = new Player(0, 0, handler);
        handler.AddPlayer(player);

        /// monster ball created
        Monster monster = new Ball(handler);
        Assert.IsFalse(monster.IsDead());
        
        /// monster ball hit and dead
        monster.Hit(100);
        Assert.IsTrue(monster.IsDead());
        
    }
}