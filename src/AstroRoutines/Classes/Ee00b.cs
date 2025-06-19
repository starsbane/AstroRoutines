// Ee00b.cs

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Equation of the equinoxes, compatible with IAU 2000 resolutions but
        /// using the truncated nutation model IAU 2000B.
        /// </summary>
        /// <param name="date1">TT as a 2-part Julian Date (Note 1)</param>
        /// <param name="date2">TT as a 2-part Julian Date (Note 1)</param>
        /// <returns>equation of the equinoxes (Note 2)</returns>
        public static double Ee00b(double date1, double date2)
        {
            double dpsipr, depspr, epsa, dpsi, deps, ee;

            /* IAU 2000 precession-rate adjustments. */
            Pr00(date1, date2, out dpsipr, out depspr);

            /* Mean obliquity, consistent with IAU 2000 precession-nutation. */
            epsa = Obl80(date1, date2) + depspr;

            /* Nutation in longitude. */
            Nut00b(date1, date2, out dpsi, out deps);

            /* Equation of the equinoxes. */
            ee = Ee00(date1, date2, epsa, dpsi);

            return ee;

            /* Finished. */
        }
    }
}
