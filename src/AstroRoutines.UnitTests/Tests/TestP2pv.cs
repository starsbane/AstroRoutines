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
        /// Test P2pv function.
        /// </summary>
        [Fact]
        public void TestP2pv()
        {
            var status = 0;
            var p = new double[3];
            var pv = new double[2, 3];

            p[0] = 0.25;
            p[1] = 1.2;
            p[2] = 3.0;

            pv[0, 0] = 0.3;
            pv[0, 1] = 1.2;
            pv[0, 2] = -2.5;

            pv[1, 0] = -0.5;
            pv[1, 1] = 3.1;
            pv[1, 2] = 0.9;

            P2pv(p, ref pv);

            Vvd(pv[0, 0], 0.25, 0.0, "P2pv", "p1", ref status);
            Vvd(pv[0, 1], 1.2, 0.0, "P2pv", "p2", ref status);
            Vvd(pv[0, 2], 3.0, 0.0, "P2pv", "p3", ref status);

            Vvd(pv[1, 0], 0.0, 0.0, "P2pv", "v1", ref status);
            Vvd(pv[1, 1], 0.0, 0.0, "P2pv", "v2", ref status);
            Vvd(pv[1, 2], 0.0, 0.0, "P2pv", "v3", ref status);

            Assert.Equal(0, status);
        }
    }
}
