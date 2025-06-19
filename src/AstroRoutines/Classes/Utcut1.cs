namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Time scale transformation: Coordinated Universal Time, UTC, to Universal Time, UT1.
        /// </summary>
        /// <param name="utc1">UTC as a 2-part quasi Julian Date</param>
        /// <param name="utc2">UTC as a 2-part quasi Julian Date</param>
        /// <param name="dut1">Delta UT1 = UT1-UTC in seconds</param>
        /// <param name="ut11">UT1 as a 2-part Julian Date</param>
        /// <param name="ut12">UT1 as a 2-part Julian Date</param>
        /// <returns>
        /// Status:
        /// +1 = dubious year
        /// 0 = OK
        /// -1 = unacceptable date
        /// </returns>
        public static int Utcut1(double utc1, double utc2, double dut1, 
                                 ref double ut11, ref double ut12)
        {
            int iy, im, id, js, jw;
            double w, dat, dta, tai1, tai2;

            // Look up TAI-UTC
            if (Jd2cal(utc1, utc2, out iy, out im, out id, out w) != 0) return -1;
            js = Dat(iy, im, id, 0.0, out dat);
            if (js < 0) return -1;

            // Form UT1-TAI
            dta = dut1 - dat;

            // UTC to TAI to UT1
            jw = Utctai(utc1, utc2, out tai1, out tai2);
            if (jw < 0)
            {
                return -1;
            }
            else if (jw > 0)
            {
                js = jw;
            }
            if (Taiut1(tai1, tai2, dta, out ut11, out ut12) != 0) return -1;

            // Status
            return js;
        }
    }
}
