namespace AstroRoutines
{
    public static partial class AR
    {
		/// <summary>
		/// p-vector inner (=scalar=dot) product.
		/// </summary>
		/// <param name="a">first p-vector</param>
		/// <param name="b">second p-vector</param>
		/// <returns>a . b</returns>
        public static double Pdp(double[] a, double[] b)
        {
            var w = a[0] * b[0]
                    + a[1] * b[1]
                    + a[2] * b[2];

            return w;

            /* Finished. */
        }
    }
}
