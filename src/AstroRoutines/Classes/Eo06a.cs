namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Equation of the origins, IAU 2006 precession and IAU 2000A nutation.
        /// </summary>
        /// <param name="date1">TT as a 2-part Julian Date (Note 1)</param>
        /// <param name="date2">TT as a 2-part Julian Date (Note 1)</param>
        /// <returns>the equation of the origins in radians</returns>
        public static double Eo06a(double date1, ref double date2)
        {
            double[,] r = new double[3, 3];
            double x, y, s, eo;

            /* Classical nutation x precession x bias matrix. */
            Pnm06a(date1, date2, ref r);

            /* Extract CIP coordinates. */
            Bpn2xy(r, out x, out y);

            /* The CIO locator, s. */
            s = S06(date1, date2, x, y);

            /* Solve for the EO. */
            eo = Eors(r, s);

            return eo;

            /* Finished. */
        }
    }
}
