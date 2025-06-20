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
        /// Test Cp function.
        /// </summary>
        [Fact]
        public void TestCp()
        {
            var status = 0;
            var p = new double[3];
            var c = new double[3];

            p[0] = 0.3;
            p[1] = 1.2;
            p[2] = -2.5;

            Cp(p, ref c);

            Vvd(c[0], 0.3, 0.0, "Cp", "1", ref status);
            Vvd(c[1], 1.2, 0.0, "Cp", "2", ref status);
            Vvd(c[2], -2.5, 0.0, "Cp", "3", ref status);

            Assert.Equal(0, status);
        }
    }
}
