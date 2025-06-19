namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Multiply a pv-vector by a scalar.
        /// </summary>
        /// <param name="s">scalar</param>
        /// <param name="pv">pv-vector</param>
        /// <param name="spv">s * pv</param>
        public static void Sxpv(double s, double[,] pv, ref double[,] spv)
        {
            S2xpv(s, s, pv, ref spv);
        }
    }
}
