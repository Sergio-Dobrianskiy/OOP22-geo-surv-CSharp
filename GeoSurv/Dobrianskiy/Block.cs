﻿using GeoSurv.Motta;

namespace GeoSurv.Dobrianskiy;

public abstract class Block : GameObject
{
    public Block(float x, float y) : base(x, y, ID.Block)
    {
    }
}