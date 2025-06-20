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
        /// Update a pv-vector, discarding the velocity component.
        /// </summary>
        /// <param name="dt">Time interval</param>
        /// <param name="pv">PV-vector</param>
        /// <param name="p">Updated position vector</param>
        public static void Pvup(double dt, double[,] pv, ref double[] p)
        {
            p[0] = pv[0, 0] + dt * pv[1, 0];
            p[1] = pv[0, 1] + dt * pv[1, 1];
            p[2] = pv[0, 2] + dt * pv[1, 2];
        }
    }
}
