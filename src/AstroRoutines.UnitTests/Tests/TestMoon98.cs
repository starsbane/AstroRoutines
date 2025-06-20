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
        /// Test Moon98 function.
        /// </summary>
        [Fact]
        public void TestMoon98()
        {
            var status = 0;
            var pv = new double[2, 3];

            Moon98(2400000.5, 43999.9, ref pv);

            Vvd(pv[0, 0], -0.2601295959971044180e-2, 1e-11, "Moon98", "x 4", ref status);
            Vvd(pv[0, 1], 0.6139750944302742189e-3, 1e-11, "Moon98", "y 4", ref status);
            Vvd(pv[0, 2], 0.2640794528229828909e-3, 1e-11, "Moon98", "z 4", ref status);

            Vvd(pv[1, 0], -0.1244321506649895021e-3, 1e-11, "Moon98", "xd 4", ref status);
            Vvd(pv[1, 1], -0.5219076942678119398e-3, 1e-11, "Moon98", "yd 4", ref status);
            Vvd(pv[1, 2], -0.1716132214378462047e-3, 1e-11, "Moon98", "zd 4", ref status);

            Assert.Equal(0, status);
        }
    }
}
