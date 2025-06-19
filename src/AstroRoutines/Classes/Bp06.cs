namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Frame bias and precession, IAU 2006.
        /// </summary>
        /// <param name="date1">TT as a 2-part Julian Date</param>
        /// <param name="date2">TT as a 2-part Julian Date</param>
        /// <param name="rb">frame bias matrix</param>
        /// <param name="rp">precession matrix</param>
        /// <param name="rbp">bias-precession matrix</param>
        public static void Bp06(double date1, double date2,
            out double[,] rb, out double[,] rp, out double[,] rbp)
        {
            double gamb, phib, psib, epsa;
            double[,] rbpw = new double[3, 3];
            double[,] rbt = new double[3, 3];
            rb = new double[2,2];
            /* B matrix. */
            Pfw06(DJM0, DJM00, out gamb, out phib, out psib, out epsa);
            Fw2m(gamb, phib, psib, epsa, ref rb);

            /* PxB matrix (temporary). */
            Pmat06(date1, date2, ref rbpw);

            /* P matrix. */
            Tr(rb, ref rbt);
            Rxr(rbpw, rbt, out rp);

            /* PxB matrix. */
            rbp = rbpw;
        }
    }
}
