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
        /// Test Refco function.
        /// </summary>
        [Fact]
        public void TestRefco()
        {
            var status = 0;

            var phpa = 800.0;
            var tc = 10.0;
            var rh = 0.9;
            var wl = 0.4;

            Refco(phpa, tc, rh, wl, out var refa, out var refb);

            Vvd(refa, 0.2264949956241415009e-3, 1e-15, "Refco", "refa", ref status);
            Vvd(refb, -0.2598658261729343970e-6, 1e-18, "Refco", "refb", ref status);

            Assert.Equal(0, status);
        }
    }
}
