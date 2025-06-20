using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Fundamental argument, IERS Conventions (2003): mean longitude of the Moon's ascending node.
        /// </summary>
        /// <param name="t">TDB, Julian centuries since J2000.0</param>
        /// <returns>Omega, radians</returns>
        public static double Faom03(double t)
        {
            var a =
                /* Mean longitude of the Moon's ascending node (IERS Conventions 2003). */
                (450160.398036 + t * (-6962890.5431 + t * (7.4722 + t * (0.007702 + t * (-0.00005939))))) % TURNAS * DAS2R;

            return a;
        }
    }
}
