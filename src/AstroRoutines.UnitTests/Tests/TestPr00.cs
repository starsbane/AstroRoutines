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
        /// Test Pr00 function.
        /// </summary>
        [Fact]
        public void TestPr00()
        {
            var status = 0;

            Pr00(2400000.5, 53736, out var dpsipr, out var depspr);

            Vvd(dpsipr, -0.8716465172668347629e-7, 1e-22, "Pr00", "dpsipr", ref status);
            Vvd(depspr, -0.7342018386722813087e-8, 1e-22, "Pr00", "depspr", ref status);

            Assert.Equal(0, status);
        }
    }
}
