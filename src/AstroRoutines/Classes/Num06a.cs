namespace AstroRoutines
{
    public static partial class AR
    {
		/// <summary>
		/// Form the matrix of nutation for a given date, IAU 2006/2000A model.
		/// </summary>
		/// <param name="date1">TT as a 2-part Julian Date (Note 1)</param>
		/// <param name="date2">TT as a 2-part Julian Date (Note 1)</param>
		/// <param name="rmatn">nutation matrix</param>
        public static void Num06a(double date1, double date2, ref double[,] rmatn)
        {
            double eps, dp = 0, de = 0;

            /* Mean obliquity. */
            eps = Obl06(date1, date2);

            /* Nutation components. */
            Nut06a(date1, date2, out dp, out de);

            /* Nutation matrix. */
            Numat(eps, dp, de, out rmatn);

            /* Finished. */
        }
    }
}
