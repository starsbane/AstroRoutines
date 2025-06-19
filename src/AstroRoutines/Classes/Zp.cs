namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Zero a p-vector.
        /// </summary>
        /// <param name="p">P-vector to be zeroed</param>
        public static void Zp(ref double[] p)
        {
            p[0] = 0.0;
            p[1] = 0.0;
            p[2] = 0.0;
        }
    }
}