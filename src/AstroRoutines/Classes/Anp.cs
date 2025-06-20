using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Normalize angle into the range 0 <= a < 2pi.
        /// </summary>
        /// <param name="a">angle (radians)</param>
        /// <returns>angle in range 0-2pi</returns>
        public static double Anp(double a)
        {
            var w = a % D2PI;
            if (w < 0) w += D2PI;
            return w;
        }
    }
}