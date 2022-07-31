namespace Server.Mobiles
{
    [CorpseName("Graisse Liquide")]
    public class GraisseMiamus : BaseCreature
    {
        [Constructable]
        public GraisseMiamus()
            : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Name = "Amas de graisse";
            Body = 51;
            BaseSoundID = 456;

			double dActiveSpeed = 0.05;
			double dPassiveSpeed = 0.1;

			SpeedInfo.GetCustomSpeeds(this, ref dActiveSpeed, ref dPassiveSpeed);

			ActiveSpeed = dActiveSpeed;
			PassiveSpeed = dPassiveSpeed;
			CurrentSpeed = dPassiveSpeed;


            Hue =  1154;

            SetStr(196, 250);
            SetDex(76, 95);
            SetInt(36, 60);

            SetHits(118, 150);

            SetDamage(8, 18);

            SetDamageType(ResistanceType.Physical, 40);
            SetDamageType(ResistanceType.Cold, 60);

            SetResistance(ResistanceType.Physical, 35, 45);
            SetResistance(ResistanceType.Fire, 20, 30);
            SetResistance(ResistanceType.Cold, 50, 60);
            SetResistance(ResistanceType.Poison, 20, 30);
            SetResistance(ResistanceType.Energy, 30, 40);

            SetSkill(SkillName.MagicResist, 65.1, 80.0);
            SetSkill(SkillName.Tactics, 85.1, 100.0);
            SetSkill(SkillName.Wrestling, 85.1, 95.0);

            Fame = 3000;
            Karma = -3000;
        }

        public GraisseMiamus(Serial serial)
            : base(serial)
        {
        }
		public override TribeType Tribe => TribeType.Geant;
		public override Poison PoisonImmune => Poison.Lethal;
        public override bool BleedImmune => true;
        public override FoodType FavoriteFood => FoodType.Meat | FoodType.Fish | FoodType.FruitsAndVegies | FoodType.GrainsAndHay | FoodType.Eggs;
        public override void GenerateLoot()
        {
            AddLoot(LootPack.Average);
            AddLoot(LootPack.Meager);
        }

		public override bool CheckMovement(Direction d, out int newZ)
        {
            if (!base.CheckMovement(d, out newZ))
                return false;

            if (Region.IsPartOf("Underworld") && newZ > Location.Z)
                return false;

            return true;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(1);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
