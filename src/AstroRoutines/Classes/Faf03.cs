using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Fundamental argument, IERS Conventions (2003): mean longitude of the Moon minus mean longitude of the ascending node.
        /// </summary>
        /// <param name="t">TDB, Julian centuries since J2000.0</param>
        /// <returns>F, radians</returns>
        public static double Faf03(double t)
        {
            var a =
                /* Mean longitude of the Moon minus that of the ascending node (IERS Conventions 2003). */
                (335779.526232 + t * (1739527262.8478 + t * (-12.7512 + t * (-0.001037 + t * (0.00000417))))) % TURNAS * DAS2R;

            return a;
        }
    }
}
