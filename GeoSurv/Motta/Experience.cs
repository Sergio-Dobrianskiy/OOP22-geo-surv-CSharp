using GeoSurv.Dobrianskiy;

namespace GeoSurv.Motta;

/// <summary>
/// Class for experience pills, created at monsters death.
/// More experience make player go to new levels.
/// </summary>
public class Experience : GameObject, IObserverEntity<Player> {

    private static readonly int ExperienceHeight = 25;
    private static readonly int ExperienceWidth = 20;
    private static readonly float PickUpSpeed = 10;
    private readonly Player _player;
    private readonly Handler _handler;
    private readonly int _exp;
    private readonly ICollisionBehavior _collisionBehavior;
    private float _mx; // Player Position throu observer
    private float _my; // Player Position throu observer

    /// <summary>
    /// The experience pill is created at monster's death, at the posistion where
    /// moster dies.
    /// </summary>
    /// <param name="x">position</param>
    /// <param name="y">position</param>
    /// <param name="exp">experience</param>
    /// <param name="h">handler</param>
    public Experience(float x, float y, int exp, Handler h) : base(x, y, ID.Experience)
    {
        _exp = exp;
        _height = ExperienceHeight;
        _width = ExperienceWidth;
        _texture = Texture.Experience;
        _handler = h;
        _player = _handler.GetPlayer();
        _player.AddObserver(this);
        _collisionBehavior = new RemoveOnCollisionBehavior();
    }
    
    /// <summary>
    /// On each game tick the experience tries to reach the player,
    /// if it's close
    /// </summary>
    public override void Tick()
    {
        if (_player.GetLevel() > 1)
        {
            ReachTarget();
        }
    }
    
    /// <returns>Pill experience</returns>
    public int GetExp() => _exp;
    
    /// <summary>
    /// Get player position information
    /// </summary>
    public void Update()
    {
        _mx = _player.GetX();
        _my = _player.GetY();
    }
    
    /// <summary>
    /// If player is near and has gained some experience(levelsup) pills are attracted.
    /// </summary>
    public void ReachTarget()
    {
        // distance from the player and experience pill
        float _distance = CalculateDistance(_player.GetX(), _player.GetY(), GetX(), GetY());
        // maxDistance: to determine the max distance a pill can reach the player and
        // increment +10% distance each level
        float _maxDistance = 80 + (10 * _player.GetLevel());

        if (_distance <= _maxDistance)
        {
            SetX(GetX() + _velX);
            SetY(GetY() + _velY);

            float angle = (float) Math.Atan2(_my - GetY() + 8, _mx - GetX() + 4);

            _velX = (float) ((PickUpSpeed) * Math.Cos(angle));
            _velY = (float) ((PickUpSpeed) * Math.Sin(angle));
        }
    }

    /// <summary>
    /// calculate distance between two point (x1,y1) and (x2,y2) in a 2d space.
    /// </summary>
    /// <param name="x1">obj 1 x pos</param>
    /// <param name="y1">obj 1 y pos</param>
    /// <param name="x2">obj 2 x pos</param>
    /// <param name="y2">obj 2 y pos</param>
    /// <returns>distance between two objects in game</returns>
    private float CalculateDistance(float x1, float y1, float x2, float y2)
    {
        float dx = x2 - x1;
        float dy = y2 - y1;
        return (float) Math.Sqrt(dx * dx + dy * dy);
    }

    /// <summary>
    /// starts collision behavior, no behavior by default.
    /// </summary>
    public override void Collide()
    {
        _collisionBehavior.Collide(this, _handler);
    }

}
