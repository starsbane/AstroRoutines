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
        /// Test Anpm function.
        /// </summary>
        /// <remarks>
        /// Normalize angle into the range -pi to +pi.
        /// </remarks>
        [Fact]
        public void TestAnpm()
        {
            var status = 0;

            Vvd(Anpm(-4.0), 2.283185307179586477, 1e-12, "Anpm", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
