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
        /// Test S2c function.
        /// </summary>
        [Fact]
        public void TestS2c()
        {
            var status = 0;

            var c = new double[3];

            S2c(3.0123, -0.999, ref c);

            Vvd(c[0], -0.5366267667260523906, 1e-12, "S2c", "1", ref status);
            Vvd(c[1], 0.0697711109765145365, 1e-12, "S2c", "2", ref status);
            Vvd(c[2], -0.8409302618566214041, 1e-12, "S2c", "3", ref status);

            Assert.Equal(0, status);
        }
    }
}
