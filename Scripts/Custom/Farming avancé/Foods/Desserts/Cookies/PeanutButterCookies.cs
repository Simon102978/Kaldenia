namespace Server.Items
{
    public class PeanutButterCookies : ContainerFood
    {
        public override int MinSkill { get { return 0; } }
        public override int MaxSkill { get { return 100; } }
        public override bool NeedSilverware { get { return false; } }
        public override string CookedMessage { get { return "You make some peanut butter cookies."; } }
        public override Item FoodContainer { get { return new DirtyPlate(); } }

        [Constructable]
        public PeanutButterCookies()
            : base(0x160C)
        {
            Name = "Peanut Butter Cookies";
            Uses = 3;
            FillFactor = 2;
        }

        public PeanutButterCookies(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
