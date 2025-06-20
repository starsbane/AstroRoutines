using static System.Math;
using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Convert degrees, arcminutes, arcseconds to radians.
        /// </summary>
        /// <param name="s">sign: '-' = negative, otherwise positive</param>
        /// <param name="ideg">degrees</param>
        /// <param name="iamin">arcminutes</param>
        /// <param name="asec">arcseconds</param>
        /// <param name="rad">angle in radians</param>
        /// <returns>status: 0 = OK, 1 = ideg outside range 0-359, 2 = iamin outside range 0-59, 3 = asec outside range 0-59.999...</returns>
        public static int Af2a(char s, int ideg, int iamin, double asec, out double rad)
        {
            rad = (s == '-' ? -1.0 : 1.0) *
                  (60.0 * (60.0 * Abs(ideg) + Abs(iamin)) + Abs(asec)) * DAS2R;

            if (ideg < 0 || ideg > 359) return 1;
            if (iamin < 0 || iamin > 59) return 2;
            if (asec < 0.0 || asec >= 60.0) return 3;
            return 0;
        }
    }
}