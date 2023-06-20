using GeoSurv.Dobrianskiy;

namespace GeoSurv.Motta;

//
//import it.unibo.geosurv.model.GameObject;
//import it.unibo.geosurv.model.Handler;
//import it.unibo.geosurv.model.ID;
//import it.unibo.geosurv.model.IObserverEntity;
//import it.unibo.geosurv.model.drops.Drop;
//import it.unibo.geosurv.model.player.Player;
//import it.unibo.geosurv.model.utility.Func;
//import it.unibo.geosurv.model.utility.Pair;
//
/**
 * Abstract Class for generic monsters.
 */
public abstract class Monster : GameObject, IMonster, IObserverEntity<Player>
{

    private static readonly int DefaultExperience = 1;
    private static readonly int Bouncingspeedmultiplier = 10;

    private static readonly int MaxHitsPerSecond = 5;
    private static readonly long HitCooldown = 1000 / MaxHitsPerSecond;

    private long _lastHitTime; 
    //private static int _monstersCounter;
    //private static int _monstersDeadCounter;

    protected static Handler _handler;
    protected int _health; // need to be shared with monters subclasses @Sergio-Dobrianskiy
    protected int _power; // power which the plyer is hit by when in contact with a monster
    protected float _mx; // Player Position throu observer
    protected float _my; // Player Position throu observer
    protected Player _player;
    protected double _speed;

    private readonly Drop _dropStrategy; // strategy for dropping life or experience

    /**
     * Monster constructor.
     * 
     * @param x
     * @param y
     * @param h
     */
    protected Monster(float x, float y, Handler h) : base(x, y, ID.Monster)
    {
        //Monster.monstersCounter++;
        _handler = h;
        _player = h.GetPlayer();
        _player.AddObserver(this);
        _lastHitTime = 0;
        _dropStrategy = new Drop(this, _handler);
    }

    public int GetHealth() => _health;

    public int GetPower() => _power;

    public bool IsDead() => GetHealth() <= 0;
 
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

    /**
     * Entity bounce if hit by weapon.
     */
    public void Bounce()
    {
        // reverse the horizontal and vertical velocities to bounce the object off the
        // player
        _velX = -_velX * Bouncingspeedmultiplier;
        _velY = -_velY * Bouncingspeedmultiplier;
    }

   public void Die()
   {
        _handler.AddObject(_dropStrategy.DropGameObject());
        _handler.RemoveObject(this); // monster is removed from Monsters list
        //monstersCounter--;
        //monstersDeadCounter++;
    }

    /**
     * @return number of total monster.
     */
    //public static int getMonstersCounter() => monstersCounter;
    public void Update()
    {
        _mx = _player.GetX();
        _my = _player.GetY();
    }

    /**
     * Try to reach the target as defined by {@link IMonster}.
     * Subclasses extending reachtarget should override this method to provide
     * specific implementation details.
     */
    public void ReachTarget()
    {
        SetX(GetX() + _velX);
        SetY(GetY() + _velY);

        float angle = (float) Math.Atan2(_my - GetY() + 8, _mx - GetX() + 4);

        _velX = (float) ((_speed) * Math.Cos(angle));
        _velY = (float) ((_speed) * Math.Sin(angle));
    }

    public void SetIsBig(bool b)
    {
        throw new NotImplementedException();
    }

    public void SetStartingPosition(float minDistance, float maxDistance)
    {
        Pair<float, float> randomPosition = Func.RandomPoint(minDistance, maxDistance);
        Update(); // to get player position
        SetX(_mx + randomPosition.GetX());
        SetY(_my + randomPosition.GetY());
        // System.out.println("[" + mx + "," + my + "]");
    }

    /**
     * @return default experience a monster drop when dies.
     */
    public int GetDefaultExperience() => DefaultExperience;

    /**
     * @return number of dead monsters.
     */
    //public static int GetMonstersDeadCounter() => monstersDeadCounter;

    public override void Collide()
    {
    }
}
