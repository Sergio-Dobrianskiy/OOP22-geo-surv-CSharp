using GeoSurv.Motta;
using GeoSurv.Dobrianskiy;
using GeoSurv.Testa;

namespace Geosurv.Testa
{
    /// <summary>
    /// Interface for player's movement.
    /// </summary>
    public interface IPlayerMovement
    {
        /// <summary>
        /// Moves the player.
        /// </summary>
        void MovePlayer();
    }
}