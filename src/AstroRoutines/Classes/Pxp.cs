namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// P-vector outer (vector/cross) product.
        /// </summary>
        /// <param name="a">First p-vector</param>
        /// <param name="b">Second p-vector</param>
        /// <param name="axb">Result of a x b</param>
        public static void Pxp(double[] a, double[] b, ref double[] axb)
        {
            var xa = a[0];
            var ya = a[1];
            var za = a[2];
            var xb = b[0];
            var yb = b[1];
            var zb = b[2];
            axb[0] = ya*zb - za*yb;
            axb[1] = za*xb - xa*zb;
            axb[2] = xa*yb - ya*xb;
        }
    }
}
