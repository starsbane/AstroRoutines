namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Discard velocity component of a pv-vector
        /// </summary>
        /// <param name="pv">pv-vector</param>
        /// <param name="p">p-vector</param>
        public static void Pv2p(double[,] pv, ref double[] p)
        {
            Cp(pv.GetRow(0), ref p);
        }

        // Extension method to help with array row extraction

    }
}
