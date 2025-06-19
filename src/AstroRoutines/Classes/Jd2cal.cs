namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Julian Date to Gregorian year, month, day, and fraction of a day.
        /// </summary>
        /// <param name="dj1">Julian Date</param>
        /// <param name="dj2">Julian Date</param>
        /// <param name="iy">year</param>
        /// <param name="im">month</param>
        /// <param name="id">day</param>
        /// <param name="fd">fraction of day</param>
        /// <returns>status: 0 = OK, -1 = unacceptable date</returns>
        public static int Jd2cal(double dj1, double dj2, out int iy, out int im, out int id, out double fd)
        {
            /* Minimum and maximum allowed JD */
            const double DJMIN = -68569.5;
            const double DJMAX = 1e9;

            long jd, i, l, n, k;
            double dj, f1, f2, d, s, cs, x, t, f;
            var v = new double[2];
            iy = im = id = 0;
            fd = 0;

            /* Verify date is acceptable. */
            dj = dj1 + dj2;
            if (dj < DJMIN || dj > DJMAX) return -1;

            /* Separate day and fraction (where -0.5 <= fraction < 0.5). */
            d = Round(dj1);
            f1 = dj1 - d;
            jd = (long)d;
            d = Round(dj2);
            f2 = dj2 - d;
            jd += (long)d;

            /* Compute f1+f2+0.5 using compensated summation (Klein 2006). */
            s = 0.5;
            cs = 0.0;
            v[0] = f1;
            v[1] = f2;
            for (i = 0; i < 2; i++)
            {
                x = v[i];
                t = s + x;
                cs += Abs(s) >= Abs(x) ? (s - t) + x : (x - t) + s;
                s = t;
                if (s >= 1.0)
                {
                    jd++;
                    s -= 1.0;
                }
            }
            f = s + cs;
            cs = f - s;

            /* Deal with negative f. */
            if (f < 0.0)
            {
                /* Compensated summation: assume that |s| <= 1.0. */
                f = s + 1.0;
                cs += (1.0 - f) + s;
                s = f;
                f = s + cs;
                cs = f - s;
                jd--;
            }

            /* Deal with f that is 1.0 or more (when rounded to double). */
            if ((f - 1.0) >= -double.Epsilon / 4.0)
            {
                /* Compensated summation: assume that |s| <= 1.0. */
                t = s - 1.0;
                cs += (s - t) - 1.0;
                s = t;
                f = s + cs;
                if (-double.Epsilon / 2.0 < f)
                {
                    jd++;
                    f = Max(f, 0.0);
                }
            }

            /* Express day in Gregorian calendar. */
            l = jd + 68569L;
            n = (4L * l) / 146097L;
            l -= (146097L * n + 3L) / 4L;
            i = (4000L * (l + 1L)) / 1461001L;
            l -= (1461L * i) / 4L - 31L;
            k = (80L * l) / 2447L;
            id = (int)(l - (2447L * k) / 80L);
            l = k / 11L;
            im = (int)(k + 2L - 12L * l);
            iy = (int)(100L * (n - 49L) + i + l);
            fd = f;

            /* Success. */
            return 0;

            /* Finished. */
        }
    }
}
