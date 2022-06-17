using System;
using System.Collections;
using Server.Items;
using Server.Gumps;
using Server.Network;
using System.Collections.Generic;
using Server.ContextMenus;
using Server.Targeting;

namespace Server.Mobiles
{
	public class Messager : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos { get { return m_SBInfos; } }

        public override bool IsActiveBuyer { get { return false; } } // response to vendor SELL
																	 //      public override bool IsActiveSeller { get { return false; } } // repsonse to vendor BUY


		public override void InitSBInfo()
		{
			m_SBInfos.Add(new SBMessager());
		}




		[Constructable]
		public Messager() : base( "Messager" )
		{
        }


		public Messager( Serial serial ) : base( serial )
		{
        }

		public override bool OnDragDrop(Mobile from, Item dropped)
		{
			if (dropped is Missive)
			{
				Missive missive = (Missive)dropped;

				if (missive.Destinataire == null)
				{
					from.SendMessage("Votre missive doit avoir un destinataire.");
					return false;
				}
				else
				{				
					missive.Destinataire.AddMissive(missive);
					PublicOverheadMessage(MessageType.Regular, SpeechHue, false, "La missive a été envoyée.", false);
					return true;
					
				}
			}




			return base.OnDragDrop(from, dropped);
		}


		public override void AddCustomContextEntries(Mobile from, List<ContextMenuEntry> list)
		{
		

			if (from is CustomPlayerMobile)
			{

				list.Add(new PosterMenu(from, this));

				CustomPlayerMobile sp = (CustomPlayerMobile)from;


				if (sp.MissiveEnAttente.Count > 0)
				{
					list.Add(new RecevoirMenu(from, this));
				}

				
				
			}

			base.AddCustomContextEntries(from, list);

		}





		public class PosterMenu : ContextMenuEntry
		{
			public Mobile From { get; set; }
			public BaseVendor Vendor { get; set; }

			public PosterMenu(Mobile from, BaseVendor vendor)
				: base(3006257) // Convert Mage Armor
			{
				From = from;
				Vendor = vendor;
			}

			public override void OnClick()
			{
				From.Target = new MissiveTarget((CustomPlayerMobile)From);
			}
		}

		public class MissiveTarget : Target
		{
			CustomPlayerMobile m_Spm;

			public MissiveTarget(CustomPlayerMobile spm) : base(-1, true, TargetFlags.None)
			{

				m_Spm = spm;
				m_Spm.SendMessage("Veuillez sélectionner la missive ?");

			}

			protected override void OnTarget(Mobile from, object o)
			{
				if (o is Missive)
				{
					Missive missive = (Missive)o;

					if (from.Backpack == null || !missive.IsChildOf(from.Backpack))
					{
						from.SendMessage("La missive doit être dans votre sac.");
					}
					else if (missive.Destinataire == null)
					{
						from.SendMessage("Votre missive doit avoir un destinataire.");
					}
					else
					{
						if (from.Backpack == null || !missive.IsChildOf(from.Backpack))
						{
							from.SendMessage("La missive doit être dans votre sac.");
						}
						else if (missive.Destinataire == null)
						{
							from.SendMessage("Votre missive doit avoir un destinataire.");
						}
						else
						{
							missive.Destinataire.AddMissive(missive);
							from.SendMessage("La missive a été envoyée.");
						}
					}
				}
				else
				{
					from.SendMessage("Vous devez choisir une missive.");
				}
			}

		}

		public class RecevoirMenu : ContextMenuEntry
		{
			public Mobile From { get; set; }
			public BaseVendor Vendor { get; set; }

			public RecevoirMenu(Mobile from, BaseVendor vendor)
				: base(3006258) // Convert Mage Armor
			{
				From = from;
				Vendor = vendor;
			}

			public override void OnClick()
			{
				if (From is CustomPlayerMobile)
				{
					CustomPlayerMobile sp = (CustomPlayerMobile)From;

					if (Vendor is Messager)
					{
						Messager Mes = (Messager)Vendor;

						sp.SendMessage(string.Format("Vous aviez {0} missive(s) en attente.", sp.MissiveEnAttente.Count));

						sp.GetMissive();

					}

				}
			}
		}


		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

            writer.Write((int)0); // version

        
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

            switch (version)
            {
                case 0:
                    {
                       

                        break;
                    }
            }
		}
	}
}