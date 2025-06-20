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
        /// Test Seps function.
        /// </summary>
        [Fact]
        public void TestSeps()
        {
            var status = 0;

            var al = 1.0;
            var ap = 0.1;

            var bl = 0.2;
            var bp = -3.0;

            var s = Seps(al, ap, bl, bp);

            Vvd(s, 2.346722016996998842, 1e-14, "Seps", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
