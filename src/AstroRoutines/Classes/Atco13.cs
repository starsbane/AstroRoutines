using AstroRoutines.Structs;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// ICRS RA,Dec to observed place. The caller supplies UTC, site coordinates, ambient air conditions and observing wavelength.
        /// </summary>
        /// <param name="rc">ICRS right ascension at J2000.0 (radians)</param>
        /// <param name="dc">ICRS declination at J2000.0 (radians)</param>
        /// <param name="pr">RA proper motion (radians/year)</param>
        /// <param name="pd">Dec proper motion (radians/year)</param>
        /// <param name="px">parallax (arcsec)</param>
        /// <param name="rv">radial velocity (km/s, +ve if receding)</param>
        /// <param name="utc1">UTC as a 2-part quasi Julian Date</param>
        /// <param name="utc2">UTC as a 2-part quasi Julian Date</param>
        /// <param name="dut1">UT1-UTC (seconds)</param>
        /// <param name="elong">longitude (radians, east +ve)</param>
        /// <param name="phi">latitude (geodetic, radians)</param>
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
        /// <param name="eo">equation of the origins (ERA-GST, radians)</param>
        /// <returns>status: +1 = dubious year, 0 = OK, -1 = unacceptable date</returns>
        public static int Atco13(double rc, double dc,
            double pr, double pd, double px, double rv,
            double utc1, double utc2, double dut1,
            double elong, double phi, double hm, double xp, double yp,
            double phpa, double tc, double rh, double wl,
            ref double aob, ref double zob, ref double hob,
            ref double dob, ref double rob, ref double eo)
        {
            int j;
            var astrom = new ASTROM();
            double ri, di;

            /* Star-independent astrometry parameters. */
            j = Apco13(utc1, utc2, dut1, elong, phi, hm, xp, yp,
                phpa, tc, rh, wl, ref astrom, ref eo);

            /* Abort if bad UTC. */
            if (j < 0)
            {
                aob = zob = hob = dob = rob = 0;
                return j;
            }

            /* Transform ICRS to CIRS. */
            Atciq(rc, dc, pr, pd, px, rv, ref astrom, out ri, out di);

            /* Transform CIRS to observed. */
            Atioq(ri, di, ref astrom, out aob, out zob, out hob, out dob, out rob);

            /* Return OK/warning status. */
            return j;
        }
    }
}
