using GeoSurv.Dobrianskiy;

namespace GeoSurv.Motta;

/**
 * Class for triangle type of Monsters.
 */
public class Triangle : Monster {

    // private Handler handler;
    // private Game game;
    private static readonly float DEFAULT_SPEED = 1.2f; // default speed of triangle
    private static readonly float MAX_SPEED = 3f; // max speed of BIG triangle
    private static readonly int DEFAULT_H_DIMENSION = 20; // default height of triangle
    private static readonly int MAX_H_DIMENSION = 50; // max height of (big) triangle
    private static readonly int DEFAULT_W_DIMENSION = 20; // default width of triangle
    private static readonly int MAX_W_DIMENSION = 50; // max width of (big) triangle
    private static readonly int DEFAULT_HEALTH = 5; // default health of triangle
    private static readonly int MAX_HEALTH = 20; // default health of BIG triangle
    private static readonly int DEFAULT_POWER = 5; // default power of triangle
    private static readonly int MAX_POWER = 5; // default power of BIG triangle
    private static int _counter;
    private const string _name = "Triangle-";

    /**
     * Triangle constructor.
     * 
     * @param h handler
     */
    public Triangle(Handler h) : base (0, 0, h)
    {
        //Triangle.counter++;
        //this.name = name + Triangle.counter;
        _health = DEFAULT_HEALTH;
        _speed = DEFAULT_SPEED;
        _power = DEFAULT_POWER;
        _height = DEFAULT_H_DIMENSION;
        _width = DEFAULT_W_DIMENSION;
        _texture = Texture.Triangle;
    }

    /**
     * On each tick, triangle monsters try to reach the player.
     */
   
    public override void Tick() => ReachTarget();

    public new void SetIsBig(bool isBig)
    {
        _health = MAX_HEALTH;
        _speed = MAX_SPEED;
        _power = MAX_POWER;
        _height = MAX_H_DIMENSION;
        _width = MAX_W_DIMENSION;
        _texture = Texture.TriangleBig;
    }

}
