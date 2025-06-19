namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// P-vector addition
        /// </summary>
        /// <param name="a">First p-vector</param>
        /// <param name="b">Second p-vector</param>
        /// <param name="apb">a + b</param>
        public static void Ppp(double[] a, double[] b, ref double[] apb)
        {
            apb[0] = a[0] + b[0];
            apb[1] = a[1] + b[1];
            apb[2] = a[2] + b[2];
        }
    }
}
