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
        /// Inner (scalar/dot) product of two pv-vectors
        /// </summary>
        /// <param name="a">First pv-vector</param>
        /// <param name="b">Second pv-vector</param>
        /// <param name="adb">Dot product result</param>
        public static void Pvdpv(double[,] a, double[,] b, ref double[] adb)
        {
            // a . b = constant part of result
            adb[0] = Pdp(a.GetRow(0), b.GetRow(0));

            // a . bdot
            var adbd = Pdp(a.GetRow(0), b.GetRow(1));

            // adot . b
            var addb = Pdp(a.GetRow(1), b.GetRow(0));

            // Velocity part of result
            adb[1] = adbd + addb;
        }

        // Reuse the GetRow extension method from Pv2p
    }
}
