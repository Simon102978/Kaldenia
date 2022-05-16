using System;
using Server.Network;
using System.Collections;
using System.Collections.Generic;
using Server.Mobiles;
using Server.Items;
using Server.ContextMenus;

namespace Server.Mobiles
{
	[CorpseName("a llama corpse")]
	public class PackLlamaExp : BaseCreature
	{
		[Constructable]
		public PackLlamaExp() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a pack llama";
			Body = 292;
			BaseSoundID = 0x3F3;

			SetStr( 52, 80 );
			SetDex( 36, 55 );
			SetInt( 16, 30 );

			SetHits( 50 );
			SetStam( 86, 105 );
			SetMana( 0 );

			SetDamage( 2, 6 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 25, 35 );
			SetResistance( ResistanceType.Fire, 10, 15 );
			SetResistance( ResistanceType.Cold, 10, 15 );
			SetResistance( ResistanceType.Poison, 10, 15 );
			SetResistance( ResistanceType.Energy, 10, 15 );

			SetSkill( SkillName.MagicResist, 15.1, 20.0 );
			SetSkill( SkillName.Tactics, 19.2, 29.0 );
			SetSkill( SkillName.Wrestling, 19.2, 29.0 );

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

		public override int Meat{ get{ return 1; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

		public PackLlamaExp( Serial serial ) : base( serial )
		{
		}

		public override void OnThink() 
		{ 
			base.OnThink();
//wild animal start
			if ((this.ControlMaster == null) && (this.SummonMaster == null))
			{
				Llama wl = new Llama();
				wl.Location = this.Location;
				wl.Map = this.Map;
				Backpack bag = new Backpack();
				Container pack = this.Backpack;
				ArrayList bagitems = new ArrayList( pack.Items );
				foreach (Item item in bagitems)
				{
					bag.DropItem(item);
				}
				bag.MoveToWorld(this.Location, this.Map);
				wl.MoveToWorld(this.Location, this.Map);
				PublicOverheadMessage(MessageType.Regular, 0x3B2, false, "* The Llama shakes off its pack! *");
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
}
