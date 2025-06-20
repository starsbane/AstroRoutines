using static System.Math;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Rotate an r-matrix about the x-axis.
        /// </summary>
        /// <param name="phi">Angle (radians)</param>
        /// <param name="r">R-matrix, rotated</param>
        public static void Rx(double phi, ref double[,] r)
        {
            double s, c, a10, a11, a12, a20, a21, a22;

            s = Sin(phi);
            c = Cos(phi);

            a10 = c * r[1, 0] + s * r[2, 0];
            a11 = c * r[1, 1] + s * r[2, 1];
            a12 = c * r[1, 2] + s * r[2, 2];
            a20 = -s * r[1, 0] + c * r[2, 0];
            a21 = -s * r[1, 1] + c * r[2, 1];
            a22 = -s * r[1, 2] + c * r[2, 2];

            r[1, 0] = a10;
            r[1, 1] = a11;
            r[1, 2] = a12;
            r[2, 0] = a20;
            r[2, 1] = a21;
            r[2, 2] = a22;
        }
    }
}
