namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// For a terrestrial observer, prepare star-independent astrometry parameters for transformations between ICRS and observed coordinates.
        /// </summary>
        /// <param name="utc1">UTC as a 2-part...</param>
        /// <param name="utc2">...quasi Julian Date (Notes 1,2)</param>
        /// <param name="dut1">UT1-UTC (seconds, Note 3)</param>
        /// <param name="elong">longitude (radians, east +ve, Note 4)</param>
        /// <param name="phi">latitude (geodetic, radians, Note 4)</param>
        /// <param name="hm">height above ellipsoid (m, geodetic, Notes 4,6)</param>
        /// <param name="xp">polar motion coordinates (radians, Note 5)</param>
        /// <param name="yp">polar motion coordinates (radians, Note 5)</param>
        /// <param name="phpa">pressure at the observer (hPa = mB, Note 6)</param>
        /// <param name="tc">ambient temperature at the observer (deg C)</param>
        /// <param name="rh">relative humidity at the observer (range 0-1)</param>
        /// <param name="wl">wavelength (micrometers, Note 7)</param>
        /// <param name="astrom">star-independent astrometry parameters</param>
        /// <param name="eo">equation of the origins (ERA-GST, radians)</param>
        /// <returns>status: +1 = dubious year (Note 2), 0 = OK, -1 = unacceptable date</returns>
        public static int Apco13(double utc1, double utc2, double dut1,
                                double elong, double phi, double hm, double xp, double yp,
                                double phpa, double tc, double rh, double wl,
                                ref ASTROM astrom, ref double eo)
        {
            double ut11 = 0, ut12 = 0;
            var ehpv = new double[2, 3];
            var ebpv = new double[2, 3];
            var r = new double[3, 3];

            /* UTC to other time scales. */
            var j = Utctai(utc1, utc2, out var tai1, out var tai2);
            if (j < 0) return -1;
            j = Taitt(tai1, tai2, out var tt1, out var tt2);
            j = Utcut1(utc1, utc2, dut1, ref ut11, ref ut12);
            if (j < 0) return -1;

            /* Earth barycentric & heliocentric position/velocity (au, au/d). */
            Epv00(tt1, tt2, ref ehpv, ref ebpv);

            /* Form the equinox based BPN matrix, IAU 2006/2000A. */
            Pnm06a(tt1, tt2, ref r);

            /* Extract CIP X,Y. */
            Bpn2xy(r, out var x, out var y);

            /* Obtain CIO locator s. */
            var s = S06(tt1, tt2, x, y);

            /* Earth rotation angle. */
            var theta = Era00(ut11, ut12);

            /* TIO locator s'. */
            var sp = Sp00(tt1, tt2);

            /* Refraction constants A and B. */
            Refco(phpa, tc, rh, wl, out var refa, out var refb);

            /* Compute the star-independent astrometry parameters. */
            var ehp = ehpv.GetRow(0);
            Apco(tt1, tt2, ebpv, ehp, x, y, s, theta,
                 elong, phi, hm, xp, yp, sp, refa, refb, ref astrom);

            /* Equation of the origins. */
            eo = Eors(r, s);

            /* Return any warning status. */
            return j;

            /* Finished. */
        }
    }
}
