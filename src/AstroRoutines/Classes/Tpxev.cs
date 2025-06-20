using static System.Math;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// In the tangent plane projection, given celestial direction cosines
        /// for a star and the tangent point, solve for the star's rectangular
        /// coordinates in the tangent plane.
        /// </summary>
        /// <param name="v">Direction cosines of star</param>
        /// <param name="v0">Direction cosines of tangent point</param>
        /// <param name="xi">Returned tangent plane coordinates of star</param>
        /// <param name="eta">Returned tangent plane coordinates of star</param>
        /// <returns>
        /// Status: 
        /// 0 = OK
        /// 1 = star too far from axis
        /// 2 = antistar on tangent plane
        /// 3 = antistar too far from axis
        /// </returns>
        public static int Tpxev(double[] v, double[] v0, ref double xi, ref double eta)
        {
            const double TINY = 1e-6;
            int j;

            // Star and tangent point
            var x = v[0];
            var y = v[1];
            var z = v[2];
            var x0 = v0[0];
            var y0 = v0[1];
            var z0 = v0[2];

            // Deal with polar case
            var r2 = x0 * x0 + y0 * y0;
            var r = Sqrt(r2);
            if (r == 0.0)
            {
                r = 1e-20;
                x0 = r;
            }

            // Reciprocal of star vector length to tangent plane
            var w = x * x0 + y * y0;
            var d = w + z * z0;

            // Check for error cases
            if (d > TINY)
            {
                j = 0;
            }
            else if (d >= 0.0)
            {
                j = 1;
                d = TINY;
            }
            else if (d > -TINY)
            {
                j = 2;
                d = -TINY;
            }
            else
            {
                j = 3;
            }

            // Return the tangent plane coordinates
            d *= r;
            xi = (y * x0 - x * y0) / d;
            eta = (z * r2 - z0 * w) / d;

            // Return the status
            return j;
        }
    }
}
