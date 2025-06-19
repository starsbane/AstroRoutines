namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Equation of the origins, given the classical NPB matrix and the
        /// quantity s.
        /// </summary>
        /// <param name="rnpb">classical nutation x precession x bias matrix</param>
        /// <param name="s">the quantity s (the CIO locator) in radians</param>
        /// <returns>the equation of the origins in radians</returns>
        public static double Eors(double[,] rnpb, double s)
        {
            double x, ax, xs, ys, zs, p, q, eo;

            /* Evaluate Wallace & Capitaine (2006) expression (16). */
            x = rnpb[2, 0];
            ax = x / (1.0 + rnpb[2, 2]);
            xs = 1.0 - ax * x;
            ys = -ax * rnpb[2, 1];
            zs = -x;
            p = rnpb[0, 0] * xs + rnpb[0, 1] * ys + rnpb[0, 2] * zs;
            q = rnpb[1, 0] * xs + rnpb[1, 1] * ys + rnpb[1, 2] * zs;
            eo = ((p != 0.0) || (q != 0.0)) ? s - Atan2(q, p) : s;

            return eo;

            /* Finished. */
        }
    }
}
