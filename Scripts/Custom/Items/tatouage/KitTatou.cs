using System;
using Server;
using Server.Items;
using Server.Network;
using Server.Mobiles;
using Server.Targeting;
using Server.Misc;
using Server.Gumps;
using Server.Spells.Fifth;
using Server.Spells.Seventh;
using Server.Spells.Necromancy;
using Server.Scripts.Commands;
using Server.Engines.Craft;

namespace Server.Items
{

    public abstract class KitTatouBase : Item
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

		public KitTatouBase(int itemID)
            : this(itemID, 0)
        {
        }

        public KitTatouBase(int itemID, int hue)
            : base(itemID)
        {
            Hue = 2406;
            Name = "Encre de tatouages";
			m_MaxUsesRemaining = 50;
			m_UsesRemaining = 50;
            Movable = true;
        }
		
		public override void OnDoubleClick( Mobile from )
		{
			from.SendMessage("Sur qui voulez vous faire un tatouage ?");

			from.Target = new InternalTarget( this );
		}

		private class InternalTarget : Target
		{
			private KitTatouBase m_Item;

			public InternalTarget( KitTatouBase item ) : base( 1, false, TargetFlags.None )
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
						if (from == m)
						{
							from.SendGump(new TatouageGump(from2,m,TGumpPage.Page1,1,0,m_Item));
						}
						else
						{
							from.SendGump(new TatouageGump(from2,m,TGumpPage.Page1,2,0,m_Item));
						}
					}
				}
                else
                {
					from.SendMessage("Vous ne pouvez faire un tatouage sur cela...");
                }
			}
			
		}
		
		public KitTatouBase(Serial serial)
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

    public class KitTatou : KitTatouBase
    {
		
        [Constructable]
        public KitTatou()
            : this(1)
        {
        }

        [Constructable]
        public KitTatou(int amount)
            : base(0x2D62)
        {
            Name = "Encre de tatouage";
            Weight = 0.1;
        }

        public KitTatou(Serial serial)
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