namespace AstroRoutines
{
    public static partial class AR
    {
		/// <summary>
        /// Precession-nutation calculation using IAU 2000 model.
        /// </summary>
        /// <remarks>
        /// Computes precession and nutation matrices, mean obliquity, and related parameters
        /// using the IAU 2000 model.
        /// 
        /// This method provides comprehensive celestial coordinate transformation matrices:
        /// - Frame bias matrix
        /// - Precession matrix
        /// - Bias-precession matrix
        /// - Nutation matrix
        /// - Combined bias-precession-nutation matrix
        /// 
        /// Includes precession-rate adjustments and consistent mean obliquity calculations.
        /// </remarks>
        /// <param name="date1">TT date part 1 (Julian Date)</param>
        /// <param name="date2">TT date part 2 (Julian Date)</param>
        /// <param name="dpsi">Nutation in longitude (radians)</param>
        /// <param name="deps">Nutation in obliquity (radians)</param>
        /// <param name="epsa">Mean obliquity of date (output, radians)</param>
        /// <param name="rb">Frame bias matrix (output)</param>
        /// <param name="rp">Precession matrix (output)</param>
        /// <param name="rbp">Bias-precession matrix (output)</param>
        /// <param name="rn">Nutation matrix (output)</param>
        /// <param name="rbpn">Bias-precession-nutation matrix (output)</param>
        public static void Pn00(double date1, double date2, double dpsi, double deps,
                                out double epsa,
                                out double[,] rb, out double[,] rp, out double[,] rbp,
                                out double[,] rn, out double[,] rbpn)
        {
            double dpsipr, depspr;
            double[,] rbpw = new double[3, 3];
            double[,] rnw = new double[3, 3];
            rbp = new double[3, 3];
            rn = new double[3, 3];

            /* IAU 2000 precession-rate adjustments. */
            Pr00(date1, date2, out dpsipr, out depspr);

            /* Mean obliquity, consistent with IAU 2000 precession-nutation. */
            epsa = Obl80(date1, date2) + depspr;

            /* Frame bias and precession matrices and their product. */
            Bp00(date1, date2, out rb, out rp, out rbpw);
            Cr(rbpw, ref rbp);

            /* Nutation matrix. */
            Numat(epsa, dpsi, deps, out rnw);
            Cr(rnw, ref rn);

            rbpn = new double[3, 3];
            /* Bias-precession-nutation matrix (classical). */
            Rxr(rnw, rbpw, ref rbpn);
        }
    }
}
