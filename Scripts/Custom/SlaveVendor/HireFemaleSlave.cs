using Server.Items;

namespace Server.Mobiles
{
    public class HireFemaleSlave : BaseHire
	{
        [Constructable]
        public HireFemaleSlave()
        {
            SpeechHue = Utility.RandomDyedHue();
            Hue = Utility.RandomSkinHue();

            Body = 0x191;
			Female = true;
            Name = NameList.RandomName("female");
			ActiveSpeed = 1.0;
			PassiveSpeed = 1.0;

			switch (Utility.Random(2))
            {
                case 0:
                    AddItem(new Skirt(Utility.RandomNeutralHue()));
                    break;
                case 1:
                    AddItem(new Kilt(Utility.RandomNeutralHue()));
                    break;
            }

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

			ControlSlots = 2;
			Tamable = false;
		}

		public HireFemaleSlave(Serial serial) : base(serial)
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