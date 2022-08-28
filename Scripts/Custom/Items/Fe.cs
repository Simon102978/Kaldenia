using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class Fe : BasePotion
	{

		CustomPlayerMobile m_Player;
	
		public Fe(CustomPlayerMobile cp)
            : base(3838, PotionEffect.Experience)
		{
			m_Player = cp;
			Movable = false;
			LootType = LootType.Blessed;
			Name = "Fiole d'expérience";
			Hue = 2372;


		}

		public Fe( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (m_Player == from)
			{					
				Drink(from);
			}
			else
			{
				from.SendMessage("Cette fe ne vous appartient pas.");
			}
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
			writer.Write(m_Player);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

			m_Player = (CustomPlayerMobile)reader.ReadMobile();
		}

		public override void Drink(Mobile from)
		{
			m_Player.FERPTotal++;
			m_Player.FE++;
			m_Player.RevealingAction();
			m_Player.PlaySound(0x2D6);


			if (m_Player.Body.IsHuman && !m_Player.Mounted)
			{
				m_Player.Animate(AnimationType.Eat, 0);
			}
			Consume();

		}
	}
}