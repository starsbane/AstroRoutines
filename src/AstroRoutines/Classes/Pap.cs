using static System.Math;

namespace AstroRoutines
{
    public static partial class AR
    {
		/// <summary>
		/// Position-angle from two p-vectors.
		/// </summary>
		/// <param name="a">direction of reference point</param>
		/// <param name="b">direction of point whose PA is required</param>
		/// <returns>position angle of b with respect to a (radians)</returns>
        public static double Pap(double[] a, double[] b)
        {
            double am, bm, st, ct, xa, ya, za, pa;
            var au = new double[3];
            var eta = new double[3];
            var xi = new double[3];
            var a2b = new double[3];

            /* Modulus and direction of the a vector. */
            Pn(a, out am, out au);

            /* Modulus of the b vector. */
            bm = Pm(b);

            /* Deal with the case of a null vector. */
            if ((am == 0.0) || (bm == 0.0))
            {
                st = 0.0;
                ct = 1.0;
            }
            else
            {
                /* The "north" axis tangential from a (arbitrary length). */
                xa = a[0];
                ya = a[1];
                za = a[2];
                eta[0] = -xa * za;
                eta[1] = -ya * za;
                eta[2] = xa * xa + ya * ya;

                /* The "east" axis tangential from a (same length). */
                Pxp(eta, au, ref xi);

                /* The vector from a to b. */
                Pmp(b, a, ref a2b);

                /* Resolve into components along the north and east axes. */
                st = Pdp(a2b, xi);
                ct = Pdp(a2b, eta);

                /* Deal with degenerate cases. */
                if ((st == 0.0) && (ct == 0.0)) ct = 1.0;
            }

            /* Position angle. */
            pa = Atan2(st, ct);

            return pa;

            /* Finished. */
        }
    }
}
