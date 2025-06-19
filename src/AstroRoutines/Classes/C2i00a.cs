namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Form the celestial-to-intermediate matrix for a given date using the IAU 2000A precession-nutation model.
        /// </summary>
        /// <param name="date1">TT as a 2-part Julian Date</param>
        /// <param name="date2">TT as a 2-part Julian Date</param>
        /// <param name="rc2i">celestial-to-intermediate matrix</param>
        public static void C2i00a(double date1, double date2, ref double[,] rc2i)
        {
            double[,] rbpn = new double[3, 3];

            /* Obtain the celestial-to-true matrix (IAU 2000A). */
            Pnm00a(date1, date2, out rbpn);

            /* Form the celestial-to-intermediate matrix. */
            C2ibpn(date1, date2, rbpn, ref rc2i);
        }
    }
}
