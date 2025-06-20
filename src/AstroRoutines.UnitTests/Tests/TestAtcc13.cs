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
        /// Test Atcc13 function.
        /// </summary>
        /// <remarks>
        /// Transform ICRS RA,Dec to CIRS RA,Dec using internal routine.
        /// </remarks>
        [Fact]
        public void TestAtcc13()
        {
            var status = 0;
            var rc = 2.71;
            var dc = 0.174;
            var pr = 1e-5;
            var pd = 5e-6;
            var px = 0.1;
            var rv = 55.0;
            var date1 = 2456165.5;
            var date2 = 0.401182685;
            double ra = 0, da = 0;

            Atcc13(rc, dc, pr, pd, px, rv, date1, date2, ref ra, ref da);

            Vvd(ra, 2.710126504531372384, 1e-12, "Atcc13", "ra", ref status);
            Vvd(da, 0.1740632537628350152, 1e-12, "Atcc13", "da", ref status);

            Assert.Equal(0, status);
        }
    }
}
