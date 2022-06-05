/*
 * Created by SharpDevelop.
 * User: gideon
 * Date: 2005/06/06
 * Time: 11:17 AM
 * 
 */

using System;
using Server.Gumps;
using Server.Mobiles;

namespace Server.Items
{
	public class RuneLute: Item
	{
        private int[] m_Notes;
        public int Size;
        private int _MAX_SIZE = 120;

        [CommandProperty(AccessLevel.GameMaster)] 
        public int[] Notes
        {
            get { return m_Notes; }
            set { m_Notes = value; }
        }

		[Constructable]
		public RuneLute() : base( 0xEB3 )
		{
			Name = "Luth fin";
			Weight = 5.0;
            Notes = new int[_MAX_SIZE];
            for (int i = 0; i < _MAX_SIZE; ++i)
                Notes[i] = 0;
            Size = 0;
		}

		public RuneLute( Serial serial ) : base( serial )
		{
            Notes = new int[_MAX_SIZE];
            for (int i = 0; i < _MAX_SIZE; ++i)
                Notes[i] = 0;
            Size = 0;
		}
		
		public override void OnDoubleClick( Mobile from )
		{
			if ( !IsChildOf( from.Backpack ) )
			{
				 from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			}
			else
			{
                //if (from is PlayerMobile)
                //{
                    //PlayerMobile pm = (PlayerMobile)from;
                    //if (pm.Classes.Barde)
                    //{
                        from.SendGump(new MusicGump(Notes, Size, this));
                    //}
                    //else
                    //{
                    //    pm.SendMessage("Vous devez être un barde pour utiliser ceci !");
                    //}
                //}
			}
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

            writer.Write((int)Size);

            for (int i = 0; i < _MAX_SIZE; i++)
                writer.Write((int)Notes[i]);
		}

        public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

            Size = reader.ReadInt();

            Notes = new int[_MAX_SIZE];
            for (int i = 0; i < _MAX_SIZE; i++)
                Notes[i] = reader.ReadInt();

			if ( Weight == 3.0 )
				Weight = 5.0;
		}
	}
}
