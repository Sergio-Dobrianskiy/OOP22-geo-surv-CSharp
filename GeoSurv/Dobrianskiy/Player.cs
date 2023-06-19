namespace GeoSurv;

public class Player : GameObject
{
    public Player(float x, float y, ID id) : base(x, y, id)
    {
    }

    public override void Tick()
    {
        throw new NotImplementedException();
    }

    public override void Collide()
    {
        throw new NotImplementedException();
    }
}