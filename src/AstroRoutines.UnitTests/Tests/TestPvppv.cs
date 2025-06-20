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
        /// Test Pvppv function.
        /// </summary>
        [Fact]
        public void TestPvppv()
        {
            var status = 0;

            var a = new double[2, 3];
            var b = new double[2, 3];
            var apb = new double[2, 3];

            a[0, 0] = 2.0;
            a[0, 1] = 2.0;
            a[0, 2] = 3.0;

            a[1, 0] = 5.0;
            a[1, 1] = 6.0;
            a[1, 2] = 3.0;

            b[0, 0] = 1.0;
            b[0, 1] = 3.0;
            b[0, 2] = 4.0;

            b[1, 0] = 3.0;
            b[1, 1] = 2.0;
            b[1, 2] = 1.0;

            Pvppv(a, b, ref apb);

            Vvd(apb[0, 0], 3.0, 1e-12, "Pvppv", "p1", ref status);
            Vvd(apb[0, 1], 5.0, 1e-12, "Pvppv", "p2", ref status);
            Vvd(apb[0, 2], 7.0, 1e-12, "Pvppv", "p3", ref status);

            Vvd(apb[1, 0], 8.0, 1e-12, "Pvppv", "v1", ref status);
            Vvd(apb[1, 1], 8.0, 1e-12, "Pvppv", "v2", ref status);
            Vvd(apb[1, 2], 4.0, 1e-12, "Pvppv", "v3", ref status);

            Assert.Equal(0, status);
        }
    }
}
