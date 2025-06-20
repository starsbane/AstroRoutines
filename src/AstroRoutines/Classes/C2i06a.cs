namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Form the celestial-to-intermediate matrix for a given date using the IAU 2006 precession and IAU 2000A nutation models.
        /// </summary>
        /// <param name="date1">TT as a 2-part Julian Date</param>
        /// <param name="date2">TT as a 2-part Julian Date</param>
        /// <param name="rc2i">celestial-to-intermediate matrix</param>
        public static void C2i06a(double date1, double date2, ref double[,] rc2i)
        {
            var rbpn = new double[3, 3];

            /* Obtain the celestial-to-true matrix (IAU 2006/2000A). */
            Pnm06a(date1, date2, ref rbpn);

            /* Extract the X,Y coordinates. */
            Bpn2xy(rbpn, out var x, out var y);

            /* Obtain the CIO locator. */
            var s = S06(date1, date2, x, y);

            /* Form the celestial-to-intermediate matrix. */
            C2ixys(x, y, s, ref rc2i);
        }
    }
}
