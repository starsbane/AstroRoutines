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
        /// Test Atci13 function.
        /// </summary>
        /// <remarks>
        /// Transform ICRS RA,Dec to CIRS RA,Dec using internal routine.
        /// </remarks>
        [Fact]
        public void TestAtci13()
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
            double ri = 0, di = 0, eo = 0;

            Atci13(rc, dc, pr, pd, px, rv, date1, date2, ref ri, ref di, ref eo);

            Vvd(ri, 2.710121572968696744, 1e-12, "Atci13", "ri", ref status);
            Vvd(di, 0.1729371367219539137, 1e-12, "Atci13", "di", ref status);
            Vvd(eo, -0.002900618712657375647, 1e-14, "Atci13", "eo", ref status);

            Assert.Equal(0, status);
        }
    }
}
