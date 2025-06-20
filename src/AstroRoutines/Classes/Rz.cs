using static System.Math;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Rotate an r-matrix about the z-axis.
        /// </summary>
        /// <param name="psi">Angle (radians)</param>
        /// <param name="r">R-matrix, rotated</param>
        public static void Rz(double psi, ref double[,] r)
        {
            var s = Sin(psi);
            var c = Cos(psi);

            var a00 = c * r[0, 0] + s * r[1, 0];
            var a01 = c * r[0, 1] + s * r[1, 1];
            var a02 = c * r[0, 2] + s * r[1, 2];
            var a10 = -s * r[0, 0] + c * r[1, 0];
            var a11 = -s * r[0, 1] + c * r[1, 1];
            var a12 = -s * r[0, 2] + c * r[1, 2];

            r[0, 0] = a00;
            r[0, 1] = a01;
            r[0, 2] = a02;
            r[1, 0] = a10;
            r[1, 1] = a11;
            r[1, 2] = a12;
        }
    }
}
