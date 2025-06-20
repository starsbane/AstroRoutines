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
        /// Test Atoiq function.
        /// </summary>
        /// <remarks>
        /// Quick transformation of observed place to CIRS RA,Dec.
        /// </remarks>
        [Fact]
        public void TestAtoiq()
        {
            var status = 0;
            var utc1 = 2456384.5;
            var utc2 = 0.969254051;
            var dut1 = 0.1550675;
            var elong = -0.527800806;
            var phi = -1.2345856;
            var hm = 2738.0;
            var xp = 2.47230737e-7;
            var yp = 1.82640464e-6;
            var phpa = 731.0;
            var tc = 12.8;
            var rh = 0.59;
            var wl = 0.55;
            var astrom = new ASTROM();

            Apio13(utc1, utc2, dut1, elong, phi, hm, xp, yp,
                   phpa, tc, rh, wl, ref astrom);

            Atoiq("R", 2.710085107986886201, 0.1717653435758265198, 
                  ref astrom, out var ri, out var di);

            Vvd(ri, 2.710121574447540810, 1e-12, "Atoiq", "R/ri", ref status);
            Vvd(di, 0.17293718391166087785, 1e-12, "Atoiq", "R/di", ref status);

            Atoiq("H", -0.09247619879782006106, 0.1717653435758265198, 
                  ref astrom, out ri, out di);

            Vvd(ri, 2.710121574448138676, 1e-12, "Atoiq", "H/ri", ref status);
            Vvd(di, 0.1729371839116608778, 1e-12, "Atoiq", "H/di", ref status);

            Atoiq("A", 0.09233952224794989993, 1.407758704513722461, 
                  ref astrom, out ri, out di);

            Vvd(ri, 2.710121574448138676, 1e-12, "Atoiq", "A/ri", ref status);
            Vvd(di, 0.1729371839116608781, 1e-12, "Atoiq", "A/di", ref status);

            Assert.Equal(0, status);
        }
    }
}
