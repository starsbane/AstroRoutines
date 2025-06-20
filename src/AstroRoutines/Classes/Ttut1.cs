using static System.Math;
using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Time scale transformation: Terrestrial Time, TT, to Universal Time, UT1.
        /// </summary>
        /// <param name="tt1">TT as a 2-part Julian Date</param>
        /// <param name="tt2">TT as a 2-part Julian Date</param>
        /// <param name="dt">TT-UT1 in seconds</param>
        /// <param name="ut11">UT1 as a 2-part Julian Date</param>
        /// <param name="ut12">UT1 as a 2-part Julian Date</param>
        /// <returns>
        /// Status: 
        /// 0 = OK
        /// </returns>
        public static int Ttut1(double tt1, double tt2, double dt, 
                                ref double ut11, ref double ut12)
        {
            var dtd =
                // Result, safeguarding precision
                dt / DAYSEC;
            if (Abs(tt1) > Abs(tt2))
            {
                ut11 = tt1;
                ut12 = tt2 - dtd;
            }
            else
            {
                ut11 = tt1 - dtd;
                ut12 = tt2;
            }

            // Status (always OK)
            return 0;
        }
    }
}
