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
        /// Test C2ixys function.
        /// </summary>
        [Fact]
        public void TestC2ixys()
        {
            var rc2i = new double[3, 3];
            var status = 0;

            var x = 0.5791308486706011000e-3;
            var y = 0.4020579816732961219e-4;
            var s = -0.1220040848472271978e-7;

            C2ixys(x, y, s, ref rc2i);

            Vvd(rc2i[0, 0], 0.9999998323037157138, 1e-12, "C2ixys", "11", ref status);
            Vvd(rc2i[0, 1], 0.5581984869168499149e-9, 1e-12, "C2ixys", "12", ref status);
            Vvd(rc2i[0, 2], -0.5791308491611282180e-3, 1e-12, "C2ixys", "13", ref status);

            Vvd(rc2i[1, 0], -0.2384261642670440317e-7, 1e-12, "C2ixys", "21", ref status);
            Vvd(rc2i[1, 1], 0.9999999991917468964, 1e-12, "C2ixys", "22", ref status);
            Vvd(rc2i[1, 2], -0.4020579110169668931e-4, 1e-12, "C2ixys", "23", ref status);

            Vvd(rc2i[2, 0], 0.5791308486706011000e-3, 1e-12, "C2ixys", "31", ref status);
            Vvd(rc2i[2, 1], 0.4020579816732961219e-4, 1e-12, "C2ixys", "32", ref status);
            Vvd(rc2i[2, 2], 0.9999998314954627590, 1e-12, "C2ixys", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
