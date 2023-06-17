namespace Dobrianskiy;

public class Handler
{
    private List<GameObject> _gameObjects = new List<GameObject>();
    
    public void RemoveObject(GameObject tempObject)
    {
        _gameObjects.Remove(tempObject);
    }
}