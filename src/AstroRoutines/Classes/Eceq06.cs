namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Transformation from ecliptic coordinates (mean equinox and ecliptic
        /// of date) to ICRS RA,Dec, using the IAU 2006 precession model.
        /// </summary>
        /// <param name="date1">TT as a 2-part Julian date (Note 1)</param>
        /// <param name="date2">TT as a 2-part Julian date (Note 1)</param>
        /// <param name="dl">ecliptic longitude and latitude (radians)</param>
        /// <param name="db">ecliptic longitude and latitude (radians)</param>
        /// <param name="dr">ICRS right ascension and declination (radians)</param>
        /// <param name="dd">ICRS right ascension and declination (radians)</param>
        public static void Eceq06(double date1, double date2, double dl, double db,
                       ref double dr, ref double dd)
        {
            var rm = new double[3, 3];
            var v1 = new double[3];
            var v2 = new double[3];

            /* Spherical to Cartesian. */
            S2c(dl, db, ref v1);

            /* Rotation matrix, ICRS equatorial to ecliptic. */
            Ecm06(date1, date2, ref rm);

            /* The transformation from ecliptic to ICRS. */
            Trxp(rm, v1, ref v2);

            /* Cartesian to spherical. */
            C2s(v2, out var a, out var b);

            /* Express in conventional ranges. */
            dr = Anp(a);
            dd = Anpm(b);

            /* Finished. */
        }
    }
}
