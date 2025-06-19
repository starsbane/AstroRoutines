namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Precession-nutation, IAU 2000B model: a multi-purpose function,
        /// supporting classical (equinox-based) use directly and CIO-based
        /// use indirectly.
        /// </summary>
        /// <param name="date1">TT as a 2-part Julian Date (Note 1)</param>
        /// <param name="date2">TT as a 2-part Julian Date (Note 1)</param>
        /// <param name="dpsi">Nutation (Note 2)</param>
        /// <param name="deps">Nutation (Note 2)</param>
        /// <param name="epsa">Mean obliquity (Note 3)</param>
        /// <param name="rb">Frame bias matrix (Note 4)</param>
        /// <param name="rp">Precession matrix (Note 5)</param>
        /// <param name="rbp">Bias-precession matrix (Note 6)</param>
        /// <param name="rn">Nutation matrix (Note 7)</param>
        /// <param name="rbpn">GCRS-to-true matrix (Notes 8,9)</param>
        public static void Pn00b(
            double date1, double date2,
            out double dpsi, out double deps, out double epsa,
            out double[,] rb, out double[,] rp, out double[,] rbp,
            out double[,] rn, out double[,] rbpn)
        {
            /* Nutation. */
            Nut00b(date1, date2, out dpsi, out deps);

            /* Remaining results. */
            Pn00(date1, date2, dpsi, deps, out epsa, out rb, out rp, out rbp, out rn, out rbpn);
        }
    }
}
