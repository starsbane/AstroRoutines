using static System.Math;
using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Time scale transformation: Barycentric Dynamical Time, TDB, to Terrestrial Time, TT.
        /// </summary>
        /// <param name="tdb1">TDB as a 2-part Julian Date</param>
        /// <param name="tdb2">TDB as a 2-part Julian Date</param>
        /// <param name="dtr">TDB-TT in seconds</param>
        /// <param name="tt1">TT as a 2-part Julian Date</param>
        /// <param name="tt2">TT as a 2-part Julian Date</param>
        /// <returns>status: 0 = OK</returns>
        public static int Tdbtt(double tdb1, double tdb2, double dtr, out double tt1, out double tt2)
        {
            tt1 = 0; tt2 = 0;
            var dtrd = dtr / DAYSEC;

            if (Abs(tdb1) > Abs(tdb2))
            {
                tt1 = tdb1;
                tt2 = tdb2 - dtrd;
            }
            else
            {
                tt1 = tdb1 - dtrd;
                tt2 = tdb2;
            }
            return 0;
        }
    }
}
