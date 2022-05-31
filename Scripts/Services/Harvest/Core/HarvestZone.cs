using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server
{
    public enum ZoneType
    {
        Mining,
        Fishing,
        Lumberjacking
    }
}

namespace Server.Engines.Harvest
{
    public class HarvestZone
    {
        private ZoneType m_ZoneType;
        private ArrayList m_Area;
        private HarvestVein[] m_Veins;
        private Map m_Map = Map.Felucca;
        private static ArrayList m_HarvestZones = new ArrayList();
        private Type m_RequiredTool;

        public ZoneType ZoneType
        {
            get { return m_ZoneType; }
            set { m_ZoneType = value; }
        }

        public ArrayList Area
        {
            get { return m_Area; }
            set { m_Area = value; }
        }

        public HarvestVein[] Veins
        {
            get { return m_Veins; }
            set { m_Veins = value; }
        }


        public Map Map
        {
            get { return m_Map; }
            set { m_Map = value; }
        }


        public Type RequiredTool
        {
            get { return m_RequiredTool; }
            set { m_RequiredTool = value; }
        }

        public static ArrayList HarvestZones
        {
            get { return m_HarvestZones; }
            set { m_HarvestZones = value; }
        }

        public static HarvestResource[] Resources
        {
            get { return m_Resources; }
            set { m_Resources = value; }
        }

        public HarvestZone(ZoneType zoneType)
        {
            m_ZoneType = zoneType;
            m_Area = new ArrayList();
        }



        public HarvestZone(ZoneType zoneType, Type tool)
        {
            m_ZoneType = zoneType;
            m_Area = new ArrayList();
            m_RequiredTool = tool;
        }


        public HarvestVein RandomVein()
        {
            if (Veins.Length == 1)
                return Veins[0];

            double randomValue = Utility.RandomDouble();

            randomValue *= 100;

            for (int i = 0; i < Veins.Length; ++i)
            {
                if (randomValue <= Veins[i].VeinChance)
                    return Veins[i];

                randomValue -= Veins[i].VeinChance;
            }

            return Veins[0];


        }


        public bool CheckValide(SkillName skill)
        {
            switch (skill)
            {
                case SkillName.Mining:

                    if (ZoneType == ZoneType.Mining)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case SkillName.Lumberjacking:
                    if (ZoneType == ZoneType.Lumberjacking)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case SkillName.Fishing:

                    if (ZoneType == ZoneType.Fishing)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default:
                    return true;
            }
        }


        private static HarvestResource[] m_Resources = new HarvestResource[]
			{
					new HarvestResource(00.0, 00.0, 100.0, 1007072, typeof(IronOre), typeof(Granite)),  // 0
					new HarvestResource(65.0, 25.0, 105.0, 1007073, typeof(DullCopperOre),  typeof(DullCopperGranite), typeof(DullCopperElemental)),  // 1
					new HarvestResource(70.0, 30.0, 110.0, 1007074, typeof(ShadowIronOre),  typeof(ShadowIronGranite), typeof(ShadowIronElemental)),  // 2
					new HarvestResource(75.0, 35.0, 115.0, 1007075, typeof(CopperOre), typeof(CopperGranite), typeof(CopperElemental)),  // 3
					new HarvestResource(80.0, 40.0, 120.0, 1007076, typeof(BronzeOre), typeof(BronzeGranite), typeof(BronzeElemental)),  // 4
					new HarvestResource(85.0, 45.0, 125.0, 1007077, typeof(GoldOre), typeof(GoldGranite), typeof(GoldenElemental)),  // 5
					new HarvestResource(90.0, 50.0, 130.0, 1007078, typeof(AgapiteOre), typeof(AgapiteGranite), typeof(AgapiteElemental)),  // 6
					new HarvestResource(95.0, 55.0, 135.0, 1007079, typeof(VeriteOre), typeof(VeriteGranite), typeof(VeriteElemental)),  // 7
					new HarvestResource(99.0, 59.0, 139.0, 1007080, typeof(ValoriteOre), typeof(ValoriteGranite), typeof(ValoriteElemental)),  // 8


					new HarvestResource(00.0, 00.0, 100.0, 1072540, typeof(Log)),  // 9
					new HarvestResource(65.0, 25.0, 105.0, 1072541, typeof(OakLog)), // 10
					new HarvestResource(80.0, 40.0, 120.0, 1072542, typeof(AshLog)),  // 11
					new HarvestResource(95.0, 55.0, 135.0, 1072543, typeof(YewLog)),  // 12
					new HarvestResource(100.0, 60.0, 140.0, 1072544, typeof(HeartwoodLog)),  // 13
					new HarvestResource(100.0, 60.0, 140.0, 1072545, typeof(BloodwoodLog)),  // 14
					new HarvestResource(100.0, 60.0, 140.0, 1072546, typeof(FrostwoodLog)),  // 15

 

        };

        public static void AddZone(HarvestZone zone)
        {
            if (!m_HarvestZones.Contains(zone))
                m_HarvestZones.Add(zone);
        }

        public static void RemoveZone(HarvestZone zone)
        {
            if (m_HarvestZones.Contains(zone))
                m_HarvestZones.Remove(zone);
        }





    }
}
