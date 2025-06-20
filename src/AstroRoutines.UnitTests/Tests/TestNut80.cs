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
        /// Test Nut80 function.
        /// </summary>
        [Fact]
        public void TestNut80()
        {
            var status = 0;

            Nut80(2400000.5, 53736.0, out var dpsi, out var deps);

            Vvd(dpsi, -0.9643658353226563966e-5, 1e-13, "Nut80", "dpsi", ref status);
            Vvd(deps, 0.4060051006879713322e-4, 1e-13, "Nut80", "deps", ref status);

            Assert.Equal(0, status);
        }
    }
}
