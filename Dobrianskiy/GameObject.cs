namespace Dobrianskiy;

using Motta;

public class GameObject : ITickingObject
{
    private float x;
    private float y;
    protected ID id;
    public GameObject(float x, float y, ID id)
    {
        this.x = x;
        this.y = y;
        this.id = id;
    }
    
    public void Tick()
    {
        throw new NotImplementedException();
    }
}