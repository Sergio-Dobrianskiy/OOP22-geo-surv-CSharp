using GeoSurv.Motta;
using GeoSurv.Dobrianskiy;
using GeoSurv.Testa;

namespace Geosurv.Testa
{
    /// <summary>
    /// Manages player levels.
    /// </summary>
    public class PlayerLevels
    {
        private const int STARTING_LEVEL = 1;
        private const int MAX_LEVEL = 12;  // Currently: 4 weapons * 3 levels each
        private const int BASE_EXP = 4;
        private const float LEVEL_MULTIPLIER = 1.3f;

        private int currentLevel;
        private int currentExperience;
        private int expToLevelUp;
        private readonly Player player;

        /// <summary>
        /// Constructor for this class.
        /// </summary>
        /// <param name="player">The game's player.</param>
        public PlayerLevels(Player player)
        {
            this.currentLevel = STARTING_LEVEL;
            this.currentExperience = 0;
            this.expToLevelUp = BASE_EXP;
            this.player = player;
        }

        /// <summary>
        /// Increases the player's experience.
        /// </summary>
        /// <param name="exp">The experience gained.</param>
        public void ExpUp(int exp)
        {
            this.currentExperience += exp;
            if (this.currentExperience > this.expToLevelUp && this.currentLevel < MAX_LEVEL)
            {
                this.LevelUp();
            }
        }

        /// <summary>
        /// Levels up the player.
        /// </summary>
        public void LevelUp()
        {
            if (this.currentLevel < MAX_LEVEL)
            {
                this.currentLevel += 1;
                this.currentExperience = 0;
                this.expToLevelUp = (int)(this.expToLevelUp * LEVEL_MULTIPLIER);
                this.player.LevelUpWeapon();
            }
        }

        /// <summary>
        /// Returns the player's current level.
        /// </summary>
        /// <returns>The player's current level.</returns>
        public int GetCurrentLevel()
        {
            return this.currentLevel;
        }

        /// <summary>
        /// Returns the player's current experience.
        /// </summary>
        /// <returns>The player's current experience.</returns>
        public int GetCurrentExperience()
        {
            return this.currentExperience;
        }

        /// <summary>
        /// Returns the total experience needed to reach the next level.
        /// </summary>
        /// <returns>The experience needed to reach the next level.</returns>
        public int GetExpToLevelUp()
        {
            return this.expToLevelUp;
        }
    }
}
