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
        /// Test Ecm06 function.
        /// </summary>
        [Fact]
        public void TestEcm06()
        {
            var status = 0;
            var date1 = 2456165.5;
            var date2 = 0.401182685;
            var rm = new double[3, 3];

            Ecm06(date1, date2, ref rm);

            Vvd(rm[0, 0], 0.9999952427708701137, 1e-14, "Ecm06", "rm11", ref status);
            Vvd(rm[0, 1], -0.2829062057663042347e-2, 1e-14, "Ecm06", "rm12", ref status);
            Vvd(rm[0, 2], -0.1229163741100017629e-2, 1e-14, "Ecm06", "rm13", ref status);
            Vvd(rm[1, 0], 0.3084546876908653562e-2, 1e-14, "Ecm06", "rm21", ref status);
            Vvd(rm[1, 1], 0.9174891871550392514, 1e-14, "Ecm06", "rm22", ref status);
            Vvd(rm[1, 2], 0.3977487611849338124, 1e-14, "Ecm06", "rm23", ref status);
            Vvd(rm[2, 0], 0.2488512951527405928e-5, 1e-14, "Ecm06", "rm31", ref status);
            Vvd(rm[2, 1], -0.3977506604161195467, 1e-14, "Ecm06", "rm32", ref status);
            Vvd(rm[2, 2], 0.9174935488232863071, 1e-14, "Ecm06", "rm33", ref status);

            Assert.Equal(0, status);
        }
    }
}
