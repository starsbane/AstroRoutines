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
        /// Test Eceq06 function.
        /// </summary>
        [Fact]
        public void TestEceq06()
        {
            var status = 0;
            var date1 = 2456165.5;
            var date2 = 0.401182685;
            double dl = 5.1, db = -0.9, dr = 0, dd = 0;

            Eceq06(date1, date2, dl, db, ref dr, ref dd);

            Vvd(dr, 5.533459733613627767, 1e-14, "Eceq06", "dr", ref status);
            Vvd(dd, -1.246542932554480576, 1e-14, "Eceq06", "dd", ref status);

            Assert.Equal(0, status);
        }
    }
}
