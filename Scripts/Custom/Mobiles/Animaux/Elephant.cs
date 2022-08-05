namespace Server.Mobiles
{
    [CorpseName("Le corps d'un Elephant")]
    public class Elephant : BaseCreature
    {
        [Constructable]
        public Elephant()
            : base(AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Name = "Un Elephant";
            Body = 260;
            BaseSoundID = 0x3EF;

            SetStr(126, 155);
            SetDex(81, 105);
            SetInt(16, 40);

            SetHits(76, 93);
            SetMana(0);

            SetDamage(8, 13);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 25, 35);
            SetResistance(ResistanceType.Cold, 15, 25);
            SetResistance(ResistanceType.Poison, 5, 10);
            SetResistance(ResistanceType.Energy, 5, 10);

            SetSkill(SkillName.MagicResist, 25.1, 40.0);
            SetSkill(SkillName.Tactics, 70.1, 100.0);
            SetSkill(SkillName.Wrestling, 45.1, 70.0);

            Fame = 1000;
            Karma = 0;

            Tamable = true;
            ControlSlots = 1;
            MinTameSkill = 40.1;
        }

        public Elephant(Serial serial)
            : base(serial)
        {
        }

        public override int Meat => 5;
        public override int Hides => 8;
        public override FoodType FavoriteFood =>  FoodType.FruitsAndVegies;

		public override bool CanBeParagon => false;

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
