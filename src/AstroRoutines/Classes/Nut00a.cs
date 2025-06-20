using static System.Math;
using static AstroRoutines.Constants;

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
// Copyright � International Astronomical Union Standards of Fundamental Astronomy (http://www.iausofa.org).
//
namespace AstroRoutines
{
    public static partial class AR
    {
        internal struct Nut00a_LSNMT
        {
            #region coefficients of l,l',F,D,Om 
            public int nl { get; set; }
            public int nlp { get; set; }
            public int nf { get; set; }

            public int nd { get; set; }
            public int nom { get; set; }
            #endregion

            #region longitude sin, t*sin, cos coefficients
            public double sp { get; set; }
            public double spt { get; set; }
            public double cp { get; set; }
            #endregion

            #region obliquity cos, t*cos, sin coefficients
            public double ce { get; set; }
            public double cet { get; set; }
            public double se { get; set; }
            #endregion
        }

        #region Luni-Solar nutation model terms
        internal static readonly Nut00a_LSNMT[] xls = {
/* 1- 10 */
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=0, nd=0, nom=1, sp=-172064161.0, spt=-174666.0, cp=33386.0, ce=92052331.0, cet=9086.0, se=15377.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=2, nd=-2, nom=2, sp=-13170906.0, spt=-1675.0, cp=-13696.0, ce=5730336.0, cet=-3015.0, se=-4587.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=2, nd=0, nom=2, sp=-2276413.0, spt=-234.0, cp=2796.0, ce=978459.0, cet=-485.0, se=1374.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=0, nd=0, nom=2, sp=2074554.0, spt=207.0, cp=-698.0, ce=-897492.0, cet=470.0, se=-291.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=1, nf=0, nd=0, nom=0, sp=1475877.0, spt=-3633.0, cp=11817.0, ce=73871.0, cet=-184.0, se=-1924.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=1, nf=2, nd=-2, nom=2, sp=-516821.0, spt=1226.0, cp=-524.0, ce=224386.0, cet=-677.0, se=-174.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=0, nd=0, nom=0, sp=711159.0, spt=73.0, cp=-872.0, ce=-6750.0, cet=0.0, se=358.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=2, nd=0, nom=1, sp=-387298.0, spt=-367.0, cp=380.0, ce=200728.0, cet=18.0, se=318.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=2, nd=0, nom=2, sp=-301461.0, spt=-36.0, cp=816.0, ce=129025.0, cet=-63.0, se=367.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-1, nf=2, nd=-2, nom=2, sp=215829.0, spt=-494.0, cp=111.0, ce=-95929.0, cet=299.0, se=132.0 },

   /* 11-20 */
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=2, nd=-2, nom=1, sp=128227.0, spt=137.0, cp=181.0, ce=-68982.0, cet=-9.0, se=39.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=2, nd=0, nom=2, sp=123457.0, spt=11.0, cp=19.0, ce=-53311.0, cet=32.0, se=-4.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=0, nd=2, nom=0, sp=156994.0, spt=10.0, cp=-168.0, ce=-1235.0, cet=0.0, se=82.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=0, nd=0, nom=1, sp=63110.0, spt=63.0, cp=27.0, ce=-33228.0, cet=0.0, se=-9.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=0, nd=0, nom=1, sp=-57976.0, spt=-63.0, cp=-189.0, ce=31429.0, cet=0.0, se=-75.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=2, nd=2, nom=2, sp=-59641.0, spt=-11.0, cp=149.0, ce=25543.0, cet=-11.0, se=66.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=2, nd=0, nom=1, sp=-51613.0, spt=-42.0, cp=129.0, ce=26366.0, cet=0.0, se=78.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=2, nd=0, nom=1, sp=45893.0, spt=50.0, cp=31.0, ce=-24236.0, cet=-10.0, se=20.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=0, nd=2, nom=0, sp=63384.0, spt=11.0, cp=-150.0, ce=-1220.0, cet=0.0, se=29.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=2, nd=2, nom=2, sp=-38571.0, spt=-1.0, cp=158.0, ce=16452.0, cet=-11.0, se=68.0 },

   /* 21-30 */
      new Nut00a_LSNMT(){ nl=0, nlp=-2, nf=2, nd=-2, nom=2, sp=32481.0, spt=0.0, cp=0.0, ce=-13870.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=0, nd=2, nom=0, sp=-47722.0, spt=0.0, cp=-18.0, ce=477.0, cet=0.0, se=-25.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=2, nd=0, nom=2, sp=-31046.0, spt=-1.0, cp=131.0, ce=13238.0, cet=-11.0, se=59.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=2, nd=-2, nom=2, sp=28593.0, spt=0.0, cp=-1.0, ce=-12338.0, cet=10.0, se=-3.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=2, nd=0, nom=1, sp=20441.0, spt=21.0, cp=10.0, ce=-10758.0, cet=0.0, se=-3.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=0, nd=0, nom=0, sp=29243.0, spt=0.0, cp=-74.0, ce=-609.0, cet=0.0, se=13.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=2, nd=0, nom=0, sp=25887.0, spt=0.0, cp=-66.0, ce=-550.0, cet=0.0, se=11.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=1, nf=0, nd=0, nom=1, sp=-14053.0, spt=-25.0, cp=79.0, ce=8551.0, cet=-2.0, se=-45.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=0, nd=2, nom=1, sp=15164.0, spt=10.0, cp=11.0, ce=-8001.0, cet=0.0, se=-1.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=2, nf=2, nd=-2, nom=2, sp=-15794.0, spt=72.0, cp=-16.0, ce=6850.0, cet=-42.0, se=-5.0 },

