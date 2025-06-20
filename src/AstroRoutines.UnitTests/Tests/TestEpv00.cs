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
        /// Test Epv00 function.
        /// </summary>
        [Fact]
        public void TestEpv00()
        {
            var status = 0;

            var pvh = new double[2, 3];
            var pvb = new double[2, 3];

            var j = Epv00(2400000.5, 53411.52501161, ref pvh, ref pvb);

            Vvd(pvh[0, 0], -0.7757238809297706813, 1e-14, "Epv00", "ph(x)", ref status);
            Vvd(pvh[0, 1], 0.5598052241363340596, 1e-14, "Epv00", "ph(y)", ref status);
            Vvd(pvh[0, 2], 0.2426998466481686993, 1e-14, "Epv00", "ph(z)", ref status);

            Vvd(pvh[1, 0], -0.1091891824147313846e-1, 1e-15, "Epv00", "vh(x)", ref status);
            Vvd(pvh[1, 1], -0.1247187268440845008e-1, 1e-15, "Epv00", "vh(y)", ref status);
            Vvd(pvh[1, 2], -0.5407569418065039061e-2, 1e-15, "Epv00", "vh(z)", ref status);

            Vvd(pvb[0, 0], -0.7714104440491111971, 1e-14, "Epv00", "pb(x)", ref status);
            Vvd(pvb[0, 1], 0.5598412061824171323, 1e-14, "Epv00", "pb(y)", ref status);
            Vvd(pvb[0, 2], 0.2425996277722452400, 1e-14, "Epv00", "pb(z)", ref status);

            Vvd(pvb[1, 0], -0.1091874268116823295e-1, 1e-15, "Epv00", "vb(x)", ref status);
            Vvd(pvb[1, 1], -0.1246525461732861538e-1, 1e-15, "Epv00", "vb(y)", ref status);
            Vvd(pvb[1, 2], -0.5404773180966231279e-2, 1e-15, "Epv00", "vb(z)", ref status);

            Viv(j, 0, "Epv00", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
