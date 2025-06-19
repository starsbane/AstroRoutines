namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Forms the matrix of precession-nutation for a given date using IAU 2000B model.
        /// </summary>
        /// <remarks>
        /// Generates a bias-precession-nutation matrix for coordinate transformations.
        /// 
        /// Key characteristics:
        /// - Includes frame bias
        /// - Uses equinox-based IAU 2000B model
        /// - Provides a faster (but slightly less accurate) alternative to IAU 2000A model
        /// 
        /// The matrix transforms vectors from the Geocentric Celestial 
        /// Reference System (GCRS) to the true equatorial triad of the specified date.
        /// 
        /// Approximately 1 milliarcsecond less accurate compared to IAU 2000A model.
        /// </remarks>
        /// <param name="date1">TT date part 1 (Julian Date)</param>
        /// <param name="date2">TT date part 2 (Julian Date)</param>
        /// <param name="rbpn">Bias-precession-nutation matrix (output)</param>
        public static void Pnm00b(double date1, double date2, ref double[,] rbpn)
        {
            double dpsi, deps, epsa;
            double[,] rb = new double[3, 3];
            double[,] rp = new double[3, 3];
            double[,] rbp = new double[3, 3];
            double[,] rn = new double[3, 3];

            /* Obtain the required matrix (discarding other results). */
            Pn00b(date1, date2, out dpsi, out deps, out epsa, out rb, out rp, out rbp, out rn, out rbpn);
        }
    }
}
