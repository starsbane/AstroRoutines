namespace AstroRoutines
{
    public static partial class AR
    {
		/// <summary>
		/// P-vector subtraction.
		/// </summary>
		/// <param name="a">first p-vector</param>
		/// <param name="b">second p-vector</param>
		/// <param name="amb">a - b</param>
        public static void Pmp(double[] a, double[] b, ref double[] amb)
        {
            amb[0] = a[0] - b[0];
            amb[1] = a[1] - b[1];
            amb[2] = a[2] - b[2];

            /* Finished. */
        }
    }
}
