using static System.Math;
using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Time scale transformation: International Atomic Time, TAI, to Terrestrial Time, TT.
        /// </summary>
        /// <param name="tai1">TAI as a 2-part Julian Date</param>
        /// <param name="tai2">TAI as a 2-part Julian Date</param>
        /// <param name="tt1">TT as a 2-part Julian Date</param>
        /// <param name="tt2">TT as a 2-part Julian Date</param>
        /// <returns>status: 0 = OK</returns>
        public static int Taitt(double tai1, double tai2, out double tt1, out double tt2)
        {
            tt1 = 0; tt2 = 0;
            var dtat = TTMTAI / DAYSEC;

            if (Abs(tai1) > Abs(tai2))
            {
                tt1 = tai1;
                tt2 = tai2 + dtat;
            }
            else
            {
                tt1 = tai1 + dtat;
                tt2 = tai2;
            }
            return 0;
        }
    }
}
