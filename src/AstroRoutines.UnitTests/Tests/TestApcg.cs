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
        /// Test Apcg function.
        /// </summary>
        /// <remarks>
        /// Prepare for ICRS to GCRS transformation, given classical catalog and J2000.0 epoch.
        /// </remarks>
        [Fact]
        public void TestApcg()
        {
            var status = 0;
            var date1 = 2456165.5;
            var date2 = 0.401182685;
            var ebpv = new double[2, 3];
            var ehp = new double[3];
            var astrom = new ASTROM();

            ebpv[0, 0] = 0.901310875;
            ebpv[0, 1] = -0.417402664;
            ebpv[0, 2] = -0.180982288;
            ebpv[1, 0] = 0.00742727954;
            ebpv[1, 1] = 0.0140507459;
            ebpv[1, 2] = 0.00609045792;
            ehp[0] = 0.903358544;
            ehp[1] = -0.415395237;
            ehp[2] = -0.180084014;

            Apcg(date1, date2, ebpv, ehp, ref astrom);

            Vvd(astrom.pmt, 12.65133794027378508, 1e-11, "Apcg", "pmt", ref status);
            Vvd(astrom.eb[0], 0.901310875, 1e-12, "Apcg", "eb(1)", ref status);
            Vvd(astrom.eb[1], -0.417402664, 1e-12, "Apcg", "eb(2)", ref status);
            Vvd(astrom.eb[2], -0.180982288, 1e-12, "Apcg", "eb(3)", ref status);
            Vvd(astrom.eh[0], 0.8940025429324143045, 1e-12, "Apcg", "eh(1)", ref status);
            Vvd(astrom.eh[1], -0.4110930268679817955, 1e-12, "Apcg", "eh(2)", ref status);
            Vvd(astrom.eh[2], -0.1782189004872870264, 1e-12, "Apcg", "eh(3)", ref status);
            Vvd(astrom.em, 1.010465295811013146, 1e-12, "Apcg", "em", ref status);
            Vvd(astrom.v[0], 0.4289638913597693554e-4, 1e-16, "Apcg", "v(1)", ref status);
            Vvd(astrom.v[1], 0.8115034051581320575e-4, 1e-16, "Apcg", "v(2)", ref status);
            Vvd(astrom.v[2], 0.3517555136380563427e-4, 1e-16, "Apcg", "v(3)", ref status);
            Vvd(astrom.bm1, 0.9999999951686012981, 1e-12, "Apcg", "bm1", ref status);

            // Checking BPN matrix
            Vvd(astrom.bpn[0, 0], 1.0, 0.0, "Apcg", "bpn(1,1)", ref status);
            Vvd(astrom.bpn[0, 1], 0.0, 0.0, "Apcg", "bpn(1,2)", ref status);
            Vvd(astrom.bpn[0, 2], 0.0, 0.0, "Apcg", "bpn(1,3)", ref status);
            Vvd(astrom.bpn[1, 0], 0.0, 0.0, "Apcg", "bpn(2,1)", ref status);
            Vvd(astrom.bpn[1, 1], 1.0, 0.0, "Apcg", "bpn(2,2)", ref status);
            Vvd(astrom.bpn[1, 2], 0.0, 0.0, "Apcg", "bpn(2,3)", ref status);
            Vvd(astrom.bpn[2, 0], 0.0, 0.0, "Apcg", "bpn(3,1)", ref status);
            Vvd(astrom.bpn[2, 1], 0.0, 0.0, "Apcg", "bpn(3,2)", ref status);
            Vvd(astrom.bpn[2, 2], 1.0, 0.0, "Apcg", "bpn(3,3)", ref status);

            Assert.Equal(0, status);
        }
    }
}
