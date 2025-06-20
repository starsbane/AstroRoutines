// Eqeq94.cs

using System;
using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Equation of the equinoxes, IAU 1994 model.
        /// </summary>
        /// <param name="date1">TDB date (Note 1)</param>
        /// <param name="date2">TDB date (Note 1)</param>
        /// <returns>equation of the equinoxes (Note 2)</returns>
        public static double Eqeq94(double date1, double date2)
        {
            double t, om, dpsi, deps, eps0, ee;

            /* Interval between fundamental epoch J2000.0 and given date (JC). */
            t = ((date1 - DJ00) + date2) / DJC;

            /* Longitude of the mean ascending node of the lunar orbit on the */
            /* ecliptic, measured from the mean equinox of date. */
            om = Anpm((450160.280 + (-482890.539
                    + (7.455 + 0.008 * t) * t) * t) * DAS2R
                    + ((-5.0 * t) % 1.0) * D2PI);

            /* Nutation components and mean obliquity. */
            Nut80(date1, date2, out dpsi, out deps);
            eps0 = Obl80(date1, date2);

            /* Equation of the equinoxes. */
            ee = dpsi * Math.Cos(eps0) + DAS2R * (0.00264 * Math.Sin(om) + 0.000063 * Math.Sin(om + om));

            return ee;

            /* Finished. */
        }
    }
}
