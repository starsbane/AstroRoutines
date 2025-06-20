using static System.Math;

//
// Copyright 2025 Alex Man (Starsbane)
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// Software Routines from the IAU SOFA Collection were used. 
// Copyright © International Astronomical Union Standards of Fundamental Astronomy (http://www.iausofa.org).
//
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

            /* CIRS RA,Dec to Cartesian -HA,Dec. */
            S2c(ri - astrom.eral, di, ref v);
            var x = v[0];
            var y = v[1];
            var z = v[2];

            /* Polar motion. */
            var sx = Sin(astrom.xpl);
            var cx = Cos(astrom.xpl);
            var sy = Sin(astrom.ypl);
            var cy = Cos(astrom.ypl);
            var xhd = cx * x + sx * z;
            var yhd = sx * sy * x + cy * y - cx * sy * z;
            var zhd = -sx * cy * x + sy * y + cx * cy * z;

            /* Diurnal aberration. */
            var f = (1.0 - astrom.diurab * yhd);
            var xhdt = f * xhd;
            var yhdt = f * (yhd + astrom.diurab);
            var zhdt = f * zhd;

            /* Cartesian -HA,Dec to Cartesian Az,El (S=0,E=90). */
            var xaet = astrom.sphi * xhdt - astrom.cphi * zhdt;
            var yaet = yhdt;
            var zaet = astrom.cphi * xhdt + astrom.sphi * zhdt;

            /* Azimuth (N=0,E=90). */
            var azobs = (xaet != 0.0 || yaet != 0.0) ? Atan2(yaet, -xaet) : 0.0;
            /* ---------- */
            /* Refraction */
            /* ---------- */
            /* Cosine and sine of altitude, with precautions. */
            var r = Sqrt(xaet * xaet + yaet * yaet);
            r = r > CELMIN ? r : CELMIN;
            z = zaet > SELMIN ? zaet : SELMIN;

            /* A*tan(z)+B*tan^3(z) model, with Newton-Raphson correction. */
            var tz = r / z;
            var w = astrom.refb * tz * tz;
            var del = (astrom.refa + w) * tz /
                      (1.0 + (astrom.refa + 3.0 * w) / (z * z));

            /* Apply the change, giving observed vector. */
            var cosdel = 1.0 - del * del / 2.0;
            f = cosdel - del * z / r;
            var xaeo = xaet * f;
            var yaeo = yaet * f;
            var zaeo = cosdel * zaet + del * r;

            /* Observed ZD. */
            var zdobs = Atan2(Sqrt(xaeo * xaeo + yaeo * yaeo), zaeo);

            /* Az/El vector to HA,Dec vector (both right-handed). */
            v[0] = astrom.sphi * xaeo + astrom.cphi * zaeo;
            v[1] = yaeo;
            v[2] = -astrom.cphi * xaeo + astrom.sphi * zaeo;

            /* To spherical -HA,Dec. */
            C2s(v, out var hmobs, out var dcobs);

            /* Right ascension (with respect to CIO). */
            var raobs = astrom.eral + hmobs;

            /* Return the results. */
            aob = Anp(azobs);
            zob = zdobs;
            hob = -hmobs;
            dob = dcobs;
            rob = Anp(raobs);
        }
    }
}
