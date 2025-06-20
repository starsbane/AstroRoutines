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
        /// Test Hd2pa function.
        /// </summary>
        [Fact]
        public void TestHd2pa()
        {
            var status = 0;
            var h = 1.1;
			var d = 1.2;
			var p = 0.3;
			
            var q = Hd2pa(h, d, p);

            Vvd(q, 1.906227428001995580, 1e-13, "Hd2pa", "q", ref status);

            Assert.Equal(0, status);
        }
    }
}
