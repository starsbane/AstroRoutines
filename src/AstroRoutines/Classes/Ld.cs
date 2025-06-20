using static System.Math;
using static AstroRoutines.Constants;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Apply light deflection by a solar-system body, as part of
        /// transforming coordinate direction into natural direction.
        /// </summary>
        /// <param name="bm">mass of the gravitating body (solar masses)</param>
        /// <param name="p">direction from observer to source (unit vector)</param>
        /// <param name="q">direction from body to source (unit vector)</param>
        /// <param name="e">direction from body to observer (unit vector)</param>
        /// <param name="em">distance from body to observer (au)</param>
        /// <param name="dlim">deflection limiter</param>
        /// <param name="p1">observer to deflected source (unit vector)</param>
        public static void Ld(double bm, double[] p, double[] q, double[] e,
                             double em, double dlim, ref double[] p1)
        {
            int i;
            var qpe = new double[3];
            var eq = new double[3];
            var peq = new double[3];

            /* q . (q + e). */
            for (i = 0; i < 3; i++)
            {
                qpe[i] = q[i] + e[i];
            }
            var qdqpe = Pdp(q, qpe);

            /* 2 x G x bm / ( em x c^2 x ( q . (q + e) ) ). */
            var w = bm * SRS / em / Max(qdqpe, dlim);

            /* p x (e x q). */
            Pxp(e, q, ref eq);
            Pxp(p, eq, ref peq);

            /* Apply the deflection. */
            for (i = 0; i < 3; i++)
            {
                p1[i] = p[i] + w * peq[i];
            }

            /* Finished. */
        }
    }
}
