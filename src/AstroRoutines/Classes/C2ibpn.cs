namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Form the celestial-to-intermediate matrix for a given date given the bias-precession-nutation matrix. IAU 2000.
        /// </summary>
        /// <param name="date1">TT as a 2-part Julian Date</param>
        /// <param name="date2">TT as a 2-part Julian Date</param>
        /// <param name="rbpn">celestial-to-true matrix</param>
        /// <param name="rc2i">celestial-to-intermediate matrix</param>
        public static void C2ibpn(double date1, double date2, double[,] rbpn,
            ref double[,] rc2i)
        {
            double x, y;

            /* Extract the X,Y coordinates. */
            Bpn2xy(rbpn, out x, out y);

            /* Form the celestial-to-intermediate matrix (n.b. IAU 2000 specific). */
            C2ixy(date1, date2, x, y, ref rc2i);
        }
    }
}
