// D2tf.cs

using System;
using static AstroRoutines.Constants;

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
// Copyright © International Astronomical Union Standards of Fundamental Astronomy (http://www.iausofa.org).
//
namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Decompose days to hours, minutes, seconds, fraction.
        /// </summary>
        /// <param name="ndp">resolution (Note 1)</param>
        /// <param name="days">interval in days</param>
        /// <param name="sign">'+' or '-'</param>
        /// <param name="ihmsf">hours, minutes, seconds, fraction</param>
        public static void D2tf(int ndp, double days, out char sign, ref int[] ihmsf)
        {
            int nrs, n;
            double rs, w;

            /* Handle sign. */
            sign = (days >= 0.0) ? '+' : '-';

            /* Interval in seconds. */
            var a = DAYSEC * Math.Abs(days);

            /* Pre-round if resolution coarser than 1s (then pretend ndp=1). */
            if (ndp < 0)
            {
                nrs = 1;
                for (n = 1; n <= -ndp; n++)
                {
                    nrs *= (n == 2 || n == 4) ? 6 : 10;
                }
                rs = (double)nrs;
                w = a / rs;
                a = rs * Math.Round(w);
            }

            /* Express the unit of each field in resolution units. */
            nrs = 1;
            for (n = 1; n <= ndp; n++)
            {
                nrs *= 10;
            }
            rs = (double)nrs;
            var rm = rs * 60.0;
            var rh = rm * 60.0;

            /* Round the interval and express in resolution units. */
            a = Math.Round(rs * a);

            /* Break into fields. */
            var ah = a / rh;
            ah = Math.Truncate(ah);
            a -= ah * rh;
            var am = a / rm;
            am = Math.Truncate(am);
            a -= am * rm;
            var _as = a / rs;
            _as = Math.Truncate(_as);
            var af = a - _as * rs;

            /* Return results. */
            ihmsf[0] = (int)ah;
            ihmsf[1] = (int)am;
            ihmsf[2] = (int)_as;
            ihmsf[3] = (int)af;

            /* Finished. */
        }
    }
}
