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
        /// Test C2t06a function.
        /// </summary>
        [Fact]
        public void TestC2t06a()
        {
            var status = 0;

            var tta = 2400000.5;
            var ttb = 53736.0;
            var uta = 2400000.5;
            var utb = 53736.0;
            var xp = 2.55060238e-7;
            var yp = 1.860359247e-6;

            C2t06a(tta, ttb, uta, utb, xp, yp, out var rc2t);

            Vvd(rc2t[0, 0], -0.1810332128305897282, 1e-12, "C2t06a", "11", ref status);
            Vvd(rc2t[0, 1], 0.9834769806938592296, 1e-12, "C2t06a", "12", ref status);
            Vvd(rc2t[0, 2], 0.6555550962998436505e-4, 1e-12, "C2t06a", "13", ref status);

            Vvd(rc2t[1, 0], -0.9834768134136214897, 1e-12, "C2t06a", "21", ref status);
            Vvd(rc2t[1, 1], -0.1810332203649130832, 1e-12, "C2t06a", "22", ref status);
            Vvd(rc2t[1, 2], 0.5749800844905594110e-3, 1e-12, "C2t06a", "23", ref status);

            Vvd(rc2t[2, 0], 0.5773474024748545878e-3, 1e-12, "C2t06a", "31", ref status);
            Vvd(rc2t[2, 1], 0.3961816829632690581e-4, 1e-12, "C2t06a", "32", ref status);
            Vvd(rc2t[2, 2], 0.9999998325501747785, 1e-12, "C2t06a", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
