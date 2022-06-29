using Server.Accounting;

namespace Server.Items
{
    public class PieceArgent : Item
    {
        [Constructable]
        public PieceArgent()
            : this(1)
        {
        }

        [Constructable]
        public PieceArgent(int amountFrom, int amountTo)
            : this(Utility.RandomMinMax(amountFrom, amountTo))
        {
        }

        [Constructable]
        public PieceArgent(int amount)
            : base(0x0EF0)
        {
            Stackable = true;
            Amount = amount;

			if (amount != 1)
			{
				Name = "Pièces d'Argents";
			}
			else
			{
				Name = "Pièce d'Argent";
			}

			
        }

        public PieceArgent(Serial serial)
            : base(serial)
        {
        }

        public override double DefaultWeight => 0.02 / 3;

        public override int GetDropSound()
        {
            if (Amount <= 1)
                return 0x2E4;
            else if (Amount <= 5)
                return 0x2E5;
            else
                return 0x2E6;
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

        protected override void OnAmountChange(int oldValue)
        {
            int newValue = Amount;

			if (newValue != 1)
			{
				Name = "Pièces d'Argent";
			}
			else
			{
				Name = "Pièce d'Argent";
			}

			//UpdateTotal(this, TotalType.Gold, newValue - oldValue);
        }
    }
}
