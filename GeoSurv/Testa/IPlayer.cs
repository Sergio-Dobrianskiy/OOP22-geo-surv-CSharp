namespace GeoSurv.Testa
{
    /// Interface Player

    public interface IPlayer
    {
        void Tick();

        ///
        /// <returns>return the experience of ther player.</returns>>
        ///
        int GetExperience();

        ///
        /// <param name="experience"> increases player experience</param>
        ///
        void SetExperience(int experience);

        ///
        /// <param name="life"> heals/damages the player</param>
        ///
        void SetLife(int life);

        ///
        /// <param name="damage"> Player life is diminished by damage</param>
        ///
        void Hit(int damage);

        ///
        /// <returns>return true if the player is alive.</returns>>
        ///
        bool IsAlive();

        ///
        /// <returns>return he level the player is in</returns>>
        ///
        int GetLevel();

        float GetExpPercentage();

        float GetLifePercentage();

        ///
        /// <returns>return how much health the Player has left</returns>>
        ///
        int GetLife();

        ///
        /// <returns>returns player maximum life</returns>>
        ///
        int GetMaxLife();
        
        ///
        /// manages players collisions
        ///
        void Collide();
    }
}
