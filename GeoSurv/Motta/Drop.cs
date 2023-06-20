using GeoSurv.Dobrianskiy;
namespace GeoSurv.Motta;

//import it.unibo.geosurv.model.GameObject;
//import it.unibo.geosurv.model.Handler;
//import it.unibo.geosurv.model.monsters.Monster;
//import it.unibo.geosurv.model.monsters.types.Ball;

/**
 * Class which manages the logics of dropping objects (life and experience).
 * 
 */
public class Drop //: IDrop<GameObject>
{

    private static readonly int LifePillsProb = 50; // probability to get a life pill: 1/50 at monster death
    private static readonly int NewMonsterProb = 10; // probability to get a new monster: 1/10 at monster death
    private readonly Monster _m;
    private readonly Handler _h;

    /**
     * Droppable object constructor.
     * 
     * @param m monster.
     * @param h handler.
     */
    public Drop(Monster m, Handler h)
    {
        _m = m;
        _h = h;
    }

    /**
     * drop implementation, which could allow for life, a new monster or experience.
     */
  
    public GameObject DropGameObject()
    {
        if (ShouldDropLife()) {
            return DropLife();
        } else if (ShouldDropMonsterBall()) {
            return DropBall();
        } else {
            return DropExperience();
        }

    }

    /**
     * Evaluates if a life should be dropped (probability 1/50).
     * 
     * @return true if life should be dropped.
     */
    public bool ShouldDropLife()
    {
        // Generate a random number between 0 and 49
        double _num = new Random().NextDouble();
        int _randomNumber = (int) (_num * LifePillsProb);
        // Return true if the random number is 0 (probability of 1/50)
        return _randomNumber == 0;
    }

    /**
     * @return life object.
     */
    public Life DropLife() => new Life(_m.GetX(),_m.GetY(),_h);

    /**
     * @return experience object.
     */
    public Experience DropExperience() => new Experience(_m.GetX(), _m.GetY(), _m.GetDefaultExperience(), _h);

    /**
     * Evaluates if a new monster should be dropped (probability 1/50).
     * 
     * @return true if life should be dropped.
     */
    public bool ShouldDropMonsterBall()
    {
        // Generate a random number between 0 and 10
        double _num = new Random().NextDouble();
        int _randomNumber = (int) (_num * NewMonsterProb);
        // Return true if the random number is 0 (probability of 1/10)
        return _randomNumber == 0;
    }

    /**
     * @return a new Ball monster.
     */
    public Ball DropBall()
    {
        Ball b = new Ball(_h);
        b.SetX(_m.GetX());
        b.SetY(_m.GetY());
        return b;
    }

}
