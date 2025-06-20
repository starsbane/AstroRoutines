namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Initialize an r-matrix to the null matrix.
        /// </summary>
        /// <param name="r">R-matrix to be zeroed</param>
        public static void Zr(ref double[,] r)
        {
            r[0,0] = 0.0;
            r[0,1] = 0.0;
            r[0,2] = 0.0;
            r[1,0] = 0.0;
            r[1,1] = 0.0;
            r[1,2] = 0.0;
            r[2,0] = 0.0;
            r[2,1] = 0.0;
            r[2,2] = 0.0;
        }
    }
}
