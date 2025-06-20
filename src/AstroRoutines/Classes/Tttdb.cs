using static System.Math;
using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Time scale transformation: Terrestrial Time, TT, to Barycentric Dynamical Time, TDB.
        /// </summary>
        /// <param name="tt1">TT as a 2-part Julian Date</param>
        /// <param name="tt2">TT as a 2-part Julian Date</param>
        /// <param name="dtr">TDB-TT in seconds</param>
        /// <param name="tdb1">TDB as a 2-part Julian Date</param>
        /// <param name="tdb2">TDB as a 2-part Julian Date</param>
        /// <returns>
        /// Status: 
        /// 0 = OK
        /// </returns>
        public static int Tttdb(double tt1, double tt2, double dtr, 
                                ref double tdb1, ref double tdb2)
        {
            var dtrd =
                // Result, safeguarding precision
                dtr / DAYSEC;
            if (Abs(tt1) > Abs(tt2))
            {
                tdb1 = tt1;
                tdb2 = tt2 + dtrd;
            }
            else
            {
                tdb1 = tt1 + dtrd;
                tdb2 = tt2;
            }

            // Status (always OK)
            return 0;
        }
    }
}
