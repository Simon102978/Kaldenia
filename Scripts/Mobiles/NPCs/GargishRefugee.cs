using Server.Items;

namespace Server.Mobiles
{
    public class Refugee : BaseCreature
    {
        [Constructable]
        public Refugee()
            : base(AIType.AI_Melee, FightMode.None, 10, 1, 0.2, 0.4)
        {
            Name = "Refugee";
            if (Female = Utility.RandomBool())
            {
                Body = 667;
                HairItemID = 17067;
                HairHue = 1762;
                AddItem(new ClothChest());
                AddItem(new ClothKilt(Utility.RandomNeutralHue()));
            }
            else
            {
                Body = 666;
                HairItemID = 16987;
                HairHue = 1801;
                AddItem(new ClothChest());
                AddItem(new ClothKilt());
                AddItem(new ClothLegs(Utility.RandomNeutralHue()));
            }
        }

        public Refugee(Serial serial)
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
