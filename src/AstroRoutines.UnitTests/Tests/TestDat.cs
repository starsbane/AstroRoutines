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
        /// Test Dat function.
        /// </summary>
        [Fact]
        public void TestDat()
        {
            var status = 0;
            var j = Dat(2003, 6, 1, 0.0, out var deltat);

            Vvd(deltat, 32.0, 0.0, "Dat", "d1", ref status);
            Viv(j, 0, "Dat", "j1", ref status);

            j = Dat(2008, 1, 17, 0.0, out deltat);

            Vvd(deltat, 33.0, 0.0, "Dat", "d2", ref status);
            Viv(j, 0, "Dat", "j2", ref status);

            j = Dat(2017, 9, 1, 0.0, out deltat);

            Vvd(deltat, 37.0, 0.0, "Dat", "d3", ref status);
            Viv(j, 0, "Dat", "j3", ref status);

            Assert.Equal(0, status);
        }
    }
}
