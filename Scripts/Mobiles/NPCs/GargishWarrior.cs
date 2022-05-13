using Server.Items;

namespace Server.Mobiles
{
    public class Warrior : BaseCreature
    {
        [Constructable]
        public Warrior()
            : base(AIType.AI_Melee, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Warrior";
            if (Female = Utility.RandomBool())
            {
                Body = 667;
                HairItemID = 17067;
                HairHue = 1762;
                AddItem(new FemalePlateChest());           
                AddItem(new PlateTalons());

                AddItem(new GlassSword());
            }
            else
            {
                Body = 666;
                HairItemID = 16987;
                HairHue = 1801;
                AddItem(new PlateChest());
                AddItem(new PlateLegs());
                AddItem(new PlateArms());
                AddItem(new PlateTalons());

                AddItem(new GlassSword());
            }
        }

        public Warrior(Serial serial)
            : base(serial)
        {
        }

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
