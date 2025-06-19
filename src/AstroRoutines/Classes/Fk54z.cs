namespace AstroRoutines;

public static partial class AR
{
    /// <summary>
    /// Convert a J2000.0 FK5 star position to B1950.0 FK4, assuming zero proper motion in FK5 and parallax.
    /// </summary>
    /// <param name="r2000">J2000.0 FK5 RA,Dec</param>
    /// <param name="d2000">J2000.0 FK5 RA,Dec</param>
    /// <param name="bepoch">Besselian epoch</param>
    /// <param name="r1950">B1950.0 FK4 RA,Dec at epoch BEPOCH</param>
    /// <param name="d1950">B1950.0 FK4 RA,Dec at epoch BEPOCH</param>
    /// <param name="dr1950">B1950.0 FK4 proper motions</param>
    /// <param name="dd1950">B1950.0 FK4 proper motions</param>
    public static void Fk54z(double r2000, double d2000, double bepoch,
                            out double r1950, out double d1950,
                            out double dr1950, out double dd1950)
    {
        double r, d, pr, pd, px, rv;
        double[] p = new double[3];
        double w;
        double[] v = new double[3];
        int i;

        /* FK5 equinox J2000.0 to FK4 equinox B1950.0. */
        Fk524(r2000, d2000, 0.0, 0.0, 0.0, 0.0,
              out r, out d, out pr, out pd, out px, out rv);

        /* Spherical to Cartesian. */
        S2c(r, d, ref p);

        /* Fictitious proper motion (radians per year). */
        v[0] = -pr * p[1] - pd * Math.Cos(r) * Math.Sin(d);
        v[1] = pr * p[0] - pd * Math.Sin(r) * Math.Sin(d);
        v[2] = pd * Math.Cos(d);

        /* Apply the motion. */
        w = bepoch - 1950.0;
        for (i = 0; i < 3; i++)
        {
            p[i] += w * v[i];
        }

        /* Cartesian to spherical. */
        C2s(p, out w, out d1950);
        r1950 = Anp(w);

        /* Fictitious proper motion. */
        dr1950 = pr;
        dd1950 = pd;
    }
}
