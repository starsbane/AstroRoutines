using static System.Math;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Transform geodetic coordinates to geocentric for a reference
        /// ellipsoid of specified form.
        /// </summary>
        /// <param name="a">equatorial radius</param>
        /// <param name="f">flattening</param>
        /// <param name="elong">longitude (radians, east +ve)</param>
        /// <param name="phi">latitude (geodetic, radians)</param>
        /// <param name="height">height above ellipsoid (geodetic)</param>
        /// <param name="xyz">geocentric vector</param>
        /// <returns>status: 0 = OK, -1 = illegal case</returns>
        public static int Gd2gce(double a, double f, double elong, double phi, double height, out double[] xyz)
        {
            double sp, cp, w, d, ac, _as, r;
            xyz = new double[3];

            /* Functions of geodetic latitude. */
            sp = Sin(phi);
            cp = Cos(phi);
            w = 1.0 - f;
            w = w * w;
            d = cp * cp + w * sp * sp;
            if (d <= 0.0) return -1;
            ac = a / Sqrt(d);
            _as = w * ac;

            /* Geocentric vector. */
            r = (ac + height) * cp;
            xyz[0] = r * Cos(elong);
            xyz[1] = r * Sin(elong);
            xyz[2] = (_as + height) * sp;

            /* Success. */
            return 0;

            /* Finished. */
        }
    }
}
