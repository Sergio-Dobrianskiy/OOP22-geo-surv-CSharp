namespace GeoSurv.Dobrianskiy;
public class Wall : Block
{
    private static readonly int BlockHeight = 32;
    private static readonly int BlockWidth = 32;

    public Wall(float x, float y) : base(x, y)
    {
        //this.height = BlockHeight;
        //this.width = BlockWidth;
        // this.texture = Texture.BLOCK;
    }

    public override void Tick()
    {
    }

    public override void Collide()
    {
    }
}