using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Greenwich mean sidereal time (model consistent with IAU 2000
        /// resolutions).
        /// </summary>
        /// <param name="uta">UT1 as a 2-part Julian Date</param>
        /// <param name="utb">UT1 as a 2-part Julian Date</param>
        /// <param name="tta">TT as a 2-part Julian Date</param>
        /// <param name="ttb">TT as a 2-part Julian Date</param>
        /// <returns>Greenwich mean sidereal time (radians)</returns>
        public static double Gmst00(double uta, double utb, double tta, double ttb)
        {
            double t, gmst;

            /* TT Julian centuries since J2000.0. */
            t = ((tta - DJ00) + ttb) / DJC;

            /* Greenwich Mean Sidereal Time, IAU 2000. */
            gmst = Anp(Era00(uta, utb) +
                          (0.014506 +
                          (4612.15739966 +
                          (1.39667721 +
                          (-0.00009344 +
                          (0.00001882)
                 * t) * t) * t) * t) * DAS2R);

            return gmst;

            /* Finished. */
        }
    }
}
