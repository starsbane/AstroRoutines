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
        /// Test Rm2v function.
        /// </summary>
        [Fact]
        public void TestRm2v()
        {
            var status = 0;

            var r = new double[3, 3];
            var w = new double[3];

            r[0, 0] = 0.00;
            r[0, 1] = -0.80; 
            r[0, 2] = -0.60;

            r[1, 0] = 0.80; 
            r[1, 1] = -0.36;
            r[1, 2] = 0.48;

            r[2, 0] = 0.60; 
            r[2, 1] = 0.48; 
            r[2, 2] = -0.64;

            Rm2v(r, ref w);

            Vvd(w[0], 0.0, 1e-12, "Rm2v", "1", ref status);
            Vvd(w[1], 1.413716694115406957, 1e-12, "Rm2v", "2", ref status);
            Vvd(w[2], -1.884955592153875943, 1e-12, "Rm2v", "3", ref status);

            Assert.Equal(0, status);
        }
    }
}
