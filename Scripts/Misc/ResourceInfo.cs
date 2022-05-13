using System;
using System.Collections;
using System.Reflection;

namespace Server.Items
{
    public enum CraftResource
    {
        None = 0,
        Iron = 1,
		[Description("Dull Copper")]
		DullCopper,
		[Description("Shadow Iron")]
		ShadowIron,
        Copper,
        Bronze,
        Gold,
        Agapite,
        Verite,
        Valorite,

		[Description("Regulier")]
		RegularLeather = 101,
		[Description("Lupus")]
		LupusLeather,
		[Description("Reptilien")]
		ReptilienLeather,
		[Description("Géant")]
		GeantLeather,
		[Description("Ophidien")]
		OphidienLeather,
		[Description("Arachnide")]
		ArachnideLeather,
		[Description("Dragonique")]
		DragoniqueLeather,
		[Description("Demoniaque")]
		DemoniaqueLeather,
		[Description("Ancien")]
		AncienLeather,




		RedScales = 201,
        YellowScales,
        BlackScales,
        GreenScales,
        WhiteScales,
        BlueScales,

        RegularWood = 301,
        OakWood,
        AshWood,
        YewWood,
        Heartwood,
        Bloodwood,
        Frostwood,

		[Description("Regulier")]
		RegularBone = 401,
		[Description("Lupus")]
		LupusBone,
		[Description("Reptilien")]
		ReptilienBone,
		[Description("Géant")]
		GeantBone,
		[Description("Ophidien")]
		OphidienBone,
		[Description("Arachnide")]
		ArachnideBone,
		[Description("Dragonique")]
		DragoniqueBone,
		[Description("Demoniaque")]
		DemoniaqueBone,
		[Description("Ancien")]
		AncienBone,
	}

    public enum CraftResourceType
    {
        None,
        Metal,
        Leather,
        Scales,
        Wood,
		Bone
    }

    public class CraftAttributeInfo
    {
        private int m_WeaponFireDamage;
        private int m_WeaponColdDamage;
        private int m_WeaponPoisonDamage;
        private int m_WeaponEnergyDamage;
        private int m_WeaponChaosDamage;
        private int m_WeaponDirectDamage;
        private int m_WeaponDurability;
        private int m_WeaponLuck;
        private int m_WeaponGoldIncrease;
        private int m_WeaponLowerRequirements;
        private int m_WeaponDamage;
        private int m_WeaponHitChance;
        private int m_WeaponHitLifeLeech;
        private int m_WeaponRegenHits;
        private int m_WeaponSwingSpeed;

        private int m_ArmorPhysicalResist;
        private int m_ArmorFireResist;
        private int m_ArmorColdResist;
        private int m_ArmorPoisonResist;
        private int m_ArmorEnergyResist;
        private int m_ArmorDurability;
        private int m_ArmorLuck;
        private int m_ArmorGoldIncrease;
        private int m_ArmorLowerRequirements;
        private int m_ArmorDamage;
        private int m_ArmorHitChance;
        private int m_ArmorRegenHits;
        private int m_ArmorMage;

        private int m_ShieldPhysicalResist;
        private int m_ShieldFireResist;
        private int m_ShieldColdResist;
        private int m_ShieldPoisonResist;
        private int m_ShieldEnergyResist;
        private int m_ShieldPhysicalRandom;
        private int m_ShieldColdRandom;
        private int m_ShieldSpellChanneling;
        private int m_ShieldLuck;
        private int m_ShieldLowerRequirements;
        private int m_ShieldRegenHits;
        private int m_ShieldBonusDex;
        private int m_ShieldBonusStr;
        private int m_ShieldReflectPhys;
        private int m_SelfRepair;

        private int m_OtherSpellChanneling;
        private int m_OtherLuck;
        private int m_OtherRegenHits;
        private int m_OtherLowerRequirements;

        private int m_RunicMinAttributes;
        private int m_RunicMaxAttributes;
        private int m_RunicMinIntensity;
        private int m_RunicMaxIntensity;

        public int WeaponFireDamage { get { return m_WeaponFireDamage; } set { m_WeaponFireDamage = value; } }
        public int WeaponColdDamage { get { return m_WeaponColdDamage; } set { m_WeaponColdDamage = value; } }
        public int WeaponPoisonDamage { get { return m_WeaponPoisonDamage; } set { m_WeaponPoisonDamage = value; } }
        public int WeaponEnergyDamage { get { return m_WeaponEnergyDamage; } set { m_WeaponEnergyDamage = value; } }
        public int WeaponChaosDamage { get { return m_WeaponChaosDamage; } set { m_WeaponChaosDamage = value; } }
        public int WeaponDirectDamage { get { return m_WeaponDirectDamage; } set { m_WeaponDirectDamage = value; } }
        public int WeaponDurability { get { return m_WeaponDurability; } set { m_WeaponDurability = value; } }
        public int WeaponLuck { get { return m_WeaponLuck; } set { m_WeaponLuck = value; } }
        public int WeaponGoldIncrease { get { return m_WeaponGoldIncrease; } set { m_WeaponGoldIncrease = value; } }
        public int WeaponLowerRequirements { get { return m_WeaponLowerRequirements; } set { m_WeaponLowerRequirements = value; } }
        public int WeaponDamage { get { return m_WeaponDamage; } set { m_WeaponDamage = value; } }
        public int WeaponHitChance { get { return m_WeaponHitChance; } set { m_WeaponHitChance = value; } }
        public int WeaponHitLifeLeech { get { return m_WeaponHitLifeLeech; } set { m_WeaponHitLifeLeech = value; } }
        public int WeaponRegenHits { get { return m_WeaponRegenHits; } set { m_WeaponRegenHits = value; } }
        public int WeaponSwingSpeed { get { return m_WeaponSwingSpeed; } set { m_WeaponSwingSpeed = value; } }

        public int ArmorPhysicalResist { get { return m_ArmorPhysicalResist; } set { m_ArmorPhysicalResist = value; } }
        public int ArmorFireResist { get { return m_ArmorFireResist; } set { m_ArmorFireResist = value; } }
        public int ArmorColdResist { get { return m_ArmorColdResist; } set { m_ArmorColdResist = value; } }
        public int ArmorPoisonResist { get { return m_ArmorPoisonResist; } set { m_ArmorPoisonResist = value; } }
        public int ArmorEnergyResist { get { return m_ArmorEnergyResist; } set { m_ArmorEnergyResist = value; } }
        public int ArmorDurability { get { return m_ArmorDurability; } set { m_ArmorDurability = value; } }
        public int ArmorLuck { get { return m_ArmorLuck; } set { m_ArmorLuck = value; } }
        public int ArmorGoldIncrease { get { return m_ArmorGoldIncrease; } set { m_ArmorGoldIncrease = value; } }
        public int ArmorLowerRequirements { get { return m_ArmorLowerRequirements; } set { m_ArmorLowerRequirements = value; } }
        public int ArmorDamage { get { return m_ArmorDamage; } set { m_ArmorDamage = value; } }
        public int ArmorHitChance { get { return m_ArmorHitChance; } set { m_ArmorHitChance = value; } }
        public int ArmorRegenHits { get { return m_ArmorRegenHits; } set { m_ArmorRegenHits = value; } }
        public int ArmorMage { get { return m_ArmorMage; } set { m_ArmorMage = value; } }

