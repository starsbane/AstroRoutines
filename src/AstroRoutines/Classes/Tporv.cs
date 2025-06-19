namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// In the tangent plane projection, given the rectangular coordinates of a star and its direction cosines, determine the direction cosines of the tangent point.
        /// </summary>
        /// <param name="xi">rectangular coordinates of star image</param>
        /// <param name="eta">rectangular coordinates of star image</param>
        /// <param name="v">star's direction cosines</param>
        /// <param name="v01">tangent point's direction cosines, Solution 1</param>
        /// <param name="v02">tangent point's direction cosines, Solution 2</param>
        /// <returns>number of solutions: 0 = no solutions returned (Note 5), 1 = only the first solution is useful (Note 6), 2 = both solutions are useful (Note 6)</returns>
        public static int Tporv(double xi, double eta, double[] v, ref double[] v01, ref double[] v02)
        {
            double x = v[0];
            double y = v[1];
            double z = v[2];
            double rxy2 = x * x + y * y;
            double xi2 = xi * xi;
            double eta2p1 = eta * eta + 1.0;
            double r = Sqrt(xi2 + eta2p1);
            double rsb = r * z;
            double rcb = r * Sqrt(rxy2);
            double w2 = rcb * rcb - xi2;

            if (w2 > 0.0)
            {
                double w = Sqrt(w2);
                double c_val = (rsb * eta + w) / (eta2p1 * Sqrt(rxy2 * (w2 + xi2)));
                v01[0] = c_val * (x * w + y * xi);
                v01[1] = c_val * (y * w - x * xi);
                v01[2] = (rsb - eta * w) / eta2p1;
                w = -w;
                c_val = (rsb * eta + w) / (eta2p1 * Sqrt(rxy2 * (w2 + xi2)));
                v02[0] = c_val * (x * w + y * xi);
                v02[1] = c_val * (y * w - x * xi);
                v02[2] = (rsb - eta * w) / eta2p1;
                return (Abs(rsb) < 1.0) ? 1 : 2;
            }
            else
            {
                return 0;
            }
        }
    }
}
