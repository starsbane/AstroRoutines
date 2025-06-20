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
        /// Test Pxp function.
        /// </summary>
        [Fact]
        public void TestPxp()
        {
            var status = 0;

            var a = new double[3];
            var b = new double[3];
            var axb = new double[3];

            a[0] = 2.0;
            a[1] = 2.0;
            a[2] = 3.0;

            b[0] = 1.0;
            b[1] = 3.0;
            b[2] = 4.0;

            Pxp(a, b, ref axb);

            Vvd(axb[0], -1.0, 1e-12, "Pxp", "1", ref status);
            Vvd(axb[1], -5.0, 1e-12, "Pxp", "2", ref status);
            Vvd(axb[2], 4.0, 1e-12, "Pxp", "3", ref status);

            Assert.Equal(0, status);
        }
    }
}
