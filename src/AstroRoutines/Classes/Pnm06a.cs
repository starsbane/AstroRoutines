namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Forms the matrix of precession-nutation for a given date using IAU 2006/2000A model.
        /// </summary>
        /// <remarks>
        /// Generates a bias-precession-nutation matrix for high-precision coordinate transformations.
        /// 
        /// Key features:
        /// - Combines IAU 2006 precession model with IAU 2000A nutation model
        /// - Provides extremely accurate celestial coordinate transformations
        /// - Includes frame bias and precession effects
        /// 
        /// The matrix transforms vectors from the Geocentric Celestial 
        /// Reference System (GCRS) to the true equatorial triad of the specified date.
        /// 
        /// Recommended for high-precision astronomical applications.
        /// </remarks>
        /// <param name="date1">TT date part 1 (Julian Date)</param>
        /// <param name="date2">TT date part 2 (Julian Date)</param>
        /// <param name="rnpb">Bias-precession-nutation matrix (output)</param>
        public static void Pnm06a(double date1, double date2, ref double[,] rbpn)
        {
            /* Fukushima-Williams angles for frame bias and precession. */
			Pfw06(date1, date2, out var gamb, out var phib, out var psib, out var epsa);

			/* Nutation components. */
			Nut06a(date1, date2, out var dp, out var de);

			/* Equinox based nutation x precession x bias matrix. */
			Fw2m(gamb, phib, psib + dp, epsa + de, ref rbpn);
        }
    }
}
