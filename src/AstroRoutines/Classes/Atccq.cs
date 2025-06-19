using AstroRoutines.Structs;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Quick transformation of a star's ICRS catalog entry (epoch J2000.0) into ICRS astrometric place, given precomputed star-independent astrometry parameters.
        /// </summary>
        /// <param name="rc">ICRS right ascension at J2000.0 (radians)</param>
        /// <param name="dc">ICRS declination at J2000.0 (radians)</param>
        /// <param name="pr">RA proper motion (radians/year)</param>
        /// <param name="pd">Dec proper motion (radians/year)</param>
        /// <param name="px">parallax (arcsec)</param>
        /// <param name="rv">radial velocity (km/s, +ve if receding)</param>
        /// <param name="astrom">star-independent astrometry parameters</param>
        /// <param name="ra">ICRS astrometric RA (radians)</param>
        /// <param name="da">ICRS astrometric Dec (radians)</param>
        public static void Atccq(double rc, double dc, double pr, double pd, double px, double rv,
                                ref ASTROM astrom, ref double ra, ref double da)
        {
            double[] pco = new double[3];
            double w;

            /* Proper motion and parallax, giving BCRS coordinate direction. */
            Pmpx(rc, dc, pr, pd, px, rv, astrom.pmt, astrom.eb, ref pco);

            /* ICRS astrometric RA,Dec to spherical coordinates. */
            C2s(pco, out w, out da);
            ra = Anp(w);
        }
    }
}
