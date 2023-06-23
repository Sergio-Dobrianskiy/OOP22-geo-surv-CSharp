using GeoSurv.Motta;
using GeoSurv.Dobrianskiy;
using GeoSurv.Testa;

using System.Collections.Generic;

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

    public override void Tick() {
        X += VelX;
        Y += VelY;
        collisions.CheckPlayerCollisions();
        playerMovement.MovePlayer();
        NotifyObservers(); // notify player position
    }

    public int GetExperience() {
        return playerLevels.CurrentExperience();
    }
    
    public int GetMaxExperience() {
        return playerLevels.GetExpToLevelUp();
    }
    
    public int GetLevel() {
        return playerLevels.GetCurrentLevel();
    }

    public float GetExpPercentage() {
        if (GetExperience() == 0) {
            return 0;
        }
        return (float)GetExperience() / GetMaxExperience();
    }

    public float GetLifePercentage() {
        if (GetLife() == 0) {
            return 0;
        }
        return (float)GetLife() / GetMaxLife();
    }

    public void setExperience(int experience) {
        this.playerLevels.expUp(experience);
    }

    public int getLife() {
        return this.life;
    }

    public int getMaxLife() {
        return MaxLife;
    }
    
    public int GetSpeed() {
        return PlayerSpeed;
    }

    public void SetLife(int plusLife) {
        life = life + plusLife > GetMaxLife() ? GetMaxLife() : life + plusLife;
    }

    public void AddObserver(IObserverEntity<GameObject> observer) {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserverEntity<GameObject> observer) {
        observers.Remove(observer);
    }

    public void NotifyObservers() {
        foreach (var observer in observers) {
            observer.Update();
        }
    }
}


