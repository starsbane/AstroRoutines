namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// P-vector plus scaled p-vector
        /// </summary>
        /// <param name="a">First p-vector</param>
        /// <param name="s">Scalar (multiplier for b)</param>
        /// <param name="b">Second p-vector</param>
        /// <param name="apsb">a + s*b</param>
        public static void Ppsp(double[] a, double s, double[] b, out double[] apsb)
        {
            double[] sb = new double[3];
            apsb = new double[3];

            // s*b
            Sxp(s, b, ref sb);

            // a + s*b
            Ppp(a, sb, ref apsb);
        }
    }
}
