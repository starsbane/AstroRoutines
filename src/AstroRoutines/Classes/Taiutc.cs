using static System.Math;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Time scale transformation: International Atomic Time, TAI, to Coordinated Universal Time, UTC.
        /// </summary>
        /// <param name="tai1">TAI as a 2-part Julian Date</param>
        /// <param name="tai2">TAI as a 2-part Julian Date</param>
        /// <param name="utc1">UTC as a 2-part quasi Julian Date</param>
        /// <param name="utc2">UTC as a 2-part quasi Julian Date</param>
        /// <returns>status: +1 = dubious year, 0 = OK, -1 = unacceptable date</returns>
        public static int Taiutc(double tai1, double tai2, out double utc1, out double utc2)
        {
            utc1 = 0; utc2 = 0;
            int i, j = 0;
            double a1, a2;

            var big1 = (Abs(tai1) >= Abs(tai2)) ? 1 : 0;
            if (big1 != 0)
            {
                a1 = tai1;
                a2 = tai2;
            }
            else
            {
                a1 = tai2;
                a2 = tai1;
            }

            var u1 = a1;
            var u2 = a2;

            for (i = 0; i < 3; i++)
            {
                j = Utctai(u1, u2, out var g1, out var g2);
                if (j < 0) 
                    return j;

                u2 += a1 - g1;
                u2 += a2 - g2;
            }

            if (big1 != 0)
            {
                utc1 = u1;
                utc2 = u2;
            }
            else
            {
                utc1 = u2;
                utc2 = u1;
            }
            return j;
        }
    }
}
