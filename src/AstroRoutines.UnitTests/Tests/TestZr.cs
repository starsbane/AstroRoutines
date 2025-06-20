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
        /// Test Zr function.
        /// </summary>
        [Fact]
        public void TestZr()
        {
            var status = 0;
            var r = new double[3, 3];

            r[0, 0] = 2.0;
            r[1, 0] = 3.0;
            r[2, 0] = 2.0;

            r[0, 1] = 3.0;
            r[1, 1] = 2.0;
            r[2, 1] = 3.0;

            r[0, 2] = 3.0;
            r[1, 2] = 4.0;
            r[2, 2] = 5.0;

            Zr(ref r);

            Vvd(r[0, 0], 0.0, 0.0, "Zr", "00", ref status);
            Vvd(r[1, 0], 0.0, 0.0, "Zr", "01", ref status);
            Vvd(r[2, 0], 0.0, 0.0, "Zr", "02", ref status);

            Vvd(r[0, 1], 0.0, 0.0, "Zr", "10", ref status);
            Vvd(r[1, 1], 0.0, 0.0, "Zr", "11", ref status);
            Vvd(r[2, 1], 0.0, 0.0, "Zr", "12", ref status);

            Vvd(r[0, 2], 0.0, 0.0, "Zr", "20", ref status);
            Vvd(r[1, 2], 0.0, 0.0, "Zr", "21", ref status);
            Vvd(r[2, 2], 0.0, 0.0, "Zr", "22", ref status);

            Assert.Equal(0, status);
        }
    }
}
