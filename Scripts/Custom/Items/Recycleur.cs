using System;
using Server;
using Server.Engines.Craft;
using Server.Targeting;
using Server.CustomScripts;

namespace Server.Items
{
	[FlipableAttribute(4787, 4787)]
	public class Recycleur : Item
	{
        private int m_UsesRemaining;

        [CommandProperty(AccessLevel.GameMaster)]
        public int UsesRemaining
        {
            get { return m_UsesRemaining; }
            set { m_UsesRemaining = value; InvalidateProperties(); }
        }

        public bool ShowUsesRemaining { get { return true; } set { } }

		[Constructable]
        public Recycleur() : base(4787)
		{
            Name = "Recycleur";
			Hue = 1109;
			Weight = 2.0;
            m_UsesRemaining = Utility.Random(50, 75);
		}

		public Recycleur( Serial serial ) : base( serial )
		{
		}

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            list.Add(String.Format("Utilisations restantes: {0}", m_UsesRemaining));
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (from.Backpack == null || this.Parent != from.Backpack)
            {
                from.SendMessage("Ce doit être dans votre sac.");
            }
            else
            {
                from.SendMessage("Sélectionner un objet à recycler.");
                from.Target = new InternalTarget(this);
            }
        }

        private class InternalTarget : Target
        {
            private Recycleur m_Recycleur;

