namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// The equation of the equinoxes, compatible with IAU 2000 resolutions,
        /// given the nutation in longitude and the mean obliquity.
        /// </summary>
        /// <param name="date1">TT as a 2-part Julian Date (Note 1)</param>
        /// <param name="date2">TT as a 2-part Julian Date (Note 1)</param>
        /// <param name="epsa">mean obliquity (Note 2)</param>
        /// <param name="dpsi">nutation in longitude (Note 3)</param>
        /// <returns>equation of the equinoxes (Note 4)</returns>
        public static double Ee00(double date1, double date2, double epsa, double dpsi)
        {
            double ee;

            /* Equation of the equinoxes. */
            ee = dpsi * Cos(epsa) + Eect00(date1, date2);

            return ee;

            /* Finished. */
        }
    }
}
