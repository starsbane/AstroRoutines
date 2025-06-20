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
        /// For a given UTC date, calculate Delta(AT) = TAI-UTC.
        /// </summary>
        /// <param name="iy">UTC: year (Notes 1 and 2)</param>
        /// <param name="im">month (Note 2)</param>
        /// <param name="id">day (Notes 2 and 3)</param>
        /// <param name="fd">fraction of day (Note 4)</param>
        /// <param name="deltat">TAI minus UTC, seconds</param>
        /// <returns>status (Note 5):
        /// 1 = dubious year (Note 1)
        /// 0 = OK
        /// -1 = bad year
        /// -2 = bad month
        /// -3 = bad day (Note 3)
        /// -4 = bad fraction (Note 4)
        /// -5 = internal error (Note 5)</returns>
        public static int Dat(int iy, int im, int id, double fd, out double deltat)
        {
            /* Release year for this version of iauDat */
            const int IYV = 2023;

            /* Reference dates (MJD) and drift rates (s/day), pre leap seconds */
            var drift = new double[,] {
                { 37300.0, 0.0012960 },
                { 37300.0, 0.0012960 },
                { 37300.0, 0.0012960 },
                { 37665.0, 0.0011232 },
                { 37665.0, 0.0011232 },
                { 38761.0, 0.0012960 },
                { 38761.0, 0.0012960 },
                { 38761.0, 0.0012960 },
                { 38761.0, 0.0012960 },
                { 38761.0, 0.0012960 },
                { 38761.0, 0.0012960 },
                { 38761.0, 0.0012960 },
                { 39126.0, 0.0025920 },
                { 39126.0, 0.0025920 }
            };

            /* Number of Delta(AT) expressions before leap seconds were introduced */
            const int NERA1 = 14;

            /* Dates and Delta(AT)s */
            var changes = new[] {
                new { iyear = 1960, month = 1, delat = 1.4178180 },
                new { iyear = 1961, month = 1, delat = 1.4228180 },
                new { iyear = 1961, month = 8, delat = 1.3728180 },
                new { iyear = 1962, month = 1, delat = 1.8458580 },
                new { iyear = 1963, month = 11, delat = 1.9458580 },
                new { iyear = 1964, month = 1, delat = 3.2401300 },
                new { iyear = 1964, month = 4, delat = 3.3401300 },
                new { iyear = 1964, month = 9, delat = 3.4401300 },
                new { iyear = 1965, month = 1, delat = 3.5401300 },
                new { iyear = 1965, month = 3, delat = 3.6401300 },
                new { iyear = 1965, month = 7, delat = 3.7401300 },
                new { iyear = 1965, month = 9, delat = 3.8401300 },
                new { iyear = 1966, month = 1, delat = 4.3131700 },
                new { iyear = 1968, month = 2, delat = 4.2131700 },
                new { iyear = 1972, month = 1, delat = 10.0 },
                new { iyear = 1972, month = 7, delat = 11.0 },
                new { iyear = 1973, month = 1, delat = 12.0 },
                new { iyear = 1974, month = 1, delat = 13.0 },
                new { iyear = 1975, month = 1, delat = 14.0 },
                new { iyear = 1976, month = 1, delat = 15.0 },
                new { iyear = 1977, month = 1, delat = 16.0 },
                new { iyear = 1978, month = 1, delat = 17.0 },
                new { iyear = 1979, month = 1, delat = 18.0 },
                new { iyear = 1980, month = 1, delat = 19.0 },
                new { iyear = 1981, month = 7, delat = 20.0 },
                new { iyear = 1982, month = 7, delat = 21.0 },
                new { iyear = 1983, month = 7, delat = 22.0 },
                new { iyear = 1985, month = 7, delat = 23.0 },
                new { iyear = 1988, month = 1, delat = 24.0 },
                new { iyear = 1990, month = 1, delat = 25.0 },
                new { iyear = 1991, month = 1, delat = 26.0 },
                new { iyear = 1992, month = 7, delat = 27.0 },
                new { iyear = 1993, month = 7, delat = 28.0 },
                new { iyear = 1994, month = 7, delat = 29.0 },
                new { iyear = 1996, month = 1, delat = 30.0 },
                new { iyear = 1997, month = 7, delat = 31.0 },
                new { iyear = 1999, month = 1, delat = 32.0 },
                new { iyear = 2006, month = 1, delat = 33.0 },
                new { iyear = 2009, month = 1, delat = 34.0 },
                new { iyear = 2012, month = 7, delat = 35.0 },
                new { iyear = 2015, month = 7, delat = 36.0 },
                new { iyear = 2017, month = 1, delat = 37.0 }
            };

            /* Number of Delta(AT) changes */
            const int NDAT = 42;

            /* Miscellaneous local variables */
            int i;
            double da, djm0;

            /* Initialize the result to zero. */
            deltat = da = 0.0;

            /* If invalid fraction of a day, set error status and give up. */
            if (fd < 0.0 || fd > 1.0) return -4;

            /* Convert the date into an MJD. */
            var j = Cal2jd(iy, im, id, out djm0, out var djm);

            /* If invalid year, month, or day, give up. */
            if (j < 0) return j;

            /* If pre-UTC year, set warning status and give up. */
            if (iy < changes[0].iyear) return 1;

            /* If suspiciously late year, set warning status but proceed. */
            if (iy > IYV + 5) j = 1;

            /* Combine year and month to form a date-ordered integer... */
            var m = 12 * iy + im;

            /* ...and use it to find the preceding table entry. */
            for (i = NDAT - 1; i >= 0; i--)
            {
                if (m >= (12 * changes[i].iyear + changes[i].month)) break;
            }

            /* Prevent underflow warnings. */
            if (i < 0) return -5;

            /* Get the Delta(AT). */
            da = changes[i].delat;

            /* If pre-1972, adjust for drift. */
            if (i < NERA1) da += (djm + fd - drift[i, 0]) * drift[i, 1];

            /* Return the Delta(AT) value. */
            deltat = da;

            /* Return the status. */
            return j;

            /* Finished. */
        }
    }
}
