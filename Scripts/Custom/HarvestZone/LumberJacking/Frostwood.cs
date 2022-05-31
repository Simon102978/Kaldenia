using System;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Engines.Harvest
{
    public class FrostWood : HarvestZone
    {
        public static void Initialize()
        {
            HarvestZone.AddZone(new FrostWood());
        }

        public FrostWood()
            : base(ZoneType.Lumberjacking)
        {

              Map = Map.Felucca;
//            Map = Map.Ilshenar;
//            Map = Map.Trammel;


              Area.Add(new Rectangle3D(new Point3D(1591,211 , 0), new Point3D(1855 ,231, 0)));
//            Area.Add(new Rectangle3D(new Point3D(0, 0, 0), new Point3D(9999, 9999, 0)));
//            Area.Add(new Rectangle3D(new Point3D(0, 0, 0), new Point3D(9999, 9999, 0)));
//            Area.Add(new Rectangle3D(new Point3D(0, 0, 0), new Point3D(9999, 9999, 0)));
//            Area.Add(new Rectangle3D(new Point3D(0, 0, 0), new Point3D(9999, 9999, 0)));

            Veins = new HarvestVein[]
                {
					new HarvestVein( 50.0, 0.0, Resources[9], null ), // Log 
			//		new HarvestVein( 10.0, 0.0, Resources[10], Resources[9]), // OakLog
		//			new HarvestVein( 70.0, 0.0, Resources[11], Resources[9]), // AshLog 
		//			new HarvestVein( 70.0, 0.0, Resources[12], Resources[9]), // YewLog 
		//			new HarvestVein( 10.0, 0.0, Resources[13], Resources[9]), // HeartwoodLog 
		//			new HarvestVein( 10.0, 0.0, Resources[14], Resources[9]), // BloodwoodLog 
					new HarvestVein( 50.0, 0.0, Resources[15], Resources[9]), // FrostwoodLog 






	};
}
}
}
