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
        /// Test S2pv function.
        /// </summary>
        [Fact]
        public void TestS2pv()
        {
            var status = 0;

            var pv = new double[2, 3];

            S2pv(-3.21, 0.123, 0.456, -7.8e-6, 9.01e-6, -1.23e-5, ref pv);

            Vvd(pv[0, 0], -0.4514964673880165228, 1e-12, "S2pv", "x", ref status);
            Vvd(pv[0, 1], 0.0309339427734258688, 1e-12, "S2pv", "y", ref status);
            Vvd(pv[0, 2], 0.0559466810510877933, 1e-12, "S2pv", "z", ref status);

            Vvd(pv[1, 0], 0.1292270850663260170e-4, 1e-16, "S2pv", "vx", ref status);
            Vvd(pv[1, 1], 0.2652814182060691422e-5, 1e-16, "S2pv", "vy", ref status);
            Vvd(pv[1, 2], 0.2568431853930292259e-5, 1e-16, "S2pv", "vz", ref status);

            Assert.Equal(0, status);
        }
    }
}
