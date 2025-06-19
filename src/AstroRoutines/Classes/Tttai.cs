namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Time scale transformation: Terrestrial Time, TT, to International Atomic Time, TAI.
        /// </summary>
        /// <param name="tt1">TT as a 2-part Julian Date</param>
        /// <param name="tt2">TT as a 2-part Julian Date</param>
        /// <param name="tai1">TAI as a 2-part Julian Date</param>
        /// <param name="tai2">TAI as a 2-part Julian Date</param>
        /// <returns>
        /// Status: 
        /// 0 = OK
        /// </returns>
        public static int Tttai(double tt1, double tt2, ref double tai1, ref double tai2)
        {
            // TT minus TAI (days)
            const double dtat = TTMTAI / DAYSEC;

            // Result, safeguarding precision
            if (Abs(tt1) > Abs(tt2))
            {
                tai1 = tt1;
                tai2 = tt2 - dtat;
            }
            else
            {
                tai1 = tt1 - dtat;
                tai2 = tt2;
            }

            // Status (always OK)
            return 0;
        }
    }
}
