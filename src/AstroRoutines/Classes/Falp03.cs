namespace AstroRoutines;

public static partial class AR
{
    /// <summary>
    /// Fundamental argument, IERS Conventions (2003): mean anomaly of the Sun.
    /// </summary>
    /// <param name="t">TDB, Julian centuries since J2000.0</param>
    /// <returns>Mean anomaly of the Sun, radians</returns>
    public static double Falp03(double t)
    {
        double a;

        /* Mean anomaly of the Sun (IERS Conventions 2003). */
        a = (1287104.793048 + t * (129596581.0481 + t * (-0.5532 + t * (0.000136 + t * (-0.00001149))))) % TURNAS * DAS2R;

        return a;
    }
}
