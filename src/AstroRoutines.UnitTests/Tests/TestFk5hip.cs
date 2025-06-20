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
        /// Test Fk5hip function.
        /// </summary>
        [Fact]
        public void TestFk5hip()
        {
            var status = 0;

            Fk5hip(out var r5h, out var s5h);

            Vvd(r5h[0, 0], 0.9999999999999928638, 1e-14, "Fk5hip", "11", ref status);
            Vvd(r5h[0, 1], 0.1110223351022919694e-6, 1e-17, "Fk5hip", "12", ref status);
            Vvd(r5h[0, 2], 0.4411803962536558154e-7, 1e-17, "Fk5hip", "13", ref status);
            Vvd(r5h[1, 0], -0.1110223308458746430e-6, 1e-17, "Fk5hip", "21", ref status);
            Vvd(r5h[1, 1], 0.9999999999999891830, 1e-14, "Fk5hip", "22", ref status);
            Vvd(r5h[1, 2], -0.9647792498984142358e-7, 1e-17, "Fk5hip", "23", ref status);
            Vvd(r5h[2, 0], -0.4411805033656962252e-7, 1e-17, "Fk5hip", "31", ref status);
            Vvd(r5h[2, 1], 0.9647792009175314354e-7, 1e-17, "Fk5hip", "32", ref status);
            Vvd(r5h[2, 2], 0.9999999999999943728, 1e-14, "Fk5hip", "33", ref status);
            Vvd(s5h[0], -0.1454441043328607981e-8, 1e-17, "Fk5hip", "s1", ref status);
            Vvd(s5h[1], 0.2908882086657215962e-8, 1e-17, "Fk5hip", "s2", ref status);
            Vvd(s5h[2], 0.3393695767766751955e-8, 1e-17, "Fk5hip", "s3", ref status);

            Assert.Equal(0, status);
        }
    }
}
