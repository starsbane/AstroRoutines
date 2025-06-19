namespace AstroRoutines
{
    public static partial class AR
    {
		/// <summary>
		/// Precession matrix (including frame bias) from GCRS to a specified
		/// date, IAU 2000 model.
		/// </summary>
		/// <param name="date1">TT as a 2-part Julian Date (Note 1)</param>
		/// <param name="date2">TT as a 2-part Julian Date (Note 1)</param>
		/// <param name="rbp">bias-precession matrix (Note 2)</param>
        public static void Pmat00(double date1, double date2, ref double[,] rbp)
        {
            double[,] rb = new double[3, 3];
            double[,] rp = new double[3, 3];

            /* Obtain the required matrix (discarding others). */
            Bp00(date1, date2, out rb, out rp, out rbp);

            /* Finished. */
        }
    }
}
