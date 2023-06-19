using GeoSurv.Dobrianskiy;

namespace GeoSurv.Motta;


//import it.unibo.geosurv.model.GameObject;
//import it.unibo.geosurv.model.Handler;
//import it.unibo.geosurv.model.ID;
//import it.unibo.geosurv.model.collisions.ICollisionBehavior;
//import it.unibo.geosurv.model.collisions.RemoveOnCollisionBehavior;
//import it.unibo.geosurv.view.graphics.Texture;
//
/**
 * Life pills are created randomly (more or less 1/50 a time) when a monster
 * dies. No experience is created if life pill is created.
 */
public class Life : GameObject
{
    private static readonly int DefaultLife = 10;
    private static readonly int DefaultLifeHeight = 25;
    private static readonly int DefaultLifeWidth = 20;
    private readonly Handler _handler;
    private readonly ICollisionBehavior _collisionBehavior;

    /**
     * Life pill constructor.
     * 
     * @param x position
     * @param y position
     * @param h handler for collision
     * 
     */

    public Life(float x, float y, Handler h) : base(x,y,ID.Life)
    {
        _height = DefaultLifeHeight;
        _width = DefaultLifeWidth;
        _texture = Texture.Life;
        this._handler = h;
        this._collisionBehavior = new RemoveOnCollisionBehavior();
    }

   public override void Tick()
   {
        /// Life pills do not tick()
   }

   /**
    * @return int amount of experience in the pill
    */
   public int GetDefaultLife() => DefaultLife;
   
   /**
    * starts collision behavior, no behavior by default.
    */
   public override void Collide()
   {
       _collisionBehavior.Collide(this, _handler);
   }

}
