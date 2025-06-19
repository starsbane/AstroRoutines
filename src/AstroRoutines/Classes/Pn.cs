namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Convert a p-vector into modulus and unit vector.
        /// </summary>
        /// <param name="p">p-vector</param>
        /// <param name="r">modulus</param>
        /// <param name="u">unit vector</param>
        public static void Pn(double[] p, out double r, out double[] u)
        {
            /* Obtain the modulus and test for zero. */
            double w = Pm(p);

            if (w == 0.0)
            {
                /* Null vector. */
                Zp(u);
            }
            else
            {
                /* Unit vector. */
                Sxp(1.0 / w, p, ref u);
            }

            /* Return the modulus. */
            r = w;
        }
    }
}
