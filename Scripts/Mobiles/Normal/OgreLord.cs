using Server.Items;
namespace Server.Mobiles
{
    [CorpseName("Corp de Seigneur Ogre")]
    public class OgreLord : BaseCeosSpawn
	{
        [Constructable]
        public OgreLord()
            : base(AIType.AI_Melee, FightMode.Closest, 10,1, 0.2, 0.4)
        {
            Name = "Seigneur Ogre";
            Body = 83;
            BaseSoundID = 427;

            SetStr(767, 945);
            SetDex(66, 75);
            SetInt(46, 70);

            SetHits(476, 552);

            SetDamage(20, 25);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 45, 55);
            SetResistance(ResistanceType.Fire, 30, 40);
            SetResistance(ResistanceType.Cold, 30, 40);
            SetResistance(ResistanceType.Poison, 40, 50);
            SetResistance(ResistanceType.Energy, 40, 50);

            SetSkill(SkillName.MagicResist, 125.1, 140.0);
            SetSkill(SkillName.Tactics, 90.1, 100.0);
            SetSkill(SkillName.Wrestling, 90.1, 100.0);

            Fame = 15000;
            Karma = -15000;
        }

        public OgreLord(Serial serial)
            : base(serial)
        {
        }

		public override void GenerateLootParagon()
		{
			AddLoot(LootPack.LootItem<SangEnvoutePhysique>(), Utility.RandomMinMax(2, 4));
		}
		public override int Hides => 6;
		public override HideType HideType => HideType.Geant;


		public override int Bones => 6;
		public override BoneType BoneType => BoneType.Geant;

		public override bool CanRummageCorpses => true;
        public override Poison PoisonImmune => Poison.Regular;
        public override int TreasureMapLevel => 3;
        public override int Meat => 2;
        public override void GenerateLoot()
        {
            AddLoot(LootPack.Rich, 2);
			AddLoot(LootPack.Potions, 2);
			AddLoot(LootPack.Others, Utility.RandomMinMax(3, 4));
			AddLoot(LootPack.LootItem<CheveuxGeant>());
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