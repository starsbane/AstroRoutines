using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Convert B1950.0 FK4 star catalog data to J2000.0 FK5.
        /// </summary>
        /// <param name="r1950">B1950.0 RA,Dec (rad)</param>
        /// <param name="d1950">B1950.0 RA,Dec (rad)</param>
        /// <param name="dr1950">B1950.0 proper motions (rad/trop.yr)</param>
        /// <param name="dd1950">B1950.0 proper motions (rad/trop.yr)</param>
        /// <param name="p1950">parallax (arcsec)</param>
        /// <param name="v1950">radial velocity (km/s, +ve = moving away)</param>
        /// <param name="r2000">J2000.0 RA,Dec (rad)</param>
        /// <param name="d2000">J2000.0 RA,Dec (rad)</param>
        /// <param name="dr2000">J2000.0 proper motions (rad/Jul.yr)</param>
        /// <param name="dd2000">J2000.0 proper motions (rad/Jul.yr)</param>
        /// <param name="p2000">parallax (arcsec)</param>
        /// <param name="v2000">radial velocity (km/s, +ve = moving away)</param>
        public static void Fk425(double r1950, double d1950,
            double dr1950, double dd1950,
            double p1950, double v1950,
            out double r2000, out double d2000,
            out double dr2000, out double dd2000,
            out double p2000, out double v2000)
        {
            /* Radians per year to arcsec per century */
            const double PMF = 100.0 * DR2AS;

            /* Small number to avoid arithmetic problems */
            const double TINY = 1e-30;

            /* Miscellaneous */
            int i, j, k, l;

            /* Pv-vectors */
            double[,] r0 = new double[2, 3], pv1 = new double[2, 3], pv2 = new double[2, 3];

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

            /* 3x2 matrix of pv-vectors (cf. Seidelmann 3.591-4, matrix M) */
            double[,,,] em = {
                {
                    { { +0.9999256782,     -0.0111820611,     -0.0048579477     },
                        { +0.00000242395018, -0.00000002710663, -0.00000001177656 } },

                    { { +0.0111820610,     +0.9999374784,     -0.0000271765     },
                        { +0.00000002710663, +0.00000242397878, -0.00000000006587 } },

                    { { +0.0048579479,     -0.0000271474,     +0.9999881997,    },
                        { +0.00000001177656, -0.00000000006582, +0.00000242410173 } }
                },

                {
                    { { -0.000551,         -0.238565,         +0.435739        },
                        { +0.99994704,       -0.01118251,       -0.00485767       } },

                    { { +0.238514,         -0.002667,         -0.008541        },
                        { +0.01118251,       +0.99995883,       -0.00002718       } },

                    { { -0.435623,         +0.012254,         +0.002117         },
                        { +0.00485767,       -0.00002714,       +1.00000956       } }
                }
            };

            /* Pick up the input arguments. */
            var r = r1950;
            var d = d1950;
            var ur = dr1950 * PMF;
            var ud = dd1950 * PMF;
            var px = p1950;
            var rv = v1950;

            /* Convert to pv-vector (normalized). */
            var pxvf = px * VF;
            var w = rv * pxvf;
            S2pv(r, d, 1.0, ur, ud, w, ref r0);

            /* Allow for E-terms (cf. Seidelmann 3.591-2). */
            Pvmpv(r0, a, ref pv1);
            var pv2Row0 = pv2.GetRow(0);
            Sxp(Pdp(r0.GetRow(0), a.GetRow(0)), r0.GetRow(0), ref pv2Row0);
            pv2.SetRow(0, pv2Row0);

            var pv2Row1 = pv2.GetRow(1);
            Sxp(Pdp(r0.GetRow(0), a.GetRow(1)), r0.GetRow(0), ref pv2Row1);
            pv2.SetRow(1, pv2Row1);
            Pvppv(pv1, pv2, ref pv1);


            /* Convert pv-vector to Fricke system (cf. Seidelmann 3.591-3). */
            for (i = 0; i < 2; i++)
            {
                for (j = 0; j < 3; j++)
                {
                    w = 0.0;
                    for (k = 0; k < 2; k++)
                    {
                        for (l = 0; l < 3; l++)
                        {
                            w += em[i, j, k, l] * pv1[k, l];
                        }
                    }
                    pv2[i, j] = w;
                }
            }

            /* Revert to catalog form. */
            Pv2s(pv2, out r, out d, out w, out ur, out ud, out var rd);
            if ( px > TINY ) {
                rv = rd/pxvf;
                px = px/w;
            }

            /* Return results. */
            r2000 = Anp(r);
            d2000 = d;
            dr2000 = ur / PMF;
            dd2000 = ud / PMF;
            p2000 = px;
            v2000 = rv;
        }
    }
}
