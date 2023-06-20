using System.Drawing;
using GeoSurv.Dobrianskiy;

namespace GeoSurv.Motta
{
    /// import java.awt.Rectangle;
    /// import java.awt.geom.RectangularShape;
    /// import it.unibo.geosurv.control.ITickingObject;
    /// import it.unibo.geosurv.view.graphics.Texture;
    
    /// <summary>
    /// Abstract class for every game object in the game.
    /// </summary>

    public abstract class GameObject : ITickingObject, IGameObject
    {
        /// <summary>
        /// gameObject x coordinate.
        /// </summary>
        protected float _x;
        
        /// <summary>
        /// gameObject y coordinate.
        /// </summary>
        protected float _y;
    
        /// <summary>
        /// gameObject x velocity.
        /// </summary>
        protected float _velX;
        
        /// <summary>
        /// gameObject y velocity.
        /// </summary>
        protected float _velY;
        
        /// <summary>
        /// gameObject dimensions.
        /// </summary>
        protected int _height;
        protected int _width;
        
        /// <summary>
        /// gameObject texture.
        /// </summary>
        protected static Texture _texture = Texture.MissingTexture;
        
        /// <summary>
        /// gameObject id.
        /// </summary>
        protected ID _id;
    
        /**
         * Constructor for this class.
         *
         * @param x  GameObject coordinate
         * @param y  GameObject coordinate
         * @param id GameObject id
         */
        public GameObject(float x, float y, ID id) {
            _x = x;
            _y = y;
            _id = id;
            // this.collisionBehavior = new NoCollisionBehavior();
        }
    
        /// <returns>
        /// GameObjects' ID.
        /// </returns>
        public ID GetId() => _id;
        
        /// <summary>
        /// set object's id.
        /// </summary>
        public void SetId(ID id) => _id = id;
        
        /// <summary>
        /// this object's behavior.
        /// </summary>
        public abstract void Tick();
        
        /// <returns>
        /// object's x coordinate.
        /// </returns>
        public float GetX() => _x;
        
        /// <summary>
        /// set object's x coordinate.
        /// </summary>
        public void SetX(float x) => _x = x;
        
        /// <returns>
        /// object's y coordinate.
        /// </returns>
        public float GetY() => _y;
        
        /// <summary>
        /// object's y coordinate.
        /// </summary>>
        public void SetY(float y) => _y = y;
        
        /// <returns>
        /// object's velocity x vector
        /// </returns>
        public float GetVelX() => _velX;
        
        /// <summary>
        /// set object's velocity x vector.
        /// </summary>>
        public void SetVelX(float velX) => _velX = velX;
        
        /// <returns>
        /// object's velocity y vector
        /// </returns>
        public float GetVelY() => _velY;
        
        /// <summary>
        /// set object's velocity y vector.
        /// </summary>
        public void SetVelY(float velY) => _velY = velY;
        
        /// <returns>
        /// object's height
        /// </returns>
        public int GetHeight() => _height;
        
        /// <returns>
        /// object's width
        /// </returns>
        public int GetWidth() => _width;
        
        /// <summary>
        /// set object's height.
        /// </summary>
        public void SetHeight(int height) => _height = height;
        
        /// <summary>
        /// set object's width.
        /// </summary>
        public void SetWidth( int width) => _width = width;
        
        /// <returns>
        /// x coordinate for object's sprite.
        /// </returns>
        public int GetRenderX() => (int) _x - _width / 2;

        /// <returns>
        /// y coordinate for object's sprite.
        /// </returns>
        public int GetRenderY() => (int) _y - _height / 2;

        /// <returns>
        /// return object's texture.
        /// </returns>
        public Texture GetTexture() => _texture;

        /// <returns>
        /// Rectangle centered on the GameObject
        /// </returns>
        public Rectangle GetShape() =>  new Rectangle(GetRenderX(), GetRenderY(), _width, _height);
        
        /// <summary>
        /// handle collision with another object.
        /// </summary>
        public abstract void Collide();
    }
    
}

