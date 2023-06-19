using System.Drawing;

namespace GeoSurv
{
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
       
        /// <summary>
        /// get object's height.
        /// </summary>
        ///
        /// <returns>object's height</returns>>
        ///
        int GetHeight();
        
        /// <summary>
        /// get object's width.
        /// </summary>
        ///
        /// <returns>object's width</returns>>
        ///
        int GetWidth();
        
        /// <summary>
        /// set object's height.
        /// </summary>
        ///
        /// <param name="height"> object's height</param>
        ///
        void SetHeight(int height);
        
        /// <summary>
        /// set object's width.
        /// </summary>
        ///
        /// <param name="width"> object's width</param>
        void SetWidth(int width);
        
        ///
        /// <returns>return x coordinate for object's sprite.</returns>>
        ///
        int GetRenderX();

        ///
        /// <returns>return y coordinate for object's sprite.</returns>>
        ///
        int GetRenderY();
        
        ///
        /// <returns>GameObject's hitbox (that is a Rectangle by default).</returns>>
        ///
        Rectangle GetShape();
        
        ///
        /// <returns>object's texture.</returns>>
        ///
        Texture GetTexture();
    }

}

