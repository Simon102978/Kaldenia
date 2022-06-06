using System;
using Server;
using Server.Items;
using Server.Network;
using Server.Mobiles;
using Server.Targeting;
using Server.Misc;
using Server.Gumps;
using Server.Scripts.Commands;
using Server.Engines.Craft;

namespace Server.Items
{

    public abstract class BarberScissorsBase : Item
    { 

		public int m_UsesRemaining;
        public int m_MaxUsesRemaining;

		[CommandProperty( AccessLevel.GameMaster )]
		public int UsesRemaining
		{
			get { return m_UsesRemaining; }
			set { m_UsesRemaining = value; }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int MaxUsesRemaining
        {
            get { return m_MaxUsesRemaining; }
            set { m_MaxUsesRemaining = value; }
        }

		public BarberScissorsBase(int itemID)
            : this(itemID, 0)
        {
        }

        public BarberScissorsBase(int itemID, int hue)
            : base(itemID)
        {
            Hue = hue;
            Name = "Ciseaux de barbier";
			m_MaxUsesRemaining = 50;
			m_UsesRemaining = 50;
            Movable = true;
        }
		
		public override void OnDoubleClick( Mobile from )
		{
			from.SendLocalizedMessage( 502434 ); // What should I use these scissors on?

			from.Target = new InternalTarget( this );
		}

		private class InternalTarget : Target
		{
			private BarberScissorsBase m_Item;

			public InternalTarget( BarberScissorsBase item ) : base( 1, false, TargetFlags.None )
			{
				m_Item = item;
			}
		
			protected override void OnTarget( Mobile from, object targeted )
            {
                if (targeted is CustomPlayerMobile)
                {
                    CustomPlayerMobile m = (CustomPlayerMobile)targeted;
					CustomPlayerMobile from2 = from as CustomPlayerMobile;
					
					int correct = 1;
					
					if (m_Item.UsesRemaining < 1)
					{
						correct = 0;
						from.SendMessage("Vous avez brisé votre outil");
						m_Item.Delete();
					}
					if (correct == 1)
					{
						from.SendGump(new CoiffureGump(from2,m,0,m_Item));
					}
				}
				else if (targeted is BaseVendor && from.AccessLevel > AccessLevel.Player)
				{
					CustomPlayerMobile from2 = from as CustomPlayerMobile;
					BaseVendor m = (BaseVendor)targeted;

					from.SendGump(new CoiffureGump(from2, m, 0, m_Item));
				}




                else
                {
                    from.SendLocalizedMessage(502440); // Scissors can not be used on that to produce anything.
                }
			}
			
		}
		
		public BarberScissorsBase(Serial serial)
            : base(serial)
        {
        }
		
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
			writer.Write( (int) m_UsesRemaining );
            writer.Write((int)m_MaxUsesRemaining);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
			m_UsesRemaining = reader.ReadInt();
			m_MaxUsesRemaining = reader.ReadInt();
        }
		
    }

    public class BarberScissors : BarberScissorsBase
    {
		
        [Constructable]
        public BarberScissors()
            : this(1)
        {
        }

        [Constructable]
        public BarberScissors(int amount)
            : base(0xDFC)
        {
            Name = "Ciseaux de barbier";
            Weight = 0.1;
        }

        public BarberScissors(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
			writer.Write( (int) m_UsesRemaining );
            writer.Write((int)m_MaxUsesRemaining);
		}

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
			m_UsesRemaining = reader.ReadInt();
			m_MaxUsesRemaining = reader.ReadInt();
        }
    }


}