using GeoSurv.Motta;
namespace GeoSurv.Dobrianskiy;

public class Player : GameObject
{
    public Player(float x, float y, Handler handler) : base(x, y, ID.Player)
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
    
    public int GetLevel()
    {
        throw new NotImplementedException();
    }

    public void AddObserver(GameObject gameObject)
    {
        throw new NotImplementedException();
    }

    public void RemoveObserver(GameObject gameObject)
    {
        throw new NotImplementedException();
    }
}