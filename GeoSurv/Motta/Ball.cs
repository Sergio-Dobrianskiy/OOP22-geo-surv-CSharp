using GeoSurv.Dobrianskiy;

namespace GeoSurv.Motta;

/// <summary>
/// Ball monster class
/// </summary>
public class Ball : Monster {
    private static readonly float DefaultSpeed = 2f; // default speed of Ball
    private static readonly float MaxSpeed = 3f; // max speed of BIG Ball
    private static readonly int DefaultHDimension = 40; // default height of Ball
    private static readonly int MaxHDimension = 40; // max height of (big) Ball
    private static readonly int DefaultWDimension = 40; // default width of Ball
    private static readonly int MaxWDimension = 40; // max width of (big) Ball
    private static readonly int DefaultHealth = 10; // default health of Ball
    private static readonly int MaxHealth = 15; // default health of BIG Ball
    private static readonly int DefaultPower = 10; // default power of Ball
    private static readonly int MaxPower = 20; // default power of BIG Ball
    
    /// <summary>
    /// Ball constructor.
    /// </summary>
    /// <param name="h">handler</param>
    public Ball(Handler h) : base(0, 0, h)
    {
        _health = DefaultHealth;
        _speed = DefaultSpeed;
        _power = DefaultPower;
        _height = DefaultHDimension;
        _width = DefaultWDimension;
        _texture = Texture.Ball;
    }
    
    /// <summary>
    /// On each tick, Ball monsters try to reach the player.
    /// </summary>
    public override void Tick() => ReachTarget();
    
    /// <summary>
    /// Make the monster big
    /// </summary>
    /// <param name="isBig"></param>
    public new void SetIsBig(bool isBig) {
        _health = MaxHealth;
        _speed = MaxSpeed;
        _power = MaxPower;
        _height = MaxHDimension;
        _width = MaxWDimension;
        _texture = Texture.Ball;
    }
    
    /// <summary>
    /// Modified by addition of a little bit of deviation.
    /// </summary>
    public new void ReachTarget()
    {
        SetX(GetX() + _velX);
        SetY(GetY() + _velY);
        
        Random random = new Random();
        float angle = (float) (Math.Atan2(_my - GetY() + 8, _mx - GetX() + 4) + random.NextDouble());
        _velX = (float) ((_speed) * Math.Cos(angle));
        _velY = (float) ((_speed) * Math.Sin(angle));
    }
}
