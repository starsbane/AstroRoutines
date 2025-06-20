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
        /// Test Gd2gce function.
        /// </summary>
        [Fact]
        public void TestGd2gce()
        {
            var status = 0;
            double a = 6378136.0, f = 0.0033528;
            double e = 3.1, p = -0.5, h = 2500.0;

            var j = Gd2gce(a, f, e, p, h, out var xyz);
            Viv(j, 0, "Gd2gce", "j", ref status);
            Vvd(xyz[0], -5598999.6665116328, 1e-7, "Gd2gce", "1", ref status);
            Vvd(xyz[1], 233011.6351463057189, 1e-7, "Gd2gce", "2", ref status);
            Vvd(xyz[2], -3040909.0517314132, 1e-7, "Gd2gce", "3", ref status);

            Assert.Equal(0, status);
        }
    }
}
