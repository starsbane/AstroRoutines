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
        public static double Eo06a(double date1, double date2)
        {
            var r = new double[3, 3];

            /* Classical nutation x precession x bias matrix. */
            Pnm06a(date1, date2, ref r);

            /* Extract CIP coordinates. */
            Bpn2xy(r, out var x, out var y);

            /* The CIO locator, s. */
            var s = S06(date1, date2, x, y);

            /* Solve for the EO. */
            var eo = Eors(r, s);

            return eo;

            /* Finished. */
        }
    }
}
