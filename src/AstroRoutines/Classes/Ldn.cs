using static System.Math;
using static AstroRoutines.Constants;

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
        /// For a star, apply light deflection by multiple solar-system bodies,
        /// as part of transforming coordinate direction into natural direction.
        /// </summary>
        /// <param name="n">number of bodies</param>
        /// <param name="b">data for each of the n bodies</param>
        /// <param name="ob">barycentric position of the observer (au)</param>
        /// <param name="sc">observer to star coord direction (unit vector)</param>
        /// <param name="sn">observer to deflected star (unit vector)</param>
        public static void Ldn(int n, LDBODY[] b, double[] ob, double[] sc, ref double[] sn)
        {
            /* Light time for 1 au (days) */
            const double CR = AULT / DAYSEC;

            int i;
            var v = new double[3];
            double dt;

            /* Star direction prior to deflection. */
            Cp(sc, ref sn);

            /* Body by body. */
            for (i = 0; i < n; i++)
            {
                /* Body to observer vector at epoch of observation (au). */
                Pmp(ob, b[i].pv.GetRow(0), ref v);

                /* Minus the time since the light passed the body (days). */
                dt = Pdp(sn, v) * CR;

                /* Neutralize if the star is "behind" the observer. */
                dt = Min(dt, 0.0);

                /* Backtrack the body to the time the light was passing the body. */
                Ppsp(v, -dt, b[i].pv.GetRow(1), out var ev);

                /* Body to observer vector as magnitude and direction. */
                Pn(ev, out var em, out var e);

                /* Apply light deflection for this body. */
                Ld(b[i].bm, sn, sn, e, em, b[i].dl, ref sn);

                /* Next body. */
            }

            /* Finished. */
        }
    }
}
