namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Compute the X,Y coordinates of the Celestial Intermediate Pole 
        /// and the CIO locator s, using the IAU 2000A precession-nutation model.
        /// </summary>
        /// <param name="date1">TT as a 2-part Julian Date</param>
        /// <param name="date2">TT as a 2-part Julian Date</param>
        /// <param name="x">Celestial Intermediate Pole X coordinate</param>
        /// <param name="y">Celestial Intermediate Pole Y coordinate</param>
        /// <param name="s">CIO locator s in radians</param>
        public static void Xys00a(double date1, double date2, 
                                  ref double x, ref double y, ref double s)
        {
            // Form the bias-precession-nutation matrix, IAU 2000A
            Pnm00a(date1, date2, out var rbpn);

            // Extract X,Y
            Bpn2xy(rbpn, out x, out y);

            // Obtain s
            s = S00(date1, date2, x, y);
        }
    }
}