        public int ShieldPhysicalResist { get { return m_ShieldPhysicalResist; } set { m_ShieldPhysicalResist = value; } }
        public int ShieldFireResist { get { return m_ShieldFireResist; } set { m_ShieldFireResist = value; } }
        public int ShieldColdResist { get { return m_ShieldColdResist; } set { m_ShieldColdResist = value; } }
        public int ShieldPoisonResist { get { return m_ShieldPoisonResist; } set { m_ShieldPoisonResist = value; } }
        public int ShieldEnergyResist { get { return m_ShieldEnergyResist; } set { m_ShieldEnergyResist = value; } }
        public int ShieldPhysicalRandom { get { return m_ShieldPhysicalRandom; } set { m_ShieldPhysicalRandom = value; } }
        public int ShieldColdRandom { get { return m_ShieldColdRandom; } set { m_ShieldColdRandom = value; } }
        public int ShieldSpellChanneling { get { return m_ShieldSpellChanneling; } set { m_ShieldSpellChanneling = value; } }
        public int ShieldLuck { get { return m_ShieldLuck; } set { m_ShieldLuck = value; } }
        public int ShieldLowerRequirements { get { return m_ShieldLowerRequirements; } set { m_ShieldLowerRequirements = value; } }
        public int ShieldRegenHits { get { return m_ShieldRegenHits; } set { m_ShieldRegenHits = value; } }
        public int ShieldBonusDex { get { return m_ShieldBonusDex; } set { m_ShieldBonusDex = value; } }
        public int ShieldBonusStr { get { return m_ShieldBonusStr; } set { m_ShieldBonusStr = value; } }
        public int ShieldReflectPhys { get { return m_ShieldReflectPhys; } set { m_ShieldReflectPhys = value; } }
        public int ShieldSelfRepair { get { return m_SelfRepair; } set { m_SelfRepair = value; } }

        public int OtherSpellChanneling { get { return m_OtherSpellChanneling; } set { m_OtherSpellChanneling = value; } }
        public int OtherLuck { get { return m_OtherLuck; } set { m_OtherLuck = value; } }
        public int OtherRegenHits { get { return m_OtherRegenHits; } set { m_OtherRegenHits = value; } }
        public int OtherLowerRequirements { get { return m_OtherLowerRequirements; } set { m_OtherLowerRequirements = value; } }

        public int RunicMinAttributes { get { return m_RunicMinAttributes; } set { m_RunicMinAttributes = value; } }
        public int RunicMaxAttributes { get { return m_RunicMaxAttributes; } set { m_RunicMaxAttributes = value; } }
        public int RunicMinIntensity { get { return m_RunicMinIntensity; } set { m_RunicMinIntensity = value; } }
        public int RunicMaxIntensity { get { return m_RunicMaxIntensity; } set { m_RunicMaxIntensity = value; } }

        public static readonly CraftAttributeInfo Blank;
        public static readonly CraftAttributeInfo DullCopper, ShadowIron, Copper, Bronze, Golden, Agapite, Verite, Valorite;
        public static readonly CraftAttributeInfo LupusLeather, ReptilienLeather, GeantLeather, OphidienLeather, ArachnideLeather, DragoniqueLeather, DemoniaqueLeather, AncienLeather;
        public static readonly CraftAttributeInfo RedScales, YellowScales, BlackScales, GreenScales, WhiteScales, BlueScales;
        public static readonly CraftAttributeInfo OakWood, AshWood, YewWood, Heartwood, Bloodwood, Frostwood;
		public static readonly CraftAttributeInfo LupusBone, ReptilienBone, GeantBone, OphidienBone, ArachnideBone, DragoniqueBone, DemoniaqueBone, AncienBone;

