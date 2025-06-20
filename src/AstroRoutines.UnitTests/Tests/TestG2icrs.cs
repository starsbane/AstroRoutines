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
        /// Test G2icrs function.
        /// </summary>
        [Fact]
        public void TestG2icrs()
        {
            var status = 0;
            var dl = 5.5850536063818546461558105;
            var db = -0.7853981633974483096156608;

            G2icrs(dl, db, out var dr, out var dd);

            Vvd(dr, 5.9338074302227188048671, 1e-14, "G2icrs", "R", ref status);
            Vvd(dd, -1.1784870613579944551541, 1e-14, "G2icrs", "D", ref status);

            Assert.Equal(0, status);
        }
    }
}
