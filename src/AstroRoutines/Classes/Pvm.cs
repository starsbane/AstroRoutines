namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Modulus of pv-vector
        /// </summary>
        /// <param name="pv">pv-vector</param>
        /// <param name="r">Modulus of position component</param>
        /// <param name="s">Modulus of velocity component</param>
        public static void Pvm(double[,] pv, out double r, out double s)
        {
            // Distance
            r = Pm(pv.GetRow(0));

            // Speed
            s = Pm(pv.GetRow(1));
        }

        // Reuse the GetRow extension method from Pv2p
    }
}
