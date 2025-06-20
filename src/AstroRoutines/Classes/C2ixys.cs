using static System.Math;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Form the celestial to intermediate-frame-of-date matrix given the CIP X,Y and the CIO locator s.
        /// </summary>
        /// <param name="x">Celestial Intermediate Pole X coordinate</param>
        /// <param name="y">Celestial Intermediate Pole Y coordinate</param>
        /// <param name="s">the CIO locator s (radians)</param>
        /// <param name="rc2i">celestial-to-intermediate matrix</param>
        public static void C2ixys(double x, double y, double s, ref double[,] rc2i)
        {
            double r2, e, d;

            /* Obtain the spherical angles E and d. */
            r2 = x * x + y * y;
            e = (r2 > 0.0) ? Atan2(y, x) : 0.0;
            d = Atan(Sqrt(r2 / (1.0 - r2)));

            /* Form the matrix. */
            Ir(ref rc2i);
            Rz(e, ref rc2i);
            Ry(d, ref rc2i);
            Rz(-(e + s), ref rc2i);
        }
    }
}
