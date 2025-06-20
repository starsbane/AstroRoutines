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
        /// Test Ltpequ function.
        /// </summary>
        [Fact]
        public void TestLtpequ()
        {
            var status = 0;
            var veq = new double[3];
			
			var epj = -2500.0;
			
            Ltpequ(epj, ref veq);

            Vvd(veq[0], -0.3586652560237326659, 1e-14, "Ltpequ", "veq1", ref status);
            Vvd(veq[1], -0.1996978910771128475, 1e-14, "Ltpequ", "veq2", ref status);
            Vvd(veq[2], 0.9118552442250819624, 1e-14, "Ltpequ", "veq3", ref status);

            Assert.Equal(0, status);
        }
    }
}
