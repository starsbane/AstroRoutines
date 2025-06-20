using AstroRoutines.Structs;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Transform star RA,Dec from geocentric CIRS to ICRS astrometric.
        /// </summary>
        /// <param name="ri">CIRS geocentric RA (radians)</param>
        /// <param name="di">CIRS geocentric Dec (radians)</param>
        /// <param name="date1">TDB as a 2-part Julian Date</param>
        /// <param name="date2">TDB as a 2-part Julian Date</param>
        /// <param name="rc">ICRS astrometric RA (radians)</param>
        /// <param name="dc">ICRS astrometric Dec (radians)</param>
        /// <param name="eo">equation of the origins (ERA-GST, radians)</param>
        public static void Atic13(double ri, double di, double date1, double date2,
            out double rc, out double dc, out double eo)
        {
            /* Star-independent astrometry parameters */
            var astrom = new ASTROM();

            /* Star-independent astrometry parameters. */
            Apci13(date1, date2, ref astrom, out eo);

            /* CIRS to ICRS astrometric. */
            Aticq(ri, di, ref astrom, out rc, out dc);
        }
    }
}
