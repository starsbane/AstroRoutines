namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Form the matrix of precession-nutation for a given date (including
        /// frame bias), equinox based, IAU 2000A model.
        /// </summary>
        /// <param name="date1">TT as a 2-part Julian Date (Note 1)</param>
        /// <param name="date2">TT as a 2-part Julian Date (Note 1)</param>
        /// <param name="rbpn">Bias-precession-nutation matrix (Note 2)</param>
        public static void Pnm00a(double date1, double date2, out double[,] rbpn)
        {
            double dpsi, deps, epsa;
            double[,] rb = new double[3,3];
            double[,] rp = new double[3,3];
            double[,] rbp = new double[3,3];
            double[,] rn = new double[3,3];

            /* Obtain the required matrix (discarding other results). */
            Pn00a(date1, date2, out dpsi, out deps, out epsa, out rb, out rp, out rbp, out rn, out rbpn);
        }
    }
}
