﻿using Server.Engines.Craft;
using System;

namespace Server.Items
{
    public class BaseUtensil : Item, IResource, IQuality
    {
        private CraftResource _Resource;
        private Mobile _Crafter;
        private ItemQuality _Quality;

        [CommandProperty(AccessLevel.GameMaster)]
        public CraftResource Resource { get { return _Resource; } set { _Resource = value; Hue = CraftResources.GetHue(_Resource); InvalidateProperties(); } }

        [CommandProperty(AccessLevel.GameMaster)]
        public Mobile Crafter { get { return _Crafter; } set { _Crafter = value; InvalidateProperties(); } }

        [CommandProperty(AccessLevel.GameMaster)]
        public ItemQuality Quality { get { return _Quality; } set { _Quality = value; InvalidateProperties(); } }

        public bool PlayerConstructed => true;

        #region Old Item Serialization Vars
        /* DO NOT USE! Only used in serialization of special scrolls that originally derived from Item */
        private bool m_InheritsItem;

        protected bool InheritsItem => m_InheritsItem;
        #endregion

        public BaseUtensil(int itemID)
            : base(itemID)
        {
        }

        public override void AddCraftedProperties(ObjectPropertyList list)
        {
            if (_Crafter != null)
            {
                list.Add(1050043, _Crafter.TitleName); // crafted by ~1_NAME~
            }

            if (_Quality == ItemQuality.Exceptional)
            {
                list.Add(1060636); // Exceptional
            }
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            if (_Resource > CraftResource.Iron)
            {
                list.Add(1053099, "#{0}\t{1}", CraftResources.GetLocalizationNumber(_Resource), string.Format("#{0}", LabelNumber.ToString())); // ~1_oretype~ ~2_armortype~
            }
            else
            {
                base.AddNameProperty(list);
            }
        }

        public virtual int OnCraft(int quality, bool makersMark, Mobile from, CraftSystem craftSystem, Type typeRes, ITool tool, CraftItem craftItem, int resHue)
        {
            Quality = (ItemQuality)quality;

            if (makersMark)
                Crafter = from;

            if (!craftItem.ForceNonExceptional)
            {
                if (typeRes == null)
                    typeRes = craftItem.Resources.GetAt(0).ItemType;

                Resource = CraftResources.GetFromType(typeRes);
            }

            return quality;
        }

