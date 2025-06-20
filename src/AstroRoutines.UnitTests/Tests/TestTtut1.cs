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
        /// Test Ttut1 function.
        /// </summary>
        [Fact]
        public void TestTtut1()
        {
            var status = 0;

            double u1 = 0, u2 = 0;

            var j = Ttut1(2453750.5, 0.892855139, 64.8499, ref u1, ref u2);

            Vvd(u1, 2453750.5, 1e-6, "Ttut1", "u1", ref status);
            Vvd(u2, 0.8921045614537037037, 1e-12, "Ttut1", "u2", ref status);

            Viv(j, 0, "Ttut1", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
