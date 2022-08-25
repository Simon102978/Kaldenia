/*using System;
using System.Collections;
using System.Collections.Generic;
using Server.Multis;
using Server.Mobiles;
using Server.Network;
using Server.ContextMenus;
using Server.Spells;
using Server.Targeting;
using Server.Misc;

namespace Server.Items
{
	public class RemoveSlayer : Item
	{
		[Constructable]
		public RemoveSlayer() : base( 0x1F14 )
		{
			Weight = 0.2;  // ?
			Name = "Slayer 1 Removal";
			Hue = 2727;
		}

		public override void OnDoubleClick( Mobile from ) 
		{
			double minSkill = 70.0;
		 
			PlayerMobile pm = from as PlayerMobile;
		
			if ( !IsChildOf( from.Backpack ) )
			{
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			}

			else if ( pm == null || from.Skills[SkillName.Inscribe].Base < 115.0 )
			{
				from.SendMessage( "You are not skilled enough to attempt this enhancement." );
			}

		        else if( from.InRange( this.GetWorldLocation(), 1 ) ) 
		        {
				double maxSkill = minSkill + 40.0;

				if ( !from.CheckSkill( SkillName.Inscribe, minSkill, maxSkill ) )
				{
					from.SendMessage( "The rune shatters, releasing the magic energy." );
					from.PlaySound( 65 );
					from.PlaySound( 0x1F8 );
					Delete();
					return;
				}
				else
				{
					from.SendMessage( "Select the item to sandblast off any slayers. This will not break your weapon." );
					from.Target = new InternalTarget( this );
				}
		        } 

		        else 
		        { 
		        	from.SendLocalizedMessage( 500446 ); // That is too far away. 
		        } 
		} 
		
		private class InternalTarget : Target 
		{
			private RemoveSlayer m_RemoveSlayer;

			public InternalTarget( RemoveSlayer runeaug ) : base( 1, false, TargetFlags.None )
			{
				m_RemoveSlayer = runeaug;
			}

		 	protected override void OnTarget( Mobile from, object targeted ) 
		 	{ 
			   int DestroyChance =  1; // Utility.Random( 11 );  // success chance. removing a stat should not break anything.

			    	if ( targeted is BaseWeapon ) 
				{ 
			       		BaseWeapon Weapon = targeted as BaseWeapon; 

					if ( !from.InRange( ((Item)targeted).GetWorldLocation(), 3 ) ) 
					{ 
			          		from.SendLocalizedMessage( 500446 ); // That is too far away. 
		       			}

					else if (( ((Item)targeted).Parent != null ) && ( ((Item)targeted).Parent is Mobile ) ) 
			       		{ 
			          		from.SendMessage( "You cannot enhance that in it's current location." ); 
		       			}
					else if( Weapon.Slayer == SlayerName.None && Weapon.Slayer2 == SlayerName.None )
					{
						from.SendMessage( "Your weapon does not have a Slayer on it." );
					}
		
					else
		       			{
					    if ( DestroyChance > 0 ) // Success
					      {
						if( Weapon.Slayer == SlayerName.None )
						{
							Weapon.Slayer2 = SlayerName.None;
							Weapon.Slayer = SlayerName.None; 
							from.SendMessage( "The Rune disolves all slayers.." );
				                  	from.PlaySound( 0x1F5 );
			        	          	m_RemoveSlayer.Delete();
			          		}
					      }
						else // Fail
						{
					  		from.SendMessage( "You have failed to enhance the weapon!" );
							from.SendMessage( "The weapon is damaged beyond repair!" );
							from.PlaySound( 42 );
						 	Weapon.Delete();
							m_RemoveSlayer.Delete();
				  		}
					}
				}
				else 
				{
		       			from.SendMessage( "You cannot enhance that." );
		    		} 
		  	}
		
		}

		public override bool DisplayLootType{ get{ return false; } }  // ha ha!

		public RemoveSlayer( Serial serial ) : base( serial )
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
		public override void AddNameProperty( ObjectPropertyList list )
		{
			base.AddNameProperty(list);
			list.Add( "Slayer Removal Rune (all slayers)" );
			list.Add( "Will not break weapon." );
		}
	}
}*/