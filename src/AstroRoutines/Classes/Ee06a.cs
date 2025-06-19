// Ee06a.cs

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Equation of the equinoxes, compatible with IAU 2000 resolutions and
        /// IAU 2006/2000A precession-nutation.
        /// </summary>
        /// <param name="date1">TT as a 2-part Julian Date (Note 1)</param>
        /// <param name="date2">TT as a 2-part Julian Date (Note 1)</param>
        /// <returns>equation of the equinoxes (Note 2)</returns>
        public static double Ee06a(double date1, double date2)
        {
            double gst06a, gmst06, ee;

            /* Apparent and mean sidereal times. */
            gst06a = Gst06a(0.0, 0.0, date1, date2);
            gmst06 = Gmst06(0.0, 0.0, date1, date2);

            /* Equation of the equinoxes. */
            ee = Anpm(gst06a - gmst06);

            return ee;

            /* Finished. */
        }
    }
}
