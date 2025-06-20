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
        /// Test A2af function.
        /// </summary>
        /// <remarks>
        /// Converts an angle to degrees, arcminutes, arcseconds.
        /// </remarks>
        [Fact]
        public void TestA2af()
        {
            var status = 0;
            var idmsf = new int[4];

            A2af(4, 2.345, out var s, ref idmsf);

            Viv((int)s, '+', "A2af", "s", ref status);

            Viv(idmsf[0], 134, "A2af", "0", ref status);
            Viv(idmsf[1], 21, "A2af", "1", ref status);
            Viv(idmsf[2], 30, "A2af", "2", ref status);
            Viv(idmsf[3], 9706, "A2af", "3", ref status);

            Assert.Equal(0, status);
        }
    }
}
