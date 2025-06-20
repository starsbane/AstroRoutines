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
        /// Test Aticq function.
        /// </summary>
        /// <remarks>
        /// Quick transformation of CIRS RA,Dec to ICRS RA,Dec.
        /// </remarks>
        [Fact]
        public void TestAticq()
        {
            var status = 0;
            var date1 = 2456165.5;
            var date2 = 0.401182685;
            var eo = 0.0;
            var ri = 2.710121572969038991;
            var di = 0.1729371367218230438;
            var astrom = new ASTROM();

            Apci13(date1, date2, ref astrom, out eo);

            Aticq(ri, di, ref astrom, out var rc, out var dc);

            Vvd(rc, 2.710126504531716819, 1e-12, "Aticq", "rc", ref status);
            Vvd(dc, 0.1740632537627034482, 1e-12, "Aticq", "dc", ref status);

            Assert.Equal(0, status);
        }
    }
}
