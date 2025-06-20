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
        /// Test Pvm function.
        /// </summary>
        [Fact]
        public void TestPvm()
        {
            var status = 0;

            var pv = new double[2, 3];

            pv[0, 0] = 0.3;
            pv[0, 1] = 1.2;
            pv[0, 2] = -2.5;

            pv[1, 0] = 0.45;
            pv[1, 1] = -0.25;
            pv[1, 2] = 1.1;

            Pvm(pv, out var r, out var s);

            Vvd(r, 2.789265136196270604, 1e-12, "Pvm", "r", ref status);
            Vvd(s, 1.214495780149111922, 1e-12, "Pvm", "s", ref status);

            Assert.Equal(0, status);
        }
    }
}
