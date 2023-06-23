using GeoSurv.Motta;
using GeoSurv.Dobrianskiy;
using GeoSurv.Testa;

namespace GeoSurv.Testa;

public class Camera {

    /**
     * Larghezza della finestra del gioco.
     */
    public const int WINDOW_WIDTH = 1000;

    /**
     * Altezza della finestra del gioco.
     */
     
    public const int WINDOW_HEIGHT = 600;
    private float x;
    private float y;
    private readonly Player tempPlayer;
    
    public Camera(float x, float y, Handler handler) {
        this.x = x;
        this.y = y;
        this.tempPlayer = handler.GetPlayer();
    }

    public void Tick() {
        x += ((tempPlayer.GetX() - x) - WINDOW_WIDTH / 2) * 0.05f;
        y += ((tempPlayer.GetY() - y) - WINDOW_HEIGHT / 2) * 0.05f;

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

    public float GetX() {
        return x;
    }

    public void SetX(float xPos) {
        x = xPos;
    }

    public float GetY() {
        return y;
    }

    public void SetY(float yPos) {
        y = yPos;
    }
}
