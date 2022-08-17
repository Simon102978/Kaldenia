using System;
using System.Text;
using Server.Gumps;
using Server.Network;


namespace Server.Items
{
	public class TatouDye : Item
	{
		[Constructable]
		public TatouDye(): base(0xEFF)
        {
			Weight = 1.0;
			Hue = 2406;
			Name = "Tatou Dye";
        }

		public TatouDye( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( from.InRange( this.GetWorldLocation(), 1 ) )
			{
				from.CloseGump( typeof( TatouDyeGump ) );
				from.SendGump( new TatouDyeGump( this ) );
			}
			else
			{
				from.LocalOverheadMessage( MessageType.Regular, 906, 1019045 ); // I can't reach that.
			}	
		}
	}

	public class TatouDyeGump : Gump
	{
		private TatouDye m_TatouDye;

		private class TatouDyeEntry
		{
			private string m_Name;
			private int m_HueStart;
			private int m_HueCount;

			public string Name
			{
				get
				{
					return m_Name;
				}
			}
			public int HueStart
			{
				get
				{
					return m_HueStart;
				}
			}

			public int HueCount
			{
				get
				{
					return m_HueCount;
				}
			}

			public TatouDyeEntry( string name, int hueStart, int hueCount )
			{
				m_Name = name;
				m_HueStart = hueStart;
				m_HueCount = hueCount;
			}
		}

		private static TatouDyeEntry[] m_Entries = new TatouDyeEntry[]
			{
				new TatouDyeEntry( "Beige", 1110, 1 ),
				new TatouDyeEntry( "Blanc", 2063, 2 ),
				new TatouDyeEntry( "Bleu", 1302, 3 ),
				new TatouDyeEntry( "Jaune", 2213, 1 ),
				new TatouDyeEntry( "Mauve", 17, 1 ),
				new TatouDyeEntry( "Noir", 1102, 1 ),
				new TatouDyeEntry( "Orange", 1118, 3 ),
				new TatouDyeEntry( "Rose", 36, 1 ),			
				new TatouDyeEntry( "Rouge", 33, 1 ),		
				new TatouDyeEntry( "Vert", 169, 2 )
			};

		public TatouDyeGump( TatouDye dye) : base( 50, 50 )
		{
			m_TatouDye = dye;

			AddPage( 0 );

			AddBackground( 100, 10, 350, 355, 2600 );
			AddBackground( 120, 54, 110, 270, 5100 );

			AddLabel(195, 25, 2101, "COULEUR DE TATOUAGE :");

			AddButton( 145, 328, 4005, 4007, 1, GumpButtonType.Reply, 0 );
			AddLabel(175, 329, 2101, "Peindre mon tatouage de cette couleur");

			for ( int i = 0; i < m_Entries.Length; ++i )
			{
				AddLabel( 130, 59 + (i * 22), m_Entries[i].HueStart - 1, m_Entries[i].Name );
				AddButton( 207, 60 + (i * 22), 5224, 5224, 0, GumpButtonType.Page, i + 1 );
			}

			for ( int i = 0; i < m_Entries.Length; ++i )
			{
				TatouDyeEntry e = m_Entries[i];

				AddPage( i + 1 );
				
				for ( int j = 0; j < e.HueCount; ++j )
				{
					AddLabel( 285 + ((j / 16) * 80), 52 + ((j % 16) * 17), e.HueStart + j - 1, "*****" );
					AddRadio( 260 + ((j / 16) * 80), 52 + ((j % 16) * 17), 210, 211, false, (i * 100) + j );
				}
			}
		}

