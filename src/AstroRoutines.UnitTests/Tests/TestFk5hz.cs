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
        /// Test Fk5hz function.
        /// </summary>
        [Fact]
        public void TestFk5hz()
        {
            var status = 0;
            var r5 = 1.76779433;
            var d5 = -0.2917517103;

            Fk5hz(r5, d5, 2400000.5, 54479.0, out var rh, out var dh);

            Vvd(rh, 1.767794191464423978, 1e-12, "Fk5hz", "ra", ref status);
            Vvd(dh, -0.2917516001679884419, 1e-12, "Fk5hz", "dec", ref status);

            Assert.Equal(0, status);
        }
    }
}
