using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// FK5 to Hipparcos rotation and spin.
        /// </summary>
        /// <param name="r5h">r-matrix: FK5 rotation wrt Hipparcos</param>
        /// <param name="s5h">r-vector: FK5 spin wrt Hipparcos</param>
        public static void Fk5hip(out double[,] r5h, out double[] s5h)
        {
            var v = new double[3];
            r5h = new double[3, 3];

            /* FK5 wrt Hipparcos orientation and spin (radians, radians/year) */
            double epx, epy, epz;
            double omx, omy, omz;

            epx = -19.9e-3 * DAS2R;
            epy = -9.1e-3 * DAS2R;
            epz = 22.9e-3 * DAS2R;

            omx = -0.30e-3 * DAS2R;
            omy = 0.60e-3 * DAS2R;
            omz = 0.70e-3 * DAS2R;

            /* FK5 to Hipparcos orientation expressed as an r-vector. */
            v[0] = epx;
            v[1] = epy;
            v[2] = epz;

            /* Re-express as an r-matrix. */
            Rv2m(v, ref r5h);

            /* Hipparcos wrt FK5 spin expressed as an r-vector. */
            s5h = new double[] { omx, omy, omz };
        }
    }
}
