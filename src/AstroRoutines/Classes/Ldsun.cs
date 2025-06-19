namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Deflection of starlight by the Sun.
        /// </summary>
        /// <param name="p">direction from observer to star (unit vector)</param>
        /// <param name="e">direction from Sun to observer (unit vector)</param>
        /// <param name="em">distance from Sun to observer (au)</param>
        /// <param name="p1">observer to deflected star (unit vector)</param>
        public static void Ldsun(double[] p, double[] e, double em, ref double[] p1)
        {
            double em2, dlim;

            /* Deflection limiter (smaller for distant observers). */
            em2 = em * em;
            if (em2 < 1.0) em2 = 1.0;
            dlim = 1e-6 / (em2 > 1.0 ? em2 : 1.0);

            /* Apply the deflection. */
            Ld(1.0, p, p, e, em, dlim, ref p1);

            /* Finished. */
        }
    }
}
