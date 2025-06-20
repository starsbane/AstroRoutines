using System;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Angular separation between two p-vectors.
        /// </summary>
        /// <param name="a">first p-vector (not necessarily unit length)</param>
        /// <param name="b">second p-vector (not necessarily unit length)</param>
        /// <returns>Angular separation (radians, always positive)</returns>
        public static double Sepp(double[] a, double[] b)
        {
            var axb = new double[3];
            double ss, cs, s;

            /* Sine of angle between the vectors, multiplied by the two moduli. */
            Pxp(a, b, ref axb);
            ss = Pm(axb);

            /* Cosine of the angle, multiplied by the two moduli. */
            cs = Pdp(a, b);

            /* The angle. */
            s = ((ss != 0.0) || (cs != 0.0)) ? Math.Atan2(ss, cs) : 0.0;

            return s;
        }
    }
}
