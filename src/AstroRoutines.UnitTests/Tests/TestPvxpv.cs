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
        /// Test Pvxpv function.
        /// </summary>
        [Fact]
        public void TestPvxpv()
        {
            var status = 0;

            var a = new double[2, 3];
            var b = new double[2, 3];
            var axb = new double[2, 3];

            a[0, 0] = 2.0;
            a[0, 1] = 2.0;
            a[0, 2] = 3.0;

            a[1, 0] = 6.0;
            a[1, 1] = 0.0;
            a[1, 2] = 4.0;

            b[0, 0] = 1.0;
            b[0, 1] = 3.0;
            b[0, 2] = 4.0;

            b[1, 0] = 0.0;
            b[1, 1] = 2.0;
            b[1, 2] = 8.0;

            Pvxpv(a, b, axb);

            Vvd(axb[0, 0], -1.0, 1e-12, "Pvxpv", "p1", ref status);
            Vvd(axb[0, 1], -5.0, 1e-12, "Pvxpv", "p2", ref status);
            Vvd(axb[0, 2], 4.0, 1e-12, "Pvxpv", "p3", ref status);

            Vvd(axb[1, 0], -2.0, 1e-12, "Pvxpv", "v1", ref status);
            Vvd(axb[1, 1], -36.0, 1e-12, "Pvxpv", "v2", ref status);
            Vvd(axb[1, 2], 22.0, 1e-12, "Pvxpv", "v3", ref status);

            Assert.Equal(0, status);
        }
    }
}
