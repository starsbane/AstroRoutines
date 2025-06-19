namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Precession-rate part of the IAU 2000 precession-nutation models
        /// </summary>
        /// <param name="date1">TT as a 2-part Julian Date</param>
        /// <param name="date2">TT as a 2-part Julian Date</param>
        /// <param name="dpsipr">Precession correction in longitude</param>
        /// <param name="depspr">Precession correction in obliquity</param>
        public static void Pr00(double date1, double date2, 
                                out double dpsipr, out double depspr)
        {
            double t;

            // Precession and obliquity corrections (radians per century)
            const double PRECOR = -0.29965 * DAS2R;
            const double OBLCOR = -0.02524 * DAS2R;

            // Interval between fundamental epoch J2000.0 and given date (JC)
            t = ((date1 - DJ00) + date2) / DJC;

            // Precession rate contributions with respect to IAU 1976/80
            dpsipr = PRECOR * t;
            depspr = OBLCOR * t;
        }
    }
}
