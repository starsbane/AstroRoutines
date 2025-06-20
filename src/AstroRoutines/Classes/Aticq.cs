using static System.Math;

//
// Copyright 2025 Alex Man (Starsbane)
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// Software Routines from the IAU SOFA Collection were used. 
// Copyright � International Astronomical Union Standards of Fundamental Astronomy (http://www.iausofa.org).
//
namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Quick CIRS RA,Dec to ICRS astrometric place, given the star-independent astrometry parameters.
        /// </summary>
        /// <param name="ri">CIRS RA (radians)</param>
        /// <param name="di">CIRS Dec (radians)</param>
        /// <param name="astrom">star-independent astrometry parameters</param>
        /// <param name="rc">ICRS astrometric RA (radians)</param>
        /// <param name="dc">ICRS astrometric Dec (radians)</param>
        public static void Aticq(double ri, double di, ref ASTROM astrom,
            out double rc, out double dc)
        {
            int j, i;
            var pi = new double[3];
            var ppr = new double[3];
            var pnat = new double[3];
            var pco = new double[3];
            double w;
            var d = new double[3];
            var before = new double[3];
            double r2, r;
            var after = new double[3];

            /* CIRS RA,Dec to Cartesian. */
            S2c(ri, di, ref pi);

            /* Bias-precession-nutation, giving GCRS proper direction. */
            Trxp(astrom.bpn, pi, ref ppr);

            /* Aberration, giving GCRS natural direction. */
            Zp(ref d);
            for (j = 0; j < 2; j++)
            {
                r2 = 0.0;
                for (i = 0; i < 3; i++)
                {
                    w = ppr[i] - d[i];
                    before[i] = w;
                    r2 += w * w;
                }
                r = Sqrt(r2);
                for (i = 0; i < 3; i++)
                {
                    before[i] /= r;
                }
                Ab(before, astrom.v, astrom.em, astrom.bm1, ref after);
                r2 = 0.0;
                for (i = 0; i < 3; i++)
                {
                    d[i] = after[i] - before[i];
                    w = ppr[i] - d[i];
                    pnat[i] = w;
                    r2 += w * w;
                }
                r = Sqrt(r2);
                for (i = 0; i < 3; i++)
                {
                    pnat[i] /= r;
                }
            }

            /* Light deflection by the Sun, giving BCRS coordinate direction. */
            Zp(ref d);
            for (j = 0; j < 5; j++)
            {
                r2 = 0.0;
                for (i = 0; i < 3; i++)
                {
                    w = pnat[i] - d[i];
                    before[i] = w;
                    r2 += w * w;
                }
                r = Sqrt(r2);
                for (i = 0; i < 3; i++)
                {
                    before[i] /= r;
                }
                Ldsun(before, astrom.eh, astrom.em, ref after);
                r2 = 0.0;
                for (i = 0; i < 3; i++)
                {
                    d[i] = after[i] - before[i];
                    w = pnat[i] - d[i];
                    pco[i] = w;
                    r2 += w * w;
                }
                r = Sqrt(r2);
                for (i = 0; i < 3; i++)
                {
                    pco[i] /= r;
                }
            }

            /* ICRS astrometric RA,Dec. */
            C2s(pco, out w, out dc);
            rc = Anp(w);
        }
    }
}
