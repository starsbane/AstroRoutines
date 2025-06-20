using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Frame bias components of IAU 2000 precession-nutation models.
        /// </summary>
        /// <param name="dpsibi">longitude correction (radians)</param>
        /// <param name="depsbi">obliquity correction (radians)</param>
        /// <param name="dra">the ICRS RA of the J2000.0 mean equinox (radians)</param>
        public static void Bi00(out double dpsibi, out double depsbi, out double dra)
        {
            /* The frame bias corrections in longitude and obliquity (radians) */
            const double DPBIAS = -0.041775 * DAS2R;
            const double DEBIAS = -0.0068192 * DAS2R;

            /* The ICRS RA of the J2000.0 equinox (Chapront et al., 2002) */
            const double DRA0 = -0.0146 * DAS2R;

            /* Return the results (which are fixed). */
            dpsibi = DPBIAS;
            depsbi = DEBIAS;
            dra = DRA0;
        }
    }
}
