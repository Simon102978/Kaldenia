#region References
using Server.Gumps;
using Server.Items;
using Server.Network;
using System;
using System.Collections.Generic;
using System;
using System.IO;
using System.Collections;
using Server.Items;
using Server.Network;
using Server.Gumps;
using Server.Mobiles;
using Server.Targeting;
using Server.Targets;

#endregion

namespace Server.Mobiles
{
    public class CustomVendor : BaseVendor
    {
        public static readonly object From = new object();
        public static readonly object Vendor = new object();
        public static readonly object Price = new object();

        private readonly List<SBInfo> m_SBInfos = new List<SBInfo>();

        [Constructable]
        public CustomVendor()
            : base("Marchand Imports/Exports")
        { }

        public CustomVendor(Serial serial)
            : base(serial)
        { }

        public override bool ClickTitle => false;
        public override bool IsActiveBuyer => false;
        public override bool IsActiveSeller => true;
        public override VendorShoeType ShoeType => Utility.RandomBool() ? VendorShoeType.Shoes : VendorShoeType.Sandals;
        protected override List<SBInfo> SBInfos => m_SBInfos;

        public override bool OnBuyItems(Mobile buyer, List<BuyItemResponse> list)
        {
            return false;
        }

        public override void VendorBuy(Mobile from)
        {
				from.SendGump(new VendorGump(from, this));
			}

               

        

        public override int GetHairHue()
        {
            return Utility.RandomBrightHue();
        }

        public override void InitOutfit()
        {
            base.InitOutfit();

            AddItem(new Robe(Utility.RandomPinkHue()));
        }

        public override bool CheckVendorAccess(Mobile from)
        {


            return base.CheckVendorAccess(from);
        }

        public override void InitSBInfo()
        { }
		private bool m_Blessed;
		private bool m_Bonded;
		private bool m_Hued;
		private int m_BlessedPrice;
		private int m_BondedPrice;
		private int m_HuedPrice;

		private Type m_Currency = typeof(Gold);

		private int m_Price1; private int m_Price2; private int m_Price3; private int m_Price4;
		private int m_Price5; private int m_Price6; private int m_Price7; private int m_Price8;
		private int m_Price9; private int m_Price10; private int m_Price11; private int m_Price12;
		private int m_Price13; private int m_Price14; private int m_Price15; private int m_Price16;
		private int m_Price17; private int m_Price18; private int m_Price19; private int m_Price20;
		private int m_Price21; private int m_Price22; private int m_Price23; private int m_Price24;
		private int m_Price25; private int m_Price26; private int m_Price27; private int m_Price28;
		private int m_Price29; private int m_Price30; private int m_Price31; private int m_Price32;
		private int m_Price33; private int m_Price34; private int m_Price35; private int m_Price36;
		private int m_Price37; private int m_Price38; private int m_Price39; private int m_Price40;


		private string m_Item1; private string m_Item2; private string m_Item3; private string m_Item4;
		private string m_Item5; private string m_Item6; private string m_Item7; private string m_Item8;
		private string m_Item9; private string m_Item10; private string m_Item11; private string m_Item12;
		private string m_Item13; private string m_Item14; private string m_Item15; private string m_Item16;
		private string m_Item17; private string m_Item18; private string m_Item19; private string m_Item20;
		private string m_Item21; private string m_Item22; private string m_Item23; private string m_Item24;
		private string m_Item25; private string m_Item26; private string m_Item27; private string m_Item28;
		private string m_Item29; private string m_Item30; private string m_Item31; private string m_Item32;
		private string m_Item33; private string m_Item34; private string m_Item35; private string m_Item36;
		private string m_Item37; private string m_Item38; private string m_Item39; private string m_Item40;


