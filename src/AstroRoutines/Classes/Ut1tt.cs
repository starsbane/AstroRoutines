using static System.Math;
using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Time scale transformation: Universal Time, UT1, to Terrestrial Time, TT.
        /// </summary>
        /// <param name="ut11">UT1 as a 2-part Julian Date</param>
        /// <param name="ut12">UT1 as a 2-part Julian Date</param>
        /// <param name="dt">TT-UT1 in seconds</param>
        /// <param name="tt1">TT as a 2-part Julian Date</param>
        /// <param name="tt2">TT as a 2-part Julian Date</param>
        /// <returns>
        /// Status: 
        /// 0 = OK
        /// </returns>
        public static int Ut1tt(double ut11, double ut12, double dt, 
                                ref double tt1, ref double tt2)
        {
            double dtd;

            // Result, safeguarding precision
            dtd = dt / DAYSEC;
            if (Abs(ut11) > Abs(ut12))
            {
                tt1 = ut11;
                tt2 = ut12 + dtd;
            }
            else
            {
                tt1 = ut11 + dtd;
                tt2 = ut12;
            }

            // Status (always OK)
            return 0;
        }
    }
}
