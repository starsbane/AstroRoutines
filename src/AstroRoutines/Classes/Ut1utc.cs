using static System.Math;
using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Time scale transformation: Universal Time, UT1, to Coordinated Universal Time, UTC.
        /// </summary>
        /// <param name="ut11">UT1 as a 2-part Julian Date</param>
        /// <param name="ut12">UT1 as a 2-part Julian Date</param>
        /// <param name="dut1">Delta UT1: UT1-UTC in seconds</param>
        /// <param name="utc1">UTC as a 2-part quasi Julian Date</param>
        /// <param name="utc2">UTC as a 2-part quasi Julian Date</param>
        /// <returns>
        /// Status:
        /// +1 = dubious year
        /// 0 = OK
        /// -1 = unacceptable date
        /// </returns>
        public static int Ut1utc(double ut11, double ut12, double dut1, 
                                 ref double utc1, ref double utc2)
        {
            int i, js = 0;
            double u1, u2, d2, ddats, us1, us2, du;

            // UT1-UTC in seconds
            var duts = dut1;

            // Put the two parts of the UT1 into big-first order
            var big1 = (Abs(ut11) >= Abs(ut12));
            if (big1)
            {
                u1 = ut11;
                u2 = ut12;
            }
            else
            {
                u1 = ut12;
                u2 = ut11;
            }

            // See if the UT1 can possibly be in a leap-second day
            var d1 = u1;
            double dats1 = 0;
            for (i = -1; i <= 3; i++)
            {
                d2 = u2 + (double)i;
                if (Jd2cal(d1, d2, out var iy, out var im, out var id, out var fd) != 0) return -1;
                js = Dat(iy, im, id, 0.0, out var dats2);
                if (js < 0) return -1;
                if (i == -1) dats1 = dats2;
                ddats = dats2 - dats1;
                if (Abs(ddats) >= 0.5)
                {
                    // Yes, leap second nearby: ensure UT1-UTC is "before" value
                    if (ddats * duts >= 0.0) duts -= ddats;

                    // UT1 for the start of the UTC day that ends in a leap
                    if (Cal2jd(iy, im, id, out d1, out d2) != 0) return -1;
                    us1 = d1;
                    us2 = d2 - 1.0 + duts / DAYSEC;

                    // Is the UT1 after this point?
                    du = u1 - us1;
                    du += u2 - us2;
                    if (du > 0.0)
                    {
                        // Yes: fraction of the current UTC day that has elapsed
                        fd = du * DAYSEC / (DAYSEC + ddats);

                        // Ramp UT1-UTC to bring about SOFA's JD(UTC) convention
                        duts += ddats * (fd <= 1.0 ? fd : 1.0);
                    }

                    // Done
                    break;
                }
                dats1 = dats2;
            }

            // Subtract the (possibly adjusted) UT1-UTC from UT1 to give UTC
            u2 -= duts / DAYSEC;

            // Result, safeguarding precision
            if (big1)
            {
                utc1 = u1;
                utc2 = u2;
            }
            else
            {
                utc1 = u2;
                utc2 = u1;
            }

            // Status
            return js;
        }
    }
}
