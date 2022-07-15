namespace Server.Items
{
    public class TreasureLevel1 : BaseDungeonChest
    {
        public override int DefaultGumpID => 0x49;

        [Constructable]
        public TreasureLevel1() : base(Utility.RandomList(0xE3C, 0xE3E, 0x9a9)) // Large, Medium and Small Crate
        {
            RequiredSkill = 20;
            LockLevel = RequiredSkill - Utility.Random(1, 10);
            MaxLockLevel = RequiredSkill;
            TrapType = TrapType.MagicTrap;
            TrapPower = 1 * Utility.Random(35, 45);

      //      DropItem(new Gold(30, 100));
            DropItem(new Bolt(10));
			DropItem(new Arrow(10));

			DropItem(new Tourmaline(Utility.Random(3)));
			DropItem(new Amber(Utility.Random(2)));
			DropItem(new Citrine(Utility.Random(5)));

			//     for (int i = Utility.Random(3) + 1; i > 0; i--) // random 1 to 3
			//       DropItem(Loot.RandomGem());
		}

        public TreasureLevel1(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version 
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class TreasureLevel2 : BaseDungeonChest
    {
        [Constructable]
        public TreasureLevel2() : base(Utility.RandomList(0xe3c, 0xE3E, 0x9a9, 0xe42, 0x9ab, 0xe40, 0xe7f, 0xe77)) // various container IDs
        {
            RequiredSkill = 40;
            LockLevel = RequiredSkill - Utility.Random(1, 10);
            MaxLockLevel = RequiredSkill;
            TrapType = TrapType.MagicTrap;
            TrapPower = 2 * Utility.Random(25, 40);

			DropItem(new Gold(50, 75));
			DropItem(new Tourmaline(Utility.Random(3)));
			DropItem(new Amber(Utility.Random(2)));
			DropItem(new Citrine(Utility.Random(5)));
			DropItem(new DragonBlood(Utility.Random(0, 1)));



			DropItem(new Arrow(10));
            DropItem(Loot.RandomPotion());
            for (int i = Utility.Random(1, 2); i > 1; i--)
            {
                Item ReagentLoot = Loot.RandomReagent();
                ReagentLoot.Amount = Utility.Random(1, 2);
                DropItem(ReagentLoot);
            }
            if (Utility.RandomBool()) //50% chance
                for (int i = Utility.Random(8) + 1; i > 0; i--)
                    DropItem(Loot.RandomScroll(0, 39, SpellbookType.Regular));

            if (Utility.RandomBool()) //50% chance
                for (int i = Utility.Random(6) + 1; i > 0; i--)
                    DropItem(Loot.RandomGem());
        }

        public TreasureLevel2(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version 
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class TreasureLevel3 : BaseDungeonChest
    {
        public override int DefaultGumpID => 0x4A;

        [Constructable]
        public TreasureLevel3() : base(Utility.RandomList(0x9ab, 0xe40, 0xe42)) // Wooden, Metal and Metal Golden Chest
        {
            RequiredSkill = 60;
            LockLevel = RequiredSkill - Utility.Random(1, 10);
            MaxLockLevel = RequiredSkill;
            TrapType = TrapType.MagicTrap;
            TrapPower = 3 * Utility.Random(20, 30);
			DropItem(new DragonBlood(Utility.Random(1, 2)));

			DropItem(new Gold(200, 500));



			DropItem(new Arrow(10));

            for (int i = Utility.Random(1, 3); i > 1; i--)
            {
                Item ReagentLoot = Loot.RandomReagent();
                ReagentLoot.Amount = Utility.Random(1, 9);
                DropItem(ReagentLoot);
            }

            for (int i = Utility.Random(1, 3); i > 1; i--)
                DropItem(Loot.RandomPotion());

            if (0.67 > Utility.RandomDouble()) //67% chance = 2/3
                for (int i = Utility.Random(12) + 1; i > 0; i--)
                    DropItem(Loot.RandomScroll(0, 47, SpellbookType.Regular));

            if (0.67 > Utility.RandomDouble()) //67% chance = 2/3
                for (int i = Utility.Random(9) + 1; i > 0; i--)
                    DropItem(Loot.RandomGem());


        }

        public TreasureLevel3(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version 
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class TreasureLevel4 : BaseDungeonChest
    {
        [Constructable]
        public TreasureLevel4() : base(Utility.RandomList(0xe40, 0xe42, 0x9ab)) // Wooden, Metal and Metal Golden Chest
        {
            RequiredSkill = 80;
            LockLevel = RequiredSkill - Utility.Random(1, 10);
            MaxLockLevel = RequiredSkill;
            TrapType = TrapType.MagicTrap;
            TrapPower = 4 * Utility.Random(15, 25); 

            DropItem(new Gold(350, 700));
            DropItem(new BlankScroll(Utility.Random(1, 4)));
			DropItem(new DragonBlood(Utility.Random(1, 3)));

			for (int i = Utility.Random(1, 4); i > 1; i--)
            {
                Item ReagentLoot = Loot.RandomReagent();
                ReagentLoot.Amount = Utility.Random(6, 12);
                DropItem(ReagentLoot);
            }

            for (int i = Utility.Random(1, 4); i > 1; i--)
                DropItem(Loot.RandomPotion());

            if (0.75 > Utility.RandomDouble()) //75% chance = 3/4
                for (int i = Utility.RandomMinMax(8, 16); i > 0; i--)
                    DropItem(Loot.RandomScroll(0, 47, SpellbookType.Regular));

            if (0.75 > Utility.RandomDouble()) //75% chance = 3/4
                for (int i = Utility.RandomMinMax(6, 12) + 1; i > 0; i--)
                    DropItem(Loot.RandomGem());

        }

        public TreasureLevel4(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version 
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

}
