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
        /// Test Dtf2d function.
        /// </summary>
        [Fact]
        public void TestDtf2d()
        {
            var status = 0;
            double u1 = 0, u2 = 0;
            var j = Dtf2d("UTC", 1994, 6, 30, 23, 59, 60.13599, ref u1, ref u2);

            Vvd(u1 + u2, 2449534.49999, 1e-6, "Dtf2d", "u", ref status);
            Viv(j, 0, "Dtf2d", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
