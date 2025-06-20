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
        /// Test Pnm80 function.
        /// </summary>
        [Fact]
        public void TestPnm80()
        {
            var status = 0;

            Pnm80(2400000.5, 50123.9999, out var rmatpn);

            Vvd(rmatpn[0, 0], 0.9999995831934611169, 1e-12, "Pnm80", "11", ref status);
            Vvd(rmatpn[0, 1], 0.8373654045728124011e-3, 1e-14, "Pnm80", "12", ref status);
            Vvd(rmatpn[0, 2], 0.3639121916933106191e-3, 1e-14, "Pnm80", "13", ref status);

            Vvd(rmatpn[1, 0], -0.8373804896118301316e-3, 1e-14, "Pnm80", "21", ref status);
            Vvd(rmatpn[1, 1], 0.9999996485439674092, 1e-12, "Pnm80", "22", ref status);
            Vvd(rmatpn[1, 2], 0.4130202510421549752e-4, 1e-14, "Pnm80", "23", ref status);

            Vvd(rmatpn[2, 0], -0.3638774789072144473e-3, 1e-14, "Pnm80", "31", ref status);
            Vvd(rmatpn[2, 1], -0.4160674085851722359e-4, 1e-14, "Pnm80", "32", ref status);
            Vvd(rmatpn[2, 2], 0.9999999329310274805, 1e-12, "Pnm80", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
