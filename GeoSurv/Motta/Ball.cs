using GeoSurv.Dobrianskiy;

namespace GeoSurv.Motta;

public class Ball : Monster {
    private static readonly float DEFAULT_SPEED = 2f; // default speed of Ball
    private static readonly float MAX_SPEED = 3f; // max speed of BIG Ball
    private static readonly int DEFAULT_H_DIMENSION = 40; // default height of Ball
    private static readonly int MAX_H_DIMENSION = 40; // max height of (big) Ball
    private static readonly int DEFAULT_W_DIMENSION = 40; // default width of Ball
    private static readonly int MAX_W_DIMENSION = 40; // max width of (big) Ball
    private static readonly int DEFAULT_HEALTH = 10; // default health of Ball
    private static readonly int MAX_HEALTH = 15; // default health of BIG Ball
    private static readonly int DEFAULT_POWER = 10; // default power of Ball
    private static readonly int MAX_POWER = 20; // default power of BIG Ball

    /**
     * Ball constructor.
     * 
     * @param h handler
     */
    public Ball(Handler h) : base(0, 0, h)
    {
        _health = DEFAULT_HEALTH;
        _speed = DEFAULT_SPEED;
        _power = DEFAULT_POWER;
        _height = DEFAULT_H_DIMENSION;
        _width = DEFAULT_W_DIMENSION;
        _texture = Texture.Ball;

    }

    /**
     * On each tick, Ball monsters try to reach the player.
     */
    public override void Tick() => ReachTarget();
    
    public new void SetIsBig(bool isBig) {
        _health = MAX_HEALTH;
        _speed = MAX_SPEED;
        _power = MAX_POWER;
        _height = MAX_H_DIMENSION;
        _width = MAX_W_DIMENSION;
        _texture = Texture.Ball;
    }

    /**
     * Modified by addition of a little bit of deviation with Math.random.
     */
    public new void ReachTarget() {
        SetX(GetX() + _velX);
        SetY(GetY() + _velY);

        // added a little bit of deviation with Math.random
        Random random = new Random();
        float angle = (float) (Math.Atan2(_my - GetY() + 8, _mx - GetX() + 4) + random.NextDouble());
        _velX = (float) ((_speed) * Math.Cos(angle));
        _velY = (float) ((_speed) * Math.Sin(angle));
    }
}
