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
        /// Test Starpm function.
        /// </summary>
        [Fact]
        public void TestStarpm()
        {
            var status = 0;

            var ra1 = 0.01686756;
            var dec1 = -1.093989828;
            var pmr1 = -1.78323516e-5;
            var pmd1 = 2.336024047e-6;
            var px1 = 0.74723;
            var rv1 = -21.6;

            var j = Starpm(ra1, dec1, pmr1, pmd1, px1, rv1,
                           2400000.5, 50083.0, 2400000.5, 53736.0,
                           out var ra2, out var dec2, out var pmr2, out var pmd2, out var px2, out var rv2);

            Vvd(ra2, 0.01668919069414256149, 1e-13, "Starpm", "ra", ref status);
            Vvd(dec2, -1.093966454217127897, 1e-13, "Starpm", "dec", ref status);
            Vvd(pmr2, -0.1783662682153176524e-4, 1e-17, "Starpm", "pmr", ref status);
            Vvd(pmd2, 0.2338092915983989595e-5, 1e-17, "Starpm", "pmd", ref status);
            Vvd(px2, 0.7473533835317719243, 1e-13, "Starpm", "px", ref status);
            Vvd(rv2, -21.59905170476417175, 1e-11, "Starpm", "rv", ref status);

            Viv(j, 0, "Starpm", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
