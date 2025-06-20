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
        /// Test C2i00b function.
        /// </summary>
        /// <remarks>
        /// Celestial-to-intermediate matrix, IAU 2000B precession-nutation.
        /// </remarks>
        [Fact]
        public void TestC2i00b()
        {
            var status = 0;
            C2i00b(2400000.5, 53736.0, out var rc2i);

			Vvd(rc2i[0, 0], 0.9999998323040954356, 1e-12, "C2i00b", "11", ref status);
			Vvd(rc2i[0, 1], 0.5581526349131823372e-9, 1e-12, "C2i00b", "12", ref status);
			Vvd(rc2i[0, 2], -0.5791301934855394005e-3, 1e-12, "C2i00b", "13", ref status);

			Vvd(rc2i[1, 0], -0.2384239285499175543e-7, 1e-12, "C2i00b", "21", ref status);
			Vvd(rc2i[1, 1], 0.9999999991917574043, 1e-12, "C2i00b", "22", ref status);
			Vvd(rc2i[1, 2], -0.4020552974819030066e-4, 1e-12, "C2i00b", "23", ref status);

			Vvd(rc2i[2, 0], 0.5791301929950208873e-3, 1e-12, "C2i00b", "31", ref status);
			Vvd(rc2i[2, 1], 0.4020553681373720832e-4, 1e-12, "C2i00b", "32", ref status);
			Vvd(rc2i[2, 2], 0.9999998314958529887, 1e-12, "C2i00b", "33", ref status);
			
            Assert.Equal(0, status);
        }
    }
}
