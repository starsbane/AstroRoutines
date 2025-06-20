namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Transform geocentric coordinates to geodetic using the specified
        /// reference ellipsoid.
        /// </summary>
        /// <param name="n">ellipsoid identifier</param>
        /// <param name="xyz">geocentric vector</param>
        /// <param name="elong">longitude (radians, east +ve)</param>
        /// <param name="phi">latitude (geodetic, radians)</param>
        /// <param name="height">height above ellipsoid (geodetic)</param>
        /// <returns>status: 0 = OK, -1 = illegal identifier, -2 = internal error</returns>
        public static int Gc2gd(int n, double[] xyz, out double elong, out double phi, out double height)
        {
            phi = 0;
            height = 0;
            elong = 0;

            /* Obtain reference ellipsoid parameters. */
            var j = Eform(n, out var a, out var f);

            /* If OK, transform x,y,z to longitude, geodetic latitude, height. */
            if (j == 0)
            {
                j = Gc2gde(a, f, xyz, out elong, out phi, out height);
                if (j < 0) j = -2;
            }

            /* Deal with any errors. */
            if (j < 0)
            {
                elong = -1e9;
                phi = -1e9;
                height = -1e9;
            }

            /* Return the status. */
            return j;

            /* Finished. */
        }
    }
}
