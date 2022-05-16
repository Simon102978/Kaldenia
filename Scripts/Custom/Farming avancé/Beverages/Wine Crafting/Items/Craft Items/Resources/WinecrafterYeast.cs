using System;

namespace Server.Items
{
	public class WinecrafterYeast : Item
	{
		[Constructable]
		public WinecrafterYeast() : this(1) 
        { 
        }

		[Constructable]
		public WinecrafterYeast(int amount) : base(4165)
		{
            this.Stackable = true;
            this.Weight = 0.1;
            this.Amount = amount;
            this.Name = "Yeast";
		}

		public WinecrafterYeast(Serial serial) : base(serial)
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
