using static System.Math;
using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
		internal struct S00_TERM 
		{
			public int[] nfa { get; set; }      /* coefficients of l,l',F,D,Om,LVe,LE,pA */
			public double s { get; set; }
			public double c { get; set; }       /* sine and cosine coefficients */
		}

		/// <summary>
		/// The CIO locator s, positioning the Celestial Intermediate Origin on the equator of the Celestial Intermediate Pole.
		/// </summary>
		/// <param name="date1">TT as a 2-part Julian Date</param>
		/// <param name="date2">TT as a 2-part Julian Date</param>
		/// <param name="x">CIP x-coordinate</param>
		/// <param name="y">CIP y-coordinate</param>
		/// <returns>The CIO locator s in radians</returns>
		public static double S00(double date1, double date2, double x, double y)
		{
			/* Time since J2000.0, in Julian centuries */
			double t;

			/* Miscellaneous */
			int i, j;
			double a, w0, w1, w2, w3, w4, w5;

			/* Fundamental arguments */
			var fa = new double[8];

			/* Returned value */
			double s;

			/* Polynomial coefficients */
			double[] sp = {
				/* 1-6 */
					94.00e-6,
				3808.35e-6,
				-119.94e-6,
			-72574.09e-6,
				27.70e-6,
				15.61e-6
			};

			/* Terms of order t^0 */
			S00_TERM[] s0 = {
				/* 1-10 */
				new S00_TERM() { nfa = new[] { 0,  0,  0,  0,  1,  0,  0,  0}, s = -2640.73e-6, c = 0.39e-6 },
				new S00_TERM() { nfa = new[] { 0,  0,  0,  0,  2,  0,  0,  0}, s = -63.53e-6, c = 0.02e-6 },
				new S00_TERM() { nfa = new[] { 0,  0,  2, -2,  3,  0,  0,  0}, s = -11.75e-6, c = -0.01e-6 },
				new S00_TERM() { nfa = new[] { 0,  0,  2, -2,  1,  0,  0,  0}, s = -11.21e-6, c = -0.01e-6 },
				new S00_TERM() { nfa = new[] { 0,  0,  2, -2,  2,  0,  0,  0}, s = 4.57e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 0,  0,  2,  0,  3,  0,  0,  0}, s = -2.02e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 0,  0,  2,  0,  1,  0,  0,  0}, s = -1.98e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 0,  0,  0,  0,  3,  0,  0,  0}, s = 1.72e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 0,  1,  0,  0,  1,  0,  0,  0}, s = 1.41e-6, c = 0.01e-6 },
				new S00_TERM() { nfa = new[] { 0,  1,  0,  0, -1,  0,  0,  0}, s = 1.26e-6, c = 0.01e-6 },

				/* 11-20 */
				new S00_TERM() { nfa = new[] { 1,  0,  0,  0, -1,  0,  0,  0}, s = 0.63e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 1,  0,  0,  0,  1,  0,  0,  0}, s = 0.63e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 0,  1,  2, -2,  3,  0,  0,  0}, s = -0.46e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 0,  1,  2, -2,  1,  0,  0,  0}, s = -0.45e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 0,  0,  4, -4,  4,  0,  0,  0}, s = -0.36e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 0,  0,  1, -1,  1, -8, 12,  0}, s = 0.24e-6, c = 0.12e-6 },
				new S00_TERM() { nfa = new[] { 0,  0,  2,  0,  0,  0,  0,  0}, s = -0.32e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 0,  0,  2,  0,  2,  0,  0,  0}, s = -0.28e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 1,  0,  2,  0,  3,  0,  0,  0}, s = -0.27e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 1,  0,  2,  0,  1,  0,  0,  0}, s = -0.26e-6, c = 0.00e-6 },

				/* 21-30 */
				new S00_TERM() { nfa = new[] { 0,  0,  2, -2,  0,  0,  0,  0}, s = 0.21e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 0,  1, -2,  2, -3,  0,  0,  0}, s = -0.19e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 0,  1, -2,  2, -1,  0,  0,  0}, s = -0.18e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 0,  0,  0,  0,  0,  8,-13, -1}, s = 0.10e-6, c = -0.05e-6 },
				new S00_TERM() { nfa = new[] { 0,  0,  0,  2,  0,  0,  0,  0}, s = -0.15e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 2,  0, -2,  0, -1,  0,  0,  0}, s = 0.14e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 0,  1,  2, -2,  2,  0,  0,  0}, s = 0.14e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 1,  0,  0, -2,  1,  0,  0,  0}, s = -0.14e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 1,  0,  0, -2, -1,  0,  0,  0}, s = -0.14e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 0,  0,  4, -2,  4,  0,  0,  0}, s = -0.13e-6, c = 0.00e-6 },

				/* 31-33 */
				new S00_TERM() { nfa = new[] { 0,  0,  2, -2,  4,  0,  0,  0}, s = 0.11e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 1,  0, -2,  0, -3,  0,  0,  0}, s = -0.11e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 1,  0, -2,  0, -1,  0,  0,  0}, s = -0.11e-6, c = 0.00e-6 }
			};

			/* Terms of order t^1 */
			S00_TERM[] s1 = {
				/* 1-3 */
				new S00_TERM() { nfa = new[] { 0,  0,  0,  0,  2,  0,  0,  0}, s = -0.07e-6, c = 3.57e-6 },
				new S00_TERM() { nfa = new[] { 0,  0,  0,  0,  1,  0,  0,  0}, s = 1.71e-6, c = -0.03e-6 },
				new S00_TERM() { nfa = new[] { 0,  0,  2, -2,  3,  0,  0,  0}, s = 0.00e-6, c = 0.48e-6 }
			};

			/* Terms of order t^2 */
			S00_TERM[] s2 = {
				/* 1-10 */
				new S00_TERM() { nfa = new[] { 0,  0,  0,  0,  1,  0,  0,  0}, s = 743.53e-6, c = -0.17e-6 },
				new S00_TERM() { nfa = new[] { 0,  0,  2, -2,  2,  0,  0,  0}, s = 56.91e-6, c = 0.06e-6 },
				new S00_TERM() { nfa = new[] { 0,  0,  2,  0,  2,  0,  0,  0}, s = 9.84e-6, c = -0.01e-6 },
				new S00_TERM() { nfa = new[] { 0,  0,  0,  0,  2,  0,  0,  0}, s = -8.85e-6, c = 0.01e-6 },
				new S00_TERM() { nfa = new[] { 0,  1,  0,  0,  0,  0,  0,  0}, s = -6.38e-6, c = -0.05e-6 },
				new S00_TERM() { nfa = new[] { 1,  0,  0,  0,  0,  0,  0,  0}, s = -3.07e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 0,  1,  2, -2,  2,  0,  0,  0}, s = 2.23e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 0,  0,  2,  0,  1,  0,  0,  0}, s = 1.67e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 1,  0,  2,  0,  2,  0,  0,  0}, s = 1.30e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 0,  1, -2,  2, -2,  0,  0,  0}, s = 0.93e-6, c = 0.00e-6 },

				/* 11-20 */
				new S00_TERM() { nfa = new[] { 1,  0,  0, -2,  0,  0,  0,  0}, s = 0.68e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 0,  0,  2, -2,  1,  0,  0,  0}, s = -0.55e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 1,  0, -2,  0, -2,  0,  0,  0}, s = 0.53e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 0,  0,  0,  2,  0,  0,  0,  0}, s = -0.27e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 1,  0,  0,  0,  1,  0,  0,  0}, s = -0.27e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 1,  0, -2, -2, -2,  0,  0,  0}, s = -0.26e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 1,  0,  0,  0, -1,  0,  0,  0}, s = -0.25e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 1,  0,  2,  0,  1,  0,  0,  0}, s = 0.22e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 2,  0,  0, -2,  0,  0,  0,  0}, s = -0.21e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 2,  0, -2,  0, -1,  0,  0,  0}, s = 0.20e-6, c = 0.00e-6 },

				/* 21-25 */
				new S00_TERM() { nfa = new[] { 0,  0,  2,  2,  2,  0,  0,  0}, s = 0.17e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 2,  0,  2,  0,  2,  0,  0,  0}, s = 0.13e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 2,  0,  0,  0,  0,  0,  0,  0}, s = -0.13e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 1,  0,  2, -2,  2,  0,  0,  0}, s = -0.12e-6, c = 0.00e-6 },
				new S00_TERM() { nfa = new[] { 0,  0,  2,  0,  0,  0,  0,  0}, s = -0.11e-6, c = 0.00e-6 }
			};

			/* Terms of order t^3 */
			S00_TERM[] s3 = {
				/* 1-4 */
				new S00_TERM() { nfa = new[] { 0,  0,  0,  0,  1,  0,  0,  0}, s = 0.30e-6, c = -23.51e-6 },
				new S00_TERM() { nfa = new[] { 0,  0,  2, -2,  2,  0,  0,  0}, s = -0.03e-6, c = -1.39e-6 },
				new S00_TERM() { nfa = new[] { 0,  0,  2,  0,  2,  0,  0,  0}, s = -0.01e-6, c = -0.24e-6 },
				new S00_TERM() { nfa = new[] { 0,  0,  0,  0,  2,  0,  0,  0}, s = 0.00e-6, c = 0.22e-6 }
			};

			/* Terms of order t^4 */
			S00_TERM[] s4 = {
				/* 1-1 */
				new S00_TERM() { nfa = new[] { 0,  0,  0,  0,  1,  0,  0,  0}, s = -0.26e-6, c = -0.01e-6 }
			};

			/* Interval between fundamental epoch J2000.0 and current date (JC). */
			t = ((date1 - DJ00) + date2) / DJC;

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
					a += (double)s0[i].nfa[j] * fa[j];
				}
				w0 += s0[i].s * Sin(a) + s0[i].c * Cos(a);
			}

			for (i = s1.Length - 1; i >= 0; i--) {
				a = 0.0;
				for (j = 0; j < 8; j++) {
					a += (double)s1[i].nfa[j] * fa[j];
				}
				w1 += s1[i].s * Sin(a) + s1[i].c * Cos(a);
			}

			for (i = s2.Length - 1; i >= 0; i--) {
				a = 0.0;
				for (j = 0; j < 8; j++) {
					a += (double)s2[i].nfa[j] * fa[j];
				}
				w2 += s2[i].s * Sin(a) + s2[i].c * Cos(a);
			}

			for (i = s3.Length - 1; i >= 0; i--) {
				a = 0.0;
				for (j = 0; j < 8; j++) {
					a += (double)s3[i].nfa[j] * fa[j];
				}
				w3 += s3[i].s * Sin(a) + s3[i].c * Cos(a);
			}

			for (i = s4.Length - 1; i >= 0; i--) {
				a = 0.0;
				for (j = 0; j < 8; j++) {
					a += (double)s4[i].nfa[j] * fa[j];
				}
				w4 += s4[i].s * Sin(a) + s4[i].c * Cos(a);
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
