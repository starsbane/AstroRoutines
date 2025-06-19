using AstroRoutines.Structs;

namespace AstroRoutines
{
    public static partial class AR
    {
		/// <summary>
		/// Transform ICRS star data, epoch J2000.0, to CIRS.
		/// </summary>
		/// <param name="rc">ICRS right ascension at J2000.0 (radians)</param>
		/// <param name="dc">ICRS declination at J2000.0 (radians)</param>
		/// <param name="pr">RA proper motion (radians/year)</param>
		/// <param name="pd">Dec proper motion (radians/year)</param>
		/// <param name="px">parallax (arcsec)</param>
		/// <param name="rv">radial velocity (km/s, +ve if receding)</param>
		/// <param name="date1">TDB as a 2-part Julian Date</param>
		/// <param name="date2">TDB as a 2-part Julian Date</param>
		/// <param name="ri">CIRS geocentric RA (radians)</param>
		/// <param name="di">CIRS geocentric Dec (radians)</param>
		/// <param name="eo">equation of the origins (ERA-GST, radians)</param>
        public static void Atci13(double rc, double dc, double pr, double pd, double px, double rv,
                                  double date1, double date2,
                                  ref double ri, ref double di, ref double eo)
        {
            /* Star-independent astrometry parameters */
            ASTROM astrom = default;

            /* The transformation parameters. */
            Apci13(date1, date2, ref astrom, out eo);

            /* ICRS (epoch J2000.0) to CIRS. */
            Atciq(rc, dc, pr, pd, px, rv, ref astrom, out ri, out di);
        }
    }
}
