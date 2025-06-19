namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// The TIO locator s', positioning the Terrestrial Intermediate Origin on the equator of the Celestial Intermediate Pole.
        /// </summary>
        /// <param name="date1">TT as a 2-part Julian Date</param>
        /// <param name="date2">TT as a 2-part Julian Date</param>
        /// <returns>The TIO locator s' in radians</returns>
        public static double Sp00(double date1, double date2)
        {
            /* Interval between fundamental epoch J2000.0 and current date (JC). */
            double t = ((date1 - DJ00) + date2) / DJC;

            /* Approximate s'. */
            double sp = -47e-6 * t * DAS2R;

            return sp;
        }
    }
}
