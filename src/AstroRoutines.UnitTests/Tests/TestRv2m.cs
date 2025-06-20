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
        /// Test Rv2m function.
        /// </summary>
        [Fact]
        public void TestRv2m()
        {
            var status = 0;

            var w = new double[3];
            var r = new double[3, 3];

            w[0] = 0.0;
            w[1] = 1.41371669;
            w[2] = -1.88495559;

            Rv2m(w, ref r);

            Vvd(r[0, 0], -0.7071067782221119905, 1e-14, "Rv2m", "11", ref status);
            Vvd(r[0, 1], -0.5656854276809129651, 1e-14, "Rv2m", "12", ref status);
            Vvd(r[0, 2], -0.4242640700104211225, 1e-14, "Rv2m", "13", ref status);

            Vvd(r[1, 0], 0.5656854276809129651, 1e-14, "Rv2m", "21", ref status);
            Vvd(r[1, 1], -0.0925483394532274246, 1e-14, "Rv2m", "22", ref status);
            Vvd(r[1, 2], -0.8194112531408833269, 1e-14, "Rv2m", "23", ref status);

            Vvd(r[2, 0], 0.4242640700104211225, 1e-14, "Rv2m", "31", ref status);
            Vvd(r[2, 1], -0.8194112531408833269, 1e-14, "Rv2m", "32", ref status);
            Vvd(r[2, 2], 0.3854415612311154341, 1e-14, "Rv2m", "33", ref status);

            Assert.Equal(0, status);
        }
    }
}
