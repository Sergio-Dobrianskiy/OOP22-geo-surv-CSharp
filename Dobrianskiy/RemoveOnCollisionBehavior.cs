namespace Dobrianskiy;

public class RemoveOnCollisionBehavior : ICollisionBehavior
{
    public void Collide(GameObject ths, Handler handler)
    {
        handler.RemoveObject(ths);
    }
}