namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Inner (scalar/dot) product of two pv-vectors
        /// </summary>
        /// <param name="a">First pv-vector</param>
        /// <param name="b">Second pv-vector</param>
        /// <param name="adb">Dot product result</param>
        public static void Pvdpv(double[,] a, double[,] b, ref double[] adb)
        {
            // a . b = constant part of result
            adb[0] = Pdp(a.GetRow(0), b.GetRow(0));

            // a . bdot
            var adbd = Pdp(a.GetRow(0), b.GetRow(1));

            // adot . b
            var addb = Pdp(a.GetRow(1), b.GetRow(0));

            // Velocity part of result
            adb[1] = adbd + addb;
        }

        // Reuse the GetRow extension method from Pv2p
    }
}
