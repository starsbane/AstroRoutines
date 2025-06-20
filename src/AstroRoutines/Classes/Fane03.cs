using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Fundamental argument, IERS Conventions (2003): mean longitude of Neptune.
        /// </summary>
        /// <param name="t">TDB, Julian centuries since J2000.0</param>
        /// <returns>Mean longitude of Neptune, radians</returns>
        public static double Fane03(double t)
        {
            var a =
                /* Mean longitude of Neptune (IERS Conventions 2003). */
                (5.311886287 + 3.8133035638 * t) % D2PI;

            return a;
        }
    }
}
