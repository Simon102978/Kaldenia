namespace Server.Engines.ArenaSystem
{
    [PropertyObject]
    public class ArenaDefinition
    {
        [CommandProperty(AccessLevel.GameMaster)]
        public string Name { get; private set; }

  /*      [CommandProperty(AccessLevel.GameMaster)]
        public Point3D StoneLocation { get; private set; }
  */
        [CommandProperty(AccessLevel.GameMaster)]
        public Point3D ManagerLocation { get; private set; }

        [CommandProperty(AccessLevel.GameMaster)]
        public Point3D BannerLocation1 { get; private set; }

        [CommandProperty(AccessLevel.GameMaster)]
        public Point3D BannerLocation2 { get; private set; }

        [CommandProperty(AccessLevel.GameMaster)]
        public Point3D GateLocation { get; private set; }

        [CommandProperty(AccessLevel.GameMaster)]
        public int BannerID1 { get; private set; }

        [CommandProperty(AccessLevel.GameMaster)]
        public int BannerID2 { get; private set; }

		public int ArenaZ { get; private set; }

		public int DeadZ { get; private set; }

		public Rectangle2D[] EffectAreas { get; private set; }
        public Rectangle2D[] RegionBounds { get; private set; }
   
        public Rectangle2D[] StartLocations { get; private set; }

        [CommandProperty(AccessLevel.GameMaster)]
        public Rectangle2D StartLocation1 { get; private set; }

        [CommandProperty(AccessLevel.GameMaster)]
        public Rectangle2D StartLocation2 { get; private set; }

        [CommandProperty(AccessLevel.GameMaster)]
        public Rectangle2D EjectLocation { get; private set; }

        [CommandProperty(AccessLevel.GameMaster)]
        public Rectangle2D DeadEjectLocation { get; private set; }

        [CommandProperty(AccessLevel.GameMaster)]
        public int MapIndex { get; private set; }

        [CommandProperty(AccessLevel.GameMaster)]
        public Map Map => Map.Maps[MapIndex];

        public ArenaDefinition(
            string name,
            int mapIndex,
    //        Point3D stoneLoc,
            Point3D manLoc,
            Point3D banloc1,
            Point3D banloc2,
            int id1,
            int id2,
			int z,
            Rectangle2D[] effectAreas,
            Rectangle2D[] startLocs,
            Point3D gateLoc,
            Rectangle2D[] bounds,
            Rectangle2D eject,
            Rectangle2D deadEject,
			int zDead)
        {
            Name = name;
            MapIndex = mapIndex;
     //       StoneLocation = stoneLoc;
            ManagerLocation = manLoc;
            BannerLocation1 = banloc1;
            BannerLocation2 = banloc2;
            BannerID1 = id1;
            BannerID2 = id2;
			ArenaZ = z;
            EffectAreas = effectAreas;
            StartLocations = startLocs;
            StartLocation1 = startLocs[0];
            StartLocation2 = startLocs[1];
            GateLocation = gateLoc;
            RegionBounds = bounds;
         
            EjectLocation = eject;
            DeadEjectLocation = deadEject;
			DeadZ = zDead;
        }

        public static ArenaDefinition LostLandsFelucca { get; set; }

        public static ArenaDefinition[] Definitions => _Definitions;
        private static readonly ArenaDefinition[] _Definitions = new ArenaDefinition[1];

        static ArenaDefinition()
        {

 
            LostLandsFelucca = new ArenaDefinition("Alverton", 0,
     //           new Point3D(1379, 687, -35),
                new Point3D(1378, 687, -35),
                new Point3D(1373, 671, 25),
                new Point3D(1373, 668, 25),
                17102,
                17100,
				5,// fait
                new Rectangle2D[]
                {
                    new Rectangle2D(1373, 666, 13, 1),
                    new Rectangle2D(1373, 673, 13, 1),
                    new Rectangle2D(1376, 659, 1, 22),
                    new Rectangle2D(1379, 659, 1, 22),
                    new Rectangle2D(1382, 659, 1, 22),
                },
                new Rectangle2D[]
                {
                    new Rectangle2D(1375, 662, 4, 3),
                    new Rectangle2D(1375, 676, 4, 3),
                    new Rectangle2D(6077, 3713, 5, 4),
                    new Rectangle2D(6084, 3713, 5, 4),
                    new Rectangle2D(6076, 3724, 5, 4),
                    new Rectangle2D(6084, 3724, 5, 4),
                    new Rectangle2D(6073, 3716, 1, 1),
                    new Rectangle2D(6073, 3724, 1, 1),
                    new Rectangle2D(6091, 3714, 2, 2),
                    new Rectangle2D(6091, 3724, 2, 2),
                },
                new Point3D(1378, 682, -35), // fait
                new Rectangle2D[]
                {
                    new Rectangle2D(1373, 659, 13, 23)
                },
                new Rectangle2D(1375, 680, 5, 4),// fait
                new Rectangle2D(1370, 655, 2, 2),  // fait?
				-15); // fait?
          
            _Definitions[0] = LostLandsFelucca;

        }
    }
}