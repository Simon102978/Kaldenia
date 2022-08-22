#region About This Script - Do Not Remove This Header

#endregion About This Script - Do Not Remove This Header

using System;
using System.Threading;
using System.Collections;
using Server;
using Server.Network;
using Server.Items;
using Server.Gumps;
using Server.Mobiles;

namespace Server.Items.Crops
{
    public class Marijuana_Seedling : DrugSystem_Engine
    {
        private static Mobile m_sower;
        public Timer thisTimer;

        [CommandProperty(AccessLevel.GameMaster)]
        public Mobile Sower { get { return m_sower; } set { m_sower = value; } }

        [Constructable]
        public Marijuana_Seedling(Mobile sower): base( 0x0DEC ) //Tomato
        {
            Name = "Marijuana Seedling";
            Movable = false;
            m_sower = sower;
            init(this);
        }
        public static void init(Marijuana_Seedling plant)
        {
            plant.thisTimer = new DrugSystem_Helper.DrugSystem_GrowTimer(plant, typeof(Marijuana_Crop), plant.Sower);
            plant.thisTimer.Start();
        }
        public override void OnDoubleClick(Mobile from)
        {
            if (from.Mounted && !DrugSystem_Helper.CanWorkMounted) 
            { 
                from.SendMessage("This Crop Is Too Small To Harvest While Mounted."); 
                    return; 
            }
            else 
                from.SendMessage("This Crop Is Too Young To Harvest.");

        }
        public Marijuana_Seedling(Serial serial): base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);

            writer.Write(m_sower);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
            m_sower = reader.ReadMobile();
            init(this);
        }
    }
}
