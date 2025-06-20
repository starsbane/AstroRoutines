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
        /// Test Pvstar function.
        /// </summary>
        [Fact]
        public void TestPvstar()
        {
            var status = 0;

            var pv = new double[2, 3];

            pv[0, 0] = 126668.5912743160601;
            pv[0, 1] = 2136.792716839935195;
            pv[0, 2] = -245251.2339876830091;

            pv[1, 0] = -0.4051854035740712739e-2;
            pv[1, 1] = -0.6253919754866173866e-2;
            pv[1, 2] = 0.1189353719774107189e-1;

            var j = Pvstar(pv, out var ra, out var dec, out var pmr, out var pmd, out var px, out var rv);

            Vvd(ra, 0.1686756e-1, 1e-12, "Pvstar", "ra", ref status);
            Vvd(dec, -1.093989828, 1e-12, "Pvstar", "dec", ref status);
            Vvd(pmr, -0.1783235160000472788e-4, 1e-16, "Pvstar", "pmr", ref status);
            Vvd(pmd, 0.2336024047000619347e-5, 1e-16, "Pvstar", "pmd", ref status);
            Vvd(px, 0.74723, 1e-12, "Pvstar", "px", ref status);
            Vvd(rv, -21.60000010107306010, 1e-11, "Pvstar", "rv", ref status);

            Viv(j, 0, "Pvstar", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
