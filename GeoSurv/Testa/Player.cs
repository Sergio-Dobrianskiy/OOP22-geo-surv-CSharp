using GeoSurv.Testa;

namespace Geosurv.Testa;

public class Player : GameObject, IPlayer, IObservable {
    
    public const int PlayerHeight = 59;
    public const int PlayerWidth = 59;
    private const int PlayerSpeed = 5;
    private const int MaxLife = 100;
    private const int MaxHitsPerSecond = 2;
    private const long HitCooldown = 1000 / MaxHitsPerSecond;
        
    private long lastHitTime;
    private int life;
    private readonly Collisions collisions;
    private readonly IPlayerMovement playerMovement;
    private readonly PlayerLevels playerLevels;
    private readonly List<IObserverEntity<GameObject>> observers;
    private WeaponLevels weaponLevels;
    private readonly ICollisionBehavior collisionBehavior;
    private readonly Handler handler;
    
    public Player(float x, float y, Handler handler) : base(x, y, ID.Player) {
        life = MaxLife;
        lastHitTime = 0;
        observers = new List<IObserverEntity<GameObject>>();
        Height = PlayerHeight;
        Width = PlayerWidth;
        this.handler = handler;
        collisions = new Collisions(handler);
        playerMovement = new PlayerMovement(handler);
        // texture = Texture.PLAYER_DUCK; // alternative texture
        Texture = Texture.PLAYER_MOUSE;
        playerLevels = new PlayerLevels(this);
        collisionBehavior = new StopPlayerBehavior();

    }
