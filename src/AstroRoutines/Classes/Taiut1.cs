using static System.Math;
using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Time scale transformation: International Atomic Time, TAI, to Universal Time, UT1.
        /// </summary>
        /// <param name="tai1">TAI as a 2-part Julian Date</param>
        /// <param name="tai2">TAI as a 2-part Julian Date</param>
        /// <param name="dta">UT1-TAI in seconds</param>
        /// <param name="ut11">UT1 as a 2-part Julian Date</param>
        /// <param name="ut12">UT1 as a 2-part Julian Date</param>
        /// <returns>status: 0 = OK</returns>
        public static int Taiut1(double tai1, double tai2, double dta, out double ut11, out double ut12)
        {
            ut11 = 0; ut12 = 0;
            var dtad = dta / DAYSEC;

            if (Abs(tai1) > Abs(tai2))
            {
                ut11 = tai1;
                ut12 = tai2 + dtad;
            }
            else
            {
                ut11 = tai1 + dtad;
                ut12 = tai2;
            }
            return 0;
        }
    }
}