		static CraftAttributeInfo()
        {
            Blank = new CraftAttributeInfo();

            CraftAttributeInfo dullCopper = DullCopper = new CraftAttributeInfo();

            dullCopper.ArmorPhysicalResist = 0;
            dullCopper.ArmorDurability = 50;
            dullCopper.ArmorLowerRequirements = 20;
            dullCopper.WeaponDurability = 100;
            dullCopper.WeaponLowerRequirements = 50;
            dullCopper.RunicMinAttributes = 1;
            dullCopper.RunicMaxAttributes = 2;

            dullCopper.RunicMinIntensity = 40;
            dullCopper.RunicMaxIntensity = 100;

            CraftAttributeInfo shadowIron = ShadowIron = new CraftAttributeInfo();

            shadowIron.ArmorPhysicalResist = 0;
            shadowIron.ArmorFireResist = 2;
            shadowIron.ArmorEnergyResist = 7;
            shadowIron.ArmorDurability = 100;

            shadowIron.WeaponColdDamage = 20;
            shadowIron.WeaponDurability = 50;

            shadowIron.RunicMinAttributes = 2;
            shadowIron.RunicMaxAttributes = 2;

            shadowIron.RunicMinIntensity = 45;
            shadowIron.RunicMaxIntensity = 100;

            CraftAttributeInfo copper = Copper = new CraftAttributeInfo();

            copper.ArmorPhysicalResist = 0;
            copper.ArmorFireResist = 2;
            copper.ArmorPoisonResist = 7;
            copper.ArmorEnergyResist = 2;
            copper.WeaponPoisonDamage = 10;
            copper.WeaponEnergyDamage = 20;
            copper.RunicMinAttributes = 2;
            copper.RunicMaxAttributes = 3;

            copper.RunicMinIntensity = 50;
            copper.RunicMaxIntensity = 100;

            CraftAttributeInfo bronze = Bronze = new CraftAttributeInfo();

            bronze.ArmorPhysicalResist = 0;
            bronze.ArmorColdResist = 7;
            bronze.ArmorPoisonResist = 2;
            bronze.ArmorEnergyResist = 2;
            bronze.WeaponFireDamage = 40;
            bronze.RunicMinAttributes = 3;
            bronze.RunicMaxAttributes = 3;

            bronze.RunicMinIntensity = 55;
            bronze.RunicMaxIntensity = 100;

            CraftAttributeInfo golden = Golden = new CraftAttributeInfo();

            golden.ArmorPhysicalResist = 0;
            golden.ArmorFireResist = 2;
            golden.ArmorColdResist = 2;
            golden.ArmorEnergyResist = 3;
            golden.ArmorLuck = 40;
            golden.ArmorLowerRequirements = 30;
            golden.WeaponLuck = 40;
            golden.WeaponLowerRequirements = 50;
            golden.RunicMinAttributes = 3;
            golden.RunicMaxAttributes = 4;

            golden.RunicMinIntensity = 60;
            golden.RunicMaxIntensity = 100;

            CraftAttributeInfo agapite = Agapite = new CraftAttributeInfo();

            agapite.ArmorPhysicalResist = 1;
            agapite.ArmorFireResist = 7;
            agapite.ArmorColdResist = 2;
            agapite.ArmorPoisonResist = 2;
            agapite.ArmorEnergyResist = 2;
            agapite.WeaponColdDamage = 30;
            agapite.WeaponEnergyDamage = 20;
            agapite.RunicMinAttributes = 4;
            agapite.RunicMaxAttributes = 4;

            agapite.RunicMinIntensity = 65;
            agapite.RunicMaxIntensity = 100;

            CraftAttributeInfo verite = Verite = new CraftAttributeInfo();

            verite.ArmorPhysicalResist = 1;
            verite.ArmorFireResist = 4;
            verite.ArmorColdResist = 3;
            verite.ArmorPoisonResist = 4;
            verite.ArmorEnergyResist = 1;
            verite.WeaponPoisonDamage = 40;
            verite.WeaponEnergyDamage = 20;
            verite.RunicMinAttributes = 4;
            verite.RunicMaxAttributes = 5;

            verite.RunicMinIntensity = 70;
            verite.RunicMaxIntensity = 100;

            CraftAttributeInfo valorite = Valorite = new CraftAttributeInfo();

            valorite.ArmorPhysicalResist = 1;
            valorite.ArmorColdResist = 4;
            valorite.ArmorPoisonResist = 4;
            valorite.ArmorEnergyResist = 4;
            valorite.ArmorDurability = 50;
            valorite.WeaponFireDamage = 10;
            valorite.WeaponColdDamage = 20;
            valorite.WeaponPoisonDamage = 10;
            valorite.WeaponEnergyDamage = 20;
            valorite.RunicMinAttributes = 5;
            valorite.RunicMaxAttributes = 5;

            valorite.RunicMinIntensity = 85;
            valorite.RunicMaxIntensity = 100;

			// Cuir

			CraftAttributeInfo lupusLeather = LupusLeather = new CraftAttributeInfo();

			lupusLeather.ArmorPhysicalResist = 0;
			lupusLeather.ArmorDurability = 50;
			lupusLeather.ArmorLowerRequirements = 20;
			lupusLeather.WeaponDurability = 100;
			lupusLeather.WeaponLowerRequirements = 50;
			lupusLeather.RunicMinAttributes = 1;
			lupusLeather.RunicMaxAttributes = 2;

			lupusLeather.RunicMinIntensity = 40;
			lupusLeather.RunicMaxIntensity = 100;

			CraftAttributeInfo reptilienLeather = ReptilienLeather = new CraftAttributeInfo();

			reptilienLeather.ArmorPhysicalResist = 0;
			reptilienLeather.ArmorFireResist = 2;
			reptilienLeather.ArmorEnergyResist = 7;
			reptilienLeather.ArmorDurability = 100;

			reptilienLeather.WeaponColdDamage = 20;
			reptilienLeather.WeaponDurability = 50;

			reptilienLeather.RunicMinAttributes = 2;
			reptilienLeather.RunicMaxAttributes = 2;

			reptilienLeather.RunicMinIntensity = 45;
			reptilienLeather.RunicMaxIntensity = 100;

			CraftAttributeInfo geantLeather = GeantLeather = new CraftAttributeInfo();

			geantLeather.ArmorPhysicalResist = 0;
			geantLeather.ArmorFireResist = 2;
			geantLeather.ArmorPoisonResist = 7;
			geantLeather.ArmorEnergyResist = 2;
			geantLeather.WeaponPoisonDamage = 10;
			geantLeather.WeaponEnergyDamage = 20;
			geantLeather.RunicMinAttributes = 2;
			geantLeather.RunicMaxAttributes = 3;

			geantLeather.RunicMinIntensity = 50;
			geantLeather.RunicMaxIntensity = 100;

			CraftAttributeInfo ophidienLeather = OphidienLeather = new CraftAttributeInfo();

			ophidienLeather.ArmorPhysicalResist = 0;
			ophidienLeather.ArmorColdResist = 7;
			ophidienLeather.ArmorPoisonResist = 2;
			ophidienLeather.ArmorEnergyResist = 2;
			ophidienLeather.WeaponFireDamage = 40;
			ophidienLeather.RunicMinAttributes = 3;
			ophidienLeather.RunicMaxAttributes = 3;

			ophidienLeather.RunicMinIntensity = 55;
			ophidienLeather.RunicMaxIntensity = 100;

			CraftAttributeInfo arachnideLeather = ArachnideLeather = new CraftAttributeInfo();

			arachnideLeather.ArmorPhysicalResist = 0;
			arachnideLeather.ArmorFireResist = 2;
			arachnideLeather.ArmorColdResist = 2;
			arachnideLeather.ArmorEnergyResist = 3;
			arachnideLeather.ArmorLuck = 40;
			arachnideLeather.ArmorLowerRequirements = 30;
			arachnideLeather.WeaponLuck = 40;
			arachnideLeather.WeaponLowerRequirements = 50;
			arachnideLeather.RunicMinAttributes = 3;
			arachnideLeather.RunicMaxAttributes = 4;

			arachnideLeather.RunicMinIntensity = 60;
			arachnideLeather.RunicMaxIntensity = 100;

			CraftAttributeInfo dragoniqueLeather = DragoniqueLeather = new CraftAttributeInfo();

			dragoniqueLeather.ArmorPhysicalResist = 1;
			dragoniqueLeather.ArmorFireResist = 7;
			dragoniqueLeather.ArmorColdResist = 2;
			dragoniqueLeather.ArmorPoisonResist = 2;
			dragoniqueLeather.ArmorEnergyResist = 2;
			dragoniqueLeather.WeaponColdDamage = 30;
			dragoniqueLeather.WeaponEnergyDamage = 20;
			dragoniqueLeather.RunicMinAttributes = 4;
			dragoniqueLeather.RunicMaxAttributes = 4;

			dragoniqueLeather.RunicMinIntensity = 65;
			dragoniqueLeather.RunicMaxIntensity = 100;

			CraftAttributeInfo demoniaqueLeather = DemoniaqueLeather = new CraftAttributeInfo();

			demoniaqueLeather.ArmorPhysicalResist = 1;
			demoniaqueLeather.ArmorFireResist = 4;
			demoniaqueLeather.ArmorColdResist = 3;
			demoniaqueLeather.ArmorPoisonResist = 4;
			demoniaqueLeather.ArmorEnergyResist = 1;
			demoniaqueLeather.WeaponPoisonDamage = 40;
			demoniaqueLeather.WeaponEnergyDamage = 20;
			demoniaqueLeather.RunicMinAttributes = 4;
			demoniaqueLeather.RunicMaxAttributes = 5;

			demoniaqueLeather.RunicMinIntensity = 70;
			demoniaqueLeather.RunicMaxIntensity = 100;

			CraftAttributeInfo ancienLeather = AncienLeather = new CraftAttributeInfo();

			ancienLeather.ArmorPhysicalResist = 1;
			ancienLeather.ArmorColdResist = 4;
			ancienLeather.ArmorPoisonResist = 4;
			ancienLeather.ArmorEnergyResist = 4;
			ancienLeather.ArmorDurability = 50;
			ancienLeather.WeaponFireDamage = 10;
			ancienLeather.WeaponColdDamage = 20;
			ancienLeather.WeaponPoisonDamage = 10;
			ancienLeather.WeaponEnergyDamage = 20;
			ancienLeather.RunicMinAttributes = 5;
			ancienLeather.RunicMaxAttributes = 5;

			ancienLeather.RunicMinIntensity = 85;
			ancienLeather.RunicMaxIntensity = 100;

			// Os

			CraftAttributeInfo lupusBone = LupusBone = new CraftAttributeInfo();

			lupusBone.ArmorPhysicalResist = 1;
			lupusBone.ArmorDurability = 50;
			lupusBone.ArmorLowerRequirements = 20;
			lupusBone.WeaponDurability = 100;
			lupusBone.WeaponLowerRequirements = 50;
			lupusBone.RunicMinAttributes = 1;
			lupusBone.RunicMaxAttributes = 2;

			lupusBone.RunicMinIntensity = 40;
			lupusBone.RunicMaxIntensity = 100;

			CraftAttributeInfo reptilienBone = ReptilienBone = new CraftAttributeInfo();

			reptilienBone.ArmorPhysicalResist = 3;
			reptilienBone.ArmorFireResist = 2;
			reptilienBone.ArmorEnergyResist = 7;
			reptilienBone.ArmorDurability = 100;

			reptilienBone.WeaponColdDamage = 20;
			reptilienBone.WeaponDurability = 50;

			reptilienBone.RunicMinAttributes = 2;
			reptilienBone.RunicMaxAttributes = 2;

			reptilienBone.RunicMinIntensity = 45;
			reptilienBone.RunicMaxIntensity = 100;

			CraftAttributeInfo geantBone = GeantBone = new CraftAttributeInfo();

			geantBone.ArmorPhysicalResist = 2;
			geantBone.ArmorFireResist = 2;
			geantBone.ArmorPoisonResist = 7;
			geantBone.ArmorEnergyResist = 2;
			geantBone.WeaponPoisonDamage = 10;
			geantBone.WeaponEnergyDamage = 20;
			geantBone.RunicMinAttributes = 2;
			geantBone.RunicMaxAttributes = 3;

			geantBone.RunicMinIntensity = 50;
			geantBone.RunicMaxIntensity = 100;

			CraftAttributeInfo ophidienBone = OphidienBone = new CraftAttributeInfo();

			ophidienBone.ArmorPhysicalResist = 3;
			ophidienBone.ArmorColdResist = 7;
			ophidienBone.ArmorPoisonResist = 2;
			ophidienBone.ArmorEnergyResist = 2;
			ophidienBone.WeaponFireDamage = 40;
			ophidienBone.RunicMinAttributes = 3;
			ophidienBone.RunicMaxAttributes = 3;

			ophidienBone.RunicMinIntensity = 55;
			ophidienBone.RunicMaxIntensity = 100;

			CraftAttributeInfo arachnideBone = ArachnideBone = new CraftAttributeInfo();

			arachnideBone.ArmorPhysicalResist = 2;
			arachnideBone.ArmorFireResist = 2;
			arachnideBone.ArmorColdResist = 2;
			arachnideBone.ArmorEnergyResist = 3;
			arachnideBone.ArmorLuck = 40;
			arachnideBone.ArmorLowerRequirements = 30;
			arachnideBone.WeaponLuck = 40;
			arachnideBone.WeaponLowerRequirements = 50;
			arachnideBone.RunicMinAttributes = 3;
			arachnideBone.RunicMaxAttributes = 4;

			arachnideBone.RunicMinIntensity = 60;
			arachnideBone.RunicMaxIntensity = 100;

			CraftAttributeInfo dragoniqueBone = DragoniqueBone = new CraftAttributeInfo();

			dragoniqueBone.ArmorPhysicalResist = 2;
			dragoniqueBone.ArmorFireResist = 7;
			dragoniqueBone.ArmorColdResist = 2;
			dragoniqueBone.ArmorPoisonResist = 2;
			dragoniqueBone.ArmorEnergyResist = 2;
			dragoniqueBone.WeaponColdDamage = 30;
			dragoniqueBone.WeaponEnergyDamage = 20;
			dragoniqueBone.RunicMinAttributes = 4;
			dragoniqueBone.RunicMaxAttributes = 4;

			dragoniqueBone.RunicMinIntensity = 65;
			dragoniqueBone.RunicMaxIntensity = 100;

			CraftAttributeInfo demoniaqueBone = DemoniaqueBone = new CraftAttributeInfo();

			demoniaqueBone.ArmorPhysicalResist = 4;
			demoniaqueBone.ArmorFireResist = 4;
			demoniaqueBone.ArmorColdResist = 3;
			demoniaqueBone.ArmorPoisonResist = 4;
			demoniaqueBone.ArmorEnergyResist = 1;
			demoniaqueBone.WeaponPoisonDamage = 40;
			demoniaqueBone.WeaponEnergyDamage = 20;
			demoniaqueBone.RunicMinAttributes = 4;
			demoniaqueBone.RunicMaxAttributes = 5;

			demoniaqueBone.RunicMinIntensity = 70;
			demoniaqueBone.RunicMaxIntensity = 100;

			CraftAttributeInfo ancienBone = AncienBone = new CraftAttributeInfo();

			ancienBone.ArmorPhysicalResist = 5;
			ancienBone.ArmorColdResist = 4;
			ancienBone.ArmorPoisonResist = 4;
			ancienBone.ArmorEnergyResist = 4;
			ancienBone.ArmorDurability = 50;
			ancienBone.WeaponFireDamage = 10;
			ancienBone.WeaponColdDamage = 20;
			ancienBone.WeaponPoisonDamage = 10;
			ancienBone.WeaponEnergyDamage = 20;
			ancienBone.RunicMinAttributes = 5;
			ancienBone.RunicMaxAttributes = 5;

			ancienBone.RunicMinIntensity = 85;
			ancienBone.RunicMaxIntensity = 100;


			CraftAttributeInfo red = RedScales = new CraftAttributeInfo();
            red.ArmorPhysicalResist = 1;
            red.ArmorFireResist = 11;
            red.ArmorColdResist = -3;
            red.ArmorPoisonResist = 1;
            red.ArmorEnergyResist = 1;

            CraftAttributeInfo yellow = YellowScales = new CraftAttributeInfo();

            yellow.ArmorPhysicalResist = -3;
            yellow.ArmorFireResist = 1;
            yellow.ArmorColdResist = 1;
            yellow.ArmorPoisonResist = 1;
            yellow.ArmorPoisonResist = 1;
            yellow.ArmorLuck = 20;

            CraftAttributeInfo black = BlackScales = new CraftAttributeInfo();

            black.ArmorPhysicalResist = 11;
            black.ArmorEnergyResist = -3;
            black.ArmorFireResist = 1;
            black.ArmorPoisonResist = 1;
            black.ArmorColdResist = 1;

            CraftAttributeInfo green = GreenScales = new CraftAttributeInfo();

            green.ArmorFireResist = -3;
            green.ArmorPhysicalResist = 1;
            green.ArmorColdResist = 1;
            green.ArmorEnergyResist = 1;
            green.ArmorPoisonResist = 11;

            CraftAttributeInfo white = WhiteScales = new CraftAttributeInfo();

            white.ArmorPhysicalResist = -3;
            white.ArmorFireResist = 1;
            white.ArmorEnergyResist = 1;
            white.ArmorPoisonResist = 1;
            white.ArmorColdResist = 11;

            CraftAttributeInfo blue = BlueScales = new CraftAttributeInfo();

            blue.ArmorPhysicalResist = 1;
            blue.ArmorFireResist = 1;
            blue.ArmorColdResist = 1;
            blue.ArmorPoisonResist = -3;
            blue.ArmorEnergyResist = 11;

            #region Mondain's Legacy
            CraftAttributeInfo oak = OakWood = new CraftAttributeInfo();

            oak.ArmorPhysicalResist = 3;
            oak.ArmorFireResist = 3;
            oak.ArmorPoisonResist = 2;
            oak.ArmorEnergyResist = 3;
            oak.ArmorLuck = 40;

            oak.ShieldPhysicalResist = 1;
            oak.ShieldFireResist = 1;
            oak.ShieldColdResist = 1;
            oak.ShieldPoisonResist = 1;
            oak.ShieldEnergyResist = 1;

            oak.WeaponLuck = 40;
            oak.WeaponDamage = 5;

            oak.RunicMinAttributes = 1;
            oak.RunicMaxAttributes = 2;
            oak.RunicMinIntensity = 1;
            oak.RunicMaxIntensity = 50;

            CraftAttributeInfo ash = AshWood = new CraftAttributeInfo();

            ash.ArmorPhysicalResist = 2;
            ash.ArmorColdResist = 4;
            ash.ArmorPoisonResist = 1;
            ash.ArmorEnergyResist = 6;
            ash.ArmorLowerRequirements = 20;

            ash.ShieldEnergyResist = 3;
            ash.ShieldLowerRequirements = 3;

            ash.WeaponSwingSpeed = 10;
            ash.WeaponLowerRequirements = 20;

            ash.OtherLowerRequirements = 20;

            ash.RunicMinAttributes = 2;
            ash.RunicMaxAttributes = 3;
            ash.RunicMinIntensity = 35;
            ash.RunicMaxIntensity = 75;

            CraftAttributeInfo yew = YewWood = new CraftAttributeInfo();

            yew.ArmorPhysicalResist = 6;
            yew.ArmorFireResist = 3;
            yew.ArmorColdResist = 3;
            yew.ArmorEnergyResist = 3;
            yew.ArmorRegenHits = 1;

            yew.ShieldPhysicalResist = 3;
            yew.ShieldRegenHits = 1;

            yew.WeaponHitChance = 5;
            yew.WeaponDamage = 10;

            yew.OtherRegenHits = 2;

            yew.RunicMinAttributes = 3;
            yew.RunicMaxAttributes = 3;
            yew.RunicMinIntensity = 40;
            yew.RunicMaxIntensity = 90;

            CraftAttributeInfo heartwood = Heartwood = new CraftAttributeInfo();

            heartwood.ArmorPhysicalResist = 2;
            heartwood.ArmorFireResist = 3;
            heartwood.ArmorColdResist = 2;
            heartwood.ArmorPoisonResist = 7;
            heartwood.ArmorEnergyResist = 2;

            // one of below
            heartwood.ArmorDamage = 10;
            heartwood.ArmorHitChance = 5;
            heartwood.ArmorLuck = 40;
            heartwood.ArmorLowerRequirements = 20;
            heartwood.ArmorMage = 1;

            // one of below
            heartwood.WeaponDamage = 10;
            heartwood.WeaponHitChance = 5;
            heartwood.WeaponHitLifeLeech = 13;
            heartwood.WeaponLuck = 40;
            heartwood.WeaponLowerRequirements = 20;
            heartwood.WeaponSwingSpeed = 10;

            heartwood.ShieldBonusDex = 2;
            heartwood.ShieldBonusStr = 2;
            heartwood.ShieldPhysicalRandom = 5;
            heartwood.ShieldReflectPhys = 5;
            heartwood.ShieldSelfRepair = 2;
            heartwood.ShieldColdRandom = 3;
            heartwood.ShieldSpellChanneling = 1;

            heartwood.RunicMinAttributes = 4;
            heartwood.RunicMaxAttributes = 4;
            heartwood.RunicMinIntensity = 50;
            heartwood.RunicMaxIntensity = 100;

            CraftAttributeInfo bloodwood = Bloodwood = new CraftAttributeInfo();

            bloodwood.ArmorPhysicalResist = 3;
            bloodwood.ArmorFireResist = 8;
            bloodwood.ArmorColdResist = 1;
            bloodwood.ArmorPoisonResist = 3;
            bloodwood.ArmorEnergyResist = 3;
            bloodwood.ArmorRegenHits = 2;

            bloodwood.ShieldFireResist = 3;
            bloodwood.ShieldLuck = 40;
            bloodwood.ShieldRegenHits = 2;

            bloodwood.WeaponRegenHits = 2;
            bloodwood.WeaponHitLifeLeech = 16;

            bloodwood.OtherLuck = 20;
            bloodwood.OtherRegenHits = 2;

            CraftAttributeInfo frostwood = Frostwood = new CraftAttributeInfo();

            frostwood.ArmorPhysicalResist = 2;
            frostwood.ArmorFireResist = 1;
            frostwood.ArmorColdResist = 8;
            frostwood.ArmorPoisonResist = 3;
            frostwood.ArmorEnergyResist = 4;

            frostwood.ShieldColdResist = 3;
            frostwood.ShieldSpellChanneling = 1;

            frostwood.WeaponColdDamage = 40;
            frostwood.WeaponDamage = 12;

            frostwood.OtherSpellChanneling = 1;
            #endregion
        }
    }

