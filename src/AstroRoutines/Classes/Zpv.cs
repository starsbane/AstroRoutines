namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Zero a pv-vector.
        /// </summary>
        /// <param name="pv">PV-vector to be zeroed</param>
        public static void Zpv(ref double[,] pv)
        {
            var pvRow0 = pv.GetRow(0);
            Zp(ref pvRow0);
            pv.SetRow(0, pvRow0);

            var pvRow1 = pv.GetRow(1);
            Zp(ref pvRow1);
            pv.SetRow(1, pvRow1);
        }
    }
}
