using Server.Items;
using System;

namespace Server.Engines.Craft
{
    public enum InscriptionRecipes
    {
        
    }

    public class DefInscription : CraftSystem
    {
        public override SkillName MainSkill => SkillName.Inscribe;

        public override int GumpTitleNumber => 1044009;

        private static CraftSystem m_CraftSystem;

        public static CraftSystem CraftSystem
        {
            get
            {
                if (m_CraftSystem == null)
                    m_CraftSystem = new DefInscription();

                return m_CraftSystem;
            }
        }

        public override double GetChanceAtMin(CraftItem item)
        {
            return 0.0; // 0%
        }

        private DefInscription()
            : base(1, 1, 1.25)// base( 1, 1, 3.0 )
        {
        }

        public override int CanCraft(Mobile from, ITool tool, Type typeItem)
        {
            int num = 0;

            if (tool == null || tool.Deleted || tool.UsesRemaining <= 0)
                return 1044038; // You have worn out your tool!
            else if (!tool.CheckAccessible(from, ref num))
                return num; // The tool must be on your person to use.

            if (typeItem != null && typeItem.IsSubclassOf(typeof(SpellScroll)))
            {
                if (!_Buffer.ContainsKey(typeItem))
                {
                    object o = Activator.CreateInstance(typeItem);

                    if (o is SpellScroll)
                    {
                        SpellScroll scroll = (SpellScroll)o;
                        _Buffer[typeItem] = scroll.SpellID;
                        scroll.Delete();
                    }
                    else if (o is IEntity)
                    {
                        ((IEntity)o).Delete();
                        return 1042404; // You don't have that spell!
                    }
                }

         /*       int id = _Buffer[typeItem];
                Spellbook book = Spellbook.Find(from, id);

                if (book == null || !book.HasSpell(id))
                    return 1042404; // You don't have that spell!*/
            }

            return 0;
        }

        private readonly System.Collections.Generic.Dictionary<Type, int> _Buffer = new System.Collections.Generic.Dictionary<Type, int>();

        public override void PlayCraftEffect(Mobile from)
        {
            from.PlaySound(0x249);
        }

        private static readonly Type typeofSpellScroll = typeof(SpellScroll);

        public override int PlayEndingEffect(Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, bool makersMark, CraftItem item)
        {
            if (toolBroken)
                from.SendLocalizedMessage(1044038); // You have worn out your tool

            if (!typeofSpellScroll.IsAssignableFrom(item.ItemType)) //  not a scroll
            {
                if (failed)
                {
                    if (lostMaterial)
                        return 1044043; // You failed to create the item, and some of your materials are lost.
                    else
                        return 1044157; // You failed to create the item, but no materials were lost.
                }
                else
                {
                    if (quality == 0)
                        return 502785; // You were barely able to make this item.  It's quality is below average.
                    else if (makersMark && quality == 2)
                        return 1044156; // You create an exceptional quality item and affix your maker's mark.
                    else if (quality == 2)
                        return 1044155; // You create an exceptional quality item.
                    else
                        return 1044154; // You create the item.
                }
            }
            else
            {
                if (failed)
                    return 501630; // You fail to inscribe the scroll, and the scroll is ruined.
                else
                    return 501629; // You inscribe the spell and put the scroll in your backpack.
            }
        }

        private int m_Circle, m_Mana;

        private enum Reg { BlackPearl, Bloodmoss, Garlic, Ginseng, MandrakeRoot, Nightshade, SulfurousAsh, SpidersSilk, BatWing, GraveDust, DaemonBlood, NoxCrystal, PigIron, Bone, DragonBlood, FertileDirt, DaemonBone }

        private readonly Type[] m_RegTypes = new Type[]
        {
            typeof( BlackPearl ),
            typeof( Bloodmoss ),
            typeof( Garlic ),
            typeof( Ginseng ),
            typeof( MandrakeRoot ),
            typeof( Nightshade ),
            typeof( SulfurousAsh ),
            typeof( SpidersSilk ),
            typeof( BatWing ),
            typeof( GraveDust ),
            typeof( DaemonBlood ),
            typeof( NoxCrystal ),
            typeof( PigIron ),
            typeof( Bone ),
            typeof( DragonBlood ),
            typeof( FertileDirt ),
            typeof( DaemonBone )
        };

        private int m_Index;

        private void AddSpell(Type type, params Reg[] regs)
        {
            double minSkill, maxSkill;
            int cliloc;

            switch (m_Circle)
            {
                default:
                case 0: minSkill = -25.0; maxSkill = 25.0; cliloc = 1111691; break;
                case 1: minSkill = -10.8; maxSkill = 39.2; cliloc = 1111691; break;
                case 2: minSkill = 03.5; maxSkill = 53.5; cliloc = 1111692; break;
                case 3: minSkill = 17.8; maxSkill = 67.8; cliloc = 1111692; break;
                case 4: minSkill = 32.1; maxSkill = 82.1; cliloc = 1111693; break;
                case 5: minSkill = 46.4; maxSkill = 96.4; cliloc = 1111693; break;
                case 6: minSkill = 60.7; maxSkill = 110.7; cliloc = 1111694; break;
                case 7: minSkill = 75.0; maxSkill = 125.0; cliloc = 1111694; break;
            }

            int index = AddCraft(type, cliloc, 1044381 + m_Index++, minSkill, maxSkill, m_RegTypes[(int)regs[0]], 1044353 + (int)regs[0], 1, 1044361 + (int)regs[0]);

            for (int i = 1; i < regs.Length; ++i)
                AddRes(index, m_RegTypes[(int)regs[i]], 1044353 + (int)regs[i], 1, 1044361 + (int)regs[i]);

            AddRes(index, typeof(BlankScroll), 1044377, 1, 1044378);

            SetManaReq(index, m_Mana);
        }

        private void AddNecroSpell(int spell, int mana, double minSkill, Type type, params Reg[] regs)
        {
            int id = GetRegLocalization(regs[0]);
            int index = AddCraft(type, 1061677, 1060509 + spell, minSkill, minSkill + 1.0, m_RegTypes[(int)regs[0]], id, 1, 501627);

            for (int i = 1; i < regs.Length; ++i)
            {
                id = GetRegLocalization(regs[i]);
                AddRes(index, m_RegTypes[(int)regs[i]], id, 1, 501627);
            }

            AddRes(index, typeof(BlankScroll), 1044377, 1, 1044378);

            SetManaReq(index, mana);
        }

