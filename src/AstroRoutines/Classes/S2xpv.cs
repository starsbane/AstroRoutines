namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Multiply a pv-vector by two scalars.
        /// </summary>
        /// <param name="s1">scalar to multiply position component by</param>
        /// <param name="s2">scalar to multiply velocity component by</param>
        /// <param name="pv">pv-vector</param>
        /// <param name="spv">scaled pv-vector</param>
        public static void S2xpv(double s1, double s2, double[,] pv, ref double[,] spv)
        {
            var spvRow0 = new double[3];
            var spvRow1 = new double[3];

            Sxp(s1, pv.GetRow(0), ref spvRow0);
            spv.SetRow(0, spvRow0);

            Sxp(s2, pv.GetRow(1), ref spvRow1);
            spv.SetRow(1, spvRow1);
        }
    }
}
