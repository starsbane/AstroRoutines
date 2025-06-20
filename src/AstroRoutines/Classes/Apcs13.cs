namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// For an observer whose geocentric position and velocity are known, prepare star-independent astrometry parameters for transformations between ICRS and GCRS.
        /// </summary>
        /// <param name="date1">TDB as a 2-part...</param>
        /// <param name="date2">...Julian Date (Note 1)</param>
        /// <param name="pv">observer's geocentric pos/vel (Note 3)</param>
        /// <param name="astrom">star-independent astrometry parameters</param>
        public static void Apcs13(double date1, double date2, double[,] pv, ref ASTROM astrom)
        {
            var ehpv = new double[2, 3];
            var ebpv = new double[2, 3];

            /* Earth barycentric & heliocentric position/velocity (au, au/d). */
            Epv00(date1, date2, ref ehpv, ref ebpv);

            /* Compute the star-independent astrometry parameters. */
            var ehp = new double[3] { ehpv[0, 0], ehpv[0, 1], ehpv[0, 2] };
            Apcs(date1, date2, pv, ebpv, ehp, ref astrom);

            /* Finished. */
        }
    }
}
