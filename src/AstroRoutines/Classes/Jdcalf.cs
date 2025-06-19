namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Julian Date to Gregorian Calendar, expressed in a form convenient
        /// for formatting messages:  rounded to a specified precision.
        /// </summary>
        /// <param name="ndp">number of decimal places of days in fraction</param>
        /// <param name="dj1">dj1+dj2 = Julian Date</param>
        /// <param name="dj2">dj1+dj2 = Julian Date</param>
        /// <param name="iymdf">year, month, day, fraction in Gregorian calendar</param>
        /// <returns>status: -1 = date out of range, 0 = OK, +1 = ndp not 0-9 (interpreted as 0)</returns>
        public static int Jdcalf(int ndp, double dj1, double dj2, ref int[] iymdf)
        {
            int j, js;
            double denom, d1, d2, f1, f2, d, djd, f, rf;

            /* Denominator of fraction (e.g. 100 for 2 decimal places). */
            if ((ndp >= 0) && (ndp <= 9))
            {
                j = 0;
                denom = Pow(10.0, ndp);
            }
            else
            {
                j = 1;
                denom = 1.0;
            }

            /* Copy the date, big then small. */
            if (Abs(dj1) >= Abs(dj2))
            {
                d1 = dj1;
                d2 = dj2;
            }
            else
            {
                d1 = dj2;
                d2 = dj1;
            }

            /* Realign to midnight (without rounding error). */
            d1 -= 0.5;

            /* Separate day and fraction (as precisely as possible). */
            d = Round(d1);
            f1 = d1 - d;
            djd = d;
            d = Round(d2);
            f2 = d2 - d;
            djd += d;
            d = Round(f1 + f2);
            f = (f1 - d) + f2;
            if (f < 0.0)
            {
                f += 1.0;
                d -= 1.0;
            }
            djd += d;

            /* Round the total fraction to the specified number of places. */
            rf = Round(f * denom) / denom;

            /* Re-align to noon. */
            djd += 0.5;

            /* Convert to Gregorian calendar. */
            js = Jd2cal(djd, rf, out iymdf[0], out iymdf[1], out iymdf[2], out f);
            if (js == 0)
            {
                iymdf[3] = (int)Round(f * denom);
            }
            else
            {
                j = js;
            }

            /* Return the status. */
            return j;

            /* Finished. */
        }
    }
}
