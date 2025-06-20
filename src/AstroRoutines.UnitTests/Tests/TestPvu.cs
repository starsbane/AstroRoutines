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
namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Pvu function.
        /// </summary>
        [Fact]
        public void TestPvu()
        {
            var status = 0;

            var pv = new double[2, 3];
            var upv = new double[2, 3];

            pv[0, 0] = 126668.5912743160734;
            pv[0, 1] = 2136.792716839935565;
            pv[0, 2] = -245251.2339876830229;

            pv[1, 0] = -0.4051854035740713039e-2;
            pv[1, 1] = -0.6253919754866175788e-2;
            pv[1, 2] = 0.1189353719774107615e-1;

            Pvu(2920.0, pv, ref upv);

            Vvd(upv[0, 0], 126656.7598605317105, 1e-6, "Pvu", "p1", ref status);
            Vvd(upv[0, 1], 2118.531271155726332, 1e-8, "Pvu", "p2", ref status);
            Vvd(upv[0, 2], -245216.5048590656190, 1e-6, "Pvu", "p3", ref status);

            Vvd(upv[1, 0], -0.4051854035740713039e-2, 1e-12, "Pvu", "v1", ref status);
            Vvd(upv[1, 1], -0.6253919754866175788e-2, 1e-12, "Pvu", "v2", ref status);
            Vvd(upv[1, 2], 0.1189353719774107615e-1, 1e-12, "Pvu", "v3", ref status);

            Assert.Equal(0, status);
        }
    }
}
