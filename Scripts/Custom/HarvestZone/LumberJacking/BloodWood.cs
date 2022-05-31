using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Engines.Harvest
{
    public class BloodWood : HarvestZone
    {
        public static void Initialize()
        {
            HarvestZone.AddZone(new BloodWood());
        }

        public BloodWood()
            : base(ZoneType.Lumberjacking)
        {

              Map = Map.Felucca;
//            Map = Map.Ilshenar;
//            Map = Map.Trammel;


              Area.Add(new Rectangle3D(new Point3D(3033, 1945, 0), new Point3D(3200 ,1955, 0)));
//            Area.Add(new Rectangle3D(new Point3D(0, 0, 0), new Point3D(9999, 9999, 0)));
//            Area.Add(new Rectangle3D(new Point3D(0, 0, 0), new Point3D(9999, 9999, 0)));
//            Area.Add(new Rectangle3D(new Point3D(0, 0, 0), new Point3D(9999, 9999, 0)));
//            Area.Add(new Rectangle3D(new Point3D(0, 0, 0), new Point3D(9999, 9999, 0)));

            Veins = new HarvestVein[]
                {
					new HarvestVein( 30.0, 0.0, Resources[9], null ), // Log 
		//			new HarvestVein( 10.0, 0.0, Resources[10], Resources[9]), // OakLog
		//			new HarvestVein( 10.0, 0.0, Resources[11], Resources[9]), // AshLog 
		//			new HarvestVein( 70.0, 0.0, Resources[12], Resources[9]), // YewLog 
		//			new HarvestVein( 10.0, 0.0, Resources[13], Resources[9]), // HeartwoodLog 
					new HarvestVein( 70.0, 0.0, Resources[14], Resources[9]), // BloodwoodLog 
		//			new HarvestVein( 10.0, 0.0, Resources[15], Resources[9]), // FrostwoodLog 

	};
}
}
}
