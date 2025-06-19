namespace AstroRoutines
{
    public static partial class AR
    {
		/// <summary>
		/// Mean obliquity of the ecliptic, IAU 1980 model.
		/// </summary>
		/// <param name="date1">TT as a 2-part Julian Date (Note 1)</param>
		/// <param name="date2">TT as a 2-part Julian Date (Note 1)</param>
		/// <returns>obliquity of the ecliptic (radians, Note 2)</returns>
        public static double Obl80(double date1, double date2)
        {
            double t, eps0;

            /* Interval between fundamental epoch J2000.0 and given date (JC). */
            t = ((date1 - DJ00) + date2) / DJC;

            /* Mean obliquity of date. */
            eps0 = DAS2R * (84381.448 +
                           (-46.8150 +
                           (-0.00059 +
                           (0.001813) * t) * t) * t);

            return eps0;

            /* Finished. */
        }
    }
}
