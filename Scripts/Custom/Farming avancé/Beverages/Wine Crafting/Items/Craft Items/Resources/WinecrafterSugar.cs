using System;
using System.Collections;
using Server;
using Server.Network;

namespace Server.Items
{
	public class WinecrafterSugar : Item
	{
		[Constructable]
		public WinecrafterSugar() : this(1) 
        { 
        }

		[Constructable]
		public WinecrafterSugar(int amount) : base(4165)
		{
			this.Stackable = true;
			this.Hue = 1150;
			this.Name = "a bag of fine sugar";
			this.Amount = amount;
			this.Weight = 1;
		}

		public WinecrafterSugar(Serial serial) : base(serial)
        {
        }
		public override void Serialize(GenericWriter writer) 
        { 
            base.Serialize(writer); writer.Write((int) 0); 
        }

		public override void Deserialize(GenericReader reader) 
        { 
            base.Deserialize(reader); int version = reader.ReadInt(); 
        }
	}
}
