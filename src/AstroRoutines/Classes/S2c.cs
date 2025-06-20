using static System.Math;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Convert spherical coordinates to Cartesian.
        /// </summary>
        /// <param name="theta">longitude angle (radians)</param>
        /// <param name="phi">latitude angle (radians)</param>
        /// <param name="c">direction cosines</param>
        public static void S2c(double theta, double phi, ref double[] c)
        {
            var cp = Cos(phi);
            c[0] = Cos(theta) * cp;
            c[1] = Sin(theta) * cp;
            c[2] = Sin(phi);
        }
    }
}