    public class CraftResourceInfo
    {
        private readonly int m_Hue;
        private readonly int m_Number;
        private readonly string m_Name;
        private readonly CraftAttributeInfo m_AttributeInfo;
        private readonly CraftResource m_Resource;
        private readonly Type[] m_ResourceTypes;

        public int Hue => m_Hue;
        public int Number => m_Number;
        public string Name => m_Name;
        public CraftAttributeInfo AttributeInfo => m_AttributeInfo;
        public CraftResource Resource => m_Resource;
        public Type[] ResourceTypes => m_ResourceTypes;

        public CraftResourceInfo(int hue, int number, string name, CraftAttributeInfo attributeInfo, CraftResource resource, params Type[] resourceTypes)
        {
            m_Hue = hue;
            m_Number = number;
            m_Name = name;
            m_AttributeInfo = attributeInfo;
            m_Resource = resource;
            m_ResourceTypes = resourceTypes;

            for (int i = 0; i < resourceTypes.Length; ++i)
                CraftResources.RegisterType(resourceTypes[i], resource);
        }
    }

    public class CraftResources
    {
        private static readonly CraftResourceInfo[] m_MetalInfo = new[]
        {
            new CraftResourceInfo(0x000, 1053109, "Iron", CraftAttributeInfo.Blank, CraftResource.Iron, typeof(IronIngot), typeof(IronOre), typeof(Granite)),
            new CraftResourceInfo(0x973, 1053108, "Dull Copper",    CraftAttributeInfo.DullCopper,  CraftResource.DullCopper, typeof(DullCopperIngot),  typeof(DullCopperOre),  typeof(DullCopperGranite)),
            new CraftResourceInfo(0x966, 1053107, "Shadow Iron",    CraftAttributeInfo.ShadowIron,  CraftResource.ShadowIron, typeof(ShadowIronIngot),  typeof(ShadowIronOre),  typeof(ShadowIronGranite)),
            new CraftResourceInfo(0x96D, 1053106, "Copper", CraftAttributeInfo.Copper, CraftResource.Copper, typeof(CopperIngot), typeof(CopperOre), typeof(CopperGranite)),
            new CraftResourceInfo(0x972, 1053105, "Bronze", CraftAttributeInfo.Bronze, CraftResource.Bronze, typeof(BronzeIngot), typeof(BronzeOre), typeof(BronzeGranite)),
            new CraftResourceInfo(0x8A5, 1053104, "Gold", CraftAttributeInfo.Golden, CraftResource.Gold, typeof(GoldIngot), typeof(GoldOre), typeof(GoldGranite)),
            new CraftResourceInfo(0x979, 1053103, "Agapite", CraftAttributeInfo.Agapite, CraftResource.Agapite, typeof(AgapiteIngot), typeof(AgapiteOre), typeof(AgapiteGranite)),
            new CraftResourceInfo(0x89F, 1053102, "Verite", CraftAttributeInfo.Verite, CraftResource.Verite, typeof(VeriteIngot), typeof(VeriteOre), typeof(VeriteGranite)),
            new CraftResourceInfo(0x8AB, 1053101, "Valorite", CraftAttributeInfo.Valorite,  CraftResource.Valorite, typeof(ValoriteIngot),  typeof(ValoriteOre), typeof(ValoriteGranite)),
        };

