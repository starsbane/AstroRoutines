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
        /// Test Pfw06 function.
        /// </summary>
        [Fact]
        public void TestPfw06()
        {
            var status = 0;

            Pfw06(2400000.5, 50123.9999, out var gamb, out var phib, out var psib, out var epsa);

            Vvd(gamb, -0.2243387670997995690e-5, 1e-16, "Pfw06", "gamb", ref status);
            Vvd(phib, 0.4091014602391312808, 1e-12, "Pfw06", "phib", ref status);
            Vvd(psib, -0.9501954178013031895e-3, 1e-14, "Pfw06", "psib", ref status);
            Vvd(epsa, 0.4091014316587367491, 1e-12, "Pfw06", "epsa", ref status);

            Assert.Equal(0, status);
        }
    }
}
