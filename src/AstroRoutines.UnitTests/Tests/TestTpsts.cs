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
        /// Test Tpsts function.
        /// </summary>
        [Fact]
        public void TestTpsts()
        {
            var status = 0;

            double ra = 0, dec = 0;

            var xi = -0.03;
            var eta = 0.07;
            var raz = 2.3;
            var decz = 1.5;

            Tpsts(xi, eta, raz, decz, ref ra, ref dec);

            Vvd(ra, 0.7596127167359629775, 1e-14, "Tpsts", "ra", ref status);
            Vvd(dec, 1.540864645109263028, 1e-13, "Tpsts", "dec", ref status);

            Assert.Equal(0, status);
        }
    }
}
