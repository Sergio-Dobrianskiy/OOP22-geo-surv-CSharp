using GeoSurv.Dobrianskiy;

namespace GeoSurv.Motta;

/// <summary>
/// contains utility functions.
/// </summary>
public class Func
{
    
    private static Random _random;

    /// <summary>
    /// To prevent creation of instances.
    /// </summary>
    private Func()
    {
    }
    
    /// <summary>
    /// Return random point on a circumference or ring.
    /// </summary>
    /// <param name="min">min radius</param>
    /// <param name="max">max radius</param>
    /// <returns>random point on a circumference or ring</returns>
    public static Pair<float, float> RandomPoint(float min, float max) {
        if (min < 0) {
            min = 0.0f;
            Console.WriteLine("You can't use negative min values");
        }

        if (max < 0) {
            max = 500.0f;
            Console.WriteLine("You can't use negative max values");
        }
 
        if (min > max)
        {
            (max, min) = (min, max);
            Console.WriteLine("Check the order of min and max values");
        }
        
        _random = new Random();
        //double angle = 2 * Math.PI * Math.random();
        double angle = 2 * Math.PI * _random.NextDouble();
        double minRandom = min / max; // proportion: max / 1 = min / x
        //double radius = Math.sqrt(_random.NextDouble(minRandom, 1));
        double radius = Math.Sqrt(_random.NextDouble() * (1 - minRandom) + minRandom);
        float x = (float) (radius * Math.Cos(angle));
        float y = (float) (radius * Math.Sin(angle));

        return new Pair<float,float>(x * max, y * max);
    }

    /// <summary>
    /// Return closest enemy to the player.
    /// </summary>
    /// <param name="handler"></param>
    public static void FindClosestEnemy(Handler handler)
    {
        // below original function
        // GameObject return: removed for semplicity
    }
    //public static GameObject FindClosestEnemy(Handler handler)
    //{
    //    List<GameObject> tmpObjects = handler.GetGameObjects();
    //    GameObject player = handler.GetPlayer();
    //    GameObject closestEnemy = null;
    //    float closestDistance = float.MaxValue;
    //    float distance;
    //    float px;
    //    float py;
    //    px = player.GetX();
    //    py = player.GetY();
    //
    //    for (GameObject tmpObject : tmpObjects) {
    //        if (tmpObject.getId() == ID.Monster) {
    //            float ex;
    //            float ey;
    //
    //            ex = tmpObject.getX();
    //            ey = tmpObject.getY();
    //
    //            distance = (float) Point2D.distance(px, py, ex, ey);
    //            if (distance < closestDistance) {
    //                closestDistance = distance;
    //                closestEnemy = tmpObject;
    //            }
    //        }
    //    }
    //    return closestEnemy;
    //}
    
    /// <summary>
    /// Return angle of from point A to B.
    /// </summary>
    /// <param name="a">obj a</param>
    /// <param name="b">obj b</param>
    /// <returns></returns>
    public static Pair<float, float> FindAngle2(GameObject a, GameObject b)
    {
        float ax = a.GetX();
        float ay = a.GetY();
        float bx = b.GetX();
        float by = b.GetY();
        float angle =(float) Math.Atan2(by - ay, bx - ax);
        return new Pair<float, float>((float) Math.Cos(angle), (float) Math.Sin(angle));
    }
}
