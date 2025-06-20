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
        /// Test Pmpx function.
        /// </summary>
        [Fact]
        public void TestPmpx()
        {
            var rc = 1.234;
            var dc = 0.789;
            var pr = 1e-5;
            var pd = -2e-5;
            var px = 1e-2;
            var rv = 10.0;
            var pmt = 8.75;
            var pob = new double[3];
            var pco = new double[3];
            var status = 0;

            pob[0] = 0.9;
            pob[1] = 0.4;
            pob[2] = 0.1;

            Pmpx(rc, dc, pr, pd, px, rv, pmt, pob, ref pco);

            Vvd(pco[0], 0.2328137623960308438, 1e-12, "Pmpx", "1", ref status);
            Vvd(pco[1], 0.6651097085397855328, 1e-12, "Pmpx", "2", ref status);
            Vvd(pco[2], 0.7095257765896359837, 1e-12, "Pmpx", "3", ref status);

            Assert.Equal(0, status);
        }
    }
}
