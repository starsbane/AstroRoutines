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
        /// Test Jd2cal function.
        /// </summary>
        [Fact]
        public void TestJd2cal()
        {
            var status = 0;

            var dj1 = 2400000.5;
			var dj2 = 50123.9999;

            var j = Jd2cal(dj1, dj2, out var iy, out var im, out var id, out var fd);

            Viv(iy, 1996, "Jd2cal", "y", ref status);
            Viv(im, 2, "Jd2cal", "m", ref status);
            Viv(id, 10, "Jd2cal", "d", ref status);
            Vvd(fd, 0.9999, 1e-7, "Jd2cal", "fd", ref status);
			
            Viv(j, 0, "Jd2cal", "j", ref status);

            Assert.Equal(0, status);
        }
    }
}
