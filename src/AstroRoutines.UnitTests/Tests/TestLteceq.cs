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
        /// Test Lteceq function.
        /// </summary>
        [Fact]
        public void TestLteceq()
        {
			var status = 0;
            var epj = 2500.0;
            var dl = 1.5;
            var db = 0.6;
            var dr = 0.0;
            var dd = 0.0;

            Lteceq(epj, dl, db, ref dr, ref dd);

            Vvd(dr, 1.275156021861921167, 1e-14, "Lteceq", "dr", ref status);
            Vvd(dd, 0.9966573543519204791, 1e-14, "Lteceq", "dd", ref status);

            Assert.Equal(0, status);
        }
    }
}
