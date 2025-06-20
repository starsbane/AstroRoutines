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
        /// Test Gd2gc function.
        /// </summary>
        [Fact]
        public void TestGd2gc()
        {
            var status = 0;
            double e = 3.1, p = -0.5, h = 2500.0;

            var j = Gd2gc(0, e, p, h, out var xyz);
            Viv(j, -1, "Gd2gc", "j0", ref status);

            j = Gd2gc(WGS84, e, p, h, out xyz);
            Viv(j, 0, "Gd2gc", "j1", ref status);
            Vvd(xyz[0], -5599000.5577049947, 1e-7, "Gd2gc", "1/1", ref status);
            Vvd(xyz[1], 233011.67223479203, 1e-7, "Gd2gc", "2/1", ref status);
            Vvd(xyz[2], -3040909.4706983363, 1e-7, "Gd2gc", "3/1", ref status);

            j = Gd2gc(GRS80, e, p, h, out xyz);
            Viv(j, 0, "Gd2gc", "j2", ref status);
            Vvd(xyz[0], -5599000.5577260984, 1e-7, "Gd2gc", "1/2", ref status);
            Vvd(xyz[1], 233011.6722356702949, 1e-7, "Gd2gc", "2/2", ref status);
            Vvd(xyz[2], -3040909.4706095476, 1e-7, "Gd2gc", "3/2", ref status);

            j = Gd2gc(WGS72, e, p, h, out xyz);
            Viv(j, 0, "Gd2gc", "j3", ref status);
            Vvd(xyz[0], -5598998.7626301490, 1e-7, "Gd2gc", "1/3", ref status);
            Vvd(xyz[1], 233011.5975297822211, 1e-7, "Gd2gc", "2/3", ref status);
            Vvd(xyz[2], -3040908.6861467111, 1e-7, "Gd2gc", "3/3", ref status);

            j = Gd2gc(4, e, p, h, out xyz);
            Viv(j, -1, "Gd2gc", "j4", ref status);

            Assert.Equal(0, status);
        }
    }
}
