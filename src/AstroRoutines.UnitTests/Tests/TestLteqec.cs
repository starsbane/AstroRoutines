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
        /// Test Lteqec function.
        /// </summary>
        [Fact]
        public void TestLteqec()
        {
            var status = 0;
            var epj = -1500.0;
            var dr = 1.234;
            var dd = 0.987;

            Lteqec(epj, dr, dd, out var dl, out var db);

            Vvd(dl, 0.5039483649047114859, 1e-14, "Lteqec", "dl", ref status);
            Vvd(db, 0.5848534459726224882, 1e-14, "Lteqec", "db", ref status);

            Assert.Equal(0, status);
        }
    }
}
