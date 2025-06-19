namespace AstroRoutines
{
    public static partial class AR
    {
		/// <summary>
		/// This function forms three Euler angles which implement general
		/// precession from epoch J2000.0, using the IAU 2006 model.  Frame
		/// bias (the offset between ICRS and mean J2000.0) is included.
		/// </summary>
		/// <param name="date1">TT as a 2-part Julian Date (Note 1)</param>
		/// <param name="date2">TT as a 2-part Julian Date (Note 1)</param>
		/// <param name="bzeta">1st rotation: radians cw around z</param>
		/// <param name="bz">3rd rotation: radians cw around z</param>
		/// <param name="btheta">2nd rotation: radians ccw around y</param>
        public static void Pb06(double date1, double date2,
                               out double bzeta, out double bz, out double btheta)
        {
            double[,] r = new double[3, 3];
            double y, x;

            /* Precession matrix via Fukushima-Williams angles. */
            Pmat06(date1, date2, ref r);

            /* Solve for z, choosing the +/- pi alternative. */
            y = r[1, 2];
            x = -r[0, 2];
            if (x < 0.0)
            {
                y = -y;
                x = -x;
            }
            bz = (x != 0.0 || y != 0.0) ? -Atan2(y, x) : 0.0;

            /* Derotate it out of the matrix. */
            Rz(bz, ref r);

            /* Solve for the remaining two angles. */
            y = r[0, 2];
            x = r[2, 2];
            btheta = (x != 0.0 || y != 0.0) ? -Atan2(y, x) : 0.0;

            y = -r[1, 0];
            x = r[1, 1];
            bzeta = (x != 0.0 || y != 0.0) ? -Atan2(y, x) : 0.0;

            /* Finished. */
        }
    }
}
