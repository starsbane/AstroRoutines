namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Multiply a pv-vector by the transpose of an r-matrix.
        /// </summary>
        /// <param name="r">R-matrix</param>
        /// <param name="pv">PV-vector</param>
        /// <param name="trpv">Resulting transposed PV-vector</param>
        public static void Trxpv(double[,] r, double[,] pv, ref double[,] trpv)
        {
            double[,] tr = new double[3, 3];

            // Transpose of matrix r
            Tr(r, ref tr);

            // Matrix tr * vector pv -> vector trpv
            Rxpv(tr, pv, ref trpv);
        }
    }
}
