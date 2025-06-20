namespace AstroRoutines;

public static partial class AR
{
    /// <summary>
    /// Convert a B1950.0 FK4 star position to J2000.0 FK5, assuming zero proper motion in the FK5 system.
    /// </summary>
    /// <param name="r1950">B1950.0 FK4 RA at epoch</param>
    /// <param name="d1950">B1950.0 FK4 Dec at epoch</param>
    /// <param name="bepoch">Besselian epoch</param>
    /// <param name="r2000">J2000.0 FK5 RA</param>
    /// <param name="d2000">J2000.0 FK5 Dec</param>
    public static void Fk45z(double r1950, double d1950, double bepoch, out double r2000, out double d2000)
    {
        /* Radians per year to arcsec per century */
        const double PMF = 100.0 * DR2AS;

        /* Position and position+velocity vectors */
        var r0 = new double[3];
        var p = new double[3];
        var pv = new double[2, 3];

        /* Miscellaneous */
        double w, djm0, djm;
        int i, j, k;

        /*
        ** CANONICAL CONSTANTS (Seidelmann 1992)
        */

        /* Vectors A and Adot (Seidelmann 3.591-2) */
        double[] a = { -1.62557e-6, -0.31919e-6, -0.13843e-6 };
        double[] ad = { +1.245e-3, -1.580e-3, -0.659e-3 };

        /* 3x2 matrix of p-vectors (cf. Seidelmann 3.591-4, matrix M) */
        var em = new double[2, 3, 3] {
            { { +0.9999256782, -0.0111820611, -0.0048579477 },
                { +0.0111820610, +0.9999374784, -0.0000271765 },
                { +0.0048579479, -0.0000271474, +0.9999881997 } },
            { { -0.000551, -0.238565, +0.435739 },
                { +0.238514, -0.002667, -0.008541 },
                { -0.435623, +0.012254, +0.002117 } }
        };

        /* Spherical coordinates to p-vector. */
        S2c(r1950, d1950, ref r0);

		/* Adjust p-vector A to give zero proper motion in FK5. */
		w  = (bepoch - 1950) / PMF;
		Ppsp(a, w, ad, out p);

		/* Remove E-terms. */
		Ppsp(p, -Pdp(r0,p), r0, out p);
		Pmp(r0, p, ref p);

		/* Convert to Fricke system pv-vector (cf. Seidelmann 3.591-3). */
		for ( i = 0; i < 2; i++ ) {
		  for ( j = 0; j < 3; j++ ) {
			 w = 0.0;
			 for ( k = 0; k < 3; k++ ) {
				w += em[i,j,k] * p[k];
			 }
			 pv[i,j] = w;
		  }
		}

		/* Allow for fictitious proper motion. */
		Epb2jd(bepoch, out djm0, out djm);
		w = (Epj(djm0,djm)-2000.0) / PMF;
		Pvu(w, pv, ref pv);

        /* Revert to spherical coordinates. */
        C2s(pv.GetRow(0), out w, out d2000);
        r2000 = Anp(w);
    }
}
