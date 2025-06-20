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
        /// Test Ld function.
        /// </summary>
        [Fact]
        public void TestLd()
        {
            var status = 0;
            var p = new double[3];
            var q = new double[3];
            var e = new double[3];
            var p1 = new double[3];
			
			var bm = 0.00028574;
			p[0] = -0.763276255;
			p[1] = -0.608633767;
			p[2] = -0.216735543;
			q[0] = -0.763276255;
			q[1] = -0.608633767;
			q[2] = -0.216735543;
			e[0] = 0.76700421;
			e[1] = 0.605629598;
			e[2] = 0.211937094;
			var em = 8.91276983;
			var dlim = 3e-10;

            Ld(bm, p, q, e, em, dlim, ref p1);

            Vvd(p1[0], -0.7632762548968159627, 1e-12, "Ld", "1", ref status);
            Vvd(p1[1], -0.6086337670823762701, 1e-12, "Ld", "2", ref status);
            Vvd(p1[2], -0.2167355431320546947, 1e-12, "Ld", "3", ref status);

            Assert.Equal(0, status);
        }
    }
}
