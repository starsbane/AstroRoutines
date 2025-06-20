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
        /// Test Rxpv function.
        /// </summary>
        [Fact]
        public void TestRxpv()
        {
            var status = 0;

            var r = new double[3, 3];
            var pv = new double[2, 3];
            var rpv = new double[2, 3];

            r[0, 0] = 2.0;
            r[0, 1] = 3.0;
            r[0, 2] = 2.0;

            r[1, 0] = 3.0;
            r[1, 1] = 2.0;
            r[1, 2] = 3.0;

            r[2, 0] = 3.0;
            r[2, 1] = 4.0;
            r[2, 2] = 5.0;

            pv[0, 0] = 0.2;
            pv[0, 1] = 1.5;
            pv[0, 2] = 0.1;

            pv[1, 0] = 1.5;
            pv[1, 1] = 0.2;
            pv[1, 2] = 0.1;

            Rxpv(r, pv, ref rpv);

            Vvd(rpv[0, 0], 5.1, 1e-12, "Rxpv", "p1", ref status);
            Vvd(rpv[1, 0], 3.8, 1e-12, "Rxpv", "v1", ref status);

            Vvd(rpv[0, 1], 3.9, 1e-12, "Rxpv", "p2", ref status);
            Vvd(rpv[1, 1], 5.2, 1e-12, "Rxpv", "v2", ref status);

            Vvd(rpv[0, 2], 7.1, 1e-12, "Rxpv", "p3", ref status);
            Vvd(rpv[1, 2], 5.8, 1e-12, "Rxpv", "v3", ref status);

            Assert.Equal(0, status);
        }
    }
}
