// Cpv.cs

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Copy a position/velocity vector.
        /// </summary>
        /// <param name="pv">position/velocity vector to be copied</param>
        /// <param name="c">copy</param>
        public static void Cpv(double[,] pv, double[,] c)
        {
            var p0 = pv.GetRow(0);
            var c0 = new double[3];
            var p1 = pv.GetRow(1);
            var c1 = new double[3];
            
            Cp(p0, ref c0);
            Cp(p1, ref c1);
            
            c[0, 0] = c0[0]; c[0, 1] = c0[1]; c[0, 2] = c0[2];
            c[1, 0] = c1[0]; c[1, 1] = c1[1]; c[1, 2] = c1[2];

            /* Finished. */
        }
    }
}
