namespace Server.Mobiles
{
    [CorpseName("Le Corps d'un Tigre")]
    public class TigerMount : BaseMount
    {
        [Constructable]
        public TigerMount()
            : this("Un Tigre")
        {
        }

        [Constructable]
        public TigerMount(string name)
            : base(name, 273, 273, AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
        {
            Hue = 0;

            BaseSoundID = 0x3EF;

            SetStr(94, 170);
            SetDex(96, 115);
            SetInt(6, 10);

            SetHits(71, 110);
            SetMana(0);

            SetDamage(11, 17);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 25, 30);
            SetResistance(ResistanceType.Fire, 10, 15);
            SetResistance(ResistanceType.Poison, 20, 25);
            SetResistance(ResistanceType.Energy, 20, 25);

            SetSkill(SkillName.MagicResist, 75.1, 80.0);
            SetSkill(SkillName.Tactics, 79.3, 94.0);
            SetSkill(SkillName.Wrestling, 79.3, 94.0);

            Fame = 1500;
            Karma = -1500;

            Tamable = true;
            ControlSlots = 2;
            MinTameSkill = 65.1;
        }

        public TigerMount(Serial serial)
            : base(serial)
        {
        }

        public override int Meat => 3;
        public override FoodType FavoriteFood => FoodType.Meat | FoodType.Fish | FoodType.Eggs | FoodType.FruitsAndVegies;
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