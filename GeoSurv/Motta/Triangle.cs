using GeoSurv.Dobrianskiy;

namespace GeoSurv.Motta;

/// <summary>
/// Class for triangle type of Monsters.
/// </summary>
public class Triangle : Monster {

    private static readonly float DefaultSpeed = 1.2f; // default speed of triangle
    private static readonly float MaxSpeed = 3f; // max speed of BIG triangle
    private static readonly int DefaultHDimension = 20; // default height of triangle
    private static readonly int MaxHDimension = 50; // max height of (big) triangle
    private static readonly int DefaultWDimension = 20; // default width of triangle
    private static readonly int MaxWDimension = 50; // max width of (big) triangle
    private static readonly int DefaultHealth = 5; // default health of triangle
    private static readonly int MaxHealth = 20; // default health of BIG triangle
    private static readonly int DefaultPower = 5; // default power of triangle
    private static readonly int MaxPower = 5; // default power of BIG triangle

    /// <summary>
    /// Triangle constructor.
    /// </summary> 
    /// <param name="h">handler</param>
    public Triangle(Handler h) : base (0, 0, h)
    {
        _health = DefaultHealth;
        _speed = DefaultSpeed;
        _power = DefaultPower;
        _height = DefaultHDimension;
        _width = DefaultWDimension;
        _texture = Texture.Triangle;
    }

    /// <summary>
    /// On each tick, triangle monsters try to reach the player.
    /// </summary>
    public override void Tick() => ReachTarget();

    /// <summary>
    /// Set the monster a big one.
    /// </summary>
    /// <param name="isBig">bool big or not </param>
    public new void SetIsBig(bool isBig)
    {
        _health = MaxHealth;
        _speed = MaxSpeed;
        _power = MaxPower;
        _height = MaxHDimension;
        _width = MaxWDimension;
        _texture = Texture.TriangleBig;
    }
    
}
