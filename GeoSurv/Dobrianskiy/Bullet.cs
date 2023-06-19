using GeoSurv.Motta;
namespace GeoSurv.Dobrianskiy;

public abstract class Bullet : GameObject
{
    protected long lifeSpan = 5000L;
    protected ICollisionBehavior collisionBehavior;
    protected Handler handler;
    private int damage;
    private readonly long creationTime;
    private readonly Collisions collisions;

    public Bullet(float x, float y, Handler handler, int damage) : base(x, y, ID.Bullet)
    {
        this.handler = handler;
        this.creationTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        this.collisions = new Collisions(handler);
        this.damage = damage;
        this.collisionBehavior = new NoCollisionBehavior();
    }

    public override void Tick()
    {
        if (StillAlive())
        {
           // UpdatePosition(velX, velY);
            collisions.CheckBulletCollisions(this);
        }
        else
        {
            handler.RemoveObject(this);
        }
    }

    private void UpdatePosition(float velX, float velY)
    {
        SetX(GetX() + velX);
        SetY(GetY() + velY);
    }

    protected bool StillAlive()
    {
        long currentTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        if ((currentTime - creationTime) > lifeSpan)
        {
            handler.RemoveObject(this);
            return false;
        }
        return true;
    }

    public int GetDamage()
    {
        return damage;
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    public override void Collide()
    {
        collisionBehavior.Collide(this, handler);
    }
}