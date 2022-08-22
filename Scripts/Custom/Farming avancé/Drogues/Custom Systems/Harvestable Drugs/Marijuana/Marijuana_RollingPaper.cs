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
    //[FlipableAttribute(0x1AA2, 0xF00)]
    public class Marijuana_RollingPaper : DrugSystem_Effect
    {
        [Constructable]
        public Marijuana_RollingPaper(): base(0x0FEF)
        {
            Name = "Rolling Papers";
            this.Weight = 0.2;
            this.Hue = 1174;
        }

        public Marijuana_RollingPaper(Serial serial): base(serial)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
            Container pack = from.Backpack;

            if (pack != null && pack.ConsumeTotal(typeof(Marijuana_Nugz), 3) )

            {
                from.SendMessage("You Roll Up The Ganja Into A Fatty.");
                from.AddToBackpack(new Marijuana_Joint());
            }
            else
            {
                from.SendMessage("You Need More Ganja Bro!");
                return;
            }
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
 