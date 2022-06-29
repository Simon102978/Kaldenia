using System;
using System.Collections;
using Server.Network;
using Server.Mobiles;
using Server.Items;
using Server.Gumps;

namespace Server.Items.Crops
{
    public class CottonSeedling : BaseCrop
    {
        private static Mobile m_sower;
        public Timer thisTimer;

        [CommandProperty(AccessLevel.GameMaster)]
        public Mobile Sower { get { return m_sower; } set { m_sower = value; } }

        [Constructable]
        public CottonSeedling(Mobile sower)
            : base(Utility.RandomList(0xC51, 0xC52))
        {
            Movable = false;
            Name = "Cotton Seedling";
            m_sower = sower;
            init(this);
        }
        public static void init(CottonSeedling plant)
        {
            plant.thisTimer = new CropHelper.GrowTimer(plant, typeof(CottonCrop), plant.Sower);
            plant.thisTimer.Start();
        }
        public override void OnDoubleClick(Mobile from)
        {
            if (from.Mounted && !CropHelper.CanWorkMounted)
            {
                from.SendMessage("Le plant est trop petit pour pouvoir �tre r??#$?&*colt??#$?&* sur votre monture.");
                return;
            }
            else
            {
                from.SendMessage("Votre pousse est trop jeune pour �tre r??#$?&*colt??#$?&*e.");
            }
        }
        public CottonSeedling(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer); writer.Write((int)0);
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