		public override void OnResponse( NetState from, RelayInfo info )
		{
			if ( m_TatouDye.Deleted )
				return;

			Mobile m = from.Mobile;
			int[] switches = info.Switches;

			if ( !m_TatouDye.IsChildOf( m.Backpack ) ) 
			{
				m.SendLocalizedMessage( 1042010 ); //You must have the object in your backpack to use it.
				return;
			}

			if ( info.ButtonID != 0 && switches.Length > 0 )
			{
				Item tatou = m.FindItemOnLayer(Layer.InnerTorso);

				if ( tatou == null )
				{
					m.SendMessage("Vous n'avez pas de tatouage a teindre"); 
				}
				else
				{
					// To prevent this from being exploited, the hue is abstracted into an internal list

					int entryIndex = switches[0] / 100;
					int hueOffset = switches[0] % 100;
					

					if ( entryIndex >= 0 && entryIndex < m_Entries.Length )
					{
						TatouDyeEntry e = m_Entries[entryIndex];

						if ( hueOffset >= 0 && hueOffset < e.HueCount )
						{
							if (e.Name == "Beige")
							{
								int hue = 2169;

								if ( tatou != null )
									tatou.Hue = hue;

								m.SendMessage("Vous colorez votre tatouage"); 
								m_TatouDye.Delete();
								m.PlaySound( 0x4E );
							}
							if (e.Name == "Blanc")
							{
								if (hueOffset == 0)
								{
									int hue = 2063;

									if ( tatou != null )
										tatou.Hue = hue;

									m.SendMessage("Vous colorez votre tatouage"); 
									m_TatouDye.Delete();
									m.PlaySound( 0x4E );
								}
								else if (hueOffset == 1)
								{
									int hue = 2054;

									if ( tatou != null )
										tatou.Hue = hue;

									m.SendMessage("Vous colorez votre tatouage"); 
									m_TatouDye.Delete();
									m.PlaySound( 0x4E );
								}
							}
							if (e.Name == "Bleu")
							{
								if (hueOffset == 0)
								{
									int hue = 2178;

									if ( tatou != null )
										tatou.Hue = hue;

									m.SendMessage("Vous colorez votre tatouage"); 
									m_TatouDye.Delete();
									m.PlaySound( 0x4E );
								}
								else if (hueOffset == 1)
								{
									int hue = 2174;

									if ( tatou != null )
										tatou.Hue = hue;

									m.SendMessage("Vous colorez votre tatouage"); 
									m_TatouDye.Delete();
									m.PlaySound( 0x4E );
								}
								else if (hueOffset == 2)
								{
									int hue = 2265;

									if ( tatou != null )
										tatou.Hue = hue;

									m.SendMessage("Vous colorez votre tatouage"); 
									m_TatouDye.Delete();
									m.PlaySound( 0x4E );
								}
							}
							if (e.Name == "Jaune")
							{
								int hue = 2147;

								if ( tatou != null )
									tatou.Hue = hue;

								m.SendMessage("Vous colorez votre tatouage"); 
								m_TatouDye.Delete();
								m.PlaySound( 0x4E );
							}
							if (e.Name == "Mauve")
							{
								int hue = 2177;

								if ( tatou != null )
									tatou.Hue = hue;

								m.SendMessage("Vous colorez votre tatouage"); 
								m_TatouDye.Delete();
								m.PlaySound( 0x4E );
							}
							if (e.Name == "Noir")
							{
								int hue = 2051;

								if ( tatou != null )
									tatou.Hue = hue;

								m.SendMessage("Vous colorez votre tatouage"); 
								m_TatouDye.Delete();
								m.PlaySound( 0x4E );
							}
							if (e.Name == "Orange")
							{
								if (hueOffset == 0)
								{
									int hue = 2161;

									if ( tatou != null )
										tatou.Hue = hue;

									m.SendMessage("Vous colorez votre tatouage"); 
									m_TatouDye.Delete();
									m.PlaySound( 0x4E );
								}
								else if (hueOffset == 1)
								{
									int hue = 2032;

									if ( tatou != null )
										tatou.Hue = hue;

									m.SendMessage("Vous colorez votre tatouage"); 
									m_TatouDye.Delete();
									m.PlaySound( 0x4E );
								}
								else if (hueOffset == 2)
								{
									int hue = 2152;

									if ( tatou != null )
										tatou.Hue = hue;

									m.SendMessage("Vous colorez votre tatouage"); 
									m_TatouDye.Delete();
									m.PlaySound( 0x4E );
								}
							}
							if (e.Name == "Rose")
							{
								int hue = 2075;

								if ( tatou != null )
									tatou.Hue = hue;

								m.SendMessage("Vous colorez votre tatouage"); 
								m_TatouDye.Delete();
								m.PlaySound( 0x4E );
							}
							if (e.Name == "Rouge")
							{
								int hue = 2068;

								if ( tatou != null )
									tatou.Hue = hue;

								m.SendMessage("Vous colorez votre tatouage"); 
								m_TatouDye.Delete();
								m.PlaySound( 0x4E );
							}
							if (e.Name == "Vert")
							{
								if (hueOffset == 0)
								{
									int hue = 2264;

									if ( tatou != null )
										tatou.Hue = hue;

									m.SendMessage("Vous colorez votre tatouage"); 
									m_TatouDye.Delete();
									m.PlaySound( 0x4E );
								}
								else if (hueOffset == 1)
								{
									int hue = 2179;

									if ( tatou != null )
										tatou.Hue = hue;

									m.SendMessage("Vous colorez votre tatouage"); 
									m_TatouDye.Delete();
									m.PlaySound( 0x4E );
								}
							}
						}
					}
				}
			}
			else
			{
				m.SendMessage("Vous decidez de ne pas teindre votre tatouage"); 
			}
		}
	}
}