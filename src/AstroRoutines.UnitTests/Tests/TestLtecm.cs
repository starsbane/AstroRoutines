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
        /// Test Ltecm function.
        /// </summary>
        [Fact]
        public void TestLtecm()
        {
			var status = 0;
            var epj = -3000.0;
            var rm = new double[3, 3];

            Ltecm(epj, rm);

            Vvd(rm[0, 0], 0.3564105644859788825, 1e-14, "Ltecm", "rm11", ref status);
            Vvd(rm[0, 1], 0.8530575738617682284, 1e-14, "Ltecm", "rm12", ref status);
            Vvd(rm[0, 2], 0.3811355207795060435, 1e-14, "Ltecm", "rm13", ref status);
            Vvd(rm[1, 0], -0.9343283469640709942, 1e-14, "Ltecm", "rm21", ref status);
            Vvd(rm[1, 1], 0.3247830597681745976, 1e-14, "Ltecm", "rm22", ref status);
            Vvd(rm[1, 2], 0.1467872751535940865, 1e-14, "Ltecm", "rm23", ref status);
            Vvd(rm[2, 0], 0.1431636191201167793e-2, 1e-14, "Ltecm", "rm31", ref status);
            Vvd(rm[2, 1], -0.4084222566960599342, 1e-14, "Ltecm", "rm32", ref status);
            Vvd(rm[2, 2], 0.9127919865189030899, 1e-14, "Ltecm", "rm33", ref status);

            Assert.Equal(0, status);
        }
    }
}
