namespace AstroRoutines;

public static partial class AR
{
    /// <summary>
    /// Fundamental argument, IERS Conventions (2003): general accumulated precession in longitude.
    /// </summary>
    /// <param name="t">TDB, Julian centuries since J2000.0</param>
    /// <returns>General precession in longitude, radians</returns>
    public static double Fapa03(double t)
    {
        double a;

        /* General accumulated precession in longitude. */
        a = (0.024381750 + 0.00000538691 * t) * t;

        return a;
    }
}
