namespace GeoSurv.Motta;

/// <summary>
/// Utility class to represent pairs of two instances of the same type.
/// </summary>
/// <param name="TX">the first type</param>
/// <param name="TY">the second type</param>
public class Pair<TX, TY> {

    private TX _x;
    private TY _y;

    /// <summary>
    /// Creates a new pair given X and Y values.
    /// </summary>
    /// <param name="x">the x value</param>
    /// <param name="y">the y value</param>
    public Pair( TX x, TY y) : base()
    {
        _x = x;
        _y = y;
    }

    /// <summary>
    /// Gets the X for this pair.
    /// </summary>
    /// <returns>x</returns>
    public TX GetX() => _x;

    /// <summary>
    /// Gets the Y for this pair.
    /// </summary>
    /// <returns>y</returns>
    public TY GetY() => _y;

    /// <summary>
    /// String representation of this Pair.
    /// </summary>
    /// <returns>the string</returns>
    public override string ToString() => "Pair un-implemented method";
}
