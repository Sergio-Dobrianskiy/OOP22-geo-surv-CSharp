using GeoSurv.Motta;

namespace GeoSurv.Dobrianskiy;

public class AutoBullet : Bullet
{
    private const int AutobulletHeight = 15;
    private const int AutobulletWidth = 15;

    public AutoBullet(float x, float y, Handler handler, int damage)
        : base(x, y, handler, damage)
    {
        //this.height = AutobulletHeight;
        //this.width = AutobulletWidth;
        // this.texture = Texture.BULLET;
        this.collisionBehavior = new RemoveOnCollisionBehavior();
    }

    public override void Collide()
    {
        this.collisionBehavior.Collide(this, this.handler);
    }
}