   /* 31-40 */
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=-2, nd=2, nom=0, sp=21783.0, spt=0.0, cp=13.0, ce=-167.0, cet=0.0, se=13.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=0, nd=-2, nom=1, sp=-12873.0, spt=-10.0, cp=-37.0, ce=6953.0, cet=0.0, se=-14.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-1, nf=0, nd=0, nom=1, sp=-12654.0, spt=11.0, cp=63.0, ce=6415.0, cet=0.0, se=26.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=2, nd=2, nom=1, sp=-10204.0, spt=0.0, cp=25.0, ce=5222.0, cet=0.0, se=15.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=2, nf=0, nd=0, nom=0, sp=16707.0, spt=-85.0, cp=-10.0, ce=168.0, cet=-1.0, se=10.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=2, nd=2, nom=2, sp=-7691.0, spt=0.0, cp=44.0, ce=3268.0, cet=0.0, se=19.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=2, nd=0, nom=0, sp=-11024.0, spt=0.0, cp=-14.0, ce=104.0, cet=0.0, se=2.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=1, nf=2, nd=0, nom=2, sp=7566.0, spt=-21.0, cp=-11.0, ce=-3250.0, cet=0.0, se=-5.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=2, nd=2, nom=1, sp=-6637.0, spt=-11.0, cp=25.0, ce=3353.0, cet=0.0, se=14.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-1, nf=2, nd=0, nom=2, sp=-7141.0, spt=21.0, cp=8.0, ce=3070.0, cet=0.0, se=4.0 },

   /* 41-50 */
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=0, nd=2, nom=1, sp=-6302.0, spt=-11.0, cp=2.0, ce=3272.0, cet=0.0, se=4.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=2, nd=-2, nom=1, sp=5800.0, spt=10.0, cp=2.0, ce=-3045.0, cet=0.0, se=-1.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=2, nd=-2, nom=2, sp=6443.0, spt=0.0, cp=-7.0, ce=-2768.0, cet=0.0, se=-4.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=0, nd=2, nom=1, sp=-5774.0, spt=-11.0, cp=-15.0, ce=3041.0, cet=0.0, se=-5.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=2, nd=0, nom=1, sp=-5350.0, spt=0.0, cp=21.0, ce=2695.0, cet=0.0, se=12.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-1, nf=2, nd=-2, nom=1, sp=-4752.0, spt=-11.0, cp=-3.0, ce=2719.0, cet=0.0, se=-3.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=0, nd=-2, nom=1, sp=-4940.0, spt=-11.0, cp=-21.0, ce=2720.0, cet=0.0, se=-9.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=-1, nf=0, nd=2, nom=0, sp=7350.0, spt=0.0, cp=-8.0, ce=-51.0, cet=0.0, se=4.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=0, nd=-2, nom=1, sp=4065.0, spt=0.0, cp=6.0, ce=-2206.0, cet=0.0, se=1.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=0, nd=2, nom=0, sp=6579.0, spt=0.0, cp=-24.0, ce=-199.0, cet=0.0, se=2.0 },

   /* 51-60 */
      new Nut00a_LSNMT(){ nl=0, nlp=1, nf=2, nd=-2, nom=1, sp=3579.0, spt=0.0, cp=5.0, ce=-1900.0, cet=0.0, se=1.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=-1, nf=0, nd=0, nom=0, sp=4725.0, spt=0.0, cp=-6.0, ce=-41.0, cet=0.0, se=3.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=2, nd=0, nom=2, sp=-3075.0, spt=0.0, cp=-2.0, ce=1313.0, cet=0.0, se=-1.0 },
      new Nut00a_LSNMT(){ nl=3, nlp=0, nf=2, nd=0, nom=2, sp=-2904.0, spt=0.0, cp=15.0, ce=1233.0, cet=0.0, se=7.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-1, nf=0, nd=2, nom=0, sp=4348.0, spt=0.0, cp=-10.0, ce=-81.0, cet=0.0, se=2.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=-1, nf=2, nd=0, nom=2, sp=-2878.0, spt=0.0, cp=8.0, ce=1232.0, cet=0.0, se=4.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=0, nd=1, nom=0, sp=-4230.0, spt=0.0, cp=5.0, ce=-20.0, cet=0.0, se=-2.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=-1, nf=2, nd=2, nom=2, sp=-2819.0, spt=0.0, cp=7.0, ce=1207.0, cet=0.0, se=3.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=2, nd=0, nom=0, sp=-4056.0, spt=0.0, cp=5.0, ce=40.0, cet=0.0, se=-2.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-1, nf=2, nd=2, nom=2, sp=-2647.0, spt=0.0, cp=11.0, ce=1129.0, cet=0.0, se=5.0 },

   /* 61-70 */
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=0, nd=0, nom=1, sp=-2294.0, spt=0.0, cp=-10.0, ce=1266.0, cet=0.0, se=-4.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=1, nf=2, nd=0, nom=2, sp=2481.0, spt=0.0, cp=-7.0, ce=-1062.0, cet=0.0, se=-3.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=0, nd=0, nom=1, sp=2179.0, spt=0.0, cp=-2.0, ce=-1129.0, cet=0.0, se=-2.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=1, nf=0, nd=1, nom=0, sp=3276.0, spt=0.0, cp=1.0, ce=-9.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=1, nf=0, nd=0, nom=0, sp=-3389.0, spt=0.0, cp=5.0, ce=35.0, cet=0.0, se=-2.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=2, nd=0, nom=0, sp=3339.0, spt=0.0, cp=-13.0, ce=-107.0, cet=0.0, se=1.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=2, nd=-2, nom=1, sp=-1987.0, spt=0.0, cp=-6.0, ce=1073.0, cet=0.0, se=-2.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=0, nd=0, nom=2, sp=-1981.0, spt=0.0, cp=0.0, ce=854.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=0, nd=1, nom=0, sp=4026.0, spt=0.0, cp=-353.0, ce=-553.0, cet=0.0, se=-139.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=2, nd=1, nom=2, sp=1660.0, spt=0.0, cp=-5.0, ce=-710.0, cet=0.0, se=-2.0 },

   /* 71-80 */
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=2, nd=4, nom=2, sp=-1521.0, spt=0.0, cp=9.0, ce=647.0, cet=0.0, se=4.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=1, nf=0, nd=1, nom=1, sp=1314.0, spt=0.0, cp=0.0, ce=-700.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-2, nf=2, nd=-2, nom=1, sp=-1283.0, spt=0.0, cp=0.0, ce=672.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=2, nd=2, nom=1, sp=-1331.0, spt=0.0, cp=8.0, ce=663.0, cet=0.0, se=4.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=2, nd=2, nom=2, sp=1383.0, spt=0.0, cp=-2.0, ce=-594.0, cet=0.0, se=-2.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=0, nd=0, nom=2, sp=1405.0, spt=0.0, cp=4.0, ce=-610.0, cet=0.0, se=2.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=1, nf=2, nd=-2, nom=2, sp=1290.0, spt=0.0, cp=0.0, ce=-556.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=2, nd=4, nom=2, sp=-1214.0, spt=0.0, cp=5.0, ce=518.0, cet=0.0, se=2.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=4, nd=0, nom=2, sp=1146.0, spt=0.0, cp=-3.0, ce=-490.0, cet=0.0, se=-1.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=2, nd=-2, nom=1, sp=1019.0, spt=0.0, cp=-1.0, ce=-527.0, cet=0.0, se=-1.0 },

   /* 81-90 */
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=2, nd=2, nom=2, sp=-1100.0, spt=0.0, cp=9.0, ce=465.0, cet=0.0, se=4.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=0, nd=2, nom=1, sp=-970.0, spt=0.0, cp=2.0, ce=496.0, cet=0.0, se=1.0 },
      new Nut00a_LSNMT(){ nl=3, nlp=0, nf=0, nd=0, nom=0, sp=1575.0, spt=0.0, cp=-6.0, ce=-50.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=3, nlp=0, nf=2, nd=-2, nom=2, sp=934.0, spt=0.0, cp=-3.0, ce=-399.0, cet=0.0, se=-1.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=4, nd=-2, nom=2, sp=922.0, spt=0.0, cp=-1.0, ce=-395.0, cet=0.0, se=-1.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=1, nf=2, nd=0, nom=1, sp=815.0, spt=0.0, cp=-1.0, ce=-422.0, cet=0.0, se=-1.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=-2, nd=2, nom=1, sp=834.0, spt=0.0, cp=2.0, ce=-440.0, cet=0.0, se=1.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=2, nd=-2, nom=3, sp=1248.0, spt=0.0, cp=0.0, ce=-170.0, cet=0.0, se=1.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=0, nd=4, nom=0, sp=1338.0, spt=0.0, cp=-5.0, ce=-39.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=-2, nd=0, nom=1, sp=716.0, spt=0.0, cp=-2.0, ce=-389.0, cet=0.0, se=-1.0 },

   /* 91-100 */
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=0, nd=4, nom=0, sp=1282.0, spt=0.0, cp=-3.0, ce=-23.0, cet=0.0, se=1.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=-1, nf=0, nd=2, nom=1, sp=742.0, spt=0.0, cp=1.0, ce=-391.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=0, nd=1, nom=1, sp=1020.0, spt=0.0, cp=-25.0, ce=-495.0, cet=0.0, se=-10.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=1, nf=0, nd=0, nom=2, sp=715.0, spt=0.0, cp=-4.0, ce=-326.0, cet=0.0, se=2.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=-2, nd=0, nom=1, sp=-666.0, spt=0.0, cp=-3.0, ce=369.0, cet=0.0, se=-1.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-1, nf=2, nd=0, nom=1, sp=-667.0, spt=0.0, cp=1.0, ce=346.0, cet=0.0, se=1.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=2, nd=-1, nom=2, sp=-704.0, spt=0.0, cp=0.0, ce=304.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=2, nd=4, nom=2, sp=-694.0, spt=0.0, cp=5.0, ce=294.0, cet=0.0, se=2.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=-1, nf=0, nd=2, nom=0, sp=-1014.0, spt=0.0, cp=-1.0, ce=4.0, cet=0.0, se=-1.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=1, nf=0, nd=-2, nom=1, sp=-585.0, spt=0.0, cp=-2.0, ce=316.0, cet=0.0, se=-1.0 },

   /* 101-110 */
      new Nut00a_LSNMT(){ nl=-1, nlp=1, nf=0, nd=2, nom=0, sp=-949.0, spt=0.0, cp=1.0, ce=8.0, cet=0.0, se=-1.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=1, nf=0, nd=1, nom=2, sp=-595.0, spt=0.0, cp=0.0, ce=258.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=-1, nf=0, nd=0, nom=1, sp=528.0, spt=0.0, cp=0.0, ce=-279.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=-1, nf=2, nd=2, nom=2, sp=-590.0, spt=0.0, cp=4.0, ce=252.0, cet=0.0, se=2.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=1, nf=2, nd=2, nom=2, sp=570.0, spt=0.0, cp=-2.0, ce=-244.0, cet=0.0, se=-1.0 },
      new Nut00a_LSNMT(){ nl=3, nlp=0, nf=2, nd=0, nom=1, sp=-502.0, spt=0.0, cp=3.0, ce=250.0, cet=0.0, se=2.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=1, nf=-2, nd=2, nom=0, sp=-875.0, spt=0.0, cp=1.0, ce=29.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=0, nd=-2, nom=1, sp=-492.0, spt=0.0, cp=-3.0, ce=275.0, cet=0.0, se=-1.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=1, nf=2, nd=2, nom=2, sp=535.0, spt=0.0, cp=-2.0, ce=-228.0, cet=0.0, se=-1.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=-1, nf=2, nd=2, nom=1, sp=-467.0, spt=0.0, cp=1.0, ce=240.0, cet=0.0, se=1.0 },

   /* 111-120 */
      new Nut00a_LSNMT(){ nl=0, nlp=-1, nf=0, nd=0, nom=2, sp=591.0, spt=0.0, cp=0.0, ce=-253.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=2, nd=-4, nom=1, sp=-453.0, spt=0.0, cp=-1.0, ce=244.0, cet=0.0, se=-1.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=-2, nd=2, nom=0, sp=766.0, spt=0.0, cp=1.0, ce=9.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-1, nf=2, nd=2, nom=1, sp=-446.0, spt=0.0, cp=2.0, ce=225.0, cet=0.0, se=1.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=-1, nf=2, nd=0, nom=2, sp=-488.0, spt=0.0, cp=2.0, ce=207.0, cet=0.0, se=1.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=0, nd=2, nom=2, sp=-468.0, spt=0.0, cp=0.0, ce=201.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=-1, nf=2, nd=0, nom=1, sp=-421.0, spt=0.0, cp=1.0, ce=216.0, cet=0.0, se=1.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=1, nf=2, nd=0, nom=2, sp=463.0, spt=0.0, cp=0.0, ce=-200.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=1, nf=0, nd=2, nom=0, sp=-673.0, spt=0.0, cp=2.0, ce=14.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-1, nf=-2, nd=2, nom=0, sp=658.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },

   /* 121-130 */
      new Nut00a_LSNMT(){ nl=0, nlp=3, nf=2, nd=-2, nom=2, sp=-438.0, spt=0.0, cp=0.0, ce=188.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=0, nd=1, nom=1, sp=-390.0, spt=0.0, cp=0.0, ce=205.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=2, nd=2, nom=0, sp=639.0, spt=-11.0, cp=-2.0, ce=-19.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=1, nf=2, nd=0, nom=2, sp=412.0, spt=0.0, cp=-2.0, ce=-176.0, cet=0.0, se=-1.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=1, nf=0, nd=0, nom=1, sp=-361.0, spt=0.0, cp=0.0, ce=189.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=1, nf=2, nd=0, nom=1, sp=360.0, spt=0.0, cp=-1.0, ce=-185.0, cet=0.0, se=-1.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=0, nd=2, nom=0, sp=588.0, spt=0.0, cp=-3.0, ce=-24.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=-2, nd=2, nom=0, sp=-578.0, spt=0.0, cp=1.0, ce=5.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=0, nd=2, nom=2, sp=-396.0, spt=0.0, cp=0.0, ce=171.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=1, nf=0, nd=1, nom=0, sp=565.0, spt=0.0, cp=-1.0, ce=-6.0, cet=0.0, se=0.0 },

   /* 131-140 */
      new Nut00a_LSNMT(){ nl=0, nlp=1, nf=0, nd=-2, nom=1, sp=-335.0, spt=0.0, cp=-1.0, ce=184.0, cet=0.0, se=-1.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=2, nd=-2, nom=2, sp=357.0, spt=0.0, cp=1.0, ce=-154.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=0, nd=-1, nom=1, sp=321.0, spt=0.0, cp=1.0, ce=-174.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=1, nf=0, nd=0, nom=1, sp=-301.0, spt=0.0, cp=-1.0, ce=162.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=2, nd=-1, nom=2, sp=-334.0, spt=0.0, cp=0.0, ce=144.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=-1, nf=0, nd=2, nom=0, sp=493.0, spt=0.0, cp=-2.0, ce=-15.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=0, nd=4, nom=0, sp=494.0, spt=0.0, cp=-2.0, ce=-19.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=2, nd=1, nom=2, sp=337.0, spt=0.0, cp=-1.0, ce=-143.0, cet=0.0, se=-1.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=2, nd=1, nom=1, sp=280.0, spt=0.0, cp=-1.0, ce=-144.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=0, nd=-2, nom=2, sp=309.0, spt=0.0, cp=1.0, ce=-134.0, cet=0.0, se=0.0 },

   /* 141-150 */
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=2, nd=4, nom=1, sp=-263.0, spt=0.0, cp=2.0, ce=131.0, cet=0.0, se=1.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=-2, nd=0, nom=1, sp=253.0, spt=0.0, cp=1.0, ce=-138.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=1, nf=2, nd=-2, nom=1, sp=245.0, spt=0.0, cp=0.0, ce=-128.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=2, nd=2, nom=0, sp=416.0, spt=0.0, cp=-2.0, ce=-17.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=2, nd=-1, nom=1, sp=-229.0, spt=0.0, cp=0.0, ce=128.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=2, nd=2, nom=1, sp=231.0, spt=0.0, cp=0.0, ce=-120.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=4, nlp=0, nf=2, nd=0, nom=2, sp=-259.0, spt=0.0, cp=2.0, ce=109.0, cet=0.0, se=1.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=-1, nf=0, nd=0, nom=0, sp=375.0, spt=0.0, cp=-1.0, ce=-8.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=1, nf=2, nd=-2, nom=2, sp=252.0, spt=0.0, cp=0.0, ce=-108.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=1, nf=2, nd=1, nom=2, sp=-245.0, spt=0.0, cp=1.0, ce=104.0, cet=0.0, se=0.0 },

   /* 151-160 */
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=4, nd=-2, nom=2, sp=243.0, spt=0.0, cp=-1.0, ce=-104.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=-1, nf=0, nd=0, nom=1, sp=208.0, spt=0.0, cp=1.0, ce=-112.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=1, nf=0, nd=2, nom=1, sp=199.0, spt=0.0, cp=0.0, ce=-102.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=2, nd=4, nom=1, sp=-208.0, spt=0.0, cp=1.0, ce=105.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=2, nd=0, nom=0, sp=335.0, spt=0.0, cp=-2.0, ce=-14.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=0, nd=1, nom=0, sp=-325.0, spt=0.0, cp=1.0, ce=7.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=0, nd=4, nom=1, sp=-187.0, spt=0.0, cp=0.0, ce=96.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=4, nd=0, nom=1, sp=197.0, spt=0.0, cp=-1.0, ce=-100.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=2, nd=2, nom=1, sp=-192.0, spt=0.0, cp=2.0, ce=94.0, cet=0.0, se=1.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=2, nd=-3, nom=2, sp=-188.0, spt=0.0, cp=0.0, ce=83.0, cet=0.0, se=0.0 },

   /* 161-170 */
      new Nut00a_LSNMT(){ nl=-1, nlp=-2, nf=0, nd=2, nom=0, sp=276.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=1, nf=0, nd=0, nom=0, sp=-286.0, spt=0.0, cp=1.0, ce=6.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=4, nd=0, nom=2, sp=186.0, spt=0.0, cp=-1.0, ce=-79.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=0, nd=0, nom=3, sp=-219.0, spt=0.0, cp=0.0, ce=43.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=3, nf=0, nd=0, nom=0, sp=276.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=2, nd=-4, nom=1, sp=-153.0, spt=0.0, cp=-1.0, ce=84.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-1, nf=0, nd=2, nom=1, sp=-156.0, spt=0.0, cp=0.0, ce=81.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=0, nd=4, nom=1, sp=-154.0, spt=0.0, cp=1.0, ce=78.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=-1, nf=2, nd=4, nom=2, sp=-174.0, spt=0.0, cp=1.0, ce=75.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=2, nd=4, nom=2, sp=-163.0, spt=0.0, cp=2.0, ce=69.0, cet=0.0, se=1.0 },

   /* 171-180 */
      new Nut00a_LSNMT(){ nl=-2, nlp=2, nf=0, nd=2, nom=0, sp=-228.0, spt=0.0, cp=0.0, ce=1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=-1, nf=2, nd=0, nom=1, sp=91.0, spt=0.0, cp=-4.0, ce=-54.0, cet=0.0, se=-2.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=0, nd=2, nom=2, sp=175.0, spt=0.0, cp=0.0, ce=-75.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=-1, nf=2, nd=0, nom=2, sp=-159.0, spt=0.0, cp=0.0, ce=69.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=4, nd=-2, nom=1, sp=141.0, spt=0.0, cp=0.0, ce=-72.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=3, nlp=0, nf=2, nd=-2, nom=1, sp=147.0, spt=0.0, cp=0.0, ce=-75.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=-1, nf=0, nd=2, nom=1, sp=-132.0, spt=0.0, cp=0.0, ce=69.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=0, nd=-1, nom=1, sp=159.0, spt=0.0, cp=-28.0, ce=-54.0, cet=0.0, se=11.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-2, nf=0, nd=2, nom=0, sp=213.0, spt=0.0, cp=0.0, ce=-4.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=0, nd=4, nom=1, sp=123.0, spt=0.0, cp=0.0, ce=-64.0, cet=0.0, se=0.0 },

   /* 181-190 */
      new Nut00a_LSNMT(){ nl=-3, nlp=0, nf=0, nd=0, nom=1, sp=-118.0, spt=0.0, cp=-1.0, ce=66.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=1, nf=2, nd=2, nom=2, sp=144.0, spt=0.0, cp=-1.0, ce=-61.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=2, nd=4, nom=1, sp=-121.0, spt=0.0, cp=1.0, ce=60.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=3, nlp=0, nf=2, nd=2, nom=2, sp=-134.0, spt=0.0, cp=1.0, ce=56.0, cet=0.0, se=1.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=1, nf=2, nd=-2, nom=1, sp=-105.0, spt=0.0, cp=0.0, ce=57.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=0, nd=-4, nom=1, sp=-102.0, spt=0.0, cp=0.0, ce=56.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=0, nd=-2, nom=2, sp=120.0, spt=0.0, cp=0.0, ce=-52.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=2, nd=-4, nom=1, sp=101.0, spt=0.0, cp=0.0, ce=-54.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=1, nf=0, nd=2, nom=1, sp=-113.0, spt=0.0, cp=0.0, ce=59.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=2, nd=-1, nom=1, sp=-106.0, spt=0.0, cp=0.0, ce=61.0, cet=0.0, se=0.0 },

   /* 191-200 */
      new Nut00a_LSNMT(){ nl=0, nlp=-2, nf=2, nd=2, nom=2, sp=-129.0, spt=0.0, cp=1.0, ce=55.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=0, nd=2, nom=1, sp=-114.0, spt=0.0, cp=0.0, ce=57.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=4, nlp=0, nf=2, nd=-2, nom=2, sp=113.0, spt=0.0, cp=-1.0, ce=-49.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=0, nd=-2, nom=2, sp=-102.0, spt=0.0, cp=0.0, ce=44.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=2, nf=0, nd=0, nom=1, sp=-94.0, spt=0.0, cp=0.0, ce=51.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=0, nd=-4, nom=1, sp=-100.0, spt=0.0, cp=-1.0, ce=56.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=2, nf=2, nd=-2, nom=1, sp=87.0, spt=0.0, cp=0.0, ce=-47.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-3, nlp=0, nf=0, nd=4, nom=0, sp=161.0, spt=0.0, cp=0.0, ce=-1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=1, nf=2, nd=0, nom=1, sp=96.0, spt=0.0, cp=0.0, ce=-50.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=-1, nf=0, nd=4, nom=0, sp=151.0, spt=0.0, cp=-1.0, ce=-5.0, cet=0.0, se=0.0 },

   /* 201-210 */
      new Nut00a_LSNMT(){ nl=-1, nlp=-2, nf=2, nd=2, nom=2, sp=-104.0, spt=0.0, cp=0.0, ce=44.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=-1, nf=2, nd=4, nom=2, sp=-110.0, spt=0.0, cp=0.0, ce=48.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=-1, nf=2, nd=2, nom=1, sp=-100.0, spt=0.0, cp=1.0, ce=50.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=1, nf=0, nd=2, nom=0, sp=92.0, spt=0.0, cp=-5.0, ce=12.0, cet=0.0, se=-2.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=1, nf=2, nd=0, nom=1, sp=82.0, spt=0.0, cp=0.0, ce=-45.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=1, nf=0, nd=-2, nom=1, sp=82.0, spt=0.0, cp=0.0, ce=-45.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-3, nlp=0, nf=2, nd=0, nom=1, sp=-78.0, spt=0.0, cp=0.0, ce=41.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=2, nd=-2, nom=1, sp=-77.0, spt=0.0, cp=0.0, ce=43.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=1, nf=0, nd=2, nom=2, sp=2.0, spt=0.0, cp=0.0, ce=54.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-1, nf=2, nd=-1, nom=2, sp=94.0, spt=0.0, cp=0.0, ce=-40.0, cet=0.0, se=0.0 },

   /* 211-220 */
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=4, nd=-2, nom=2, sp=-93.0, spt=0.0, cp=0.0, ce=40.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-2, nf=2, nd=0, nom=2, sp=-83.0, spt=0.0, cp=10.0, ce=40.0, cet=0.0, se=-2.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=2, nd=1, nom=2, sp=83.0, spt=0.0, cp=0.0, ce=-36.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=0, nd=0, nom=2, sp=-91.0, spt=0.0, cp=0.0, ce=39.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=2, nd=0, nom=3, sp=128.0, spt=0.0, cp=0.0, ce=-1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=4, nd=0, nom=2, sp=-79.0, spt=0.0, cp=0.0, ce=34.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=-2, nd=0, nom=1, sp=-83.0, spt=0.0, cp=0.0, ce=47.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=1, nf=2, nd=2, nom=1, sp=84.0, spt=0.0, cp=0.0, ce=-44.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=3, nlp=0, nf=0, nd=0, nom=1, sp=83.0, spt=0.0, cp=0.0, ce=-43.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=2, nd=3, nom=2, sp=91.0, spt=0.0, cp=0.0, ce=-39.0, cet=0.0, se=0.0 },

   /* 221-230 */
      new Nut00a_LSNMT(){ nl=2, nlp=-1, nf=2, nd=0, nom=1, sp=-77.0, spt=0.0, cp=0.0, ce=39.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=1, nf=2, nd=2, nom=1, sp=84.0, spt=0.0, cp=0.0, ce=-43.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-1, nf=2, nd=4, nom=2, sp=-92.0, spt=0.0, cp=1.0, ce=39.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=-1, nf=2, nd=2, nom=2, sp=-92.0, spt=0.0, cp=1.0, ce=39.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=2, nf=-2, nd=2, nom=0, sp=-94.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=-1, nf=2, nd=-1, nom=1, sp=68.0, spt=0.0, cp=0.0, ce=-36.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-2, nf=0, nd=0, nom=1, sp=-61.0, spt=0.0, cp=0.0, ce=32.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=2, nd=-4, nom=2, sp=71.0, spt=0.0, cp=0.0, ce=-31.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=-1, nf=0, nd=-2, nom=1, sp=62.0, spt=0.0, cp=0.0, ce=-34.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=-1, nf=2, nd=0, nom=1, sp=-63.0, spt=0.0, cp=0.0, ce=33.0, cet=0.0, se=0.0 },

   /* 231-240 */
      new Nut00a_LSNMT(){ nl=1, nlp=-1, nf=2, nd=-2, nom=2, sp=-73.0, spt=0.0, cp=0.0, ce=32.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=-1, nf=0, nd=4, nom=0, sp=115.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=0, nd=3, nom=0, sp=-103.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=-1, nf=2, nd=2, nom=2, sp=63.0, spt=0.0, cp=0.0, ce=-28.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=2, nf=2, nd=0, nom=2, sp=74.0, spt=0.0, cp=0.0, ce=-32.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=1, nf=0, nd=2, nom=0, sp=-103.0, spt=0.0, cp=-3.0, ce=3.0, cet=0.0, se=-1.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=2, nd=-1, nom=2, sp=-69.0, spt=0.0, cp=0.0, ce=30.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=2, nd=1, nom=1, sp=57.0, spt=0.0, cp=0.0, ce=-29.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=4, nlp=0, nf=0, nd=0, nom=0, sp=94.0, spt=0.0, cp=0.0, ce=-4.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=1, nf=2, nd=0, nom=1, sp=64.0, spt=0.0, cp=0.0, ce=-33.0, cet=0.0, se=0.0 },

   /* 241-250 */
      new Nut00a_LSNMT(){ nl=3, nlp=-1, nf=2, nd=0, nom=2, sp=-63.0, spt=0.0, cp=0.0, ce=26.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=2, nf=0, nd=2, nom=1, sp=-38.0, spt=0.0, cp=0.0, ce=20.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=2, nd=-3, nom=1, sp=-43.0, spt=0.0, cp=0.0, ce=24.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=1, nf=2, nd=-4, nom=1, sp=-45.0, spt=0.0, cp=0.0, ce=23.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=-1, nf=2, nd=-2, nom=1, sp=47.0, spt=0.0, cp=0.0, ce=-24.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-1, nf=0, nd=-1, nom=1, sp=-48.0, spt=0.0, cp=0.0, ce=25.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-1, nf=0, nd=-2, nom=1, sp=45.0, spt=0.0, cp=0.0, ce=-26.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=0, nd=0, nom=2, sp=56.0, spt=0.0, cp=0.0, ce=-25.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=-2, nd=2, nom=0, sp=88.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=-2, nd=4, nom=0, sp=-75.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },

   /* 251-260 */
      new Nut00a_LSNMT(){ nl=1, nlp=-2, nf=0, nd=0, nom=0, sp=85.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=1, nf=0, nd=1, nom=1, sp=49.0, spt=0.0, cp=0.0, ce=-26.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=2, nf=0, nd=2, nom=0, sp=-74.0, spt=0.0, cp=-3.0, ce=-1.0, cet=0.0, se=-1.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=-1, nf=2, nd=-2, nom=1, sp=-39.0, spt=0.0, cp=0.0, ce=21.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=2, nf=2, nd=-2, nom=2, sp=45.0, spt=0.0, cp=0.0, ce=-20.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=-1, nf=2, nd=-2, nom=2, sp=51.0, spt=0.0, cp=0.0, ce=-22.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=2, nd=-1, nom=1, sp=-40.0, spt=0.0, cp=0.0, ce=21.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=1, nf=2, nd=-2, nom=1, sp=41.0, spt=0.0, cp=0.0, ce=-21.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=0, nd=-2, nom=1, sp=-42.0, spt=0.0, cp=0.0, ce=24.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=-2, nf=2, nd=0, nom=2, sp=-51.0, spt=0.0, cp=0.0, ce=22.0, cet=0.0, se=0.0 },

   /* 261-270 */
      new Nut00a_LSNMT(){ nl=0, nlp=1, nf=2, nd=1, nom=1, sp=-42.0, spt=0.0, cp=0.0, ce=22.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=4, nd=-2, nom=1, sp=39.0, spt=0.0, cp=0.0, ce=-21.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=4, nd=2, nom=2, sp=46.0, spt=0.0, cp=0.0, ce=-18.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=1, nf=2, nd=1, nom=2, sp=-53.0, spt=0.0, cp=0.0, ce=22.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=0, nd=4, nom=0, sp=82.0, spt=0.0, cp=0.0, ce=-4.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=2, nd=2, nom=0, sp=81.0, spt=0.0, cp=-1.0, ce=-4.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=2, nd=1, nom=2, sp=47.0, spt=0.0, cp=0.0, ce=-19.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=3, nlp=1, nf=2, nd=0, nom=2, sp=53.0, spt=0.0, cp=0.0, ce=-23.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=4, nlp=0, nf=2, nd=0, nom=1, sp=-45.0, spt=0.0, cp=0.0, ce=22.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=-1, nf=2, nd=0, nom=0, sp=-44.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },

   /* 271-280 */
      new Nut00a_LSNMT(){ nl=0, nlp=1, nf=-2, nd=2, nom=1, sp=-33.0, spt=0.0, cp=0.0, ce=16.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=-2, nd=1, nom=0, sp=-61.0, spt=0.0, cp=0.0, ce=1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-1, nf=-2, nd=2, nom=1, sp=28.0, spt=0.0, cp=0.0, ce=-15.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=-1, nf=0, nd=-2, nom=1, sp=-38.0, spt=0.0, cp=0.0, ce=19.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=2, nd=-1, nom=2, sp=-33.0, spt=0.0, cp=0.0, ce=21.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=2, nd=-3, nom=2, sp=-60.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=1, nf=2, nd=-2, nom=3, sp=48.0, spt=0.0, cp=0.0, ce=-10.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=2, nd=-3, nom=1, sp=27.0, spt=0.0, cp=0.0, ce=-14.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=-2, nd=2, nom=1, sp=38.0, spt=0.0, cp=0.0, ce=-20.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=2, nd=-4, nom=2, sp=31.0, spt=0.0, cp=0.0, ce=-13.0, cet=0.0, se=0.0 },

   /* 281-290 */
      new Nut00a_LSNMT(){ nl=-2, nlp=1, nf=0, nd=0, nom=1, sp=-29.0, spt=0.0, cp=0.0, ce=15.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=0, nd=-1, nom=1, sp=28.0, spt=0.0, cp=0.0, ce=-15.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=2, nd=-4, nom=2, sp=-32.0, spt=0.0, cp=0.0, ce=15.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=4, nd=-4, nom=4, sp=45.0, spt=0.0, cp=0.0, ce=-8.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=4, nd=-4, nom=2, sp=-44.0, spt=0.0, cp=0.0, ce=19.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=-2, nf=0, nd=2, nom=1, sp=28.0, spt=0.0, cp=0.0, ce=-15.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=0, nd=3, nom=0, sp=-51.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=-2, nd=2, nom=1, sp=-36.0, spt=0.0, cp=0.0, ce=20.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-3, nlp=0, nf=2, nd=2, nom=2, sp=44.0, spt=0.0, cp=0.0, ce=-19.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-3, nlp=0, nf=2, nd=2, nom=1, sp=26.0, spt=0.0, cp=0.0, ce=-14.0, cet=0.0, se=0.0 },

   /* 291-300 */
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=2, nd=2, nom=0, sp=-60.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=-1, nf=0, nd=0, nom=1, sp=35.0, spt=0.0, cp=0.0, ce=-18.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=1, nf=2, nd=2, nom=2, sp=-27.0, spt=0.0, cp=0.0, ce=11.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=1, nf=0, nd=1, nom=0, sp=47.0, spt=0.0, cp=0.0, ce=-1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=1, nf=4, nd=-2, nom=2, sp=36.0, spt=0.0, cp=0.0, ce=-15.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=1, nf=0, nd=-2, nom=1, sp=-36.0, spt=0.0, cp=0.0, ce=20.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=0, nd=-4, nom=1, sp=-35.0, spt=0.0, cp=0.0, ce=19.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=-1, nf=0, nd=2, nom=1, sp=-37.0, spt=0.0, cp=0.0, ce=19.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=1, nf=0, nd=2, nom=1, sp=32.0, spt=0.0, cp=0.0, ce=-16.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=2, nf=2, nd=2, nom=2, sp=35.0, spt=0.0, cp=0.0, ce=-14.0, cet=0.0, se=0.0 },

   /* 301-310 */
      new Nut00a_LSNMT(){ nl=3, nlp=1, nf=2, nd=-2, nom=2, sp=32.0, spt=0.0, cp=0.0, ce=-13.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-1, nf=0, nd=4, nom=0, sp=65.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=-1, nf=0, nd=2, nom=0, sp=47.0, spt=0.0, cp=0.0, ce=-1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=4, nd=0, nom=1, sp=32.0, spt=0.0, cp=0.0, ce=-16.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=4, nd=-2, nom=2, sp=37.0, spt=0.0, cp=0.0, ce=-16.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=-1, nf=2, nd=4, nom=1, sp=-30.0, spt=0.0, cp=0.0, ce=15.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=0, nd=4, nom=1, sp=-32.0, spt=0.0, cp=0.0, ce=16.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=-2, nf=2, nd=2, nom=2, sp=-31.0, spt=0.0, cp=0.0, ce=13.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=2, nd=3, nom=2, sp=37.0, spt=0.0, cp=0.0, ce=-16.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=1, nf=2, nd=4, nom=2, sp=31.0, spt=0.0, cp=0.0, ce=-13.0, cet=0.0, se=0.0 },

   /* 311-320 */
      new Nut00a_LSNMT(){ nl=3, nlp=0, nf=0, nd=2, nom=0, sp=49.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=4, nd=2, nom=2, sp=32.0, spt=0.0, cp=0.0, ce=-13.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=1, nf=2, nd=2, nom=1, sp=23.0, spt=0.0, cp=0.0, ce=-12.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=2, nd=6, nom=2, sp=-43.0, spt=0.0, cp=0.0, ce=18.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=1, nf=2, nd=2, nom=2, sp=26.0, spt=0.0, cp=0.0, ce=-11.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=2, nd=6, nom=2, sp=-32.0, spt=0.0, cp=0.0, ce=14.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=2, nd=4, nom=1, sp=-29.0, spt=0.0, cp=0.0, ce=14.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=2, nd=4, nom=2, sp=-27.0, spt=0.0, cp=0.0, ce=12.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=1, nf=-2, nd=1, nom=0, sp=30.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-3, nlp=1, nf=2, nd=1, nom=2, sp=-11.0, spt=0.0, cp=0.0, ce=5.0, cet=0.0, se=0.0 },

   /* 321-330 */
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=-2, nd=0, nom=2, sp=-21.0, spt=0.0, cp=0.0, ce=10.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=0, nd=1, nom=2, sp=-34.0, spt=0.0, cp=0.0, ce=15.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-4, nlp=0, nf=2, nd=2, nom=1, sp=-10.0, spt=0.0, cp=0.0, ce=6.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=-1, nf=0, nd=1, nom=0, sp=-36.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=-2, nd=2, nom=2, sp=-9.0, spt=0.0, cp=0.0, ce=4.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=0, nd=-1, nom=2, sp=-12.0, spt=0.0, cp=0.0, ce=5.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-1, nf=2, nd=-2, nom=3, sp=-21.0, spt=0.0, cp=0.0, ce=5.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=1, nf=2, nd=0, nom=0, sp=-29.0, spt=0.0, cp=0.0, ce=-1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=2, nd=-2, nom=4, sp=-15.0, spt=0.0, cp=0.0, ce=3.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=-2, nf=0, nd=2, nom=0, sp=-20.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },

   /* 331-340 */
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=-2, nd=4, nom=0, sp=28.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=-2.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-2, nf=-2, nd=2, nom=0, sp=17.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=2, nf=0, nd=-2, nom=1, sp=-22.0, spt=0.0, cp=0.0, ce=12.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=3, nlp=0, nf=0, nd=-4, nom=1, sp=-14.0, spt=0.0, cp=0.0, ce=7.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=1, nf=2, nd=-2, nom=2, sp=24.0, spt=0.0, cp=0.0, ce=-11.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=-1, nf=2, nd=-4, nom=1, sp=11.0, spt=0.0, cp=0.0, ce=-6.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=1, nf=0, nd=-2, nom=2, sp=14.0, spt=0.0, cp=0.0, ce=-6.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-3, nlp=0, nf=2, nd=0, nom=0, sp=24.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-3, nlp=0, nf=2, nd=0, nom=2, sp=18.0, spt=0.0, cp=0.0, ce=-8.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=0, nd=1, nom=0, sp=-38.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },

   /* 341-350 */
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=-2, nd=1, nom=0, sp=-31.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-3, nlp=0, nf=0, nd=2, nom=1, sp=-16.0, spt=0.0, cp=0.0, ce=8.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=-1, nf=-2, nd=2, nom=0, sp=29.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=1, nf=2, nd=-4, nom=1, sp=-18.0, spt=0.0, cp=0.0, ce=10.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=1, nf=0, nd=-4, nom=1, sp=-10.0, spt=0.0, cp=0.0, ce=5.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=2, nf=0, nd=-2, nom=1, sp=-17.0, spt=0.0, cp=0.0, ce=10.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=0, nd=-3, nom=1, sp=9.0, spt=0.0, cp=0.0, ce=-4.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=2, nd=-2, nom=2, sp=16.0, spt=0.0, cp=0.0, ce=-6.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=-1, nf=0, nd=0, nom=1, sp=22.0, spt=0.0, cp=0.0, ce=-12.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-4, nlp=0, nf=0, nd=2, nom=0, sp=20.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },

   /* 351-360 */
      new Nut00a_LSNMT(){ nl=1, nlp=1, nf=0, nd=-4, nom=1, sp=-13.0, spt=0.0, cp=0.0, ce=6.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=2, nd=-4, nom=1, sp=-17.0, spt=0.0, cp=0.0, ce=9.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=4, nd=-4, nom=1, sp=-14.0, spt=0.0, cp=0.0, ce=8.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=3, nf=2, nd=-2, nom=2, sp=0.0, spt=0.0, cp=0.0, ce=-7.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-3, nlp=-1, nf=0, nd=4, nom=0, sp=14.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-3, nlp=0, nf=0, nd=4, nom=1, sp=19.0, spt=0.0, cp=0.0, ce=-10.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=-1, nf=-2, nd=2, nom=0, sp=-34.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=-1, nf=0, nd=2, nom=2, sp=-20.0, spt=0.0, cp=0.0, ce=8.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=-2, nf=0, nd=0, nom=1, sp=9.0, spt=0.0, cp=0.0, ce=-5.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=-1, nf=0, nd=0, nom=2, sp=-18.0, spt=0.0, cp=0.0, ce=7.0, cet=0.0, se=0.0 },

   /* 361-370 */
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=0, nd=1, nom=2, sp=13.0, spt=0.0, cp=0.0, ce=-6.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=-1, nf=2, nd=0, nom=0, sp=17.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=-2, nf=2, nd=-2, nom=2, sp=-12.0, spt=0.0, cp=0.0, ce=5.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-1, nf=2, nd=-1, nom=1, sp=15.0, spt=0.0, cp=0.0, ce=-8.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=2, nd=0, nom=3, sp=-11.0, spt=0.0, cp=0.0, ce=3.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=1, nf=0, nd=0, nom=2, sp=13.0, spt=0.0, cp=0.0, ce=-5.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=1, nf=2, nd=0, nom=0, sp=-18.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=2, nf=0, nd=0, nom=0, sp=-35.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=2, nf=2, nd=0, nom=2, sp=9.0, spt=0.0, cp=0.0, ce=-4.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=4, nd=-2, nom=1, sp=-19.0, spt=0.0, cp=0.0, ce=10.0, cet=0.0, se=0.0 },

   /* 371-380 */
      new Nut00a_LSNMT(){ nl=3, nlp=0, nf=2, nd=-4, nom=2, sp=-26.0, spt=0.0, cp=0.0, ce=11.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=2, nf=2, nd=-2, nom=1, sp=8.0, spt=0.0, cp=0.0, ce=-4.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=4, nd=-4, nom=2, sp=-10.0, spt=0.0, cp=0.0, ce=4.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=-1, nf=0, nd=4, nom=1, sp=10.0, spt=0.0, cp=0.0, ce=-6.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-1, nf=0, nd=2, nom=2, sp=-21.0, spt=0.0, cp=0.0, ce=9.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=1, nf=0, nd=4, nom=0, sp=-15.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=-1, nf=2, nd=2, nom=1, sp=9.0, spt=0.0, cp=0.0, ce=-5.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=-2, nd=2, nom=0, sp=-29.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=0, nd=1, nom=1, sp=-19.0, spt=0.0, cp=0.0, ce=10.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=1, nf=0, nd=2, nom=2, sp=12.0, spt=0.0, cp=0.0, ce=-5.0, cet=0.0, se=0.0 },

   /* 381-390 */
      new Nut00a_LSNMT(){ nl=1, nlp=-1, nf=2, nd=-1, nom=2, sp=22.0, spt=0.0, cp=0.0, ce=-9.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=4, nd=0, nom=1, sp=-10.0, spt=0.0, cp=0.0, ce=5.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=1, nf=0, nd=0, nom=1, sp=-20.0, spt=0.0, cp=0.0, ce=11.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=1, nf=2, nd=0, nom=0, sp=-20.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-1, nf=4, nd=-2, nom=2, sp=-17.0, spt=0.0, cp=0.0, ce=7.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=4, nd=-2, nom=4, sp=15.0, spt=0.0, cp=0.0, ce=-3.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=2, nf=2, nd=0, nom=1, sp=8.0, spt=0.0, cp=0.0, ce=-4.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-3, nlp=0, nf=0, nd=6, nom=0, sp=14.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=-1, nf=0, nd=4, nom=1, sp=-12.0, spt=0.0, cp=0.0, ce=6.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=-2, nf=0, nd=2, nom=0, sp=25.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },

   /* 391-400 */
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=0, nd=4, nom=2, sp=-13.0, spt=0.0, cp=0.0, ce=6.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=-2, nf=2, nd=2, nom=1, sp=-14.0, spt=0.0, cp=0.0, ce=8.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=0, nd=-2, nom=2, sp=13.0, spt=0.0, cp=0.0, ce=-5.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=-2, nd=-2, nom=1, sp=-17.0, spt=0.0, cp=0.0, ce=9.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=-2, nd=-2, nom=1, sp=-12.0, spt=0.0, cp=0.0, ce=6.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=-2, nd=0, nom=1, sp=-10.0, spt=0.0, cp=0.0, ce=5.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=0, nd=3, nom=1, sp=10.0, spt=0.0, cp=0.0, ce=-6.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=0, nd=3, nom=0, sp=-15.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=1, nf=0, nd=4, nom=0, sp=-22.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=-1, nf=2, nd=2, nom=0, sp=28.0, spt=0.0, cp=0.0, ce=-1.0, cet=0.0, se=0.0 },

   /* 401-410 */
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=2, nd=3, nom=2, sp=15.0, spt=0.0, cp=0.0, ce=-7.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=0, nd=2, nom=2, sp=23.0, spt=0.0, cp=0.0, ce=-10.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-1, nf=2, nd=1, nom=2, sp=12.0, spt=0.0, cp=0.0, ce=-5.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=3, nlp=-1, nf=0, nd=0, nom=0, sp=29.0, spt=0.0, cp=0.0, ce=-1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=0, nd=1, nom=0, sp=-25.0, spt=0.0, cp=0.0, ce=1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=-1, nf=2, nd=0, nom=0, sp=22.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=2, nd=1, nom=0, sp=-18.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=2, nd=0, nom=3, sp=15.0, spt=0.0, cp=0.0, ce=3.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=3, nlp=1, nf=0, nd=0, nom=0, sp=-23.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=3, nlp=-1, nf=2, nd=-2, nom=2, sp=12.0, spt=0.0, cp=0.0, ce=-5.0, cet=0.0, se=0.0 },

   /* 411-420 */
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=2, nd=-1, nom=1, sp=-8.0, spt=0.0, cp=0.0, ce=4.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=1, nf=2, nd=0, nom=0, sp=-19.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=4, nd=-1, nom=2, sp=-10.0, spt=0.0, cp=0.0, ce=4.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=2, nf=2, nd=0, nom=2, sp=21.0, spt=0.0, cp=0.0, ce=-9.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=0, nd=6, nom=0, sp=23.0, spt=0.0, cp=0.0, ce=-1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-1, nf=0, nd=4, nom=1, sp=-16.0, spt=0.0, cp=0.0, ce=8.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=-1, nf=2, nd=4, nom=1, sp=-19.0, spt=0.0, cp=0.0, ce=9.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-2, nf=2, nd=2, nom=1, sp=-22.0, spt=0.0, cp=0.0, ce=10.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-1, nf=2, nd=2, nom=0, sp=27.0, spt=0.0, cp=0.0, ce=-1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=2, nd=3, nom=1, sp=16.0, spt=0.0, cp=0.0, ce=-8.0, cet=0.0, se=0.0 },

   /* 421-430 */
      new Nut00a_LSNMT(){ nl=-2, nlp=1, nf=2, nd=4, nom=2, sp=19.0, spt=0.0, cp=0.0, ce=-8.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=0, nd=2, nom=2, sp=9.0, spt=0.0, cp=0.0, ce=-4.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=-2, nf=2, nd=0, nom=2, sp=-9.0, spt=0.0, cp=0.0, ce=4.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=1, nf=2, nd=3, nom=2, sp=-9.0, spt=0.0, cp=0.0, ce=4.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=3, nlp=0, nf=2, nd=-1, nom=2, sp=-8.0, spt=0.0, cp=0.0, ce=4.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=4, nlp=0, nf=2, nd=-2, nom=1, sp=18.0, spt=0.0, cp=0.0, ce=-9.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=0, nd=6, nom=0, sp=16.0, spt=0.0, cp=0.0, ce=-1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=-2, nf=2, nd=4, nom=2, sp=-10.0, spt=0.0, cp=0.0, ce=4.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-3, nlp=0, nf=2, nd=6, nom=2, sp=-23.0, spt=0.0, cp=0.0, ce=9.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=2, nd=4, nom=0, sp=16.0, spt=0.0, cp=0.0, ce=-1.0, cet=0.0, se=0.0 },

   /* 431-440 */
      new Nut00a_LSNMT(){ nl=3, nlp=0, nf=0, nd=2, nom=1, sp=-12.0, spt=0.0, cp=0.0, ce=6.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=3, nlp=-1, nf=2, nd=0, nom=1, sp=-8.0, spt=0.0, cp=0.0, ce=4.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=3, nlp=0, nf=2, nd=0, nom=0, sp=30.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=4, nd=0, nom=2, sp=24.0, spt=0.0, cp=0.0, ce=-10.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=5, nlp=0, nf=2, nd=-2, nom=2, sp=10.0, spt=0.0, cp=0.0, ce=-4.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-1, nf=2, nd=4, nom=1, sp=-16.0, spt=0.0, cp=0.0, ce=7.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=-1, nf=2, nd=2, nom=1, sp=-16.0, spt=0.0, cp=0.0, ce=7.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=1, nf=2, nd=4, nom=2, sp=17.0, spt=0.0, cp=0.0, ce=-7.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=-1, nf=2, nd=4, nom=2, sp=-24.0, spt=0.0, cp=0.0, ce=10.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=3, nlp=-1, nf=2, nd=2, nom=2, sp=-12.0, spt=0.0, cp=0.0, ce=5.0, cet=0.0, se=0.0 },

   /* 441-450 */
      new Nut00a_LSNMT(){ nl=3, nlp=0, nf=2, nd=2, nom=1, sp=-24.0, spt=0.0, cp=0.0, ce=11.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=5, nlp=0, nf=2, nd=0, nom=2, sp=-23.0, spt=0.0, cp=0.0, ce=9.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=2, nd=6, nom=2, sp=-13.0, spt=0.0, cp=0.0, ce=5.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=4, nlp=0, nf=2, nd=2, nom=2, sp=-15.0, spt=0.0, cp=0.0, ce=7.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-1, nf=1, nd=-1, nom=1, sp=0.0, spt=0.0, cp=-1988.0, ce=0.0, cet=0.0, se=-1679.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=1, nd=0, nom=3, sp=0.0, spt=0.0, cp=-63.0, ce=0.0, cet=0.0, se=-27.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-2, nf=2, nd=-2, nom=3, sp=-4.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=-1, nd=0, nom=1, sp=0.0, spt=0.0, cp=5.0, ce=0.0, cet=0.0, se=4.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=-2, nf=0, nd=-2, nom=1, sp=5.0, spt=0.0, cp=0.0, ce=-3.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=1, nd=0, nom=2, sp=0.0, spt=0.0, cp=364.0, ce=0.0, cet=0.0, se=176.0 },

   /* 451-460 */
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=1, nd=0, nom=1, sp=0.0, spt=0.0, cp=-1044.0, ce=0.0, cet=0.0, se=-891.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=-1, nf=2, nd=-1, nom=2, sp=-3.0, spt=0.0, cp=0.0, ce=1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=2, nf=0, nd=2, nom=2, sp=4.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=1, nd=0, nom=0, sp=0.0, spt=0.0, cp=330.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-4, nlp=1, nf=2, nd=2, nom=2, sp=5.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-3, nlp=0, nf=2, nd=1, nom=1, sp=3.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=-1, nf=2, nd=0, nom=2, sp=-3.0, spt=0.0, cp=0.0, ce=1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=-2, nd=1, nom=1, sp=-5.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=-1, nf=-2, nd=0, nom=1, sp=3.0, spt=0.0, cp=0.0, ce=-1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-4, nlp=0, nf=2, nd=2, nom=0, sp=3.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },

   /* 461-470 */
      new Nut00a_LSNMT(){ nl=-3, nlp=1, nf=0, nd=3, nom=0, sp=3.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=-1, nd=2, nom=0, sp=0.0, spt=0.0, cp=5.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-2, nf=0, nd=0, nom=2, sp=0.0, spt=0.0, cp=0.0, ce=1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-2, nf=0, nd=0, nom=2, sp=4.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-3, nlp=0, nf=0, nd=3, nom=0, sp=6.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=-1, nf=0, nd=2, nom=2, sp=5.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=-2, nd=3, nom=0, sp=-7.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-4, nlp=0, nf=0, nd=4, nom=0, sp=-12.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=1, nf=-2, nd=0, nom=1, sp=5.0, spt=0.0, cp=0.0, ce=-3.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=-1, nf=0, nd=-2, nom=2, sp=3.0, spt=0.0, cp=0.0, ce=-1.0, cet=0.0, se=0.0 },

   /* 471-480 */
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=1, nd=-1, nom=0, sp=-5.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=2, nf=0, nd=1, nom=0, sp=3.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=1, nf=2, nd=0, nom=2, sp=-7.0, spt=0.0, cp=0.0, ce=3.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=1, nf=0, nd=-1, nom=1, sp=7.0, spt=0.0, cp=0.0, ce=-4.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=1, nd=-2, nom=1, sp=0.0, spt=0.0, cp=-12.0, ce=0.0, cet=0.0, se=-10.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=2, nf=0, nd=0, nom=2, sp=4.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=-1, nf=2, nd=-3, nom=1, sp=3.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=1, nf=2, nd=-1, nom=1, sp=-3.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=4, nd=-2, nom=2, sp=-7.0, spt=0.0, cp=0.0, ce=3.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=4, nd=-2, nom=1, sp=-4.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },

   /* 481-490 */
      new Nut00a_LSNMT(){ nl=-2, nlp=-2, nf=0, nd=2, nom=1, sp=-3.0, spt=0.0, cp=0.0, ce=1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=-2, nd=4, nom=0, sp=0.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=2, nf=2, nd=-4, nom=1, sp=-3.0, spt=0.0, cp=0.0, ce=1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=1, nf=2, nd=-4, nom=2, sp=7.0, spt=0.0, cp=0.0, ce=-3.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=2, nf=2, nd=-2, nom=1, sp=-4.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=0, nd=-3, nom=1, sp=4.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=2, nf=0, nd=0, nom=1, sp=-5.0, spt=0.0, cp=0.0, ce=3.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=0, nd=-2, nom=0, sp=5.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=-1, nf=2, nd=-2, nom=2, sp=-5.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=1, nf=0, nd=0, nom=2, sp=5.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },

   /* 491-500 */
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=0, nd=-1, nom=2, sp=-8.0, spt=0.0, cp=0.0, ce=3.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=1, nf=0, nd=1, nom=0, sp=9.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=-2, nf=0, nd=-2, nom=1, sp=6.0, spt=0.0, cp=0.0, ce=-3.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=-2, nd=0, nom=2, sp=-5.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-3, nlp=1, nf=0, nd=2, nom=0, sp=3.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=1, nf=-2, nd=2, nom=0, sp=-7.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=-1, nf=0, nd=0, nom=2, sp=-3.0, spt=0.0, cp=0.0, ce=1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-3, nlp=0, nf=0, nd=2, nom=0, sp=5.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-3, nlp=-1, nf=0, nd=2, nom=0, sp=3.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=2, nd=-6, nom=1, sp=-3.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },

   /* 501-510 */
      new Nut00a_LSNMT(){ nl=0, nlp=1, nf=2, nd=-4, nom=2, sp=4.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=0, nd=-4, nom=2, sp=3.0, spt=0.0, cp=0.0, ce=-1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=1, nf=2, nd=-2, nom=1, sp=-5.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-1, nf=2, nd=-4, nom=1, sp=4.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=1, nf=0, nd=-2, nom=2, sp=9.0, spt=0.0, cp=0.0, ce=-3.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=0, nd=-2, nom=0, sp=4.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=-2, nd=-2, nom=1, sp=4.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-4, nlp=0, nf=2, nd=0, nom=1, sp=-3.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=-1, nf=0, nd=-1, nom=1, sp=-4.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=-2, nd=0, nom=2, sp=9.0, spt=0.0, cp=0.0, ce=-3.0, cet=0.0, se=0.0 },

   /* 511-520 */
      new Nut00a_LSNMT(){ nl=-3, nlp=0, nf=0, nd=1, nom=0, sp=-4.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=-2, nd=1, nom=0, sp=-4.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=-2, nd=2, nom=1, sp=3.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=-4, nd=2, nom=0, sp=8.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=-1, nf=-2, nd=2, nom=0, sp=3.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=2, nd=-6, nom=1, sp=-3.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=2, nd=-4, nom=2, sp=3.0, spt=0.0, cp=0.0, ce=-1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=0, nd=-4, nom=2, sp=3.0, spt=0.0, cp=0.0, ce=-1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=1, nf=2, nd=-4, nom=2, sp=-3.0, spt=0.0, cp=0.0, ce=1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=1, nf=2, nd=-4, nom=1, sp=6.0, spt=0.0, cp=0.0, ce=-3.0, cet=0.0, se=0.0 },

   /* 521-530 */
      new Nut00a_LSNMT(){ nl=0, nlp=1, nf=4, nd=-4, nom=4, sp=3.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=1, nf=4, nd=-4, nom=2, sp=-3.0, spt=0.0, cp=0.0, ce=1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=-1, nf=-2, nd=4, nom=0, sp=-7.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=-3, nf=0, nd=2, nom=0, sp=9.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=-2, nd=4, nom=1, sp=-3.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=-1, nf=0, nd=3, nom=0, sp=-3.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=-2, nd=3, nom=0, sp=-4.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=0, nd=3, nom=1, sp=-5.0, spt=0.0, cp=0.0, ce=3.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-1, nf=0, nd=1, nom=0, sp=-13.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-3, nlp=0, nf=2, nd=2, nom=0, sp=-7.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },

   /* 531-540 */
      new Nut00a_LSNMT(){ nl=1, nlp=1, nf=-2, nd=2, nom=0, sp=10.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=1, nf=0, nd=2, nom=2, sp=3.0, spt=0.0, cp=0.0, ce=-1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=-2, nf=2, nd=-2, nom=1, sp=10.0, spt=0.0, cp=13.0, ce=6.0, cet=0.0, se=-5.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=1, nd=0, nom=2, sp=0.0, spt=0.0, cp=30.0, ce=0.0, cet=0.0, se=14.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=1, nd=0, nom=1, sp=0.0, spt=0.0, cp=-162.0, ce=0.0, cet=0.0, se=-138.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=1, nd=0, nom=0, sp=0.0, spt=0.0, cp=75.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=2, nf=0, nd=2, nom=1, sp=-7.0, spt=0.0, cp=0.0, ce=4.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=2, nd=0, nom=2, sp=-4.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=2, nd=0, nom=2, sp=4.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=0, nd=-1, nom=1, sp=5.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },

   /* 541-550 */
      new Nut00a_LSNMT(){ nl=3, nlp=0, nf=0, nd=-2, nom=1, sp=5.0, spt=0.0, cp=0.0, ce=-3.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=2, nd=-2, nom=3, sp=-3.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=2, nf=0, nd=0, nom=1, sp=-3.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=2, nd=-3, nom=2, sp=-4.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=1, nf=4, nd=-2, nom=2, sp=-5.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=-2, nf=0, nd=4, nom=0, sp=6.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-3, nf=0, nd=2, nom=0, sp=9.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=-2, nd=4, nom=0, sp=5.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=-1, nf=0, nd=3, nom=0, sp=-7.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=0, nd=4, nom=2, sp=-3.0, spt=0.0, cp=0.0, ce=1.0, cet=0.0, se=0.0 },

   /* 551-560 */
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=0, nd=3, nom=1, sp=-4.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=-2, nf=0, nd=0, nom=0, sp=7.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=-1, nf=0, nd=1, nom=0, sp=-4.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=0, nd=2, nom=0, sp=4.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-2, nf=2, nd=0, nom=1, sp=-6.0, spt=0.0, cp=-3.0, ce=3.0, cet=0.0, se=1.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=1, nd=2, nom=1, sp=0.0, spt=0.0, cp=-3.0, ce=0.0, cet=0.0, se=-2.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=1, nf=0, nd=3, nom=0, sp=11.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=-1, nf=2, nd=1, nom=2, sp=3.0, spt=0.0, cp=0.0, ce=-1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-1, nf=2, nd=0, nom=0, sp=11.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=1, nf=2, nd=2, nom=1, sp=-3.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },

   /* 561-570 */
      new Nut00a_LSNMT(){ nl=2, nlp=-2, nf=2, nd=-2, nom=2, sp=-1.0, spt=0.0, cp=3.0, ce=3.0, cet=0.0, se=-1.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=1, nf=0, nd=1, nom=1, sp=4.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=1, nd=0, nom=1, sp=0.0, spt=0.0, cp=-13.0, ce=0.0, cet=0.0, se=-11.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=1, nd=0, nom=0, sp=3.0, spt=0.0, cp=6.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=2, nf=0, nd=2, nom=0, sp=-7.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=-1, nf=2, nd=-2, nom=1, sp=5.0, spt=0.0, cp=0.0, ce=-3.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-1, nf=4, nd=-2, nom=1, sp=-3.0, spt=0.0, cp=0.0, ce=1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=4, nd=-2, nom=3, sp=3.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=1, nf=4, nd=-2, nom=1, sp=5.0, spt=0.0, cp=0.0, ce=-3.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=4, nlp=0, nf=2, nd=-4, nom=2, sp=-7.0, spt=0.0, cp=0.0, ce=3.0, cet=0.0, se=0.0 },

   /* 571-580 */
      new Nut00a_LSNMT(){ nl=2, nlp=2, nf=2, nd=-2, nom=2, sp=8.0, spt=0.0, cp=0.0, ce=-3.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=4, nd=-4, nom=2, sp=-4.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=-2, nf=0, nd=4, nom=0, sp=11.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=-3, nf=2, nd=2, nom=2, sp=-3.0, spt=0.0, cp=0.0, ce=1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-3, nlp=0, nf=2, nd=4, nom=2, sp=3.0, spt=0.0, cp=0.0, ce=-1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-3, nlp=0, nf=2, nd=-2, nom=1, sp=-4.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=-1, nf=0, nd=-2, nom=1, sp=8.0, spt=0.0, cp=0.0, ce=-4.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-3, nlp=0, nf=0, nd=0, nom=2, sp=3.0, spt=0.0, cp=0.0, ce=-1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-3, nlp=0, nf=-2, nd=2, nom=0, sp=11.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=1, nf=0, nd=-4, nom=1, sp=-6.0, spt=0.0, cp=0.0, ce=3.0, cet=0.0, se=0.0 },

   /* 581-590 */
      new Nut00a_LSNMT(){ nl=-2, nlp=1, nf=0, nd=-2, nom=1, sp=-4.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-4, nlp=0, nf=0, nd=0, nom=1, sp=-8.0, spt=0.0, cp=0.0, ce=4.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=0, nd=-4, nom=1, sp=-7.0, spt=0.0, cp=0.0, ce=3.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-3, nlp=0, nf=0, nd=-2, nom=1, sp=-4.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=0, nd=3, nom=2, sp=3.0, spt=0.0, cp=0.0, ce=-1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=1, nf=0, nd=4, nom=1, sp=6.0, spt=0.0, cp=0.0, ce=-3.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=-2, nf=2, nd=0, nom=1, sp=-6.0, spt=0.0, cp=0.0, ce=3.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=1, nf=0, nd=3, nom=0, sp=6.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=2, nd=2, nom=3, sp=6.0, spt=0.0, cp=0.0, ce=-1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=2, nd=2, nom=2, sp=5.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },

   /* 591-600 */
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=2, nd=2, nom=2, sp=-5.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=1, nf=2, nd=2, nom=0, sp=-4.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=3, nlp=0, nf=0, nd=0, nom=2, sp=-4.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=1, nf=0, nd=1, nom=0, sp=4.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=-1, nf=2, nd=-1, nom=2, sp=6.0, spt=0.0, cp=0.0, ce=-3.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=2, nd=0, nom=1, sp=-4.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=3, nd=0, nom=3, sp=0.0, spt=0.0, cp=-26.0, ce=0.0, cet=0.0, se=-11.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=3, nd=0, nom=2, sp=0.0, spt=0.0, cp=-10.0, ce=0.0, cet=0.0, se=-5.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=2, nf=2, nd=2, nom=1, sp=5.0, spt=0.0, cp=0.0, ce=-3.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=4, nd=0, nom=0, sp=-13.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },

   /* 601-610 */
      new Nut00a_LSNMT(){ nl=1, nlp=2, nf=2, nd=0, nom=1, sp=3.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=3, nlp=1, nf=2, nd=-2, nom=1, sp=4.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=1, nf=4, nd=-2, nom=2, sp=7.0, spt=0.0, cp=0.0, ce=-3.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=-1, nf=0, nd=6, nom=0, sp=4.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-2, nf=0, nd=4, nom=0, sp=5.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=0, nd=6, nom=1, sp=-3.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=-2, nf=2, nd=4, nom=2, sp=-6.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-3, nf=2, nd=2, nom=2, sp=-5.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=0, nd=4, nom=2, sp=-7.0, spt=0.0, cp=0.0, ce=3.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=-1, nf=2, nd=3, nom=2, sp=5.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },

   /* 611-620 */
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=2, nd=4, nom=0, sp=13.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=-1, nf=0, nd=2, nom=1, sp=-4.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=0, nd=3, nom=0, sp=-3.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=1, nf=0, nd=4, nom=1, sp=5.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=1, nf=0, nd=4, nom=0, sp=-11.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=-1, nf=2, nd=1, nom=2, sp=5.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=2, nd=2, nom=3, sp=4.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=2, nd=2, nom=2, sp=4.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=2, nd=2, nom=2, sp=-4.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=4, nd=2, nom=1, sp=6.0, spt=0.0, cp=0.0, ce=-3.0, cet=0.0, se=0.0 },

   /* 621-630 */
      new Nut00a_LSNMT(){ nl=2, nlp=1, nf=0, nd=2, nom=1, sp=3.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=1, nf=0, nd=2, nom=0, sp=-12.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=-1, nf=2, nd=0, nom=0, sp=4.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=2, nd=1, nom=0, sp=-3.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=1, nf=2, nd=2, nom=0, sp=-4.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=2, nd=0, nom=3, sp=3.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=3, nlp=0, nf=2, nd=0, nom=2, sp=3.0, spt=0.0, cp=0.0, ce=-1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=2, nd=0, nom=2, sp=-3.0, spt=0.0, cp=0.0, ce=1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=3, nd=0, nom=3, sp=0.0, spt=0.0, cp=-5.0, ce=0.0, cet=0.0, se=-2.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=1, nf=2, nd=1, nom=1, sp=-7.0, spt=0.0, cp=0.0, ce=4.0, cet=0.0, se=0.0 },

   /* 631-640 */
      new Nut00a_LSNMT(){ nl=0, nlp=2, nf=2, nd=2, nom=2, sp=6.0, spt=0.0, cp=0.0, ce=-3.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=1, nf=2, nd=0, nom=0, sp=-3.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=4, nd=-2, nom=1, sp=5.0, spt=0.0, cp=0.0, ce=-3.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=4, nlp=1, nf=2, nd=-2, nom=2, sp=3.0, spt=0.0, cp=0.0, ce=-1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=-1, nf=0, nd=6, nom=0, sp=3.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-3, nlp=-1, nf=2, nd=6, nom=2, sp=-3.0, spt=0.0, cp=0.0, ce=1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=0, nd=6, nom=1, sp=-5.0, spt=0.0, cp=0.0, ce=3.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-3, nlp=0, nf=2, nd=6, nom=1, sp=-3.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=-1, nf=0, nd=4, nom=1, sp=-3.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=-1, nf=0, nd=4, nom=0, sp=12.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },

   /* 641-650 */
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=2, nd=5, nom=2, sp=3.0, spt=0.0, cp=0.0, ce=-1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=-2, nf=2, nd=2, nom=1, sp=-4.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=3, nlp=-1, nf=0, nd=2, nom=0, sp=4.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=-1, nf=2, nd=2, nom=0, sp=6.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=2, nd=3, nom=1, sp=5.0, spt=0.0, cp=0.0, ce=-3.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=1, nf=2, nd=4, nom=1, sp=4.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=1, nf=2, nd=3, nom=2, sp=-6.0, spt=0.0, cp=0.0, ce=3.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=4, nd=2, nom=1, sp=4.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=2, nd=1, nom=1, sp=6.0, spt=0.0, cp=0.0, ce=-3.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=5, nlp=0, nf=0, nd=0, nom=0, sp=6.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },

   /* 651-660 */
      new Nut00a_LSNMT(){ nl=2, nlp=1, nf=2, nd=1, nom=2, sp=-6.0, spt=0.0, cp=0.0, ce=3.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=4, nd=0, nom=1, sp=3.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=3, nlp=1, nf=2, nd=0, nom=1, sp=7.0, spt=0.0, cp=0.0, ce=-4.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=3, nlp=0, nf=4, nd=-2, nom=2, sp=4.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=-1, nf=2, nd=6, nom=2, sp=-5.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=0, nd=6, nom=0, sp=5.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=-2, nf=2, nd=4, nom=2, sp=-6.0, spt=0.0, cp=0.0, ce=3.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-2, nlp=0, nf=2, nd=6, nom=1, sp=-6.0, spt=0.0, cp=0.0, ce=3.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=0, nd=4, nom=1, sp=-4.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=0, nd=4, nom=0, sp=10.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },

   /* 661-670 */
      new Nut00a_LSNMT(){ nl=2, nlp=-2, nf=2, nd=2, nom=2, sp=-4.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=2, nd=4, nom=0, sp=7.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=0, nf=2, nd=3, nom=2, sp=7.0, spt=0.0, cp=0.0, ce=-3.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=4, nlp=0, nf=0, nd=2, nom=0, sp=4.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=2, nd=2, nom=0, sp=11.0, spt=0.0, cp=0.0, ce=0.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=0, nlp=0, nf=4, nd=2, nom=2, sp=5.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=4, nlp=-1, nf=2, nd=0, nom=2, sp=-6.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=3, nlp=0, nf=2, nd=1, nom=2, sp=4.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=1, nf=2, nd=2, nom=1, sp=3.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=4, nlp=1, nf=2, nd=0, nom=2, sp=5.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },

   /* 671-678 */
      new Nut00a_LSNMT(){ nl=-1, nlp=-1, nf=2, nd=6, nom=2, sp=-4.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=-1, nlp=0, nf=2, nd=6, nom=1, sp=-4.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=-1, nf=2, nd=4, nom=1, sp=-3.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=1, nlp=1, nf=2, nd=4, nom=2, sp=4.0, spt=0.0, cp=0.0, ce=-2.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=3, nlp=1, nf=2, nd=2, nom=2, sp=3.0, spt=0.0, cp=0.0, ce=-1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=5, nlp=0, nf=2, nd=0, nom=1, sp=-3.0, spt=0.0, cp=0.0, ce=1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=-1, nf=2, nd=4, nom=2, sp=-3.0, spt=0.0, cp=0.0, ce=1.0, cet=0.0, se=0.0 },
      new Nut00a_LSNMT(){ nl=2, nlp=0, nf=2, nd=4, nom=1, sp=-3.0, spt=0.0, cp=0.0, ce=2.0, cet=0.0, se=0.0 },
            };
        #endregion

        internal struct Nut00a_PNMT
        {
            #region coefficients of l, F, D and Omega
            public int nl { get; set; }               
            public int nf { get; set; }
            public int nd { get; set; }
            public int nom { get; set; }
            #endregion

            #region coefficients of planetary longitudes
            public int nme { get; set; }              
            public int nve { get; set; }
            public int nea { get; set; }
            public int nma { get; set; }
            public int nju { get; set; }
            public int nsa { get; set; }
            public int nur { get; set; }
            public int nne { get; set; }
            #endregion

            #region coefficient of general precession
            public int npa { get; set; }              
            public int sp { get; set; }
            #endregion

            #region longitude sin, cos coefficients 
            public int cp { get; set; }            
            public int se { get; set; }
            #endregion

            #region obliquity sin, cos coefficients
            public int ce { get; set; }
            #endregion
        }

        #region Planetary nutation model terms
        internal static readonly Nut00a_PNMT[] xpl = {
   /* 1-10 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=8, nma=-16, nju=4, nsa=5, nur=0, nne=0, npa=0, sp=1440, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-8, nma=16, nju=-4, nsa=-5, nur=0, nne=0, npa=2, sp=56, cp=-117, se=-42, ce=-40},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=8, nma=-16, nju=4, nsa=5, nur=0, nne=0, npa=2, sp=125, cp=-43, se=0, ce=-54},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=0, nsa=0, nur=-1, nne=2, npa=2, sp=0, cp=5, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-4, nma=8, nju=-1, nsa=-5, nur=0, nne=0, npa=2, sp=3, cp=-7, se=-3, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=4, nma=-8, nju=3, nsa=0, nur=0, nne=0, npa=1, sp=3, cp=0, se=0, ce=-2},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=0, nea=3, nma=-8, nju=3, nsa=0, nur=0, nne=0, npa=0, sp=-114, cp=0, se=0, ce=61},
      new Nut00a_PNMT(){nl=-1, nf=0, nd=0, nom=0, nme=0, nve=10, nea=-3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-219, cp=89, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=-2, nsa=6, nur=-3, nne=0, npa=2, sp=-3, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=4, nma=-8, nju=3, nsa=0, nur=0, nne=0, npa=0, sp=-462, cp=1604, se=0, ce=0},

   /* 11-20 */
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=0, nea=-5, nma=8, nju=-3, nsa=0, nur=0, nne=0, npa=0, sp=99, cp=0, se=0, ce=-53},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-4, nma=8, nju=-3, nsa=0, nur=0, nne=0, npa=1, sp=-3, cp=0, se=0, ce=2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=4, nma=-8, nju=1, nsa=5, nur=0, nne=0, npa=2, sp=0, cp=6, se=2, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-5, nea=6, nma=4, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=3, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=2, nsa=-5, nur=0, nne=0, npa=2, sp=-12, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=2, nsa=-5, nur=0, nne=0, npa=1, sp=14, cp=-218, se=117, ce=8},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=0, nea=-1, nma=0, nju=2, nsa=-5, nur=0, nne=0, npa=0, sp=31, cp=-481, se=-257, ce=-17},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=2, nsa=-5, nur=0, nne=0, npa=0, sp=-491, cp=128, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=0, nea=-1, nma=0, nju=-2, nsa=5, nur=0, nne=0, npa=0, sp=-3084, cp=5123, se=2735, ce=1647},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=-2, nsa=5, nur=0, nne=0, npa=1, sp=-1444, cp=2409, se=-1286, ce=-771},

   /* 21-30 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=-2, nsa=5, nur=0, nne=0, npa=2, sp=11, cp=-24, se=-11, ce=-9},
      new Nut00a_PNMT(){nl=2, nf=-1, nd=-1, nom=0, nme=0, nve=0, nea=3, nma=-7, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=26, cp=-9, se=0, ce=0},
      new Nut00a_PNMT(){nl=1, nf=0, nd=-2, nom=0, nme=0, nve=19, nea=-21, nma=3, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=103, cp=-60, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=2, nea=-4, nma=0, nju=-3, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=-13, se=-7, ce=0},
      new Nut00a_PNMT(){nl=1, nf=0, nd=-1, nom=1, nme=0, nve=0, nea=-1, nma=0, nju=2, nsa=0, nur=0, nne=0, npa=0, sp=-26, cp=-29, se=-16, ce=14},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=0, nea=-1, nma=0, nju=-4, nsa=10, nur=0, nne=0, npa=0, sp=9, cp=-27, se=-14, ce=-5},
      new Nut00a_PNMT(){nl=-2, nf=0, nd=2, nom=1, nme=0, nve=0, nea=2, nma=0, nju=0, nsa=-5, nur=0, nne=0, npa=0, sp=12, cp=0, se=0, ce=-6},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=3, nea=-7, nma=4, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-7, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=-1, nd=1, nom=0, nme=0, nve=0, nea=1, nma=0, nju=1, nsa=-1, nur=0, nne=0, npa=0, sp=0, cp=24, se=0, ce=0},
      new Nut00a_PNMT(){nl=-2, nf=0, nd=2, nom=1, nme=0, nve=0, nea=2, nma=0, nju=-2, nsa=0, nur=0, nne=0, npa=0, sp=284, cp=0, se=0, ce=-151},

   /* 31-40 */
      new Nut00a_PNMT(){nl=-1, nf=0, nd=0, nom=0, nme=0, nve=18, nea=-16, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=226, cp=101, se=0, ce=0},
      new Nut00a_PNMT(){nl=-2, nf=1, nd=1, nom=2, nme=0, nve=0, nea=1, nma=0, nju=-2, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=-8, se=-2, ce=0},
      new Nut00a_PNMT(){nl=-1, nf=1, nd=-1, nom=1, nme=0, nve=18, nea=-17, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=-6, se=-3, ce=0},
      new Nut00a_PNMT(){nl=-1, nf=0, nd=1, nom=1, nme=0, nve=0, nea=2, nma=-2, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=5, cp=0, se=0, ce=-3},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-8, nea=13, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-41, cp=175, se=76, ce=17},
      new Nut00a_PNMT(){nl=0, nf=2, nd=-2, nom=2, nme=0, nve=-8, nea=11, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=15, se=6, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-8, nea=13, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=425, cp=212, se=-133, ce=269},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=-8, nea=12, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=1200, cp=598, se=319, ce=-641},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=8, nea=-13, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=235, cp=334, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=8, nea=-14, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=11, cp=-12, se=-7, ce=-6},

   /* 41-50 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=8, nea=-13, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=5, cp=-6, se=3, ce=3},
      new Nut00a_PNMT(){nl=-2, nf=0, nd=2, nom=1, nme=0, nve=0, nea=2, nma=0, nju=-4, nsa=5, nur=0, nne=0, npa=0, sp=-5, cp=0, se=0, ce=3},
      new Nut00a_PNMT(){nl=-2, nf=0, nd=2, nom=2, nme=0, nve=3, nea=-3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=6, cp=0, se=0, ce=-3},
      new Nut00a_PNMT(){nl=-2, nf=0, nd=2, nom=0, nme=0, nve=0, nea=2, nma=0, nju=-3, nsa=1, nur=0, nne=0, npa=0, sp=15, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=3, nea=-5, nma=0, nju=2, nsa=0, nur=0, nne=0, npa=0, sp=13, cp=0, se=0, ce=-7},
      new Nut00a_PNMT(){nl=-2, nf=0, nd=2, nom=0, nme=0, nve=0, nea=2, nma=0, nju=-4, nsa=3, nur=0, nne=0, npa=0, sp=-6, cp=-9, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=-1, nd=1, nom=0, nme=0, nve=0, nea=0, nma=2, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=266, cp=-78, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=0, nea=-1, nma=2, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-460, cp=-435, se=-232, ce=246},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=2, nme=0, nve=0, nea=-2, nma=2, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=15, se=7, ce=0},
      new Nut00a_PNMT(){nl=-1, nf=1, nd=0, nom=1, nme=0, nve=3, nea=-5, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-3, cp=0, se=0, ce=2},

   /* 51-60 */
      new Nut00a_PNMT(){nl=-1, nf=0, nd=1, nom=0, nme=0, nve=3, nea=-4, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=131, se=0, ce=0},
      new Nut00a_PNMT(){nl=-2, nf=0, nd=2, nom=0, nme=0, nve=0, nea=2, nma=0, nju=-2, nsa=-2, nur=0, nne=0, npa=0, sp=4, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=-2, nf=2, nd=0, nom=2, nme=0, nve=0, nea=-5, nma=9, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=3, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=0, nea=-1, nma=0, nju=0, nsa=0, nur=-1, nne=0, npa=0, sp=0, cp=4, se=2, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=0, nsa=0, nur=1, nne=0, npa=0, sp=0, cp=3, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=0, nea=-1, nma=0, nju=0, nsa=0, nur=0, nne=2, npa=0, sp=-17, cp=-19, se=-10, ce=9},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=0, nsa=0, nur=0, nne=2, npa=1, sp=-9, cp=-11, se=6, ce=-5},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=0, nsa=0, nur=0, nne=2, npa=2, sp=-6, cp=0, se=0, ce=3},
      new Nut00a_PNMT(){nl=-1, nf=0, nd=1, nom=0, nme=0, nve=0, nea=3, nma=-4, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-16, cp=8, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=-1, nd=1, nom=0, nme=0, nve=0, nea=1, nma=0, nju=0, nsa=2, nur=0, nne=0, npa=0, sp=0, cp=3, se=0, ce=0},

   /* 61-70 */
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=2, nme=0, nve=0, nea=-1, nma=0, nju=0, nsa=2, nur=0, nne=0, npa=0, sp=11, cp=24, se=11, ce=-5},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=0, nea=-9, nma=17, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-3, cp=-4, se=-2, ce=1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=2, nme=0, nve=-3, nea=5, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=3, cp=0, se=0, ce=-1},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=0, nea=-1, nma=0, nju=-1, nsa=2, nur=0, nne=0, npa=0, sp=0, cp=-8, se=-4, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=1, nsa=-2, nur=0, nne=0, npa=0, sp=0, cp=3, se=0, ce=0},
      new Nut00a_PNMT(){nl=1, nf=0, nd=-2, nom=0, nme=0, nve=17, nea=-16, nma=0, nju=-2, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=5, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=0, nea=-1, nma=0, nju=1, nsa=-3, nur=0, nne=0, npa=0, sp=0, cp=3, se=2, ce=0},
      new Nut00a_PNMT(){nl=-2, nf=0, nd=2, nom=1, nme=0, nve=0, nea=5, nma=-6, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-6, cp=4, se=2, ce=3},
      new Nut00a_PNMT(){nl=0, nf=-2, nd=2, nom=0, nme=0, nve=0, nea=9, nma=-13, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-3, cp=-5, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=2, nme=0, nve=0, nea=-1, nma=0, nju=0, nsa=1, nur=0, nne=0, npa=0, sp=-5, cp=0, se=0, ce=2},

   /* 71-80 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=0, nea=0, nma=0, nju=0, nsa=1, nur=0, nne=0, npa=0, sp=4, cp=24, se=13, ce=-2},
      new Nut00a_PNMT(){nl=0, nf=-1, nd=1, nom=0, nme=0, nve=0, nea=1, nma=0, nju=0, nsa=1, nur=0, nne=0, npa=0, sp=-42, cp=20, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=-2, nd=2, nom=0, nme=0, nve=5, nea=-6, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-10, cp=233, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=-1, nd=1, nom=1, nme=0, nve=5, nea=-7, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-3, cp=0, se=0, ce=1},
      new Nut00a_PNMT(){nl=-2, nf=0, nd=2, nom=0, nme=0, nve=6, nea=-8, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=78, cp=-18, se=0, ce=0},
      new Nut00a_PNMT(){nl=2, nf=1, nd=-3, nom=1, nme=0, nve=-6, nea=7, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=3, se=1, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=2, nme=0, nve=0, nea=0, nma=0, nju=1, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=-3, se=-1, ce=0},
      new Nut00a_PNMT(){nl=0, nf=-1, nd=1, nom=1, nme=0, nve=0, nea=1, nma=0, nju=1, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=-4, se=-2, ce=1},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=0, nea=-1, nma=0, nju=0, nsa=0, nur=2, nne=0, npa=0, sp=0, cp=-8, se=-4, ce=-1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=0, nsa=0, nur=2, nne=0, npa=1, sp=0, cp=-5, se=3, ce=0},

   /* 81-90 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=0, nsa=0, nur=2, nne=0, npa=2, sp=-7, cp=0, se=0, ce=3},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-8, nma=15, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-14, cp=8, se=3, ce=6},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-8, nma=15, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=0, cp=8, se=-4, ce=0},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=0, nea=-9, nma=15, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=19, se=10, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=8, nma=-15, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=45, cp=-22, se=0, ce=0},
      new Nut00a_PNMT(){nl=1, nf=-1, nd=-1, nom=0, nme=0, nve=0, nea=8, nma=-15, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-3, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=2, nf=0, nd=-2, nom=0, nme=0, nve=2, nea=-5, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=-3, se=0, ce=0},
      new Nut00a_PNMT(){nl=-2, nf=0, nd=2, nom=0, nme=0, nve=0, nea=2, nma=0, nju=-5, nsa=5, nur=0, nne=0, npa=0, sp=0, cp=3, se=0, ce=0},
      new Nut00a_PNMT(){nl=2, nf=0, nd=-2, nom=1, nme=0, nve=0, nea=-6, nma=8, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=3, cp=5, se=3, ce=-2},
      new Nut00a_PNMT(){nl=2, nf=0, nd=-2, nom=1, nme=0, nve=0, nea=-2, nma=0, nju=3, nsa=0, nur=0, nne=0, npa=0, sp=89, cp=-16, se=-9, ce=-48},

   /* 91-100 */
      new Nut00a_PNMT(){nl=-2, nf=1, nd=1, nom=0, nme=0, nve=0, nea=1, nma=0, nju=-3, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=3, se=0, ce=0},
      new Nut00a_PNMT(){nl=-2, nf=1, nd=1, nom=1, nme=0, nve=0, nea=1, nma=0, nju=-3, nsa=0, nur=0, nne=0, npa=0, sp=-3, cp=7, se=4, ce=2},
      new Nut00a_PNMT(){nl=-2, nf=0, nd=2, nom=0, nme=0, nve=0, nea=2, nma=0, nju=-3, nsa=0, nur=0, nne=0, npa=0, sp=-349, cp=-62, se=0, ce=0},
      new Nut00a_PNMT(){nl=-2, nf=0, nd=2, nom=0, nme=0, nve=0, nea=6, nma=-8, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-15, cp=22, se=0, ce=0},
      new Nut00a_PNMT(){nl=-2, nf=0, nd=2, nom=0, nme=0, nve=0, nea=2, nma=0, nju=-1, nsa=-5, nur=0, nne=0, npa=0, sp=-3, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=-1, nf=0, nd=1, nom=0, nme=0, nve=0, nea=1, nma=0, nju=-1, nsa=0, nur=0, nne=0, npa=0, sp=-53, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=-1, nf=1, nd=1, nom=1, nme=0, nve=-20, nea=20, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=5, cp=0, se=0, ce=-3},
      new Nut00a_PNMT(){nl=1, nf=0, nd=-2, nom=0, nme=0, nve=20, nea=-21, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=-8, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=0, nea=8, nma=-15, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=15, cp=-7, se=-4, ce=-8},
      new Nut00a_PNMT(){nl=0, nf=2, nd=-2, nom=1, nme=0, nve=0, nea=-10, nma=15, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-3, cp=0, se=0, ce=1},

   /* 101-110 */
      new Nut00a_PNMT(){nl=0, nf=-1, nd=1, nom=0, nme=0, nve=0, nea=1, nma=0, nju=1, nsa=0, nur=0, nne=0, npa=0, sp=-21, cp=-78, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=0, nea=0, nma=0, nju=1, nsa=0, nur=0, nne=0, npa=0, sp=20, cp=-70, se=-37, ce=-11},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=2, nme=0, nve=0, nea=-1, nma=0, nju=1, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=6, se=3, ce=0},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=0, nea=-1, nma=0, nju=-2, nsa=4, nur=0, nne=0, npa=0, sp=5, cp=3, se=2, ce=-2},
      new Nut00a_PNMT(){nl=2, nf=0, nd=-2, nom=1, nme=0, nve=-6, nea=8, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-17, cp=-4, se=-2, ce=9},
      new Nut00a_PNMT(){nl=0, nf=-2, nd=2, nom=1, nme=0, nve=5, nea=-6, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=6, se=3, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=0, nsa=-1, nur=0, nne=0, npa=1, sp=32, cp=15, se=-8, ce=17},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=0, nea=-1, nma=0, nju=0, nsa=-1, nur=0, nne=0, npa=0, sp=174, cp=84, se=45, ce=-93},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=0, nsa=1, nur=0, nne=0, npa=0, sp=11, cp=56, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=0, nea=-1, nma=0, nju=0, nsa=1, nur=0, nne=0, npa=0, sp=-66, cp=-12, se=-6, ce=35},

   /* 111-120 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=0, nsa=1, nur=0, nne=0, npa=1, sp=47, cp=8, se=4, ce=-25},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=0, nsa=1, nur=0, nne=0, npa=2, sp=0, cp=8, se=4, ce=0},
      new Nut00a_PNMT(){nl=0, nf=2, nd=-2, nom=1, nme=0, nve=0, nea=-9, nma=13, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=10, cp=-22, se=-12, ce=-5},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=0, nea=7, nma=-13, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-3, cp=0, se=0, ce=2},
      new Nut00a_PNMT(){nl=-2, nf=0, nd=2, nom=0, nme=0, nve=0, nea=5, nma=-6, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-24, cp=12, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=9, nma=-17, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=5, cp=-6, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-9, nma=17, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=3, cp=0, se=0, ce=-2},
      new Nut00a_PNMT(){nl=1, nf=0, nd=-1, nom=1, nme=0, nve=0, nea=-3, nma=4, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=4, cp=3, se=1, ce=-2},
      new Nut00a_PNMT(){nl=1, nf=0, nd=-1, nom=1, nme=0, nve=-3, nea=4, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=29, se=15, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=2, nme=0, nve=0, nea=-1, nma=2, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-5, cp=-4, se=-2, ce=2},

   /* 121-130 */
      new Nut00a_PNMT(){nl=0, nf=-1, nd=1, nom=1, nme=0, nve=0, nea=0, nma=2, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=8, cp=-3, se=-1, ce=-5},
      new Nut00a_PNMT(){nl=0, nf=-2, nd=2, nom=0, nme=1, nve=0, nea=-2, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=-3, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=3, nea=-5, nma=0, nju=2, nsa=0, nur=0, nne=0, npa=0, sp=10, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=-2, nf=0, nd=2, nom=1, nme=0, nve=0, nea=2, nma=0, nju=-3, nsa=1, nur=0, nne=0, npa=0, sp=3, cp=0, se=0, ce=-2},
      new Nut00a_PNMT(){nl=-2, nf=0, nd=2, nom=1, nme=0, nve=3, nea=-3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-5, cp=0, se=0, ce=3},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=8, nea=-13, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=46, cp=66, se=35, ce=-25},
      new Nut00a_PNMT(){nl=0, nf=-1, nd=1, nom=0, nme=0, nve=8, nea=-12, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-14, cp=7, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=2, nd=-2, nom=1, nme=0, nve=-8, nea=11, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=3, se=2, ce=0},
      new Nut00a_PNMT(){nl=-1, nf=0, nd=1, nom=0, nme=0, nve=0, nea=2, nma=-2, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-5, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=-1, nf=0, nd=0, nom=1, nme=0, nve=18, nea=-16, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-68, cp=-34, se=-18, ce=36},

   /* 131-140 */
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=0, nea=-1, nma=0, nju=-1, nsa=1, nur=0, nne=0, npa=0, sp=0, cp=14, se=7, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=3, nea=-7, nma=4, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=10, cp=-6, se=-3, ce=-5},
      new Nut00a_PNMT(){nl=-2, nf=1, nd=1, nom=1, nme=0, nve=0, nea=-3, nma=7, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-5, cp=-4, se=-2, ce=3},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=2, nme=0, nve=0, nea=-1, nma=0, nju=-2, nsa=5, nur=0, nne=0, npa=0, sp=-3, cp=5, se=2, ce=1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=0, nea=0, nma=0, nju=-2, nsa=5, nur=0, nne=0, npa=0, sp=76, cp=17, se=9, ce=-41},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=0, nea=-4, nma=8, nju=-3, nsa=0, nur=0, nne=0, npa=0, sp=84, cp=298, se=159, ce=-45},
      new Nut00a_PNMT(){nl=1, nf=0, nd=0, nom=1, nme=0, nve=-10, nea=3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=3, cp=0, se=0, ce=-1},
      new Nut00a_PNMT(){nl=0, nf=2, nd=-2, nom=1, nme=0, nve=0, nea=-2, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-3, cp=0, se=0, ce=2},
      new Nut00a_PNMT(){nl=-1, nf=0, nd=0, nom=1, nme=0, nve=10, nea=-3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-3, cp=0, se=0, ce=1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=0, nea=4, nma=-8, nju=3, nsa=0, nur=0, nne=0, npa=0, sp=-82, cp=292, se=156, ce=44},

   /* 141-150 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=0, nea=0, nma=0, nju=2, nsa=-5, nur=0, nne=0, npa=0, sp=-73, cp=17, se=9, ce=39},
      new Nut00a_PNMT(){nl=0, nf=-1, nd=1, nom=0, nme=0, nve=0, nea=1, nma=0, nju=2, nsa=-5, nur=0, nne=0, npa=0, sp=-9, cp=-16, se=0, ce=0},
      new Nut00a_PNMT(){nl=2, nf=-1, nd=-1, nom=1, nme=0, nve=0, nea=3, nma=-7, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=3, cp=0, se=-1, ce=-2},
      new Nut00a_PNMT(){nl=-2, nf=0, nd=2, nom=0, nme=0, nve=0, nea=2, nma=0, nju=0, nsa=-5, nur=0, nne=0, npa=0, sp=-3, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=-3, nea=7, nma=-4, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-9, cp=-5, se=-3, ce=5},
      new Nut00a_PNMT(){nl=-2, nf=0, nd=2, nom=0, nme=0, nve=0, nea=2, nma=0, nju=-2, nsa=0, nur=0, nne=0, npa=0, sp=-439, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=1, nf=0, nd=0, nom=1, nme=0, nve=-18, nea=16, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=57, cp=-28, se=-15, ce=-30},
      new Nut00a_PNMT(){nl=-2, nf=1, nd=1, nom=1, nme=0, nve=0, nea=1, nma=0, nju=-2, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=-6, se=-3, ce=0},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=2, nme=0, nve=-8, nea=12, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-4, cp=0, se=0, ce=2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=-8, nea=13, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-40, cp=57, se=30, ce=21},

   /* 151-160 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=1, nma=-2, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=23, cp=7, se=3, ce=-13},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=0, nea=0, nma=-2, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=273, cp=80, se=43, ce=-146},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=1, nma=-2, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-449, cp=430, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=0, nea=-2, nma=2, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-8, cp=-47, se=-25, ce=4},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-1, nma=2, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=6, cp=47, se=25, ce=-3},
      new Nut00a_PNMT(){nl=-1, nf=0, nd=1, nom=1, nme=0, nve=3, nea=-4, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=23, se=13, ce=0},
      new Nut00a_PNMT(){nl=-1, nf=0, nd=1, nom=1, nme=0, nve=0, nea=3, nma=-4, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-3, cp=0, se=0, ce=2},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=0, nea=-1, nma=0, nju=0, nsa=-2, nur=0, nne=0, npa=0, sp=3, cp=-4, se=-2, ce=-2},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=0, nea=-1, nma=0, nju=0, nsa=2, nur=0, nne=0, npa=0, sp=-48, cp=-110, se=-59, ce=26},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=0, nsa=2, nur=0, nne=0, npa=1, sp=51, cp=114, se=61, ce=-27},

   /* 161-170 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=0, nsa=2, nur=0, nne=0, npa=2, sp=-133, cp=0, se=0, ce=57},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=0, nme=0, nve=3, nea=-6, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=4, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=-3, nea=5, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-21, cp=-6, se=-3, ce=11},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=2, nme=0, nve=-3, nea=4, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=-3, se=-1, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=0, nea=-2, nma=4, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-11, cp=-21, se=-11, ce=6},
      new Nut00a_PNMT(){nl=0, nf=2, nd=-2, nom=1, nme=0, nve=-5, nea=6, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-18, cp=-436, se=-233, ce=9},
      new Nut00a_PNMT(){nl=0, nf=-1, nd=1, nom=0, nme=0, nve=5, nea=-7, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=35, cp=-7, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=5, nea=-8, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=5, se=3, ce=0},
      new Nut00a_PNMT(){nl=-2, nf=0, nd=2, nom=1, nme=0, nve=6, nea=-8, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=11, cp=-3, se=-1, ce=-6},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=0, nea=-8, nma=15, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-5, cp=-3, se=-1, ce=3},

   /* 171-180 */
      new Nut00a_PNMT(){nl=-2, nf=0, nd=2, nom=1, nme=0, nve=0, nea=2, nma=0, nju=-3, nsa=0, nur=0, nne=0, npa=0, sp=-53, cp=-9, se=-5, ce=28},
      new Nut00a_PNMT(){nl=-2, nf=0, nd=2, nom=1, nme=0, nve=0, nea=6, nma=-8, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=3, se=2, ce=1},
      new Nut00a_PNMT(){nl=1, nf=0, nd=-1, nom=1, nme=0, nve=0, nea=-1, nma=0, nju=1, nsa=0, nur=0, nne=0, npa=0, sp=4, cp=0, se=0, ce=-2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=3, nsa=-5, nur=0, nne=0, npa=0, sp=0, cp=-4, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=0, nea=-1, nma=0, nju=-1, nsa=0, nur=0, nne=0, npa=0, sp=-50, cp=194, se=103, ce=27},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=-1, nsa=0, nur=0, nne=0, npa=1, sp=-13, cp=52, se=28, ce=7},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=1, nsa=0, nur=0, nne=0, npa=0, sp=-91, cp=248, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=1, nsa=0, nur=0, nne=0, npa=1, sp=6, cp=49, se=26, ce=-3},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=0, nea=-1, nma=0, nju=1, nsa=0, nur=0, nne=0, npa=0, sp=-6, cp=-47, se=-25, ce=3},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=1, nsa=0, nur=0, nne=0, npa=1, sp=0, cp=5, se=3, ce=0},

   /* 181-190 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=1, nsa=0, nur=0, nne=0, npa=2, sp=52, cp=23, se=10, ce=-23},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=2, nme=0, nve=0, nea=-1, nma=0, nju=0, nsa=-1, nur=0, nne=0, npa=0, sp=-3, cp=0, se=0, ce=1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=0, nea=0, nma=0, nju=0, nsa=-1, nur=0, nne=0, npa=0, sp=0, cp=5, se=3, ce=0},
      new Nut00a_PNMT(){nl=0, nf=-1, nd=1, nom=0, nme=0, nve=0, nea=1, nma=0, nju=0, nsa=-1, nur=0, nne=0, npa=0, sp=-4, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-7, nma=13, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-4, cp=8, se=3, ce=2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=7, nma=-13, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=10, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=2, nf=0, nd=-2, nom=1, nme=0, nve=0, nea=-5, nma=6, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=3, cp=0, se=0, ce=-2},
      new Nut00a_PNMT(){nl=0, nf=2, nd=-2, nom=1, nme=0, nve=0, nea=-8, nma=11, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=8, se=4, ce=0},
      new Nut00a_PNMT(){nl=0, nf=2, nd=-2, nom=1, nme=-1, nve=0, nea=2, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=8, se=4, ce=1},
      new Nut00a_PNMT(){nl=-2, nf=0, nd=2, nom=0, nme=0, nve=0, nea=4, nma=-4, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-4, cp=0, se=0, ce=0},

   /* 191-200 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=2, nsa=-2, nur=0, nne=0, npa=0, sp=-4, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=0, nea=-1, nma=0, nju=0, nsa=3, nur=0, nne=0, npa=0, sp=-8, cp=4, se=2, ce=4},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=0, nsa=3, nur=0, nne=0, npa=1, sp=8, cp=-4, se=-2, ce=-4},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=0, nsa=3, nur=0, nne=0, npa=2, sp=0, cp=15, se=7, ce=0},
      new Nut00a_PNMT(){nl=-2, nf=0, nd=2, nom=0, nme=0, nve=3, nea=-3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-138, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=2, nme=0, nve=0, nea=-4, nma=8, nju=-3, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=-7, se=-3, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=2, nme=0, nve=0, nea=4, nma=-8, nju=3, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=-7, se=-3, ce=0},
      new Nut00a_PNMT(){nl=2, nf=0, nd=-2, nom=1, nme=0, nve=0, nea=-2, nma=0, nju=2, nsa=0, nur=0, nne=0, npa=0, sp=54, cp=0, se=0, ce=-29},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=2, nme=0, nve=0, nea=-1, nma=0, nju=2, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=10, se=4, ce=0},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=2, nme=0, nve=0, nea=0, nma=-2, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-7, cp=0, se=0, ce=3},

   /* 201-210 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=0, nea=1, nma=-2, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-37, cp=35, se=19, ce=20},
      new Nut00a_PNMT(){nl=0, nf=-1, nd=1, nom=0, nme=0, nve=0, nea=2, nma=-2, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=4, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=-1, nd=1, nom=0, nme=0, nve=0, nea=1, nma=0, nju=0, nsa=-2, nur=0, nne=0, npa=0, sp=-4, cp=9, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=2, nd=-2, nom=1, nme=0, nve=0, nea=-2, nma=0, nju=0, nsa=2, nur=0, nne=0, npa=0, sp=8, cp=0, se=0, ce=-4},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=3, nea=-6, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-9, cp=-14, se=-8, ce=5},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=3, nea=-5, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=-3, cp=-9, se=-5, ce=3},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=3, nea=-5, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-145, cp=47, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=-3, nea=4, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-10, cp=40, se=21, ce=5},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-3, nea=5, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=11, cp=-49, se=-26, ce=-7},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-3, nea=5, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-2150, cp=0, se=0, ce=932},

   /* 211-220 */
      new Nut00a_PNMT(){nl=0, nf=2, nd=-2, nom=2, nme=0, nve=-3, nea=3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-12, cp=0, se=0, ce=5},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-3, nea=5, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=85, cp=0, se=0, ce=-37},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=2, nma=-4, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=4, cp=0, se=0, ce=-2},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=0, nea=1, nma=-4, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=3, cp=0, se=0, ce=-2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=2, nma=-4, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-86, cp=153, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-2, nma=4, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=-6, cp=9, se=5, ce=3},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=0, nea=-3, nma=4, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=9, cp=-13, se=-7, ce=-5},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-2, nma=4, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=-8, cp=12, se=6, ce=4},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-2, nma=4, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-51, cp=0, se=0, ce=22},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-5, nea=8, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-11, cp=-268, se=-116, ce=5},

   /* 221-230 */
      new Nut00a_PNMT(){nl=0, nf=2, nd=-2, nom=2, nme=0, nve=-5, nea=6, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=12, se=5, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-5, nea=8, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=0, cp=7, se=3, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-5, nea=8, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=31, cp=6, se=3, ce=-17},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=-5, nea=7, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=140, cp=27, se=14, ce=-75},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-5, nea=8, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=57, cp=11, se=6, ce=-30},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=5, nea=-8, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-14, cp=-39, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=2, nme=0, nve=0, nea=-1, nma=0, nju=-1, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=-6, se=-2, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=0, nea=0, nma=0, nju=-1, nsa=0, nur=0, nne=0, npa=0, sp=4, cp=15, se=8, ce=-2},
      new Nut00a_PNMT(){nl=0, nf=-1, nd=1, nom=0, nme=0, nve=0, nea=1, nma=0, nju=-1, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=4, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=2, nd=-2, nom=1, nme=0, nve=0, nea=-2, nma=0, nju=1, nsa=0, nur=0, nne=0, npa=0, sp=-3, cp=0, se=0, ce=1},

   /* 231-240 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-6, nma=11, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=0, cp=11, se=5, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=6, nma=-11, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=9, cp=6, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=-1, nve=0, nea=4, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-4, cp=10, se=4, ce=2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=1, nve=0, nea=-4, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=5, cp=3, se=0, ce=0},
      new Nut00a_PNMT(){nl=2, nf=0, nd=-2, nom=1, nme=0, nve=-3, nea=3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=16, cp=0, se=0, ce=-9},
      new Nut00a_PNMT(){nl=-2, nf=0, nd=2, nom=0, nme=0, nve=0, nea=2, nma=0, nju=0, nsa=-2, nur=0, nne=0, npa=0, sp=-3, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=2, nd=-2, nom=1, nme=0, nve=0, nea=-7, nma=9, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=3, se=2, ce=-1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=4, nsa=-5, nur=0, nne=0, npa=2, sp=7, cp=0, se=0, ce=-3},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=2, nsa=0, nur=0, nne=0, npa=0, sp=-25, cp=22, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=2, nsa=0, nur=0, nne=0, npa=1, sp=42, cp=223, se=119, ce=-22},

   /* 241-250 */
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=0, nea=-1, nma=0, nju=2, nsa=0, nur=0, nne=0, npa=0, sp=-27, cp=-143, se=-77, ce=14},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=2, nsa=0, nur=0, nne=0, npa=1, sp=9, cp=49, se=26, ce=-5},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=2, nsa=0, nur=0, nne=0, npa=2, sp=-1166, cp=0, se=0, ce=505},
      new Nut00a_PNMT(){nl=0, nf=2, nd=-2, nom=2, nme=0, nve=0, nea=-2, nma=0, nju=2, nsa=0, nur=0, nne=0, npa=0, sp=-5, cp=0, se=0, ce=2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=0, nsa=5, nur=0, nne=0, npa=2, sp=-6, cp=0, se=0, ce=3},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=3, nea=-5, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-8, cp=0, se=1, ce=4},
      new Nut00a_PNMT(){nl=0, nf=-1, nd=1, nom=0, nme=0, nve=3, nea=-4, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=-4, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=2, nd=-2, nom=1, nme=0, nve=-3, nea=3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=117, cp=0, se=0, ce=-63},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=0, nea=2, nma=-4, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-4, cp=8, se=4, ce=2},
      new Nut00a_PNMT(){nl=0, nf=2, nd=-2, nom=1, nme=0, nve=0, nea=-4, nma=4, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=3, cp=0, se=0, ce=-2},

   /* 251-260 */
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=2, nme=0, nve=-5, nea=7, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-5, cp=0, se=0, ce=2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=3, nma=-6, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=31, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-3, nma=6, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=-5, cp=0, se=1, ce=3},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=0, nea=-4, nma=6, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=4, cp=0, se=0, ce=-2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-3, nma=6, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=-4, cp=0, se=0, ce=2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-3, nma=6, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-24, cp=-13, se=-6, ce=10},
      new Nut00a_PNMT(){nl=0, nf=-1, nd=1, nom=0, nme=0, nve=2, nea=-2, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=3, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=2, nea=-3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=-32, se=-17, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-5, nma=9, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=8, cp=12, se=5, ce=-3},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-5, nma=9, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=3, cp=0, se=0, ce=-1},

   /* 261-270 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=5, nma=-9, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=7, cp=13, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=-1, nd=1, nom=0, nme=0, nve=0, nea=1, nma=0, nju=-2, nsa=0, nur=0, nne=0, npa=0, sp=-3, cp=16, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=2, nd=-2, nom=1, nme=0, nve=0, nea=-2, nma=0, nju=2, nsa=0, nur=0, nne=0, npa=0, sp=50, cp=0, se=0, ce=-27},
      new Nut00a_PNMT(){nl=-2, nf=1, nd=1, nom=1, nme=0, nve=0, nea=1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=-5, se=-3, ce=0},
      new Nut00a_PNMT(){nl=0, nf=-2, nd=2, nom=0, nme=0, nve=3, nea=-3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=13, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-6, nea=10, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=0, cp=5, se=3, ce=1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-6, nea=10, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=24, cp=5, se=2, ce=-11},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-2, nea=3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=5, cp=-11, se=-5, ce=-2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-2, nea=3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=30, cp=-3, se=-2, ce=-16},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=-2, nea=2, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=18, cp=0, se=0, ce=-9},

   /* 271-280 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=2, nea=-3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=8, cp=614, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=2, nea=-3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=3, cp=-3, se=-1, ce=-2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=3, nsa=0, nur=0, nne=0, npa=1, sp=6, cp=17, se=9, ce=-3},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=0, nea=-1, nma=0, nju=3, nsa=0, nur=0, nne=0, npa=0, sp=-3, cp=-9, se=-5, ce=2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=3, nsa=0, nur=0, nne=0, npa=1, sp=0, cp=6, se=3, ce=-1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=3, nsa=0, nur=0, nne=0, npa=2, sp=-127, cp=21, se=9, ce=55},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=4, nma=-8, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=3, cp=5, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-4, nma=8, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-6, cp=-10, se=-4, ce=3},
      new Nut00a_PNMT(){nl=0, nf=-2, nd=2, nom=0, nme=0, nve=0, nea=2, nma=0, nju=-2, nsa=0, nur=0, nne=0, npa=0, sp=5, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-4, nma=7, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=16, cp=9, se=4, ce=-7},

   /* 281-290 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-4, nma=7, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=3, cp=0, se=0, ce=-2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=4, nma=-7, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=22, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=-2, nea=3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=19, se=10, ce=0},
      new Nut00a_PNMT(){nl=0, nf=2, nd=-2, nom=1, nme=0, nve=0, nea=-2, nma=0, nju=3, nsa=0, nur=0, nne=0, npa=0, sp=7, cp=0, se=0, ce=-4},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-5, nma=10, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=0, cp=-5, se=-2, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=-1, nea=2, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=3, se=1, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=4, nsa=0, nur=0, nne=0, npa=2, sp=-9, cp=3, se=1, ce=4},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-3, nma=5, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=17, cp=0, se=0, ce=-7},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-3, nma=5, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=0, cp=-3, se=-2, ce=-1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=3, nma=-5, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-20, cp=34, se=0, ce=0},

   /* 291-300 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=1, nea=-2, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=-10, cp=0, se=1, ce=5},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=1, nea=-3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-4, cp=0, se=0, ce=2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=1, nea=-2, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=22, cp=-87, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-1, nea=2, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=-4, cp=0, se=0, ce=2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-1, nea=2, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-3, cp=-6, se=-2, ce=1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-7, nea=11, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-16, cp=-3, se=-1, ce=7},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-7, nea=11, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=0, cp=-3, se=-2, ce=0},
      new Nut00a_PNMT(){nl=0, nf=-2, nd=2, nom=0, nme=0, nve=4, nea=-4, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=4, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=2, nma=-3, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-68, cp=39, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=2, nd=-2, nom=1, nme=0, nve=-4, nea=4, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=27, cp=0, se=0, ce=-14},

   /* 301-310 */
      new Nut00a_PNMT(){nl=0, nf=-1, nd=1, nom=0, nme=0, nve=4, nea=-5, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=-4, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=1, nma=-1, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-25, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-4, nea=7, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=-12, cp=-3, se=-2, ce=6},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=-4, nea=6, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=3, cp=0, se=0, ce=-1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-4, nea=7, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=3, cp=66, se=29, ce=-1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-4, nea=6, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=490, cp=0, se=0, ce=-213},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-4, nea=6, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=-22, cp=93, se=49, ce=12},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=-4, nea=5, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-7, cp=28, se=15, ce=4},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-4, nea=6, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=-3, cp=13, se=7, ce=2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=4, nea=-6, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-46, cp=14, se=0, ce=0},

   /* 311-320 */
      new Nut00a_PNMT(){nl=-2, nf=0, nd=2, nom=0, nme=0, nve=2, nea=-2, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-5, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=1, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=2, cp=1, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=-1, nd=1, nom=0, nme=0, nve=1, nea=0, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=-3, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=1, nea=-1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-28, cp=0, se=0, ce=15},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-1, nma=0, nju=5, nsa=0, nur=0, nne=0, npa=2, sp=5, cp=0, se=0, ce=-2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=1, nma=-3, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=3, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-1, nma=3, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-11, cp=0, se=0, ce=5},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-7, nma=12, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=0, cp=3, se=1, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-1, nea=1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-3, cp=0, se=0, ce=1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-1, nea=1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=25, cp=106, se=57, ce=-13},

   /* 321-330 */
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=-1, nea=0, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=5, cp=21, se=11, ce=-3},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=1, nea=-1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=1485, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=1, nea=-1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=-7, cp=-32, se=-17, ce=4},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=1, nea=-2, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=5, se=3, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-2, nma=5, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-6, cp=-3, se=-2, ce=3},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-1, nma=0, nju=4, nsa=0, nur=0, nne=0, npa=2, sp=30, cp=-6, se=-2, ce=-13},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=1, nma=0, nju=-4, nsa=0, nur=0, nne=0, npa=0, sp=-4, cp=4, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=-1, nea=1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-19, cp=0, se=0, ce=10},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-6, nma=10, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=0, cp=4, se=2, ce=-1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-6, nma=10, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=3, se=0, ce=0},

   /* 331-340 */
      new Nut00a_PNMT(){nl=0, nf=2, nd=-2, nom=1, nme=0, nve=0, nea=-3, nma=0, nju=3, nsa=0, nur=0, nne=0, npa=0, sp=4, cp=0, se=0, ce=-2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-3, nma=7, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=0, cp=-3, se=-1, ce=0},
      new Nut00a_PNMT(){nl=-2, nf=0, nd=2, nom=0, nme=0, nve=4, nea=-4, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-3, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-5, nma=8, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=5, cp=3, se=1, ce=-2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=5, nma=-8, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=11, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-1, nma=0, nju=3, nsa=0, nur=0, nne=0, npa=2, sp=118, cp=0, se=0, ce=-52},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-1, nma=0, nju=3, nsa=0, nur=0, nne=0, npa=1, sp=0, cp=-5, se=-3, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=1, nma=0, nju=-3, nsa=0, nur=0, nne=0, npa=0, sp=-28, cp=36, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=2, nea=-4, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=5, cp=-5, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-2, nea=4, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=14, cp=-59, se=-31, ce=-8},

   /* 341-350 */
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=-2, nea=3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=9, se=5, ce=1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-2, nea=4, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-458, cp=0, se=0, ce=198},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-6, nea=9, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=0, cp=-45, se=-20, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-6, nea=9, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=9, cp=0, se=0, ce=-5},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=6, nea=-9, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=-3, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=0, nea=1, nma=0, nju=-2, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=-4, se=-2, ce=-1},
      new Nut00a_PNMT(){nl=0, nf=2, nd=-2, nom=1, nme=0, nve=-2, nea=2, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=11, cp=0, se=0, ce=-6},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-4, nma=6, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=6, cp=0, se=0, ce=-2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=4, nma=-6, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-16, cp=23, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=3, nea=-4, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=-4, se=-2, ce=0},

   /* 351-360 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-1, nma=0, nju=2, nsa=0, nur=0, nne=0, npa=2, sp=-5, cp=0, se=0, ce=2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=1, nma=0, nju=-2, nsa=0, nur=0, nne=0, npa=0, sp=-166, cp=269, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=0, nea=1, nma=0, nju=-1, nsa=0, nur=0, nne=0, npa=0, sp=15, cp=0, se=0, ce=-8},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-5, nea=9, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=10, cp=0, se=0, ce=-4},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=3, nma=-4, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-78, cp=45, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-3, nea=4, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=0, cp=-5, se=-2, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-3, nea=4, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=7, cp=0, se=0, ce=-4},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=3, nea=-4, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-5, cp=328, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=3, nea=-4, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=3, cp=0, se=0, ce=-2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=0, nea=2, nma=-2, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=5, cp=0, se=0, ce=-2},

   /* 361-370 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=0, nea=-1, nma=0, nju=2, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=3, se=1, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=1, nma=0, nju=0, nsa=-3, nur=0, nne=0, npa=0, sp=-3, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=1, nma=0, nju=1, nsa=-5, nur=0, nne=0, npa=0, sp=-3, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-1, nma=0, nju=1, nsa=0, nur=0, nne=0, npa=1, sp=0, cp=-4, se=-2, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=1, nma=0, nju=-1, nsa=0, nur=0, nne=0, npa=0, sp=-1223, cp=-26, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=1, nma=0, nju=-1, nsa=0, nur=0, nne=0, npa=1, sp=0, cp=7, se=3, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=1, nma=0, nju=-3, nsa=5, nur=0, nne=0, npa=0, sp=3, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=-3, nea=4, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=3, se=2, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=1, nma=0, nju=0, nsa=-2, nur=0, nne=0, npa=0, sp=-6, cp=20, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=2, nma=-2, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-368, cp=0, se=0, ce=0},

   /* 371-380 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=1, nma=0, nju=0, nsa=-1, nur=0, nne=0, npa=0, sp=-75, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=0, nea=-1, nma=0, nju=1, nsa=0, nur=0, nne=0, npa=0, sp=11, cp=0, se=0, ce=-6},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=0, nea=-2, nma=2, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=3, cp=0, se=0, ce=-2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-8, nea=14, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-3, cp=0, se=0, ce=1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=1, nma=0, nju=2, nsa=-5, nur=0, nne=0, npa=0, sp=-13, cp=-30, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=5, nma=-8, nju=3, nsa=0, nur=0, nne=0, npa=0, sp=21, cp=3, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=5, nma=-8, nju=3, nsa=0, nur=0, nne=0, npa=2, sp=-3, cp=0, se=0, ce=1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=-4, cp=0, se=0, ce=2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=8, cp=-27, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=3, nma=-8, nju=3, nsa=0, nur=0, nne=0, npa=0, sp=-19, cp=-11, se=0, ce=0},

   /* 381-390 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-3, nma=8, nju=-3, nsa=0, nur=0, nne=0, npa=2, sp=-4, cp=0, se=0, ce=2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=1, nma=0, nju=-2, nsa=5, nur=0, nne=0, npa=2, sp=0, cp=5, se=2, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-8, nea=12, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-6, cp=0, se=0, ce=2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-8, nea=12, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-8, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=1, nma=0, nju=1, nsa=-2, nur=0, nne=0, npa=0, sp=-1, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=1, nma=0, nju=0, nsa=1, nur=0, nne=0, npa=2, sp=-14, cp=0, se=0, ce=6},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=2, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=6, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=2, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-74, cp=0, se=0, ce=32},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=1, nma=0, nju=0, nsa=2, nur=0, nne=0, npa=2, sp=0, cp=-3, se=-1, ce=0},
      new Nut00a_PNMT(){nl=0, nf=2, nd=-2, nom=1, nme=0, nve=-5, nea=5, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=4, cp=0, se=0, ce=-2},

   /* 391-400 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=1, nma=0, nju=1, nsa=0, nur=0, nne=0, npa=0, sp=8, cp=11, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=1, nma=0, nju=1, nsa=0, nur=0, nne=0, npa=1, sp=0, cp=3, se=2, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=1, nma=0, nju=1, nsa=0, nur=0, nne=0, npa=2, sp=-262, cp=0, se=0, ce=114},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=3, nea=-6, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=-4, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-3, nea=6, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=-7, cp=0, se=0, ce=4},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-3, nea=6, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=0, cp=-27, se=-12, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-1, nma=4, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-19, cp=-8, se=-4, ce=8},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-5, nea=7, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=202, cp=0, se=0, ce=-87},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-5, nea=7, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=-8, cp=35, se=19, ce=5},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=-5, nea=6, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=4, se=2, ce=0},

   /* 401-410 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=5, nea=-7, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=16, cp=-5, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=2, nd=-2, nom=1, nme=0, nve=0, nea=-1, nma=0, nju=1, nsa=0, nur=0, nne=0, npa=0, sp=5, cp=0, se=0, ce=-3},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-1, nma=0, nju=1, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=-3, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=-1, nve=0, nea=3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=1, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=1, nma=0, nju=2, nsa=0, nur=0, nne=0, npa=2, sp=-35, cp=-48, se=-21, ce=15},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-2, nma=6, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-3, cp=-5, se=-2, ce=1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=2, nea=-2, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=6, cp=0, se=0, ce=-3},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-6, nma=9, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=3, cp=0, se=0, ce=-1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=6, nma=-9, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=-5, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-2, nea=2, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=12, cp=55, se=29, ce=-6},

   /* 411-420 */
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=-2, nea=1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=5, se=3, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=2, nea=-2, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-598, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=2, nea=-2, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=-3, cp=-13, se=-7, ce=1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=1, nma=0, nju=3, nsa=0, nur=0, nne=0, npa=2, sp=-5, cp=-7, se=-3, ce=2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-5, nma=7, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=3, cp=0, se=0, ce=-1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=5, nma=-7, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=5, cp=-7, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=-2, nea=2, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=4, cp=0, se=0, ce=-2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=4, nma=-5, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=16, cp=-6, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=1, nea=-3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=8, cp=-3, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-1, nea=3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=8, cp=-31, se=-16, ce=-4},

   /* 421-430 */
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=-1, nea=2, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=3, se=1, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-1, nea=3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=113, cp=0, se=0, ce=-49},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-7, nea=10, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=0, cp=-24, se=-10, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-7, nea=10, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=4, cp=0, se=0, ce=-2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=3, nma=-3, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=27, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-4, nea=8, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-3, cp=0, se=0, ce=1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-4, nea=5, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=0, cp=-4, se=-2, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-4, nea=5, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=5, cp=0, se=0, ce=-2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=4, nea=-5, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=-3, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=1, nma=1, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-13, cp=0, se=0, ce=6},

   /* 431-440 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-2, nma=0, nju=5, nsa=0, nur=0, nne=0, npa=2, sp=5, cp=0, se=0, ce=-2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=3, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-18, cp=-10, se=-4, ce=8},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=1, nea=0, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-4, cp=-28, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=1, nea=0, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-5, cp=6, se=3, ce=2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-9, nea=13, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-3, cp=0, se=0, ce=1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-1, nma=5, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-5, cp=-9, se=-4, ce=2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-2, nma=0, nju=4, nsa=0, nur=0, nne=0, npa=2, sp=17, cp=0, se=0, ce=-7},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=2, nma=0, nju=-4, nsa=0, nur=0, nne=0, npa=0, sp=11, cp=4, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-2, nma=7, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=0, cp=-6, se=-2, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=2, nma=0, nju=-3, nsa=0, nur=0, nne=0, npa=0, sp=83, cp=15, se=0, ce=0},

   /* 441-450 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-2, nea=5, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=-4, cp=0, se=0, ce=2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-2, nea=5, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=0, cp=-114, se=-49, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-6, nea=8, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=117, cp=0, se=0, ce=-51},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-6, nea=8, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=-5, cp=19, se=10, ce=2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=6, nea=-8, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-3, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=1, nme=0, nve=0, nea=2, nma=0, nju=-2, nsa=0, nur=0, nne=0, npa=0, sp=-3, cp=0, se=0, ce=2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-3, nma=9, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=0, cp=-3, se=-1, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=5, nma=-6, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=3, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=5, nma=-6, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=0, cp=-6, se=-2, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=2, nma=0, nju=-2, nsa=0, nur=0, nne=0, npa=0, sp=393, cp=3, se=0, ce=0},

   /* 451-460 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=2, nma=0, nju=-2, nsa=0, nur=0, nne=0, npa=1, sp=-4, cp=21, se=11, ce=2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=2, nma=0, nju=-2, nsa=0, nur=0, nne=0, npa=2, sp=-6, cp=0, se=-1, ce=3},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-5, nea=10, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-3, cp=8, se=4, ce=1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=4, nma=-4, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=8, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=4, nma=-4, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=18, cp=-29, se=-13, ce=-8},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-3, nea=3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=8, cp=34, se=18, ce=-4},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=3, nea=-3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=89, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=3, nea=-3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=3, cp=12, se=6, ce=-1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=3, nea=-3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=54, cp=-15, se=-7, ce=-24},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=2, nma=0, nju=0, nsa=-3, nur=0, nne=0, npa=0, sp=0, cp=3, se=0, ce=0},

   /* 461-470 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-5, nma=13, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=3, cp=0, se=0, ce=-1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=2, nma=0, nju=-1, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=35, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=2, nma=0, nju=-1, nsa=0, nur=0, nne=0, npa=2, sp=-154, cp=-30, se=-13, ce=67},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=2, nma=0, nju=0, nsa=-2, nur=0, nne=0, npa=0, sp=15, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=2, nma=0, nju=0, nsa=-2, nur=0, nne=0, npa=1, sp=0, cp=4, se=2, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=3, nma=-2, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=9, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=3, nma=-2, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=80, cp=-71, se=-31, ce=-35},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=2, nma=0, nju=0, nsa=-1, nur=0, nne=0, npa=2, sp=0, cp=-20, se=-9, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-6, nma=15, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=11, cp=5, se=2, ce=-5},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-8, nea=15, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=61, cp=-96, se=-42, ce=-27},

   /* 471-480 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-3, nea=9, nma=-4, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=14, cp=9, se=4, ce=-6},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=2, nma=0, nju=2, nsa=-5, nur=0, nne=0, npa=2, sp=-11, cp=-6, se=-3, ce=5},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-2, nma=8, nju=-1, nsa=-5, nur=0, nne=0, npa=2, sp=0, cp=-3, se=-1, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=6, nma=-8, nju=3, nsa=0, nur=0, nne=0, npa=2, sp=123, cp=-415, se=-180, ce=-53},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=2, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=0, se=0, ce=-35},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=2, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-5, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=2, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=7, cp=-32, se=-17, ce=-4},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=1, nme=0, nve=0, nea=1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=-9, se=-5, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=2, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=0, cp=-4, se=2, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=2, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-89, cp=0, se=0, ce=38},

   /* 481-490 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-6, nma=16, nju=-4, nsa=-5, nur=0, nne=0, npa=2, sp=0, cp=-86, se=-19, ce=-6},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-2, nma=8, nju=-3, nsa=0, nur=0, nne=0, npa=2, sp=0, cp=0, se=-19, ce=6},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-2, nma=8, nju=-3, nsa=0, nur=0, nne=0, npa=2, sp=-123, cp=-416, se=-180, ce=53},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=6, nma=-8, nju=1, nsa=5, nur=0, nne=0, npa=2, sp=0, cp=-3, se=-1, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=2, nma=0, nju=-2, nsa=5, nur=0, nne=0, npa=2, sp=12, cp=-6, se=-3, ce=-5},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=3, nea=-5, nma=4, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-13, cp=9, se=4, ce=6},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-8, nea=11, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=0, cp=-15, se=-7, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-8, nea=11, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=3, cp=0, se=0, ce=-1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-8, nea=11, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-62, cp=-97, se=-42, ce=27},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=11, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-11, cp=5, se=2, ce=5},

   /* 491-500 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=2, nma=0, nju=0, nsa=1, nur=0, nne=0, npa=2, sp=0, cp=-19, se=-8, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=3, nea=-3, nma=0, nju=2, nsa=0, nur=0, nne=0, npa=2, sp=-3, cp=0, se=0, ce=1},
      new Nut00a_PNMT(){nl=0, nf=2, nd=-2, nom=1, nme=0, nve=0, nea=4, nma=-8, nju=3, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=4, se=2, ce=0},
      new Nut00a_PNMT(){nl=0, nf=1, nd=-1, nom=0, nme=0, nve=0, nea=1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=3, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=2, nd=-2, nom=1, nme=0, nve=0, nea=-4, nma=8, nju=-3, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=4, se=2, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=1, nma=2, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-85, cp=-70, se=-31, ce=37},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=2, nma=0, nju=1, nsa=0, nur=0, nne=0, npa=2, sp=163, cp=-12, se=-5, ce=-72},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-3, nea=7, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-63, cp=-16, se=-7, ce=28},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=4, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-21, cp=-32, se=-14, ce=9},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-5, nea=6, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=0, cp=-3, se=-1, ce=0},

   /* 501-510 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-5, nea=6, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=3, cp=0, se=0, ce=-2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=5, nea=-6, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=8, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=5, nea=-6, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=3, cp=10, se=4, ce=-1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=2, nma=0, nju=2, nsa=0, nur=0, nne=0, npa=2, sp=3, cp=0, se=0, ce=-1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-1, nma=6, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=0, cp=-7, se=-3, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=7, nma=-9, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=0, cp=-4, se=-2, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=2, nea=-1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=6, cp=19, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=2, nea=-1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=5, cp=-173, se=-75, ce=-2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=6, nma=-7, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=0, cp=-7, se=-3, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=5, nma=-5, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=7, cp=-12, se=-5, ce=-3},

   /* 511-520 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-1, nea=4, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=-3, cp=0, se=0, ce=2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-1, nea=4, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=3, cp=-4, se=-2, ce=-1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-7, nea=9, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=74, cp=0, se=0, ce=-32},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-7, nea=9, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=-3, cp=12, se=6, ce=2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=4, nma=-3, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=26, cp=-14, se=-6, ce=-11},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=3, nma=-1, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=19, cp=0, se=0, ce=-8},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-4, nea=4, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=6, cp=24, se=13, ce=-3},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=4, nea=-4, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=83, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=4, nea=-4, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=0, cp=-10, se=-5, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=4, nea=-4, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=11, cp=-3, se=-1, ce=-5},

   /* 521-530 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=2, nma=1, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=3, cp=0, se=1, ce=-1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-3, nma=0, nju=5, nsa=0, nur=0, nne=0, npa=2, sp=3, cp=0, se=0, ce=-1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=1, nea=1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-4, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=1, nea=1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=5, cp=-23, se=-12, ce=-3},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=1, nea=1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-339, cp=0, se=0, ce=147},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-9, nea=12, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=0, cp=-10, se=-5, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=3, nma=0, nju=-4, nsa=0, nur=0, nne=0, npa=0, sp=5, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=2, nd=-2, nom=1, nme=0, nve=1, nea=-1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=3, cp=0, se=0, ce=-1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=7, nma=-8, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=0, cp=-4, se=-2, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=3, nma=0, nju=-3, nsa=0, nur=0, nne=0, npa=0, sp=18, cp=-3, se=0, ce=0},

   /* 531-540 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=3, nma=0, nju=-3, nsa=0, nur=0, nne=0, npa=2, sp=9, cp=-11, se=-5, ce=-4},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-2, nea=6, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-8, cp=0, se=0, ce=4},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-6, nea=7, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=3, cp=0, se=0, ce=-1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=6, nea=-7, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=9, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=6, nma=-6, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=6, cp=-9, se=-4, ce=-2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=3, nma=0, nju=-2, nsa=0, nur=0, nne=0, npa=0, sp=-4, cp=-12, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=3, nma=0, nju=-2, nsa=0, nur=0, nne=0, npa=2, sp=67, cp=-91, se=-39, ce=-29},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=5, nma=-4, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=30, cp=-18, se=-8, ce=-13},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=3, nea=-2, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=3, nea=-2, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=0, cp=-114, se=-50, ce=0},

   /* 541-550 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=3, nma=0, nju=-1, nsa=0, nur=0, nne=0, npa=2, sp=0, cp=0, se=0, ce=23},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=3, nma=0, nju=-1, nsa=0, nur=0, nne=0, npa=2, sp=517, cp=16, se=7, ce=-224},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=3, nma=0, nju=0, nsa=-2, nur=0, nne=0, npa=2, sp=0, cp=-7, se=-3, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=4, nma=-2, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=143, cp=-3, se=-1, ce=-62},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=3, nma=0, nju=0, nsa=-1, nur=0, nne=0, npa=2, sp=29, cp=0, se=0, ce=-13},
      new Nut00a_PNMT(){nl=0, nf=2, nd=-2, nom=1, nme=0, nve=0, nea=1, nma=0, nju=-1, nsa=0, nur=0, nne=0, npa=0, sp=-4, cp=0, se=0, ce=2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-8, nea=16, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-6, cp=0, se=0, ce=3},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=3, nma=0, nju=2, nsa=-5, nur=0, nne=0, npa=2, sp=5, cp=12, se=5, ce=-2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=7, nma=-8, nju=3, nsa=0, nur=0, nne=0, npa=2, sp=-25, cp=0, se=0, ce=11},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-5, nma=16, nju=-4, nsa=-5, nur=0, nne=0, npa=2, sp=-3, cp=0, se=0, ce=1},

   /* 551-560 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=0, cp=4, se=2, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=-1, nma=8, nju=-3, nsa=0, nur=0, nne=0, npa=2, sp=-22, cp=12, se=5, ce=10},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-8, nea=10, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=50, cp=0, se=0, ce=-22},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-8, nea=10, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=0, cp=7, se=4, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-8, nea=10, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=0, cp=3, se=1, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=2, nma=2, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-4, cp=4, se=2, ce=2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=3, nma=0, nju=1, nsa=0, nur=0, nne=0, npa=2, sp=-5, cp=-11, se=-5, ce=2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-3, nea=8, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=0, cp=4, se=2, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-5, nea=5, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=4, cp=17, se=9, ce=-2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=5, nea=-5, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=59, cp=0, se=0, ce=0},

   /* 561-570 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=5, nea=-5, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=0, cp=-4, se=-2, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=5, nea=-5, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-8, cp=0, se=0, ce=4},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=2, nea=0, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-3, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=2, nea=0, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=4, cp=-15, se=-8, ce=-2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=2, nea=0, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=370, cp=-8, se=0, ce=-160},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=7, nma=-7, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=0, cp=0, se=-3, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=7, nma=-7, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=0, cp=3, se=1, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=6, nma=-5, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-6, cp=3, se=1, ce=3},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=7, nea=-8, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=6, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=5, nma=-3, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-10, cp=0, se=0, ce=4},

   /* 571-580 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=4, nea=-3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=0, cp=9, se=4, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=1, nea=2, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=4, cp=17, se=7, ce=-2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-9, nea=11, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=34, cp=0, se=0, ce=-15},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-9, nea=11, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=0, cp=5, se=3, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=4, nma=0, nju=-4, nsa=0, nur=0, nne=0, npa=2, sp=-5, cp=0, se=0, ce=2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=4, nma=0, nju=-3, nsa=0, nur=0, nne=0, npa=2, sp=-37, cp=-7, se=-3, ce=16},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-6, nea=6, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=3, cp=13, se=7, ce=-2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=6, nea=-6, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=40, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=6, nea=-6, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=0, cp=-3, se=-2, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=4, nma=0, nju=-2, nsa=0, nur=0, nne=0, npa=2, sp=-184, cp=-3, se=-1, ce=80},

   /* 581-590 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=6, nma=-4, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=-3, cp=0, se=0, ce=1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=3, nea=-1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-3, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=3, nea=-1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=0, cp=-10, se=-6, ce=-1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=3, nea=-1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=31, cp=-6, se=0, ce=-13},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=4, nma=0, nju=-1, nsa=0, nur=0, nne=0, npa=2, sp=-3, cp=-32, se=-14, ce=1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=4, nma=0, nju=0, nsa=-2, nur=0, nne=0, npa=2, sp=-7, cp=0, se=0, ce=3},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=5, nma=-2, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=0, cp=-8, se=-4, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=4, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=3, cp=-4, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=8, nea=-9, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=4, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=5, nea=-4, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=0, cp=3, se=1, ce=0},

   /* 591-600 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=2, nea=1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=19, cp=-23, se=-10, ce=2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=2, nea=1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=0, cp=0, se=0, ce=-10},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=2, nea=1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=0, cp=3, se=2, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-7, nea=7, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=0, cp=9, se=5, ce=-1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=7, nea=-7, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=28, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=4, nea=-2, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=0, cp=-7, se=-4, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=4, nea=-2, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=8, cp=-4, se=0, ce=-4},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=4, nea=-2, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=0, se=-2, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=4, nea=-2, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=3, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=5, nma=0, nju=-4, nsa=0, nur=0, nne=0, npa=2, sp=-3, cp=0, se=0, ce=1},

   /* 601-610 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=5, nma=0, nju=-3, nsa=0, nur=0, nne=0, npa=2, sp=-9, cp=0, se=1, ce=4},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=5, nma=0, nju=-2, nsa=0, nur=0, nne=0, npa=2, sp=3, cp=12, se=5, ce=-1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=3, nea=0, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=17, cp=-3, se=-1, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-8, nea=8, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=0, cp=7, se=4, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=8, nea=-8, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=19, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=5, nea=-3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=0, cp=-5, se=-3, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=5, nea=-3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=14, cp=-3, se=0, ce=-1},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-9, nea=9, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=0, cp=0, se=-1, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-9, nea=9, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=0, cp=0, se=0, ce=-5},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=-9, nea=9, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=0, cp=5, se=3, ce=0},

   /* 611-620 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=9, nea=-9, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=13, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=6, nea=-4, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=0, cp=-3, se=-2, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=6, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=2, cp=9, se=4, ce=3},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=6, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=0, se=0, ce=-4},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=6, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=8, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=6, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=0, cp=4, se=2, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=6, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=6, cp=0, se=0, ce=-3},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=6, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=6, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=6, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=1, sp=0, cp=3, se=1, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=6, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=5, cp=0, se=0, ce=-2},

   /* 621-630 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=0, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=2, sp=3, cp=0, se=0, ce=-1},
      new Nut00a_PNMT(){nl=1, nf=0, nd=-2, nom=0, nme=0, nve=0, nea=2, nma=0, nju=-2, nsa=0, nur=0, nne=0, npa=0, sp=-3, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=1, nf=0, nd=-2, nom=0, nme=0, nve=2, nea=-2, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=6, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=1, nf=0, nd=-2, nom=0, nme=0, nve=0, nea=1, nma=0, nju=-1, nsa=0, nur=0, nne=0, npa=0, sp=7, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=1, nf=0, nd=-2, nom=0, nme=0, nve=1, nea=-1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-4, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=-1, nf=0, nd=0, nom=0, nme=0, nve=3, nea=-3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=4, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=-1, nf=0, nd=0, nom=0, nme=0, nve=0, nea=2, nma=0, nju=-2, nsa=0, nur=0, nne=0, npa=0, sp=6, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=-1, nf=0, nd=2, nom=0, nme=0, nve=0, nea=4, nma=-8, nju=3, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=-4, se=0, ce=0},
      new Nut00a_PNMT(){nl=1, nf=0, nd=-2, nom=0, nme=0, nve=0, nea=4, nma=-8, nju=3, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=-4, se=0, ce=0},
      new Nut00a_PNMT(){nl=-2, nf=0, nd=2, nom=0, nme=0, nve=0, nea=4, nma=-8, nju=3, nsa=0, nur=0, nne=0, npa=0, sp=5, cp=0, se=0, ce=0},

   /* 631-640 */
      new Nut00a_PNMT(){nl=-1, nf=0, nd=0, nom=0, nme=0, nve=0, nea=2, nma=0, nju=-3, nsa=0, nur=0, nne=0, npa=0, sp=-3, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=-1, nf=0, nd=0, nom=0, nme=0, nve=0, nea=1, nma=0, nju=-1, nsa=0, nur=0, nne=0, npa=0, sp=4, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=-1, nf=0, nd=0, nom=0, nme=0, nve=1, nea=-1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-5, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=-1, nf=0, nd=2, nom=0, nme=0, nve=2, nea=-2, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=4, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=1, nf=-1, nd=1, nom=0, nme=0, nve=0, nea=1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=3, se=0, ce=0},
      new Nut00a_PNMT(){nl=-1, nf=0, nd=2, nom=0, nme=0, nve=0, nea=2, nma=0, nju=-3, nsa=0, nur=0, nne=0, npa=0, sp=13, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=-2, nf=0, nd=0, nom=0, nme=0, nve=0, nea=2, nma=0, nju=-3, nsa=0, nur=0, nne=0, npa=0, sp=21, cp=11, se=0, ce=0},
      new Nut00a_PNMT(){nl=1, nf=0, nd=0, nom=0, nme=0, nve=0, nea=4, nma=-8, nju=3, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=-5, se=0, ce=0},
      new Nut00a_PNMT(){nl=-1, nf=1, nd=-1, nom=1, nme=0, nve=0, nea=-1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=-5, se=-2, ce=0},
      new Nut00a_PNMT(){nl=1, nf=1, nd=-1, nom=1, nme=0, nve=0, nea=-1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=5, se=3, ce=0},

   /* 641-650 */
      new Nut00a_PNMT(){nl=-1, nf=0, nd=0, nom=0, nme=0, nve=0, nea=4, nma=-8, nju=3, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=-5, se=0, ce=0},
      new Nut00a_PNMT(){nl=-1, nf=0, nd=2, nom=1, nme=0, nve=0, nea=2, nma=0, nju=-2, nsa=0, nur=0, nne=0, npa=0, sp=-3, cp=0, se=0, ce=2},
      new Nut00a_PNMT(){nl=0, nf=0, nd=0, nom=0, nme=0, nve=0, nea=2, nma=0, nju=-2, nsa=0, nur=0, nne=0, npa=0, sp=20, cp=10, se=0, ce=0},
      new Nut00a_PNMT(){nl=-1, nf=0, nd=2, nom=0, nme=0, nve=0, nea=2, nma=0, nju=-2, nsa=0, nur=0, nne=0, npa=0, sp=-34, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=-1, nf=0, nd=2, nom=0, nme=0, nve=3, nea=-3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-19, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=1, nf=0, nd=-2, nom=1, nme=0, nve=0, nea=-2, nma=0, nju=2, nsa=0, nur=0, nne=0, npa=0, sp=3, cp=0, se=0, ce=-2},
      new Nut00a_PNMT(){nl=1, nf=2, nd=-2, nom=2, nme=0, nve=-3, nea=3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-3, cp=0, se=0, ce=1},
      new Nut00a_PNMT(){nl=1, nf=2, nd=-2, nom=2, nme=0, nve=0, nea=-2, nma=0, nju=2, nsa=0, nur=0, nne=0, npa=0, sp=-6, cp=0, se=0, ce=3},
      new Nut00a_PNMT(){nl=1, nf=0, nd=0, nom=0, nme=0, nve=1, nea=-1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-4, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=1, nf=0, nd=0, nom=0, nme=0, nve=0, nea=1, nma=0, nju=-1, nsa=0, nur=0, nne=0, npa=0, sp=3, cp=0, se=0, ce=0},

   /* 651-660 */
      new Nut00a_PNMT(){nl=0, nf=0, nd=-2, nom=0, nme=0, nve=2, nea=-2, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=3, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=-2, nom=0, nme=0, nve=0, nea=1, nma=0, nju=-1, nsa=0, nur=0, nne=0, npa=0, sp=4, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=2, nd=0, nom=2, nme=0, nve=-2, nea=2, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=3, cp=0, se=0, ce=-1},
      new Nut00a_PNMT(){nl=0, nf=2, nd=0, nom=2, nme=0, nve=0, nea=-1, nma=0, nju=1, nsa=0, nur=0, nne=0, npa=0, sp=6, cp=0, se=0, ce=-3},
      new Nut00a_PNMT(){nl=0, nf=2, nd=0, nom=2, nme=0, nve=-1, nea=1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-8, cp=0, se=0, ce=3},
      new Nut00a_PNMT(){nl=0, nf=2, nd=0, nom=2, nme=0, nve=-2, nea=3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=3, se=1, ce=0},
      new Nut00a_PNMT(){nl=0, nf=0, nd=2, nom=0, nme=0, nve=0, nea=2, nma=0, nju=-2, nsa=0, nur=0, nne=0, npa=0, sp=-3, cp=0, se=0, ce=0},
      new Nut00a_PNMT(){nl=0, nf=1, nd=1, nom=2, nme=0, nve=0, nea=1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=-3, se=-2, ce=0},
      new Nut00a_PNMT(){nl=1, nf=2, nd=0, nom=2, nme=0, nve=0, nea=1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=126, cp=-63, se=-27, ce=-55},
      new Nut00a_PNMT(){nl=-1, nf=2, nd=0, nom=2, nme=0, nve=10, nea=-3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-5, cp=0, se=1, ce=2},

   /* 661-670 */
      new Nut00a_PNMT(){nl=0, nf=1, nd=1, nom=1, nme=0, nve=0, nea=1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-3, cp=28, se=15, ce=2},
      new Nut00a_PNMT(){nl=1, nf=2, nd=0, nom=2, nme=0, nve=0, nea=1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=5, cp=0, se=1, ce=-2},
      new Nut00a_PNMT(){nl=0, nf=2, nd=0, nom=2, nme=0, nve=0, nea=4, nma=-8, nju=3, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=9, se=4, ce=1},
      new Nut00a_PNMT(){nl=0, nf=2, nd=0, nom=2, nme=0, nve=0, nea=-4, nma=8, nju=-3, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=9, se=4, ce=-1},
      new Nut00a_PNMT(){nl=-1, nf=2, nd=0, nom=2, nme=0, nve=0, nea=-4, nma=8, nju=-3, nsa=0, nur=0, nne=0, npa=0, sp=-126, cp=-63, se=-27, ce=55},
      new Nut00a_PNMT(){nl=2, nf=2, nd=-2, nom=2, nme=0, nve=0, nea=-2, nma=0, nju=3, nsa=0, nur=0, nne=0, npa=0, sp=3, cp=0, se=0, ce=-1},
      new Nut00a_PNMT(){nl=1, nf=2, nd=0, nom=1, nme=0, nve=0, nea=-2, nma=0, nju=3, nsa=0, nur=0, nne=0, npa=0, sp=21, cp=-11, se=-6, ce=-11},
      new Nut00a_PNMT(){nl=0, nf=1, nd=1, nom=0, nme=0, nve=0, nea=1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=-4, se=0, ce=0},
      new Nut00a_PNMT(){nl=-1, nf=2, nd=0, nom=1, nme=0, nve=0, nea=1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-21, cp=-11, se=-6, ce=11},
      new Nut00a_PNMT(){nl=-2, nf=2, nd=2, nom=2, nme=0, nve=0, nea=2, nma=0, nju=-2, nsa=0, nur=0, nne=0, npa=0, sp=-3, cp=0, se=0, ce=1},

   /* 671-680 */
      new Nut00a_PNMT(){nl=0, nf=2, nd=0, nom=2, nme=0, nve=2, nea=-3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=3, se=1, ce=0},
      new Nut00a_PNMT(){nl=0, nf=2, nd=0, nom=2, nme=0, nve=1, nea=-1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=8, cp=0, se=0, ce=-4},
      new Nut00a_PNMT(){nl=0, nf=2, nd=0, nom=2, nme=0, nve=0, nea=1, nma=0, nju=-1, nsa=0, nur=0, nne=0, npa=0, sp=-6, cp=0, se=0, ce=3},
      new Nut00a_PNMT(){nl=0, nf=2, nd=0, nom=2, nme=0, nve=2, nea=-2, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-3, cp=0, se=0, ce=1},
      new Nut00a_PNMT(){nl=-1, nf=2, nd=2, nom=2, nme=0, nve=0, nea=-1, nma=0, nju=1, nsa=0, nur=0, nne=0, npa=0, sp=3, cp=0, se=0, ce=-1},
      new Nut00a_PNMT(){nl=1, nf=2, nd=0, nom=2, nme=0, nve=-1, nea=1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-3, cp=0, se=0, ce=1},
      new Nut00a_PNMT(){nl=-1, nf=2, nd=2, nom=2, nme=0, nve=0, nea=2, nma=0, nju=-3, nsa=0, nur=0, nne=0, npa=0, sp=-5, cp=0, se=0, ce=2},
      new Nut00a_PNMT(){nl=2, nf=2, nd=0, nom=2, nme=0, nve=0, nea=2, nma=0, nju=-3, nsa=0, nur=0, nne=0, npa=0, sp=24, cp=-12, se=-5, ce=-11},
      new Nut00a_PNMT(){nl=1, nf=2, nd=0, nom=2, nme=0, nve=0, nea=-4, nma=8, nju=-3, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=3, se=1, ce=0},
      new Nut00a_PNMT(){nl=1, nf=2, nd=0, nom=2, nme=0, nve=0, nea=4, nma=-8, nju=3, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=3, se=1, ce=0},

   /* 681-687 */
      new Nut00a_PNMT(){nl=1, nf=1, nd=1, nom=1, nme=0, nve=0, nea=1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=0, cp=3, se=2, ce=0},
      new Nut00a_PNMT(){nl=0, nf=2, nd=0, nom=2, nme=0, nve=0, nea=1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=-24, cp=-12, se=-5, ce=10},
      new Nut00a_PNMT(){nl=2, nf=2, nd=0, nom=1, nme=0, nve=0, nea=1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=4, cp=0, se=-1, ce=-2},
      new Nut00a_PNMT(){nl=-1, nf=2, nd=2, nom=2, nme=0, nve=0, nea=2, nma=0, nju=-2, nsa=0, nur=0, nne=0, npa=0, sp=13, cp=0, se=0, ce=-6},
      new Nut00a_PNMT(){nl=-1, nf=2, nd=2, nom=2, nme=0, nve=3, nea=-3, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=7, cp=0, se=0, ce=-3},
      new Nut00a_PNMT(){nl=1, nf=2, nd=0, nom=2, nme=0, nve=1, nea=-1, nma=0, nju=0, nsa=0, nur=0, nne=0, npa=0, sp=3, cp=0, se=0, ce=-1},
      new Nut00a_PNMT(){nl=0, nf=2, nd=2, nom=2, nme=0, nve=0, nea=2, nma=0, nju=-2, nsa=0, nur=0, nne=0, npa=0, sp=3, cp=0, se=0, ce=-1},
        };
        #endregion

        /// <summary>
        /// Nutation,  2000A model (MHB2000 luni-solar and planetary nutation with free core nutation omitted).
        /// <para>Given:</para>
        /// <param name="date1">TT as a 2-part Julian Date (see SOFA comments)</param>
        /// <param name="date2">TT as a 2-part Julian Date (see SOFA comments)</param>
        /// <para>Returned:</para>
        /// <param name="dpsi">Nutation in longitude, luni-solar + planetary, radians (output)</param>
        /// <param name="deps">Nutation in obliquity, luni-solar + planetary, radians (output)</param>
        /// </summary>
        public static void Nut00a(double date1, double date2, out double dpsi, out double deps)
        {
            int i;
            double arg,
                sarg, carg;

            // Units of 0.1 microarcsecond to radians
            const double U2R = DAS2R / 1e7;

            /* Number of terms in the luni-solar nutation model */
            var NLS = xls.Length;

            /* Number of terms in the planetary nutation model */
            var NPL = xpl.Length;


            /* ------------------------------------------------------------------ */
            /* Interval between fundamental date J2000.0 and given date (JC). */
            var t = ((date1 - DJ00) + date2) / DJC;

            /* ------------------- */
            /* LUNI-SOLAR NUTATION */
            /* ------------------- */
            /* Fundamental (Delaunay) arguments */
            /* Mean anomaly of the Moon (IERS 2003). */
            var el = Fal03(t);

            /* Mean anomaly of the Sun (MHB2000). */
            var elp = (1287104.79305 +
                       t * (129596581.0481 +
                            t * (-0.5532 +
                                 t * (0.000136 +
                                      t * (-0.00001149))))) % TURNAS * DAS2R;

            /* Mean longitude of the Moon minus that of the ascending node */
            /* (IERS 2003). */
            var f = Faf03(t);

            /* Mean elongation of the Moon from the Sun (MHB2000). */
            var d = (1072260.70369 +
                     t * (1602961601.2090 +
                          t * (-6.3706 +
                               t * (0.006593 +
                                    t * (-0.00003169))))) % TURNAS * DAS2R;

            /* Mean longitude of the ascending node of the Moon (IERS 2003). */
            var om = Faom03(t);

            /* Initialize the nutation values. */
            var dp = 0.0;
            var de = 0.0;

            /* Summation of luni-solar nutation series (in reverse order). */
            for (i = NLS - 1; i >= 0; i--)
            {

                /* Argument and functions. */
                arg = ((double)xls[i].nl * el +
                           (double)xls[i].nlp * elp +
                           (double)xls[i].nf * f +
                           (double)xls[i].nd * d +
                           (double)xls[i].nom * om) % D2PI;
                sarg = Sin(arg);
                carg = Cos(arg);

                /* Term. */
                dp += (xls[i].sp + xls[i].spt * t) * sarg + xls[i].cp * carg;
                de += (xls[i].ce + xls[i].cet * t) * carg + xls[i].se * sarg;
            }

            /* Convert from 0.1 microarcsec units to radians. */
            var dpsils = dp * U2R;
            var depsls = de * U2R;
            /* ------------------ */
            /* PLANETARY NUTATION */
            /* ------------------ */
            /* n.b.  The MHB2000 code computes the luni-solar and planetary nutation */
            /* in different functions, using slightly different Delaunay */
            /* arguments in the two cases.  This behaviour is faithfully */
            /* reproduced here.  Use of the IERS 2003 expressions for both */
            /* cases leads to negligible changes, well below */
            /* 0.1 microarcsecond. */
            /* Mean anomaly of the Moon (MHB2000). */
            var al = (2.35555598 + 8328.6914269554 * t) % D2PI;

            /* Mean longitude of the Moon minus that of the ascending node */
            /*(MHB2000). */
            var af = (1.627905234 + 8433.466158131 * t) % D2PI;

            /* Mean elongation of the Moon from the Sun (MHB2000). */
            var ad = (5.198466741 + 7771.3771468121 * t) % D2PI;

            /* Mean longitude of the ascending node of the Moon (MHB2000). */
            var aom = (2.18243920 - 33.757045 * t) % D2PI;

            /* General accumulated precession in longitude (IERS 2003). */
            var apa = Fapa03(t);

            /* Planetary longitudes, Mercury through Uranus (IERS 2003). */
            var alme = Fame03(t);
            var alve = Fave03(t);
            var alea = Fae03(t);
            var alma = Fama03(t);
            var alju = Faju03(t);
            var alsa = Fasa03(t);
            var alur = Faur03(t);

            /* Neptune longitude (MHB2000). */
            var alne = (5.321159000 + 3.8127774000 * t) % D2PI;

            /* Initialize the nutation values. */
            dp = 0.0;
            de = 0.0;

            /* Summation of planetary nutation series (in reverse order). */
            for (i = NPL - 1; i >= 0; i--)
            {

                /* Argument and functions. */
                arg = ((double)xpl[i].nl * al +
                           (double)xpl[i].nf * af +
                           (double)xpl[i].nd * ad +
                           (double)xpl[i].nom * aom +
                           (double)xpl[i].nme * alme +
                           (double)xpl[i].nve * alve +
                           (double)xpl[i].nea * alea +
                           (double)xpl[i].nma * alma +
                           (double)xpl[i].nju * alju +
                           (double)xpl[i].nsa * alsa +
                           (double)xpl[i].nur * alur +
                           (double)xpl[i].nne * alne +
                           (double)xpl[i].npa * apa) % D2PI;
                sarg = Sin(arg);
                carg = Cos(arg);

                /* Term. */
                dp += (double)xpl[i].sp * sarg + (double)xpl[i].cp * carg;
                de += (double)xpl[i].se * sarg + (double)xpl[i].ce * carg;

            }

            /* Convert from 0.1 microarcsec units to radians. */
            var dpsipl = dp * U2R;
            var depspl = de * U2R;
            /* ------- */
            /* RESULTS */
            /* ------- */
            /* Add luni-solar and planetary components. */
            dpsi = dpsils + dpsipl;
            deps = depsls + depspl;

            /* Finished. */
        }
    }
}
