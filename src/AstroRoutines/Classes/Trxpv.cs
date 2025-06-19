namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Multiply a pv-vector by the transpose of an r-matrix.
        /// </summary>
        public static void Trxpv(double[,] r, double[,] pv, double[,] trpv)
        {
            double[] p = new double[3] { pv[0, 0], pv[0, 1], pv[0, 2] };
            double[] v = new double[3] { pv[1, 0], pv[1, 1], pv[1, 2] };
            double[] rtp = new double[3];
            double[] rtv = new double[3];

            // Transpose multiply position
            for (int j = 0; j < 3; j++)
            {
                rtp[j] = r[0, j] * p[0] + r[1, j] * p[1] + r[2, j] * p[2];
                rtv[j] = r[0, j] * v[0] + r[1, j] * v[1] + r[2, j] * v[2];
            }

            trpv[0, 0] = rtp[0]; trpv[0, 1] = rtp[1]; trpv[0, 2] = rtp[2];
            trpv[1, 0] = rtv[0]; trpv[1, 1] = rtv[1]; trpv[1, 2] = rtv[2];
        }
    }
}
