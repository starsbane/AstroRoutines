using static System.Math;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Convert position/velocity from spherical to Cartesian coordinates.
        /// </summary>
        /// <param name="theta">longitude angle (radians)</param>
        /// <param name="phi">latitude angle (radians)</param>
        /// <param name="r">radial distance</param>
        /// <param name="td">rate of change of theta</param>
        /// <param name="pd">rate of change of phi</param>
        /// <param name="rd">rate of change of r</param>
        /// <param name="pv">pv-vector</param>
        public static void S2pv(double theta, double phi, double r,
                                double td, double pd, double rd,
                                ref double[,] pv)
        {
            var st = Sin(theta);
            var ct = Cos(theta);
            var sp = Sin(phi);
            var cp = Cos(phi);
            var rcp = r * cp;
            var x = rcp * ct;
            var y = rcp * st;
            var rpd = r * pd;
            var w = rpd * sp - cp * rd;

            pv[0, 0] = x;
            pv[0, 1] = y;
            pv[0, 2] = r * sp;
            pv[1, 0] = -y * td - w * ct;
            pv[1, 1] = x * td - w * st;
            pv[1, 2] = rpd * cp + sp * rd;
        }
    }
}
