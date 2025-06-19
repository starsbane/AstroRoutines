namespace AstroRoutines
{
    public static partial class AR
    {
		/// <summary>
		/// Form the matrix of nutation.
		/// </summary>
		/// <param name="epsa">mean obliquity of date (Note 1)</param>
		/// <param name="dpsi">nutation in longitude (Note 2)</param>
		/// <param name="deps">nutation in obliquity (Note 2)</param>
		/// <param name="rmatn">nutation matrix (Note 3)</param>
        public static void Numat(double epsa, double dpsi, double deps, out double[,] rmatn)
        {
            /* Build the rotation matrix. */
            rmatn = new double[3, 3];
            Ir(ref rmatn);
            Rx(epsa, ref rmatn);
            Rz(-dpsi, ref rmatn);
            Rx(-(epsa + deps), ref rmatn);

            /* Finished. */
        }
    }
}
