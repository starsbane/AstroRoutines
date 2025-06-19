namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Precession-nutation calculation using IAU 2000A model.
        /// </summary>
        /// <remarks>
        /// Computes precession and nutation using the IAU 2000A model, 
        /// which provides high-precision celestial coordinate transformations.
        /// 
        /// This method calculates:
        /// - Nutation in longitude and obliquity
        /// - Mean obliquity
        /// - Various rotation matrices for coordinate transformations
        /// </remarks>
        /// <param name="date1">TT date part 1 (Julian Date)</param>
        /// <param name="date2">TT date part 2 (Julian Date)</param>
        /// <param name="dpsi">Output: Nutation in longitude (radians)</param>
        /// <param name="deps">Output: Nutation in obliquity (radians)</param>
        /// <param name="epsa">Output: Mean obliquity of date (radians)</param>
        /// <param name="rb">Output: Frame bias matrix</param>
        /// <param name="rp">Output: Precession matrix</param>
        /// <param name="rbp">Output: Bias-precession matrix</param>
        /// <param name="rn">Output: Nutation matrix</param>
        /// <param name="rbpn">Output: Bias-precession-nutation matrix</param>
        public static void Pn00a(double date1, double date2,
                                 out double dpsi, out double deps, out double epsa,
                                 out double[,] rb, out double[,] rp, out double[,] rbp,
                                 out double[,] rn, out double[,] rbpn)
        {
            /* Nutation. */
            Nut00a(date1, date2, out dpsi, out deps);

            /* Remaining results. */
            Pn00(date1, date2, dpsi, deps, out epsa, out rb, out rp, out rbp, out rn, out rbpn);
        }
    }
}