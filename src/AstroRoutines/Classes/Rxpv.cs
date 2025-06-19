namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Multiply a pv-vector by an r-matrix.
        /// </summary>
        /// <param name="r">r-matrix</param>
        /// <param name="pv">pv-vector</param>
        /// <param name="rpv">r * pv</param>
        public static void Rxpv(double[,] r, double[,] pv, ref double[,] rpv)
        {
            var rpvRow0 = new double[3];
            var rpvRow1 = new double[3];
            Rxp(r, pv.GetRow(0), ref rpvRow0);
            rpv.SetRow(0, rpvRow0);

            Rxp(r, pv.GetRow(1), ref rpvRow1);
            rpv.SetRow(1, rpvRow1);
        }
    }
}
