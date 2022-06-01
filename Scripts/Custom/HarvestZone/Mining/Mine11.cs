using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Engines.Harvest
{
    public class Mine11 : HarvestZone
    {
        public static void Initialize()
        {
            HarvestZone.AddZone(new Mine11());
        }

        public Mine11()
            : base(ZoneType.Mining)
        {
                          Map = Map.Felucca;
            //            Map = Map.Ilshenar;
            //            Map = Map.Trammel;

                          Area.Add(new Rectangle3D(new Point3D(2115, 1156, 0), new Point3D(2206, 1230, 0)));
            //            Area.Add(new Rectangle3D(new Point3D(0, 0, 0), new Point3D(9999, 9999, 0)));
            //            Area.Add(new Rectangle3D(new Point3D(0, 0, 0), new Point3D(9999, 9999, 0)));
            //            Area.Add(new Rectangle3D(new Point3D(0, 0, 0), new Point3D(9999, 9999, 0)));
            //            Area.Add(new Rectangle3D(new Point3D(0, 0, 0), new Point3D(9999, 9999, 0)));

            Veins = new HarvestVein[]
                {
					new HarvestVein( 40.0, 0.0, Resources[0], null ), // Iron
	   			//	new HarvestVein( 40.0, 0.0, Resources[1], Resources[0]), // DullCopperOre - 65 
				//	new HarvestVein( 20.0, 0.0, Resources[2], Resources[0]), // ShadowIronOre - 70
				//	new HarvestVein( 20.0, 0.0, Resources[3], Resources[0]), // CopperOre - 75
				//	new HarvestVein( 20.0, 0.0, Resources[4], Resources[0]), // BronzeOre - 80
				//	new HarvestVein( 20.0, 0.0, Resources[5], Resources[0]), // GoldOre - 85
				//	new HarvestVein( 20.0, 0.0, Resources[6], Resources[0]), // AgapiteOre 90
					new HarvestVein( 60.0, 0.0, Resources[7], Resources[0]), // VeriteOre 95
				//	new HarvestVein( 20.0, 0.0, Resources[8], Resources[0]), // ValoriteOre - 99
                };
        }
    }
}
