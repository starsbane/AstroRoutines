using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Fundamental argument, IERS Conventions (2003): mean longitude of Jupiter.
        /// </summary>
        /// <param name="t">TDB, Julian centuries since J2000.0</param>
        /// <returns>Mean longitude of Jupiter, radians</returns>
        public static double Faju03(double t)
        {
            double a;

            /* Mean longitude of Jupiter (IERS Conventions 2003). */
            a = (0.599546497 + 52.9690962641 * t) % D2PI;

            return a;
        }
    }
}
