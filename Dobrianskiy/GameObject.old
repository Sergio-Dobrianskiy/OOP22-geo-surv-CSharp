using System.Drawing;

namespace Dobrianskiy;

using Motta;

public class GameObject : ITickingObject
{
    private float x;
    private float y;
    protected ID id;
    protected int height;
    protected int width;
    protected float velX;
    protected float velY;
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
    
    public float GetX()
    {
        return x;
    }

    public void SetX(float x)
    {
        this.x = x;
    }

    public float GetY()
    {
        return y;
    }

    public void SetY(float y)
    {
        this.y = y;
    }
    
    public ID GetId()
    {
        return id;
    }
    
    public int GetRenderX()
    {
        return (int)x - width / 2;
    }

    public int GetRenderY()
    {
        return (int)y - height / 2;
    }
    
    public Rectangle GetShape()
    {
        return new Rectangle(GetRenderX(), GetRenderY(), width, height);
    }
}