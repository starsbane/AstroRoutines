namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Multiply a p-vector by an r-matrix.
        /// </summary>
        /// <param name="r">r-matrix</param>
        /// <param name="p">p-vector</param>
        /// <param name="rp">r * p</param>
        public static void Rxp(double[,] r, double[] p, ref double[] rp)
        {
            double w;
            double[] wrp = new double[3];

            for (int j = 0; j < 3; j++)
            {
                w = 0.0;
                for (int i = 0; i < 3; i++)
                {
                    w += r[j, i] * p[i];
                }
                wrp[j] = w;
            }

            Cp(wrp, rp);
        }
    }
}
