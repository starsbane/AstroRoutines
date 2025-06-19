namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Apply aberration to transform natural direction into proper direction.
        /// </summary>
        /// <param name="pnat">natural direction to the source (unit vector)</param>
        /// <param name="v">observer barycentric velocity in units of c</param>
        /// <param name="s">distance between the Sun and the observer (au)</param>
        /// <param name="bm1">sqrt(1-|v|^2): reciprocal of Lorenz factor</param>
        /// <param name="ppr">proper direction to source (unit vector)</param>
        public static void Ab(double[] pnat, double[] v, double s, double bm1, ref double[] ppr)
        {
            double pdv = Pdp(pnat, v);
            double w1 = 1.0 + pdv / (1.0 + bm1);
            double w2 = SRS / s;
            double r2 = 0.0;
            double[] p = new double[3];

            for (int i = 0; i < 3; i++)
            {
                double w = pnat[i] * bm1 + w1 * v[i] + w2 * (v[i] - pdv * pnat[i]);
                p[i] = w;
                r2 += w * w;
            }

            double r = Sqrt(r2);
            for (int i = 0; i < 3; i++)
            {
                ppr[i] = p[i] / r;
            }
        }
    }
}
