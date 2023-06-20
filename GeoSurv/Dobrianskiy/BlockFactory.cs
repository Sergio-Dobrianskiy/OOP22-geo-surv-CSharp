namespace GeoSurv.Dobrianskiy;

public class BlockFactory : IBlockFactory
{
    public Block? CreateBlock(BlockType type, float x, float y)
    {
        if (type == BlockType.WALL)
        {
            return new Wall(x, y);
        }
        return null;
    }
}
    