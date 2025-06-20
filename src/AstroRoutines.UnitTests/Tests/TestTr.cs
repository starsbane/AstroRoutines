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
        /// Test Tr function.
        /// </summary>
        [Fact]
        public void TestTr()
        {
            var status = 0;
			
            var r = new double[3, 3];
            var rt = new double[3, 3];

            r[0, 0] = 2.0;
            r[0, 1] = 3.0;
            r[0, 2] = 2.0;

            r[1, 0] = 3.0;
            r[1, 1] = 2.0;
            r[1, 2] = 3.0;

            r[2, 0] = 3.0;
            r[2, 1] = 4.0;
            r[2, 2] = 5.0;

            Tr(r, ref rt);

            Vvd(rt[0, 0], 2.0, 0.0, "Tr", "11", ref status);
            Vvd(rt[0, 1], 3.0, 0.0, "Tr", "12", ref status);
            Vvd(rt[0, 2], 3.0, 0.0, "Tr", "13", ref status);

            Vvd(rt[1, 0], 3.0, 0.0, "Tr", "21", ref status);
            Vvd(rt[1, 1], 2.0, 0.0, "Tr", "22", ref status);
            Vvd(rt[1, 2], 4.0, 0.0, "Tr", "23", ref status);

            Vvd(rt[2, 0], 2.0, 0.0, "Tr", "31", ref status);
            Vvd(rt[2, 1], 3.0, 0.0, "Tr", "32", ref status);
            Vvd(rt[2, 2], 5.0, 0.0, "Tr", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
