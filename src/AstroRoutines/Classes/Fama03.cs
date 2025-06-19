namespace AstroRoutines;

public static partial class AR
{
    /// <summary>
    /// Fundamental argument, IERS Conventions (2003): mean longitude of Mars.
    /// </summary>
    /// <param name="t">TDB, Julian centuries since J2000.0</param>
    /// <returns>Mean longitude of Mars, radians</returns>
    public static double Fama03(double t)
    {
        double a;

        /* Mean longitude of Mars (IERS Conventions 2003). */
        a = (6.203480913 + 334.0612426700 * t) % D2PI;

        return a;
    }
}
