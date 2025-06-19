// D2tf.cs
using System;

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
            double rs, rm, rh, a, w, ah, am, _as, af;

            /* Handle sign. */
            sign = (days >= 0.0) ? '+' : '-';

            /* Interval in seconds. */
            a = DAYSEC * Math.Abs(days);

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
            rm = rs * 60.0;
            rh = rm * 60.0;

            /* Round the interval and express in resolution units. */
            a = Math.Round(rs * a);

            /* Break into fields. */
            ah = a / rh;
            ah = Math.Truncate(ah);
            a -= ah * rh;
            am = a / rm;
            am = Math.Truncate(am);
            a -= am * rm;
            _as = a / rs;
            _as = Math.Truncate(_as);
            af = a - _as * rs;

            /* Return results. */
            ihmsf[0] = (int)ah;
            ihmsf[1] = (int)am;
            ihmsf[2] = (int)_as;
            ihmsf[3] = (int)af;

            /* Finished. */
        }
    }
}
