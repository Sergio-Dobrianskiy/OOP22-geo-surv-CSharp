using GeoSurv.Dobrianskiy;
using GeoSurv.Testa;

namespace GeoSurv.Motta;

/// <summary>
/// Abstract Class for generic monsters.
/// </summary>

public abstract class Monster : GameObject, IMonster, IObserverEntity<GameObject>
{

    private static readonly int DefaultExperience = 1;
    private static readonly int BouncingSpeedMultiplier = 10;
    private static readonly int MaxHitsPerSecond = 5;
    private static readonly long HitCooldown = 1000 / MaxHitsPerSecond;
    private readonly Drop _dropStrategy; // strategy for dropping life or experience
    private long _lastHitTime;

    protected static Handler _handler;
    protected int _health; // need to be shared with monters subclasses @Sergio-Dobrianskiy
    protected int _power; // power which the plyer is hit by when in contact with a monster
    protected float _mx; // Player Position throu observer
    protected float _my; // Player Position throu observer
    protected Player _player;
    protected double _speed;

    ///Monster constructor.<summary>
    /// Monster constructor.
    /// </summary>
    /// <param name="x">x</param>
    /// <param name="y">y</param>
    /// <param name="h">handler</param>
    protected Monster(float x, float y, Handler h) : base(x, y, ID.Monster)
    {
        _handler = h;
        _player = h.GetPlayer();
        _player.AddObserver(this);
        _lastHitTime = 0;
        _dropStrategy = new Drop(this, _handler);
    }

    /// <returns>monster health</returns>
    public int GetHealth() => _health;
    
    /// <returns>monster power</returns>
    public int GetPower() => _power;

    /// <returns>monster is dead</returns>
    public bool IsDead() => GetHealth() <= 0;
    
    /// <summary>
    /// Evaluate the damage of weapon to the monster.
    /// </summary>
    /// <param name="weaponDamage">damage quantity</param>
    public void Hit(int weaponDamage)
    {
        long currentTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        if (currentTime - _lastHitTime >= HitCooldown) {
            _health -= weaponDamage;
            _lastHitTime = currentTime;
            Bounce();
        }

        if (IsDead())
        {
            _player.RemoveObserver(this);
            Die();
        }
    }
    
    /// <summary>
    /// Entity bounce if hit by weapon.
    /// </summary>
    public void Bounce()
    {
        _velX = -_velX * BouncingSpeedMultiplier;
        _velY = -_velY * BouncingSpeedMultiplier;
    }

    /// <summary>
    /// Monster dies.
    /// </summary>
    public void Die()
    {
        _handler.AddObject(_dropStrategy.DropGameObject());
        _handler.RemoveObject(this); 
    }
    
    /// <summary>
    /// Monster update of player position
    /// </summary>
    public void Update()
    {
        _mx = _player.GetX();
        _my = _player.GetY();
    }

    /// <summary>
    /// Try to reach the target as defined by {@link IMonster}.
    /// Subclasses extending Reachtarget should override this method to provide
    /// specific implementation details.
    /// </summary>
    public void ReachTarget()
    {
        SetX(GetX() + _velX);
        SetY(GetY() + _velY);

        float angle = (float) Math.Atan2(_my - GetY() + 8, _mx - GetX() + 4);

        _velX = (float) ((_speed) * Math.Cos(angle));
        _velY = (float) ((_speed) * Math.Sin(angle));
    }

    /// <summary>
    /// Make the monster a big one
    /// </summary>
    /// <param name="b"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void SetIsBig(bool b)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Set the position where the monster appear.
    /// It's random in an area between to circle (radius minDistance & maxDistance)
    /// </summary>
    /// <param name="minDistance"></param>
    /// <param name="maxDistance"></param>
    public void SetStartingPosition(float minDistance, float maxDistance)
    {
        Pair<float, float> randomPosition = Func.RandomPoint(minDistance, maxDistance);
        Update(); 
        SetX(_mx + randomPosition.GetX());
        SetY(_my + randomPosition.GetY());
    }
    
    /// <returns>default experience a monster drop when dies.</returns>
    public int GetDefaultExperience() => DefaultExperience;
    
    public override void Collide()
    {
    }
}
