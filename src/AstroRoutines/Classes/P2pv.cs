namespace AstroRoutines
{
    public static partial class AR
    {
		/// <summary>
		/// Extend a p-vector to a pv-vector by appending a zero velocity.
		/// </summary>
		/// <param name="p">p-vector</param>
		/// <param name="pv">pv-vector</param>
        public static void P2pv(double[] p, ref double[,] pv)
        {
            Cp(p, new double[] { pv[0, 0], pv[0, 1], pv[0, 2] });
            Zp(new double[] { pv[1, 0], pv[1, 1], pv[1, 2] });

            /* Finished. */
        }
    }
}
