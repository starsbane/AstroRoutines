namespace AstroRoutines
{
    public static partial class AR
    {
		/// <summary>
		/// Transformation from ICRS RA,Dec to ecliptic coordinates (mean equinox
		/// and ecliptic of date), using a long-term precession model.
		/// </summary>
		/// <param name="epj">Julian epoch (TT)</param>
		/// <param name="dr">ICRS right ascension and declination (radians)</param>
		/// <param name="dd">ICRS right ascension and declination (radians)</param>
		/// <param name="dl">ecliptic longitude and latitude (radians)</param>
		/// <param name="db">ecliptic longitude and latitude (radians)</param>
        public static void Lteqec(double epj, double dr, double dd, out double dl, out double db)
        {
            var rm = new double[3, 3];
            var v1 = new double[3];
            var v2 = new double[3];
            double a, b;

            /* Spherical to Cartesian. */
            S2c(dr, dd, ref v1);

            /* Rotation matrix, ICRS equatorial to ecliptic. */
            Ltecm(epj, rm);

            /* The transformation from ICRS to ecliptic. */
            Rxp(rm, v1, ref v2);

            /* Cartesian to spherical. */
            C2s(v2, out a, out b);

            /* Express in conventional ranges. */
            dl = Anp(a);
            db = Anpm(b);

            /* Finished. */
        }
    }
}
