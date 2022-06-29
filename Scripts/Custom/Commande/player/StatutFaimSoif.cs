using System;
using Server;
using Server.Misc;
using Server.Network;
using Server.Mobiles;
using Server.Commands;
using Server.Targeting;
using System.Collections;
using Server.Engines.Plants;
using Server.Engines.Quests;
using Server.Engines.Quests.Hag;
using System.Collections.Generic;
using Server.Commands.Generic;


namespace Server.Items
{
	public class FoodDecayTimer : Timer
	{
		public static void Initialize()
		{
			new FoodDecayTimer().Start();
		}

		public FoodDecayTimer() : base( TimeSpan.FromMinutes( 10 ), TimeSpan.FromMinutes( 10 ) )
		{
			Priority = TimerPriority.OneMinute;
		}

		protected override void OnTick()
		{
			FoodDecay();			
		}

		public static void FoodDecay()
		{
			foreach ( NetState state in NetState.Instances )
			{
				if ( state.Mobile != null && state.Mobile.AccessLevel == AccessLevel.Player ) // Check if player
				{
					HungerDecay( state.Mobile );
					ThirstDecay( state.Mobile );
				}
			}
		}

		public static void HungerDecay( Mobile m )
		{
			if ( m != null )
			{
				if ( m.Hunger >= 1 )
				{
					m.Hunger -= 1;
					// added to give hunger value a real meaning.
					if ( m.Hunger < 5 )
						m.SendMessage( "Vous avez extrêmement faim." );
					else if ( m.Hunger < 10 )
						m.SendMessage( "Vous avez faim." );
				}	
				else
				{
					if ( m.Hits > 5 )
						m.Hits -= 5;
					m.SendMessage( "Vous mourrez de faim!" );
				}
			}
		}

		public static void ThirstDecay( Mobile m )
		{
			if ( m != null )
			{
				if ( m.Thirst >= 1 )
				{
					m.Thirst -= 1;
				// added to give thirst value a real meaning.
					if ( m.Thirst < 5 )
						m.SendMessage( "Vous avez très soif." );
					else if ( m.Thirst < 10 )
						m.SendMessage("Vous avez soif.");
				}
				else
				{
					if ( m.Stam > 5 )
						m.Stam -= 5;
					m.SendMessage( "Vous êtes complètement d??#$?&*shydrat??#$?&*!" );
				}
			}
		}
	}
	// Create the timer that monitors the current state of hunger
	public class HitsDecayTimer : Timer
	{
		public static void Initialize()
		{
			new HitsDecayTimer().Start();
		}
		// Based on the same timespan used in RegenRates.cs
		public HitsDecayTimer() : base( TimeSpan.FromSeconds( 11 ), TimeSpan.FromSeconds( 11 ) )
		{
			Priority = TimerPriority.OneSecond;
		}
		
		protected override void OnTick()
		{
			HitsDecay();
		}
		// Check the NetState and call the decaying function
		public static void HitsDecay()
		{
			foreach ( NetState state in NetState.Instances )
			{
				HitsDecaying( state.Mobile );
			}
		}

		// Check hunger level if below the value set take away 1 hit
		public static void HitsDecaying( Mobile m )
		{
			if ( m != null && m.Hunger < 5 && m.Hits > 3 )
			{
				switch (m.Hunger)
				{
					case 4: m.Hits -= 2; break;
					case 3: m.Hits -= 2; break;
					case 2: m.Hits -= 5; break;
					case 1: m.Hits -= 5; break;
					case 0:
					{
						m.Hits -= 10;
//					m.SendMessage("Vous mourrez de faim!");  TimeSpan.FromSeconds(15) ;
						break;
					}
				}
			}
		}
	}
	// Create the timer that monitors the current state of thirst
	public class StamDecayTimer : Timer
	{
		public static void Initialize()
		{
			new StamDecayTimer().Start();
		}
		// Based on the same timespan used in RegenRates.cs
		public StamDecayTimer() : base( TimeSpan.FromSeconds( 7 ), TimeSpan.FromSeconds( 7 ) )
		{
			Priority = TimerPriority.OneSecond;
		}
		
		protected override void OnTick()
		{
			StamDecay();
		}
		// Check the NetState and call the decaying function
		public static void StamDecay()
		{
			foreach ( NetState state in NetState.Instances )
			{
				StamDecaying( state.Mobile );
			}
		}
		
		// Check thirst level if below the value set take away 1 point of stam
		public static void StamDecaying( Mobile m )
		{
			if ( m != null && m.Thirst < 5 && m.Stam > 3 )
			{
				switch (m.Thirst)
				{
					case 4: m.Stam -= 2; break;
					case 3: m.Stam -= 2; break;
					case 2: m.Stam -= 5; break;
					case 1: m.Stam -= 5; break;
					case 0:
					{
						m.Stam -= 10;
//					m.SendMessage("Vous êtes complètement d??#$?&*shydrat??#$?&*!"); TimeSpan.FromSeconds(15);
						break;
					}
				}
			}
		}
	}
	public class Statut
	{
		public static void Initialize()
		{
			CommandSystem.Register("Statut", AccessLevel.Player, new CommandEventHandler(Statut_OnCommand));
		}

		[Usage("Statut")]
		[Description("Affiche votre niveau de nutrition et d'hydratation.")]
		public static void Statut_OnCommand(CommandEventArgs e)

	

	{
			int h = e.Mobile.Hunger; // Variable to hold the hunger value of the player
			// these values are taken from Food.cs and relate directly to the message
			// you get when you eat.
			if (h <= 0)
				e.Mobile.SendMessage( "Vous avez extrêmement faim." );
			else if ( h <= 5 )
			       	e.Mobile.SendMessage( "Vous avez très faim." );
			else if ( h <= 10)
				e.Mobile.SendMessage( "Vous avez faim." );
			else if ( h <= 15 )
				e.Mobile.SendMessage( "Vous avez l??#$?&*gèrement faim." );
			else if ( h <= 20)
				e.Mobile.SendMessage( "Vous n'avez pas faim." );
			else
				e.Mobile.SendMessage("Vous n'avez pas faim.");

			int t = e.Mobile.Thirst; // Variable to hold the thirst value of the player
			// read the comments above to see where these values came from
			if ( t <= 0 )
				e.Mobile.SendMessage( "Vous avez extrêmement soif." );
			else if ( t <= 5 )
			       	e.Mobile.SendMessage( "Vous avez très soif." );
			else if ( t <= 10 )
				e.Mobile.SendMessage( "Vous avez soif." );
			else if ( t <= 15 )
				e.Mobile.SendMessage( "Vous avez l??#$?&*gèrement soif." );
			else if ( t <= 20 )
				e.Mobile.SendMessage( "Vous n'avez pas soif." );
			else
				e.Mobile.SendMessage("Vous n'avez pas soif.");
		}
	}
}


