using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
		/// <summary>
		/// Mean obliquity of the ecliptic, IAU 2006 precession model.
		/// </summary>
		/// <param name="date1">TT as a 2-part Julian Date (Note 1)</param>
		/// <param name="date2">TT as a 2-part Julian Date (Note 1)</param>
		/// <returns>obliquity of the ecliptic (radians, Note 2)</returns>
        public static double Obl06(double date1, double date2)
        {
            double t, eps0;

            /* Interval between fundamental date J2000.0 and given date (JC). */
            t = ((date1 - DJ00) + date2) / DJC;

            /* Mean obliquity. */
            eps0 = (84381.406 +
                   (-46.836769 +
                   (-0.0001831 +
                   (0.00200340 +
                   (-0.000000576 +
                   (-0.0000000434) * t) * t) * t) * t) * t) * DAS2R;

            return eps0;

            /* Finished. */
        }
    }
}
