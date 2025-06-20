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
        /// Test Nut06a function.
        /// </summary>
        [Fact]
        public void TestNut06a()
        {
            var status = 0;

            Nut06a(2400000.5, 53736.0, out var dpsi, out var deps);

            Vvd(dpsi, -0.9630912025820308797e-5, 1e-13, "Nut06a", "dpsi", ref status);
            Vvd(deps, 0.4063238496887249798e-4, 1e-13, "Nut06a", "deps", ref status);

            Assert.Equal(0, status);
        }
    }
}
