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
        /// Test Rxr function.
        /// </summary>
        [Fact]
        public void TestRxr()
        {
            var a = new double[3, 3];
            var b = new double[3, 3];
            var atb = new double[3, 3];
            var status = 0;

            a[0, 0] = 2.0;
            a[0, 1] = 3.0;
            a[0, 2] = 2.0;

            a[1, 0] = 3.0;
            a[1, 1] = 2.0;
            a[1, 2] = 3.0;

            a[2, 0] = 3.0;
            a[2, 1] = 4.0;
            a[2, 2] = 5.0;

            b[0, 0] = 1.0;
            b[0, 1] = 2.0;
            b[0, 2] = 2.0;

            b[1, 0] = 4.0;
            b[1, 1] = 1.0;
            b[1, 2] = 1.0;

            b[2, 0] = 3.0;
            b[2, 1] = 0.0;
            b[2, 2] = 1.0;

            Rxr(a, b, ref atb);

            Vvd(atb[0, 0], 20.0, 1e-12, "Rxr", "11", ref status);
            Vvd(atb[0, 1], 7.0, 1e-12, "Rxr", "12", ref status);
            Vvd(atb[0, 2], 9.0, 1e-12, "Rxr", "13", ref status);

            Vvd(atb[1, 0], 20.0, 1e-12, "Rxr", "21", ref status);
            Vvd(atb[1, 1], 8.0, 1e-12, "Rxr", "22", ref status);
            Vvd(atb[1, 2], 11.0, 1e-12, "Rxr", "23", ref status);

            Vvd(atb[2, 0], 34.0, 1e-12, "Rxr", "31", ref status);
            Vvd(atb[2, 1], 10.0, 1e-12, "Rxr", "32", ref status);
            Vvd(atb[2, 2], 15.0, 1e-12, "Rxr", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
