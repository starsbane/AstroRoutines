using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Fundamental argument, IERS Conventions (2003): mean longitude of Uranus.
        /// </summary>
        /// <param name="t">TDB, Julian centuries since J2000.0</param>
        /// <returns>Mean longitude of Uranus, radians</returns>
        public static double Faur03(double t)
        {
            var a =
                /* Mean longitude of Uranus (IERS Conventions 2003). */
                (5.481293872 + 7.4781598567 * t) % D2PI;

            return a;
        }
    }
}
