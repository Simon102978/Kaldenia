using Server.Items;

using System;
using System.Linq;

namespace Server.Engines.Craft
{
	public class DefPeinture : CraftSystem
	{
		public override SkillName MainSkill => SkillName.Inscribe;

		//    public override int GumpTitleNumber => 1044004;

		public override string GumpTitleString => "Peinture";

		private static CraftSystem m_CraftSystem;

		public static CraftSystem CraftSystem
		{
			get
			{
				if ( m_CraftSystem == null )
					m_CraftSystem = new DefPeinture();

				return m_CraftSystem;
			}
		}

		public override double GetChanceAtMin(CraftItem item)
		{
			return 0.5; // 50%
		}

		private DefPeinture()
			: base(1, 1, 1.25)// base( 1, 1, 3.0 )
		{
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

		public override void PlayCraftEffect( Mobile from )
        	{

            from.PlaySound(0x55);
        	}

		public override int PlayEndingEffect(Mobile from, bool failed, bool lostMaterial, bool toolBroken, int quality, bool makersMark, CraftItem item)
		{
			if (toolBroken)
				from.SendLocalizedMessage(1044038); // You have worn out your tool

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

		public override void InitCraftList()
		{
            int index = -1;

        #region PortraitSud
	    

	    index = AddCraft(typeof(PortraitSud01), "Portrait Sud", "Portrait01", 10, 30, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");
		

	    index = AddCraft(typeof(PortraitSud02), "Portrait Sud", "Portrait02", 10, 30, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");
		

	    index = AddCraft(typeof(PortraitSud03), "Portrait Sud", "Portrait03", 10, 30, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");
		

	    index = AddCraft(typeof(PortraitSud04), "Portrait Sud", "Portrait04", 10, 30, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");
		

	    index = AddCraft(typeof(PortraitSud05), "Portrait Sud", "Portrait05", 10, 30, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");
		

	    index = AddCraft(typeof(PortraitHomme), "Portrait Sud", "Portrait Homme", 30, 50, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");
		

	    index = AddCraft(typeof(PortraitSud06), "Portrait Sud", "Portrait06", 30, 50, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");
		

	    index = AddCraft(typeof(PortraitSud07), "Portrait Sud", "Portrait07", 30, 50, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");
		

	    index = AddCraft(typeof(PortraitSud08), "Portrait Sud", "Portrait08", 30, 50, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");
		

	    index = AddCraft(typeof(PortraitSud09), "Portrait Sud", "Portrait09", 30, 50, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");
		
	   
	    index = AddCraft(typeof(PortraitFemme), "Portrait Sud", "Portrait Femme", 30, 50, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");
		

	    index = AddCraft(typeof(PortraitSud10), "Portrait Sud", "Portrait10", 30, 50, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");
		

	    index = AddCraft(typeof(PortraitSud11), "Portrait Sud", "Portrait11", 30, 50, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");
		

	    index = AddCraft(typeof(PortraitSud12), "Portrait Sud", "Portrait12", 50, 80, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");
		

	    index = AddCraft(typeof(PortraitSud13), "Portrait Sud", "Portrait13", 50, 80, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");
		

	    index = AddCraft(typeof(PortraitSud14), "Portrait Sud", "Portrait14", 50, 80, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");
		

	    index = AddCraft(typeof(PortraitSud15), "Portrait Sud", "Portrait15", 50, 80, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");
		

	    index = AddCraft(typeof(PortraitSud16), "Portrait Sud", "Portrait16", 50, 80, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

		index = AddCraft(typeof(ToileChameau), "Portrait Sud", "Toile Chameau", 50, 80, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");


		index = AddCraft(typeof(ToileKershe), "Portrait Sud", "Toile Kershe", 50, 80, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");


			#endregion

			#region PortraitEst

			index = AddCraft(typeof(PortraitEst01), "Portrait Est", "Portrait01", 10, 30, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PortraitEst02), "Portrait Est", "Portrait02", 10, 30, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PortraitEst03), "Portrait Est", "Portrait03", 10, 30, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PortraitEst04), "Portrait Est", "Portrait04", 10, 30, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PortraitEst05), "Portrait Est", "Portrait05", 10, 30, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PortraitEst06), "Portrait Est", "Portrait06", 30, 50, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PortraitEst07), "Portrait Est", "Portrait07", 30, 50, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PortraitEst08), "Portrait Est", "Portrait08", 30, 50, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PortraitEst09), "Portrait Est", "Portrait09", 30, 50, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PortraitEst10), "Portrait Est", "Portrait10", 50, 80, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PortraitEst11), "Portrait Est", "Portrait11", 50, 80, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PortraitEst12), "Portrait Est", "Portrait12", 50, 80, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PortraitEst13), "Portrait Est", "Portrait13", 50, 80, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");
		

	    index = AddCraft(typeof(PortraitEst14), "Portrait Est", "Portrait14", 50, 80, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");
		

	    index = AddCraft(typeof(PortraitEst15), "Portrait Est", "Portrait15", 50, 80, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");
		

	    index = AddCraft(typeof(PortraitEst16), "Portrait Est", "Portrait16", 50, 80, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");
		

        #endregion

	    #region PeintureSUD

	    index = AddCraft(typeof(PeintureSud01), "Peinture Sud", "Peinture01", 30, 50, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud), "Peinture Sud", "Peinture", 60, 90, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud02), "Peinture Sud", "Peinture02", 60, 90, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud03), "Peinture Sud", "Peinture03", 60, 90, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud04), "Peinture Sud", "Peinture04", 60, 90, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud05), "Peinture Sud", "Peinture05", 60, 90, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud06), "Peinture Sud", "Peinture06", 60, 90, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud07), "Peinture Sud", "Peinture07", 60, 90, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud08), "Peinture Sud", "Peinture08", 60, 90, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud09), "Peinture Sud", "Peinture09", 60, 90, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud10), "Peinture Sud", "Peinture10", 60, 90, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud11), "Peinture Sud", "Peinture11", 60, 90, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud12), "Peinture Sud", "Peinture12", 60, 90, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud13), "Peinture Sud", "Peinture13", 60, 90, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud14), "Peinture Sud", "Peinture14", 70, 100, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud15), "Peinture Sud", "Peinture15", 70, 100, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud16), "Peinture Sud", "Peinture16", 70, 100, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud17), "Peinture Sud", "Peinture17", 70, 100, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud18), "Peinture Sud", "Peinture18", 70, 100, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud19), "Peinture Sud", "Peinture19", 70, 100, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud20), "Peinture Sud", "Peinture20", 70, 100, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud21), "Peinture Sud", "Peinture21", 70, 100, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud22), "Peinture Sud", "Peinture22", 70, 100, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud23), "Peinture Sud", "Peinture23", 70, 100, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud24), "Peinture Sud", "Peinture24", 70, 100, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud25), "Peinture Sud", "Peinture25", 70, 100, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud26), "Peinture Sud", "Peinture26", 70, 100, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");
		
		index = AddCraft(typeof(PeintureSud27), "Peinture Sud", "Peinture27", 80, 110, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud28), "Peinture Sud", "Peinture28", 80, 110, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud29), "Peinture Sud", "Peinture29", 80, 110, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud30), "Peinture Sud", "Peinture30", 80, 110, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud31), "Peinture Sud", "Peinture31", 80, 110, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud32), "Peinture Sud", "Peinture32", 80, 110, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud33), "Peinture Sud", "Peinture33", 80, 110, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud34), "Peinture Sud", "Peinture34", 80, 110, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud35), "Peinture Sud", "Peinture35", 80, 110, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud36), "Peinture Sud", "Peinture36", 80, 110, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud37), "Peinture Sud", "Peinture37", 80, 110, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureSud38), "Peinture Sud", "Peinture38", 80, 110, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

        #endregion

	    #region PeintureEST

	    index = AddCraft(typeof(PeintureEst01), "Peinture Est", "Peinture01", 30, 50, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");
		
	    index = AddCraft(typeof(PeintureEst02), "Peinture Est", "Peinture02", 60, 90, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureEst03), "Peinture Est", "Peinture03", 60, 90, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureEst04), "Peinture Est", "Peinture04", 60, 90, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureEst05), "Peinture Est", "Peinture05", 60, 90, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureEst06), "Peinture Est", "Peinture06", 60, 90, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureEst07), "Peinture Est", "Peinture07", 60, 90, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureEst08), "Peinture Est", "Peinture08", 60, 90, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureEst09), "Peinture Est", "Peinture09", 60, 90, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureEst10), "Peinture Est", "Peinture10", 60, 90, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureEst11), "Peinture Est", "Peinture11", 60, 90, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureEst12), "Peinture Est", "Peinture12", 60, 90, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureEst13), "Peinture Est", "Peinture13", 60, 90, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureEst14), "Peinture Est", "Peinture14", 70, 100, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureEst15), "Peinture Est", "Peinture15", 70, 100, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureEst16), "Peinture Est", "Peinture16", 70, 100, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureEst17), "Peinture Est", "Peinture17", 70, 100, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureEst18), "Peinture Est", "Peinture18", 70, 100, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureEst19), "Peinture Est", "Peinture19", 70, 100, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureEst20), "Peinture Est", "Peinture20", 70, 100, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureEst21), "Peinture Est", "Peinture21", 70, 100, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureEst22), "Peinture Est", "Peinture22", 70, 100, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureEst23), "Peinture Est", "Peinture23", 70, 100, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureEst24), "Peinture Est", "Peinture24", 70, 100, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureEst25), "Peinture Est", "Peinture25", 70, 100, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureEst26), "Peinture Est", "Peinture26", 70, 100, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");
		
		index = AddCraft(typeof(PeintureEst27), "Peinture Est", "Peinture27", 80, 110, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureEst28), "Peinture Est", "Peinture28", 80, 110, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureEst29), "Peinture Est", "Peinture29", 80, 110, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureEst30), "Peinture Est", "Peinture30", 80, 110, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureEst31), "Peinture Est", "Peinture31", 80, 110, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureEst32), "Peinture Est", "Peinture32", 80, 110, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureEst33), "Peinture Est", "Peinture33", 80, 110, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureEst34), "Peinture Est", "Peinture34", 80, 110, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureEst35), "Peinture Est", "Peinture35", 80, 110, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureEst36), "Peinture Est", "Peinture36", 80, 110, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureEst37), "Peinture Est", "Peinture37", 80, 110, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");

	    index = AddCraft(typeof(PeintureEst38), "Peinture Est", "Peinture38", 80, 110, typeof(ToileVierge), "Toile Vierge", 1, "Vous n'avez pas de toile");
			
        #endregion

     
		}
	}
}

        
