using GeoSurv.Dobrianskiy;

namespace Test;

[TestClass]
public class TestCollisions
{
    [TestMethod]
    public void PlayerCollidesWithBlock()
    {
        Handler handler = new Handler();
        Player player = new Player(0, 0, handler);
        BlockFactory blockFactory = new BlockFactory();
        Block? block = blockFactory.CreateBlock(BlockType.WALL, 0, 0);
        Assert.IsTrue(block != null);
        Assert.IsTrue(Collisions.IsColliding(player, block, ID.Block));

        block = blockFactory.CreateBlock(BlockType.WALL, 1000, 1000);
        Assert.IsTrue(block != null);
        Assert.IsFalse(Collisions.IsColliding(player, block, ID.Block));
    }

    [TestMethod]
    public void AutoBulletCollidesWithBlock()
    {
        Handler handler = new Handler();
        AutoBullet bullet = new AutoBullet(0, 0, handler, 1);
        handler.AddObject(bullet);
        BlockFactory blockFactory = new BlockFactory();
        Block? block = blockFactory.CreateBlock(BlockType.WALL, 0, 0);
        
        Assert.IsTrue(block != null);
        Assert.IsTrue( Collisions.IsColliding(bullet, block, ID.Block));
        Assert.IsTrue(handler.GetGameObjects().Contains(bullet));

        bullet.Collide();
        Assert.IsFalse(handler.GetGameObjects().Contains(bullet));

        bullet = new AutoBullet(1000, 1000, handler, 1);
        Assert.IsTrue(block != null);
        Assert.IsFalse(Collisions.IsColliding(bullet, block, ID.Block));
    }
        
}