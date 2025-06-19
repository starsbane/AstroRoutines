namespace AstroRoutines;

public static partial class AR
{
    /// <summary>
    /// Fundamental argument, IERS Conventions (2003): mean elongation of the Moon from the Sun.
    /// </summary>
    /// <param name="t">TDB, Julian centuries since J2000.0</param>
    /// <returns>D, radians</returns>
    public static double Fad03(double t)
    {
        double a;

        /* Mean elongation of the Moon from the Sun (IERS Conventions 2003). */
        a = (1072260.703692 + t * (1602961601.2090 + t * (-6.3706 + t * (0.006593 + t * (-0.00003169))))) % TURNAS * DAS2R;

        return a;
    }
}
