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
// Copyright � International Astronomical Union Standards of Fundamental Astronomy (http://www.iausofa.org).
//
namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Encode date and time fields into 2-part Julian Date (or in the case
        /// of UTC a quasi-JD form that includes special provision for leap
        /// seconds).
        /// </summary>
        /// <param name="scale">time scale ID (Note 1)</param>
        /// <param name="iy">year in Gregorian calendar (Note 2)</param>
        /// <param name="im">month in Gregorian calendar (Note 2)</param>
        /// <param name="id">day in Gregorian calendar (Note 2)</param>
        /// <param name="ihr">hour</param>
        /// <param name="imn">minute</param>
        /// <param name="sec">seconds</param>
        /// <param name="d1">2-part Julian Date (Notes 3,4)</param>
        /// <param name="d2">2-part Julian Date (Notes 3,4)</param>
        /// <returns>
        /// status: +3 = both of next two
        ///         +2 = time is after end of day (Note 5)
        ///         +1 = dubious year (Note 6)
        ///          0 = OK
        ///         -1 = bad year
        ///         -2 = bad month
        ///         -3 = bad day
        ///         -4 = bad hour
        ///         -5 = bad minute
        ///         -6 = bad second (&lt;0)
        /// </returns>
        public static int Dtf2d(string scale, int iy, int im, int id,
                               int ihr, int imn, double sec, ref double d1, ref double d2)
        {
            double dleap;

            /* Today's Julian Day Number. */
            var js = Cal2jd(iy, im, id, out var dj, out var w);
            if (js != 0) return js;
            dj += w;

            /* Day length and final minute length in seconds (provisional). */
            var day = DAYSEC;
            var seclim = 60.0;

            /* Deal with the UTC leap second case. */
            if (scale == "UTC")
            {
                /* TAI-UTC at 0h today. */
                js = Dat(iy, im, id, 0.0, out var dat0);
                if (js < 0) return js;

                /* TAI-UTC at 12h today (to detect drift). */
                js = Dat(iy, im, id, 0.5, out var dat12);
                if (js < 0) return js;

                /* TAI-UTC at 0h tomorrow (to detect jumps). */
                js = Jd2cal(dj, 1.5, out var iy2, out var im2, out var id2, out w);
                if (js != 0) return js;
                js = Dat(iy2, im2, id2, 0.0, out var dat24);
                if (js < 0) return js;

                /* Any sudden change in TAI-UTC between today and tomorrow. */
                dleap = dat24 - (2.0 * dat12 - dat0);

                /* If leap second day, correct the day and final minute lengths. */
                day += dleap;
                if (ihr == 23 && imn == 59) seclim += dleap;

                /* End of UTC-specific actions. */
            }

            /* Validate the time. */
            if (ihr >= 0 && ihr <= 23)
            {
                if (imn >= 0 && imn <= 59)
                {
                    if (sec >= 0.0)
                    {
                        if (sec >= seclim)
                        {
                            js += 2;
                        }
                    }
                    else
                    {
                        js = -6;
                    }
                }
                else
                {
                    js = -5;
                }
            }
            else
            {
                js = -4;
            }
            if (js < 0) return js;

            /* The time in days. */
            var time = (60.0 * ((double)(60 * ihr + imn)) + sec) / day;

            /* Return the date and time. */
            d1 = dj;
            d2 = time;

            /* Status. */
            return js;

            /* Finished. */
        }
    }
}
