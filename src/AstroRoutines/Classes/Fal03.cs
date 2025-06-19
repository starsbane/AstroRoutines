namespace AstroRoutines;

public static partial class AR
{
    /// <summary>
    /// Fundamental argument, IERS Conventions (2003): mean anomaly of the Moon.
    /// </summary>
    /// <param name="t">TDB, Julian centuries since J2000.0</param>
    /// <returns>l, radians</returns>
    public static double Fal03(double t)
    {
        double a;

        /* Mean anomaly of the Moon (IERS Conventions 2003). */
        a = (485868.249036 + t * (1717915923.2178 + t * (31.8792 + t * (0.051635 + t * (-0.00024470))))) % TURNAS * DAS2R;

        return a;
    }
}
