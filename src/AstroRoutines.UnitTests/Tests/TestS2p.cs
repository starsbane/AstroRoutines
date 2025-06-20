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
        /// Test S2p function.
        /// </summary>
        [Fact]
        public void TestS2p()
        {
            var status = 0;

            var p = new double[3];

            S2p(-3.21, 0.123, 0.456, ref p);

            Vvd(p[0], -0.4514964673880165228, 1e-12, "S2p", "x", ref status);
            Vvd(p[1], 0.0309339427734258688, 1e-12, "S2p", "y", ref status);
            Vvd(p[2], 0.0559466810510877933, 1e-12, "S2p", "z", ref status);

            Assert.Equal(0, status);
        }
    }
}
