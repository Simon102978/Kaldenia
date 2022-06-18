using System;
using Server.Items;

namespace Server.Custom.Packaging.Packages
{
	public abstract class CustomPackaging : Item
	{

		private int m_Reward;


		[CommandProperty(AccessLevel.Seer)]
		public int Reward { get => m_Reward; set => m_Reward = value; }

		public virtual double Conversion => 1.0;


		public CustomPackaging(int itemID) : base(itemID)
		{

		}

		public CustomPackaging(Serial serial)
			: base(serial)
		{
		}


		public virtual void Finaliser(Mobile from)
		{
			PieceArgent pa = new PieceArgent( (int)Math.Round(Reward * Conversion));

			from.AddToBackpack(pa);

			this.Delete();

		}

		



		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(1); // version
			writer.Write(Reward);

		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

			switch (version)
			{
				case 1:
					{
						Reward = reader.ReadInt();
						break;
					}
				default:
					break;
			}
		}
	}
}
