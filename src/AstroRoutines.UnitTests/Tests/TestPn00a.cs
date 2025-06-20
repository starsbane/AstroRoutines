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
        /// Test Pn00a function.
        /// </summary>
        [Fact]
        public void TestPn00a()
        {
            var status = 0;

            Pn00a(2400000.5, 53736.0, out var dpsi, out var deps, out var epsa, out var rb, out var rp, out var rbp, out var rn, out var rbpn);


            Vvd(dpsi, -0.9630909107115518431e-5, 1e-12, "Pn00a", "dpsi", ref status);
            Vvd(deps, 0.4063239174001678710e-4, 1e-12, "Pn00a", "deps", ref status);
            Vvd(epsa, 0.4090791789404229916, 1e-12, "Pn00a", "epsa", ref status);

            Vvd(rb[0, 0], 0.9999999999999942498, 1e-12, "Pn00a", "rb11", ref status);
            Vvd(rb[0, 1], -0.7078279744199196626e-7, 1e-16, "Pn00a", "rb12", ref status);
            Vvd(rb[0, 2], 0.8056217146976134152e-7, 1e-16, "Pn00a", "rb13", ref status);

            Vvd(rb[1, 0], 0.7078279477857337206e-7, 1e-16, "Pn00a", "rb21", ref status);
            Vvd(rb[1, 1], 0.9999999999999969484, 1e-12, "Pn00a", "rb22", ref status);
            Vvd(rb[1, 2], 0.3306041454222136517e-7, 1e-16, "Pn00a", "rb23", ref status);

            Vvd(rb[2, 0], -0.8056217380986972157e-7, 1e-16, "Pn00a", "rb31", ref status);
            Vvd(rb[2, 1], -0.3306040883980552500e-7, 1e-16, "Pn00a", "rb32", ref status);
            Vvd(rb[2, 2], 0.9999999999999962084, 1e-12, "Pn00a", "rb33", ref status);

            Vvd(rp[0, 0], 0.9999989300532289018, 1e-12, "Pn00a", "rp11", ref status);
            Vvd(rp[0, 1], -0.1341647226791824349e-2, 1e-14, "Pn00a", "rp12", ref status);
            Vvd(rp[0, 2], -0.5829880927190296547e-3, 1e-14, "Pn00a", "rp13", ref status);

            Vvd(rp[1, 0], 0.1341647231069759008e-2, 1e-14, "Pn00a", "rp21", ref status);
            Vvd(rp[1, 1], 0.9999990999908750433, 1e-12, "Pn00a", "rp22", ref status);
            Vvd(rp[1, 2], -0.3837444441583715468e-6, 1e-14, "Pn00a", "rp23", ref status);

            Vvd(rp[2, 0], 0.5829880828740957684e-3, 1e-14, "Pn00a", "rp31", ref status);
            Vvd(rp[2, 1], -0.3984203267708834759e-6, 1e-14, "Pn00a", "rp32", ref status);
            Vvd(rp[2, 2], 0.9999998300623538046, 1e-12, "Pn00a", "rp33", ref status);

            Vvd(rbp[0, 0], 0.9999989300052243993, 1e-12, "Pn00a", "rbp11", ref status);
            Vvd(rbp[0, 1], -0.1341717990239703727e-2, 1e-14, "Pn00a", "rbp12", ref status);
            Vvd(rbp[0, 2], -0.5829075749891684053e-3, 1e-14, "Pn00a", "rbp13", ref status);

            Vvd(rbp[1, 0], 0.1341718013831739992e-2, 1e-14, "Pn00a", "rbp21", ref status);
            Vvd(rbp[1, 1], 0.9999990998959191343, 1e-12, "Pn00a", "rbp22", ref status);
            Vvd(rbp[1, 2], -0.3505759733565421170e-6, 1e-14, "Pn00a", "rbp23", ref status);

            Vvd(rbp[2, 0], 0.5829075206857717883e-3, 1e-14, "Pn00a", "rbp31", ref status);
            Vvd(rbp[2, 1], -0.4315219955198608970e-6, 1e-14, "Pn00a", "rbp32", ref status);
            Vvd(rbp[2, 2], 0.9999998301093036269, 1e-12, "Pn00a", "rbp33", ref status);

            Vvd(rn[0, 0], 0.9999999999536227949, 1e-12, "Pn00a", "rn11", ref status);
            Vvd(rn[0, 1], 0.8836238544090873336e-5, 1e-14, "Pn00a", "rn12", ref status);
            Vvd(rn[0, 2], 0.3830835237722400669e-5, 1e-14, "Pn00a", "rn13", ref status);

            Vvd(rn[1, 0], -0.8836082880798569274e-5, 1e-14, "Pn00a", "rn21", ref status);
            Vvd(rn[1, 1], 0.9999999991354655028, 1e-12, "Pn00a", "rn22", ref status);
            Vvd(rn[1, 2], -0.4063240865362499850e-4, 1e-14, "Pn00a", "rn23", ref status);

            Vvd(rn[2, 0], -0.3831194272065995866e-5, 1e-14, "Pn00a", "rn31", ref status);
            Vvd(rn[2, 1], 0.4063237480216291775e-4, 1e-14, "Pn00a", "rn32", ref status);
            Vvd(rn[2, 2], 0.9999999991671660338, 1e-12, "Pn00a", "rn33", ref status);

            Vvd(rbpn[0, 0], 0.9999989440476103435, 1e-12, "Pn00a", "rbpn11", ref status);
            Vvd(rbpn[0, 1], -0.1332881761240011763e-2, 1e-14, "Pn00a", "rbpn12", ref status);
            Vvd(rbpn[0, 2], -0.5790767434730085751e-3, 1e-14, "Pn00a", "rbpn13", ref status);

            Vvd(rbpn[1, 0], 0.1332858254308954658e-2, 1e-14, "Pn00a", "rbpn21", ref status);
            Vvd(rbpn[1, 1], 0.9999991109044505577, 1e-12, "Pn00a", "rbpn22", ref status);
            Vvd(rbpn[1, 2], -0.4097782710396580452e-4, 1e-14, "Pn00a", "rbpn23", ref status);

            Vvd(rbpn[2, 0], 0.5791308472168152904e-3, 1e-14, "Pn00a", "rbpn31", ref status);
            Vvd(rbpn[2, 1], 0.4020595661591500259e-4, 1e-14, "Pn00a", "rbpn32", ref status);
            Vvd(rbpn[2, 2], 0.9999998314954572304, 1e-12, "Pn00a", "rbpn33", ref status);

            Assert.Equal(0, status);
        }
    }
}
