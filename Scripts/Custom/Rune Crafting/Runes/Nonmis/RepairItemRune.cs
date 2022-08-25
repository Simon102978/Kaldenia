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
	public class RepairItem : Item
	{
		[Constructable]
		public RepairItem() : base( 0x1F14 )
		{
			Weight = 0.2;  // ?
			Name = "Item Repair Rune";
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
			private RepairItem m_RepairItem;

			public InternalTarget( RepairItem runeaug ) : base( 1, false, TargetFlags.None )
			{
				m_RepairItem = runeaug;
			}

		 	protected override void OnTarget( Mobile from, object targeted ) 
		 	{ 
			     int DestroyChance = 1; // Utility.Random( 9 );  // success chance.  no fails to apply.

				if ( targeted is IDurability && targeted is Item  )
				{
					IDurability wearable = (IDurability) targeted;
					Item item = (Item) targeted;

					if ( !from.InRange( ((Item)targeted).GetWorldLocation(), 3 ) ) 
					{ 
			          		from.SendLocalizedMessage( 500446 ); // That is too far away. 
		       			}

					else if (( ((Item)targeted).Parent != null ) && ( ((Item)targeted).Parent is Mobile ) ) 
			       		{ 
			          		from.SendMessage( "You cannot enhance that in it's current location." ); 
		       			}
						
					else
		       			{
					   if ( DestroyChance > 0 ) // Success
						if( wearable.HitPoints < wearable.MaxHitPoints )
						{
							wearable.HitPoints = wearable.MaxHitPoints; from.SendMessage( "The Rune's Magic fully repaired the item." );
				                  	from.PlaySound( 0x1F5 );
			        	          	m_RepairItem.Delete();
			          		}
						else // Fail
						{
					  		from.SendMessage( "You have failed to enhance the item, and the rune crumbles!" );
							from.PlaySound( 42 );
						  	//item.Delete();
							m_RepairItem.Delete();
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

		public RepairItem( Serial serial ) : base( serial )
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
			list.Add( "Will Not Break Item" );
		}
	}
}*/