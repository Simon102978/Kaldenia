using Server.Items;
using System;

namespace Server.Mobiles
{
    [CorpseName("Corps de Roux-tisane")]
    public class TitusRouxTisane : TitusFanatiqueBase
	{
        [Constructable]
        public TitusRouxTisane()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.15, 0.4)
        {

			SpeechHue = Utility.RandomDyedHue();
			Title = Utility.RandomBool() ? "Roux-tisane" : "Courtisane de Titus";

			Race = Race.GetRace(Utility.Random(4));

			Female = true;
		
			Body = 0x191;
			Name = NameList.RandomName("female");
			AddItem(new Skirt(Utility.RandomNeutralHue()));

			SetStr(151, 170);
			SetDex(92, 130);
			SetInt(51, 65);

			SetDamage(15, 20);

			SetResistance(ResistanceType.Physical, 55, 60);
			SetResistance(ResistanceType.Fire, 25, 35);
			SetResistance(ResistanceType.Cold, 30, 40);
			SetResistance(ResistanceType.Poison, 30, 40);
			SetResistance(ResistanceType.Energy, 30, 40);

			SetSkill(SkillName.MagicResist, 55.0, 65.0);
			SetSkill(SkillName.Tactics, 80.0, 100.0);
			SetSkill(SkillName.Wrestling, 80.0, 100.0);
			SetSkill(SkillName.Fencing, 80, 110);
			SetSkill(SkillName.Macing, 80, 110);
			SetSkill(SkillName.Swords, 80, 110);

			SetSkill(SkillName.Musicianship, 100);
			SetSkill(SkillName.Discordance, 100);
			SetSkill(SkillName.Provocation, 100);
			SetSkill(SkillName.Peacemaking, 100);

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
        }

        public TitusRouxTisane(Serial serial)
            : base(serial)
        {
        }

		public override bool CanDiscord => true;
		public override bool CanPeace => true;
		public override bool CanProvoke => true;

		public override int Meat => 1;
        public override bool AlwaysMurderer => true;
        public override bool ShowFameTitle => false;


        public override void GenerateLoot()
        {
            AddLoot(LootPack.Rich);
			AddLoot(LootPack.Rich);
			AddLoot(LootPack.Others, Utility.RandomMinMax(3, 4));
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
