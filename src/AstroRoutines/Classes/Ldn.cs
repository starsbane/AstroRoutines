using AstroRoutines.Structs;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// For a star, apply light deflection by multiple solar-system bodies,
        /// as part of transforming coordinate direction into natural direction.
        /// </summary>
        /// <param name="n">number of bodies</param>
        /// <param name="b">data for each of the n bodies</param>
        /// <param name="ob">barycentric position of the observer (au)</param>
        /// <param name="sc">observer to star coord direction (unit vector)</param>
        /// <param name="sn">observer to deflected star (unit vector)</param>
        public static void Ldn(int n, LDBODY[] b, double[] ob, double[] sc, ref double[] sn)
        {
            /* Light time for 1 au (days) */
            const double CR = AULT / DAYSEC;

            int i;
            double[] v = new double[3];
            double dt;
            double[] ev = new double[3];
            double em;
            double[] e = new double[3];

            /* Star direction prior to deflection. */
            Cp(sc, sn);

            /* Body by body. */
            for (i = 0; i < n; i++)
            {
                /* Body to observer vector at epoch of observation (au). */
                Pmp(ob, new double[] { b[i].pv[0, 0], b[i].pv[0, 1], b[i].pv[0, 2] }, ref v);

                /* Minus the time since the light passed the body (days). */
                dt = Pdp(sn, v) * CR;

                /* Neutralize if the star is "behind" the observer. */
                dt = Min(dt, 0.0);

                /* Backtrack the body to the time the light was passing the body. */
                Ppsp(v, -dt, new double[] { b[i].pv[1, 0], b[i].pv[1, 1], b[i].pv[1, 2] }, out ev);

                /* Body to observer vector as magnitude and direction. */
                Pn(ev, out em, out e);

                /* Apply light deflection for this body. */
                Ld(b[i].bm, sn, sn, e, em, b[i].dl, ref sn);

                /* Next body. */
            }

            /* Finished. */
        }
    }
}
