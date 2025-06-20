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
// Copyright © International Astronomical Union Standards of Fundamental Astronomy (http://www.iausofa.org).
//
namespace AstroRoutines
{
    /// <summary>
    /// Body parameters for light deflection
    /// </summary>
    public class LDBODY
    {
        /// <summary>
        /// mass of the body (solar masses)
        /// </summary>
        public double bm;

        /// <summary>
        /// deflection limiter (radians^2/2)
        /// </summary>
        public double dl;

        /// <summary>
        /// barycentric PV of the body (au, au/day)
        /// </summary>
        public double[,] pv;

        public LDBODY()
        {
            bm = 0.0;
            dl = 0.0;
            pv = new double[2, 3];
        }
    }
}
