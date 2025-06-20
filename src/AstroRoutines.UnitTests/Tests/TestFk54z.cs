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
        /// Test Fk54z function.
        /// </summary>
        [Fact]
        public void TestFk54z()
        {
            var status = 0;

            var r2000 = 0.02719026625066316119;
            var d2000 = -0.1115815170738754813;
            var bepoch = 1954.677308160316374;

            Fk54z(r2000, d2000, bepoch, out var r1950, out var d1950, out var dr1950, out var dd1950);

            Vvd(r1950, 0.01602015588390065476, 1e-14, "Fk54z", "r1950", ref status);
            Vvd(d1950, -0.1164397101110765346, 1e-13, "Fk54z", "d1950", ref status);
            Vvd(dr1950, -0.1175712648471090704e-7, 1e-20, "Fk54z", "dr1950", ref status);
            Vvd(dd1950, 0.2108109051316431056e-7, 1e-20, "Fk54z", "dd1950", ref status);

            Assert.Equal(0, status);
        }
    }
}
