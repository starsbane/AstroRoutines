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
// Copyright � International Astronomical Union Standards of Fundamental Astronomy (http://www.iausofa.org).
//
namespace AstroRoutines.UnitTests
{
    public partial class RATests
    {
        /// <summary>
        /// Test Ab function.
        /// </summary>
        /// <remarks>
        /// Tests stellar aberration.
        /// </remarks>
        [Fact]
        public void TestAb()
        {
            var status = 0;
            var pnat = new double[3];
            var v = new double[3];
            var ppr = new double[3];

            pnat[0] = -0.76321968546737951;
            pnat[1] = -0.60869453983060384;
            pnat[2] = -0.21676408580639883;
            v[0] =  2.1044018893653786e-5;
            v[1] = -8.9108923304429319e-5;
            v[2] = -3.8633714797716569e-5;
            var s = 0.99980921395708788;
            var bm1 = 0.99999999506209258;

            Ab(pnat, v, s, bm1, ref ppr);

            Vvd(ppr[0], -0.7631631094219556269, 1e-12, "Ab", "1", ref status);
            Vvd(ppr[1], -0.6087553082505590832, 1e-12, "Ab", "2", ref status);
            Vvd(ppr[2], -0.2167926269368471279, 1e-12, "Ab", "3", ref status);

            Assert.Equal(0, status);
        }
    }
}
