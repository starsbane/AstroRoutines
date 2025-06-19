namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Form the matrix of precession/nutation for a given date, IAU 1976
        /// precession model, IAU 1980 nutation model.
        /// </summary>
        /// <param name="date1">TT as a 2-part Julian Date (Note 1)</param>
        /// <param name="date2">TT as a 2-part Julian Date (Note 1)</param>
        /// <param name="rmatpn">Combined precession/nutation matrix</param>
        public static void Pnm80(double date1, double date2, out double[,] rmatpn)
        {
            double[,] rmatp = new double[3, 3];
            double[,] rmatn = new double[3, 3];

            // Precession matrix, J2000.0 to date
            Pmat76(date1, date2, ref rmatp);

            // Nutation matrix
            Nutm80(date1, date2, out rmatn);

            // Combine the matrices: PN = N x P
            Rxr(rmatn, rmatp, out rmatpn);
        }
    }
}
