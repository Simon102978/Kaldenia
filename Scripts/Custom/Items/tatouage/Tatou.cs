using System;
using Server.Mobiles;

namespace Server.Items
{
    public abstract class Tatou : Item
    {
        public static Tatou CreateByID(int id, int hue)
        {
            switch (id)
            {
                case 0xA3FC: return new TatouBras(hue);
                case 0xA3FD: return new TatouCuisse(hue);
                case 0xA3FE: return new TatouVisage(hue);
                case 0xA3FF: return new TatouFront(hue);
                case 0xA400: return new TatouCorps(hue);
                case 0xA401: return new TatouMasque(hue);
                default: return new GenericTatou(id, hue);
            }
        }

        public override bool CanEquip(Mobile m)
        {
            if (m is CustomPlayerMobile)
            {
                CustomPlayerMobile pm = (CustomPlayerMobile)m;
            }

            return base.CanEquip(m);
        }

        public Tatou(int itemID)
            : this(itemID, 0)
        {
        }

        public Tatou(int itemID, int hue)
            : base(itemID)
        {
            LootType = LootType.Blessed;
            Layer = Layer.Talisman;
            Hue = hue;
        }

        public Tatou(Serial serial)
            : base(serial)
        {
        }

        public override bool DisplayLootType { get { return false; } }

        public override bool VerifyMove(Mobile from)
        {
            return (from.AccessLevel >= AccessLevel.GameMaster);
        }

        public override DeathMoveResult OnParentDeath(Mobile parent)
        {
            //Dupe(Amount);

            return DeathMoveResult.MoveToCorpse;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            LootType = LootType.Blessed;

            int version = reader.ReadInt();
        }
    }

	public class GenericTatou : Tatou
	{
		[Constructable]
		public GenericTatou(int itemID)
			: this(itemID, 0)
		{
		}

		[Constructable]
		public GenericTatou(int itemID, int hue)
			: base(itemID, hue)
		{
		}

		public GenericTatou(Serial serial)
			: base(serial)
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
	public class TatouBras : Tatou
	{
		[Constructable]
		public TatouBras()
			: this(0)
		{
		}

		[Constructable]
		public TatouBras(int hue)
			: base(0xA3FC, hue)
		{
			Name = "TatouBras";
		}

		public TatouBras(Serial serial)
			: base(serial)
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

	public class TatouCuisse : Tatou
	{
		[Constructable]
		public TatouCuisse()
			: this(0)
		{
		}

		[Constructable]
		public TatouCuisse(int hue)
			: base(0xA3FD, hue)
		{
			Name = "TatouCuisse";
		}

		public TatouCuisse(Serial serial)
			: base(serial)
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

	public class TatouVisage: Tatou
	{
		[Constructable]
		public TatouVisage()
			: this(0)
		{
		}

		[Constructable]
		public TatouVisage(int hue)
			: base(0xA3FE, hue)
		{
			Name = "TatouVisage";
		}

		public TatouVisage(Serial serial)
			: base(serial)
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

	public class TatouFront : Tatou
	{
		[Constructable]
		public TatouFront()
			: this(0)
		{
		}

		[Constructable]
		public TatouFront(int hue)
			: base(0xA3FF, hue)
		{
			Name = "TatouFront";
		}

		public TatouFront(Serial serial)
			: base(serial)
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

	public class TatouCorps : Tatou
	{
		[Constructable]
		public TatouCorps()
			: this(0)
		{
		}

		[Constructable]
		public TatouCorps(int hue)
			: base(0xA400, hue)
		{
			Name = "TatouCorps";
		}

		public TatouCorps(Serial serial)
			: base(serial)
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
	public class TatouMasque : Tatou
	{
		[Constructable]
		public TatouMasque()
			: this(0)
		{
		}

		[Constructable]
		public TatouMasque(int hue)
			: base(0xA401, hue)
		{
			Name = "TatouMasque";
		}

		public TatouMasque(Serial serial)
			: base(serial)
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