namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Multiply a p-vector by the transpose of an r-matrix.
        /// </summary>
        /// <param name="r">r-matrix</param>
        /// <param name="p">p-vector</param>
        /// <param name="trp">result of r^T * p</param>
        public static void Trxp(double[,] r, double[] p, ref double[] trp)
        {
            var tr = new double[3, 3];

            /* Transpose of matrix r. */
            Tr(r, ref tr);

            /* Matrix tr * vector p -> vector trp. */
            Rxp(tr, p, ref trp);
        }
    }
}
