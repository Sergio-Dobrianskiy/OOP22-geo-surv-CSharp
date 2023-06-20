using GeoSurv.Dobrianskiy;

namespace GeoSurv.Motta;

//import java.awt.geom.Point2D;
//import java.util.List;
//import java.util.Random;
//
//import it.unibo.geosurv.model.GameObject;
//import it.unibo.geosurv.model.Handler;
//import it.unibo.geosurv.model.ID;

/**
 * contains utility functions.
 */
public class Func {

    private static Random _random;
    /**
     * To prevent creation of instances.
     */
    private Func() {
    }

    /**
     * Return random point on a circumference or ring.
     *
     * @param min minimal radius
     * @param max maxi mum radius
     *            NOTE: min must be < than max
     * @return Pair coordinates x, y
     */
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

    /**
     * Return closest enemy to the player.
     *
     * @param handler game handler
     * 
     * @return GameObject player
     */

    public static void FindClosestEnemy(Handler handler)
    {
        // below original function
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

    /**
     * Return angle of from point A to B.
     *
     * @param flaot A's x coordinate
     * @param flaot A'y x coordinate
     * @param flaot B's x coordinate
     * @param flaot B'y x coordinate
     * @return Pair angle
     */
    // public static Pair<Float, Float> findAngle(final float ax, final float ay,
    // final float bx, final float by) {
    // float angle = (float) Math.atan2(by - ay, bx - ax);
    // return new Pair<Float, Float>((float) Math.cos(angle), (float)
    // Math.sin(angle));
    // }

    /**
     * Return angle of from point A to B.
     *
     * @param a GameObject origin
     * @param b GameObject aimed
     * @return Pair angle
     */
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
