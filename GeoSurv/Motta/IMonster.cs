namespace GeoSurv.Motta
{
   /// <summary>
   /// Interface to model Monsters.
   /// </summary>
   
    public interface IMonster
   {
       
       ///<returns>
       /// an integer showing how much health entity has left.
       /// </returns>
       
       int GetHealth();
       
       /// <returns>
       /// an integer showing how much power entity has hit the player.
       /// </returns> 
       
       int GetPower();
   
       /// <summary>
       /// Check if Entity is alive.
       /// </summary>
       /// <returns>
       /// boolean value
       /// </returns>
        
       bool IsDead();
       
       /// <summary>
       /// Entity's been hit by player weapon.
       /// </summary>
       /// <param name="weaponDamage">which hits the entity</param>>
       
       void Hit(int weaponDamage);
       
       /// <summary>
       /// Allow the monster to try to reach the player.
       /// </summary>
   
       void ReachTarget();
       
       /// <summary>
       /// Define if a monster is a big one.
       /// </summary>
       /// <param name="b">boolean value</param>>
        
       void SetIsBig(bool b);
       
       /// <summary>
       /// Set the starting position of a monster after it's born.
       /// Position is a random point between two circle (the first of radius
       /// minDistance and the second with a radius of maxDistance).
       /// </summary>
       ///<param name="minDistance">from player</param>
       ///<param name="maxDistance">from player</param>
        
       void SetStartingPosition(float minDistance, float maxDistance);
       
       /// <summary>
       /// Entity dies, drop experience or life and it is removed.
       /// </summary>
       
       void Die();
        
   }

}

