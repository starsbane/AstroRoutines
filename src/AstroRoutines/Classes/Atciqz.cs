namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Quick ICRS to CIRS transformation, given precomputed star-independent astrometry parameters, and assuming zero parallax and proper motion.
        /// </summary>
        /// <param name="rc">ICRS RA at J2000.0 (radians)</param>
        /// <param name="dc">ICRS Dec at J2000.0 (radians)</param>
        /// <param name="astrom">star-independent astrometry parameters</param>
        /// <param name="ri">CIRS RA (radians)</param>
        /// <param name="di">CIRS Dec (radians)</param>
        public static void Atciqz(double rc, double dc, ref ASTROM astrom,
            out double ri, out double di)
        {
            var pco = new double[3];
            var pnat = new double[3];
            var ppr = new double[3];
            var pi = new double[3];
            double w;

            /* BCRS coordinate direction (unit vector). */
            S2c(rc, dc, ref pco);

            /* Light deflection by the Sun, giving BCRS natural direction. */
            Ldsun(pco, astrom.eh, astrom.em, ref pnat);

            /* Aberration, giving GCRS proper direction. */
            Ab(pnat, astrom.v, astrom.em, astrom.bm1, ref ppr);

            /* Bias-precession-nutation, giving CIRS proper direction. */
            Rxp(astrom.bpn, ppr, ref pi);

            /* CIRS RA,Dec. */
            C2s(pi, out w, out di);
            ri = Anp(w);
        }
    }
}
