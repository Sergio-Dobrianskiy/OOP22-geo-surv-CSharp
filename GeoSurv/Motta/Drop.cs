using GeoSurv.Dobrianskiy;
namespace GeoSurv.Motta;

/// <summary>
/// Class which manages the logics of dropping objects (life and experience).
/// </summary>
public class Drop
{
    private static readonly int LifePillsProb = 50; // probability to get a life pill: 1/50 at monster death
    private static readonly int NewMonsterProb = 10; // probability to get a new monster: 1/10 at monster death
    private readonly Monster _m;
    private readonly Handler _h;
    
    /// <summary>
    /// Droppable object constructor.
    /// </summary>
    /// <param name="m">monster</param>
    /// <param name="h">handler</param>
    public Drop(Monster m, Handler h)
    {
        _m = m;
        _h = h;
    }
    
    /// <summary>
    /// drop implementation, which could allow for life, a new monster or experience.
    /// </summary>
    /// <returns>GameObject (experience pill, monster or life pill)</returns>
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
    
    /// <summary>
    /// Evaluates if a life should be dropped (probability 1/50).
    /// </summary>
    /// <returns>if Life should be dropped</returns>
    public bool ShouldDropLife()
    {
        // Generate a random number between 0 and 49
        double _num = new Random().NextDouble();
        int _randomNumber = (int) (_num * LifePillsProb);
        // Return true if the random number is 0 (probability of 1/50)
        return _randomNumber == 0;
    }

    /// <returns>life object</returns>
    public Life DropLife() => new Life(_m.GetX(),_m.GetY(),_h);
    
    /// <returns>experience object</returns>
    public Experience DropExperience() => new Experience(_m.GetX(), _m.GetY(), _m.GetDefaultExperience(), _h);
    
    /// <summary>
    /// Evaluates if a new monster should be dropped (probability 1/50).
    /// </summary>
    /// <returns>if a new monster should be dropped</returns>
    public bool ShouldDropMonsterBall()
    {
        // Generate a random number between 0 and 10
        double _num = new Random().NextDouble();
        int _randomNumber = (int) (_num * NewMonsterProb);
        // Return true if the random number is 0 (probability of 1/10)
        return _randomNumber == 0;
    }
    
    /// <returns>a new Ball monster.</returns>
    public Ball DropBall()
    {
        Ball b = new Ball(_h);
        b.SetX(_m.GetX());
        b.SetY(_m.GetY());
        return b;
    }

}
