using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Fundamental argument, IERS Conventions (2003): mean longitude of Mercury.
        /// </summary>
        /// <param name="t">TDB, Julian centuries since J2000.0</param>
        /// <returns>Mean longitude of Mercury, radians</returns>
        public static double Fame03(double t)
        {
            var a =
                /* Mean longitude of Mercury (IERS Conventions 2003). */
                (4.402608842 + 2608.7903141574 * t) % D2PI;

            return a;
        }
    }
}
