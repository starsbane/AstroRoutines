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
		/// Position-angle from two p-vectors.
		/// </summary>
		/// <param name="a">direction of reference point</param>
		/// <param name="b">direction of point whose PA is required</param>
		/// <returns>position angle of b with respect to a (radians)</returns>
        public static double Pap(double[] a, double[] b)
        {
            double st, ct, xa, ya, za;
            var eta = new double[3];
            var xi = new double[3];
            var a2b = new double[3];

            /* Modulus and direction of the a vector. */
            Pn(a, out var am, out var au);

            /* Modulus of the b vector. */
            var bm = Pm(b);

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
            var pa = Atan2(st, ct);

            return pa;

            /* Finished. */
        }
    }
}