		private string m_GumpName1; private string m_GumpName2; private string m_GumpName3; private string m_GumpName4;
		private string m_GumpName5; private string m_GumpName6; private string m_GumpName7; private string m_GumpName8;
		private string m_GumpName9; private string m_GumpName10; private string m_GumpName11; private string m_GumpName12;
		private string m_GumpName13; private string m_GumpName14; private string m_GumpName15; private string m_GumpName16;
		private string m_GumpName17; private string m_GumpName18; private string m_GumpName19; private string m_GumpName20;
		private string m_GumpName21; private string m_GumpName22; private string m_GumpName23; private string m_GumpName24;
		private string m_GumpName25; private string m_GumpName26; private string m_GumpName27; private string m_GumpName28;
		private string m_GumpName29; private string m_GumpName30; private string m_GumpName31; private string m_GumpName32;
		private string m_GumpName33; private string m_GumpName34; private string m_GumpName35; private string m_GumpName36;
		private string m_GumpName37; private string m_GumpName38; private string m_GumpName39; private string m_GumpName40;

		//[CommandProperty( AccessLevel.Seer )]
		public bool Blessed { get { return m_Blessed; } set { m_Blessed = value; } }

		//[CommandProperty( AccessLevel.Seer )]
		public bool Bonded { get { return m_Bonded; } set { m_Bonded = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public bool Hued { get { return m_Hued; } set { m_Hued = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int BlessedPrice { get { return m_BlessedPrice; } set { m_BlessedPrice = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int BondedPrice { get { return m_BondedPrice; } set { m_BondedPrice = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int HuedPrice { get { return m_HuedPrice; } set { m_HuedPrice = value; } }

		[CommandProperty(AccessLevel.Seer)]
		public Type Currency { get { return m_Currency; } set { m_Currency = value; } }

		//[CommandProperty( AccessLevel.Seer )]
		public int Price1 { get { return m_Price1; } set { m_Price1 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price2 { get { return m_Price2; } set { m_Price2 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price3 { get { return m_Price3; } set { m_Price3 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price4 { get { return m_Price4; } set { m_Price4 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price5 { get { return m_Price5; } set { m_Price5 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price6 { get { return m_Price6; } set { m_Price6 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price7 { get { return m_Price7; } set { m_Price7 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price8 { get { return m_Price8; } set { m_Price8 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price9 { get { return m_Price9; } set { m_Price9 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price10 { get { return m_Price10; } set { m_Price10 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price11 { get { return m_Price11; } set { m_Price11 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price12 { get { return m_Price12; } set { m_Price12 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price13 { get { return m_Price13; } set { m_Price13 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price14 { get { return m_Price14; } set { m_Price14 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price15 { get { return m_Price15; } set { m_Price15 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price16 { get { return m_Price16; } set { m_Price16 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price17 { get { return m_Price17; } set { m_Price17 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price18 { get { return m_Price18; } set { m_Price18 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price19 { get { return m_Price19; } set { m_Price19 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price20 { get { return m_Price20; } set { m_Price20 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price21 { get { return m_Price21; } set { m_Price21 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price22 { get { return m_Price22; } set { m_Price22 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price23 { get { return m_Price23; } set { m_Price23 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price24 { get { return m_Price24; } set { m_Price24 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price25 { get { return m_Price25; } set { m_Price25 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price26 { get { return m_Price26; } set { m_Price26 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price27 { get { return m_Price27; } set { m_Price27 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price28 { get { return m_Price28; } set { m_Price28 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price29 { get { return m_Price29; } set { m_Price29 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price30 { get { return m_Price30; } set { m_Price30 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price31 { get { return m_Price31; } set { m_Price31 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price32 { get { return m_Price32; } set { m_Price32 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price33 { get { return m_Price33; } set { m_Price33 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price34 { get { return m_Price34; } set { m_Price34 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price35 { get { return m_Price35; } set { m_Price35 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price36 { get { return m_Price36; } set { m_Price36 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price37 { get { return m_Price37; } set { m_Price37 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price38 { get { return m_Price38; } set { m_Price38 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price39 { get { return m_Price39; } set { m_Price39 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public int Price40 { get { return m_Price40; } set { m_Price40 = value; } }


		//[CommandProperty( AccessLevel.Seer )]
		public string Item1 { get { return m_Item1; } set { m_Item1 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item2 { get { return m_Item2; } set { m_Item2 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item3 { get { return m_Item3; } set { m_Item3 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item4 { get { return m_Item4; } set { m_Item4 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item5 { get { return m_Item5; } set { m_Item5 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item6 { get { return m_Item6; } set { m_Item6 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item7 { get { return m_Item7; } set { m_Item7 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item8 { get { return m_Item8; } set { m_Item8 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item9 { get { return m_Item9; } set { m_Item9 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item10 { get { return m_Item10; } set { m_Item10 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item11 { get { return m_Item11; } set { m_Item11 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item12 { get { return m_Item12; } set { m_Item12 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item13 { get { return m_Item13; } set { m_Item13 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item14 { get { return m_Item14; } set { m_Item14 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item15 { get { return m_Item15; } set { m_Item15 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item16 { get { return m_Item16; } set { m_Item16 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item17 { get { return m_Item17; } set { m_Item17 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item18 { get { return m_Item18; } set { m_Item18 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item19 { get { return m_Item19; } set { m_Item19 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item20 { get { return m_Item20; } set { m_Item20 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item21 { get { return m_Item21; } set { m_Item21 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item22 { get { return m_Item22; } set { m_Item22 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item23 { get { return m_Item23; } set { m_Item23 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item24 { get { return m_Item24; } set { m_Item24 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item25 { get { return m_Item25; } set { m_Item25 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item26 { get { return m_Item26; } set { m_Item26 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item27 { get { return m_Item27; } set { m_Item27 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item28 { get { return m_Item28; } set { m_Item28 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item29 { get { return m_Item29; } set { m_Item29 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item30 { get { return m_Item30; } set { m_Item30 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item31 { get { return m_Item31; } set { m_Item31 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item32 { get { return m_Item32; } set { m_Item32 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item33 { get { return m_Item33; } set { m_Item33 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item34 { get { return m_Item34; } set { m_Item34 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item35 { get { return m_Item35; } set { m_Item35 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item36 { get { return m_Item36; } set { m_Item36 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item37 { get { return m_Item37; } set { m_Item37 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item38 { get { return m_Item38; } set { m_Item38 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item39 { get { return m_Item39; } set { m_Item39 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string Item40 { get { return m_Item40; } set { m_Item40 = value; } }


		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName1 { get { return m_GumpName1; } set { m_GumpName1 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName2 { get { return m_GumpName2; } set { m_GumpName2 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName3 { get { return m_GumpName3; } set { m_GumpName3 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName4 { get { return m_GumpName4; } set { m_GumpName4 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName5 { get { return m_GumpName5; } set { m_GumpName5 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName6 { get { return m_GumpName6; } set { m_GumpName6 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName7 { get { return m_GumpName7; } set { m_GumpName7 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName8 { get { return m_GumpName8; } set { m_GumpName8 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName9 { get { return m_GumpName9; } set { m_GumpName9 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName10 { get { return m_GumpName10; } set { m_GumpName10 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName11 { get { return m_GumpName11; } set { m_GumpName11 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName12 { get { return m_GumpName12; } set { m_GumpName12 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName13 { get { return m_GumpName13; } set { m_GumpName13 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName14 { get { return m_GumpName14; } set { m_GumpName14 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName15 { get { return m_GumpName15; } set { m_GumpName15 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName16 { get { return m_GumpName16; } set { m_GumpName16 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName17 { get { return m_GumpName17; } set { m_GumpName17 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName18 { get { return m_GumpName18; } set { m_GumpName18 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName19 { get { return m_GumpName19; } set { m_GumpName19 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName20 { get { return m_GumpName20; } set { m_GumpName20 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName21 { get { return m_GumpName21; } set { m_GumpName21 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName22 { get { return m_GumpName22; } set { m_GumpName22 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName23 { get { return m_GumpName23; } set { m_GumpName23 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName24 { get { return m_GumpName24; } set { m_GumpName24 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName25 { get { return m_GumpName25; } set { m_GumpName25 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName26 { get { return m_GumpName26; } set { m_GumpName26 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName27 { get { return m_GumpName27; } set { m_GumpName27 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName28 { get { return m_GumpName28; } set { m_GumpName28 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName29 { get { return m_GumpName29; } set { m_GumpName29 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName30 { get { return m_GumpName30; } set { m_GumpName30 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName31 { get { return m_GumpName31; } set { m_GumpName31 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName32 { get { return m_GumpName32; } set { m_GumpName32 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName33 { get { return m_GumpName33; } set { m_GumpName33 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName34 { get { return m_GumpName34; } set { m_GumpName34 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName35 { get { return m_GumpName35; } set { m_GumpName35 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName36 { get { return m_GumpName36; } set { m_GumpName36 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName37 { get { return m_GumpName37; } set { m_GumpName37 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName38 { get { return m_GumpName38; } set { m_GumpName38 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName39 { get { return m_GumpName39; } set { m_GumpName39 = value; } }
		//[CommandProperty( AccessLevel.Seer )]
		public string GumpName40 { get { return m_GumpName40; } set { m_GumpName40 = value; } }

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); // version 
			writer.Write((bool)Blessed);
			writer.Write((bool)Bonded);
			writer.Write((bool)Hued);
			writer.Write((int)BlessedPrice);
			writer.Write((int)BondedPrice);
			writer.Write((int)HuedPrice);

			writer.Write(m_Currency.ToString());

			writer.Write((int)Price1);
			writer.Write((int)Price2);
			writer.Write((int)Price3);
			writer.Write((int)Price4);
			writer.Write((int)Price5);
			writer.Write((int)Price6);
			writer.Write((int)Price7);
			writer.Write((int)Price8);
			writer.Write((int)Price9);
			writer.Write((int)Price10);
			writer.Write((int)Price11);
			writer.Write((int)Price12);
			writer.Write((int)Price13);
			writer.Write((int)Price14);
			writer.Write((int)Price15);
			writer.Write((int)Price16);
			writer.Write((int)Price17);
			writer.Write((int)Price18);
			writer.Write((int)Price19);
			writer.Write((int)Price20);
			writer.Write((int)Price21);
			writer.Write((int)Price22);
			writer.Write((int)Price23);
			writer.Write((int)Price24);
			writer.Write((int)Price25);
			writer.Write((int)Price26);
			writer.Write((int)Price27);
			writer.Write((int)Price28);
			writer.Write((int)Price29);
			writer.Write((int)Price30);
			writer.Write((int)Price31);
			writer.Write((int)Price32);
			writer.Write((int)Price33);
			writer.Write((int)Price34);
			writer.Write((int)Price35);
			writer.Write((int)Price36);
			writer.Write((int)Price37);
			writer.Write((int)Price38);
			writer.Write((int)Price39);
			writer.Write((int)Price40);

			writer.Write((string)Item1);
			writer.Write((string)Item2);
			writer.Write((string)Item3);
			writer.Write((string)Item4);
			writer.Write((string)Item5);
			writer.Write((string)Item6);
			writer.Write((string)Item7);
			writer.Write((string)Item8);
			writer.Write((string)Item9);
			writer.Write((string)Item10);
			writer.Write((string)Item11);
			writer.Write((string)Item12);
			writer.Write((string)Item13);
			writer.Write((string)Item14);
			writer.Write((string)Item15);
			writer.Write((string)Item16);
			writer.Write((string)Item17);
			writer.Write((string)Item18);
			writer.Write((string)Item19);
			writer.Write((string)Item20);
			writer.Write((string)Item21);
			writer.Write((string)Item22);
			writer.Write((string)Item23);
			writer.Write((string)Item24);
			writer.Write((string)Item25);
			writer.Write((string)Item26);
			writer.Write((string)Item27);
			writer.Write((string)Item28);
			writer.Write((string)Item29);
			writer.Write((string)Item30);
			writer.Write((string)Item31);
			writer.Write((string)Item32);
			writer.Write((string)Item33);
			writer.Write((string)Item34);
			writer.Write((string)Item35);
			writer.Write((string)Item36);
			writer.Write((string)Item37);
			writer.Write((string)Item38);
			writer.Write((string)Item39);
			writer.Write((string)Item40);

			writer.Write((string)GumpName1);
			writer.Write((string)GumpName2);
			writer.Write((string)GumpName3);
			writer.Write((string)GumpName4);
			writer.Write((string)GumpName5);
			writer.Write((string)GumpName6);
			writer.Write((string)GumpName7);
			writer.Write((string)GumpName8);
			writer.Write((string)GumpName9);
			writer.Write((string)GumpName10);
			writer.Write((string)GumpName11);
			writer.Write((string)GumpName12);
			writer.Write((string)GumpName13);
			writer.Write((string)GumpName14);
			writer.Write((string)GumpName15);
			writer.Write((string)GumpName16);
			writer.Write((string)GumpName17);
			writer.Write((string)GumpName18);
			writer.Write((string)GumpName19);
			writer.Write((string)GumpName20);
			writer.Write((string)GumpName21);
			writer.Write((string)GumpName22);
			writer.Write((string)GumpName23);
			writer.Write((string)GumpName24);
			writer.Write((string)GumpName25);
			writer.Write((string)GumpName26);
			writer.Write((string)GumpName27);
			writer.Write((string)GumpName28);
			writer.Write((string)GumpName29);
			writer.Write((string)GumpName30);
			writer.Write((string)GumpName31);
			writer.Write((string)GumpName32);
			writer.Write((string)GumpName33);
			writer.Write((string)GumpName34);
			writer.Write((string)GumpName35);
			writer.Write((string)GumpName36);
			writer.Write((string)GumpName37);
			writer.Write((string)GumpName38);
			writer.Write((string)GumpName39);
			writer.Write((string)GumpName40);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

			m_Blessed = reader.ReadBool();
			m_Bonded = reader.ReadBool();
			m_Hued = reader.ReadBool();
			m_BlessedPrice = reader.ReadInt();
			m_BondedPrice = reader.ReadInt();
			m_HuedPrice = reader.ReadInt();

			m_Currency = ScriptCompiler.FindTypeByFullName(reader.ReadString());

			m_Price1 = reader.ReadInt();
			m_Price2 = reader.ReadInt();
			m_Price3 = reader.ReadInt();
			m_Price4 = reader.ReadInt();
			m_Price5 = reader.ReadInt();
			m_Price6 = reader.ReadInt();
			m_Price7 = reader.ReadInt();
			m_Price8 = reader.ReadInt();
			m_Price9 = reader.ReadInt();
			m_Price10 = reader.ReadInt();
			m_Price11 = reader.ReadInt();
			m_Price12 = reader.ReadInt();
			m_Price13 = reader.ReadInt();
			m_Price14 = reader.ReadInt();
			m_Price15 = reader.ReadInt();
			m_Price16 = reader.ReadInt();
			m_Price17 = reader.ReadInt();
			m_Price18 = reader.ReadInt();
			m_Price19 = reader.ReadInt();
			m_Price20 = reader.ReadInt();
			m_Price21 = reader.ReadInt();
			m_Price22 = reader.ReadInt();
			m_Price23 = reader.ReadInt();
			m_Price24 = reader.ReadInt();
			m_Price25 = reader.ReadInt();
			m_Price26 = reader.ReadInt();
			m_Price27 = reader.ReadInt();
			m_Price28 = reader.ReadInt();
			m_Price29 = reader.ReadInt();
			m_Price30 = reader.ReadInt();
			m_Price31 = reader.ReadInt();
			m_Price32 = reader.ReadInt();
			m_Price33 = reader.ReadInt();
			m_Price34 = reader.ReadInt();
			m_Price35 = reader.ReadInt();
			m_Price36 = reader.ReadInt();
			m_Price37 = reader.ReadInt();
			m_Price38 = reader.ReadInt();
			m_Price39 = reader.ReadInt();
			m_Price40 = reader.ReadInt();

			m_Item1 = reader.ReadString();
			m_Item2 = reader.ReadString();
			m_Item3 = reader.ReadString();
			m_Item4 = reader.ReadString();
			m_Item5 = reader.ReadString();
			m_Item6 = reader.ReadString();
			m_Item7 = reader.ReadString();
			m_Item8 = reader.ReadString();
			m_Item9 = reader.ReadString();
			m_Item10 = reader.ReadString();
			m_Item11 = reader.ReadString();
			m_Item12 = reader.ReadString();
			m_Item13 = reader.ReadString();
			m_Item14 = reader.ReadString();
			m_Item15 = reader.ReadString();
			m_Item16 = reader.ReadString();
			m_Item17 = reader.ReadString();
			m_Item18 = reader.ReadString();
			m_Item19 = reader.ReadString();
			m_Item20 = reader.ReadString();
			m_Item21 = reader.ReadString();
			m_Item22 = reader.ReadString();
			m_Item23 = reader.ReadString();
			m_Item24 = reader.ReadString();
			m_Item25 = reader.ReadString();
			m_Item26 = reader.ReadString();
			m_Item27 = reader.ReadString();
			m_Item28 = reader.ReadString();
			m_Item29 = reader.ReadString();
			m_Item30 = reader.ReadString();
			m_Item31 = reader.ReadString();
			m_Item32 = reader.ReadString();
			m_Item33 = reader.ReadString();
			m_Item34 = reader.ReadString();
			m_Item35 = reader.ReadString();
			m_Item36 = reader.ReadString();
			m_Item37 = reader.ReadString();
			m_Item38 = reader.ReadString();
			m_Item39 = reader.ReadString();
			m_Item40 = reader.ReadString();

			m_GumpName1 = reader.ReadString();
			m_GumpName2 = reader.ReadString();
			m_GumpName3 = reader.ReadString();
			m_GumpName4 = reader.ReadString();
			m_GumpName5 = reader.ReadString();
			m_GumpName6 = reader.ReadString();
			m_GumpName7 = reader.ReadString();
			m_GumpName8 = reader.ReadString();
			m_GumpName9 = reader.ReadString();
			m_GumpName10 = reader.ReadString();
			m_GumpName11 = reader.ReadString();
			m_GumpName12 = reader.ReadString();
			m_GumpName13 = reader.ReadString();
			m_GumpName14 = reader.ReadString();
			m_GumpName15 = reader.ReadString();
			m_GumpName16 = reader.ReadString();
			m_GumpName17 = reader.ReadString();
			m_GumpName18 = reader.ReadString();
			m_GumpName19 = reader.ReadString();
			m_GumpName20 = reader.ReadString();
			m_GumpName21 = reader.ReadString();
			m_GumpName22 = reader.ReadString();
			m_GumpName23 = reader.ReadString();
			m_GumpName24 = reader.ReadString();
			m_GumpName25 = reader.ReadString();
			m_GumpName26 = reader.ReadString();
			m_GumpName27 = reader.ReadString();
			m_GumpName28 = reader.ReadString();
			m_GumpName29 = reader.ReadString();
			m_GumpName30 = reader.ReadString();
			m_GumpName31 = reader.ReadString();
			m_GumpName32 = reader.ReadString();
			m_GumpName33 = reader.ReadString();
			m_GumpName34 = reader.ReadString();
			m_GumpName35 = reader.ReadString();
			m_GumpName36 = reader.ReadString();
			m_GumpName37 = reader.ReadString();
			m_GumpName38 = reader.ReadString();
			m_GumpName39 = reader.ReadString();
			m_GumpName40 = reader.ReadString();
		}
	}
}