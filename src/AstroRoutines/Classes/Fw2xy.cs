namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// CIP X,Y given Fukushima-Williams bias-precession-nutation angles.
        /// </summary>
        /// <param name="gamb">F-W angle gamma_bar</param>
        /// <param name="phib">F-W angle phi_bar</param>
        /// <param name="psi">F-W angle psi</param>
        /// <param name="eps">F-W angle epsilon</param>
        /// <param name="x">CIP unit vector X</param>
        /// <param name="y">CIP unit vector Y</param>
        public static void Fw2xy(double gamb, double phib, double psi, double eps, out double x, out double y)
        {
            var r = new double[3, 3];

            /* Form NxPxB matrix. */
            Fw2m(gamb, phib, psi, eps, ref r);

            /* Extract CIP X,Y. */
            Bpn2xy(r, out x, out y);
        }
    }
}