        private void AddMysticSpell(int id, int mana, double minSkill, Type type, params Reg[] regs)
        {
            int index = AddCraft(type, 1111671, id, minSkill, minSkill + 1.0, m_RegTypes[(int)regs[0]], GetRegLocalization(regs[0]), 1, 501627);	//Yes, on OSI it's only 1.0 skill diff'.  Don't blame me, blame OSI.

            for (int i = 1; i < regs.Length; ++i)
                AddRes(index, m_RegTypes[(int)regs[i]], GetRegLocalization(regs[i]), 1, 501627);

            AddRes(index, typeof(BlankScroll), 1044377, 1, 1044378);

            SetManaReq(index, mana);
        }

        private int GetRegLocalization(Reg reg)
        {
            int loc = 0;

            switch (reg)
            {
                case Reg.BatWing: loc = 1023960; break;
                case Reg.GraveDust: loc = 1023983; break;
                case Reg.DaemonBlood: loc = 1023965; break;
                case Reg.NoxCrystal: loc = 1023982; break;
                case Reg.PigIron: loc = 1023978; break;
                case Reg.Bone: loc = 1023966; break;
                case Reg.DragonBlood: loc = 1023970; break;
                case Reg.FertileDirt: loc = 1023969; break;
                case Reg.DaemonBone: loc = 1023968; break;
            }

            if (loc == 0)
                loc = 1044353 + (int)reg;

            return loc;
        }

