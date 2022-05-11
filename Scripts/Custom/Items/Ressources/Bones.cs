using System;


namespace Server.Items
{
    public abstract class BaseBone : Item
    {
        protected virtual CraftResource DefaultResource => CraftResource.RegularBone;

        private CraftResource m_Resource;
        public BaseBone(CraftResource resource)
            : this(resource, 1)
        {
        }

        public BaseBone(CraftResource resource, int amount)
            : base(0xf7e)
        {
            Stackable = true;
            Weight = 1.0;
            Amount = amount;
            Hue = CraftResources.GetHue(resource);


            m_Resource = resource;
        }

        public BaseBone(Serial serial)
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
       /*         if (m_Resource >= CraftResource.SpinedBone && m_Resource <= CraftResource.BarbedBone)
                    return 1049684 + (m_Resource - CraftResource.SpinedBone);*/
 
                return 1049064;
            }
        }
		//       TextDefinition ICommodity.Description => LabelNumber;


		public override void AddNameProperty(ObjectPropertyList list)
		{
			var name = CraftResources.GetName(m_Resource);

			if (Amount > 1)
				list.Add(1060532, String.Format("{3} {0}{1}{2}", "Os [", name, "]", Amount)); // ~1_NUMBER~ ~2_ITEMNAME~
			else
				list.Add(String.Format("{0}{1}{2}", "Os [", name, "]")); // ingots
		}



	//	bool ICommodity.IsDeedable => true;
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

   /*     public override void AddNameProperty(ObjectPropertyList list)
        {
            if (Amount > 1)
                list.Add(1050039, "{0}\t#{1}", Amount, 1024199); // ~1_NUMBER~ ~2_ITEMNAME~
            else
                list.Add(1024199); // cut Bone
        }*/

  /*      public override void GetProperties(ObjectPropertyList list)
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

    [Flipable(0x1081, 0x1082)]
    public class Bone : BaseBone
    {
        [Constructable]
        public Bone()
            : this(1)
        {
        }

        [Constructable]
        public Bone(int amount)
            : base(CraftResource.RegularBone, amount)
        {
        }

        public Bone(Serial serial)
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
    }

    [Flipable(0x1081, 0x1082)]
    public class LupusBone : BaseBone
    {
        protected override CraftResource DefaultResource => CraftResource.LupusBone;

        [Constructable]
        public LupusBone()
            : this(1)
        {
        }

        [Constructable]
        public LupusBone(int amount)
            : base(CraftResource.LupusBone, amount)
        {
        }

        public LupusBone(Serial serial)
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
    }

    [Flipable(0x1081, 0x1082)]
    public class ReptilienBone : BaseBone
    {
        protected override CraftResource DefaultResource => CraftResource.ReptilienBone;

        [Constructable]
        public ReptilienBone()
            : this(1)
        {
        }

        [Constructable]
        public ReptilienBone(int amount)
            : base(CraftResource.ReptilienBone, amount)
        {
        }

        public ReptilienBone(Serial serial)
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
    }

    [Flipable(0x1081, 0x1082)]
    public class GeantBone : BaseBone
    {
        protected override CraftResource DefaultResource => CraftResource.GeantBone;

        [Constructable]
        public GeantBone()
            : this(1)
        {
        }

        [Constructable]
        public GeantBone(int amount)
            : base(CraftResource.GeantBone, amount)
        {
        }

        public GeantBone(Serial serial)
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
    }

	[Flipable(0x1081, 0x1082)]
	public class OphidienBone : BaseBone
	{
		protected override CraftResource DefaultResource => CraftResource.OphidienBone;

		[Constructable]
		public OphidienBone()
			: this(1)
		{
		}

		[Constructable]
		public OphidienBone(int amount)
			: base(CraftResource.OphidienBone, amount)
		{
		}

		public OphidienBone(Serial serial)
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
	}

	[Flipable(0x1081, 0x1082)]
	public class ArachnideBone : BaseBone
	{
		protected override CraftResource DefaultResource => CraftResource.ArachnideBone;

		[Constructable]
		public ArachnideBone()
			: this(1)
		{
		}

		[Constructable]
		public ArachnideBone(int amount)
			: base(CraftResource.ArachnideBone, amount)
		{
		}

		public ArachnideBone(Serial serial)
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
	}

	[Flipable(0x1081, 0x1082)]
	public class DragoniqueBone : BaseBone
	{
		protected override CraftResource DefaultResource => CraftResource.DragoniqueBone;

		[Constructable]
		public DragoniqueBone()
			: this(1)
		{
		}

		[Constructable]
		public DragoniqueBone(int amount)
			: base(CraftResource.DragoniqueBone, amount)
		{
		}

		public DragoniqueBone(Serial serial)
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
	}

	[Flipable(0x1081, 0x1082)]
	public class DemoniaqueBone : BaseBone
	{
		protected override CraftResource DefaultResource => CraftResource.DemoniaqueBone;

		[Constructable]
		public DemoniaqueBone()
			: this(1)
		{
		}

		[Constructable]
		public DemoniaqueBone(int amount)
			: base(CraftResource.DemoniaqueBone, amount)
		{
		}

		public DemoniaqueBone(Serial serial)
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
	}

	[Flipable(0x1081, 0x1082)]
	public class AncienBone : BaseBone
	{
		protected override CraftResource DefaultResource => CraftResource.AncienBone;

		[Constructable]
		public AncienBone()
			: this(1)
		{
		}

		[Constructable]
		public AncienBone(int amount)
			: base(CraftResource.AncienBone, amount)
		{
		}

		public AncienBone(Serial serial)
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
	}



}