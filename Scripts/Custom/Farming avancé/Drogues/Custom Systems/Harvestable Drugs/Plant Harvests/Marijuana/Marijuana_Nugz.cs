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
    public class Marijuana_Nugz : DrugSystem_Engine
    {
        [Constructable]
        public Marijuana_Nugz() : this(null) { }

        [Constructable]
        public Marijuana_Nugz(Mobile sower): base(0xF88)
        {
            Name = "Bubba Kush";
            Weight = 0.3;
            Hue = 167;
            Movable = true;
            Stackable = true;
        }

        public override void OnDoubleClick(Mobile from)
        {

            int emote = Utility.Random(0);
            switch (emote)
            {
                case 0:
                    {
                        from.Emote("*Sniffs The Freshly Gathered Nugz*");
                        from.SendMessage("You Sense These Nugz Are Of Excellant Quality");
                        break;
                    }
            }
        }
        public Marijuana_Nugz(Serial serial): base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version 
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}