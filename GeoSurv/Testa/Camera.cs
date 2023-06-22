using GeoSurv.Motta;
using GeoSurv.Dobrianskiy;

namespace Geosurv.Testa;

public class Camera {
    private float x;
    private float y;
    private readonly Player tempPlayer;
    
    public Camera(float x, float y, Handler handler) {
        this.x = x;
        this.y = y;
        this.tempPlayer = handler.GetPlayer();
    }

    public void Tick() {
        x += ((tempPlayer.GetX() - x) - Game.WINDOW_WIDTH / 2) * 0.05f;
        y += ((tempPlayer.GetY() - y) - Game.WINDOW_HEIGHT / 2) * 0.05f;

        if (x <= 0) {
            x = 0;
        }

        if (x >= 1045) {
            x = 1045;
        }

        if (y <= 0) {
            y = 0;
        }

        if (y >= 1500) {
            y = 1500;
        }
    }
