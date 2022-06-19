using System.Collections.Generic;
using Server.ContextMenus;
using Server.Custom.Gumps;
using Server.Targeting;
using Server.Custom.Packaging.Packages;
using Server.Items;

namespace Server.Mobiles
{
    public class PackageExchanger : BaseVendor
    {
	
		
		private readonly List<SBInfo> m_SBInfos = new List<SBInfo>();

        [Constructable]
        public PackageExchanger() : base("Importateur de marchandises")
		{

			SetSkill(SkillName.Cartography, 75.0, 100.0);
			SetSkill(SkillName.Hiding, 75.0, 100.0);

			Hue = Utility.RandomSkinHue();
			Body = 0x190;
			Name = NameList.RandomName("male");

			HairItemID = Race.RandomHair(Female);
			if (Utility.RandomBool())
				FacialHairItemID = Race.RandomFacialHair(Female);
			int hhue = Race.RandomHairHue();
			HairHue = hhue;
			FacialHairHue = hhue;

			SetStr(86, 100);
			SetDex(81, 95);
			SetInt(61, 75);
			SetDamage(10, 23);
		}

		public override void InitOutfit()
		{
			AddItem(new Camisole(Utility.RandomNeutralHue()));
			AddItem(new Shoes());
			AddItem(new SkullCap(Utility.RandomBirdHue()));
			AddItem(new Pantalon6(Utility.RandomBirdHue()));
			AddItem(new ShoulderParrot());
		}
		public PackageExchanger(Serial serial)
            : base(serial)
        {
        }

        protected override List<SBInfo> SBInfos => m_SBInfos;
        public override void InitSBInfo()
        {

        }

		public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
		{
			

			if (CanPaperdollBeOpenedBy(from))
			{
				list.Add(new PaperdollEntry(this));
			}

			var pm = from as PlayerMobile;

			if (pm != null)
				list.Add(new VendorSellEntry(pm, this));
		}


		public override bool OnDragDrop(Mobile from, Item dropped)
		{
			if (dropped is CustomPackaging)
			{
				CustomPackaging cp = (CustomPackaging)dropped;

				cp.Finaliser(from);

				return true;
			}
			
			return base.OnDragDrop(from, dropped);
		}

		public class VendorSellEntry : ContextMenuEntry
		{
			private readonly BaseVendor m_Vendor;
			private Mobile m_From;

			public VendorSellEntry(Mobile from, BaseVendor vendor)
				: base(6104, 8)
			{
				m_From = from;
				m_Vendor = vendor;
			}

			public override void OnClick()
			{
				m_From.Target = new InternalTarget(m_From, m_Vendor);
				m_From.SendMessage("Veuillez selectionner le paquet.");
			}
			private class InternalTarget : Target
			{
				public Mobile From { get; set; }
				public BaseVendor Vendor { get; set; }

				public InternalTarget(Mobile from, BaseVendor vendor)
					: base(1, false, TargetFlags.None)
				{
					From = from;
					Vendor = vendor;
				}

				protected override void OnTarget(Mobile from, object targeted)
				{
					if (targeted is CustomPackaging)
					{
						CustomPackaging cp = (CustomPackaging)targeted;

						cp.Finaliser(from);
					}
					else
					{
						from.SendMessage("Ceci n'est pas un paquet recevable.");
						from.Target = new InternalTarget(from, Vendor);
					}
				}
			}




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
