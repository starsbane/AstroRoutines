namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// For a terrestrial observer, prepare star-independent astrometry parameters for transformations between CIRS and observed coordinates.
        /// </summary>
        /// <param name="utc1">UTC as a 2-part...</param>
        /// <param name="utc2">...quasi Julian Date (Notes 1,2)</param>
        /// <param name="dut1">UT1-UTC (seconds, Note 3)</param>
        /// <param name="elong">longitude (radians, east +ve, Note 4)</param>
        /// <param name="phi">geodetic latitude (radians, Note 4)</param>
        /// <param name="hm">height above ellipsoid (m, geodetic, Notes 4,6)</param>
        /// <param name="xp">polar motion coordinates (radians, Note 5)</param>
        /// <param name="yp">polar motion coordinates (radians, Note 5)</param>
        /// <param name="phpa">pressure at the observer (hPa = mB, Note 6)</param>
        /// <param name="tc">ambient temperature at the observer (deg C)</param>
        /// <param name="rh">relative humidity at the observer (range 0-1)</param>
        /// <param name="wl">wavelength (micrometers, Note 7)</param>
        /// <param name="astrom">star-independent astrometry parameters</param>
        /// <returns>status: +1 = dubious year (Note 2), 0 = OK, -1 = unacceptable date</returns>
        public static int Apio13(double utc1, double utc2, double dut1,
                                double elong, double phi, double hm, double xp, double yp,
                                double phpa, double tc, double rh, double wl,
                                ref ASTROM astrom)
        {
            int j;
            double tai1 = 0, tai2 = 0, tt1 = 0, tt2 = 0, ut11 = 0, ut12 = 0;
            double sp, theta, refa = 0, refb = 0;

            /* UTC to other time scales. */
            j = Utctai(utc1, utc2, out tai1, out tai2);
            if (j < 0) return -1;
            j = Taitt(tai1, tai2, out tt1, out tt2);
            j = Utcut1(utc1, utc2, dut1, ref ut11, ref ut12);
            if (j < 0) return -1;

            /* TIO locator s'. */
            sp = Sp00(tt1, tt2);

            /* Earth rotation angle. */
            theta = Era00(ut11, ut12);

            /* Refraction constants A and B. */
            Refco(phpa, tc, rh, wl, out refa, out refb);

            /* CIRS <-> observed astrometry parameters. */
            Apio(sp, theta, elong, phi, hm, xp, yp, refa, refb, ref astrom);

            /* Return any warning status. */
            return j;

            /* Finished. */
        }
    }
}
