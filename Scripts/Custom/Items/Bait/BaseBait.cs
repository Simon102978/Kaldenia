using System;
using Server;
using Server.Items;
using Server.ContextMenus;
using System.Collections;
using System.Collections.Generic;

namespace Server
{
    public interface IFishingPole
    {
        Bait Bait { get; set; }
        int Charge { get; set; }
    }

    public enum Bait
    {
        Aucun,
		AutumnDragonfish,
		BlueLobster,
		BullFish,
		CrystalFish,
		FairySalmon,
		FireFish,
		GiantKoi,
		GreatBarracuda,
		HolyMackerel,
		LavaFish,
		ReaperFish,
		SpiderCrab,
		StoneCrab,
		SummerDragonfish,
		UnicornFish,
		YellowtailBarracuda,
		AbyssalDragonfish,
		BlackMarlin,
		BloodLobster,
		BlueMarlin,
		DreadLobster,
		DungeonPike,
		GiantSamuraiFish,
		GoldenTuna,
		Kingfish,
		LanternFish,
		RainbowFish,
		SeekerFish,
		SpringDragonfish,
		StoneFish,
		TunnelCrab,
		VoidCrab,
		VoidLobster,
		WinterDragonfish,
		ZombieFish
	}
}

namespace Server.ContextMenus
{
    public class ApplyBaitEntry : ContextMenuEntry
    {
        private Mobile m_From;
        private BaseBait m_Bait;

        public ApplyBaitEntry(Mobile from, BaseBait Bait) : base(90, 1)
        {
            m_From = from;
            m_Bait = Bait;
        }

        public override void OnClick()
        {
            if (m_Bait.Deleted || !m_Bait.Movable || !m_From.CheckAlive())
                return;

            m_From.SendMessage("Appliquer sur quelle canne à pêche?");
            m_From.BeginTarget(1, false, Server.Targeting.TargetFlags.None, new TargetStateCallback(Bait_OnApply), m_Bait);
        }

        private void Bait_OnApply(Mobile from, object targeted, object state)
        {
            if (targeted is IFishingPole)
            {
				BaseBait bait = state as BaseBait;
				IFishingPole pole = (IFishingPole)targeted;

				if (pole.Bait == Bait.Aucun && pole.Charge <= 0)
				{
					pole.Bait = bait.Bait;
					pole.Charge = bait.Charge;
					from.SendMessage("Vous accrochez l'appât après la canne à pêche.");

					bait.Delete();
				}
                else
                {
                    from.SendMessage("Cette canne à pêche possède déjà un appât.");
                }
            }
            else
            {
                from.SendMessage("Vous devez choisir une canne à pêche.");
            }
        }
    }
}

namespace Server.Items
{
    public abstract class BaseBait : Item
    {
        private Bait m_Bait;
        private int m_Charge;

