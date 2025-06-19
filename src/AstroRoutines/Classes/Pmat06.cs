namespace AstroRoutines
{
    public static partial class AR
    {
		/// <summary>
		/// Precession matrix (including frame bias) from GCRS to a specified
		/// date, IAU 2006 model.
		/// </summary>
		/// <param name="date1">TT as a 2-part Julian Date (Note 1)</param>
		/// <param name="date2">TT as a 2-part Julian Date (Note 1)</param>
		/// <param name="rbp">bias-precession matrix (Note 2)</param>
        public static void Pmat06(double date1, double date2, ref double[,] rbp)
        {
            double gamb, phib, psib, epsa;

            /* Bias-precession Fukushima-Williams angles. */
            Pfw06(date1, date2, out gamb, out phib, out psib, out epsa);

            /* Form the matrix. */
            Fw2m(gamb, phib, psib, epsa, ref rbp);

            /* Finished. */
        }
    }
}
