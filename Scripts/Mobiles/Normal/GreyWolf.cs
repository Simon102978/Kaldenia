using Server.Items;

namespace Server.Mobiles
{
    [CorpseName("a grey wolf corpse")]
    public class GreyWolf : BaseCreature
    {
        [Constructable]
        public GreyWolf()
            : base(AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = "a grey wolf";
            Body = Utility.RandomList(25, 27);
            BaseSoundID = 0xE5;

            SetStr(56, 80);
            SetDex(56, 75);
            SetInt(31, 55);

            SetHits(34, 48);
            SetMana(0);

            SetDamage(3, 7);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 15, 20);
            SetResistance(ResistanceType.Fire, 10, 15);
            SetResistance(ResistanceType.Cold, 20, 25);
            SetResistance(ResistanceType.Poison, 10, 15);
            SetResistance(ResistanceType.Energy, 10, 15);

            SetSkill(SkillName.MagicResist, 20.1, 35.0);
            SetSkill(SkillName.Tactics, 45.1, 60.0);
            SetSkill(SkillName.Wrestling, 45.1, 60.0);

            Fame = 450;
            Karma = 0;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 53.1;
        }

        public GreyWolf(Serial serial)
            : base(serial)
        {
        }

		public override bool CanBeParagon => false;
		public override int Meat => 1;
		public override int Hides => 5;
		public override HideType HideType => HideType.Lupus;


		public override int Bones => 5;
		public override BoneType BoneType => BoneType.Lupus;

		public override FoodType FavoriteFood => FoodType.Meat;
        public override PackInstinct PackInstinct => PackInstinct.Canine;

		public override void GenerateLoot()
		{
			AddLoot(LootPack.LootItem<PoilsLoup>());
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
