namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// The CIO locator s, positioning the Celestial Intermediate Origin on the equator of the Celestial Intermediate Pole.
        /// </summary>
        /// <param name="date1">TT as a 2-part Julian Date</param>
        /// <param name="date2">TT as a 2-part Julian Date</param>
        /// <returns>The CIO locator s in radians</returns>
        public static double S00b(double date1, double date2)
        {
            var rbpn = new double[3, 3];
            double x, y, s;

            /* Bias-precession-nutation-matrix, IAU 2000B. */
            Pnm00b(date1, date2, ref rbpn);

            /* Extract the CIP coordinates. */
            Bpn2xy(rbpn, out x, out y);

            /* Compute the CIO locator s, given the CIP coordinates. */
            s = S00(date1, date2, x, y);

            return s;
        }
    }
}