        public override void InitCraftList()
        {

            int index;

			index = AddCraft(typeof(MindRotScroll),"Anarchique","Pourriture", 3.5, 53.5, typeof(BlankScroll), 1044377, 1, 1044378);
			AddRes(index, typeof(BatWing),"BatWing", 1,"Vous n'avez pas assez de BatWing.");
			AddRes(index, typeof(PigIron),"PigIron", 1,"Vous n'avez pas assez de PigIron.");
			AddRes(index, typeof(DaemonBlood),"DaemonBlood", 1,"Vous n'avez pas assez de DaemonBlood.");
			CraftItem craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 9;

			index = AddCraft(typeof(WraithFormScroll),"Anarchique","Spectre", -10.8, 39.2, typeof(BlankScroll), 1044377, 1, 1044378);
			AddRes(index, typeof(NoxCrystal),"NoxCrystal", 1,"Vous n'avez pas assez de NoxCrystal.");
			AddRes(index, typeof(PigIron),"PigIron", 1,"Vous n'avez pas assez de PigIron.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 6;

			index = AddCraft(typeof(ConfidenceScroll),"Vie","Confiance", -10.8, 39.2, typeof(BlankScroll), 1044377, 1, 1044378);
		    craftItem = CraftItems.GetAt(index);
		    craftItem.Mana = 6;

			index = AddCraft(typeof(ImmolatingWeaponScroll),"Anarchique","Arme d'immolation", -25.0, 25, typeof(BlankScroll), 1044377, 1, 1044378);
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 4;

			index = AddCraft(typeof(SleepScroll),"Anarchique","Dormir", 3.5, 53.5, typeof(BlankScroll), 1044377, 1, 1044378);
			AddRes(index, typeof(Nightshade),"Nightshade", 1,"Vous n'avez pas assez de Nightshade.");
			AddRes(index, typeof(SpidersSilk),"SpidersSilk", 1,"Vous n'avez pas assez de SpidersSilk.");
			AddRes(index, typeof(BlackPearl),"BlackPearl", 1,"Vous n'avez pas assez de BlackPearl.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 9;

			index = AddCraft(typeof(CurseScroll),"Anarchique","Malédiction", 17.8, 67.8, typeof(BlankScroll), 1044377, 1, 1044378);
			AddRes(index, typeof(Nightshade),"Nightshade", 1,"Vous n'avez pas assez de Nightshade.");
			AddRes(index, typeof(Garlic),"Garlic", 1,"Vous n'avez pas assez de Garlic.");
			AddRes(index, typeof(SulfurousAsh),"SulfurousAsh", 1,"Vous n'avez pas assez de SulfurousAsh.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 11;

			index = AddCraft(typeof(PoisonScroll),"Anarchique","Poison", 3.5, 53.5, typeof(BlankScroll), 1044377, 1, 1044378);
			AddRes(index, typeof(Nightshade),"Nightshade", 1,"Vous n'avez pas assez de Nightshade.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 9;

		    index = AddCraft(typeof(IncognitoScroll),"Anarchique","Incognito", 32.1, 82.1, typeof(BlankScroll), 1044377, 1, 1044378);
			AddRes(index, typeof(Bloodmoss),"Bloodmoss", 1,"Vous n'avez pas assez de Bloodmoss.");
			AddRes(index, typeof(Garlic),"Garlic", 1,"Vous n'avez pas assez de Garlic.");
			AddRes(index, typeof(Nightshade),"Nightshade", 1,"Vous n'avez pas assez de Nightshade.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 14;

			index = AddCraft(typeof(InvisibilityScroll),"Anarchique","Invisibilité", 46.4, 96.4, typeof(BlankScroll), 1044377, 1, 1044378);
			AddRes(index, typeof(Bloodmoss),"Bloodmoss", 1,"Vous n'avez pas assez de Bloodmoss.");
			AddRes(index, typeof(Nightshade),"Nightshade", 1,"Vous n'avez pas assez de Nightshade.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 20;

			index = AddCraft(typeof(ManaVampireScroll),"Anarchique","Drain vampirique", 60.7, 110.7, typeof(BlankScroll), 1044377, 1, 1044378);
			AddRes(index, typeof(BlackPearl),"BlackPearl", 1,"Vous n'avez pas assez de BlackPearl.");
			AddRes(index, typeof(Bloodmoss),"Bloodmoss", 1,"Vous n'avez pas assez de Bloodmoss.");
			AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 40;

			index = AddCraft(typeof(CounterAttackScroll),"Vie","Contre - attaque", 17.8, 67.8, typeof(BlankScroll), 1044377, 1, 1044378);
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 11;

			index = AddCraft(typeof(EvasionScroll),"Obeissance","Évasion", 46.4, 96.4, typeof(BlankScroll), 1044377, 1, 1044378);
			 craftItem = CraftItems.GetAt(index);
			 craftItem.Mana = 20;

			index = AddCraft(typeof(EtherealVoyageScroll),"Anarchique","Voyage éthéré", -10.8, 39.2, typeof(BlankScroll), 1044377, 1, 1044378);
			 craftItem = CraftItems.GetAt(index);
			 craftItem.Mana = 6;

			index = AddCraft(typeof(FlameStrikeScroll),"Anarchique","Jet de feu", 60.7, 110.7, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(SpidersSilk),"SpidersSilk", 1,"Vous n'avez pas assez de SpidersSilk.");
			AddRes(index, typeof(SulfurousAsh),"SulfurousAsh", 1,"Vous n'avez pas assez de SulfurousAsh.");
			 craftItem = CraftItems.GetAt(index);
			 craftItem.Mana = 40;

			index = AddCraft(typeof(VengefulSpiritScroll),"Anarchique","Esprit Vengeur", 75.0, 125.0, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(BatWing),"BatWing", 1,"Vous n'avez pas assez de BatWing.");
			AddRes(index, typeof(GraveDust),"GraveDust", 1,"Vous n'avez pas assez de GraveDust.");
			 AddRes(index, typeof(PigIron),"PigIron", 1,"Vous n'avez pas assez de PigIron.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 50;

			index = AddCraft(typeof(EnergyVortexScroll),"Anarchique","Vortex d'energie", 75.0, 125.0, typeof(BlankScroll), 1044377, 1, 1044378);
			AddRes(index, typeof(Bloodmoss),"Bloodmoss", 1,"Vous n'avez pas assez de Bloodmoss.");
			 AddRes(index, typeof(BlackPearl),"BlackPearl", 1,"Vous n'avez pas assez de BlackPearl.");
			AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			 craftItem = CraftItems.GetAt(index);
			 craftItem.Mana = 50;

			index = AddCraft(typeof(ReactiveArmorScroll),"Arcane","Armure réactive", -25.0, 25, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(Garlic),"Garlic", 1,"Vous n'avez pas assez de Garlic.");
			AddRes(index, typeof(SpidersSilk),"SpidersSilk", 1,"Vous n'avez pas assez de SpidersSilk.");
			 AddRes(index, typeof(SulfurousAsh),"SulfurousAsh", 1,"Vous n'avez pas assez de SulfurousAsh.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 4;

			index = AddCraft(typeof(CreateFoodScroll),"Arcane","Nourriture", -25.0, 25, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(Garlic),"Garlic", 1,"Vous n'avez pas assez de Garlic.");
			AddRes(index, typeof(Ginseng),"Ginseng", 1,"Vous n'avez pas assez de Ginseng.");
			 AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 4;

			index = AddCraft(typeof(NightSightScroll),"Arcane","Vision de nuit", -25.0, 25, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(SulfurousAsh),"SulfurousAsh", 1,"Vous n'avez pas assez de SulfurousAsh.");
			AddRes(index, typeof(SpidersSilk),"SpidersSilk", 1,"Vous n'avez pas assez de SpidersSilk.");
			 craftItem = CraftItems.GetAt(index);
			 craftItem.Mana = 4;

			index = AddCraft(typeof(HealScroll),"Arcane","Guérison", -25.0, 25, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(Garlic),"Garlic", 1,"Vous n'avez pas assez de Garlic.");
			AddRes(index, typeof(Ginseng),"Ginseng", 1,"Vous n'avez pas assez de Ginseng.");
			 AddRes(index, typeof(SpidersSilk),"SpidersSilk", 1,"Vous n'avez pas assez de SpidersSilk.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 4;

			index = AddCraft(typeof(MagicArrowScroll),"Arcane","Flèche magique", -25.0, 25, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(SulfurousAsh),"SulfurousAsh", 1,"Vous n'avez pas assez de SulfurousAsh.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 4;

			index = AddCraft(typeof(ClumsyScroll),"Arcane","Maladresse", -25.0, 25, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(Bloodmoss),"Bloodmoss", 1,"Vous n'avez pas assez de Bloodmoss.");
			AddRes(index, typeof(Nightshade),"Nightshade", 1,"Vous n'avez pas assez de Nightshade.");
			 craftItem = CraftItems.GetAt(index);
			 craftItem.Mana = 4;

			index = AddCraft(typeof(FeeblemindScroll),"Arcane","Abrutissement", -25.0, 25, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(Ginseng),"Ginseng", 1,"Vous n'avez pas assez de Ginseng.");
			AddRes(index, typeof(Nightshade),"Nightshade", 1,"Vous n'avez pas assez de Nightshade.");
			 craftItem = CraftItems.GetAt(index);
			 craftItem.Mana = 4;

			index = AddCraft(typeof(WeakenScroll),"Arcane","Faiblesse", -25.0, 25, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(Garlic),"Garlic", 1,"Vous n'avez pas assez de Garlic.");
			AddRes(index, typeof(Nightshade),"Nightshade", 1,"Vous n'avez pas assez de Nightshade.");
			 craftItem = CraftItems.GetAt(index);
			 craftItem.Mana = 4;

			index = AddCraft(typeof(AgilityScroll),"Arcane","Agilité", -10.8, 39.2, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(Bloodmoss),"Bloodmoss", 1,"Vous n'avez pas assez de Bloodmoss.");
			AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			 craftItem = CraftItems.GetAt(index);
			 craftItem.Mana = 6;

			index = AddCraft(typeof(CunningScroll),"Arcane","Astuce", -10.8, 39.2, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			AddRes(index, typeof(Nightshade),"Nightshade", 1,"Vous n'avez pas assez de Nightshade.");
			 craftItem = CraftItems.GetAt(index);
			 craftItem.Mana = 6;

			index = AddCraft(typeof(StrengthScroll),"Arcane","Force", -10.8, 39.2, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			AddRes(index, typeof(Nightshade),"Nightshade", 1,"Vous n'avez pas assez de Nightshade.");
			 craftItem = CraftItems.GetAt(index);
			 craftItem.Mana = 6;

			index = AddCraft(typeof(ProtectionScroll),"Arcane","Protection", -10.8, 39.2, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(Garlic),"Garlic", 1,"Vous n'avez pas assez de Garlic.");
			AddRes(index, typeof(Ginseng),"Ginseng", 1,"Vous n'avez pas assez de Ginseng.");
			 AddRes(index, typeof(SulfurousAsh),"SulfurousAsh", 1,"Vous n'avez pas assez de SulfurousAsh.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 6;

			index = AddCraft(typeof(CureScroll),"Arcane","Antidote", -10.8, 39.2, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(Garlic),"Garlic", 1,"Vous n'avez pas assez de Garlic.");
			AddRes(index, typeof(Ginseng),"Ginseng", 1,"Vous n'avez pas assez de Ginseng.");
			 craftItem = CraftItems.GetAt(index);
			 craftItem.Mana = 6;

			index = AddCraft(typeof(HarmScroll),"Arcane","Malaise", -10.8, 39.2, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(Nightshade),"Nightshade", 1,"Vous n'avez pas assez de Nightshade.");
			AddRes(index, typeof(SpidersSilk),"SpidersSilk", 1,"Vous n'avez pas assez de SpidersSilk.");
			 craftItem = CraftItems.GetAt(index);
			 craftItem.Mana = 6;

			index = AddCraft(typeof(MagicTrapScroll),"Arcane","Piège Magique", -10.8, 39.2, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(Garlic),"Garlic", 1,"Vous n'avez pas assez de Garlic.");
			AddRes(index, typeof(SpidersSilk),"SpidersSilk", 1,"Vous n'avez pas assez de SpidersSilk.");
			 AddRes(index, typeof(SulfurousAsh),"SulfurousAsh", 1,"Vous n'avez pas assez de SulfurousAsh.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 6;

			index = AddCraft(typeof(RemoveTrapScroll),"Arcane","Sup.De Piège", -10.8, 39.2, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(Bloodmoss),"Bloodmoss", 1,"Vous n'avez pas assez de Bloodmoss.");
			AddRes(index, typeof(SulfurousAsh),"SulfurousAsh", 1,"Vous n'avez pas assez de SulfurousAsh.");
			 craftItem = CraftItems.GetAt(index);
			 craftItem.Mana = 6;

			index = AddCraft(typeof(MagicLockScroll),"Arcane","Fermeture Mag.", 3.5, 53.5, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(Garlic),"Garlic", 1,"Vous n'avez pas assez de Garlic.");
			AddRes(index, typeof(Bloodmoss),"Bloodmoss", 1,"Vous n'avez pas assez de Bloodmoss.");
			 AddRes(index, typeof(SulfurousAsh),"SulfurousAsh", 1,"Vous n'avez pas assez de SulfurousAsh.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 9;

			index = AddCraft(typeof(UnlockScroll),"Arcane","Crochetage", 3.5, 53.5, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(Bloodmoss),"Bloodmoss", 1,"Vous n'avez pas assez de Bloodmoss.");
			AddRes(index, typeof(SulfurousAsh),"SulfurousAsh", 1,"Vous n'avez pas assez de SulfurousAsh.");
			 craftItem = CraftItems.GetAt(index);
			 craftItem.Mana = 9;

			index = AddCraft(typeof(TelekinesisScroll),"Arcane","Télékinésie", 3.5, 53.5, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(Bloodmoss),"Bloodmoss", 1,"Vous n'avez pas assez de Bloodmoss.");
			AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			 craftItem = CraftItems.GetAt(index);
			 craftItem.Mana = 9;

			index = AddCraft(typeof(TeleportScroll),"Arcane","Téléportation", 3.5, 53.5, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(Bloodmoss),"Bloodmoss", 1,"Vous n'avez pas assez de Bloodmoss.");
			AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			 craftItem = CraftItems.GetAt(index);
			 craftItem.Mana = 9;

			index = AddCraft(typeof(RecallScroll),"Arcane","Rappel", 17.8, 67.8, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(BlackPearl),"BlackPearl", 1,"Vous n'avez pas assez de BlackPearl.");
			AddRes(index, typeof(Bloodmoss),"Bloodmoss", 1,"Vous n'avez pas assez de Bloodmoss.");
			 AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 11;

			index = AddCraft(typeof(MindBlastScroll),"Arcane","Souffle d'esprit", 32.1, 82.1, typeof(BlankScroll), 1044377, 1, 1044378);
			AddRes(index, typeof(BlackPearl),"BlackPearl", 1,"Vous n'avez pas assez de BlackPearl.");
			 AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			AddRes(index, typeof(Nightshade),"Nightshade", 1,"Vous n'avez pas assez de Nightshade.");
			 craftItem = CraftItems.GetAt(index);
			 craftItem.Mana = 14;

			index = AddCraft(typeof(FireballScroll),"Arcane","Boule de feu", 3.5, 53.5, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(BlackPearl),"BlackPearl", 1,"Vous n'avez pas assez de BlackPearl.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 9;

			index = AddCraft(typeof(FireElementalScroll),"Arcane","Élém. : Feu", 75.0, 125.0, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(Bloodmoss),"Bloodmoss", 1,"Vous n'avez pas assez de Bloodmoss.");
			AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			 AddRes(index, typeof(SpidersSilk),"SpidersSilk", 1,"Vous n'avez pas assez de SpidersSilk.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 50;

			index = AddCraft(typeof(EarthElementalScroll),"Arcane","Élém. : Terre", 75.0, 125.0, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(Bloodmoss),"Bloodmoss", 1,"Vous n'avez pas assez de Bloodmoss.");
			AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			 AddRes(index, typeof(SpidersSilk),"SpidersSilk", 1,"Vous n'avez pas assez de SpidersSilk.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 50;

			index = AddCraft(typeof(AirElementalScroll),"Arcane","Élém. : Air", 75.0, 125.0, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(Bloodmoss),"Bloodmoss", 1,"Vous n'avez pas assez de Bloodmoss.");
			AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			 AddRes(index, typeof(SpidersSilk),"SpidersSilk", 1,"Vous n'avez pas assez de SpidersSilk.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 50;

			index = AddCraft(typeof(SummonFamiliarScroll),"Cycle","Familier", 3.5, 53.5, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(BatWing),"BatWing", 1,"Vous n'avez pas assez de BatWing.");
			AddRes(index, typeof(GraveDust),"GraveDust", 1,"Vous n'avez pas assez de GraveDust.");
			 AddRes(index, typeof(DaemonBlood),"DaemonBlood", 1,"Vous n'avez pas assez de DaemonBlood.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 9;

			index = AddCraft(typeof(CorpseSkinScroll),"Cycle","Peau de mort", -10.8, 39.2, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(BatWing),"BatWing", 1,"Vous n'avez pas assez de BatWing.");
			AddRes(index, typeof(GraveDust),"GraveDust", 1,"Vous n'avez pas assez de GraveDust.");
			 craftItem = CraftItems.GetAt(index);
			 craftItem.Mana = 6;

			index = AddCraft(typeof(NatureFuryScroll),"Cycle","Fureur de la nature", -10.8, 39.2, typeof(BlankScroll), 1044377, 1, 1044378);
			 craftItem = CraftItems.GetAt(index);
			 craftItem.Mana = 6;

			index = AddCraft(typeof(EnchantScroll),"Cycle","Enchanter", -10.8, 39.2, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(SpidersSilk),"SpidersSilk", 1,"Vous n'avez pas assez de SpidersSilk.");
			AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			 AddRes(index, typeof(SulfurousAsh),"SulfurousAsh", 1,"Vous n'avez pas assez de SulfurousAsh.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 6;

			index = AddCraft(typeof(WitherScroll),"Cycle","Flétrissement", 46.4, 96.4, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(NoxCrystal),"NoxCrystal", 1,"Vous n'avez pas assez de NoxCrystal.");
			AddRes(index, typeof(GraveDust),"GraveDust", 1,"Vous n'avez pas assez de GraveDust.");
			 AddRes(index, typeof(PigIron),"PigIron", 1,"Vous n'avez pas assez de PigIron.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 20;

			index = AddCraft(typeof(FireFieldScroll),"Cycle","Mur de feu", 17.8, 67.8, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(BlackPearl),"BlackPearl", 1,"Vous n'avez pas assez de BlackPearl.");
			AddRes(index, typeof(SpidersSilk),"SpidersSilk", 1,"Vous n'avez pas assez de SpidersSilk.");
			 AddRes(index, typeof(SulfurousAsh),"SulfurousAsh", 1,"Vous n'avez pas assez de SulfurousAsh.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 11;

			index = AddCraft(typeof(PolymorphScroll),"Cycle","Transformation", 60.7, 110.7, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(Bloodmoss),"Bloodmoss", 1,"Vous n'avez pas assez de Bloodmoss.");
			AddRes(index, typeof(SpidersSilk),"SpidersSilk", 1,"Vous n'avez pas assez de SpidersSilk.");
			 AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 40;

			index = AddCraft(typeof(AnimateDeadScroll),"Cycle","Réanimation", 17.8, 67.8, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(GraveDust),"GraveDust", 1,"Vous n'avez pas assez de GraveDust.");
			AddRes(index, typeof(DaemonBlood),"DaemonBlood", 1,"Vous n'avez pas assez de DaemonBlood.");
			 craftItem = CraftItems.GetAt(index);
			 craftItem.Mana = 11;

			index = AddCraft(typeof(ReaperFormScroll),"Cycle","Forme de faucheuse", -10.8, 39.2, typeof(BlankScroll), 1044377, 1, 1044378);
			 craftItem = CraftItems.GetAt(index);
			 craftItem.Mana = 6;

			index = AddCraft(typeof(SummonCreatureScroll),"Cycle","Créatures", 32.1, 82.1, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(Bloodmoss),"Bloodmoss", 1,"Vous n'avez pas assez de Bloodmoss.");
			AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			 AddRes(index, typeof(SpidersSilk),"SpidersSilk", 1,"Vous n'avez pas assez de SpidersSilk.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 14;

			index = AddCraft(typeof(MarkScroll),"Cycle","Marquage", 46.4, 96.4, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(BlackPearl),"BlackPearl", 1,"Vous n'avez pas assez de BlackPearl.");
			AddRes(index, typeof(Bloodmoss),"Bloodmoss", 1,"Vous n'avez pas assez de Bloodmoss.");
			 AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 20;

			index = AddCraft(typeof(ExplosionScroll),"Cycle","Explosion", 46.4, 96.4, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(Bloodmoss),"Bloodmoss", 1,"Vous n'avez pas assez de Bloodmoss.");
			AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			 craftItem = CraftItems.GetAt(index);
			 craftItem.Mana = 20;

			index = AddCraft(typeof(HailStormScroll),"Cycle","Orage de grêle", 60.7, 110.7, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(BlackPearl),"BlackPearl", 1,"Vous n'avez pas assez de BlackPearl.");
			AddRes(index, typeof(Bloodmoss),"Bloodmoss", 1,"Vous n'avez pas assez de Bloodmoss.");
			 AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 40;

			index = AddCraft(typeof(NetherCycloneScroll),"Cycle","Cyclone du Néant", 75.0, 125.0, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			AddRes(index, typeof(Nightshade),"Nightshade", 1,"Vous n'avez pas assez de Nightshade.");
			 AddRes(index, typeof(SulfurousAsh),"SulfurousAsh", 1,"Vous n'avez pas assez de SulfurousAsh.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 50;

			index = AddCraft(typeof(GateTravelScroll),"Cycle","Trou de ver", 60.7, 110.7, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(BlackPearl),"BlackPearl", 1,"Vous n'avez pas assez de BlackPearl.");
			AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			 AddRes(index, typeof(SulfurousAsh),"SulfurousAsh", 1,"Vous n'avez pas assez de SulfurousAsh.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 40;

			index = AddCraft(typeof(EarthquakeScroll),"Cycle","Séisme", 75.0, 125.0, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(Bloodmoss),"Bloodmoss", 1,"Vous n'avez pas assez de Bloodmoss.");
			AddRes(index, typeof(Ginseng),"Ginseng", 1,"Vous n'avez pas assez de Ginseng.");
			 AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 50;

			index = AddCraft(typeof(CurseWeaponScroll),"Mort","Calamite", -25.0, 25, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(PigIron),"PigIron", 1,"Vous n'avez pas assez de PigIron.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 4;

			index = AddCraft(typeof(EvilOmenScroll),"Mort","Mauvais présage", -10.8, 39.2, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(BatWing),"BatWing", 1,"Vous n'avez pas assez de BatWing.");
			AddRes(index, typeof(NoxCrystal),"NoxCrystal", 1,"Vous n'avez pas assez de NoxCrystal.");
			 craftItem = CraftItems.GetAt(index);
			 craftItem.Mana = 6;

			index = AddCraft(typeof(HorrificBeastScroll),"Mort","Bête Horrifique", 17.8, 67.8, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(BatWing),"BatWing", 1,"Vous n'avez pas assez de BatWing.");
			AddRes(index, typeof(DaemonBlood),"DaemonBlood", 1,"Vous n'avez pas assez de DaemonBlood.");
			 craftItem = CraftItems.GetAt(index);
			 craftItem.Mana = 11;

			index = AddCraft(typeof(GiftOfRenewalScroll),"Mort","Don du renouveau", -25.0, 25, typeof(BlankScroll), 1044377, 1, 1044378);
			 craftItem = CraftItems.GetAt(index);
			 craftItem.Mana = 4;

			index = AddCraft(typeof(AnimatedWeaponScroll),"Mort","Arme Animée", 17.8, 67.8, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(BlackPearl),"BlackPearl", 1,"Vous n'avez pas assez de BlackPearl.");
			AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			 AddRes(index, typeof(Nightshade),"Nightshade", 1,"Vous n'avez pas assez de Nightshade.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 11;

			index = AddCraft(typeof(ManaDrainScroll),"Mort","Drain de mana", 17.8, 67.8, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(BlackPearl),"BlackPearl", 1,"Vous n'avez pas assez de BlackPearl.");
			AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			 AddRes(index, typeof(SpidersSilk),"SpidersSilk", 1,"Vous n'avez pas assez de SpidersSilk.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 11;

			index = AddCraft(typeof(MassCurseScroll),"Mort","Malédiction de groupe", 46.4, 96.4, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(Garlic),"Garlic", 1,"Vous n'avez pas assez de Garlic.");
			AddRes(index, typeof(Nightshade),"Nightshade", 1,"Vous n'avez pas assez de Nightshade.");
			 AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 20;

			index = AddCraft(typeof(DispelFieldScroll),"Mort","Dissipation de mur", 32.1, 82.1, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(BlackPearl),"BlackPearl", 1,"Vous n'avez pas assez de BlackPearl.");
			AddRes(index, typeof(SpidersSilk),"SpidersSilk", 1,"Vous n'avez pas assez de SpidersSilk.");
			 AddRes(index, typeof(SulfurousAsh),"SulfurousAsh", 1,"Vous n'avez pas assez de SulfurousAsh.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 14;

			index = AddCraft(typeof(PoisonFieldScroll),"Mort","Mur de poison", 32.1, 82.1, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(BlackPearl),"BlackPearl", 1,"Vous n'avez pas assez de BlackPearl.");
			AddRes(index, typeof(Nightshade),"Nightshade", 1,"Vous n'avez pas assez de Nightshade.");
			 AddRes(index, typeof(SpidersSilk),"SpidersSilk", 1,"Vous n'avez pas assez de SpidersSilk.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 14;

		   index = AddCraft(typeof(BloodOathScroll),"Mort","Serment de sang", -10.8, 39.2, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(DaemonBlood),"DaemonBlood", 1,"Vous n'avez pas assez de DaemonBlood.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 6;

		  index = AddCraft(typeof(CloseWoundsScroll),"Vie","Fermer les plaies", -25.0, 25, typeof(BlankScroll), 1044377, 1, 1044378);
		 craftItem = CraftItems.GetAt(index);
		 craftItem.Mana = 4;

			index = AddCraft(typeof(PoisonStrikeScroll),"Mort","Jet de poison", 32.1, 82.1, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(NoxCrystal),"NoxCrystal", 1,"Vous n'avez pas assez de NoxCrystal.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 14;

		   index = AddCraft(typeof(StrangleScroll),"Mort","Étranglement", 46.4, 96.4, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(DaemonBlood),"DaemonBlood", 1,"Vous n'avez pas assez de DaemonBlood.");
			AddRes(index, typeof(NoxCrystal),"NoxCrystal", 1,"Vous n'avez pas assez de NoxCrystal.");
			 craftItem = CraftItems.GetAt(index);
			 craftItem.Mana = 20;

			index = AddCraft(typeof(LichFormScroll),"Mort","Liche", 60.7, 110.7, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(GraveDust),"GraveDust", 1,"Vous n'avez pas assez de GraveDust.");
			AddRes(index, typeof(DaemonBlood),"DaemonBlood", 1,"Vous n'avez pas assez de DaemonBlood.");
			 AddRes(index, typeof(NoxCrystal),"NoxCrystal", 1,"Vous n'avez pas assez de NoxCrystal.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 40;

			index = AddCraft(typeof(VampiricEmbraceScroll),"Mort","Vampirisme", 75.0, 125.0, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(BatWing),"BatWing", 1,"Vous n'avez pas assez de BatWing.");
			AddRes(index, typeof(NoxCrystal),"NoxCrystal", 1,"Vous n'avez pas assez de NoxCrystal.");
			 AddRes(index, typeof(PigIron),"PigIron", 1,"Vous n'avez pas assez de PigIron.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 50;

			index = AddCraft(typeof(SummonDaemonScroll),"Mort","Démon", 75.0, 125.0, typeof(BlankScroll), 1044377, 1, 1044378);
			 AddRes(index, typeof(Bloodmoss),"Bloodmoss", 1,"Vous n'avez pas assez de Bloodmoss.");
			AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			 AddRes(index, typeof(SpidersSilk),"SpidersSilk", 1,"Vous n'avez pas assez de SpidersSilk.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 50;

			index = AddCraft(typeof(RemoveCurseScroll),"Obeissance","Supprimer le mal", -25.0, 25, typeof(BlankScroll), 1044377, 1, 1044378);
			 craftItem = CraftItems.GetAt(index);
			 craftItem.Mana = 4;

			index = AddCraft(typeof(WallOfStoneScroll),"Obeissance","Mur de pierre", 3.5, 53.5, typeof(BlankScroll), 1044377, 1, 1044378);
			AddRes(index, typeof(Bloodmoss),"Bloodmoss", 1,"Vous n'avez pas assez de Bloodmoss.");
			AddRes(index, typeof(Garlic),"Garlic", 1,"Vous n'avez pas assez de Garlic.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 9;

			index = AddCraft(typeof(CleanseByFireScroll),"Obeissance", "Purification", -25.0, 25, typeof(BlankScroll), 1044377, 1, 1044378);
			 craftItem = CraftItems.GetAt(index);
			 craftItem.Mana = 4;

			index = AddCraft(typeof(BladeSpiritsScroll),"Obeissance","Esprit de Lame", 32.1, 82.1, typeof(BlankScroll), 1044377, 1, 1044378);
			AddRes(index, typeof(BlackPearl),"BlackPearl", 1,"Vous n'avez pas assez de BlackPearl.");
			AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			AddRes(index, typeof(Nightshade),"Nightshade", 1,"Vous n'avez pas assez de Nightshade.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 14;

			index = AddCraft(typeof(LightningScroll),"Obeissance","Éclair", 17.8, 67.8, typeof(BlankScroll), 1044377, 1, 1044378);
			AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			AddRes(index, typeof(SulfurousAsh),"SulfurousAsh", 1,"Vous n'avez pas assez de SulfurousAsh.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 11;

			index = AddCraft(typeof(ConsecrateWeaponScroll),"Obeissance","Consacrer l'arme", -25.0, 25, typeof(BlankScroll), 1044377, 1, 1044378);
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 4;

			index = AddCraft(typeof(DivineFuryScroll),"Obeissance","Fureur divine", -10.8, 39.2, typeof(BlankScroll), 1044377, 1, 1044378);
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 6;

			index = AddCraft(typeof(ArchProtectionScroll),"Obeissance","Protection de groupe", 17.8, 67.8, typeof(BlankScroll), 1044377, 1, 1044378);
			AddRes(index, typeof(Garlic),"Garlic", 1,"Vous n'avez pas assez de Garlic.");
			AddRes(index, typeof(Ginseng),"Ginseng", 1,"Vous n'avez pas assez de Ginseng.");
			AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 11;

			index = AddCraft(typeof(MagicReflectScroll),"Obeissance","Armure magique", 32.1, 82.1, typeof(BlankScroll), 1044377, 1, 1044378);
			AddRes(index, typeof(Garlic),"Garlic", 1,"Vous n'avez pas assez de Garlic.");
			AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			AddRes(index, typeof(SpidersSilk),"SpidersSilk", 1,"Vous n'avez pas assez de SpidersSilk.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 14;

			index = AddCraft(typeof(DispelScroll),"Obeissance","Dissipation", 46.4, 96.4, typeof(BlankScroll), 1044377, 1, 1044378);
			AddRes(index, typeof(Garlic),"Garlic", 1,"Vous n'avez pas assez de Garlic.");
			AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			AddRes(index, typeof(SulfurousAsh),"SulfurousAsh", 1,"Vous n'avez pas assez de SulfurousAsh.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 20;

			index = AddCraft(typeof(DispelEvilScroll),"Vie","Dissiper le mal", 3.5, 53.5, typeof(BlankScroll), 1044377, 1, 1044378);
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 9;

			index = AddCraft(typeof(ParalyzeFieldScroll),"Obeissance","Mur de paralysie", 46.4, 96.4, typeof(BlankScroll), 1044377, 1, 1044378);
			AddRes(index, typeof(BlackPearl),"BlackPearl", 1,"Vous n'avez pas assez de BlackPearl.");
			AddRes(index, typeof(Ginseng),"Ginseng", 1,"Vous n'avez pas assez de Ginseng.");
			AddRes(index, typeof(SpidersSilk),"SpidersSilk", 1,"Vous n'avez pas assez de SpidersSilk.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 20;

			index = AddCraft(typeof(EnemyOfOneScroll),"Obeissance","Ennemi d'un", 17.8, 67.8, typeof(BlankScroll), 1044377, 1, 1044378);
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 11;

			index = AddCraft(typeof(HolyLightScroll),"Vie","Lumière sacrée", 32.1, 82.1, typeof(BlankScroll), 1044377, 1, 1044378);
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 14;

			index = AddCraft(typeof(MassDispelScroll),"Obeissance","Dissipation massive", 60.7, 110.7, typeof(BlankScroll), 1044377, 1, 1044378);
			AddRes(index, typeof(Garlic),"Garlic", 1,"Vous n'avez pas assez de Garlic.");
			AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			AddRes(index, typeof(BlackPearl),"BlackPearl", 1,"Vous n'avez pas assez de BlackPearl.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 40;

			index = AddCraft(typeof(ResurrectionScroll),"Obeissance","Résurrection", 75.0, 125.0, typeof(BlankScroll), 1044377, 1, 1044378);
			AddRes(index, typeof(Bloodmoss),"Bloodmoss", 1,"Vous n'avez pas assez de Bloodmoss.");
			AddRes(index, typeof(Garlic),"Garlic", 1,"Vous n'avez pas assez de Garlic.");
			AddRes(index, typeof(Ginseng),"Ginseng", 1,"Vous n'avez pas assez de Ginseng.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 50;

			index = AddCraft(typeof(WaterElementalScroll),"Arcane","Élém. : Eau", 75.0, 125.0, typeof(BlankScroll), 1044377, 1, 1044378);
			AddRes(index, typeof(Bloodmoss),"Bloodmoss", 1,"Vous n'avez pas assez de Bloodmoss.");
			AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			AddRes(index, typeof(SpidersSilk),"SpidersSilk", 1,"Vous n'avez pas assez de SpidersSilk.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 50;

			index = AddCraft(typeof(RevealScroll),"Vie","Révélation", 46.4, 96.4, typeof(BlankScroll), 1044377, 1, 1044378);
			AddRes(index, typeof(Bloodmoss),"Bloodmoss", 1,"Vous n'avez pas assez de Bloodmoss.");
			AddRes(index, typeof(SulfurousAsh),"SulfurousAsh", 1,"Vous n'avez pas assez de SulfurousAsh.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 20;

			index = AddCraft(typeof(AttuneWeaponScroll),"Vie","Harmonisation", -10.8, 39.2, typeof(BlankScroll), 1044377, 1, 1044378);
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 6;

			index = AddCraft(typeof(NobleSacrificeScroll),"Vie","Nobles sacrifices", 46.4, 96.4, typeof(BlankScroll), 1044377, 1, 1044378);
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 20;

			index = AddCraft(typeof(BlessScroll),"Vie","Bénédiction", 3.5, 53.5, typeof(BlankScroll), 1044377, 1, 1044378);
			AddRes(index, typeof(Garlic),"Garlic", 1,"Vous n'avez pas assez de Garlic.");
			AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 9;

			index = AddCraft(typeof(AnimalFormScroll),"Anarchique","Forme animale", -25.0, 25, typeof(BlankScroll), 1044377, 1, 1044378);
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 4;

			index = AddCraft(typeof(ArchCureScroll),"Vie","Antidote de masse", 17.8, 67.8, typeof(BlankScroll), 1044377, 1, 1044378);
			AddRes(index, typeof(Garlic),"Garlic", 1,"Vous n'avez pas assez de Garlic.");
			AddRes(index, typeof(Ginseng),"Ginseng", 1,"Vous n'avez pas assez de Ginseng.");
			AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 11;

			index = AddCraft(typeof(GreaterHealScroll),"Vie","Guérison majeure", 17.8, 67.8, typeof(BlankScroll), 1044377, 1, 1044378);
			AddRes(index, typeof(Garlic),"Garlic", 1,"Vous n'avez pas assez de Garlic.");
			AddRes(index, typeof(Ginseng),"Ginseng", 1,"Vous n'avez pas assez de Ginseng.");
			AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 11;

			index = AddCraft(typeof(ParalyzeScroll),"Vie","Paralysie", 32.1, 82.1, typeof(BlankScroll), 1044377, 1, 1044378);
			AddRes(index, typeof(Garlic),"Garlic", 1,"Vous n'avez pas assez de Garlic.");
			AddRes(index, typeof(MandrakeRoot),"MandrakeRoot", 1,"Vous n'avez pas assez de MandrakeRoot.");
			AddRes(index, typeof(SpidersSilk),"SpidersSilk", 1,"Vous n'avez pas assez de SpidersSilk.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 14;

			 index = AddCraft(typeof(MirrorImageScroll),"Anarchique","Image miroir", -10.8, 39.2, typeof(BlankScroll), 1044377, 1, 1044378);
			 craftItem = CraftItems.GetAt(index);
			 craftItem.Mana = 6;

			index = AddCraft(typeof(ShadowjumpScroll),"Anarchique","Saut d'ombre", 32.1, 82.1, typeof(BlankScroll), 1044377, 1, 1044378);
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 14;

			index = AddCraft(typeof(DeathStrikeScroll),"Mort","Frappe mortelle", 75.0, 125.0, typeof(BlankScroll), 1044377, 1, 1044378);
			 craftItem = CraftItems.GetAt(index);
			 craftItem.Mana = 50;

			index = AddCraft(typeof(KiAttackScroll),"Obeissance","Attaque Ki", 75.0, 125.0, typeof(BlankScroll), 1044377, 1, 1044378);
			 craftItem = CraftItems.GetAt(index);
			 craftItem.Mana = 50;

			index = AddCraft(typeof(GiftOfLifeScroll),"Vie","Don de vie", 17.8, 67.8, typeof(BlankScroll), 1044377, 1, 1044378);
			 craftItem = CraftItems.GetAt(index);
			 craftItem.Mana = 11;

			index = AddCraft(typeof(EnergyBoltScroll),"Vie","Boule d'énergie", 46.4, 96.4, typeof(BlankScroll), 1044377, 1, 1044378);
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 20;

			index = AddCraft(typeof(EnergyFieldScroll),"Vie","Mur d'energie", 60.7, 110.7, typeof(BlankScroll), 1044377, 1, 1044378);
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 40;

			index = AddCraft(typeof(RisingColossusScroll),"Vie","Colosse montant", 75.0, 125.0, typeof(BlankScroll), 1044377, 1, 1044378);
			AddRes(index, typeof(DaemonBone),"DaemonBone", 1,"Vous n'avez pas assez de DaemonBone.");
			AddRes(index, typeof(DragonBlood),"DragonBlood", 1,"Vous n'avez pas assez de DragonBlood.");
		    AddRes(index, typeof(FertileDirt),"FertileDirt", 1,"Vous n'avez pas assez de FertileDirt.");
			craftItem = CraftItems.GetAt(index);
			craftItem.Mana = 50;



	/*		index = AddCraft(typeof(EnchantedSwitch), 1044294, 1072893, 45.0, 95.0, typeof(BlankScroll), 1044377, 1, 1044378);
			AddRes(index, typeof(SpidersSilk), 1044360, 1, 1044253);
			AddRes(index, typeof(BlackPearl), 1044353, 1, 1044253);
			AddRes(index, typeof(SwitchItem), 1073464, 1, 1044253);
			ForceNonExceptional(index);

			index = AddCraft(typeof(RunedPrism), 1044294, 1073465, 45.0, 95.0, typeof(BlankScroll), 1044377, 1, 1044378);
			AddRes(index, typeof(SpidersSilk), 1044360, 1, 1044253);
			AddRes(index, typeof(BlackPearl), 1044353, 1, 1044253);
			AddRes(index, typeof(HollowPrism), 1072895, 1, 1044253);
			ForceNonExceptional(index);*/

			index = AddCraft(typeof(Runebook), "Autres", 1041267, 45.0, 95.0, typeof(BlankScroll), 1044377, 8, 1044378);
			AddRes(index, typeof(RecallScroll), 1044445, 1, 1044253);
			AddRes(index, typeof(GateTravelScroll), 1044446, 1, 1044253);

			AddCraft(typeof(BulkOrders.BulkOrderBook), "Autres", 1028793, 65.0, 115.0, typeof(BlankScroll), 1044377, 10, 1044378);

			AddCraft(typeof(NewSpellbook), "Autres", "Livre de sort", 50.0, 126, typeof(BlankScroll), 1044377, 10, 1044378);




/*			index = AddCraft(typeof(ScrappersCompendium), 1044294, 1072940, 75.0, 125.0, typeof(BlankScroll), 1044377, 100, 1044378);
			AddRes(index, typeof(DreadHornMane), 1032682, 1, 1044253);
			AddRes(index, typeof(Taint), 1032679, 10, 1044253);
			AddRes(index, typeof(Corruption), 1032676, 10, 1044253);
			AddRecipe(index, (int)TinkerRecipes.ScrappersCompendium);
			ForceNonExceptional(index);

			index = AddCraft(typeof(SpellbookEngraver), 1044294, 1072151, 75.0, 100.0, typeof(Feather), 1044562, 1, 1044563);
			AddRes(index, typeof(BlackPearl), 1015001, 7, 1044253);

			AddCraft(typeof(MysticBook), 1044294, 1031677, 50.0, 100.0, typeof(BlankScroll), 1044377, 10, 1044378);

			AddCraft(typeof(NecromancerSpellbook), 1044294, 1074909, 50.0, 100.0, typeof(BlankScroll), 1044377, 10, 1044378);

			index = AddCraft(typeof(ExodusSummoningRite), 1044294, 1153498, 95.0, 120.0, typeof(DaemonBlood), 1023965, 5, 1044253);
			AddRes(index, typeof(Taint), 1032679, 1, 1044253);
			AddRes(index, typeof(DaemonBone), 1017412, 5, 1044253);
			AddRes(index, typeof(SummonDaemonScroll), 1016017, 1, 1044253);

			index = AddCraft(typeof(PropheticManuscript), 1044294, 1155631, 90.0, 115.0, typeof(AncientParchment), 1155627, 10, 1044253);
			AddRes(index, typeof(AntiqueDocumentsKit), 1155630, 1, 1044253);
			AddRes(index, typeof(WoodPulp), 1113136, 10, 1113289);
			AddRes(index, typeof(Beeswax), 1025154, 5, 1044253);*/

			AddCraft(typeof(BlankScroll), "Autres", 1023636, 50.0, 100.0, typeof(WoodPulp), 1113136, 1, 1044378);
			AddCraft(typeof(Missive), "Autres", 1023636, 15.0, 50.0, typeof(WoodPulp), 1113136, 1, 1044378);

			/*			index = AddCraft(typeof(ScrollBinderDeed), 1044294, 1113135, 75.0, 125.0, typeof(WoodPulp), 1113136, 1, 1044253);
						SetItemHue(index, 1641);*/

			index = AddCraft(typeof(GargoyleBook100), "Autres", 1113290, 60.0, 100.0, typeof(BlankScroll), 1044377, 40, 1044378);
			AddRes(index, typeof(Beeswax), 1025154, 2, 1053098);

			index = AddCraft(typeof(GargoyleBook200), "Autres", 1113291, 72.0, 100.0, typeof(BlankScroll), 1044377, 40, 1044378);
			AddRes(index, typeof(Beeswax), 1025154, 4, 1053098);

			index = AddCraft(typeof(CarnetAdresse), "Autres", 1113291, 25.0, 50.0, typeof(BlankScroll), 1044377, 40, 1044378);
			AddRes(index, typeof(Beeswax), 1025154, 4, 1053098);

			MarkOption = true;
        }
    }
}
