using GeoSurv.Dobrianskiy;
using GeoSurv.Motta;
using GeoSurv.Testa;

namespace Test;

[TestClass]
public class TestMonsters
{
    [TestMethod]
    public void TestMonsterDeath()
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
    
    [TestMethod]
    public void TestMonsterHit()
    {
        Handler handler = new Handler();
        
        // bullet creation
        AutoBullet bullet = new AutoBullet(0, 0, handler, 2);
        handler.AddObject(bullet);
        
        // player creation
        Player player = new Player(0, 0, handler);
        handler.AddPlayer(player);

        // monster creation
        Monster monster = new Ball(handler);
        handler.AddObject(monster);
        
        // monster health before hit
        int monsterHealth = monster.GetHealth();
        
        // monster is hit by bullet
        monster.Hit(bullet.GetDamage());
        
        // check if health is less than before
        Assert.IsTrue(monster.GetHealth() < monsterHealth);
        
    }
}