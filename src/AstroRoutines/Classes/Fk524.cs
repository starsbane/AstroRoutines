using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Convert J2000.0 FK5 star catalog data to B1950.0 FK4.
        /// </summary>
        /// <param name="r2000">J2000.0 RA,Dec (rad)</param>
        /// <param name="d2000">J2000.0 RA,Dec (rad)</param>
        /// <param name="dr2000">J2000.0 proper motions (rad/Jul.yr)</param>
        /// <param name="dd2000">J2000.0 proper motions (rad/Jul.yr)</param>
        /// <param name="p2000">parallax (arcsec)</param>
        /// <param name="v2000">radial velocity (km/s, +ve = moving away)</param>
        /// <param name="r1950">B1950.0 RA,Dec (rad)</param>
        /// <param name="d1950">B1950.0 RA,Dec (rad)</param>
        /// <param name="dr1950">B1950.0 proper motions (rad/trop.yr)</param>
        /// <param name="dd1950">B1950.0 proper motions (rad/trop.yr)</param>
        /// <param name="p1950">parallax (arcsec)</param>
        /// <param name="v1950">radial velocity (km/s, +ve = moving away)</param>
        public static void Fk524(double r2000, double d2000,
            double dr2000, double dd2000,
            double p2000, double v2000,
            out double r1950, out double d1950,
            out double dr1950, out double dd1950,
            out double p1950, out double v1950)
        {
            /* Radians per year to arcsec per century */
            const double PMF = 100.0 * DR2AS;

            /* Small number to avoid arithmetic problems */
            const double TINY = 1e-30;

            /* Miscellaneous */
            int i, j, k, l;

            /* Vectors, p and pv */
            double[,] r0 = new double[2, 3], r1 = new double[2, 3];
            double[] p1 = new double[3], p2 = new double[3];
            var pv = new double[2, 3];

            /*
             ** CANONICAL CONSTANTS (Seidelmann 1992)
             */

            /* Km per sec to au per tropical century */
            /* = 86400 * 36524.2198782 / 149597870.7 */
            const double VF = 21.095;

            /* Constant pv-vector (cf. Seidelmann 3.591-2, vectors A and Adot) */
            double[,] a = {
                { -1.62557e-6, -0.31919e-6, -0.13843e-6 },
                { +1.245e-3,   -1.580e-3,   -0.659e-3   }
            };

            /* 3x2 matrix of pv-vectors (cf. Seidelmann 3.592-1, matrix M^-1) */
            double[,,,] em = {
                {
                    { { +0.9999256795,     +0.0111814828,     +0.0048590039,    },
                        { -0.00000242389840, -0.00000002710544, -0.00000001177742 } },

                    { { -0.0111814828,     +0.9999374849,     -0.0000271771,    },
                        { +0.00000002710544, -0.00000242392702, +0.00000000006585 } },

                    { { -0.0048590040,     -0.0000271557,     +0.9999881946,    },
                        { +0.00000001177742, +0.00000000006585, -0.00000242404995 } }
                },

                {
                    { { -0.000551,         +0.238509,         -0.435614,        },
                        { +0.99990432,       +0.01118145,       +0.00485852       } },

                    { { -0.238560,         -0.002667,         +0.012254,        },
                        { -0.01118145,       +0.99991613,       -0.00002717       } },

                    { { +0.435730,         -0.008541,         +0.002117,        },
                        { -0.00485852,       -0.00002716,       +0.99996684       } }
                }
            };

            /* Pick up J2000 data (units of radians and arcsec/JC). */
            var r = r2000;
            var d = d2000;
            var ur = dr2000 * PMF;
            var ud = dd2000 * PMF;
            var px = p2000;
            var rv = v2000;

            /* Convert to pv-vector (normalized). */
            var pxvf = px * VF;
            var w = rv * pxvf;
            S2pv(r, d, 1.0, ur, ud, w, ref r0);

            /* Convert pv-vector to Bessel-Newcomb system (cf. Seidelmann 3.592-1). */
            for (i = 0; i < 2; i++)
            {
                for (j = 0; j < 3; j++)
                {
                    w = 0.0;
                    for (k = 0; k < 2; k++)
                    {
                        for (l = 0; l < 3; l++)
                        {
                            w += em[i, j, k, l] * r0[k, l];
                        }
                    }
                    r1[i, j] = w;
                }
            }

            /* Apply E-terms (equivalent to Seidelmann 3.592-3, one iteration). */

            /* Direction. */
            w = Pm(r1.GetRow(0));
            Sxp(Pdp(r1.GetRow(0),a.GetRow(0)), r1.GetRow(0), ref p1);
            Sxp(w, a.GetRow(0), ref p2);
            Pmp(p2, p1, ref p1);
            Ppp(r1.GetRow(0), p1, ref p1);


            /* Recompute the velocity. */
            w = Pm(p1);

            /* Direction. */
            Sxp(Pdp(r1.GetRow(0),a.GetRow(0)), r1.GetRow(0), ref p1);
            Sxp(w, a.GetRow(0), ref p2);
            Pmp(p2, p1, ref p1);
            var pvRow0 = pv.GetRow(0);
            Ppp(r1.GetRow(0), p1, ref pvRow0);
            pv.SetRow(0, pvRow0);

            /* Derivative. */
            Sxp(Pdp(r1.GetRow(0),a.GetRow(1)), pv.GetRow(0), ref p1);
            Sxp(w, a.GetRow(1), ref p2);
            Pmp(p2, p1, ref p1);
            var pvRow1 = pv.GetRow(1);
            Ppp(r1.GetRow(1), p1, ref pvRow1);
            pv.SetRow(1, pvRow1);

            /* Revert to catalog form. */
            Pv2s(pv, out r, out d, out w, out ur, out ud, out var rd);
            if ( px > TINY ) {
                rv = rd/pxvf;
                px = px/w;
            }

            /* Return results. */
            r1950 = Anp(r);
            d1950 = d;
            dr1950 = ur / PMF;
            dd1950 = ud / PMF;
            p1950 = px;
            v1950 = rv;
        }
    }
}
