namespace Dobrianskiy;

using Motta;
    
public class Handler
{
    private List<GameObject> _gameObjects = new List<GameObject>();
    private List<ITickingObject> _tickingObjects = new List<ITickingObject>();
    private Player _player;
    
    public void Tick()
    {
        foreach (GameObject gameObject in _gameObjects)
        {
            gameObject.Tick();
        }

        foreach (ITickingObject tickingObject in _tickingObjects)
        {
            tickingObject.Tick();
        }
    }
    public void AddObject(GameObject tempObject)
    {
        _gameObjects.Add(tempObject);
    }

    public void RemoveObject(GameObject tempObject)
    {
        _gameObjects.Remove(tempObject);
    }
    
    public void AddTickingObject(ITickingObject tempObject)
    {
        _tickingObjects.Add(tempObject);
    }

    public void RemoveTickingObject(ITickingObject tempObject)
    {
        _tickingObjects.Remove(tempObject);
    }

    public void AddPlayer(Player player)
    {
        this._player = player;
        _gameObjects.Add(player);
    }

    public Player GetPlayer()
    {
        return _player;
    }
    
    public int GetObjectsSize()
    {
        return _gameObjects.Count;
    }

    public List<GameObject> GetGameObjects()
    {
        return _gameObjects;
    }

    public List<ITickingObject> GetTickingObjects()
    {
        return _tickingObjects;
    }
    
    public void ClearHandler()
    {
        _gameObjects.Clear();
        _tickingObjects.Clear();
    }
}