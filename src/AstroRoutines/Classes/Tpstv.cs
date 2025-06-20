using static System.Math;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// In the tangent plane projection, given the star's rectangular
        /// coordinates and the direction cosines of the tangent point, solve
        /// for the direction cosines of the star.
        /// </summary>
        /// <param name="xi">Rectangular coordinates of star image</param>
        /// <param name="eta">Rectangular coordinates of star image</param>
        /// <param name="v0">Direction cosines of the tangent point</param>
        /// <param name="v">Direction cosines of the star</param>
        public static void Tpstv(double xi, double eta, double[] v0, ref double[] v)
        {
            // Tangent point
            var x = v0[0];
            var y = v0[1];
            var z = v0[2];

            // Deal with polar case
            var r = Sqrt(x * x + y * y);
            if (r == 0.0)
            {
                r = 1e-20;
                x = r;
            }

            // Star vector length to tangent plane
            var f = Sqrt(1.0 + xi * xi + eta * eta);

            // Apply the transformation and normalize
            v[0] = (x - (xi * y + eta * x * z) / r) / f;
            v[1] = (y + (xi * x - eta * y * z) / r) / f;
            v[2] = (z + eta * r) / f;
        }
    }
}