        private static readonly CraftResourceInfo[] m_ScaleInfo = new[]
        {
            new CraftResourceInfo(0x66D, 1053129, "Red Scales", CraftAttributeInfo.RedScales, CraftResource.RedScales, typeof(RedScales)),
            new CraftResourceInfo(0x8A8, 1053130, "Yellow Scales",  CraftAttributeInfo.YellowScales,    CraftResource.YellowScales, typeof(YellowScales)),
            new CraftResourceInfo(0x455, 1053131, "Black Scales",   CraftAttributeInfo.BlackScales, CraftResource.BlackScales, typeof(BlackScales)),
            new CraftResourceInfo(0x851, 1053132, "Green Scales",   CraftAttributeInfo.GreenScales, CraftResource.GreenScales, typeof(GreenScales)),
            new CraftResourceInfo(0x8FD, 1053133, "White Scales",   CraftAttributeInfo.WhiteScales, CraftResource.WhiteScales, typeof(WhiteScales)),
            new CraftResourceInfo(0x8B0, 1053134, "Blue Scales",    CraftAttributeInfo.BlueScales, CraftResource.BlueScales, typeof(BlueScales)),
        };

        private static readonly CraftResourceInfo[] m_AOSLeatherInfo = new[]
        {
            new CraftResourceInfo(0x000, 1049353, "Normal", CraftAttributeInfo.Blank, CraftResource.RegularLeather, typeof(Leather), typeof(Hides)),
			new CraftResourceInfo( 1106, 1049356, "Lupus", CraftAttributeInfo.LupusLeather,            CraftResource.LupusLeather,     typeof( LupusLeather ),     typeof( LupusHides ) ),
			new CraftResourceInfo( 1438, 1049354, "Reptilien", CraftAttributeInfo.ReptilienLeather,      CraftResource.ReptilienLeather, typeof( ReptilienLeather ), typeof( ReptilienHides ) ),
			new CraftResourceInfo( 1711, 1049356, "Geant", CraftAttributeInfo.GeantLeather,          CraftResource.GeantLeather,     typeof( GeantLeather ),     typeof( GeantHides ) ),
			new CraftResourceInfo( 1635, 1049356, "Ophidien", CraftAttributeInfo.OphidienLeather,       CraftResource.OphidienLeather,  typeof( OphidienLeather ),  typeof( OphidienHides ) ),
			new CraftResourceInfo( 2128, 1049356, "Arachnide", CraftAttributeInfo.ArachnideLeather,      CraftResource.ArachnideLeather, typeof( ArachnideLeather ), typeof( ArachnideHides ) ),
			new CraftResourceInfo( 2174, 1049356, "Dragonique", CraftAttributeInfo.DragoniqueLeather,     CraftResource.DragoniqueLeather,typeof( DragoniqueLeather ),typeof( DragoniqueHides ) ),
			new CraftResourceInfo( 2118, 1049356, "Demoniaque", CraftAttributeInfo.DemoniaqueLeather,     CraftResource.DemoniaqueLeather,typeof( DemoniaqueLeather ),typeof( DemoniaqueHides ) ),
			new CraftResourceInfo( 1940, 1049356, "Ancien", CraftAttributeInfo.AncienLeather,         CraftResource.AncienLeather,    typeof( AncienLeather ),    typeof( AncienHides ) ),


		};

