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
            Cp(r0, ref c0);
            c.SetRow(0, c0);

            var r1 = r.GetRow(1);
            var c1 = new double[3];
            Cp(r1, ref c1);
            c.SetRow(1, c1);

            var r2 = r.GetRow(2);
            var c2 = new double[3];
            Cp(r2, ref c2);
            c.SetRow(2, c2);
        }
    }
}
