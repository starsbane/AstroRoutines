namespace AstroRoutines
{
    public static partial class AR
    {
		/// <summary>
		/// Modulus of p-vector.
		/// </summary>
		/// <param name="p">p-vector</param>
		/// <returns>modulus</returns>
        public static double Pm(double[] p)
        {
            return Sqrt(p[0] * p[0] + p[1] * p[1] + p[2] * p[2]);

            /* Finished. */
        }
    }
}
