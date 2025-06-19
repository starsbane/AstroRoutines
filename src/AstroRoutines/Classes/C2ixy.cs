namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Form the celestial to intermediate-frame-of-date matrix for a given date when the CIP X,Y coordinates are known. IAU 2000.
        /// </summary>
        /// <param name="date1">TT as a 2-part Julian Date</param>
        /// <param name="date2">TT as a 2-part Julian Date</param>
        /// <param name="x">Celestial Intermediate Pole X coordinate</param>
        /// <param name="y">Celestial Intermediate Pole Y coordinate</param>
        /// <param name="rc2i">celestial-to-intermediate matrix</param>
        public static void C2ixy(double date1, double date2, double x, double y,
            ref double[,] rc2i)
        {
            /* Compute s and then the matrix. */
            C2ixys(x, y, S00(date1, date2, x, y), ref rc2i);
        }
    }
}
