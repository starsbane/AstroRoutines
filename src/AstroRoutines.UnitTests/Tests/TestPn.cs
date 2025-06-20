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
        /// Test Pn function.
        /// </summary>
        [Fact]
        public void TestPn()
        {
            var p = new double[3];
            var status = 0;

            p[0] = 0.3;
            p[1] = 1.2;
            p[2] = -2.5;

            Pn(p, out var r, out var u);

            Vvd(r, 2.789265136196270604, 1e-12, "Pn", "r", ref status);
            Vvd(u[0], 0.1075552109073112058, 1e-12, "Pn", "u1", ref status);
            Vvd(u[1], 0.4302208436292448232, 1e-12, "Pn", "u2", ref status);
            Vvd(u[2], -0.8962934242275933816, 1e-12, "Pn", "u3", ref status);

            Assert.Equal(0, status);
        }
    }
}
