// Cr.cs
using System;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Copy an r-matrix.
        /// </summary>
        /// <param name="r">r-matrix to be copied</param>
        /// <param name="c">copy</param>
        public static void Cr(double[,] r, ref double[,] c)
        {
            var r0 = r.GetRow(0);
            var c0 = new double[3];
            var r1 = r.GetRow(1);
            var c1 = new double[3];
            var r2 = r.GetRow(2);
            var c2 = new double[3];
            
            Cp(r0, ref c0);
            Cp(r1, ref c1);
            Cp(r2, ref c2);
            
            c[0, 0] = c0[0]; c[0, 1] = c0[1]; c[0, 2] = c0[2];
            c[1, 0] = c1[0]; c[1, 1] = c1[1]; c[1, 2] = c1[2];
            c[2, 0] = c2[0]; c[2, 1] = c2[1]; c[2, 2] = c2[2];

            /* Finished. */
        }
    }
}
