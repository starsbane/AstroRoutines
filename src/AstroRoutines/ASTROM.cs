// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo
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
// Copyright � International Astronomical Union Standards of Fundamental Astronomy (http://www.iausofa.org).
//
namespace AstroRoutines
{
    /// <summary>
    /// Star-independent astrometry parameters
    /// </summary>

    public class ASTROM
    {
        /// <summary>
        /// PM time interval (SSB, Julian years)
        /// </summary>
        public double pmt;

        /// <summary>
        /// SSB to observer (vector, au)
        /// </summary>
        public double[] eb;

        /// <summary>
        /// Sun to observer (unit vector)
        /// </summary>
        public double[] eh;

        /// <summary>
        /// distance from Sun to observer (au)
        /// </summary>
        public double em;

        /// <summary>
        /// barycentric observer velocity (vector, c)
        /// </summary>
        public double[] v;

        /// <summary>
        /// sqrt(1-|v|^2): reciprocal of Lorenz factor
        /// </summary>
        public double bm1;

        /// <summary>
        /// bias-precession-nutation matrix
        /// </summary>
        public double[,] bpn;

        /// <summary>
        /// longitude + s' + dERA(DUT) (radians)
        /// </summary>
        public double along;

        /// <summary>
        /// geodetic latitude (radians)
        /// </summary>
        public double phi;

        /// <summary>
        /// polar motion xp wrt local meridian (radians)
        /// </summary>
        public double xpl;

        /// <summary>
        /// polar motion yp wrt local meridian (radians)
        /// </summary>
        public double ypl;

        /// <summary>
        /// sine of geodetic latitude
        /// </summary>
        public double sphi;

        /// <summary>
        /// cosine of geodetic latitude
        /// </summary>
        public double cphi;

        /// <summary>
        /// magnitude of diurnal aberration vector
        /// </summary>
        public double diurab;

        /// <summary>
        /// "local" Earth rotation angle (radians)
        /// </summary>
        public double eral;

        /// <summary>
        /// refraction constant A (radians)
        /// </summary>
        public double refa;

        /// <summary>
        /// refraction constant B (radians)
        /// </summary>
        public double refb;

        public ASTROM()
        {
            pmt = 0.0;
            eb = new double[3];
            eh = new double[3];
            em = 0.0;
            v = new double[3];
            bm1 = 0.0;
            bpn = new double[3, 3];
            along = 0.0;
            phi = 0.0;
            xpl = 0.0;
            ypl = 0.0;
            sphi = 0.0;
            cphi = 0.0;
            diurab = 0.0;
            eral = 0.0;
            refa = 0.0;
            refb = 0.0;
        }
    }
}
