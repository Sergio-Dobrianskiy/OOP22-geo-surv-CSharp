﻿using GeoSurv.Dobrianskiy;
using GeoSurv.Motta;

namespace Test;

[TestClass]
public class TestDobrianskiy
{
    [TestMethod]
    public void CreateBullets()
    {
        Handler handler = new Handler();
        const int damage = 10;
        // const int size = 10;
        Bullet bullet;

        handler.AddPlayer(new Player(0, 0, handler));

        bullet = new AutoBullet(0, 0, handler, damage);
        Assert.AreEqual(typeof(AutoBullet), bullet.GetType());
    }

    [TestMethod]
    public void TestBulletDamage()
    {
        Handler handler = new Handler();
        const int damage = 10;
        // const int size = 10;

        handler.AddPlayer(new Player(0, 0, handler));

        Bullet bullet = new AutoBullet(0, 0, handler, damage);
        Assert.AreEqual(damage, bullet.GetDamage());
    }
}