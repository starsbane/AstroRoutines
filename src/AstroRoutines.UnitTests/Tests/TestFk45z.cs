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
        /// Test Fk45z function.
        /// </summary>
        [Fact]
        public void TestFk45z()
        {
            var status = 0;

            var r1950 = 0.01602284975382960982;
            var d1950 = -0.1164347929099906024;
            var bepoch = 1954.677617625256806;

            Fk45z(r1950, d1950, bepoch, out var r2000, out var d2000);

            Vvd(r2000, 0.02719295911606862303, 1e-15, "Fk45z", "r2000", ref status);
            Vvd(d2000, -0.1115766001565926892, 1e-13, "Fk45z", "d2000", ref status);

            Assert.Equal(0, status);
        }
    }
}
