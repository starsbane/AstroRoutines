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
        /// Test Tpxev function.
        /// </summary>
        [Fact]
        public void TestTpxev()
        {
            var status = 0;

            double xi = 0, eta = 0;
            var v = new double[3];
            var vz = new double[3];

            var ra = 1.3;
            var dec = 1.55;
            var raz = 2.3;
            var decz = 1.5;

            S2c(ra, dec, ref v);
            S2c(raz, decz, ref vz);

            var j = Tpxev(v, vz, ref xi, ref eta);

            Vvd(xi, -0.01753200983236980595, 1e-15, "Tpxev", "xi", ref status);
            Vvd(eta, 0.05962940005778712891, 1e-15, "Tpxev", "eta", ref status);
            Viv(j, 0, "Tpxev", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
