namespace AstroRoutines
{
    public static partial class AR
    {
		/// <summary>
		/// P-vector to spherical polar coordinates.
		/// </summary>
		/// <param name="p">p-vector</param>
		/// <param name="theta">longitude angle (radians)</param>
		/// <param name="phi">latitude angle (radians)</param>
		/// <param name="r">radial distance</param>
        public static void P2s(double[] p, ref double theta, ref double phi, out double r)
        {
            C2s(p, out theta, out phi);
            r = Pm(p);

            /* Finished. */
        }
    }
}
