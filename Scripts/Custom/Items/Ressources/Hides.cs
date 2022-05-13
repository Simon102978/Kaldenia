using System;

namespace Server.Items
{
    public abstract class BaseHides : Item/*, ICommodity*/
    {
        protected virtual CraftResource DefaultResource => CraftResource.RegularLeather;

        private CraftResource m_Resource;
        public BaseHides(CraftResource resource)
            : this(resource, 1)
        {
        }

        public BaseHides(CraftResource resource, int amount)
            : base(0x1079)
        {
            Stackable = true;
            Weight = 5.0;
            Amount = amount;
            Hue = CraftResources.GetHue(resource);

            m_Resource = resource;
        }

        public BaseHides(Serial serial)
            : base(serial)
        {
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public CraftResource Resource
        {
            get
            {
                return m_Resource;
            }
            set
            {
                m_Resource = value;
                InvalidateProperties();
            }
        }
        public override int LabelNumber
        {
            get
            {
              /*  if (m_Resource >= CraftResource.SpinedLeather && m_Resource <= CraftResource.BarbedLeather)
                    return 1049687 + (m_Resource - CraftResource.SpinedLeather);*/

                return 1047023;
            }
        }
      /*  TextDefinition ICommodity.Description => LabelNumber;
        bool ICommodity.IsDeedable => true;*/

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(1); // version

            writer.Write((int)m_Resource);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 2: // Reset from Resource System
                    m_Resource = DefaultResource;
                    reader.ReadString();
                    break;
                case 1:
                    {
                        m_Resource = (CraftResource)reader.ReadInt();
                        break;
                    }
                case 0:
                    {
                        OreInfo info = new OreInfo(reader.ReadInt(), reader.ReadInt(), reader.ReadString());

                        m_Resource = CraftResources.GetFromOreInfo(info);
                        break;
                    }
            }
        }

		public override void AddNameProperty(ObjectPropertyList list)
		{
			var name = CraftResources.GetName(m_Resource);

			if (Amount > 1)
				list.Add(String.Format("{3} {0}{1}{2}", "Peaux [", name, "]", Amount)); // ~1_NUMBER~ ~2_ITEMNAME~
			else
				list.Add(String.Format("{0}{1}{2}", "Peau [", name, "]")); // ingots
		}

