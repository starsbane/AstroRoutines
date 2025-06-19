namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Extract from the bias-precession-nutation matrix the X,Y coordinates of the Celestial Intermediate Pole.
        /// </summary>
        /// <param name="rbpn">celestial-to-true matrix</param>
        /// <param name="x">Celestial Intermediate Pole X coordinate</param>
        /// <param name="y">Celestial Intermediate Pole Y coordinate</param>
        public static void Bpn2xy(double[,] rbpn, out double x, out double y)
        {
            /* Extract the X,Y coordinates. */
            x = rbpn[2, 0];
            y = rbpn[2, 1];
        }
    }
}
