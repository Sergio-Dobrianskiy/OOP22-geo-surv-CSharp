namespace GeoSurv.Motta;

/**
 * Utility class to represent pairs of two instances of the same type.
 *
 * @param <X> the first type
 * @param <Y> the second type
 */
public class Pair<X, Y> {

    private X _x;
    private Y _y;

    /**
     * Creates a new pair given X and Y values.
     *
     * @param x the x value
     * @param y the y value
     */
    public Pair( X x, Y y) : base()
    {
        _x = x;
        _y = y;
    }

    /**
     * Gets the X for this pair.
     *
     * @return the X
     */
    public X GetX() => _x;

    /**
     * Gets the Y for this pair.
     *
     * @return the Y
     */
    public Y GetY() => _y;

    /**
     * Generate a hash code for this Pair.
     *
     * @return the hash code
     */
    public int HashCode() {
        //not implemented
        return 1;
    }

    /**
     * Test this Pair for equality with another Object.
     *
     * @param obj the other object
     * @return true if equals, false otherwise
     */
    public override bool Equals(Object obj)
    {
        // not implemented
        return false;
    }

    /**
     * String representation of this Pair.
     *
     * @return the string
     */
    public override string ToString() => "Pair un-implemented method";
}