		private static readonly CraftResourceInfo[] m_BoneInfo = new[]
	   {
			new CraftResourceInfo(0x000, 1049353, "Normal", CraftAttributeInfo.Blank, CraftResource.RegularBone, typeof(Bone)),
			new CraftResourceInfo( 1106, 1049356, "Lupus", CraftAttributeInfo.LupusBone,            CraftResource.LupusBone,     typeof( LupusBone )),
			new CraftResourceInfo( 1438, 1049354, "Reptilien", CraftAttributeInfo.ReptilienBone,      CraftResource.ReptilienBone, typeof( ReptilienBone ) ),
			new CraftResourceInfo( 1711, 1049356, "Geant", CraftAttributeInfo.GeantBone,          CraftResource.GeantBone,     typeof( GeantBone ) ),
			new CraftResourceInfo( 1635, 1049356, "Ophidien", CraftAttributeInfo.OphidienBone,       CraftResource.OphidienBone,  typeof( OphidienBone ) ),
			new CraftResourceInfo( 2128, 1049356, "Arachnide", CraftAttributeInfo.ArachnideBone,      CraftResource.ArachnideBone, typeof( ArachnideBone ) ),
			new CraftResourceInfo( 2174, 1049356, "Dragonique", CraftAttributeInfo.DragoniqueBone,     CraftResource.DragoniqueBone,typeof( DragoniqueBone ) ),
			new CraftResourceInfo( 2118, 1049356, "Demoniaque", CraftAttributeInfo.DemoniaqueBone,     CraftResource.DemoniaqueBone,typeof( DemoniaqueBone ) ),
			new CraftResourceInfo( 1940, 1049356, "Ancien", CraftAttributeInfo.AncienBone,         CraftResource.AncienBone,    typeof( AncienBone )),


		};

