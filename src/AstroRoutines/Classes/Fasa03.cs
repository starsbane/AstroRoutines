using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Fundamental argument, IERS Conventions (2003): mean longitude of Saturn.
        /// </summary>
        /// <param name="t">TDB, Julian centuries since J2000.0</param>
        /// <returns>Mean longitude of Saturn, radians</returns>
        public static double Fasa03(double t)
        {
            double a;

            /* Mean longitude of Saturn (IERS Conventions 2003). */
            a = (0.874016757 + 21.3299104960 * t) % D2PI;

            return a;
        }
    }
}
