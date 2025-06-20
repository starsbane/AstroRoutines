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
        /// Test Pvtob function.
        /// </summary>
        [Fact]
        public void TestPvtob()
        {
            var status = 0;

            var pv = new double[2, 3];

            var elong = 2.0;
            var phi = 0.5;
            var hm = 3000.0;
            var xp = 1e-6;
            var yp = -0.5e-6;
            var sp = 1e-8;
            var theta = 5.0;

            Pvtob(elong, phi, hm, xp, yp, sp, theta, ref pv);

            Vvd(pv[0, 0], 4225081.367071159207, 1e-5, "Pvtob", "p(1)", ref status);
            Vvd(pv[0, 1], 3681943.215856198144, 1e-5, "Pvtob", "p(2)", ref status);
            Vvd(pv[0, 2], 3041149.399241260785, 1e-5, "Pvtob", "p(3)", ref status);
            Vvd(pv[1, 0], -268.4915389365998787, 1e-9, "Pvtob", "v(1)", ref status);
            Vvd(pv[1, 1], 308.0977983288903123, 1e-9, "Pvtob", "v(2)", ref status);
            Vvd(pv[1, 2], 0, 0, "Pvtob", "v(3)", ref status);

            Assert.Equal(0, status);
        }
    }
}
