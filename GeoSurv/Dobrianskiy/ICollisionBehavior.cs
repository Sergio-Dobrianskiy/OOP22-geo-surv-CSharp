using GeoSurv.Motta;

namespace GeoSurv.Dobrianskiy;

public interface ICollisionBehavior
{
    void Collide(GameObject ths, Handler handler);
}