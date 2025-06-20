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
        /// Test Tf2d function.
        /// </summary>
        [Fact]
        public void TestTf2d()
        {
            var status = 0;

            var j = Tf2d(' ', 23, 55, 10.9, out var d);

            Vvd(d, 0.9966539351851851852, 1e-12, "Tf2d", "d", ref status);
            Viv(j, 0, "Tf2d", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
