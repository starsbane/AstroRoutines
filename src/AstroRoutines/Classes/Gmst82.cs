using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Universal Time to Greenwich mean sidereal time (IAU 1982 model).
        /// </summary>
        /// <param name="dj1">UT1 Julian Date</param>
        /// <param name="dj2">UT1 Julian Date</param>
        /// <returns>Greenwich mean sidereal time (radians)</returns>
        public static double Gmst82(double dj1, double dj2)
        {
            /* Coefficients of IAU 1982 GMST-UT1 model */
            var A = 24110.54841 - DAYSEC / 2.0;
            var B = 8640184.812866;
            var C = 0.093104;
            var D = -6.2e-6;

            /* The first constant, A, has to be adjusted by 12 hours because the */
            /* UT1 is supplied as a Julian date, which begins at noon.           */

            double d1, d2, t, f, gmst;

            /* Julian centuries since fundamental epoch. */
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
            t = (d1 + (d2 - DJ00)) / DJC;

            /* Fractional part of JD(UT1), in seconds. */
            f = DAYSEC * (d1 % 1.0 + d2 % 1.0);

            /* GMST at this UT1. */
            gmst = Anp(DS2R * ((A + (B + (C + D * t) * t) * t) + f));

            return gmst;

            /* Finished. */
        }
    }
}
