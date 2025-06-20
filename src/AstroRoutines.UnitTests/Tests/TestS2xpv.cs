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
        /// Test S2xpv function.
        /// </summary>
        [Fact]
        public void TestS2xpv()
        {
            var status = 0;

            var s1 = 2.0;
            var s2 = 3.0;
            var pv = new double[2, 3];
            var spv = new double[2, 3];

            pv[0, 0] = 0.3;
            pv[0, 1] = 1.2;
            pv[0, 2] = -2.5;

            pv[1, 0] = 0.5;
            pv[1, 1] = 2.3;
            pv[1, 2] = -0.4;

            S2xpv(s1, s2, pv, ref spv);

            Vvd(spv[0, 0], 0.6, 1e-12, "S2xpv", "p1", ref status);
            Vvd(spv[0, 1], 2.4, 1e-12, "S2xpv", "p2", ref status);
            Vvd(spv[0, 2], -5.0, 1e-12, "S2xpv", "p3", ref status);

            Vvd(spv[1, 0], 1.5, 1e-12, "S2xpv", "v1", ref status);
            Vvd(spv[1, 1], 6.9, 1e-12, "S2xpv", "v2", ref status);
            Vvd(spv[1, 2], -1.2, 1e-12, "S2xpv", "v3", ref status);

            Assert.Equal(0, status);
        }
    }
}
