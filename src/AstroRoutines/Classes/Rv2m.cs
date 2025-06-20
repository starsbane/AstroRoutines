using static System.Math;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Form the r-matrix corresponding to a given r-vector.
        /// </summary>
        /// <param name="w">Rotation vector</param>
        /// <param name="r">Rotation matrix</param>
        public static void Rv2m(double[] w, ref double[,] r)
        {
            double x, y, z, phi, s, c, f;

            // Euler angle (magnitude of rotation vector) and functions
            x = w[0];
            y = w[1];
            z = w[2];
            phi = Sqrt(x * x + y * y + z * z);
            s = Sin(phi);
            c = Cos(phi);
            f = 1.0 - c;

            // Euler axis (direction of rotation vector), perhaps null
            if (phi > 0.0)
            {
                x /= phi;
                y /= phi;
                z /= phi;
            }

            // Form the rotation matrix
            r[0, 0] = x * x * f + c;
            r[0, 1] = x * y * f + z * s;
            r[0, 2] = x * z * f - y * s;
            r[1, 0] = y * x * f - z * s;
            r[1, 1] = y * y * f + c;
            r[1, 2] = y * z * f + x * s;
            r[2, 0] = z * x * f + y * s;
            r[2, 1] = z * y * f - x * s;
            r[2, 2] = z * z * f + c;
        }
    }
}
