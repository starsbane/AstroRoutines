namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Quick CIRS to observed place transformation.
        /// </summary>
        /// <param name="ri">CIRS right ascension</param>
        /// <param name="di">CIRS declination</param>
        /// <param name="astrom">star-independent astrometry parameters</param>
        /// <param name="aob">observed azimuth (radians: N=0,E=90)</param>
        /// <param name="zob">observed zenith distance (radians)</param>
        /// <param name="hob">observed hour angle (radians)</param>
        /// <param name="dob">observed declination (radians)</param>
        /// <param name="rob">observed right ascension (CIO-based, radians)</param>
        public static void Atioq(double ri, double di, ref ASTROM astrom,
            out double aob, out double zob,
            out double hob, out double dob, out double rob)
        {
            /* Minimum cos(alt) and sin(alt) for refraction purposes */
            const double CELMIN = 1e-6;
            const double SELMIN = 0.05;

            var v = new double[3];
            double x, y, z, sx, cx, sy, cy, xhd, yhd, zhd, f,
                   xhdt, yhdt, zhdt, xaet, yaet, zaet, azobs, r, tz, w, del,
                   cosdel, xaeo, yaeo, zaeo, zdobs, hmobs, dcobs, raobs;

            /* CIRS RA,Dec to Cartesian -HA,Dec. */
            S2c(ri - astrom.eral, di, ref v);
            x = v[0];
            y = v[1];
            z = v[2];

            /* Polar motion. */
            sx = Sin(astrom.xpl);
            cx = Cos(astrom.xpl);
            sy = Sin(astrom.ypl);
            cy = Cos(astrom.ypl);
            xhd = cx * x + sx * z;
            yhd = sx * sy * x + cy * y - cx * sy * z;
            zhd = -sx * cy * x + sy * y + cx * cy * z;

            /* Diurnal aberration. */
            f = (1.0 - astrom.diurab * yhd);
            xhdt = f * xhd;
            yhdt = f * (yhd + astrom.diurab);
            zhdt = f * zhd;

            /* Cartesian -HA,Dec to Cartesian Az,El (S=0,E=90). */
            xaet = astrom.sphi * xhdt - astrom.cphi * zhdt;
            yaet = yhdt;
            zaet = astrom.cphi * xhdt + astrom.sphi * zhdt;

            /* Azimuth (N=0,E=90). */
            azobs = (xaet != 0.0 || yaet != 0.0) ? Atan2(yaet, -xaet) : 0.0;

            /* ---------- */
            /* Refraction */
            /* ---------- */

            /* Cosine and sine of altitude, with precautions. */
            r = Sqrt(xaet * xaet + yaet * yaet);
            r = r > CELMIN ? r : CELMIN;
            z = zaet > SELMIN ? zaet : SELMIN;

            /* A*tan(z)+B*tan^3(z) model, with Newton-Raphson correction. */
            tz = r / z;
            w = astrom.refb * tz * tz;
            del = (astrom.refa + w) * tz /
                  (1.0 + (astrom.refa + 3.0 * w) / (z * z));

            /* Apply the change, giving observed vector. */
            cosdel = 1.0 - del * del / 2.0;
            f = cosdel - del * z / r;
            xaeo = xaet * f;
            yaeo = yaet * f;
            zaeo = cosdel * zaet + del * r;

            /* Observed ZD. */
            zdobs = Atan2(Sqrt(xaeo * xaeo + yaeo * yaeo), zaeo);

            /* Az/El vector to HA,Dec vector (both right-handed). */
            v[0] = astrom.sphi * xaeo + astrom.cphi * zaeo;
            v[1] = yaeo;
            v[2] = -astrom.cphi * xaeo + astrom.sphi * zaeo;

            /* To spherical -HA,Dec. */
            C2s(v, out hmobs, out dcobs);

            /* Right ascension (with respect to CIO). */
            raobs = astrom.eral + hmobs;

            /* Return the results. */
            aob = Anp(azobs);
            zob = zdobs;
            hob = -hmobs;
            dob = dcobs;
            rob = Anp(raobs);
        }
    }
}
