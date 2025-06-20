using static System.Math;
using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Time scale transformation: Universal Time, UT1, to International Atomic Time, TAI.
        /// </summary>
        /// <param name="ut11">UT1 as a 2-part Julian Date</param>
        /// <param name="ut12">UT1 as a 2-part Julian Date</param>
        /// <param name="dta">UT1-TAI in seconds</param>
        /// <param name="tai1">TAI as a 2-part Julian Date</param>
        /// <param name="tai2">TAI as a 2-part Julian Date</param>
        /// <returns>
        /// Status: 
        /// 0 = OK
        /// </returns>
        public static int Ut1tai(double ut11, double ut12, double dta, 
                                 ref double tai1, ref double tai2)
        {
            var dtad =
                // Result, safeguarding precision
                dta / DAYSEC;
            if (Abs(ut11) > Abs(ut12))
            {
                tai1 = ut11;
                tai2 = ut12 - dtad;
            }
            else
            {
                tai1 = ut11 - dtad;
                tai2 = ut12;
            }

            // Status (always OK)
            return 0;
        }
    }
}
