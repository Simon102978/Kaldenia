using System;
using Server.Network;
using System.Collections;
using System.Collections.Generic;
using Server.Mobiles;
using Server.Items;
using Server.ContextMenus;

namespace Server.Mobiles
{
	[CorpseName( "a horse corpse" )]
    public class PackHorseExp : BaseCreature
	{
		[Constructable]
		public PackHorseExp() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a pack horse";
			Body = 291;
			BaseSoundID = 0xA8;

			SetStr( 44, 120 );
			SetDex( 36, 55 );
			SetInt( 6, 10 );

			SetHits( 61, 80 );
			SetStam( 81, 100 );
			SetMana( 0 );

			SetDamage( 5, 11 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 20, 25 );
			SetResistance( ResistanceType.Fire, 10, 15 );
			SetResistance( ResistanceType.Cold, 20, 25 );
			SetResistance( ResistanceType.Poison, 10, 15 );
			SetResistance( ResistanceType.Energy, 10, 15 );

			SetSkill( SkillName.MagicResist, 25.1, 30.0 );
			SetSkill( SkillName.Tactics, 29.3, 44.0 );
			SetSkill( SkillName.Wrestling, 29.3, 44.0 );

			Fame = 0;
			Karma = 200;

			VirtualArmor = 16;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 11.1;

			Container pack = Backpack;

			if ( pack != null )
				pack.Delete();

			pack = new StrongBackpack();
			pack.Movable = false;

			AddItem( pack );
		}

		public override int Meat{ get{ return 3; } }
		public override int Hides{ get{ return 10; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

		public PackHorseExp( Serial serial ) : base( serial )
		{
		}

		public override void OnThink() 
		{ 
			base.OnThink();
//wild animal start
			if ((this.ControlMaster == null) && (this.SummonMaster == null))
			{
				WildHorse wh = new WildHorse();
				wh.Location = this.Location;
				wh.Map = this.Map;
				Backpack bag = new Backpack();
				Container pack = this.Backpack;
				ArrayList bagitems = new ArrayList( pack.Items );
				foreach (Item item in bagitems)
				{
					bag.DropItem(item);
				}
				bag.MoveToWorld(this.Location, this.Map);
				wh.MoveToWorld(this.Location, this.Map);
				PublicOverheadMessage(MessageType.Regular, 0x3B2, false, "* The Horse shakes off its pack! *");
				this.Delete();
			}
//wild animal end
		}
			
			
		#region Pack Animal Methods
		public override bool OnBeforeDeath()
		{
			if ( !base.OnBeforeDeath() )
				return false;

            PackAnimalExp.CombineBackpacks( this );

			return true;
		}

		public override DeathMoveResult GetInventoryMoveResultFor( Item item )
		{
			return DeathMoveResult.MoveToCorpse;
		}

		public override bool IsSnoop( Mobile from )
		{
			if (PackAnimalExp.CheckAccess( this, from ) )
				return false;

			return base.IsSnoop( from );
		}

		public override bool OnDragDrop( Mobile from, Item item )
		{
			if ( CheckFeed( from, item ) )
				return true;

			if (PackAnimalExp.CheckAccess( this, from ) )
			{
				AddToBackpack( item );
				return true;
			}

			return base.OnDragDrop( from, item );
		}

		public override bool CheckNonlocalDrop( Mobile from, Item item, Item target )
		{
			return PackAnimalExp.CheckAccess( this, from );
		}

		public override bool CheckNonlocalLift( Mobile from, Item item )
		{
			return PackAnimalExp.CheckAccess( this, from );
		}

		public override void OnDoubleClick( Mobile from )
		{
            PackAnimalExp.TryPackOpen( this, from );
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );

            PackAnimalExp.GetContextMenuEntries( this, from, list );
		}
		#endregion

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}

	public class PackAnimalBackpackEntryExp : ContextMenuEntry
	{
		private BaseCreature m_Animal;
		private Mobile m_From;

		public PackAnimalBackpackEntryExp( BaseCreature animal, Mobile from ) : base( 6145, 3 )
		{
			m_Animal = animal;
			m_From = from;

			if ( animal.IsDeadPet )
				Enabled = false;
		}

		public override void OnClick()
		{
            PackAnimalExp.TryPackOpen( m_Animal, m_From );
		}
	}

	public class PackAnimalExp
	{
		public static void GetContextMenuEntries( BaseCreature animal, Mobile from, List<ContextMenuEntry> list )
		{
			if ( CheckAccess( animal, from ) )
				list.Add( new PackAnimalBackpackEntryExp( animal, from ) );
		}

		public static bool CheckAccess( BaseCreature animal, Mobile from )
		{
			if ( from == animal || from.AccessLevel >= AccessLevel.GameMaster )
				return true;

			if ( from.Alive && animal.Controlled && !animal.IsDeadPet && (from == animal.ControlMaster || from == animal.SummonMaster) )
				return true;

			return false;
		}

		public static void CombineBackpacks( BaseCreature animal )
		{
			if ( Core.AOS )
				return;

			//if ( animal.IsBonded || animal.IsDeadPet )
			//	return;

			Container pack = animal.Backpack;

			if ( pack != null )
			{
				Container newPack = new Backpack();

				for ( int i = pack.Items.Count - 1; i >= 0; --i )
				{
					if ( i >= pack.Items.Count )
						continue;

					newPack.DropItem( pack.Items[i] );
				}

				pack.DropItem( newPack );
			}
		}

		public static void TryPackOpen( BaseCreature animal, Mobile from )
		{
			if ( animal.IsDeadPet )
				return;

			Container item = animal.Backpack;

			if ( item != null )
				from.Use( item );
		}
	}
}
