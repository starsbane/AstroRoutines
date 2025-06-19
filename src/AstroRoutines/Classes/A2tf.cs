namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Decompose radians into hours, minutes, seconds, fraction.
        /// </summary>
        /// <param name="ndp">resolution</param>
        /// <param name="angle">angle in radians</param>
        /// <param name="sign">'+' or '-'</param>
        /// <param name="ihmsf">hours, minutes, seconds, fraction</param>
        public static void A2tf(int ndp, double angle, out char sign, ref int[] ihmsf)
        {
            D2tf(ndp, angle / D2PI, out sign, ref ihmsf);
        }
    }
}
