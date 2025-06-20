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
        /// Test Pom00 function.
        /// </summary>
        [Fact]
        public void TestPom00()
        {
            var status = 0;

            var xp = 2.55060238e-7;
            var yp = 1.860359247e-6;
            var sp = -0.1367174580728891460e-10;
            var rpom = new double[3, 3];

            Pom00(xp, yp, sp, ref rpom);

            Vvd(rpom[0, 0], 0.9999999999999674721, 1e-12, "Pom00", "11", ref status);
            Vvd(rpom[0, 1], -0.1367174580728846989e-10, 1e-16, "Pom00", "12", ref status);
            Vvd(rpom[0, 2], 0.2550602379999972345e-6, 1e-16, "Pom00", "13", ref status);

            Vvd(rpom[1, 0], 0.1414624947957029801e-10, 1e-16, "Pom00", "21", ref status);
            Vvd(rpom[1, 1], 0.9999999999982695317, 1e-12, "Pom00", "22", ref status);
            Vvd(rpom[1, 2], -0.1860359246998866389e-5, 1e-16, "Pom00", "23", ref status);

            Vvd(rpom[2, 0], -0.2550602379741215021e-6, 1e-16, "Pom00", "31", ref status);
            Vvd(rpom[2, 1], 0.1860359247002414021e-5, 1e-16, "Pom00", "32", ref status);
            Vvd(rpom[2, 2], 0.9999999999982370039, 1e-12, "Pom00", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
