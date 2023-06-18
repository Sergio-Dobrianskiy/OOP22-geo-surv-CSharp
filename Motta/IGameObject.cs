namespace Motta
{
    import java.awt.geom.RectangularShape;
    import it.unibo.geosurv.view.graphics.Texture;

    /// <summary>
    /// Interface for GameObjects.
    /// </summary>
    public interface IGameObject
    {
        /// <returns>
        /// returns GameObjects' ID.
        /// </returns>
        ID GetId();
    
        /// <summary>
        /// set object's id.
        /// </summary>
        ///
        /// <param name="id"> object's id</param>
        ///
        void SetId(ID id);
    
        /// <summary>
        /// get object's x coordinate.
        /// </summary>
        ///
        /// <returns>object's x coordinate</returns>
        ///
        float GetX();
    
        /// <summary>
        /// set object's x coordinate.
        /// </summary>
        ///
        /// <param name="x"> object's x coordinate</param>
        ///
        void SetX(float x);
        
        /// <summary>
        /// get object's y coordinate.
        /// </summary>
        ///
        /// <returns>object's y coordinate</returns>>
        ///
        float GetY();
        
        /// <summary>
        /// set object's y coordinate.
        /// </summary>
        ///
        /// <param name="y"> object's y coordinate</param>
        ///
        void SetY(float y);
        
        /// <summary>
        /// get object's velocity x vector.
        /// </summary>
        ///
        /// <returns>object's velocity x vector</returns>>
        ///
        float GetVelX();
        
        /// <summary>
        /// set object's velocity x vector.
        /// </summary>
        ///
        /// <param name="velX"> object's velocity x vector</param>
        ///
        void SetVelX(float velX);
        
        /// <summary>
        /// get object's velocity y vector.
        /// </summary>
        ///
        /// <returns>object's velocity y vector</returns>>
        ///
        float GetVelY();
        
        /// <summary>
        /// set object's velocity y vector.
        /// </summary>
        ///
        /// <param name="velY"> object's velocity y vector</param>
        ///
        void SetVelY(float velY);
        //TODO: fin qui
        /// <summary>
        /// set object's id.
        /// </summary>
        ///
        /// <param name="id"> object's id</param>
        ///
        /**
        * get object's height.
        * @return object's width
        */
        int GetHeight();
         
        /// <summary>
        /// set object's id.
        /// </summary>
        ///
        /// <param name="id"> object's id</param>
        ///
        /**
        * get object's width.
        * @return object's width
        */
        int GetWidth();
        
        /// <summary>
        /// set object's id.
        /// </summary>
        ///
        /// <param name="id"> object's id</param>
        ///
        /**
        * set object's height.
        * @param height object's width
        */
        void SetHeight(int height);
        
        /// <summary>
        /// set object's id.
        /// </summary>
        ///
        /// <param name="id"> object's id</param>
        /**
         * set object's width.
         * @param width object's width
         */
        void SetWidth(int width);
    
        /**
         * return x coordinate for object's sprite.
         * @return object sprite y coordinate
         */
        int GetRenderX();
    
        /**
         * return y coordinate for object's sprite.
         * @return object sprite y coordinate
         */
        int GetRenderY();
    
        /**
         * return GameObject's hitbox (that is a Rectangle by default).
         * 
         * @return RectangularShape centered on the GameObject
         */
        RectangularShape GetShape();
    
        /**
         * return object's texture.
         * @return object's texture
         */
        Texture GetTexture();
    }

    
}

