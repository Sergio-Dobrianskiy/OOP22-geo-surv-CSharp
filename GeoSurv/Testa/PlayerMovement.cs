using GeoSurv.Motta;
using GeoSurv.Dobrianskiy;
using Geosurv.Testa;
using GeoSurv.Testa;

namespace GeoSurv.Testa
{
    /// <summary>
    /// Manages player movement.
    /// </summary>
    public class PlayerMovement : IPlayerMovement
    {
        private readonly Handler handler;
        private Player player;

        /// <summary>
        /// Constructor for this class.
        /// </summary>
        /// <param name="handler">The game's Handler.</param>
        public PlayerMovement(Handler handler)
        {
        }

        /// <summary>
        /// Manages player movement.
        /// </summary>
        public void MovePlayer()
        {
        }
    }
}
