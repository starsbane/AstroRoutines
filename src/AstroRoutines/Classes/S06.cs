namespace AstroRoutines
{
    public static partial class AR
    {
        internal record S06_TERM 
        {
            public int[] Nfa { get; init; }
            public double S { get; init; }
            public double C { get; init; }
        }

        /// <summary>
        /// The CIO locator s, positioning the Celestial Intermediate Origin on the equator of the Celestial Intermediate Pole.
        /// </summary>
        /// <param name="date1">TT as a 2-part Julian Date</param>
        /// <param name="date2">TT as a 2-part Julian Date</param>
        /// <param name="x">CIP x-coordinate</param>
        /// <param name="y">CIP y-coordinate</param>
        /// <returns>The CIO locator s in radians</returns>
        public static double S06(double date1, double date2, double x, double y)
        {
            /* Time since J2000.0, in Julian centuries */
            double t = ((date1 - DJ00) + date2) / DJC;

            /* Miscellaneous */
            int i, j;
            double a, w0, w1, w2, w3, w4, w5;

            /* Fundamental arguments */
            double[] fa = new double[8];

            /* Returned value */
            double s;

            /* Polynomial coefficients */
            double[] sp = {
                /* 1-6 */
                    94.00e-6,
                3808.65e-6,
                -122.68e-6,
            -72574.11e-6,
                27.98e-6,
                15.62e-6
            };

            /* Terms of order t^0 */
            S06_TERM[] s0 = {
                /* 1-10 */
                new() { Nfa = new int[] { 0,  0,  0,  0,  1,  0,  0,  0}, S = -2640.73e-6, C = 0.39e-6 },
                new() { Nfa = new int[] { 0,  0,  0,  0,  2,  0,  0,  0}, S = -63.53e-6, C = 0.02e-6 },
                new() { Nfa = new int[] { 0,  0,  2, -2,  3,  0,  0,  0}, S = -11.75e-6, C = -0.01e-6 },
                new() { Nfa = new int[] { 0,  0,  2, -2,  1,  0,  0,  0}, S = -11.21e-6, C = -0.01e-6 },
                new() { Nfa = new int[] { 0,  0,  2, -2,  2,  0,  0,  0}, S = 4.57e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 0,  0,  2,  0,  3,  0,  0,  0}, S = -2.02e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 0,  0,  2,  0,  1,  0,  0,  0}, S = -1.98e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 0,  0,  0,  0,  3,  0,  0,  0}, S = 1.72e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 0,  1,  0,  0,  1,  0,  0,  0}, S = 1.41e-6, C = 0.01e-6 },
                new() { Nfa = new int[] { 0,  1,  0,  0, -1,  0,  0,  0}, S = 1.26e-6, C = 0.01e-6 },

                /* 11-20 */
                new() { Nfa = new int[] { 1,  0,  0,  0, -1,  0,  0,  0}, S = 0.63e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 1,  0,  0,  0,  1,  0,  0,  0}, S = 0.63e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 0,  1,  2, -2,  3,  0,  0,  0}, S = -0.46e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 0,  1,  2, -2,  1,  0,  0,  0}, S = -0.45e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 0,  0,  4, -4,  4,  0,  0,  0}, S = -0.36e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 0,  0,  1, -1,  1, -8, 12,  0}, S = 0.24e-6, C = 0.12e-6 },
                new() { Nfa = new int[] { 0,  0,  2,  0,  0,  0,  0,  0}, S = -0.32e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 0,  0,  2,  0,  2,  0,  0,  0}, S = -0.28e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 1,  0,  2,  0,  3,  0,  0,  0}, S = -0.27e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 1,  0,  2,  0,  1,  0,  0,  0}, S = -0.26e-6, C = 0.00e-6 },

                /* 21-30 */
                new() { Nfa = new int[] { 0,  0,  2, -2,  0,  0,  0,  0}, S = 0.21e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 0,  1, -2,  2, -3,  0,  0,  0}, S = -0.19e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 0,  1, -2,  2, -1,  0,  0,  0}, S = -0.18e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 0,  0,  0,  0,  0,  8,-13, -1}, S = 0.10e-6, C = -0.05e-6 },
                new() { Nfa = new int[] { 0,  0,  0,  2,  0,  0,  0,  0}, S = -0.15e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 2,  0, -2,  0, -1,  0,  0,  0}, S = 0.14e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 0,  1,  2, -2,  2,  0,  0,  0}, S = 0.14e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 1,  0,  0, -2,  1,  0,  0,  0}, S = -0.14e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 1,  0,  0, -2, -1,  0,  0,  0}, S = -0.14e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 0,  0,  4, -2,  4,  0,  0,  0}, S = -0.13e-6, C = 0.00e-6 },

                /* 31-33 */
                new() { Nfa = new int[] { 0,  0,  2, -2,  4,  0,  0,  0}, S = 0.11e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 1,  0, -2,  0, -3,  0,  0,  0}, S = -0.11e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 1,  0, -2,  0, -1,  0,  0,  0}, S = -0.11e-6, C = 0.00e-6 }
            };

            /* Terms of order t^1 */
            S06_TERM[] s1 = {
                /* 1-3 */
                new() { Nfa = new int[] { 0,  0,  0,  0,  2,  0,  0,  0}, S = -0.07e-6, C = 3.57e-6 },
                new() { Nfa = new int[] { 0,  0,  0,  0,  1,  0,  0,  0}, S = 1.73e-6, C = -0.03e-6 },
                new() { Nfa = new int[] { 0,  0,  2, -2,  3,  0,  0,  0}, S = 0.00e-6, C = 0.48e-6 }
            };

            /* Terms of order t^2 */
            S06_TERM[] s2 = {
                /* 1-10 */
                new() { Nfa = new int[] { 0,  0,  0,  0,  1,  0,  0,  0}, S = 743.52e-6, C = -0.17e-6 },
                new() { Nfa = new int[] { 0,  0,  2, -2,  2,  0,  0,  0}, S = 56.91e-6, C = 0.06e-6 },
                new() { Nfa = new int[] { 0,  0,  2,  0,  2,  0,  0,  0}, S = 9.84e-6, C = -0.01e-6 },
                new() { Nfa = new int[] { 0,  0,  0,  0,  2,  0,  0,  0}, S = -8.85e-6, C = 0.01e-6 },
                new() { Nfa = new int[] { 0,  1,  0,  0,  0,  0,  0,  0}, S = -6.38e-6, C = -0.05e-6 },
                new() { Nfa = new int[] { 1,  0,  0,  0,  0,  0,  0,  0}, S = -3.07e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 0,  1,  2, -2,  2,  0,  0,  0}, S = 2.23e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 0,  0,  2,  0,  1,  0,  0,  0}, S = 1.67e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 1,  0,  2,  0,  2,  0,  0,  0}, S = 1.30e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 0,  1, -2,  2, -2,  0,  0,  0}, S = 0.93e-6, C = 0.00e-6 },

                /* 11-20 */
                new() { Nfa = new int[] { 1,  0,  0, -2,  0,  0,  0,  0}, S = 0.68e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 0,  0,  2, -2,  1,  0,  0,  0}, S = -0.55e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 1,  0, -2,  0, -2,  0,  0,  0}, S = 0.53e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 0,  0,  0,  2,  0,  0,  0,  0}, S = -0.27e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 1,  0,  0,  0,  1,  0,  0,  0}, S = -0.27e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 1,  0, -2, -2, -2,  0,  0,  0}, S = -0.26e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 1,  0,  0,  0, -1,  0,  0,  0}, S = -0.25e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 1,  0,  2,  0,  1,  0,  0,  0}, S = 0.22e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 2,  0,  0, -2,  0,  0,  0,  0}, S = -0.21e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 2,  0, -2,  0, -1,  0,  0,  0}, S = 0.20e-6, C = 0.00e-6 },

                /* 21-25 */
                new() { Nfa = new int[] { 0,  0,  2,  2,  2,  0,  0,  0}, S = 0.17e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 2,  0,  2,  0,  2,  0,  0,  0}, S = 0.13e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 2,  0,  0,  0,  0,  0,  0,  0}, S = -0.13e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 1,  0,  2, -2,  2,  0,  0,  0}, S = -0.12e-6, C = 0.00e-6 },
                new() { Nfa = new int[] { 0,  0,  2,  0,  0,  0,  0,  0}, S = -0.11e-6, C = 0.00e-6 }
            };

            /* Terms of order t^3 */
            S06_TERM[] s3 = {
                /* 1-4 */
                new() { Nfa = new int[] { 0,  0,  0,  0,  1,  0,  0,  0}, S = 0.30e-6, C = -23.42e-6 },
                new() { Nfa = new int[] { 0,  0,  2, -2,  2,  0,  0,  0}, S = -0.03e-6, C = -1.46e-6 },
                new() { Nfa = new int[] { 0,  0,  2,  0,  2,  0,  0,  0}, S = -0.01e-6, C = -0.25e-6 },
                new() { Nfa = new int[] { 0,  0,  0,  0,  2,  0,  0,  0}, S = 0.00e-6, C = 0.23e-6 }
            };

            /* Terms of order t^4 */
            S06_TERM[] s4 = {
                /* 1-1 */
                new() { Nfa = new int[] { 0,  0,  0,  0,  1,  0,  0,  0}, S = -0.26e-6, C = -0.01e-6 }
            };

            /* Fundamental Arguments (from IERS Conventions 2003) */
            fa[0] = Fal03(t);
            fa[1] = Falp03(t);
            fa[2] = Faf03(t);
            fa[3] = Fad03(t);
            fa[4] = Faom03(t);
            fa[5] = Fave03(t);
            fa[6] = Fae03(t);
            fa[7] = Fapa03(t);

            /* Evaluate s. */
            w0 = sp[0];
            w1 = sp[1];
            w2 = sp[2];
            w3 = sp[3];
            w4 = sp[4];
            w5 = sp[5];

            for (i = s0.Length - 1; i >= 0; i--) {
                a = 0.0;
                for (j = 0; j < 8; j++) {
                    a += (double)s0[i].Nfa[j] * fa[j];
                }
                w0 += s0[i].S * Sin(a) + s0[i].C * Cos(a);
            }

            for (i = s1.Length - 1; i >= 0; i--) {
                a = 0.0;
                for (j = 0; j < 8; j++) {
                    a += (double)s1[i].Nfa[j] * fa[j];
                }
                w1 += s1[i].S * Sin(a) + s1[i].C * Cos(a);
            }

            for (i = s2.Length - 1; i >= 0; i--) {
                a = 0.0;
                for (j = 0; j < 8; j++) {
                    a += (double)s2[i].Nfa[j] * fa[j];
                }
                w2 += s2[i].S * Sin(a) + s2[i].C * Cos(a);
            }

            for (i = s3.Length - 1; i >= 0; i--) {
                a = 0.0;
                for (j = 0; j < 8; j++) {
                    a += (double)s3[i].Nfa[j] * fa[j];
                }
                w3 += s3[i].S * Sin(a) + s3[i].C * Cos(a);
            }

            for (i = s4.Length - 1; i >= 0; i--) {
                a = 0.0;
                for (j = 0; j < 8; j++) {
                    a += (double)s4[i].Nfa[j] * fa[j];
                }
                w4 += s4[i].S * Sin(a) + s4[i].C * Cos(a);
            }

            s = (w0 +
                (w1 +
                (w2 +
                (w3 +
                (w4 +
                 w5 * t) * t) * t) * t) * t) * DAS2R - x*y/2.0;

            return s;
        }
    }
}