		private static readonly CraftResourceInfo[] m_WoodInfo = new[]
        {
            new CraftResourceInfo(0x000, 1011542, "Normal", CraftAttributeInfo.Blank, CraftResource.RegularWood,    typeof(Log), typeof(Board)),
            new CraftResourceInfo(0x7DA, 1072533, "Oak", CraftAttributeInfo.OakWood, CraftResource.OakWood, typeof(OakLog), typeof(OakBoard)),
            new CraftResourceInfo(0x4A7, 1072534, "Ash", CraftAttributeInfo.AshWood, CraftResource.AshWood, typeof(AshLog), typeof(AshBoard)),
            new CraftResourceInfo(0x4A8, 1072535, "Yew", CraftAttributeInfo.YewWood, CraftResource.YewWood, typeof(YewLog), typeof(YewBoard)),
            new CraftResourceInfo(0x4A9, 1072536, "Heartwood", CraftAttributeInfo.Heartwood,    CraftResource.Heartwood,    typeof(HeartwoodLog),   typeof(HeartwoodBoard)),
            new CraftResourceInfo(0x4AA, 1072538, "Bloodwood", CraftAttributeInfo.Bloodwood,    CraftResource.Bloodwood,    typeof(BloodwoodLog),   typeof(BloodwoodBoard)),
            new CraftResourceInfo(0x47F, 1072539, "Frostwood", CraftAttributeInfo.Frostwood,    CraftResource.Frostwood,    typeof(FrostwoodLog),   typeof(FrostwoodBoard)),
        };

        /// <summary>
        /// Returns true if '<paramref name="resource"/>' is None, Iron, RegularLeather or RegularWood. False if otherwise.
        /// </summary>
        public static bool IsStandard(CraftResource resource)
        {
            return (resource == CraftResource.None || resource == CraftResource.Iron || resource == CraftResource.RegularLeather || resource == CraftResource.RegularWood);
        }

        private static Hashtable m_TypeTable;

        /// <summary>
        /// Registers that '<paramref name="resourceType"/>' uses '<paramref name="resource"/>' so that it can later be queried by <see cref="GetFromType"/>
        /// </summary>
        public static void RegisterType(Type resourceType, CraftResource resource)
        {
            if (m_TypeTable == null)
                m_TypeTable = new Hashtable();

            m_TypeTable[resourceType] = resource;
        }

        /// <summary>
        /// Returns the <see cref="CraftResource"/> value for which '<paramref name="resourceType"/>' uses -or- CraftResource.None if an unregistered type was specified.
        /// </summary>
        public static CraftResource GetFromType(Type resourceType)
        {
            if (m_TypeTable == null)
                return CraftResource.None;

            object obj = m_TypeTable[resourceType];

            if (!(obj is CraftResource))
                return CraftResource.None;

            return (CraftResource)obj;
        }

        /// <summary>
        /// Returns a <see cref="CraftResourceInfo"/> instance describing '<paramref name="resource"/>' -or- null if an invalid resource was specified.
        /// </summary>
        public static CraftResourceInfo GetInfo(CraftResource resource)
        {
            CraftResourceInfo[] list = null;

            switch (GetType(resource))
            {
                case CraftResourceType.Metal:
                    list = m_MetalInfo;
                    break;
                case CraftResourceType.Leather:
                    list = m_AOSLeatherInfo;
                    break;
                case CraftResourceType.Scales:
                    list = m_ScaleInfo;
                    break;
                case CraftResourceType.Wood:
                    list = m_WoodInfo;
                    break;
				case CraftResourceType.Bone:
					list = m_BoneInfo;
					break;
			}

            if (list != null)
            {
                int index = GetIndex(resource);

                if (index >= 0 && index < list.Length)
                    return list[index];
            }

            return null;
        }

        /// <summary>
        /// Returns a <see cref="CraftResourceType"/> value indiciating the type of '<paramref name="resource"/>'.
        /// </summary>
        public static CraftResourceType GetType(CraftResource resource)
        {
            if (resource >= CraftResource.Iron && resource <= CraftResource.Valorite)
                return CraftResourceType.Metal;

            if (resource >= CraftResource.RegularLeather && resource <= CraftResource.AncienLeather)
                return CraftResourceType.Leather;

            if (resource >= CraftResource.RedScales && resource <= CraftResource.BlueScales)
                return CraftResourceType.Scales;

            if (resource >= CraftResource.RegularWood && resource <= CraftResource.Frostwood)
                return CraftResourceType.Wood;

			if (resource >= CraftResource.RegularBone && resource <= CraftResource.AncienBone)
				return CraftResourceType.Bone;

			return CraftResourceType.None;
        }

