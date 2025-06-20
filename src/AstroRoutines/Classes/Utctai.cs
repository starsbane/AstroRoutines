using static System.Math;
using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Time scale transformation: Coordinated Universal Time, UTC, to International Atomic Time, TAI.
        /// </summary>
        /// <param name="utc1">UTC as a 2-part quasi Julian Date</param>
        /// <param name="utc2">UTC as a 2-part quasi Julian Date</param>
        /// <param name="tai1">TAI as a 2-part Julian Date</param>
        /// <param name="tai2">TAI as a 2-part Julian Date</param>
        /// <returns>
        /// Status:
        /// +1 = dubious year
        /// 0 = OK
        /// -1 = unacceptable date
        /// </returns>
        public static int Utctai(double utc1, double utc2, 
                                 out double tai1, out double tai2)
        {
            bool big1;
            int iy, im, id, j, iyt, imt, idt;
            double u1, u2, fd, dat0, dat12, w, dat24, dlod, dleap, z1 = 0, z2 = 0, a2;
            tai1 = tai2 = 0;

            // Put the two parts of the UTC into big-first order
            big1 = (Abs(utc1) >= Abs(utc2));
            if (big1)
            {
                u1 = utc1;
                u2 = utc2;
            }
            else
            {
                u1 = utc2;
                u2 = utc1;
            }

            // Get TAI-UTC at 0h today
            j = Jd2cal(u1, u2, out iy, out im, out id, out fd);
            if (j != 0) return j;
            j = Dat(iy, im, id, 0.0, out dat0);
            if (j < 0) return j;

            // Get TAI-UTC at 12h today (to detect drift)
            j = Dat(iy, im, id, 0.5, out dat12);
            if (j < 0) return j;

            // Get TAI-UTC at 0h tomorrow (to detect jumps)
            j = Jd2cal(u1 + 1.5, u2 - fd, out iyt, out imt, out idt, out w);
            if (j != 0) return j;
            j = Dat(iyt, imt, idt, 0.0, out dat24);
            if (j < 0) return j;

            // Separate TAI-UTC change into per-day (DLOD) and any jump (DLEAP)
            dlod = 2.0 * (dat12 - dat0);
            dleap = dat24 - (dat0 + dlod);

            // Remove any scaling applied to spread leap into preceding day
            fd *= (DAYSEC + dleap) / DAYSEC;

            // Scale from (pre-1972) UTC seconds to SI seconds
            fd *= (DAYSEC + dlod) / DAYSEC;

            // Today's calendar date to 2-part JD
            if (Cal2jd(iy, im, id, out z1, out z2) != 0) return -1;

            // Assemble the TAI result, preserving the UTC split and order
            a2 = z1 - u1;
            a2 += z2;
            a2 += fd + dat0 / DAYSEC;
            if (big1)
            {
                tai1 = u1;
                tai2 = a2;
            }
            else
            {
                tai1 = a2;
                tai2 = u1;
            }

            // Status
            return j;
        }
    }
}
