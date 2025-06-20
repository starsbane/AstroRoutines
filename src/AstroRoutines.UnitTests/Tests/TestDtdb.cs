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
        /// Test Dtdb function.
        /// </summary>
        [Fact]
        public void TestDtdb()
        {
            var status = 0;
            var dtdb = Dtdb(2448939.5, 0.123, 0.76543, 5.0123, 5525.242, 3190.0);

            Vvd(dtdb, -0.1280368005936998991e-2, 1e-15, "Dtdb", "", ref status);

            Assert.Equal(0, status);
        }
    }
}
