using static System.Math;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// In the tangent plane projection, given celestial spherical
        /// coordinates for a star and the tangent point, solve for the star's
        /// rectangular coordinates in the tangent plane.
        /// </summary>
        /// <param name="a">Star's spherical coordinate</param>
        /// <param name="b">Star's spherical coordinate</param>
        /// <param name="a0">Tangent point's spherical coordinate</param>
        /// <param name="b0">Tangent point's spherical coordinate</param>
        /// <param name="xi">Rectangular coordinates of star image</param>
        /// <param name="eta">Rectangular coordinates of star image</param>
        /// <returns>
        /// Status: 
        /// 0 = OK
        /// 1 = star too far from axis
        /// 2 = antistar on tangent plane
        /// 3 = antistar too far from axis
        /// </returns>
        public static int Tpxes(double a, double b, double a0, double b0, 
                                ref double xi, ref double eta)
        {
            const double TINY = 1e-6;
            int j;

            // Functions of the spherical coordinates
            var sb0 = Sin(b0);
            var sb = Sin(b);
            var cb0 = Cos(b0);
            var cb = Cos(b);
            var da = a - a0;
            var sda = Sin(da);
            var cda = Cos(da);

            // Reciprocal of star vector length to tangent plane
            var d = sb * sb0 + cb * cb0 * cda;

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
            xi = cb * sda / d;
            eta = (sb * cb0 - cb * sb0 * cda) / d;

            // Return the status
            return j;
        }
    }
}
