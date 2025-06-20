using AstroRoutines.Structs;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// CIRS RA,Dec to observed place. The caller supplies UTC, site coordinates, ambient air conditions and observing wavelength.
        /// </summary>
        /// <param name="ri">CIRS right ascension (CIO-based, radians)</param>
        /// <param name="di">CIRS declination (radians)</param>
        /// <param name="utc1">UTC as a 2-part quasi Julian Date</param>
        /// <param name="utc2">UTC as a 2-part quasi Julian Date</param>
        /// <param name="dut1">UT1-UTC (seconds)</param>
        /// <param name="elong">longitude (radians, east +ve)</param>
        /// <param name="phi">geodetic latitude (radians)</param>
        /// <param name="hm">height above ellipsoid (m, geodetic)</param>
        /// <param name="xp">polar motion coordinates (radians)</param>
        /// <param name="yp">polar motion coordinates (radians)</param>
        /// <param name="phpa">pressure at the observer (hPa = mB)</param>
        /// <param name="tc">ambient temperature at the observer (deg C)</param>
        /// <param name="rh">relative humidity at the observer (range 0-1)</param>
        /// <param name="wl">wavelength (micrometers)</param>
        /// <param name="aob">observed azimuth (radians: N=0,E=90)</param>
        /// <param name="zob">observed zenith distance (radians)</param>
        /// <param name="hob">observed hour angle (radians)</param>
        /// <param name="dob">observed declination (radians)</param>
        /// <param name="rob">observed right ascension (CIO-based, radians)</param>
        /// <returns>status: +1 = dubious year, 0 = OK, -1 = unacceptable date</returns>
        public static int Atio13(double ri, double di,
            double utc1, double utc2, double dut1,
            double elong, double phi, double hm, double xp, double yp,
            double phpa, double tc, double rh, double wl,
            out double aob, out double zob, out double hob,
            out double dob, out double rob)
        {
            int j;
            var astrom = new ASTROM();

            /* Star-independent astrometry parameters for CIRS->observed. */
            j = Apio13(utc1, utc2, dut1, elong, phi, hm, xp, yp,
                phpa, tc, rh, wl, ref astrom);

            /* Abort if bad UTC. */
            if (j < 0)
            {
                aob = zob = hob = dob = rob = 0;
                return j;
            }

            /* Transform CIRS to observed. */
            Atioq(ri, di, ref astrom, out aob, out zob, out hob, out dob, out rob);

            /* Return OK/warning status. */
            return j;
        }
    }
}
