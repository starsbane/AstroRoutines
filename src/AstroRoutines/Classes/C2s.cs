namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// P-vector to spherical coordinates.
        /// </summary>
        /// <param name="p">p-vector</param>
        /// <param name="theta">longitude angle (radians)</param>
        /// <param name="phi">latitude angle (radians)</param>
        public static void C2s(double[] p, out double theta, out double phi)
        {
            double x, y, z, d2;

            x = p[0];
            y = p[1];
            z = p[2];
            d2 = x * x + y * y;

            theta = (d2 == 0.0) ? 0.0 : Atan2(y, x);
            phi = (z == 0.0) ? 0.0 : Atan2(z, Sqrt(d2));
        }
    }
}
