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
        /// Test Bpn2xy function.
        /// </summary>
        /// <remarks>
        /// Extract CIP X,Y coordinates from bias-precession-nutation matrix.
        /// </remarks>
        [Fact]
        public void TestBpn2xy()
        {
            var status = 0;
            var rbpn = new double[3, 3];

            rbpn[0, 0] =  9.999962358680738e-1;
            rbpn[0, 1] = -2.516417057665452e-3;
            rbpn[0, 2] = -1.093569785342370e-3;

            rbpn[1, 0] =  2.516462370370876e-3;
            rbpn[1, 1] =  9.999968329010883e-1;
            rbpn[1, 2] =  4.006159587358310e-5;

            rbpn[2, 0] =  1.093465510215479e-3;
            rbpn[2, 1] = -4.281337229063151e-5;
            rbpn[2, 2] =  9.999994012499173e-1;

            Bpn2xy(rbpn, out var x, out var y);

            Vvd(x,  1.093465510215479e-3, 1e-12, "Bpn2xy", "x", ref status);
            Vvd(y, -4.281337229063151e-5, 1e-12, "Bpn2xy", "y", ref status);

            Assert.Equal(0, status);
        }
    }
}
