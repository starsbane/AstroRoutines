using static System.Math;
using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Star proper motion: update star catalog data for space motion.
        /// </summary>
        /// <param name="ra1">right ascension (radians), before</param>
        /// <param name="dec1">declination (radians), before</param>
        /// <param name="pmr1">RA proper motion (radians/year), before</param>
        /// <param name="pmd1">Dec proper motion (radians/year), before</param>
        /// <param name="px1">parallax (arcseconds), before</param>
        /// <param name="rv1">radial velocity (km/s, +ve = receding), before</param>
        /// <param name="ep1a">"before" epoch, part A</param>
        /// <param name="ep1b">"before" epoch, part B</param>
        /// <param name="ep2a">"after" epoch, part A</param>
        /// <param name="ep2b">"after" epoch, part B</param>
        /// <param name="ra2">right ascension (radians), after</param>
        /// <param name="dec2">declination (radians), after</param>
        /// <param name="pmr2">RA proper motion (radians/year), after</param>
        /// <param name="pmd2">Dec proper motion (radians/year), after</param>
        /// <param name="px2">parallax (arcseconds), after</param>
        /// <param name="rv2">radial velocity (km/s, +ve = receding), after</param>
        /// <returns>status code</returns>
        public static int Starpm(double ra1, double dec1,
                                 double pmr1, double pmd1, double px1, double rv1,
                                 double ep1a, double ep1b, double ep2a, double ep2b,
                                 out double ra2, out double dec2,
                                 out double pmr2, out double pmd2, out double px2, out double rv2)
        {
            // Initialize out parameters to default values
            ra2 = 0.0;
            dec2 = 0.0;
            pmr2 = 0.0;
            pmd2 = 0.0;
            px2 = 0.0;
            rv2 = 0.0;

            var pv1 = new double[2, 3];
            double tl1, dt, r2, rdv, v2, c2mv2, tl2;
            var pv = new double[2, 3];
            var pv2 = new double[2, 3];
            int j1, j2, j;

            /* RA,Dec etc. at the "before" epoch to space motion pv-vector. */
            j1 = Starpv(ra1, dec1, pmr1, pmd1, px1, rv1, ref pv1);

            /* Light time when observed (days). */
            tl1 = Pm(pv1.GetRow(0)) / DC;

            /* Time interval, "before" to "after" (days). */
            dt = (ep2a - ep1a) + (ep2b - ep1b);

            /* Move star along track from the "before" observed position to the */
            /* "after" geometric position. */
            Pvu(dt + tl1, pv1, ref pv);

            /* From this geometric position, deduce the observed light time (days) */
            /* at the "after" epoch (with theoretically unneccessary error check). */
            r2 = Pdp(pv.GetRow(0), pv.GetRow(0));
            rdv = Pdp(pv.GetRow(0), pv.GetRow(1));
            v2 = Pdp(pv.GetRow(1), pv.GetRow(1));
            c2mv2 = DC * DC - v2;
            if (c2mv2 <= 0.0) return -1;
            tl2 = (-rdv + Sqrt(rdv * rdv + c2mv2 * r2)) / c2mv2;

            /* Move the position along track from the observed place at the */
            /* "before" epoch to the observed place at the "after" epoch. */
            Pvu(dt + (tl1 - tl2), pv1, ref pv2);

            /* Space motion pv-vector to RA,Dec etc. at the "after" epoch. */
            j2 = Pvstar(pv2, out ra2, out dec2, out pmr2, out pmd2, out px2, out rv2);

            /* Final status. */
            j = (j2 == 0) ? j1 : -1;

            return j;
        }
    }
}
