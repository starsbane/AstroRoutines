using static System.Math;

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

            double ce, xaeo, yaeo, zaeo;
            var v = new double[3];
            double xmhdo, ymhdo, zmhdo;

            /* Coordinate type. */
            int c = type[0];

            /* Coordinates. */
            var c1 = ob1;
            var c2 = ob2;

            /* Sin, cos of latitude. */
            var sphi = astrom.sphi;
            var cphi = astrom.cphi;

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
            var az = (xaeo != 0.0 || yaeo != 0.0) ? Atan2(yaeo, xaeo) : 0.0;

            /* Sine of observed ZD, and observed ZD. */
            var sz = Sqrt(xaeo * xaeo + yaeo * yaeo);
            var zdo = Atan2(sz, zaeo);
            /*
            ** Refraction
            ** ----------
            */
            /* Fast algorithm using two constant model. */
            var refa = astrom.refa;
            var refb = astrom.refb;
            var tz = sz / (zaeo > SELMIN ? zaeo : SELMIN);
            var dref = (refa + refb * tz * tz) * tz;
            var zdt = zdo + dref;

            /* To Cartesian Az,ZD. */
            ce = Sin(zdt);
            var xaet = Cos(az) * ce;
            var yaet = Sin(az) * ce;
            var zaet = Cos(zdt);

            /* Cartesian Az,ZD to Cartesian -HA,Dec. */
            var xmhda = sphi * xaet + cphi * zaet;
            var ymhda = yaet;
            var zmhda = -cphi * xaet + sphi * zaet;

            /* Diurnal aberration. */
            var f = (1.0 + astrom.diurab * ymhda);
            var xhd = f * xmhda;
            var yhd = f * (ymhda - astrom.diurab);
            var zhd = f * zmhda;

            /* Polar motion. */
            var sx = Sin(astrom.xpl);
            var cx = Cos(astrom.xpl);
            var sy = Sin(astrom.ypl);
            var cy = Cos(astrom.ypl);
            v[0] = cx * xhd + sx * sy * yhd - sx * cy * zhd;
            v[1] = cy * yhd + sy * zhd;
            v[2] = sx * xhd - cx * sy * yhd + cx * cy * zhd;

            /* To spherical -HA,Dec. */
            C2s(v, out var hma, out di);

            /* Right ascension. */
            ri = Anp(astrom.eral + hma);
        }
    }
}
