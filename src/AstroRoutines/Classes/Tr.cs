namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Transpose an r-matrix.
        /// </summary>
        /// <param name="r">r-matrix to be transposed</param>
        /// <param name="rt">transposed matrix</param>
        public static void Tr(double[,] r, ref double[,] rt)
        {
            var wm = new double[3, 3];
            for (int i = 0; i < 3; i++) {
                for (int j = 0; j < 3; j++) {
                    wm[i, j] = r[j, i];
                }
            }
            Cr(wm, ref rt);
        }
    }
}
