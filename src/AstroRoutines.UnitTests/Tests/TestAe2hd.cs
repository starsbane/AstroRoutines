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
        /// Test Ae2hd function.
        /// </summary>
        /// <remarks>
        /// Converts azimuth and elevation to hour angle and declination.
        /// </remarks>
        [Fact]
        public void TestAe2hd()
        {
            var status = 0;

            var a = 5.5;
            var e = 1.1;
            var p = 0.7;

            Ae2hd(a, e, p, out var h, out var d);

            Vvd(h, 0.5933291115507309663, 1e-14, "Ae2hd", "h", ref status);
            Vvd(d, 0.9613934761647817620, 1e-14, "Ae2hd", "d", ref status);

            Assert.Equal(0, status);
        }
    }
}
