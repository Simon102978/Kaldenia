namespace Server.Items
{
	public class AsianVegMix : ContainerFood
    {
        public override int MinSkill { get { return 0; } }
        public override int MaxSkill { get { return 100; } }
        public override bool NeedSilverware { get { return true; } }
        public override string CookedMessage { get { return "You make a bowl of asian vegetable mix."; } }
        public override Item FoodContainer { get { return new EmptyWoodenBowlExp(); } }
        [Constructable]
		public AsianVegMix() : base(0x15FB )
		{
            Name = "Asian vegetable Mix";
            Weight = 1.0;
            Uses = 2;
            FillFactor = 2;
		}
		public AsianVegMix( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
	public class BowlCornFlakes : ContainerFood
    {
        public override int MinSkill { get { return 0; } }
        public override int MaxSkill { get { return 100; } }
        public override bool NeedSilverware { get { return true; } }
        public override string CookedMessage { get { return "You make a bowl of corn flakes."; } }
        public override Item FoodContainer { get { return new EmptyWoodenBowlExp(); } }

        [Constructable]
		public BowlCornFlakes() : base(0x15FA )
		{
            Name = "Bowl of Corn Flakes";
            Weight = 1.0;
            Uses = 2;
            FillFactor = 2;
		}
		public BowlCornFlakes( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
	public class BowlRiceKrisps : ContainerFood
    {
        public override int MinSkill { get { return 0; } }
        public override int MaxSkill { get { return 100; } }
        public override bool NeedSilverware { get { return true; } }
        public override string CookedMessage { get { return "You make a bowl of Rice Krisps."; } }
        public override Item FoodContainer { get { return new EmptyWoodenBowlExp(); } }

        [Constructable]
		public BowlRiceKrisps() : base( 0x1602 )
		{
            Name = "Bowl of Rice Krisps";
            Weight = 1.0;
            Uses = 2;
            FillFactor = 2;
		}
		public BowlRiceKrisps( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
	public class CheeseSauce : ContainerFood
    {
        public override int MinSkill { get { return 0; } }
        public override int MaxSkill { get { return 100; } }
        public override bool NeedSilverware { get { return true; } }
        public override string CookedMessage { get { return "You make a Bowl of Cheese Sauce."; } }
        public override Item FoodContainer { get { return new EmptyWoodenBowlExp(); } }

        [Constructable]
		public CheeseSauce( ) : base(0x15FA )
		{
            Name = "Bowl of Cheese Sauce";
            Weight = 1.0;
            Uses = 2;
			FillFactor = 2;
		}
		public CheeseSauce( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
	public class ChocIceCream : ContainerFood
    {
        public override int MinSkill { get { return 0; } }
        public override int MaxSkill { get { return 100; } }
        public override bool NeedSilverware { get { return true; } }
        public override string CookedMessage { get { return "You make a Bowl of Chocolate Ice Cream."; } }
        public override Item FoodContainer { get { return new EmptyWoodenBowlExp(); } }

        [Constructable]
		public ChocIceCream() : base( 0x15FA )
		{
            Name = "Bowl of Chocolate Ice Cream";
            Weight = 1.0;
            Uses = 2;
			FillFactor = 2;
		}
		public ChocIceCream( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
	public class Gravy : ContainerFood
    {
        public override int MinSkill { get { return 0; } }
        public override int MaxSkill { get { return 100; } }
        public override bool NeedSilverware { get { return true; } }
        public override string CookedMessage { get { return "You make a Bowl of Gravy."; } }
        public override Item FoodContainer { get { return new EmptyWoodenBowlExp(); } }

        [Constructable]
		public Gravy() : base(0x15FD )
		{
            Name = "Bowl of Gravy";
            Weight = 1.0;
            Uses = 2;
			FillFactor = 2;
			Hue = 1012;
		}
		public Gravy( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
	public class MixedVegetables : ContainerFood
    {
        public override int MinSkill { get { return 0; } }
        public override int MaxSkill { get { return 100; } }
        public override bool NeedSilverware { get { return true; } }
        public override string CookedMessage { get { return "You make a Bowl of Mixed Vegetables."; } }
        public override Item FoodContainer { get { return new EmptyWoodenBowlExp(); } }

        [Constructable]
		public MixedVegetables() : base(0x15FB )
		{
            Name = "Bowl of Mixed Vegetables";
            Weight = 1.0;
            Uses = 2;
			FillFactor = 2;
		}
		public MixedVegetables( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
	public class BroccoliCheese : ContainerFood
    {
        public override int MinSkill { get { return 0; } }
        public override int MaxSkill { get { return 100; } }
        public override bool NeedSilverware { get { return true; } }
        public override string CookedMessage { get { return "You make a Bowl of Broccoli and Cheese."; } }
        public override Item FoodContainer { get { return new EmptyWoodenBowlExp(); } }

        [Constructable]
		public BroccoliCheese() : base(0x15FC )
		{
            Name = "Bowl of Broccoli and Cheese";
            Weight = 1.0;
            Uses = 2;
			FillFactor = 2;
		}
		public BroccoliCheese( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
	public class BroccoliCaulCheese : ContainerFood
    {
        public override int MinSkill { get { return 0; } }
        public override int MaxSkill { get { return 100; } }
        public override bool NeedSilverware { get { return true; } }
        public override string CookedMessage { get { return "You make a Bowl of Broccoli and Cauliflower with Cheese."; } }
        public override Item FoodContainer { get { return new EmptyWoodenBowlExp(); } }
        [Constructable]
		public BroccoliCaulCheese() : base(0x15FB )
		{
            Name = "Bowl of Broccoli and Cauliflower with Cheese";
            Weight = 1.0;
            Uses = 2;
			FillFactor = 2;
		}
		public BroccoliCaulCheese( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
	public class ChickenNoodleSoup : ContainerFood
    {
        public override int MinSkill { get { return 0; } }
        public override int MaxSkill { get { return 100; } }
        public override bool NeedSilverware { get { return true; } }
        public override string CookedMessage { get { return "You make a Bowl of Chicken Noodle Soup."; } }
        public override Item FoodContainer { get { return new EmptyWoodenBowlExp(); } }

        [Constructable]
		public ChickenNoodleSoup() : base(0x15FA )
		{
            Name = "Bowl of Chicken Noodle Soup";
            Weight = 1.0;
            Uses = 2;
			FillFactor = 2;
		}
		public ChickenNoodleSoup( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
	public class BowlBeets : ContainerFood
    {
        public override int MinSkill { get { return 0; } }
        public override int MaxSkill { get { return 100; } }
        public override bool NeedSilverware { get { return true; } }
        public override string CookedMessage { get { return "You make a Bowl of Beets."; } }
        public override Item FoodContainer { get { return new EmptyWoodenBowlExp(); } }

        [Constructable]
		public BowlBeets() : base(0x15F9 )
		{
            Name = "Bowl of Beets";
            Weight = 1.0;
            Uses = 2;
			FillFactor = 2;
		}
		public BowlBeets( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
	public class BowlBroccoli : ContainerFood
    {
        public override int MinSkill { get { return 0; } }
        public override int MaxSkill { get { return 100; } }
        public override bool NeedSilverware { get { return true; } }
        public override string CookedMessage { get { return "You make a Bowl of Broccoli."; } }
        public override Item FoodContainer { get { return new EmptyWoodenBowlExp(); } }

        [Constructable]
		public BowlBroccoli() : base(0x15FB )
		{
            Name = "Bowl of Broccoli";
            Weight = 1.0;
            Uses = 2;
			FillFactor = 2;
		}
		public BowlBroccoli( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
	public class BowlCauliflower : ContainerFood
    {
        public override int MinSkill { get { return 0; } }
        public override int MaxSkill { get { return 100; } }
        public override bool NeedSilverware { get { return true; } }
        public override string CookedMessage { get { return "You make a Bowl of Cauliflower."; } }
        public override Item FoodContainer { get { return new EmptyWoodenBowlExp(); } }

        [Constructable]
		public BowlCauliflower( ) : base(0x15FA )
		{
            Name = "Bowl of Cauliflower";
            Weight = 1.0;
            Uses = 2;
			FillFactor = 2;
		}
		public BowlCauliflower( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
	public class BowlGreenBeans : ContainerFood
    {
        public override int MinSkill { get { return 0; } }
        public override int MaxSkill { get { return 100; } }
        public override bool NeedSilverware { get { return true; } }
        public override string CookedMessage { get { return "You make a Bowl of Green Beans."; } }
        public override Item FoodContainer { get { return new EmptyWoodenBowlExp(); } }

        [Constructable]
		public BowlGreenBeans() : base(0x15FC )
		{
            Name = "Bowl of Green Beans";
            Weight = 1.0;
            Uses = 2;
			FillFactor = 2;
		}
		public BowlGreenBeans( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
	public class BowlSpinach : ContainerFood
    {
        public override int MinSkill { get { return 0; } }
        public override int MaxSkill { get { return 100; } }
        public override bool NeedSilverware { get { return true; } }
        public override string CookedMessage { get { return "You make a Bowl of Spinach."; } }
        public override Item FoodContainer { get { return new EmptyWoodenBowlExp(); } }

        [Constructable]
		public BowlSpinach( ) : base(0x15FC )
		{
            Name = "Bowl of Spinach";
            Weight = 1.0;
            Uses = 2;
			FillFactor = 2;
		}
		public BowlSpinach( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
	public class BowlTurnips : ContainerFood
    {
        public override int MinSkill { get { return 0; } }
        public override int MaxSkill { get { return 100; } }
        public override bool NeedSilverware { get { return true; } }
        public override string CookedMessage { get { return "You make a Bowl of Turnips."; } }
        public override Item FoodContainer { get { return new EmptyWoodenBowlExp(); } }
        [Constructable]
		public BowlTurnips() : base( 0x15F9 )
		{
            Name = "Bowl of Turnips";
            Weight = 1.0;
            Uses = 2;
			FillFactor = 2;
		}
		public BowlTurnips( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
	public class BowlMashedPotatos : ContainerFood
    {
        public override int MinSkill { get { return 0; } }
        public override int MaxSkill { get { return 100; } }
        public override bool NeedSilverware { get { return true; } }
        public override string CookedMessage { get { return "You make a Bowl of Mashed Potatos."; } }
        public override Item FoodContainer { get { return new EmptyWoodenBowlExp(); } }
        [Constructable]
		public BowlMashedPotatos() : base(0x15FB )
		{
            Name = "Bowl of Mashed Potatos";
            Weight = 1.0;
            Uses = 2;
			FillFactor = 2;
		}
		public BowlMashedPotatos( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
	public class MacaroniCheese : ContainerFood
    {
        public override int MinSkill { get { return 0; } }
        public override int MaxSkill { get { return 100; } }
        public override bool NeedSilverware { get { return true; } }
        public override string CookedMessage { get { return "You make a Bowl of Macaroni and Cheese."; } }
        public override Item FoodContainer { get { return new EmptyWoodenBowlExp(); } }
        [Constructable]
		public MacaroniCheese() : base( 0x15FF )
		{
            Name = "Bowl of Macaroni and Cheese";
            Weight = 1.0;
            Uses = 2;
			FillFactor = 2;
		}
		public MacaroniCheese( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
	public class CauliflowerCheese : ContainerFood
    {
        public override int MinSkill { get { return 0; } }
        public override int MaxSkill { get { return 100; } }
        public override bool NeedSilverware { get { return true; } }
        public override string CookedMessage { get { return "You make a Bowl of Cauliflower and Cheese."; } }
        public override Item FoodContainer { get { return new EmptyWoodenBowlExp(); } }
        [Constructable]
		public CauliflowerCheese() : base(0x1602 )
		{
            Name = "Bowl of Cauliflower and Cheese";
            Weight = 1.0;
            Uses = 2;
			FillFactor = 2;
		}
		public CauliflowerCheese( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
	public class PotatoFries : ContainerFood
    {
        public override int MinSkill { get { return 0; } }
        public override int MaxSkill { get { return 100; } }
        public override bool NeedSilverware { get { return true; } }
        public override string CookedMessage { get { return "You make a Bowl of Potato Fries."; } }
        public override Item FoodContainer { get { return new EmptyWoodenBowlExp(); } }
        [Constructable]
		public PotatoFries() : base( 0x160C )
		{
            Name = "Bowl of Potato Fries";
            Weight = 1.0;
            Uses = 2;
			FillFactor = 2;
		}
		public PotatoFries( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
	public class BowlOatmeal : ContainerFood
    {
        public override int MinSkill { get { return 0; } }
        public override int MaxSkill { get { return 100; } }
        public override bool NeedSilverware { get { return true; } }
        public override string CookedMessage { get { return "You make a Bowl of Oatmeal."; } }
        public override Item FoodContainer { get { return new EmptyWoodenBowlExp(); } }
        [Constructable]
		public BowlOatmeal() : base( 0x1602 )
		{
            Name = "Bowl of Oatmeal";
            Weight = 1.0;
            Uses = 2;
			FillFactor = 2;
		}
		public BowlOatmeal( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
	public class TomatoRice : ContainerFood
    {
        public override int MinSkill { get { return 0; } }
        public override int MaxSkill { get { return 100; } }
        public override bool NeedSilverware { get { return true; } }
        public override string CookedMessage { get { return "You make a bowl of Tomato and Rice"; } }
        public override Item FoodContainer { get { return new EmptyWoodenBowlExp(); } }
        [Constructable]
		public TomatoRice() : base(0x1606 )
		{
            Name = "Bowl of Tomato and Rice";
            Weight = 1.0;
            Uses = 2;
			FillFactor = 2;
		}
		public TomatoRice( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
	public class Popcorn : ContainerFood
    {
        public override int MinSkill { get { return 0; } }
        public override int MaxSkill { get { return 100; } }
        public override bool NeedSilverware { get { return true; } }
        public override string CookedMessage { get { return "You make a Bowl of Popcorn."; } }
        public override Item FoodContainer { get { return new EmptyWoodenBowlExp(); } }
        [Constructable]
		public Popcorn( ) : base( 0x1602 )
		{
            Name = "Bowl of Popcorn";
            Weight = 1.0;
            Uses = 2;
			FillFactor = 2;
		}
		public Popcorn( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
	public class BowlCookedVeggies : ContainerFood
    {
        public override int MinSkill { get { return 0; } }
        public override int MaxSkill { get { return 100; } }
        public override bool NeedSilverware { get { return true; } }
        public override string CookedMessage { get { return "You make a Bowl of Vegetables"; } }
        public override Item FoodContainer { get { return new EmptyWoodenBowlExp(); } }
        [Constructable]
		public BowlCookedVeggies() : base( 0x15FB )
		{
            Name = "Bowl of Vegetables";
            Weight = 1.0;
            Uses = 2;
			FillFactor = 2;
		}
		public BowlCookedVeggies( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
	public class BowlRice : ContainerFood
    {
        public override int MinSkill { get { return 0; } }
        public override int MaxSkill { get { return 100; } }
        public override bool NeedSilverware { get { return true; } }
        public override string CookedMessage { get { return "You make a Bowl of Rice."; } }
        public override Item FoodContainer { get { return new EmptyWoodenBowlExp(); } }
        [Constructable]
		public BowlRice() : base(0x15FB )
		{
            Name = "Bowl of Rice";
            Weight = 1.0;
            Uses = 2;
			FillFactor = 2;
		}
		public BowlRice( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}

    public class BowlOfRotwormStewExp : BaseFood
    {
        public override int LabelNumber { get { return 1031706; } } // bowl of rotworm stew

        [Constructable]
        public BowlOfRotwormStewExp()
            : base(0x2DBA)
        {
            Stackable = false;
            Weight = 2.0;
            FillFactor = 1;
        }

        public BowlOfRotwormStewExp(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            /*int version = */
            reader.ReadInt();
        }
    }

    public class BlackrockStew : BaseFood
    {
        public override int LabelNumber { get { return 1115752; } } // Blackrock Stew

        [Constructable]
        public BlackrockStew()
            : base(0x2DBA)
        {
            Stackable = false;
            Weight = 2.0;
            Hue = 1;
            FillFactor = 1;
        }

        public BlackrockStew(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            /*int version = */
            reader.ReadInt();
        }
    }

    public class BowlOfStew : BaseFood
	{
		[Constructable]
		public BowlOfStew() : this( 1 ) { }
		[Constructable]
		public BowlOfStew( int amount ) : base( amount, 0x1604 )
		{
			Weight = 0.2;
			FillFactor = 5;
			Name = "Bowl of Stew";
		}
		public BowlOfStew( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
	public class PewterBowlCabbage : BaseFood
	{
		[Constructable]
		public PewterBowlCabbage() : this( 1 ) { }
		[Constructable]
		public PewterBowlCabbage( int amount ) : base( amount, 0x9D8 )
		{
			Weight = 0.2;
			FillFactor = 1;
			Name = "Bowl of Cabbage";
		}
		public PewterBowlCabbage( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
	public class PewterBowlCarrot : BaseFood
	{
		[Constructable]
		public PewterBowlCarrot() : this( 1 ) { }
		[Constructable]
		public PewterBowlCarrot( int amount ) : base( amount, 0x15FE )
		{
			Weight = 0.2;
			FillFactor = 1;
			Name = "Bowl of Carrot";
		}
		public PewterBowlCarrot( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
	public class PewterBowlCorn : BaseFood
	{
		[Constructable]
		public PewterBowlCorn() : this( 1 ) { }
		[Constructable]
		public PewterBowlCorn( int amount ) : base( amount, 0x15FF )
		{
			Weight = 0.2;
			FillFactor = 1;
			Name = "Bowl of Corn";
		}
		public PewterBowlCorn( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
	public class PewterBowlLettuce : BaseFood
	{
		[Constructable]
		public PewterBowlLettuce() : this( 1 ) { }
		[Constructable]
		public PewterBowlLettuce( int amount ) : base( amount, 0x1600 )
		{
			Weight = 0.2;
			FillFactor = 1;
			Name = "Bowl of Lettuce";
		}
		public PewterBowlLettuce( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
	public class PewterBowlPea : BaseFood
	{
		[Constructable]
		public PewterBowlPea() : this( 1 ) { }
		[Constructable]
		public PewterBowlPea( int amount ) : base( amount, 0x1601 )
		{
			Weight = 0.2;
			FillFactor = 1;
			Name = "Bowl of Pea";
		}
		public PewterBowlPea( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
	public class TomatoSoup : BaseFood
	{
		[Constructable]
		public TomatoSoup() : this( 1 ) { }
		[Constructable]
		public TomatoSoup( int amount ) : base( amount, 0x1606 )
		{
			Weight = 2;
			FillFactor = 4;
			Name = "tomato soup";
		}
		public TomatoSoup( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
	public class WoodenBowlCabbage : BaseFood
	{
		[Constructable]
		public WoodenBowlCabbage() : this( 1 ) { }
		[Constructable]
		public WoodenBowlCabbage( int amount ) : base( amount, 0x15FB )
		{
			Weight = 1;
			FillFactor = 1;
			Name = "Bowl of cabbage";
		}
		public WoodenBowlCabbage( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
	public class WoodenBowlCarrot : BaseFood
	{
		[Constructable]
		public WoodenBowlCarrot() : this( 1 ) { }
		[Constructable]
		public WoodenBowlCarrot( int amount ) : base( amount, 0x15F9 )
		{
			Weight = 1;
			FillFactor = 1;
			Name = "Bowl of Carrot";
		}
		public WoodenBowlCarrot( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
	public class WoodenBowlCorn : BaseFood
	{
		[Constructable]
		public WoodenBowlCorn() : this( 1 ) { }
		[Constructable]
		public WoodenBowlCorn( int amount ) : base( amount, 0x15FA )
		{
			Weight = 1;
			FillFactor = 1;
			Name = "Bowl of Corn";
		}
		public WoodenBowlCorn( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
	public class WoodenBowlLettuce : BaseFood
	{
		[Constructable]
		public WoodenBowlLettuce() : this( 1 ) { }
		[Constructable]
		public WoodenBowlLettuce( int amount ) : base( amount, 0x15FB )
		{
			Weight = 1;
			FillFactor = 1;
			Name = "Bowl of Lettuce";
		}
		public WoodenBowlLettuce( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}
	public class WoodenBowlPea : BaseFood
	{
		[Constructable]
		public WoodenBowlPea() : this( 1 ) { }
		[Constructable]
		public WoodenBowlPea( int amount ) : base( amount, 0x15FC )
		{
			Weight = 1;
			FillFactor = 1;
			Name = "Bowl of Pea";
		}
		public WoodenBowlPea( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 ); }
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt(); }

	}

	public class WoodenBowlOfCarrotsExp : BaseFood
	{
		[Constructable]
		public WoodenBowlOfCarrotsExp() : base( 0x15F9 )
		{
			FillFactor = 2;
		}

		public override bool Eat( Mobile from )
		{
			if ( !base.Eat( from ) ) return false;
			from.AddToBackpack( new EmptyWoodenBowlExp() );
			return true;
		}

		public WoodenBowlOfCarrotsExp( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 );}
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt();}
	}

	public class WoodenBowlOfCornExp : BaseFood
	{
		[Constructable]
		public WoodenBowlOfCornExp() : base( 0x15FA )
		{
			FillFactor = 2;
		}

		public override bool Eat( Mobile from )
		{
			if ( !base.Eat( from ) ) return false;
			from.AddToBackpack( new EmptyWoodenBowlExp() );
			return true;
		}

		public WoodenBowlOfCornExp( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 );}
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt();}
	}

	public class WoodenBowlOfLettuceExp : BaseFood
	{
		[Constructable]
		public WoodenBowlOfLettuceExp() : base( 0x15FB )
		{
			FillFactor = 2;
		}

		public override bool Eat( Mobile from )
		{
			if ( !base.Eat( from ) ) return false;
			from.AddToBackpack( new EmptyWoodenBowlExp() );
			return true;
		}

		public WoodenBowlOfLettuceExp( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 );}
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt();}
	}

	public class WoodenBowlOfPeasExp : BaseFood
	{
		[Constructable]
		public WoodenBowlOfPeasExp() : base( 0x15FC )
		{
			FillFactor = 2;
		}

		public override bool Eat( Mobile from )
		{
			if ( !base.Eat( from ) ) return false;
			from.AddToBackpack( new EmptyWoodenBowlExp() );
			return true;
		}

		public WoodenBowlOfPeasExp( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 );}
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt();}
	}

	public class PewterBowlOfCarrotsExp : BaseFood
	{
		[Constructable]
		public PewterBowlOfCarrotsExp() : base( 0x15FE )
		{
			FillFactor = 2;
		}

		public override bool Eat( Mobile from )
		{
			if ( !base.Eat( from ) ) return false;
			from.AddToBackpack( new EmptyPewterBowlExp() );
			return true;
		}

		public PewterBowlOfCarrotsExp( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 );}
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt();}
	}

	public class PewterBowlOfCornExp : BaseFood
	{
		[Constructable]
		public PewterBowlOfCornExp() : base( 0x15FF )
		{
			FillFactor = 2;
		}

		public override bool Eat( Mobile from )
		{
			if ( !base.Eat( from ) ) return false;
			from.AddToBackpack( new EmptyPewterBowlExp() );
			return true;
		}

		public PewterBowlOfCornExp( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 );}
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt();}
	}

	public class PewterBowlOfLettuceExp : BaseFood
	{
		[Constructable]
		public PewterBowlOfLettuceExp() : base( 0x1600 )
		{
			FillFactor = 2;
		}

		public override bool Eat( Mobile from )
		{
			if ( !base.Eat( from ) ) return false;
			from.AddToBackpack( new EmptyPewterBowlExp() );
			return true;
		}

		public PewterBowlOfLettuceExp( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 );}
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt();}
	}

	public class PewterBowlOfPeasExp : BaseFood
	{
		[Constructable]
		public PewterBowlOfPeasExp() : base( 0x1601 )
		{
			FillFactor = 2;
		}

		public override bool Eat( Mobile from )
		{
			if ( !base.Eat( from ) ) return false;
			from.AddToBackpack( new EmptyPewterBowlExp() );
			return true;
		}

		public PewterBowlOfPeasExp( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 );}
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt();}
	}

	public class PewterBowlOfPotatosExp : BaseFood
	{
		[Constructable]
		public PewterBowlOfPotatosExp() : base( 0x1602 )
		{
			FillFactor = 2;
		}

		public override bool Eat( Mobile from )
		{
			if ( !base.Eat( from ) ) return false;
			from.AddToBackpack( new EmptyPewterBowlExp() );
			return true;
		}

		public PewterBowlOfPotatosExp( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 );}
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt();}
	}

	public class WoodenBowlOfStewExp : BaseFood
	{
		[Constructable]
		public WoodenBowlOfStewExp() : base( 0x1604 )
		{
			Weight = 2.0;
			FillFactor = 2;
		}

		public override bool Eat( Mobile from )
		{
			if ( !base.Eat( from ) ) return false;
			from.AddToBackpack( new EmptyWoodenTubExp() );
			return true;
		}

		public WoodenBowlOfStewExp( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 );}
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt();}
	}

	public class WoodenBowlOfTomatoSoupExp : BaseFood
	{
		[Constructable]
		public WoodenBowlOfTomatoSoupExp() : base( 0x1606 )
		{
			Weight = 2.0;
			FillFactor = 2;
		}

		public override bool Eat( Mobile from )
        {
            if (base.Eat(from))
            {
                from.AddToBackpack(new EmptyWoodenTubExp());
                return true;
            }

            return false;
        }

        public WoodenBowlOfTomatoSoupExp( Serial serial ) : base( serial ) { }
		public override void Serialize( GenericWriter writer ) { base.Serialize( writer ); writer.Write( (int) 0 );}
		public override void Deserialize( GenericReader reader ) { base.Deserialize( reader ); int version = reader.ReadInt();}
	}
    public class HarpyEggSoup : BaseFood
    {
        [Constructable]
        public HarpyEggSoup() : this(1) { }
        [Constructable]
        public HarpyEggSoup(int amount)
            : base(amount, 0x15FA)
        {
            Weight = 1.0;
            FillFactor = 2;
            Name = "Harpy Egg Soup";
        }

        public override bool Eat(Mobile from)
        {
            if (!base.Eat(from))
            {
                return false;
            }

            from.AddToBackpack(new EmptyWoodenTubExp());
            return true;
        }
        public HarpyEggSoup(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }

    }
}
