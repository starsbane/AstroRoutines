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
        /// Test Eqec06 function.
        /// </summary>
        [Fact]
        public void TestEqec06()
        {
            var status = 0;
            double date1 = 1234.5, date2 = 2440000.5;
            double dr = 1.234, dd = 0.987, dl = 0, db = 0;

            Eqec06(date1, date2, dr, dd, ref dl, ref db);

            Vvd(dl, 1.342509918994654619, 1e-14, "Eqec06", "dl", ref status);
            Vvd(db, 0.5926215259704608132, 1e-14, "Eqec06", "db", ref status);

            Assert.Equal(0, status);
        }
    }
}
