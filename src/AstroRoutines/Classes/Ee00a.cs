// Ee00a.cs

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Equation of the equinoxes, compatible with IAU 2000 resolutions.
        /// </summary>
        /// <param name="date1">TT as a 2-part Julian Date (Note 1)</param>
        /// <param name="date2">TT as a 2-part Julian Date (Note 1)</param>
        /// <returns>equation of the equinoxes (Note 2)</returns>
        public static double Ee00a(double date1, double date2)
        {
            double dpsipr, deps;

            /* IAU 2000 precession-rate adjustments. */
            Pr00(date1, date2, out dpsipr, out var depspr);

            /* Mean obliquity, consistent with IAU 2000 precession-nutation. */
            var epsa = Obl80(date1, date2) + depspr;

            /* Nutation in longitude. */
            Nut00a(date1, date2, out var dpsi, out deps);

            /* Equation of the equinoxes. */
            var ee = Ee00(date1, date2, epsa, dpsi);

            return ee;

            /* Finished. */
        }
    }
}
