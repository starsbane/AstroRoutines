namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// ICRS equatorial to ecliptic rotation matrix, IAU 2006.
        /// </summary>
        /// <param name="date1">TT as a 2-part Julian date (Note 1)</param>
        /// <param name="date2">TT as a 2-part Julian date (Note 1)</param>
        /// <param name="rm">ICRS to ecliptic rotation matrix</param>
        public static void Ecm06(double date1, double date2, ref double[,] rm)
        {
            var bp = new double[3, 3];
            var e = new double[3, 3];

            /* Obliquity, IAU 2006. */
            var ob = Obl06(date1, date2);

            /* Precession-bias matrix, IAU 2006. */
            Pmat06(date1, date2, ref bp);

            /* Equatorial of date to ecliptic matrix. */
            Ir(ref e);
            Rx(ob, ref e);

            /* ICRS to ecliptic coordinates rotation matrix, IAU 2006. */
            Rxr(e, bp, ref rm);

            /* Finished. */
        }
    }
}