        /// <summary>
        /// Returns the first <see cref="CraftResource"/> in the series of resources for which '<paramref name="resource"/>' belongs.
        /// </summary>
        public static CraftResource GetStart(CraftResource resource)
        {
            switch (GetType(resource))
            {
                case CraftResourceType.Metal:
                    return CraftResource.Iron;
                case CraftResourceType.Leather:
                    return CraftResource.RegularLeather;
                case CraftResourceType.Scales:
                    return CraftResource.RedScales;
                case CraftResourceType.Wood:
                    return CraftResource.RegularWood;
				case CraftResourceType.Bone:
					return CraftResource.RegularBone;
			}

            return CraftResource.None;
        }

        /// <summary>
        /// Returns the index of '<paramref name="resource"/>' in the seriest of resources for which it belongs.
        /// </summary>
        public static int GetIndex(CraftResource resource)
        {
            CraftResource start = GetStart(resource);

            if (start == CraftResource.None)
                return 0;

            return resource - start;
        }

        /// <summary>
        /// Returns the <see cref="CraftResourceInfo.Number"/> property of '<paramref name="resource"/>' -or- 0 if an invalid resource was specified.
        /// </summary>
        public static int GetLocalizationNumber(CraftResource resource)
        {
            CraftResourceInfo info = GetInfo(resource);

            return (info == null ? 0 : info.Number);
        }

        /// <summary>
        /// Returns the <see cref="CraftResourceInfo.Hue"/> property of '<paramref name="resource"/>' -or- 0 if an invalid resource was specified.
        /// </summary>
        public static int GetHue(CraftResource resource)
        {
            CraftResourceInfo info = GetInfo(resource);

            return (info == null ? 0 : info.Hue);
        }

        /// <summary>
        /// Returns the <see cref="CraftResourceInfo.Name"/> property of '<paramref name="resource"/>' -or- an empty string if the resource specified was invalid.
        /// </summary>
        public static string GetName(CraftResource resource)
        {
            CraftResourceInfo info = GetInfo(resource);

            return (info == null ? string.Empty : info.Name);
        }


		public static string GetDescription(CraftResource resource)
		{
			FieldInfo field = resource.GetType().GetField(resource.ToString());
			DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
			return attribute == null ? resource.ToString() : attribute.Description;
		}



		/// <summary>
		/// Returns the <see cref="CraftResource"/> value which represents '<paramref name="info"/>' -or- CraftResource.None if unable to convert.
		/// </summary>
		public static CraftResource GetFromOreInfo(OreInfo info)
        {
            if (info.Name.IndexOf("Lupus") >= 0)
                return CraftResource.LupusLeather;
            else if (info.Name.IndexOf("Reptilien") >= 0)
                return CraftResource.ReptilienLeather;
            else if (info.Name.IndexOf("Geant") >= 0)
                return CraftResource.GeantLeather;

			else if (info.Name.IndexOf("Ophidien") >= 0)
				return CraftResource.OphidienLeather;
			else if (info.Name.IndexOf("Arachnide") >= 0)
				return CraftResource.ArachnideLeather;
			else if (info.Name.IndexOf("Dragonique") >= 0)
				return CraftResource.DragoniqueLeather;
			else if (info.Name.IndexOf("Demoniaque") >= 0)
				return CraftResource.DemoniaqueLeather;
			else if (info.Name.IndexOf("Ancien") >= 0)
				return CraftResource.AncienLeather;


			else if (info.Name.IndexOf("Leather") >= 0)
                return CraftResource.RegularLeather;

            if (info.Level == 0)
                return CraftResource.Iron;
            else if (info.Level == 1)
                return CraftResource.DullCopper;
            else if (info.Level == 2)
                return CraftResource.ShadowIron;
            else if (info.Level == 3)
                return CraftResource.Copper;
            else if (info.Level == 4)
                return CraftResource.Bronze;
            else if (info.Level == 5)
                return CraftResource.Gold;
            else if (info.Level == 6)
                return CraftResource.Agapite;
            else if (info.Level == 7)
                return CraftResource.Verite;
            else if (info.Level == 8)
                return CraftResource.Valorite;

            return CraftResource.None;
        }

        /// <summary>
        /// Returns the <see cref="CraftResource"/> value which represents '<paramref name="info"/>', using '<paramref name="material"/>' to help resolve leather OreInfo instances.
        /// </summary>
        public static CraftResource GetFromOreInfo(OreInfo info, ArmorMaterialType material)
        {
            if (material == ArmorMaterialType.Studded || material == ArmorMaterialType.Leather )
            {
                if (info.Level == 0)
                    return CraftResource.RegularLeather;
                else if (info.Level == 1)
                    return CraftResource.LupusLeather;
                else if (info.Level == 2)
                    return CraftResource.ReptilienLeather;
                else if (info.Level == 3)
                    return CraftResource.GeantLeather;
				else if (info.Level == 4)
					return CraftResource.OphidienLeather;
				else if (info.Level == 5)
					return CraftResource.ArachnideLeather;
				else if (info.Level == 6)
					return CraftResource.DragoniqueLeather;
				else if (info.Level == 7)
					return CraftResource.DemoniaqueLeather;
				else if (info.Level == 8)
					return CraftResource.AncienLeather;
				else if (info.Level == 9)

				return CraftResource.None;
            }

            return GetFromOreInfo(info);
        }
    }

    // NOTE: This class is only for compatability with very old RunUO versions.
    // No changes to it should be required for custom resources.
    public class OreInfo
    {
        public static readonly OreInfo Iron = new OreInfo(0, 0x000, "Iron");
        public static readonly OreInfo DullCopper = new OreInfo(1, 0x973, "Dull Copper");
        public static readonly OreInfo ShadowIron = new OreInfo(2, 0x966, "Shadow Iron");
        public static readonly OreInfo Copper = new OreInfo(3, 0x96D, "Copper");
        public static readonly OreInfo Bronze = new OreInfo(4, 0x972, "Bronze");
        public static readonly OreInfo Gold = new OreInfo(5, 0x8A5, "Gold");
        public static readonly OreInfo Agapite = new OreInfo(6, 0x979, "Agapite");
        public static readonly OreInfo Verite = new OreInfo(7, 0x89F, "Verite");
        public static readonly OreInfo Valorite = new OreInfo(8, 0x8AB, "Valorite");

        private readonly int m_Level;
        private readonly int m_Hue;
        private readonly string m_Name;

        public OreInfo(int level, int hue, string name)
        {
            m_Level = level;
            m_Hue = hue;
            m_Name = name;
        }

        public int Level => m_Level;

        public int Hue => m_Hue;

        public string Name => m_Name;
    }
}
