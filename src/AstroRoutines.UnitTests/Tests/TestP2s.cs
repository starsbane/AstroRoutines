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
        /// Test P2s function.
        /// </summary>
        [Fact]
        public void TestP2s()
        {
            var status = 0;
            var p = new double[3];

            p[0] = 100.0;
			p[1] = -50.0;
			p[2] =  25.0;

            P2s(p, out var theta, out var phi, out var r);

            Vvd(theta, -0.4636476090008061162, 1e-12, "P2s", "theta", ref status);
            Vvd(phi, 0.2199879773954594463, 1e-12, "P2s", "phi", ref status);
            Vvd(r, 114.5643923738960002, 1e-9, "P2s", "r", ref status);

            Assert.Equal(0, status);
        }
    }
}
