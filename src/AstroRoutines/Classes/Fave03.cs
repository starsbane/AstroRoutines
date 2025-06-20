using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Fundamental argument, IERS Conventions (2003): mean longitude of Venus.
        /// </summary>
        /// <param name="t">TDB, Julian centuries since J2000.0</param>
        /// <returns>Mean longitude of Venus, radians</returns>
        public static double Fave03(double t)
        {
            var a =
                /* Mean longitude of Venus (IERS Conventions 2003). */
                (3.176146697 + 1021.3285546211 * t) % D2PI;

            return a;
        }
    }
}
