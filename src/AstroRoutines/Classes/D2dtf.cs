// D2dtf.cs
using System;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Format for output a 2-part Julian Date (or in the case of UTC a
        /// quasi-JD form that includes special provision for leap seconds).
        /// </summary>
        /// <param name="scale">time scale ID (Note 1)</param>
        /// <param name="ndp">resolution (Note 2)</param>
        /// <param name="d1">time as a 2-part Julian Date (Notes 3,4)</param>
        /// <param name="d2">time as a 2-part Julian Date (Notes 3,4)</param>
        /// <param name="iy">year, month, day in Gregorian calendar (Note 5)</param>
        /// <param name="im">year, month, day in Gregorian calendar (Note 5)</param>
        /// <param name="id">year, month, day in Gregorian calendar (Note 5)</param>
        /// <param name="ihmsf">hours, minutes, seconds, fraction (Note 1)</param>
        /// <returns>status: +1 = dubious year (Note 5)
        /// 0 = OK
        /// -1 = unacceptable date (Note 6)</returns>
        public static int D2dtf(string scale, int ndp, double d1, double d2,
                     ref int iy, ref int im, ref int id, int[] ihmsf)
        {
            int leap;
            char s;
            int iy1, im1, id1, js, iy2, im2, id2;
            int[] ihmsf1 = new int[4];
            int i;
            double a1, b1, fd, dat0, dat12, w, dat24, dleap;

            /* The two-part JD. */
            a1 = d1;
            b1 = d2;

            /* Provisional calendar date. */
            js = Jd2cal(a1, b1, out iy1, out im1, out id1, out fd);
            if (js != 0) return -1;

            /* Is this a leap second day? */
            leap = 0;
            if (scale == "UTC")
            {
                /* TAI-UTC at 0h today. */
                js = Dat(iy1, im1, id1, 0.0, out dat0);
                if (js < 0) return -1;

                /* TAI-UTC at 12h today (to detect drift). */
                js = Dat(iy1, im1, id1, 0.5, out dat12);
                if (js < 0) return -1;

                /* TAI-UTC at 0h tomorrow (to detect jumps). */
                js = Jd2cal(a1 + 1.5, b1 - fd, out iy2, out im2, out id2, out w);
                if (js != 0) return -1;
                js = Dat(iy2, im2, id2, 0.0, out dat24);
                if (js < 0) return -1;

                /* Any sudden change in TAI-UTC (seconds). */
                dleap = dat24 - (2.0 * dat12 - dat0);

                /* If leap second day, scale the fraction of a day into SI. */
                leap = (Math.Abs(dleap) > 0.5) ? 1 : 0;
                if (leap != 0) fd += fd * dleap / DAYSEC;
            }

            /* Provisional time of day. */
            D2tf(ndp, fd, out s, ref ihmsf1);

            /* Has the (rounded) time gone past 24h? */
            if (ihmsf1[0] > 23)
            {
                /* Yes.  We probably need tomorrow's calendar date. */
                js = Jd2cal(a1 + 1.5, b1 - fd, out iy2, out im2, out id2, out w);
                if (js != 0) return -1;

                /* Is today a leap second day? */
                if (leap == 0)
                {
                    /* No.  Use 0h tomorrow. */
                    iy1 = iy2;
                    im1 = im2;
                    id1 = id2;
                    ihmsf1[0] = 0;
                    ihmsf1[1] = 0;
                    ihmsf1[2] = 0;
                }
                else
                {
                    /* Yes.  Are we past the leap second itself? */
                    if (ihmsf1[2] > 0)
                    {
                        /* Yes.  Use tomorrow but allow for the leap second. */
                        iy1 = iy2;
                        im1 = im2;
                        id1 = id2;
                        ihmsf1[0] = 0;
                        ihmsf1[1] = 0;
                        ihmsf1[2] = 0;
                    }
                    else
                    {
                        /* No.  Use 23 59 60... today. */
                        ihmsf1[0] = 23;
                        ihmsf1[1] = 59;
                        ihmsf1[2] = 60;
                    }

                    /* If rounding to 10s or coarser always go up to new day. */
                    if (ndp < 0 && ihmsf1[2] == 60)
                    {
                        iy1 = iy2;
                        im1 = im2;
                        id1 = id2;
                        ihmsf1[0] = 0;
                        ihmsf1[1] = 0;
                        ihmsf1[2] = 0;
                    }
                }
            }

            /* Results. */
            iy = iy1;
            im = im1;
            id = id1;
            for (i = 0; i < 4; i++)
            {
                ihmsf[i] = ihmsf1[i];
            }

            /* Status. */
            return js;

            /* Finished. */
        }
    }
}
