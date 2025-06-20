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
        /// Test C2ixy function.
        /// </summary>
        [Fact]
        public void TestC2ixy()
        {
            var rc2i = new double[3, 3];
            var status = 0;

            var x = 0.5791308486706011000e-3;
            var y = 0.4020579816732961219e-4;

            C2ixy(2400000.5, 53736, x, y, ref rc2i);

            Vvd(rc2i[0, 0], 0.9999998323037157138, 1e-12, "C2ixy", "11", ref status);
            Vvd(rc2i[0, 1], 0.5581526349032241205e-9, 1e-12, "C2ixy", "12", ref status);
            Vvd(rc2i[0, 2], -0.5791308491611263745e-3, 1e-12, "C2ixy", "13", ref status);

            Vvd(rc2i[1, 0], -0.2384257057469842953e-7, 1e-12, "C2ixy", "21", ref status);
            Vvd(rc2i[1, 1], 0.9999999991917468964, 1e-12, "C2ixy", "22", ref status);
            Vvd(rc2i[1, 2], -0.4020579110172324363e-4, 1e-12, "C2ixy", "23", ref status);

            Vvd(rc2i[2, 0], 0.5791308486706011000e-3, 1e-12, "C2ixy", "31", ref status);
            Vvd(rc2i[2, 1], 0.4020579816732961219e-4, 1e-12, "C2ixy", "32", ref status);
            Vvd(rc2i[2, 2], 0.9999998314954627590, 1e-12, "C2ixy", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
