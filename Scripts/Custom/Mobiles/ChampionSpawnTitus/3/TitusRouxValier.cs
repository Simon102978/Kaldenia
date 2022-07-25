using Server.Items;
using System;

namespace Server.Mobiles
{
    [CorpseName("Corps de Rouxvalier")]
    public class TitusRouxValier : TitusFanatiqueBase
	{
        [Constructable]
        public TitusRouxValier()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.15, 0.4)
        {

			SpeechHue = Utility.RandomDyedHue();
			Title = Utility.RandomBool() ? "Roux-valier" : "Chevalier de Titus";

			Race = Race.GetRace(Utility.Random(4));

			double dActiveSpeed = 0.05;
			double dPassiveSpeed = 0.1;


			SpeedInfo.GetCustomSpeeds(this, ref dActiveSpeed, ref dPassiveSpeed);

			ActiveSpeed = dActiveSpeed;
			PassiveSpeed = dPassiveSpeed;
			CurrentSpeed = dPassiveSpeed;

			if (Female = Utility.RandomBool())
			{
				Body = 0x191;
				Name = NameList.RandomName("female");
				AddItem(new Skirt(Utility.RandomNeutralHue()));
			}
			else
			{
				Body = 0x190;
				Name = NameList.RandomName("male");
				AddItem(new ShortPants(Utility.RandomNeutralHue()));
			}


			SetStr(151, 170);
			SetDex(92, 130);
			SetInt(51, 65);

			SetDamage(20, 30);


			SetDamageType(ResistanceType.Physical, 100);

            SetSkill(SkillName.Fencing, 70, 110);
            SetSkill(SkillName.Healing, 60.3, 90.0);
            SetSkill(SkillName.Macing, 70, 110);
            SetSkill(SkillName.Poisoning, 60.0, 82.5);
            SetSkill(SkillName.MagicResist, 72.5, 95.0);
            SetSkill(SkillName.Swords, 70, 110);
            SetSkill(SkillName.Tactics, 72.5, 95.0);

			AddItem(new Boots(Utility.RandomNeutralHue()));
			AddItem(new FancyShirt());
			AddItem(new Bandana());

			switch (Utility.Random(7))
			{
				case 0:
					AddItem(new Longsword());
					break;
				case 1:
					AddItem(new Cutlass());
					break;
				case 2:
					AddItem(new Broadsword());
					break;
				case 3:
					AddItem(new Axe());
					break;
				case 4:
					AddItem(new Club());
					break;
				case 5:
					AddItem(new Dagger());
					break;
				case 6:
					AddItem(new Spear());
					break;
			}


			Utility.AssignRandomHair(this, RouxCouleur());

			new Horse().Rider = this;

			AdjustSpeeds();

		}


		public override void AdjustSpeeds()
		{
			double activeSpeed = 0.0;
			double passiveSpeed = 0.0;


			if (Mounted)
			{
				SpeedInfo.GetCustomSpeeds(this, ref activeSpeed, ref passiveSpeed);
			}
			else
			{
				SpeedInfo.GetSpeeds(this, ref activeSpeed, ref passiveSpeed);
			}

			

			ActiveSpeed = activeSpeed;
			PassiveSpeed = passiveSpeed;
			CurrentSpeed = passiveSpeed;
		}


		public TitusRouxValier(Serial serial)
            : base(serial)
        {
        }

		public override void OnDamage(int amount, Mobile from, bool willKill)
		{
			AdjustSpeeds();

			base.OnDamage(amount, from, willKill);
		}
		public override int Meat => 1;
        public override bool AlwaysMurderer => true;
        public override bool ShowFameTitle => false;


        public override void GenerateLoot()
        {
            AddLoot(LootPack.Rich);
			AddLoot(LootPack.Others, Utility.RandomMinMax(3, 4));
		}

        public override bool OnBeforeDeath()
        {
            IMount mount = Mount;

            if (mount != null)
                mount.Rider = null;

            if (mount is Mobile)
                ((Mobile)mount).Delete();

            return base.OnBeforeDeath();
        }


        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
