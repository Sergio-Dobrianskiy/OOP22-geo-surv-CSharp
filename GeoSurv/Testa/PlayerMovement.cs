using GeoSurv.Motta;
using GeoSurv.Dobrianskiy;
using GeoSurv.Testa;

namespace Geosurv.Testa
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
            this.handler = handler;
            this.player = handler.GetPlayer();
        }

        /// <summary>
        /// Manages player movement.
        /// </summary>
        public void MovePlayer()
        {
            if (player == null)
            {
                player = handler.GetPlayer();
                return;
            }

            if (handler.IsUp())
            {
                player.SetVelY(-player.GetSpeed());
            }
            else if (!handler.IsDown())
            {
                player.SetVelY(0);
            }

            if (handler.IsDown())
            {
                player.SetVelY(player.GetSpeed());
            }
            else if (!handler.IsUp())
            {
                player.SetVelY(0);
            }

            if (handler.IsRight())
            {
                player.SetVelX(player.GetSpeed());
            }
            else if (!handler.IsLeft())
            {
                player.SetVelX(0);
            }

            if (handler.IsLeft())
            {
                player.SetVelX(-player.GetSpeed());
            }
            else if (!handler.IsRight())
            {
                player.SetVelX(0);
            }
        }
    }
}
