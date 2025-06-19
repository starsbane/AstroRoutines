// Cp.cs
using System;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Copy a p-vector.
        /// </summary>
        /// <param name="p">p-vector to be copied</param>
        /// <param name="c">copy</param>
        public static void Cp(double[] p, double[] c)
        {
            c[0] = p[0];
            c[1] = p[1];
            c[2] = p[2];

            /* Finished. */
        }
    }
}
