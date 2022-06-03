using Server.Items;

namespace Server.Mobiles
{
    public class HireMaleSlave : BaseHire
	{
        [Constructable]
        public HireMaleSlave()
		{
            SpeechHue = Utility.RandomDyedHue();
            Hue = Utility.RandomSkinHue();

            Body = 0x190;
            Name = NameList.RandomName("male");
            AddItem(new ShortPants(Utility.RandomNeutralHue()));

            Title = "Esclave";
            HairItemID = Race.RandomHair(Female);
            HairHue = Race.RandomHairHue();
            Race.RandomFacialHair(this);

			SetStr(100);
			SetDex(100);
			SetInt(25);

			SetDamage(10, 23);

			SetSkill(SkillName.Tactics, 50);
			SetSkill(SkillName.Wrestling, 50);
			SetSkill(SkillName.Swords, 50);

			Fame = 0;
            Karma = 0;

            AddItem(new Sandals(Utility.RandomNeutralHue()));
            switch (Utility.Random(2))
            {
                case 0:
                    AddItem(new Doublet(Utility.RandomNeutralHue()));
                    break;
                case 1:
                    AddItem(new Shirt(Utility.RandomNeutralHue()));
                    break;
            }

			ControlSlots = 1;
			Tamable = false;
		}

        public HireMaleSlave(Serial serial) : base(serial)
        {
        }

        public override bool ClickTitle => false;
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0);// version 
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}