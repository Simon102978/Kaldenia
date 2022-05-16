using System;
using Server.Targeting;

namespace Server.Items
{
    public class FishOil : Item
    {
		
        [Constructable]
        public FishOil()
            : base(0x1C18)
        {
            Weight = 1.0;
        }

        public FishOil(Serial serial)
            : base(serial)
        {
        }

        public override int LabelNumber
        {
            get
            {
                return 1150863;
            }
        }// Fish Oil Flask
		
		public override void OnDoubleClick(Mobile from)
		{
			if ( !IsChildOf (from.Backpack))
			{
				from.SendLocalizedMessage(1042010); // You must have the object in your backpack to use it.
			}
			else
			{
				from.SendLocalizedMessage(1154219); // Where do you wish to use this?
				from.BeginTarget(2, false, TargetFlags.None, new TargetCallback( OnTargetOracle ));
			}
		}
		
		private void OnTargetOracle(Mobile from, object targeted)
		{
			if(targeted is OracleOfTheSea)
			{ 
				((OracleOfTheSea)targeted).UsesRemaining = 5;
			 
				from.SendMessage("Your have fully changed your Oracle of The Sea !"); // Confirmation message.
				this.Delete();
			}
			else if(targeted is Lantern)
			{
				((Lantern)targeted).Duration = TimeSpan.FromMinutes(60);
				((Lantern)targeted).Burning = true;	
				((Lantern)targeted).BurntOut = false;
				
				from.SendMessage("Your have fully changed your Lantern !"); // Confirmation message.
				this.Delete();
			}
			else
			{
				// If the targeted item is not the Oracle Of The Seas or a Lantern, the oil does nothing.
				from.SendMessage("This item does not have any effect on this.");
			}
		}
		
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
