using GeoSurv.Motta;
using GeoSurv.Dobrianskiy;
using GeoSurv.Testa;

using System.Collections.Generic;
using Geosurv.Testa;

namespace GeoSurv.Testa;

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
    private readonly PlayerMovement playerMovement;
    private readonly PlayerLevels playerLevels;
    private readonly List<IObserverEntity<GameObject>> observers;
    //private WeaponLevels weaponLevels;
    private readonly ICollisionBehavior collisionBehavior;
    private readonly Handler handler;
    
    public Player(float x, float y, Handler handler) : base(x, y, ID.Player) {
        life = MaxLife;
        lastHitTime = 0;
        observers = new List<IObserverEntity<GameObject>>();
        _height = PlayerHeight;
        _width = PlayerWidth;
        this.handler = handler;
        collisions = new Collisions(handler);
        playerMovement = new PlayerMovement(handler);
        // texture = Texture.PLAYER_DUCK; // alternative texture
        //Texture = Texture.PLAYER_MOUSE;
        playerLevels = new PlayerLevels(this);
        //collisionBehavior = new StopPlayerBehavior();

    }

    public override void Tick() {
        _x += _velX;
        _y += _velY;
        collisions.CheckPlayerCollisions();
        playerMovement.MovePlayer();
        NotifyObservers(); // notify player position
    }

    public int GetExperience()
    { 
        return playerLevels.GetCurrentExperience();
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

    public void SetExperience(int experience) {
        this.playerLevels.ExpUp(experience);
    }

    public int GetLife() {
        return this.life;
    }

    public int GetMaxLife() {
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

    public void Hit(int damage) {
        var currentTime = System.DateTimeOffset.Now.ToUnixTimeMilliseconds();
        if (currentTime - lastHitTime >= HitCooldown){
            SetLife(-damage);
            lastHitTime = currentTime;
        }
    }
    /*

    public void SetWeapons(List<Weapon> weapons) {
        // this.weapons = weapons;
        weaponLevels = new WeaponLevels(weapons);
    }

    public void LevelUpWeapon() {
        weaponLevels.LevelUpWeapon();
    }

    */

    public bool IsAlive() {
        return life > 0;
    }

    public override void Collide() {
        collisionBehavior.Collide(this, handler);
    }
}


