using AstroRoutines.Structs;

namespace AstroRoutines
{
    public static partial class AR
    {
        /// <summary>
        /// Quick observed place to CIRS, given the star-independent astrometry parameters.
        /// </summary>
        /// <param name="type">type of coordinates: "R", "H" or "A"</param>
        /// <param name="ob1">observed Az, HA or RA (radians; Az is N=0,E=90)</param>
        /// <param name="ob2">observed ZD or Dec (radians)</param>
        /// <param name="astrom">star-independent astrometry parameters</param>
        /// <param name="ri">CIRS right ascension (CIO-based, radians)</param>
        /// <param name="di">CIRS declination (radians)</param>
        public static void Atoiq(string type,
            double ob1, double ob2, ref ASTROM astrom,
            out double ri, out double di)
        {
            /* Minimum sin(alt) for refraction purposes */
            const double SELMIN = 0.05;

            int c;
            double c1, c2, sphi, cphi, ce, xaeo, yaeo, zaeo;
            double[] v = new double[3];
            double xmhdo, ymhdo, zmhdo, az, sz, zdo, refa, refb, tz, dref,
                   zdt, xaet, yaet, zaet, xmhda, ymhda, zmhda,
                   f, xhd, yhd, zhd, sx, cx, sy, cy, hma;

            /* Coordinate type. */
            c = type[0];

            /* Coordinates. */
            c1 = ob1;
            c2 = ob2;

            /* Sin, cos of latitude. */
            sphi = astrom.sphi;
            cphi = astrom.cphi;

            /* Standardize coordinate type. */
            if (c == 'r' || c == 'R')
            {
                c = 'R';
            }
            else if (c == 'h' || c == 'H')
            {
                c = 'H';
            }
            else
            {
                c = 'A';
            }

            /* If Az,ZD, convert to Cartesian (S=0,E=90). */
            if (c == 'A')
            {
                ce = Sin(c2);
                xaeo = -Cos(c1) * ce;
                yaeo = Sin(c1) * ce;
                zaeo = Cos(c2);
            }
            else
            {
                /* If RA,Dec, convert to HA,Dec. */
                if (c == 'R')
                {
                    c1 = astrom.eral - c1;
                }

                /* To Cartesian -HA,Dec. */
                S2c(-c1, c2, ref v);
                xmhdo = v[0];
                ymhdo = v[1];
                zmhdo = v[2];

                /* To Cartesian Az,El (S=0,E=90). */
                xaeo = sphi * xmhdo - cphi * zmhdo;
                yaeo = ymhdo;
                zaeo = cphi * xmhdo + sphi * zmhdo;
            }

            /* Azimuth (S=0,E=90). */
            az = (xaeo != 0.0 || yaeo != 0.0) ? Atan2(yaeo, xaeo) : 0.0;

            /* Sine of observed ZD, and observed ZD. */
            sz = Sqrt(xaeo * xaeo + yaeo * yaeo);
            zdo = Atan2(sz, zaeo);

            /*
            ** Refraction
            ** ----------
            */

            /* Fast algorithm using two constant model. */
            refa = astrom.refa;
            refb = astrom.refb;
            tz = sz / (zaeo > SELMIN ? zaeo : SELMIN);
            dref = (refa + refb * tz * tz) * tz;
            zdt = zdo + dref;

            /* To Cartesian Az,ZD. */
            ce = Sin(zdt);
            xaet = Cos(az) * ce;
            yaet = Sin(az) * ce;
            zaet = Cos(zdt);

            /* Cartesian Az,ZD to Cartesian -HA,Dec. */
            xmhda = sphi * xaet + cphi * zaet;
            ymhda = yaet;
            zmhda = -cphi * xaet + sphi * zaet;

            /* Diurnal aberration. */
            f = (1.0 + astrom.diurab * ymhda);
            xhd = f * xmhda;
            yhd = f * (ymhda - astrom.diurab);
            zhd = f * zmhda;

            /* Polar motion. */
            sx = Sin(astrom.xpl);
            cx = Cos(astrom.xpl);
            sy = Sin(astrom.ypl);
            cy = Cos(astrom.ypl);
            v[0] = cx * xhd + sx * sy * yhd - sx * cy * zhd;
            v[1] = cy * yhd + sy * zhd;
            v[2] = sx * xhd - cx * sy * yhd + cx * cy * zhd;

            /* To spherical -HA,Dec. */
            C2s(v, out hma, out di);

            /* Right ascension. */
            ri = Anp(astrom.eral + hma);
        }
    }
}
