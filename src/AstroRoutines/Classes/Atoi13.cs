using AstroRoutines.Structs;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Observed place to CIRS. The caller supplies UTC, site coordinates, ambient air conditions and observing wavelength.
        /// </summary>
        /// <param name="type">type of coordinates - "R", "H" or "A"</param>
        /// <param name="ob1">observed Az, HA or RA (radians; Az is N=0,E=90)</param>
        /// <param name="ob2">observed ZD or Dec (radians)</param>
        /// <param name="utc1">UTC as a 2-part quasi Julian Date</param>
        /// <param name="utc2">UTC as a 2-part quasi Julian Date</param>
        /// <param name="dut1">UT1-UTC (seconds)</param>
        /// <param name="elong">longitude (radians, east +ve)</param>
        /// <param name="phi">geodetic latitude (radians)</param>
        /// <param name="hm">height above the ellipsoid (meters)</param>
        /// <param name="xp">polar motion coordinates (radians)</param>
        /// <param name="yp">polar motion coordinates (radians)</param>
        /// <param name="phpa">pressure at the observer (hPa = mB)</param>
        /// <param name="tc">ambient temperature at the observer (deg C)</param>
        /// <param name="rh">relative humidity at the observer (range 0-1)</param>
        /// <param name="wl">wavelength (micrometers)</param>
        /// <param name="ri">CIRS right ascension (CIO-based, radians)</param>
        /// <param name="di">CIRS declination (radians)</param>
        /// <returns>status: +1 = dubious year, 0 = OK, -1 = unacceptable date</returns>
        public static int Atoi13(string type, double ob1, double ob2,
            double utc1, double utc2, double dut1,
            double elong, double phi, double hm, double xp, double yp,
            double phpa, double tc, double rh, double wl,
            out double ri, out double di)
        {
            int j;
            ASTROM astrom = new ASTROM();

            /* Star-independent astrometry parameters for CIRS->observed. */
            j = Apio13(utc1, utc2, dut1, elong, phi, hm, xp, yp,
                phpa, tc, rh, wl, ref astrom);

            /* Abort if bad UTC. */
            if (j < 0)
            {
                ri = di = 0;
                return j;
            }

            /* Transform observed to CIRS. */
            Atoiq(type, ob1, ob2, ref astrom, out ri, out di);

            /* Return OK/warning status. */
            return j;
        }
    }
}
