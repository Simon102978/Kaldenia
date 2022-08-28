using System;
using System.Collections.Generic;
using Server.Items;
using Server.Items.Crops;

namespace Server.Mobiles
{
	public class SBGardener : SBInfo
	{
        private readonly List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
        private readonly IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBGardener(){}

        public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
        public override List<GenericBuyInfo> BuyInfo
        {
            get
            {
                return this.m_BuyInfo;
            }
        }

        public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				this.Add( new GenericBuyInfo( typeof( MilkBucket ), 300, 10, 0x0FFA, 0 ) );
				this.Add( new GenericBuyInfo( typeof( CheeseForm ), 300, 10, 0x0E78, 0 ) );

				this.Add( new GenericBuyInfo( "Plant Bowl", typeof( Engines.Plants.PlantBowl ), 2, 20, 0x15FD, 0 ) );
				this.Add( new GenericBuyInfo( "Fertile Dirt", typeof( FertileDirt ), 5, 999, 0xF81, 0 ) );
				this.Add( new GenericBuyInfo( "Random Plant Seed", typeof( Engines.Plants.Seed ), 2, 20, 0xDCF, 0 ) );
 			//	this.Add( new GenericBuyInfo( typeof( GreaterCurePotion ), 45, 20, 0xF07, 0 ) );
			//	this.Add( new GenericBuyInfo( typeof( GreaterPoisonPotion ), 45, 20, 0xF0A, 0 ) );
			//	this.Add( new GenericBuyInfo( typeof( GreaterStrengthPotion ), 45, 20, 0xF09, 0 ) );
			//	this.Add( new GenericBuyInfo( typeof( GreaterHealPotion ), 45, 20, 0xF0C, 0 ) );
                this.Add(new GenericBuyInfo("Asparagus Seed", typeof(AsparagusSeed), 1, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("Beet Seed", typeof(BeetSeed), 1, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("Broccoli Seed", typeof(BroccoliSeed), 1, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("Cabbage Seed", typeof(CabbageSeed), 1, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("Carrot Seed", typeof(CarrotSeed), 1, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("Cauliflower Seed", typeof(CauliflowerSeed), 1, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("Celery Seed", typeof(CelerySeed), 1, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("Eggplant Seed", typeof(EggplantSeed), 1, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("GreenBean Seed", typeof(GreenBeanSeed), 1, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("Lettuce Seed", typeof(LettuceSeed), 1, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("Onion Seed", typeof(OnionSeed), 1, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("Peanut Seed", typeof(PeanutSeed), 1, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("Peas Seed", typeof(PeasSeed), 1, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("Potato Seed", typeof(PotatoSeed), 1, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("Radish Seed", typeof(RadishSeed), 1, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("SnowPeas Seed", typeof(SnowPeasSeed), 1, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("Soy Seed", typeof(SoySeed), 1, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("Spinach Seed", typeof(SpinachSeed), 1, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("Strawberry Seed", typeof(StrawberrySeed), 1, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("SweetPotato Seed", typeof(SweetPotatoSeed), 1, 20, 0xF27, 0));
                this.Add(new GenericBuyInfo("Turnip Seed", typeof(TurnipSeed), 1, 20, 0xF27, 0));

				this.Add(new GenericBuyInfo("Blackberry Seed", typeof(BlackberrySeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("BlackRaspberry Seed", typeof(BlackRaspberrySeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Blueberry Seed", typeof(BlueberrySeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Cranberry Seed", typeof(CranberrySeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Pineapple Seed", typeof(PineappleSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("RedRaspberry Seed", typeof(RedRaspberrySeed), 1, 20, 0xF27, 0));


				this.Add(new GenericBuyInfo("Red Rose Seed", typeof(RedRoseSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("White Rose Seed", typeof(WhiteRoseSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Black Rose Seed", typeof(BlackRoseSeed), 1, 20, 0xF27, 0));


				this.Add(new GenericBuyInfo("Cotton Seed", typeof(CottonSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Flax Seed", typeof(FlaxSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Hay Seed", typeof(HaySeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Oats Seed", typeof(OatsSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Rice Seed", typeof(RiceSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Sugarcane Seed", typeof(SugarcaneSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Wheat Seed", typeof(WheatSeed), 1, 20, 0xF27, 0));


				this.Add(new GenericBuyInfo("Garlic Seed", typeof(GarlicSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Tan Ginger Seed", typeof(TanGingerSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Ginseng Seed", typeof(GinsengSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Mandrake Seed", typeof(MandrakeSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Nightshade Seed", typeof(NightshadeSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Tan Mushroom Seed", typeof(TanMushroomSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Red Mushroom Seed", typeof(RedMushroomSeed), 1, 20, 0xF27, 0));


				this.Add(new GenericBuyInfo("Bitter Hops Seed", typeof(BitterHopsSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Elven Hops Seed", typeof(ElvenHopsSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Snow Hops Seed", typeof(SnowHopsSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Sweet Hops Seed", typeof(SweetHopsSeed), 1, 20, 0xF27, 0));


				this.Add(new GenericBuyInfo("Corn Seed", typeof(CornSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Field Corn Seed", typeof(FieldCornSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Sun Flower Seed", typeof(SunFlowerSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Tea Seed", typeof(TeaSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("VanillaSeed", typeof(VanillaSeed), 1, 20, 0xF27, 0));


			//	this.Add(new GenericBuyInfo("Pommier", typeof(AppleSapling), 1, 20, 0xF27, 0));
			//	this.Add(new GenericBuyInfo("Pêcher", typeof(PeachSapling), 1, 20, 0xF27, 0));
			//	this.Add(new GenericBuyInfo("Poirier", typeof(PearSapling), 1, 20, 0xF27, 0));

				this.Add(new GenericBuyInfo("Chili Pepper Seed", typeof(ChiliPepperSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Cucumber Seed", typeof(CucumberSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Green Pepper Seed", typeof(GreenPepperSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Orange Pepper Seed", typeof(OrangePepperSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Red Pepper Seed", typeof(RedPepperSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Tomato Seed", typeof(TomatoSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Yellow Pepper Seed", typeof(YellowPepperSeed), 1, 20, 0xF27, 0));

				this.Add(new GenericBuyInfo("Cantaloupe Seed", typeof(CantaloupeSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Green Squash Seed", typeof(GreenSquashSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Honeydew Melon Seed", typeof(HoneydewMelonSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Pumpkin Seed", typeof(PumpkinSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Squash Seed", typeof(SquashSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Watermelon Seed", typeof(WatermelonSeed), 1, 20, 0xF27, 0));

				this.Add(new GenericBuyInfo("Banana Seed", typeof(BananaSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Coconut Seed", typeof(CoconutSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Date Seed", typeof(DateSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Mini Almond Seed", typeof(MiniAlmondSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Mini Apple Seed", typeof(MiniAppleSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Mini Apricot Seed", typeof(MiniApricotSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Mini Avocado Seed", typeof(MiniAvocadoSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Mini Cherry Seed", typeof(MiniCherrySeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Mini Cocoa Seed", typeof(MiniCocoaSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Mini Coffee Seed", typeof(MiniCoffeeSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Mini Grapefruit Seed", typeof(MiniGrapefruitSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Mini Kiwi Seed", typeof(MiniKiwiSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Mini Lemon Seed", typeof(MiniLemonSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Mini Lime Seed", typeof(MiniLimeSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Mini Mango Seed", typeof(MiniMangoSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Mini Orange Seed", typeof(MiniOrangeSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Mini Peach Seed", typeof(MiniPeachSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Mini Pear Seed", typeof(MiniPearSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Mini Pistacio Seed", typeof(MiniPistacioSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Mini Pomegranate Seed", typeof(MiniPomegranateSeed), 1, 20, 0xF27, 0));
				this.Add(new GenericBuyInfo("Small Banana Seed", typeof(SmallBananaSeed), 1, 20, 0xF27, 0));










			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( MilkBucket ), 40 );
				Add( typeof( CheeseForm ), 40 );

				Add( typeof( Apple ), 1 );
				Add( typeof( Grapes ), 1 );
				Add( typeof( Watermelon ), 3 );
				Add( typeof( YellowGourd ), 1 );
				Add( typeof( Pumpkin ), 5 );
				Add( typeof( Onion ), 1 );
				Add( typeof( Lettuce ), 2 );
				Add( typeof( Squash ), 1 );
				Add( typeof( Carrot ), 1 );
				Add( typeof( HoneydewMelon ), 3 );
				Add( typeof( Cantaloupe ), 3 );
				Add( typeof( Cabbage ), 2 );
				Add( typeof( Lemon ), 1 );
				Add( typeof( Lime ), 1 );
				Add( typeof( Peach ), 1 );
				Add( typeof( Pear ), 1 );
			}
		}
	}
}