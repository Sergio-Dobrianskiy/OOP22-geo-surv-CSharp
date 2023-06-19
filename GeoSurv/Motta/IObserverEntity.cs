namespace GeoSurv.Motta
{
    /// <summary>
    /// Interface for observers.
    /// </summary>
    /// <param name="T">specific type for the observer.</param>
    public interface IObserverEntity<T>
    {
       /// <summary>
       /// Allow to update observers/monsters to follow the player.
       /// </summary>
        void Update();
    }
}