        public BaseUtensil(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(1); // version

            writer.Write((int)_Resource);
            writer.Write(_Crafter);
            writer.Write((int)_Quality);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 1:
                    _Resource = (CraftResource)reader.ReadInt();
                    _Crafter = reader.ReadMobile();
                    _Quality = (ItemQuality)reader.ReadInt();

                    break;
                case 0:
                    m_InheritsItem = true;
                    break;
            }
        }
    }

    [Flipable(0x9F4, 0x9F5, 0x9A3, 0x9A4)]
    public class Fork : BaseUtensil
    {
        [Constructable]
        public Fork()
            : base(0x9F4)
        {
            Weight = 1.0;
        }

        public Fork(Serial serial)
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

            int version = (InheritsItem ? 0 : reader.ReadInt()); // Required for BaseUtensil insertion
        }
    }

    public class ForkLeft : BaseUtensil
    {
        [Constructable]
        public ForkLeft()
            : base(0x9F4)
        {
            Weight = 1.0;
        }

        public ForkLeft(Serial serial)
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

            int version = (InheritsItem ? 0 : reader.ReadInt()); // Required for BaseUtensil insertion
        }
    }

    public class ForkRight : BaseUtensil
    {
        [Constructable]
        public ForkRight()
            : base(0x9F5)
        {
            Weight = 1.0;
        }

        public ForkRight(Serial serial)
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

            int version = (InheritsItem ? 0 : reader.ReadInt()); // Required for BaseUtensil insertion
        }
    }

    [Flipable(0x9F8, 0x9F9, 0x9C2, 0x9C3)]
    public class Spoon : BaseUtensil
    {
        [Constructable]
        public Spoon()
            : base(0x9F8)
        {
            Weight = 1.0;
        }

        public Spoon(Serial serial)
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

            int version = (InheritsItem ? 0 : reader.ReadInt()); // Required for BaseUtensil insertion
        }
    }

    public class SpoonLeft : BaseUtensil
    {
        [Constructable]
        public SpoonLeft()
            : base(0x9F8)
        {
            Weight = 1.0;
        }

        public SpoonLeft(Serial serial)
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

            int version = (InheritsItem ? 0 : reader.ReadInt()); // Required for BaseUtensil insertion
        }
    }

    public class SpoonRight : BaseUtensil
    {
        [Constructable]
        public SpoonRight()
            : base(0x9F9)
        {
            Weight = 1.0;
        }

        public SpoonRight(Serial serial)
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

            int version = (InheritsItem ? 0 : reader.ReadInt()); // Required for BaseUtensil insertion
        }
    }

    [Flipable(0x9F6, 0x9F7, 0x9A5, 0x9A6)]
    public class Knife : BaseUtensil
    {
        [Constructable]
        public Knife()
            : base(0x9F6)
        {
            Weight = 1.0;
        }

        public Knife(Serial serial)
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

            int version = (InheritsItem ? 0 : reader.ReadInt()); // Required for BaseUtensil insertion
        }
    }

    public class KnifeLeft : BaseUtensil
    {
        [Constructable]
        public KnifeLeft()
            : base(0x9F6)
        {
            Weight = 1.0;
        }

        public KnifeLeft(Serial serial)
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

            int version = (InheritsItem ? 0 : reader.ReadInt()); // Required for BaseUtensil insertion
        }
    }

    public class KnifeRight : BaseUtensil
    {
        [Constructable]
        public KnifeRight()
            : base(0x9F7)
        {
            Weight = 1.0;
        }

        public KnifeRight(Serial serial)
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

            int version = (InheritsItem ? 0 : reader.ReadInt()); // Required for BaseUtensil insertion
        }
    }

    public class Plate : BaseUtensil
    {
        [Constructable]
        public Plate()
            : base(0x9D7)
        {
            Weight = 1.0;
        }

        public Plate(Serial serial)
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

            int version = (InheritsItem ? 0 : reader.ReadInt()); // Required for BaseUtensil insertion
        }
    }

	public class AssietteMosaique : BaseUtensil
	{
		[Constructable]
		public AssietteMosaique()
			: base(0x99AA)
		{
			Weight = 1.0;
		}

		public AssietteMosaique(Serial serial)
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

			int version = (InheritsItem ? 0 : reader.ReadInt()); // Required for BaseUtensil insertion
		}
	}

	public class Bock : BaseUtensil

	{


		[Constructable]
		public Bock()
				: base(0xA3E4)

		{
			Weight = 2.0;
			Name = "Bock de Bière";
			Layer = Layer.OneHanded;
		}

		public Bock(Serial serial)
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
	public class CoupeMain : BaseUtensil

	{


		[Constructable]
		public CoupeMain()
				: base(0xA3FA)

		{
			Weight = 2.0;
			Name = "Coupe";
			Layer = Layer.OneHanded;
		}

		public CoupeMain(Serial serial)
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

	public class PoissonMain : BaseUtensil

	{


		[Constructable]
		public PoissonMain()
				: base(0xA3F9)

		{
			Weight = 2.0;
			Name = "Un Poisson";
			Layer = Layer.OneHanded;
		}

		public PoissonMain(Serial serial)
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
	public class CorneBoire : BaseUtensil

	{


		[Constructable]
		public CorneBoire()
				: base(0xA3F0)

		{
			Weight = 2.0;
			Name = "Corne à Boire";
			Layer = Layer.OneHanded;
		}

		public CorneBoire(Serial serial)
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

	public class Eventail : Item

	{


		[Constructable]
		public Eventail()
				: base(0xA3F1)

		{
			Weight = 2.0;
			Name = "Eventail";
			Layer = Layer.OneHanded;
		}

		public Eventail(Serial serial)
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

	public class Parchemin : BaseUtensil

	{


		[Constructable]
		public Parchemin()
				: base(0xA3F6)

		{
			Weight = 2.0;
			Name = "Un Parchemin";
			Layer = Layer.OneHanded;
		}

		public Parchemin(Serial serial)
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
