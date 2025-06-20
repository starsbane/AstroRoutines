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
        /// Test Pb06 function.
        /// </summary>
        [Fact]
        public void TestPb06()
        {
            var status = 0;

            Pb06(2400000.5, 50123.9999, out var bzeta, out var bz, out var btheta);

            Vvd(bzeta, -0.5092634016326478238e-3, 1e-12, "Pb06", "bzeta", ref status);
            Vvd(bz, -0.3602772060566044413e-3, 1e-12, "Pb06", "bz", ref status);
            Vvd(btheta, -0.3779735537167811177e-3, 1e-12, "Pb06", "btheta", ref status);

            Assert.Equal(0, status);
        }
    }
}
