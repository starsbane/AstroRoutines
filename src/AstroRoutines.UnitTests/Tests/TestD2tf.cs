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
        /// Test D2tf function.
        /// </summary>
        [Fact]
        public void TestD2tf()
        {
            var status = 0;
            var ihmsf = new int[4];

            D2tf(4, -0.987654321, out var s, ref ihmsf);

            Viv((int)s, '-', "D2tf", "s", ref status);
            Viv(ihmsf[0], 23, "D2tf", "0", ref status);
            Viv(ihmsf[1], 42, "D2tf", "1", ref status);
            Viv(ihmsf[2], 13, "D2tf", "2", ref status);
            Viv(ihmsf[3], 3333, "D2tf", "3", ref status);

            Assert.Equal(0, status);
        }
    }
}