        [CommandProperty(AccessLevel.GameMaster)]
        public Bait Bait
        {
            get { return m_Bait; }
            set { m_Bait = value; SetNewName(); InvalidateProperties();  }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Charge
        {
            get { return m_Charge; }
            set
            {
                m_Charge = value;

                if (m_Charge <= 0)
                    Delete();
                else if (m_Charge > 20)
                    m_Charge = 20;
            }
        }

        [Constructable]
        public BaseBait(Bait Bait, int charge) : base(0xDCE)
        {
            Name = "appât";
            Weight = 0.5;

            m_Bait = Bait;
            m_Charge = charge;
            Stackable = true;
        }

        public static string[] m_Material = new string[]
            {
		"aucun",
		"AutumnDragonfish",
		"BlueLobster",
		"BullFish",
		"CrystalFish",
		"FairySalmon",
		"FireFish",
		"GiantKoi",
		"GreatBarracuda",
		"HolyMackerel",
		"LavaFish",
		"ReaperFish",
		"SpiderCrab",
		"StoneCrab",
		"SummerDragonfish",
		"UnicornFish",
		"YellowtailBarracuda",
		"AbyssalDragonfish",
		"BlackMarlin",
		"BloodLobster",
		"BlueMarlin",
		"DreadLobster",
		"DungeonPike",
		"GiantSamuraiFish",
		"GoldenTuna",
		"Kingfish",
		"LanternFish",
		"RainbowFish",
		"SeekerFish",
		"SpringDragonfish",
		"StoneFish",
		"TunnelCrab",
		"VoidCrab",
		"VoidLobster",
		"WinterDragonfish",
		"ZombieFish",
			};

        public virtual string GetMaterial()
        {
            string value = "aucun";

            try
            {
                value = m_Material[((int)m_Bait)];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return value;
        }

		public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
		{
            if (from.Alive && IsChildOf(from.Backpack))
            {
                list.Add(new ApplyBaitEntry(from, this));
            }

            base.GetContextMenuEntries(from, list);
        }

        public void SetNewName()
        {
            Name = "Appât : " + m_Material;
        }

        public static BaseBait CreateBait(Bait Bait, int charge)
        {
            switch (Bait)
            {
                case Bait.AutumnDragonfish: return new BaitAutumnDragonfish(charge);
                case Bait.BlueLobster: return new BaitBlueLobster(charge);
                case Bait.BullFish: return new BaitBullFish(charge);
                case Bait.CrystalFish: return new BaitCrystalFish(charge);
                case Bait.FairySalmon: return new BaitFairySalmon(charge);
                case Bait.FireFish: return new BaitFireFish(charge);
                case Bait.GiantKoi: return new BaitGiantKoi(charge);
                case Bait.GreatBarracuda: return new BaitGreatBarracuda(charge);
                case Bait.HolyMackerel: return new BaitHolyMackerel(charge);
                case Bait.LavaFish: return new BaitLavaFish(charge);
                case Bait.ReaperFish: return new BaitReaperFish(charge);
                case Bait.SpiderCrab: return new BaitSpiderCrab(charge);
                case Bait.StoneCrab: return new BaitStoneCrab(charge);
                case Bait.SummerDragonfish: return new BaitSummerDragonfish(charge);
				case Bait.UnicornFish: return new BaitUnicornFish(charge);
				case Bait.YellowtailBarracuda: return new BaitYellowtailBarracuda(charge);
				case Bait.AbyssalDragonfish: return new BaitAbyssalDragonfish(charge);
				case Bait.BlackMarlin: return new BaitBlackMarlin(charge);
				case Bait.BloodLobster: return new BaitBloodLobster(charge);
				case Bait.BlueMarlin: return new BaitBlueMarlin(charge);
				case Bait.DreadLobster: return new BaitDreadLobster(charge);
				case Bait.DungeonPike: return new BaitDungeonPike(charge);
				case Bait.GiantSamuraiFish: return new BaitGiantSamuraiFish(charge);
				case Bait.GoldenTuna: return new BaitGoldenTuna(charge);
				case Bait.Kingfish: return new BaitKingfish(charge);
				case Bait.LanternFish: return new BaitLanternFish(charge);
				case Bait.RainbowFish: return new BaitRainbowFish(charge);
				case Bait.SeekerFish: return new BaitSeekerFish(charge);
				case Bait.SpringDragonfish: return new BaitSpringDragonfish(charge);
				case Bait.StoneFish: return new BaitStoneFish(charge);
				case Bait.TunnelCrab: return new BaitTunnelCrab(charge);
				case Bait.VoidCrab: return new BaitVoidCrab(charge);
				case Bait.VoidLobster: return new BaitVoidLobster(charge);
				case Bait.WinterDragonfish: return new BaitWinterDragonfish(charge);
				case Bait.ZombieFish: return new BaitZombieFish(charge);

				default: return null;
            }
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            if (Amount > 1)
                list.Add(1060532, String.Format("{3} {0}{1}{2}", "Appâts [", GetMaterial(), "]", Amount)); // ~1_NUMBER~ ~2_ITEMNAME~
            else
                list.Add(String.Format("{0}{1}{2}", "Appât [", GetMaterial(), "]")); // ingots
        }

        public BaseBait(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)1); // version

            writer.Write((int)m_Bait);
            writer.Write(m_Charge);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 1:
                    {
                        m_Bait = (Bait)reader.ReadInt();
                        m_Charge = reader.ReadInt();
                        goto case 0;
                    }
                case 0:
                    {
                        break;
                    }
            }
        }
    }
}