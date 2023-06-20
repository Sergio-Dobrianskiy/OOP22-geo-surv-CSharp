using GeoSurv.Motta;

namespace GeoSurv.Dobrianskiy;

public interface IBlockFactory
{
    Block? CreateBlock(BlockType type, float x, float y);
}