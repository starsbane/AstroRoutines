namespace AstroRoutines;

public static partial class AR
{
    /// <summary>
    /// Earth rotation angle (IAU 2000 model).
    /// </summary>
    /// <param name="dj1">UT1 as a 2-part Julian Date</param>
    /// <param name="dj2">UT1 as a 2-part Julian Date</param>
    /// <returns>Earth rotation angle, radians</returns>
    public static double Era00(double dj1, double dj2)
    {
        double d1, d2, t, f, theta;

        /* Days since fundamental epoch. */
        if (dj1 < dj2)
        {
            d1 = dj1;
            d2 = dj2;
        }
        else
        {
            d1 = dj2;
            d2 = dj1;
        }
        t = d1 + (d2 - DJ00);

        /* Fractional part of T (days). */
        f = (d1 % 1.0) + (d2 % 1.0);

        /* Earth rotation angle at this UT1. */
        theta = Anp(D2PI * (f + 0.7790572732640 + 0.00273781191135448 * t));

        return theta;
    }
}
