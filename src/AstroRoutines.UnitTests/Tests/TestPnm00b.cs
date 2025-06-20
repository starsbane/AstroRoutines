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
        /// Test Pnm00b function.
        /// </summary>
        [Fact]
        public void TestPnm00b()
        {
            var rbpn = new double[3, 3];
            var status = 0;

            Pnm00b(2400000.5, 50123.9999, ref rbpn);

            Vvd(rbpn[0, 0], 0.9999995832776208280, 1e-12, "Pnm00b", "11", ref status);
            Vvd(rbpn[0, 1], 0.8372401264429654837e-3, 1e-14, "Pnm00b", "12", ref status);
            Vvd(rbpn[0, 2], 0.3639691681450271771e-3, 1e-14, "Pnm00b", "13", ref status);

            Vvd(rbpn[1, 0], -0.8372552234147137424e-3, 1e-14, "Pnm00b", "21", ref status);
            Vvd(rbpn[1, 1], 0.9999996486477686123, 1e-12, "Pnm00b", "22", ref status);
            Vvd(rbpn[1, 2], 0.4132832190946052890e-4, 1e-14, "Pnm00b", "23", ref status);

            Vvd(rbpn[2, 0], -0.3639344385341866407e-3, 1e-14, "Pnm00b", "31", ref status);
            Vvd(rbpn[2, 1], -0.4163303977421522785e-4, 1e-14, "Pnm00b", "32", ref status);
            Vvd(rbpn[2, 2], 0.9999999329092049734, 1e-12, "Pnm00b", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
