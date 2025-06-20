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
        /// Test Ee00 function.
        /// </summary>
        [Fact]
        public void TestEe00()
        {
            var status = 0;
            var epsa = 0.4090789763356509900;
            var dpsi = -0.9630909107115582393e-5;

            var ee = Ee00(2400000.5, 53736.0, epsa, dpsi);

            Vvd(ee, -0.8834193235367965479e-5, 1e-18, "Ee00", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