		/*     public override void AddNameProperty(ObjectPropertyList list)
			 {
				 if (Amount > 1)
					 list.Add(1050039, "{0}\t#{1}", Amount, 1024216); // ~1_NUMBER~ ~2_ITEMNAME~
				 else
					 list.Add(1024216); // pile of hides
			 }

			 public override void GetProperties(ObjectPropertyList list)
			 {
				 base.GetProperties(list);

				 if (!CraftResources.IsStandard(m_Resource))
				 {
					 int num = CraftResources.GetLocalizationNumber(m_Resource);

					 if (num > 0)
						 list.Add(num);
					 else
						 list.Add(CraftResources.GetName(m_Resource));
				 }
			 }*/
	}

    [Flipable(0x1079, 0x1078)]
    public class Hides : BaseHides, IScissorable
    {
        [Constructable]
        public Hides()
            : this(1)
        {
        }

        [Constructable]
        public Hides(int amount)
            : base(CraftResource.RegularLeather, amount)
        {
        }

        public Hides(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public bool Scissor(Mobile from, Scissors scissors)
        {
            if (Deleted || !from.CanSee(this))
                return false;

            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(502437); // Items you wish to cut must be in your backpack
                return false;
            }
            base.ScissorHelper(from, new Leather(), 1);

            return true;
        }
    }

    [Flipable(0x1079, 0x1078)]
    public class LupusHides : BaseHides, IScissorable
    {
        protected override CraftResource DefaultResource => CraftResource.LupusLeather;

        [Constructable]
        public LupusHides()
            : this(1)
        {
        }

        [Constructable]
        public LupusHides(int amount)
            : base(CraftResource.LupusLeather, amount)
        {
        }

        public LupusHides(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public bool Scissor(Mobile from, Scissors scissors)
        {
            if (Deleted || !from.CanSee(this))
                return false;

            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(502437); // Items you wish to cut must be in your backpack
                return false;
            }

            base.ScissorHelper(from, new LupusLeather(), 1);

            return true;
        }
    }

    [Flipable(0x1079, 0x1078)]
    public class ReptilienHides : BaseHides, IScissorable
    {
        protected override CraftResource DefaultResource => CraftResource.ReptilienLeather;

        [Constructable]
        public ReptilienHides()
            : this(1)
        {
        }

        [Constructable]
        public ReptilienHides(int amount)
            : base(CraftResource.ReptilienLeather, amount)
        {
        }

        public ReptilienHides(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public bool Scissor(Mobile from, Scissors scissors)
        {
            if (Deleted || !from.CanSee(this))
                return false;

            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(502437); // Items you wish to cut must be in your backpack
                return false;
            }

            base.ScissorHelper(from, new ReptilienLeather(), 1);

            return true;
        }
    }

    [Flipable(0x1079, 0x1078)]
    public class GeantHides : BaseHides, IScissorable
    {
        protected override CraftResource DefaultResource => CraftResource.GeantLeather;

        [Constructable]
        public GeantHides()
            : this(1)
        {
        }

        [Constructable]
        public GeantHides(int amount)
            : base(CraftResource.GeantLeather, amount)
        {
        }

        public GeantHides(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }

        public bool Scissor(Mobile from, Scissors scissors)
        {
            if (Deleted || !from.CanSee(this))
                return false;

            if (!IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(502437); // Items you wish to cut must be in your backpack
                return false;
            }

            base.ScissorHelper(from, new GeantLeather(), 1);

            return true;
        }
    }

	[Flipable(0x1079, 0x1078)]
	public class OphidienHides : BaseHides, IScissorable
	{
		protected override CraftResource DefaultResource => CraftResource.OphidienLeather;

		[Constructable]
		public OphidienHides()
			: this(1)
		{
		}

		[Constructable]
		public OphidienHides(int amount)
			: base(CraftResource.OphidienLeather, amount)
		{
		}

		public OphidienHides(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}

		public bool Scissor(Mobile from, Scissors scissors)
		{
			if (Deleted || !from.CanSee(this))
				return false;

			if (!IsChildOf(from.Backpack))
			{
				from.SendLocalizedMessage(502437); // Items you wish to cut must be in your backpack
				return false;
			}

			base.ScissorHelper(from, new OphidienLeather(), 1);

			return true;
		}
	}
	[Flipable(0x1079, 0x1078)]
	public class ArachnideHides : BaseHides, IScissorable
	{
		protected override CraftResource DefaultResource => CraftResource.ArachnideLeather;

		[Constructable]
		public ArachnideHides()
			: this(1)
		{
		}

		[Constructable]
		public ArachnideHides(int amount)
			: base(CraftResource.ArachnideLeather, amount)
		{
		}

		public ArachnideHides(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}

		public bool Scissor(Mobile from, Scissors scissors)
		{
			if (Deleted || !from.CanSee(this))
				return false;

			if (!IsChildOf(from.Backpack))
			{
				from.SendLocalizedMessage(502437); // Items you wish to cut must be in your backpack
				return false;
			}

			base.ScissorHelper(from, new ArachnideLeather(), 1);

			return true;
		}
	}

	[Flipable(0x1079, 0x1078)]
	public class DragoniqueHides : BaseHides, IScissorable
	{
		protected override CraftResource DefaultResource => CraftResource.DragoniqueLeather;

		[Constructable]
		public DragoniqueHides()
			: this(1)
		{
		}

		[Constructable]
		public DragoniqueHides(int amount)
			: base(CraftResource.DragoniqueLeather, amount)
		{
		}

		public DragoniqueHides(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}

		public bool Scissor(Mobile from, Scissors scissors)
		{
			if (Deleted || !from.CanSee(this))
				return false;

			if (!IsChildOf(from.Backpack))
			{
				from.SendLocalizedMessage(502437); // Items you wish to cut must be in your backpack
				return false;
			}

			base.ScissorHelper(from, new DragoniqueLeather(), 1);

			return true;
		}
	}

	[Flipable(0x1079, 0x1078)]
	public class DemoniaqueHides : BaseHides, IScissorable
	{
		protected override CraftResource DefaultResource => CraftResource.DemoniaqueLeather;

		[Constructable]
		public DemoniaqueHides()
			: this(1)
		{
		}

		[Constructable]
		public DemoniaqueHides(int amount)
			: base(CraftResource.DemoniaqueLeather, amount)
		{
		}

		public DemoniaqueHides(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}

		public bool Scissor(Mobile from, Scissors scissors)
		{
			if (Deleted || !from.CanSee(this))
				return false;

			if (!IsChildOf(from.Backpack))
			{
				from.SendLocalizedMessage(502437); // Items you wish to cut must be in your backpack
				return false;
			}

			base.ScissorHelper(from, new DemoniaqueLeather(), 1);

			return true;
		}
	}

	[Flipable(0x1079, 0x1078)]
	public class AncienHides : BaseHides, IScissorable
	{
		protected override CraftResource DefaultResource => CraftResource.AncienLeather;

		[Constructable]
		public AncienHides()
			: this(1)
		{
		}

		[Constructable]
		public AncienHides(int amount)
			: base(CraftResource.AncienLeather, amount)
		{
		}

		public AncienHides(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}

		public bool Scissor(Mobile from, Scissors scissors)
		{
			if (Deleted || !from.CanSee(this))
				return false;

			if (!IsChildOf(from.Backpack))
			{
				from.SendLocalizedMessage(502437); // Items you wish to cut must be in your backpack
				return false;
			}

			base.ScissorHelper(from, new AncienLeather(), 1);

			return true;
		}
	}

}
