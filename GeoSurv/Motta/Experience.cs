using GeoSurv.Dobrianskiy;

namespace GeoSurv.Motta;

//import it.unibo.geosurv.model.GameObject;
//import it.unibo.geosurv.model.Handler;
//import it.unibo.geosurv.model.ID;
//import it.unibo.geosurv.model.IObserverEntity;
//import it.unibo.geosurv.model.collisions.ICollisionBehavior;
//import it.unibo.geosurv.model.collisions.RemoveOnCollisionBehavior;
//import it.unibo.geosurv.model.player.Player;
//import it.unibo.geosurv.view.graphics.Texture;

/**
 * Class for experience pills, created at monsters death.
 * More experience make player go to new levels.
 */
public class Experience : GameObject, IObserverEntity<Player> {

    private static readonly int ExperienceHeight = 25;
    private static readonly int ExperienceWidth = 20;
    private static readonly float PickUpSpeed = 10;
    private static int _experienceCounter;
    private readonly Player _player;
    private readonly Handler _handler;
    private readonly int _exp;
    private readonly ICollisionBehavior _collisionBehavior;
    private float _mx; // Player Position throu observer
    private float _my; // Player Position throu observer

    /**
     * The experience pill is created at monster's death, at the posistion where
     * moster dies.
     * 
     * @param x   position
     * @param y   position
     * @param exp experience quantity
     * @param h   handler
     */
    public Experience(float x, float y, int exp, Handler h) : base(x, y, ID.Experience)
    {
        _exp = exp;
        //Experience._experienceCounter++;
        _height = ExperienceHeight;
        _width = ExperienceWidth;
        _texture = Texture.Experience;
        _handler = h;
        _player = _handler.GetPlayer();
        _player.AddObserver(this);
        _collisionBehavior = new RemoveOnCollisionBehavior();
    }

    public override void Tick()
    {
        if (_player.GetLevel() > 1) {
            ReachTarget();
        }
    }

    /**
     * Pill experience.
     * 
     * @return int amount of experience in the pill
     */
    public int GetExp() => _exp;

    /**
     * @return how many pills have been created.
     */
    public static int GetExperienceCounter() => _experienceCounter;

    public void Update()
    {
        _mx = _player.GetX();
        _my = _player.GetY();
    }

    /**
     * If player is near and has gained some experience(levelsup) pills are
     * attracted.
     */
    public void ReachTarget()
    {
        // distance from the player and experience pill
        float _distance = CalculateDistance(_player.GetX(), _player.GetY(), GetX(), GetY());
        // maxDistance: to determine the max distance a pill can reach the player and
        // increment +10% distance each level
        float _maxDistance = 80 + (10 * _player.GetLevel());

        if (_distance <= _maxDistance) {
            SetX(GetX() + _velX);
            SetY(GetY() + _velY);

            float angle = (float) Math.Atan2(_my - GetY() + 8, _mx - GetX() + 4);

            _velX = (float) ((PickUpSpeed) * Math.Cos(angle));
            _velY = (float) ((PickUpSpeed) * Math.Sin(angle));
        }
    }

    /**
     * calculate distance beetwen two point (x1,y1) and (x2,y2) in a 2d space.
     * 
     * @param x1 first point x
     * @param y1 first point y
     * @param x2 second point x
     * @param y2 second point y
     * 
     * @return float distance
     */
    private float CalculateDistance(float x1, float y1, float x2, float y2)
    {
        float dx = x2 - x1;
        float dy = y2 - y1;
        return (float) Math.Sqrt(dx * dx + dy * dy);
    }

    /**
     * starts collision behavior, no behavior by default.
     */
    public override void Collide()
    {
        _collisionBehavior.Collide(this, _handler);
    }

}
