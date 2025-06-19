namespace AstroRoutines
{
    public static partial class AR
    {
		/// <summary>
		/// Form the matrix of nutation for a given date, IAU 2000B model.
		/// </summary>
		/// <param name="date1">TT as a 2-part Julian Date (Note 1)</param>
		/// <param name="date2">TT as a 2-part Julian Date (Note 1)</param>
		/// <param name="rmatn">nutation matrix</param>
        public static void Num00b(double date1, double date2, ref double[,] rmatn)
        {
            double dpsi = 0, deps = 0, epsa;
            var rb = new double[3, 3];
            var rp = new double[3, 3];
            var rbp = new double[3, 3];
            var rbpn = new double[3, 3];

            /* Obtain the required matrix (discarding other results). */
            Pn00b(date1, date2,
                  out dpsi, out deps, out epsa, out rb, out rp, out rbp, out rmatn, out rbpn);

            /* Finished. */
        }
    }
}
