using System;
using Server.Items;
using Server.Mobiles;
using Server.Engines.CannedEvil;

namespace Server.Engines.Craft
{
	public class DefRuneCrafting : CraftSystem
	{
		public override SkillName MainSkill
		{
			get{ return SkillName.Inscribe; }
		}


		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefRuneCrafting();

				return m_CraftSystem;
			}
		}

		public override double GetChanceAtMin( CraftItem item )
		{
			return 0.0; // 0%
		}

		private DefRuneCrafting() : base( 1, 1, 1.25 )// base( 1, 2, 1.7 )
		{
		}



		public override void PlayCraftEffect( Mobile from )
		{
			from.PlaySound( 0x1F5 ); // magic

			//if ( from.Body.Type == BodyType.Human && !from.Mounted )
			//	from.Animate( 9, 5, 1, true, false, 0 );

			//new InternalTimer( from ).Start();
		}

		// Delay to synchronize the sound with the hit on the anvil
		private class InternalTimer : Timer
		{
			private Mobile m_From;

			public InternalTimer( Mobile from ) : base( TimeSpan.FromSeconds( 0.7 ) )
			{
				m_From = from;
			}

			protected override void OnTick()
			{
				m_From.PlaySound( 0x2A );
			}
		}

		public override int PlayEndingEffect( Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, bool makersMark, CraftItem item )
		{
			if ( toolBroken )
				from.SendLocalizedMessage( 1044038 ); // You have worn out your tool

			if ( failed )
			{
				from.PlaySound( 65 ); // rune breaking
				if ( lostMaterial )
					return 1044043; // You failed to create the item, and some of your materials are lost.
				else
					return 1044157; // You failed to create the item, but no materials were lost.
			}
			else
			{
				//from.PlaySound( 65 ); // rune breaking
				//if ( quality == 0 )
					//return 502785; // You were barely able to make this item.  It's quality is below average.
				//else if ( makersMark && quality == 2 )
					//return 1044156; // You create an exceptional quality item and affix your maker's mark.
				//else if ( quality == 2 )
					//return 1044155; // You create an exceptional quality item.
				//else				
					return 1044154; // You create the item.
			}
		}

		public override void InitCraftList()
		{
			int index = AddCraft( typeof( BlankRune ), 1044050, "blank rune", 45.0, 80.0, typeof( RoughStone ), "Rough Stone", 1, "A rough stone is needed to make that." );
/*
			int index = AddCraft( typeof( LowerManaCostRune ), "Casting", "Lower Mana Cost", 75.5, 115.0, typeof( DaemonBlood ), "Daemon Blood", 5, "You do not have enough daemon blood to make that." );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
			index = AddCraft( typeof( LowerRegCostRune ), "Casting", "Lower Reagent Cost", 85.5, 120.0, typeof( DaemonBlood ), "Daemon Blood", 7, "You do not have enough daemon blood to make that." );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
			index = AddCraft( typeof( CastSpeedRune ), "Casting", "Faster Casting", 75.5, 115.0, typeof( MandrakeRoot ), "Mandrake Root", 5, 1044365 );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
			index = AddCraft( typeof( CastRecoverRune ), "Casting", "Faster Cast Recovery", 70.5, 105.0, typeof( BlackPearl ), "Black Pearl", 5, 1044361 );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );*/
			index = AddCraft( typeof( SpellChannelRune ), "Casting", "Canalisation Magique", 75.0, 120.0, typeof( SpidersSilk ), "Spiders Silk", 5, 1044368 );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
	//		index = AddCraft( typeof( SpellDamageRune ), "Casting", "Spell Dmg Inc", 85.5, 120.0, typeof( GraveDust ), "Grave Dust", 7, "You do not have enough grave dust to make that." );
	//			AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );


			index = AddCraft( typeof( AttackChanceRune ), "Misc", "Chance de touche", 75.5, 115.0, typeof( Bloodmoss ), "Bloodmoss", 5, 1044362 );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
			index = AddCraft( typeof( DefenceChanceRune ), "Misc", "Defense", 70.5, 100.0, typeof( SulfurousAsh ), "Sulfurous Ash", 5, 1044367 );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
/*			index = AddCraft( typeof( EnhancePotsRune ), "Misc", "Enhance Potions", 50.0, 80.5, typeof( BlackPearl ), "Black Pearl", 3, 1044361 );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
			index = AddCraft( typeof( LuckRune ), "Misc", "Luck", 50.5, 90.0, typeof( Garlic), "Garlic", 3, "You do not have enough Garlic to make that" );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
			index = AddCraft( typeof( NightSightRune ), "Misc", "Night Sight", 50.5, 90.0, typeof( SpidersSilk ), "Spiders Silk", 3, 1044368 );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
			index = AddCraft( typeof( MageArmorRune ), "Misc", "Mage Armor/wep", 60.0, 95.0, typeof( Garlic ), "Garlic", 3, "You do not have enough Garlic to make that." );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );*/
			index = AddCraft( typeof( SelfRepairRune ), "Misc", "Auto-Réparation", 65.5, 95.0, typeof( SpidersSilk ), "Spiders Silk", 3, 1044368 );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
/*			index = AddCraft( typeof( DurabilityBonusRune ), "Misc", "Fortifying rune / Durability Inc", 97.5, 100.0, typeof( ValoriteIngot ), "Valorite Ingots", 100, "You do not have enough Valorite Ingots to make that." );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 5, "You do not have any Rough Stones to make that."  );
			index = AddCraft( typeof( RepairItem ), "Misc", "Item Repair Rune Wont Break Item", 97.5, 100.0, typeof( ValoriteIngot ), "Valorite Ingots", 50, "You do not have enough Valorite Ingots to make that." );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 10, "You do not have any Rough Stones to make that."  );
				AddRes( index, typeof ( Lockpick ), "lockpick", 40, "You do not have enough Lock Picks to make that."  );


			index = AddCraft( typeof( ReflectPhysRune ), "Resistances / Reflect", "Reflect Physical Damage", 70.5, 105.0, typeof( PigIron ), "Pig Iron", 5, "You do not have enough pig iron to make that." );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );*/
			index = AddCraft( typeof( ResistColdRune ), "Resistances / Reflect", "Resistance au froid", 70.5, 100.0, typeof( BlackPearl ), "Black Pearl", 5, 1044361 );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
			index = AddCraft( typeof( ResistEnergyRune ), "Resistances / Reflect", "Resistance à l'énergie", 70.5, 100.0, typeof( BlackPearl ), "Black Pearl", 5, 1044361 );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
			index = AddCraft( typeof( ResistFireRune ), "Resistances / Reflect", "Resistance au feu", 70.5, 100.0, typeof( SulfurousAsh ), "Sulfurous Ash", 5, 1044367 );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
			index = AddCraft( typeof( ResistPhysRune ), "Resistances / Reflect", "Resistance physique", 70.5, 100.0, typeof( Garlic ), "Garlic", 5, "A blank rune is needed to make that." );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
			index = AddCraft( typeof( ResistPoisRune ), "Resistances / Reflect", "Resistance au poison", 70.5, 100.0, typeof( NoxCrystal ), "Nox Crystal", 5, "You do not have enough nox crystal to make that." );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );


			index = AddCraft( typeof( BonusDexRune ), "Stats/Regens", "Dexterité", 85.5, 120.0, typeof( BatWing ), "Bat Wing", 7, "You do not have enough bat wing to make that." );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
			index = AddCraft( typeof( BonusIntRune ), "Stats/Regens", "Intelligence", 80.5, 120.0, typeof( Ginseng ), "Ginseng", 7, 1044364 );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
			index = AddCraft( typeof( BonusStrRune ), "Stats/Regens", "Force", 80.5, 120.0, typeof( MandrakeRoot ), "Mandrake Root", 7, 1044365 );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
			index = AddCraft( typeof( BonusHitRune ), "Stats/Regens", "Vie", 85.5, 120.0, typeof( Ginseng ), "Ginseng", 7, 1044364 );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
			index = AddCraft( typeof( BonusManaRune ), "Stats/Regens", "Mana", 80.5, 120.0, typeof( DaemonBlood ), "Daemon Blood", 7, "You do not have enough daemon blood to make that." );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
			index = AddCraft( typeof( BonusStamRune ), "Stats/Regens", "Stamina", 80.5, 110.0, typeof( MandrakeRoot ), "Mandrake Root", 7, 1044365 );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
			index = AddCraft( typeof( RegenHitsRune ), "Stats/Regens", "Regeneration de vie", 80.5, 115.0, typeof( Ginseng ), "Ginseng", 7, 1044364 );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
			index = AddCraft( typeof( RegenManaRune ), "Stats/Regens", "Regeneration de mana", 75.5, 115.0, typeof( GraveDust ), "Grave Dust", 5, "You do not have enough grave dust to make that." );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
			index = AddCraft( typeof( RegenStamRune ), "Stats/Regens", "Regeneration de stamina", 70.5, 99.5, typeof( Bloodmoss ), "Bloodmoss", 5, 1044362 );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );


	/*		index = AddCraft( typeof( ArachnidSlayer ), "Slayers", "Arachnid Slayer", 120, 120.5, typeof( ChampionSkull ), "Champion Skull's", 25, "You do not have enough Champion Skull's to Craft this." );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
				AddRes( index, typeof ( GreenThorns ), "Green Thorn", 10, "You do not have Enough Green Thorns."  );
				AddRes( index, typeof ( OrangePetals ), "Orange Petals", 10, "You do not have enough Orange Petals to make that."  );
			index = AddCraft( typeof( DemonSlayer ), "Slayers", "Demon Slayer", 120, 120.5, typeof( ChampionSkull ), "Champion Skull's", 25, "You do not have enough Champion Skull's to Craft this." );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
				AddRes( index, typeof ( GreenThorns ), "Green Thorn", 10, "You do not have Enough Green Thorns."  );
				AddRes( index, typeof ( OrangePetals ), "Orange Petals", 10, "You do not have enough Orange Petals to make that."  );
			index = AddCraft( typeof( ElementalSlayer ), "Slayers", "Elemental Slayer", 120, 120.5, typeof( ChampionSkull ), "Champion Skull's", 25, "You do not have enough Champion Skull's to Craft this." );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
				AddRes( index, typeof ( GreenThorns ), "Green Thorn", 10, "You do not have Enough Green Thorns."  );
				AddRes( index, typeof ( OrangePetals ), "Orange Petals", 10, "You do not have enough Orange Petals to make that."  );
			index = AddCraft( typeof( FeySlayer ), "Slayers", "Fey Slayer", 120, 120, typeof( ChampionSkull ), "Champion Skull's", 25, "You do not have enough Champion Skull's to Craft this." );
				AddRes( index, typeof ( RoughStone ), "RoughStone", 1, "You do not have any Rough Stones to make that."  );
				AddRes( index, typeof ( GreenThorns ), "Green Thorn", 10, "You do not have Enough Green Thorns."  );
				AddRes( index, typeof ( OrangePetals ), "Orange Petals", 10, "You do not have enough Orange Petals to make that."  );
			index = AddCraft( typeof( RepondSlayer ), "Slayers", "Repond Slayer", 120, 120.5, typeof( ChampionSkull ), "Champion Skull's", 25, "You do not have enough Champion Skull's to Craft this." );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
				AddRes( index, typeof ( GreenThorns ), "Green Thorn", 10, "You do not have Enough Green Thorns."  );
				AddRes( index, typeof ( OrangePetals ), "Orange Petals", 10, "You do not have enough Orange Petals to make that."  );
			index = AddCraft( typeof( ReptileSlayer ), "Slayers", "Reptile Slayer", 120, 120.5, typeof( ChampionSkull ), "Champion Skull's", 25, "You do not have enough Champion Skull's to Craft this." );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
				AddRes( index, typeof ( GreenThorns ), "Green Thorn", 10, "You do not have Enough Green Thorns."  );
				AddRes( index, typeof ( OrangePetals ), "Orange Petals", 10, "You do not have enough Orange Petals to make that."  );
			index = AddCraft( typeof( UndeadSlayer ), "Slayers", "Undead Slayer", 120, 120.5, typeof( ChampionSkull ), "Champion Skull's", 25, "You do not have enough Champion Skull's to Craft this." );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
				AddRes( index, typeof ( GreenThorns ), "Green Thorn", 10, "You do not have Enough Green Thorns."  );
				AddRes( index, typeof ( OrangePetals ), "Orange Petals", 10, "You do not have enough Orange Petals to make that."  );
			index = AddCraft( typeof( RemoveSlayer ), "Slayers", "Slayer Removal *all* wont break item", 120, 120.5, typeof( ChampionSkull ), "Champion Skull's", 5, "You do not have enough Champion Skull's to Craft this." );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
				AddRes( index, typeof ( OilCloth ), "Oil Cloth", 30, "You do not have Enough Oil Cloths."  );
				AddRes( index, typeof ( Sand ), "Sand", 10, "You do not have enough Sand to make that."  );
*/
/*
			index = AddCraft( typeof( HitColdAreaRune ), "Weapons Area", "Cold Area", 70.5, 105.0, typeof( BlackPearl ), "Black Pearl", 5, 1044361 );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
			index = AddCraft( typeof( HitEnergyAreaRune ), "Weapons Area", "Energy Area", 70.5, 100.0, typeof( PigIron ), "Pig Iron", 5, "You do not have enough pig iron to make that." );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
			index = AddCraft( typeof( HitFireAreaRune ), "Weapons Area", "Fire Area", 70.5, 100.0, typeof( SulfurousAsh ), "Sulfurous Ash", 5, 1044367 );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
			index = AddCraft( typeof( HitPhysAreaRune ), "Weapons Area", "Physical Area", 70.5, 100.0, typeof( SpidersSilk ), "Spiders Silk", 5, 1044368 );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
			index = AddCraft( typeof( HitPoisonAreaRune ), "Weapons Area", "Poison Area", 70.5, 100.0, typeof( NoxCrystal ), "Nox Crystal", 5, "You do not have enough nox crystal to make that." );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );

			index = AddCraft( typeof( HitDispelRune ), "Weapons Hit", "Hit Dispel", 60.5, 100.0, typeof( BatWing ), "Bat Wing", 3, "You do not have enough bat wing to make that." );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
			index = AddCraft( typeof( HitLowerAttackRune ), "Weapons Hit", "Hit Lower Attack", 75.5, 102.0, typeof( DaemonBlood ), "Daemon Blood", 5, "You do not have enough daemon blood to make that." );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
			index = AddCraft( typeof( HitLowerDefenseRune ), "Weapons Hit", "Hit Lower Defense", 65.5, 105.0, typeof( GraveDust ), "Grave Dust", 3, "You do not have enough grave dust to make that." );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
			index = AddCraft( typeof( HitFireBallRune ), "Weapons Hit", "Hit Fireball", 60.5, 95.0, typeof( SulfurousAsh ), "Sulfurous Ash", 3, 1044367 );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
			index = AddCraft( typeof( HitHarmRune ), "Weapons Hit", "Hit Harm", 60.5, 95.0, typeof( BatWing ), "Bat Wing", 3, "You do not have enough bat wing to make that." );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
			index = AddCraft( typeof( HitLightningRune ), "Weapons Hit", "Hit Lightning", 60.5, 100.0, typeof( Garlic ), "Garlic", 3, "You do not have enough Garlic to make that" );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
			index = AddCraft( typeof( HitMagicArrowRune ), "Weapons Hit", "Hit Magic Arrow", 52.5, 100.0, typeof( BlackPearl ), "Black Pearl", 3, 1044361 );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
			index = AddCraft( typeof( HitLeechLifeRune ), "Weapons Hit", "Hit Life Leech", 85.5, 120.0, typeof( Nightshade ), "Nightshade", 7, 1044366 );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
			index = AddCraft( typeof( HitLeechManaRune ), "Weapons Hit", "Hit Mana Leech", 80.5, 120.0, typeof( Nightshade ), "Nightshade", 3, 1044366 );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
			index = AddCraft( typeof( HitLeechStamRune ), "Weapons Hit", "Hit Stam Leech", 75.5, 105.0, typeof( Nightshade ), "Nightshade", 5, 1044366 );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
*/
			index = AddCraft( typeof( UseBestWepRune ), "Weapons Misc", "Meilleur arme", 65.5, 100.0, typeof( PigIron ), "Pig Iron", 3, "You do not have enough pig iron to make that." );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );
			index = AddCraft( typeof( DamageIncRune ), "Weapons Misc", "Degat", 75.5, 120.0, typeof( Bloodmoss ), "Bloodmoss", 5, 1044362 );
				AddRes( index, typeof ( RoughStone ), "RoughStone", 1, "You do not have any Rough Stones to make that."  );
			index = AddCraft( typeof( SwingSpeedRune ), "Weapons Misc", "Vitesse de frappe", 75.5, 115.0, typeof( Bloodmoss ), "Bloodmoss", 5, 1044362 );
				AddRes( index, typeof ( RoughStone ), "Rough Stone", 1, "You do not have any Rough Stones to make that."  );

		}

		public override int CanCraft(Mobile from, ITool tool, Type itemType)
		{
			int num = 0;

			if (tool == null || tool.Deleted || tool.UsesRemaining <= 0)
				return 1044038; // You have worn out your tool!
			else if (!tool.CheckAccessible(from, ref num))
				return num; // The tool must be on your person to use.

			return 0;
		}
	}
}