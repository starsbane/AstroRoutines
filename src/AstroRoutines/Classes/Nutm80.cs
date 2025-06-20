namespace AstroRoutines
{
    public static partial class AR
    {
		/// <summary>
		/// Form the matrix of nutation for a given date, IAU 1980 model.
		/// </summary>
		/// <param name="date1">TDB date (Note 1)</param>
		/// <param name="date2">TDB date (Note 1)</param>
		/// <param name="rmatn">nutation matrix</param>
        public static void Nutm80(double date1, double date2, out double[,] rmatn)
        {
            /* Nutation components and mean obliquity. */
            Nut80(date1, date2, out var dpsi, out var deps);
            var epsa = Obl80(date1, date2);

            /* Build the rotation matrix. */
            Numat(epsa, dpsi, deps, out rmatn);

            /* Finished. */
        }
    }
}
