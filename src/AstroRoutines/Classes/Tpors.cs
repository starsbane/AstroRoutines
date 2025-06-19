namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// In the tangent plane projection, given the rectangular coordinates of a star and its spherical coordinates, determine the spherical coordinates of the tangent point.
        /// </summary>
        /// <param name="xi">rectangular coordinates of star image</param>
        /// <param name="eta">rectangular coordinates of star image</param>
        /// <param name="a">star's spherical coordinates</param>
        /// <param name="b">star's spherical coordinates</param>
        /// <param name="a01">tangent point's spherical coordinates, Soln. 1</param>
        /// <param name="b01">tangent point's spherical coordinates, Soln. 1</param>
        /// <param name="a02">tangent point's spherical coordinates, Soln. 2</param>
        /// <param name="b02">tangent point's spherical coordinates, Soln. 2</param>
        /// <returns>number of solutions: 0 = no solutions returned (Note 5), 1 = only the first solution is useful (Note 6), 2 = both solutions are useful (Note 6)</returns>
        public static int Tpors(double xi, double eta, double a, double b, out double a01, out double b01, out double a02, out double b02)
        {
            a01 = 0; b01 = 0; a02 = 0; b02 = 0;
            double xi2 = xi * xi;
            double r = Sqrt(1.0 + xi2 + eta * eta);
            double sb = Sin(b);
            double cb = Cos(b);
            double rsb = r * sb;
            double rcb = r * cb;
            double w2 = rcb * rcb - xi2;

            if (w2 >= 0.0)
            {
                double w = Sqrt(w2);
                double s = rsb - eta * w;
                double c = rsb * eta + w;
                if (xi == 0.0 && w == 0.0) w = 1.0;
                a01 = Anp(a - Atan2(xi, w));
                b01 = Atan2(s, c);
                w = -w;
                s = rsb - eta * w;
                c = rsb * eta + w;
                a02 = Anp(a - Atan2(xi, w));
                b02 = Atan2(s, c);
                return (Abs(rsb) < 1.0) ? 1 : 2;
            }
            else
            {
                return 0;
            }
        }
    }
}
