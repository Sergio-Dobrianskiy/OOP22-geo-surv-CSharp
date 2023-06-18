namespace Motta

{

    /// <summary>
    /// Interface for Observable.
    /// </summary>
    public interface IObservable
    {
        /// <summary>
        /// Adds an observer to the player.
        /// </summary>
        /// <param name="observer"></param>

        void AddObserver(IObserverEntity<GameObject> observer);

        /// <summary>
        /// Removes an observer from the player.
        /// </summary>
        /// <param name="observer"></param>

        void RemoveObserver(IObserverEntity<GameObject> observer);

        /// <summary>
        /// Notifies each observer.
        /// </summary>

        void NotifyObservers();
    }
}