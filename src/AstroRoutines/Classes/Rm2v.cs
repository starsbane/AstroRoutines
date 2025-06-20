using static System.Math;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Express an r-matrix as an r-vector.
        /// </summary>
        /// <param name="r">Rotation matrix</param>
        /// <param name="w">Rotation vector</param>
        public static void Rm2v(double[,] r, ref double[] w)
        {
            double c2, phi, f;

            var x = r[1, 2] - r[2, 1];
            var y = r[2, 0] - r[0, 2];
            var z = r[0, 1] - r[1, 0];
            var s2 = Sqrt(x * x + y * y + z * z);
            if (s2 > 0)
            {
                c2 = r[0, 0] + r[1, 1] + r[2, 2] - 1.0;
                phi = Atan2(s2, c2);
                f = phi / s2;
                w[0] = x * f;
                w[1] = y * f;
                w[2] = z * f;
            }
            else
            {
                w[0] = 0.0;
                w[1] = 0.0;
                w[2] = 0.0;
            }
        }
    }
}
