using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Fundamental argument, IERS Conventions (2003): mean longitude of Earth.
        /// </summary>
        /// <param name="t">TDB, Julian centuries since J2000.0</param>
        /// <returns>Mean longitude of Earth, radians</returns>
        public static double Fae03(double t)
        {
            var a =
                /* Mean longitude of Earth (IERS Conventions 2003). */
                (1.753470314 + 628.3075849991 * t) % D2PI;

            return a;
        }
    }
}
