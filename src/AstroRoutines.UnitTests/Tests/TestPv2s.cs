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
namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Pv2s function.
        /// </summary>
        [Fact]
        public void TestPv2s()
        {
            var status = 0;

            var pv = new double[2, 3];

            pv[0, 0] = -0.4514964673880165;
            pv[0, 1] = 0.03093394277342585;
            pv[0, 2] = 0.05594668105108779;

            pv[1, 0] = 1.292270850663260e-5;
            pv[1, 1] = 2.652814182060692e-6;
            pv[1, 2] = 2.568431853930293e-6;

            Pv2s(pv, out var theta, out var phi, out var r, out var td, out var pd, out var rd);

            Vvd(theta, 3.073185307179586515, 1e-12, "Pv2s", "theta", ref status);
            Vvd(phi, 0.1229999999999999992, 1e-12, "Pv2s", "phi", ref status);
            Vvd(r, 0.4559999999999999757, 1e-12, "Pv2s", "r", ref status);
            Vvd(td, -0.7800000000000000364e-5, 1e-16, "Pv2s", "td", ref status);
            Vvd(pd, 0.9010000000000001639e-5, 1e-16, "Pv2s", "pd", ref status);
            Vvd(rd, -0.1229999999999999832e-4, 1e-16, "Pv2s", "rd", ref status);

            Assert.Equal(0, status);
        }
    }
}
