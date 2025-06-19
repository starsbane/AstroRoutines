namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Normalize angle into the range -pi <= a < +pi.
        /// </summary>
        /// <param name="a">angle (radians)</param>
        /// <returns>angle in range +/-pi</returns>
        public static double Anpm(double a)
        {
            double w = a % D2PI;
            if (Abs(w) >= DPI) w -= Sign(w) * D2PI;
            return w;
        }
    }
}