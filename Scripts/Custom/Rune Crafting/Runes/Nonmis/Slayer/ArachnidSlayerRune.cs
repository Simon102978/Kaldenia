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
	public class ArachnidSlayer : Item
	{
		[Constructable]
		public ArachnidSlayer() : base( 0x1F14 )
		{
			Weight = 0.2;  // ?
			Name = "Arachnid Slayer";
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
					from.SendMessage( "Select the item to enhance." );
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
			private ArachnidSlayer m_ArachnidSlayer;

			public InternalTarget( ArachnidSlayer runeaug ) : base( 1, false, TargetFlags.None )
			{
				m_ArachnidSlayer = runeaug;
			}


		 	protected override void OnTarget( Mobile from, object targeted ) 
		 	{ 
			     int DestroyChance = Utility.Random( 11 );  // success chance.

			     if ( targeted is BaseWeapon ) 
				{ 
			       		BaseWeapon Weapon = targeted as BaseWeapon; 

					if ( !from.InRange( ((Item)targeted).GetWorldLocation(), 1 ) ) 
					{ 
			          		from.SendLocalizedMessage( 500446 ); // That is too far away. 
		       			}

					else if (( ((Item)targeted).Parent != null ) && ( ((Item)targeted).Parent is Mobile ) ) 
			       		{ 
			          		from.SendMessage( "You cannot enhance that in it's current location." ); 
		       			}
					else if( Weapon.Slayer != SlayerName.None && Weapon.Slayer2 != SlayerName.None )
					{
						from.SendMessage( "Your weapon already has two slayers! One must be removed first." );
					}
					else if ( Weapon.Slayer == SlayerName.ArachnidDoom || Weapon.Slayer2 == SlayerName.ArachnidDoom )
					{
						from.SendMessage( "That already has This Slayer Type!");
					}
						
					else
		       			{
					    if ( DestroyChance > 0 ) // Success
					      {
						if( Weapon.Slayer == SlayerName.None )
						{
							Weapon.Slayer = SlayerName.ArachnidDoom; from.SendMessage( "The Rune enhances your weapon." );
				                  	from.PlaySound( 0x1F5 );
			        	          	m_ArachnidSlayer.Delete();
			          		}
						else if( Weapon.Slayer2 == SlayerName.None )
						{
							Weapon.Slayer2 = SlayerName.ArachnidDoom; from.SendMessage( "The Rune enhances your weapon." );
				                  	from.PlaySound( 0x1F5 );
			        	          	m_ArachnidSlayer.Delete();
			          		}
					      }
						else // Fail
						{
					  		from.SendMessage( "You have failed to enhance the weapon!" );
							from.SendMessage( "The weapon is damaged beyond repair!" );
							from.PlaySound( 42 );
						  	Weapon.Delete();
							m_ArachnidSlayer.Delete();
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

		public ArachnidSlayer( Serial serial ) : base( serial )
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
			list.Add( "Super Slayer Rune" );
		}
	}
}*/