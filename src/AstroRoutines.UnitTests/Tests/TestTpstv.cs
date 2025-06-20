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
        /// Test Tpstv function.
        /// </summary>
        [Fact]
        public void TestTpstv()
        {
            var status = 0;

            var vz = new double[3];
            var v = new double[3];

            var xi = -0.03;
            var eta = 0.07;
            var raz = 2.3;
            var decz = 1.5;
            
            S2c(raz, decz, ref vz);

            Tpstv(xi, eta, vz, ref v);

            Vvd(v[0], 0.02170030454907376677, 1e-15, "Tpstv", "x", ref status);
            Vvd(v[1], 0.02060909590535367447, 1e-15, "Tpstv", "y", ref status);
            Vvd(v[2], 0.9995520806583523804, 1e-14, "Tpstv", "z", ref status);

            Assert.Equal(0, status);
        }
    }
}
