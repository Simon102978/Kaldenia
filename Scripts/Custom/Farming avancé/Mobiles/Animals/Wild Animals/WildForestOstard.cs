using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "an ostard corpse" )]
	public class WildForestOstard : BaseAnimal
	{
		[Constructable]
		public WildForestOstard( ) : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Hue = Utility.RandomSlimeHue() | 0x8000;
			Name = "a forest ostard";
			Body = 0xDB;

			BaseSoundID = 0x270;

			SetStr( 94, 170 );
			SetDex( 56, 75 );
			SetInt( 6, 10 );

			SetHits( 71, 88 );
			SetMana( 0 );

			SetDamage( 8, 14 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 15, 20 );

			SetSkill( SkillName.MagicResist, 27.1, 32.0 );
			SetSkill( SkillName.Tactics, 29.3, 44.0 );
			SetSkill( SkillName.Wrestling, 29.3, 44.0 );

			Fame = 450;
			Karma = 0;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 29.1;
		}

		public override bool CanBeParagon => false;

		public override int Meat{ get{ return 3; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Ostard; } }

		public WildForestOstard( Serial serial ) : base( serial )
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
	}
}