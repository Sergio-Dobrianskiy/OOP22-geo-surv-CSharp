namespace Testa;

public interface IPlayer
{
    void Tick();

    int GetExperience();

    void SetExperience(int experience);

    void SetLife(int life);

    void Hit(int damage);

    bool IsAlive();

    int GetLevel();

    float GetExpPercentage();

    float GetLifePercentage();

    int GetLife();

    int GetMaxLife();

    void Collide();

}
