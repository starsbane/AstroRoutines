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
        /// Test Numat function.
        /// </summary>
        [Fact]
        public void TestNumat()
        {
            var status = 0;
            var epsa = 0.4090789763356509900;
            var dpsi = -0.9630909107115582393e-5;
            var deps = 0.4063239174001678826e-4;

            Numat(epsa, dpsi, deps, out var rmatn);

            Vvd(rmatn[0, 0], 0.9999999999536227949, 1e-12, "Numat", "11", ref status);
            Vvd(rmatn[0, 1], 0.8836239320236250577e-5, 1e-12, "Numat", "12", ref status);
            Vvd(rmatn[0, 2], 0.3830833447458251908e-5, 1e-12, "Numat", "13", ref status);

            Vvd(rmatn[1, 0], -0.8836083657016688588e-5, 1e-12, "Numat", "21", ref status);
            Vvd(rmatn[1, 1], 0.9999999991354654959, 1e-12, "Numat", "22", ref status);
            Vvd(rmatn[1, 2], -0.4063240865362499850e-4, 1e-12, "Numat", "23", ref status);

            Vvd(rmatn[2, 0], -0.3831192481833385226e-5, 1e-12, "Numat", "31", ref status);
            Vvd(rmatn[2, 1], 0.4063237480216934159e-4, 1e-12, "Numat", "32", ref status);
            Vvd(rmatn[2, 2], 0.9999999991671660407, 1e-12, "Numat", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