            public InternalTarget(Recycleur recycleur) : base(1, false, TargetFlags.None)
            {
                m_Recycleur = recycleur;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                CraftSystem m_CraftSystem = null;
                CraftResource resource = CraftResource.None;

                if (targeted is BaseArmor)
                {
                    BaseArmor armor = (BaseArmor)targeted;
                    resource = armor.Resource;
                }
                else if (targeted is BaseWeapon)
                {
                    BaseWeapon weapon = (BaseWeapon)targeted;
                    resource = weapon.Resource;
                }
                else if (targeted is BaseShoes)
                {
                    BaseShoes shoes = (BaseShoes)targeted;
                    resource = shoes.Resource;
                }
                else
                {
                    from.SendMessage( "Cet article ne peut pas être recyclé.");
                }

                if (resource == CraftResource.None)
                {
                    from.SendMessage( "Vous ne pouvez pas recycler ceci. (Code: -1)");
                    return;
                }

                switch (resource)
				{
                    case CraftResource.Iron:             m_CraftSystem = DefBlacksmithy.CraftSystem; break;
                    case CraftResource.DullCopper:                 m_CraftSystem = DefBlacksmithy.CraftSystem; break;
                    case CraftResource.ShadowIron:		        m_CraftSystem = DefBlacksmithy.CraftSystem; break;
                    case CraftResource.Copper:		        m_CraftSystem = DefBlacksmithy.CraftSystem; break;
					case CraftResource.Bronze:			        m_CraftSystem = DefBlacksmithy.CraftSystem; break;
					case CraftResource.Gold:			    m_CraftSystem = DefBlacksmithy.CraftSystem; break;
					case CraftResource.Agapite:			    m_CraftSystem = DefBlacksmithy.CraftSystem; break;
					case CraftResource.Verite:			    m_CraftSystem = DefBlacksmithy.CraftSystem; break;
					case CraftResource.Valorite:		    m_CraftSystem = DefBlacksmithy.CraftSystem; break;
					case CraftResource.Mytheril:		    m_CraftSystem = DefBlacksmithy.CraftSystem; break;

                    case CraftResource.LupusLeather:     m_CraftSystem = DefTailoring.CraftSystem; break;
					case CraftResource.ReptilienLeather:	        m_CraftSystem = DefTailoring.CraftSystem; break;
					case CraftResource.GeantLeather:	    m_CraftSystem = DefTailoring.CraftSystem; break;
					case CraftResource.OphidienLeather:	    m_CraftSystem = DefTailoring.CraftSystem; break;
                    case CraftResource.ArachnideLeather:         m_CraftSystem = DefTailoring.CraftSystem; break;
                    case CraftResource.DragoniqueLeather:       m_CraftSystem = DefTailoring.CraftSystem; break;
                    case CraftResource.DemoniaqueLeather:      m_CraftSystem = DefTailoring.CraftSystem; break;
                    case CraftResource.AncienLeather:        m_CraftSystem = DefTailoring.CraftSystem; break;
                    case CraftResource.RegularLeather:       m_CraftSystem = DefTailoring.CraftSystem; break;

                    case CraftResource.RegularBone:        m_CraftSystem = DefBoneTailoring.CraftSystem; break;
					case CraftResource.LupusBone:	            m_CraftSystem = DefBoneTailoring.CraftSystem; break;
					case CraftResource.ReptilienBone:	        m_CraftSystem = DefBoneTailoring.CraftSystem; break;
					case CraftResource.GeantBone:	        m_CraftSystem = DefBoneTailoring.CraftSystem; break;
                    case CraftResource.OphidienBone:            m_CraftSystem = DefBoneTailoring.CraftSystem; break;
                    case CraftResource.ArachnideBone:          m_CraftSystem = DefBoneTailoring.CraftSystem; break;
                    case CraftResource.DragoniqueBone:         m_CraftSystem = DefBoneTailoring.CraftSystem; break;
                    case CraftResource.DemoniaqueBone:           m_CraftSystem = DefBoneTailoring.CraftSystem; break;
                    case CraftResource.AncienBone:          m_CraftSystem = DefBoneTailoring.CraftSystem; break;

                    case CraftResource.RegularWood:          m_CraftSystem = DefBowFletching.CraftSystem; break;
					case CraftResource.OakWood:	        m_CraftSystem = DefBowFletching.CraftSystem; break;
					case CraftResource.AshWood:	    m_CraftSystem = DefBowFletching.CraftSystem; break;
                    case CraftResource.YewWood:           m_CraftSystem = DefBowFletching.CraftSystem; break;
                    case CraftResource.Heartwood:        m_CraftSystem = DefBowFletching.CraftSystem; break;
                    case CraftResource.Bloodwood:           m_CraftSystem = DefBowFletching.CraftSystem; break;
                    case CraftResource.Frostwood:          m_CraftSystem = DefBowFletching.CraftSystem; break;
              

              
				}

                if (m_CraftSystem == null)
                {
                    from.SendMessage( "Vous ne pouvez pas recycler ceci. (Code: 0)");
                    return;
                }

                CraftResourceInfo info = CraftResources.GetInfo(resource);

                if (info == null || info.ResourceTypes.Length == 0)
                {
                    from.SendMessage( "Vous ne pouvez pas recycler ceci. (Code: 1)");
                    return;
                }

                CraftItem craftItem = m_CraftSystem.CraftItems.SearchFor(targeted.GetType());

                if (craftItem == null || craftItem.Resources.Count == 0)
                {
                    switch (resource)
				    {
						case CraftResource.Iron: m_CraftSystem = DefTinkering.CraftSystem; break;
						case CraftResource.DullCopper: m_CraftSystem = DefTinkering.CraftSystem; break;
						case CraftResource.ShadowIron: m_CraftSystem = DefTinkering.CraftSystem; break;
						case CraftResource.Copper: m_CraftSystem = DefTinkering.CraftSystem; break;
						case CraftResource.Bronze: m_CraftSystem = DefTinkering.CraftSystem; break;
						case CraftResource.Gold: m_CraftSystem = DefTinkering.CraftSystem; break;
						case CraftResource.Agapite: m_CraftSystem = DefTinkering.CraftSystem; break;
						case CraftResource.Verite: m_CraftSystem = DefTinkering.CraftSystem; break;
						case CraftResource.Valorite: m_CraftSystem = DefTinkering.CraftSystem; break;
						case CraftResource.Mytheril: m_CraftSystem = DefTinkering.CraftSystem; break;

						case CraftResource.LupusLeather: m_CraftSystem = DefTailoring.CraftSystem; break;
						case CraftResource.ReptilienLeather: m_CraftSystem = DefTailoring.CraftSystem; break;
						case CraftResource.GeantLeather: m_CraftSystem = DefTailoring.CraftSystem; break;
						case CraftResource.OphidienLeather: m_CraftSystem = DefTailoring.CraftSystem; break;
						case CraftResource.ArachnideLeather: m_CraftSystem = DefTailoring.CraftSystem; break;
						case CraftResource.DragoniqueLeather: m_CraftSystem = DefTailoring.CraftSystem; break;
						case CraftResource.DemoniaqueLeather: m_CraftSystem = DefTailoring.CraftSystem; break;
						case CraftResource.AncienLeather: m_CraftSystem = DefTailoring.CraftSystem; break;
						case CraftResource.RegularLeather: m_CraftSystem = DefTailoring.CraftSystem; break;



						case CraftResource.RegularWood: m_CraftSystem = DefTinkering.CraftSystem; break;
						case CraftResource.OakWood: m_CraftSystem = DefTinkering.CraftSystem; break;
						case CraftResource.AshWood: m_CraftSystem = DefTinkering.CraftSystem; break;
						case CraftResource.YewWood: m_CraftSystem = DefTinkering.CraftSystem; break;
						case CraftResource.Heartwood: m_CraftSystem = DefTinkering.CraftSystem; break;
						case CraftResource.Bloodwood: m_CraftSystem = DefTinkering.CraftSystem; break;
						case CraftResource.Frostwood: m_CraftSystem = DefTinkering.CraftSystem; break;
					}

                    craftItem = m_CraftSystem.CraftItems.SearchFor(targeted.GetType());
                }

                if (craftItem == null || craftItem.Resources.Count == 0)
                {
                    from.SendMessage( "Vous ne pouvez pas recycler ceci. (Code: 2)");
                    return;
                }

                CraftRes craftResource = craftItem.Resources.GetAt(0);

                if (craftResource.Amount < 2)
                {
                    from.SendMessage( "Cet objet ne contient pas suffisamment de ressources pour être recyclé.");
                    return;
                }

                Type resourceType = info.ResourceTypes[0];
                Item resItem = (Item)Activator.CreateInstance(resourceType);

                if (resItem is BaseIngot)
                {
                    switch (resource)
                    {
                        case CraftResource.Iron:         resItem = new IronIngot(); break;
                        case CraftResource.Copper:      resItem = new CopperIngot(); break;
                        case CraftResource.DullCopper:       resItem = new DullCopperIngot(); break;
                        case CraftResource.ShadowIron:      resItem = new ShadowIronIngot(); break;
						case CraftResource.Bronze:		resItem = new BronzeIngot(); break;
						case CraftResource.Gold:          resItem = new GoldIngot(); break;
                        case CraftResource.Agapite:     resItem = new AgapiteIngot(); break;
                        case CraftResource.Verite:      resItem = new VeriteIngot(); break;
                        case CraftResource.Valorite:    resItem = new ValoriteIngot(); break;
                        case CraftResource.Mytheril:    resItem = new MytherilIngot(); break;
                    }
                }
                else if (resItem is BaseLog)
                {
                    switch (resource)
                    {
                        case CraftResource.RegularWood:      resItem = new Board(); break;
                        case CraftResource.OakWood:       resItem = new OakBoard(); break;
                        case CraftResource.AshWood:    resItem = new AshBoard(); break;
                        case CraftResource.YewWood:       resItem = new YewBoard(); break;
                        case CraftResource.Heartwood:    resItem = new HeartwoodBoard(); break;
                        case CraftResource.Bloodwood:       resItem = new BloodwoodBoard(); break;
                        case CraftResource.Frostwood:      resItem = new FrostwoodBoard(); break;
                      
                    }
                }
                else if (resItem is BaseBone)
                {
                    switch (resource)
                    {
                        case CraftResource.RegularBone:  resItem = new Bone(); break;
                        case CraftResource.LupusBone:       resItem = new LupusBone(); break;
                        case CraftResource.ReptilienBone:     resItem = new ReptilienBone(); break;
                        case CraftResource.GeantBone:   resItem = new GeantBone(); break;
                        case CraftResource.OphidienBone:      resItem = new OphidienBone(); break;
                        case CraftResource.ArachnideBone:    resItem = new ArachnideBone(); break;
                        case CraftResource.DragoniqueBone:   resItem = new DragoniqueBone(); break;
                        case CraftResource.DemoniaqueBone:     resItem = new DemoniaqueBone(); break;
                        case CraftResource.AncienBone:    resItem = new AncienBone(); break;
                    }
                }
                
                else if (resItem is BaseHides)
                {
                    switch (resource)
                    {
                        case CraftResource.RegularLeather:  resItem = new Leather(); break;
                        case CraftResource.LupusLeather:       resItem = new LupusLeather(); break;
                        case CraftResource.ReptilienLeather:     resItem = new ReptilienLeather(); break;
                        case CraftResource.GeantLeather:   resItem = new GeantLeather(); break;
                        case CraftResource.OphidienLeather:      resItem = new OphidienLeather(); break;
                        case CraftResource.ArachnideLeather:    resItem = new ArachnideLeather(); break;
                        case CraftResource.DragoniqueLeather:   resItem = new DragoniqueLeather(); break;
                        case CraftResource.DemoniaqueLeather:     resItem = new DemoniaqueLeather(); break;
                        case CraftResource.AncienLeather:    resItem = new AncienLeather(); break;
                    }
                }

                int newAmount = (int)(craftResource.Amount * 0.5);
                
                if (newAmount < 1)
                    newAmount = 1;

				resItem.Amount = newAmount;


                from.AddToBackpack(resItem);

                ((Item)targeted).Delete();
                    
                m_Recycleur.UsesRemaining -= 1;

                if (m_Recycleur.UsesRemaining < 1)
                {
                    m_Recycleur.Delete();
                    from.SendMessage( "Vous brisez votre outil!");
                }

                from.PlaySound(0x5CA);
            }
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version

            writer.Write((int)m_UsesRemaining);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

            m_UsesRemaining = reader.ReadInt();
		}
	}
}