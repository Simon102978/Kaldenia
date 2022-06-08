using Server.Engines.Points;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Blackthorn
{
    public class AgentOfTheCrown : BaseTurnInMobile
    {
        public override int TitleLocalization => 1154520;  // Click a minor artifact to turn in for reward points.
        public override int CancelLocalization => 1154519; 	// Bring me items bearing the crest of Minax and I will reward you with valuable items.     
        public override int TurnInLocalization => 1154571;  // Turn In Minax Artifacts
        public override int ClaimLocalization => 1154572;  // Claim Blackthorn Artifacts

        [Constructable]
        public AgentOfTheCrown() : base("the Agent Of The Crown")
        {
        }

        public override void InitBody()
        {
            base.InitBody();

            Name = NameList.RandomName("male");

            Hue = Utility.RandomSkinHue();
            Body = 0x190;
            HairItemID = 0x2047;
            HairHue = 0x46D;
        }

        public override void InitOutfit()
        {
            SetWearable(new ChainChest(), 2106);
            SetWearable(new ThighBoots(), 2106);
            SetWearable(new Obi(), 1775);
            SetWearable(new BodySash(), 1775);
            SetWearable(new GoldRing());
            SetWearable(new Epaulette());

            // QuiverOfInfinityBase
            Item item = new CloakBearingTheCrestOfBlackthorn
            {
                Movable = false
            };
            PackItem(item);

            item = new ClothWingArmorBearingTheCrestOfBlackthorn
            {
                Movable = false
            };
            PackItem(item);

            // RoyalBritannianBase

            item = new DoubletBearingTheCrestOfBlackthorn
            {
                Movable = false
            };
            PackItem(item);

            item = new SashBearingTheCrestOfBlackthorn
            {
                Movable = false
            };
            PackItem(item);

            item = new SurcoatBearingTheCrestOfBlackthorn
            {
                Movable = false
            };
            PackItem(item);

            item = new TunicBearingTheCrestOfBlackthorn
            {
                Movable = false
            };
            PackItem(item);

            // RuneBeetleCarapaceBase

            item = new ChainmailTunicBearingTheCrestOfBlackthorn
            {
                Movable = false
            };
            PackItem(item);

            item = new DragonBreastplateBearingTheCrestOfBlackthorn
            {
                Movable = false
            };
            PackItem(item);

            item = new PlatemailChestBearingTheCrestOfBlackthorn
            {
                Movable = false
            };
            PackItem(item);


            item = new PlatemailTunicBearingTheCrestOfBlackthorn
            {
                Movable = false
            };
            PackItem(item);

            item = new RingmailTunicBearingTheCrestOfBlackthorn
            {
                Movable = false
            };
            PackItem(item);

            // ShroudOfTheCondemnedBase

            item = new EpauletteBearingTheCrestOfBlackthorn1
            {
                Movable = false
            };
            PackItem(item);

            item = new FancyDressBearingTheCrestOfBlackthorn1
            {
                Movable = false
            };
            PackItem(item);

            item = new FemaleKimonoBearingTheCrestOfBlackthorn1
            {
                Movable = false
            };
            PackItem(item);

            item = new EpauletteBearingTheCrestOfBlackthorn1
            {
                Movable = false
            };
            PackItem(item);

            item = new FancyBearingTheCrestOfBlackthorn1
            {
                Movable = false
            };
            PackItem(item);

            item = new RobeBearingTheCrestOfBlackthorn1
            {
                Movable = false
            };
            PackItem(item);


            item = new HoodedRobeBearingTheCrestOfBlackthorn1
            {
                Movable = false
            };
            PackItem(item);

            item = new MaleKimonoBearingTheCrestOfBlackthorn1
            {
                Movable = false
            };
            PackItem(item);

            item = new PlainDressBearingTheCrestOfBlackthorn1
            {
                Movable = false
            };
            PackItem(item);

            item = new RobeBearingTheCrestOfBlackthorn1
            {
                Movable = false
            };
            PackItem(item);

            // MysticsGarbBase

            item = new EpauletteBearingTheCrestOfBlackthorn2
            {
                Movable = false
            };
            PackItem(item);

            item = new FancyDressBearingTheCrestOfBlackthorn2
            {
                Movable = false
            };
            PackItem(item);

            item = new FemaleKimonoBearingTheCrestOfBlackthorn2
            {
                Movable = false
            };
            PackItem(item);

            item = new EpauletteBearingTheCrestOfBlackthorn2
            {
                Movable = false
            };
            PackItem(item);

            item = new FancyBearingTheCrestOfBlackthorn2
            {
                Movable = false
            };
            PackItem(item);

            item = new RobeBearingTheCrestOfBlackthorn2
            {
                Movable = false
            };
            PackItem(item);

            item = new HoodedRobeBearingTheCrestOfBlackthorn2
            {
                Movable = false
            };
            PackItem(item);

            item = new MaleKimonoBearingTheCrestOfBlackthorn2
            {
                Movable = false
            };
            PackItem(item);

            item = new PlainDressBearingTheCrestOfBlackthorn2
            {
                Movable = false
            };
            PackItem(item);

            item = new RobeBearingTheCrestOfBlackthorn2
            {
                Movable = false
            };
            PackItem(item);

            // CloakOfSilenceBase

            item = new EpauletteBearingTheCrestOfBlackthorn3
            {
                Movable = false
            };
            PackItem(item);

            item = new FancyDressBearingTheCrestOfBlackthorn3
            {
                Movable = false
            };
            PackItem(item);

            item = new FemaleKimonoBearingTheCrestOfBlackthorn3
            {
                Movable = false
            };
            PackItem(item);

            item = new EpauletteBearingTheCrestOfBlackthorn3
            {
                Movable = false
            };
            PackItem(item);

            item = new FancyBearingTheCrestOfBlackthorn3
            {
                Movable = false
            };
            PackItem(item);

            item = new RobeBearingTheCrestOfBlackthorn3
            {
                Movable = false
            };
            PackItem(item);

            item = new HoodedRobeBearingTheCrestOfBlackthorn3
            {
                Movable = false
            };
            PackItem(item);

            item = new MaleKimonoBearingTheCrestOfBlackthorn3
            {
                Movable = false
            };
            PackItem(item);

            item = new PlainDressBearingTheCrestOfBlackthorn3
            {
                Movable = false
            };
            PackItem(item);

            item = new RobeBearingTheCrestOfBlackthorn3
            {
                Movable = false
            };
            PackItem(item);

            // CloakOfPowerBase

            item = new EpauletteBearingTheCrestOfBlackthorn4
            {
                Movable = false
            };
            PackItem(item);

            item = new FancyDressBearingTheCrestOfBlackthorn4
            {
                Movable = false
            };
            PackItem(item);

            item = new FemaleKimonoBearingTheCrestOfBlackthorn4
            {
                Movable = false
            };
            PackItem(item);

            item = new EpauletteBearingTheCrestOfBlackthorn4
            {
                Movable = false
            };
            PackItem(item);

            item = new FancyBearingTheCrestOfBlackthorn4
            {
                Movable = false
            };
            PackItem(item);

            item = new RobeBearingTheCrestOfBlackthorn4
            {
                Movable = false
            };
            PackItem(item);

            item = new HoodedRobeBearingTheCrestOfBlackthorn4
            {
                Movable = false
            };
            PackItem(item);

            item = new MaleKimonoBearingTheCrestOfBlackthorn4
            {
                Movable = false
            };
            PackItem(item);

            item = new PlainDressBearingTheCrestOfBlackthorn4
            {
                Movable = false
            };
            PackItem(item);

            item = new RobeBearingTheCrestOfBlackthorn4
            {
                Movable = false
            };
            PackItem(item);

            // CloakOfLifeBase

            item = new EpauletteBearingTheCrestOfBlackthorn5
            {
                Movable = false
            };
            PackItem(item);

            item = new FancyDressBearingTheCrestOfBlackthorn5
            {
                Movable = false
            };
            PackItem(item);

            item = new FemaleKimonoBearingTheCrestOfBlackthorn5
            {
                Movable = false
            };
            PackItem(item);

            item = new EpauletteBearingTheCrestOfBlackthorn5
            {
                Movable = false
            };
            PackItem(item);

            item = new FancyBearingTheCrestOfBlackthorn5
            {
                Movable = false
            };
            PackItem(item);

            item = new RobeBearingTheCrestOfBlackthorn5
            {
                Movable = false
            };
            PackItem(item);



            item = new HoodedRobeBearingTheCrestOfBlackthorn5
            {
                Movable = false
            };
            PackItem(item);

            item = new MaleKimonoBearingTheCrestOfBlackthorn5
            {
                Movable = false
            };
            PackItem(item);

            item = new PlainDressBearingTheCrestOfBlackthorn5
            {
                Movable = false
            };
            PackItem(item);

            item = new RobeBearingTheCrestOfBlackthorn5
            {
                Movable = false
            };
            PackItem(item);

            // CloakOfDeathBase

            item = new EpauletteBearingTheCrestOfBlackthorn6
            {
                Movable = false
            };
            PackItem(item);

            item = new FancyDressBearingTheCrestOfBlackthorn6
            {
                Movable = false
            };
            PackItem(item);

            item = new FemaleKimonoBearingTheCrestOfBlackthorn6
            {
                Movable = false
            };
            PackItem(item);

            item = new EpauletteBearingTheCrestOfBlackthorn6
            {
                Movable = false
            };
            PackItem(item);

            item = new FancyBearingTheCrestOfBlackthorn6
            {
                Movable = false
            };
            PackItem(item);

            item = new RobeBearingTheCrestOfBlackthorn6
            {
                Movable = false
            };
            PackItem(item);

         

            item = new HoodedRobeBearingTheCrestOfBlackthorn6
            {
                Movable = false
            };
            PackItem(item);

            item = new MaleKimonoBearingTheCrestOfBlackthorn6
            {
                Movable = false
            };
            PackItem(item);

            item = new PlainDressBearingTheCrestOfBlackthorn6
            {
                Movable = false
            };
            PackItem(item);

            item = new RobeBearingTheCrestOfBlackthorn6
            {
                Movable = false
            };
            PackItem(item);

            // ConjurersGarbBase

            item = new EpauletteBearingTheCrestOfBlackthorn7
            {
                Movable = false
            };
            PackItem(item);

            item = new FancyDressBearingTheCrestOfBlackthorn7
            {
                Movable = false
            };
            PackItem(item);

            item = new FemaleKimonoBearingTheCrestOfBlackthorn7
            {
                Movable = false
            };
            PackItem(item);

            item = new EpauletteBearingTheCrestOfBlackthorn7
            {
                Movable = false
            };
            PackItem(item);

            item = new FancyBearingTheCrestOfBlackthorn7
            {
                Movable = false
            };
            PackItem(item);

            item = new RobeBearingTheCrestOfBlackthorn7
            {
                Movable = false
            };
            PackItem(item);


            item = new HoodedRobeBearingTheCrestOfBlackthorn7
            {
                Movable = false
            };
            PackItem(item);

            item = new MaleKimonoBearingTheCrestOfBlackthorn7
            {
                Movable = false
            };
            PackItem(item);

            item = new PlainDressBearingTheCrestOfBlackthorn7
            {
                Movable = false
            };
            PackItem(item);

            item = new RobeBearingTheCrestOfBlackthorn7
            {
                Movable = false
            };
            PackItem(item);

            // NightEyesBase

            item = new BandanaBearingTheCrestOfBlackthorn1
            {
                Movable = false
            };
            PackItem(item);

            item = new BascinetBearingTheCrestOfBlackthorn1
            {
                Movable = false
            };
            PackItem(item);

            item = new CircletBearingTheCrestOfBlackthorn1
            {
                Movable = false
            };
            PackItem(item);

            item = new FeatheredHatBearingTheCrestOfBlackthorn1
            {
                Movable = false
            };
            PackItem(item);

            item = new EarringsBearingTheCrestOfBlackthorn1
            {
                Movable = false
            };
            PackItem(item);

            item = new GlassesBearingTheCrestOfBlackthorn1
            {
                Movable = false
            };
            PackItem(item);

            item = new JesterHatBearingTheCrestOfBlackthorn1
            {
                Movable = false
            };
            PackItem(item);

            item = new NorseHelmBearingTheCrestOfBlackthorn1
            {
                Movable = false
            };
            PackItem(item);

            item = new PlateHelmBearingTheCrestOfBlackthorn1
            {
                Movable = false
            };
            PackItem(item);

            item = new RoyalCircletBearingTheCrestOfBlackthorn1
            {
                Movable = false
            };
            PackItem(item);

            item = new SkullcapBearingTheCrestOfBlackthorn1
            {
                Movable = false
            };
            PackItem(item);

            item = new TricorneHatBearingTheCrestOfBlackthorn1
            {
                Movable = false
            };
            PackItem(item);

            item = new WizardsHatBearingTheCrestOfBlackthorn1
            {
                Movable = false
            };
            PackItem(item);

            // MaceAndShieldBase

            item = new BandanaBearingTheCrestOfBlackthorn2
            {
                Movable = false
            };
            PackItem(item);

            item = new BascinetBearingTheCrestOfBlackthorn2
            {
                Movable = false
            };
            PackItem(item);

            item = new CircletBearingTheCrestOfBlackthorn2
            {
                Movable = false
            };
            PackItem(item);

            item = new FeatheredHatBearingTheCrestOfBlackthorn2
            {
                Movable = false
            };
            PackItem(item);

            item = new EarringsBearingTheCrestOfBlackthorn2
            {
                Movable = false
            };
            PackItem(item);

            item = new GlassesBearingTheCrestOfBlackthorn2
            {
                Movable = false
            };
            PackItem(item);

            item = new JesterHatBearingTheCrestOfBlackthorn2
            {
                Movable = false
            };
            PackItem(item);

            item = new NorseHelmBearingTheCrestOfBlackthorn2
            {
                Movable = false
            };
            PackItem(item);

            item = new PlateHelmBearingTheCrestOfBlackthorn2
            {
                Movable = false
            };
            PackItem(item);

            item = new RoyalCircletBearingTheCrestOfBlackthorn2
            {
                Movable = false
            };
            PackItem(item);

            item = new SkullcapBearingTheCrestOfBlackthorn2
            {
                Movable = false
            };
            PackItem(item);

            item = new TricorneHatBearingTheCrestOfBlackthorn2
            {
                Movable = false
            };
            PackItem(item);

            item = new WizardsHatBearingTheCrestOfBlackthorn2
            {
                Movable = false
            };
            PackItem(item);

            // FoldedSteelBase

            item = new BandanaBearingTheCrestOfBlackthorn3
            {
                Movable = false
            };
            PackItem(item);

            item = new BascinetBearingTheCrestOfBlackthorn3
            {
                Movable = false
            };
            PackItem(item);

            item = new CircletBearingTheCrestOfBlackthorn3
            {
                Movable = false
            };
            PackItem(item);

            item = new FeatheredHatBearingTheCrestOfBlackthorn3
            {
                Movable = false
            };
            PackItem(item);

            item = new EarringsBearingTheCrestOfBlackthorn3
            {
                Movable = false
            };
            PackItem(item);

            item = new GlassesBearingTheCrestOfBlackthorn3
            {
                Movable = false
            };
            PackItem(item);

            item = new JesterHatBearingTheCrestOfBlackthorn3
            {
                Movable = false
            };
            PackItem(item);

            item = new NorseHelmBearingTheCrestOfBlackthorn3
            {
                Movable = false
            };
            PackItem(item);

            item = new PlateHelmBearingTheCrestOfBlackthorn3
            {
                Movable = false
            };
            PackItem(item);

            item = new RoyalCircletBearingTheCrestOfBlackthorn3
            {
                Movable = false
            };
            PackItem(item);

            item = new SkullcapBearingTheCrestOfBlackthorn3
            {
                Movable = false
            };
            PackItem(item);

            item = new TricorneHatBearingTheCrestOfBlackthorn3
            {
                Movable = false
            };
            PackItem(item);

            item = new WizardsHatBearingTheCrestOfBlackthorn3
            {
                Movable = false
            };
            PackItem(item);

            // TangleBase

            item = new HalfApronBearingTheCrestOfBlackthorn1
            {
                Movable = false
            };
            PackItem(item);

            item = new LeatherNinjaBeltBearingTheCrestOfBlackthorn1
            {
                Movable = false
            };
            PackItem(item);

            item = new ObiBearingTheCrestOfBlackthorn1
            {
                Movable = false
            };
            PackItem(item);

            item = new WoodlandBeltBearingTheCrestOfBlackthorn1
            {
                Movable = false
            };
            PackItem(item);

            // CrimsonCinctureBase

            item = new HalfApronBearingTheCrestOfBlackthorn2
            {
                Movable = false
            };
            PackItem(item);

            item = new LeatherNinjaBeltBearingTheCrestOfBlackthorn2
            {
                Movable = false
            };
            PackItem(item);

            item = new ObiBearingTheCrestOfBlackthorn2
            {
                Movable = false
            };
            PackItem(item);

            item = new WoodlandBeltBearingTheCrestOfBlackthorn2
            {
                Movable = false
            };
            PackItem(item);
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            list.Add(1154517); // Minax Artifact Turn in Officer
        }

        public override void AwardPoints(PlayerMobile pm, Item item, int amount)
        {
            PointsSystem.Blackthorn.AwardPoints(pm, amount);
        }

        public override bool IsRedeemableItem(Item item)
        {
            if (item is BaseWeapon && ((BaseWeapon)item).ReforgedSuffix == ReforgedSuffix.Minax)
                return true;
            if (item is BaseArmor && ((BaseArmor)item).ReforgedSuffix == ReforgedSuffix.Minax)
                return true;
            if (item is BaseJewel && ((BaseJewel)item).ReforgedSuffix == ReforgedSuffix.Minax)
                return true;
            if (item is BaseClothing && ((BaseClothing)item).ReforgedSuffix == ReforgedSuffix.Minax)
                return true;

            return false;
        }

        public override void SendRewardGump(Mobile m)
        {
            if (m.Player && m.CheckAlive())
                m.SendGump(new BlackthornRewardGump(this, m as PlayerMobile));
        }

        public AgentOfTheCrown(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
