using System;
using System.Collections.Generic;
using Server;

namespace Server.Mobiles
{
	public class RuneCrafter : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override StatutSocialEnum MinBuyClasse => StatutSocialEnum.Equite;



		[Constructable]
		public RuneCrafter() : base( "the rune crafter" )
		{
			SetSkill( SkillName.EvalInt, 60.0, 83.0 );
			SetSkill( SkillName.Inscribe, 90.0, 100.0 );
			SetSkill( SkillName.Magery, 70.0, 90.0 );
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBRuneCraft() );
		}

		public override VendorShoeType ShoeType
		{
			get{ return Utility.RandomBool() ? VendorShoeType.Shoes : VendorShoeType.Sandals; }
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			AddItem( new Server.Items.Robe( Utility.RandomOrangeHue() ) );
		}

		public RuneCrafter( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}