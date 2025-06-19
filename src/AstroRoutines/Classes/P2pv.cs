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
            var pvRow0 = pv.GetRow(0);
            Cp(p, ref pvRow0);
            pv.SetRow(0, pvRow0);

            var pvRow1 = pv.GetRow(1);
            Zp(ref pvRow1);
            pv.SetRow(1, pvRow1);

            /* Finished. */
        }
    }
}
