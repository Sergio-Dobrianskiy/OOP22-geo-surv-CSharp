namespace Dobrianskiy;

public class Collisions
{
    private readonly Handler handler;

    public Collisions(Handler handler)
    {
        this.handler = handler;
    }

    public void CheckPlayerCollisions()
    {
        var goIterator = handler.GetGameObjects().GetEnumerator();
        var player = handler.GetPlayer();

        while (goIterator.MoveNext())
        {
            var obj = goIterator.Current;

            if (IsColliding(player, obj, ID.Block))
            {
                player.Collide();
            }
            // else if (IsColliding(player, obj, ID.Monster))
            // {
            //     player.Hit(((Monster)obj).GetPower());
            // }
            // else if (IsColliding(player, obj, ID.Experience))
            // {
            //     handler.GetPlayer().SetExperience(((Experience)obj).GetExp());
            //     obj.Collide();
            // }
            // else if (IsColliding(player, obj, ID.Life))
            // {
            //     handler.GetPlayer().SetLife(((Life)obj).GetDefaultLife());
            //     obj.Collide();
            // }
        }
    }

    public void CheckBulletCollisions(Bullet bullet)
    {
        var goIterator = handler.GetGameObjects().GetEnumerator();

        while (goIterator.MoveNext())
        {
            var obj = goIterator.Current;

            if (IsColliding(bullet, obj, ID.Block))
            {
                bullet.Collide();
            }
            // else if (IsColliding(bullet, obj, ID.Monster))
            // {
            //     ((Monster)obj).Hit(bullet.GetDamage());
            //     bullet.Collide();
            // }
        }
    }

    public static bool IsColliding(GameObject obj1, GameObject obj2, ID id)
    {
        return obj2.GetId() == id && obj1.GetShape().IntersectsWith(obj2.GetShape());
    }

    public static bool IsColliding(GameObject obj1, GameObject obj2)
    {
        return obj1.GetShape().IntersectsWith(obj2.GetShape());
    }

    // public void StopMovements()
    // {
    //     var player = handler.GetPlayer();
    //     player.SetX(player.GetX() + player.GetVelX() * -1);
    //     player.SetY(player.GetY() + player.GetVelY() * -1);
    // }
}
    
