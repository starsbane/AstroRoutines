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
        /// Test Tdbtcb function.
        /// </summary>
        [Fact]
        public void TestTdbtcb()
        {
            var status = 0;

            var j = Tdbtcb(2453750.5, 0.892855137, out var b1, out var b2);

            Vvd(b1, 2453750.5, 1e-6, "Tdbtcb", "b1", ref status);
            Vvd(b2, 0.8930195997253656716, 1e-12, "Tdbtcb", "b2", ref status);
            Viv(j, 0, "Tdbtcb", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
