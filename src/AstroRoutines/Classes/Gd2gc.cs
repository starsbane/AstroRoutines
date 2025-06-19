namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Transform geodetic coordinates to geocentric using the specified
        /// reference ellipsoid.
        /// </summary>
        /// <param name="n">ellipsoid identifier</param>
        /// <param name="elong">longitude (radians, east +ve)</param>
        /// <param name="phi">latitude (geodetic, radians)</param>
        /// <param name="height">height above ellipsoid (geodetic)</param>
        /// <param name="xyz">geocentric vector</param>
        /// <returns>status: 0 = OK, -1 = illegal identifier, -2 = illegal case</returns>
        public static int Gd2gc(int n, double elong, double phi, double height, ref double[] xyz)
        {
            int j;
            double a, f;

            /* Obtain reference ellipsoid parameters. */
            j = Eform(n, out a, out f);

            /* If OK, transform longitude, geodetic latitude, height to x,y,z. */
            if (j == 0)
            {
                j = Gd2gce(a, f, elong, phi, height, ref xyz);
                if (j != 0) j = -2;
            }

            /* Deal with any errors. */
            if (j != 0) Zp(ref xyz);

            /* Return the status. */
            return j;

            /* Finished. */
        }
    }
}
