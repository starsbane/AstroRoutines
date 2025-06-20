using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Greenwich mean sidereal time (consistent with IAU 2006 precession).
        /// </summary>
        /// <param name="uta">UT1 as a 2-part Julian Date</param>
        /// <param name="utb">UT1 as a 2-part Julian Date</param>
        /// <param name="tta">TT as a 2-part Julian Date</param>
        /// <param name="ttb">TT as a 2-part Julian Date</param>
        /// <returns>Greenwich mean sidereal time (radians)</returns>
        public static double Gmst06(double uta, double utb, double tta, double ttb)
        {
            double t, gmst;

            /* TT Julian centuries since J2000.0. */
            t = ((tta - DJ00) + ttb) / DJC;

            /* Greenwich mean sidereal time, IAU 2006. */
            gmst = Anp(Era00(uta, utb) +
                         (0.014506 +
                         (4612.156534 +
                         (1.3915817 +
                         (-0.00000044 +
                         (-0.000029956 +
                         (-0.0000000368)
                 * t) * t) * t) * t) * t) * DAS2R);

            return gmst;

            /* Finished. */
        }
    }
}
