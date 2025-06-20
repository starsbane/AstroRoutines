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
        /// Test Gc2gd function.
        /// </summary>
        [Fact]
        public void TestGc2gd()
        {
            var status = 0;
            double[] xyz = { 2e6, 3e6, 5.244e6 };

            var j = Gc2gd(0, xyz, out var e, out var p, out var h);
            Viv(j, -1, "Gc2gd", "j0", ref status);

            j = Gc2gd(WGS84, xyz, out e, out p, out h);
            Viv(j, 0, "Gc2gd", "j1", ref status);
            Vvd(e, 0.9827937232473290680, 1e-14, "Gc2gd", "e1", ref status);
            Vvd(p, 0.97160184819075459, 1e-14, "Gc2gd", "p1", ref status);
            Vvd(h, 331.4172461426059892, 1e-8, "Gc2gd", "h1", ref status);

            j = Gc2gd(GRS80, xyz, out e, out p, out h);
            Viv(j, 0, "Gc2gd", "j2", ref status);
            Vvd(e, 0.9827937232473290680, 1e-14, "Gc2gd", "e2", ref status);
            Vvd(p, 0.97160184820607853, 1e-14, "Gc2gd", "p2", ref status);
            Vvd(h, 331.41731754844348, 1e-8, "Gc2gd", "h2", ref status);

            j = Gc2gd(WGS72, xyz, out e, out p, out h);
            Viv(j, 0, "Gc2gd", "j3", ref status);
            Vvd(e, 0.9827937232473290680, 1e-14, "Gc2gd", "e3", ref status);
            Vvd(p, 0.9716018181101511937, 1e-14, "Gc2gd", "p3", ref status);
            Vvd(h, 333.2770726130318123, 1e-8, "Gc2gd", "h3", ref status);

            j = Gc2gd(4, xyz, out e, out p, out h);
            Viv(j, -1, "Gc2gd", "j4", ref status);

            Assert.Equal(0, status);
        }
    }
}
