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
        public static double S06a(double date1, double date2)
        {
            var rnpb = new double[3, 3];
            double x, y, s;

            /* Bias-precession-nutation-matrix, IAU 2006/2000A. */
            Pnm06a(date1, date2, ref rnpb);

            /* Extract the CIP coordinates. */
            Bpn2xy(rnpb, out x, out y);

            /* Compute the CIO locator s, given the CIP coordinates. */
            s = S06(date1, date2, x, y);

            return s;
        }
    }
}
