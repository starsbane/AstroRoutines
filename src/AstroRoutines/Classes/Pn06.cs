namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Precession-nutation calculation using IAU 2006 model.
        /// </summary>
        /// <remarks>
        /// Computes precession and nutation matrices using the IAU 2006 model.
        /// 
        /// This method provides:
        /// - Frame bias matrix
        /// - Precession matrix
        /// - Bias-precession matrix
        /// - Nutation matrix
        /// - Combined bias-precession-nutation matrix
        /// 
        /// Uses Fukushima-Williams angles for precise celestial coordinate transformations.
        /// </remarks>
        /// <param name="date1">TT date part 1 (Julian Date)</param>
        /// <param name="date2">TT date part 2 (Julian Date)</param>
        /// <param name="dpsi">Nutation in longitude (radians)</param>
        /// <param name="deps">Nutation in obliquity (radians)</param>
        /// <param name="epsa">Output: Mean obliquity of date (radians)</param>
        /// <param name="rb">Output: Frame bias matrix</param>
        /// <param name="rp">Output: Precession matrix</param>
        /// <param name="rbp">Output: Bias-precession matrix</param>
        /// <param name="rn">Output: Nutation matrix</param>
        /// <param name="rbpn">Output: Bias-precession-nutation matrix</param>
        public static void Pn06(double date1, double date2, double dpsi, double deps,
                                out double epsa,
                                out double[,] rb, out double[,] rp, out double[,] rbp,
                                out double[,] rn, out double[,] rbpn)
        {
            double gamb, phib, psib, eps;
            double[,] r1 = new double[3, 3];
            double[,] r2 = new double[3, 3];
            double[,] rt = new double[3, 3];
            rb = new double[3, 3];
            rbp = new double[3, 3];
            rbpn = new double[3, 3];

            /* Bias-precession Fukushima-Williams angles of J2000.0 = frame bias. */
            Pfw06(DJM0, DJM00, out gamb, out phib, out psib, out eps);

            /* B matrix. */
            Fw2m(gamb, phib, psib, eps, ref r1);
            Cr(r1, ref rb);

            /* Bias-precession Fukushima-Williams angles of date. */
            Pfw06(date1, date2, out gamb, out phib, out psib, out eps);

            /* Bias-precession matrix. */
            Fw2m(gamb, phib, psib, eps, ref r2);
            Cr(r2, ref rbp);

            /* Solve for precession matrix. */
            Tr(r1, ref rt);
            Rxr(r2, rt, rp);

            /* Equinox-based bias-precession-nutation matrix. */
            Fw2m(gamb, phib, psib + dpsi, eps + deps, ref r1);
            Cr(r1, ref rbpn);

            /* Solve for nutation matrix. */
            Tr(r2, ref rt);
            Rxr(r1, rt, rn);

            /* Obliquity, mean of date. */
            epsa = eps;
        }
    }
}
