using GeoSurv.Dobrianskiy;

namespace GeoSurv.Motta;

/// <summary>
/// Life pills are created randomly (more or less 1/50 a time) when a monster dies.
/// No experience is created if life pill is created.
/// </summary>
public class Life : GameObject
{
    private static readonly int DefaultLife = 10;
    private static readonly int DefaultLifeHeight = 25;
    private static readonly int DefaultLifeWidth = 20;
    private readonly Handler _handler;
    private readonly ICollisionBehavior _collisionBehavior;
    
    /// <summary>
    /// Life pill constructor.
    /// </summary>
    /// <param name="x">position</param>
    /// <param name="y">position</param>
    /// <param name="h">handler</param>
    public Life(float x, float y, Handler h) : base(x,y,ID.Life)
    {
        _height = DefaultLifeHeight;
        _width = DefaultLifeWidth;
        _texture = Texture.Life;
        this._handler = h;
        this._collisionBehavior = new RemoveOnCollisionBehavior();
    }
    
    /// <summary>
    /// Life pills do not tick().
    /// </summary>
    public override void Tick()
    {
    }
    
    /// <returns>amount of experience in the pill</returns>
    public int GetDefaultLife() => DefaultLife;
    
    /// <summary>
    /// starts collision behavior, no behavior by default.
    /// </summary>
    public override void Collide()
    {
        _collisionBehavior.Collide(this, _handler);
    }

}
