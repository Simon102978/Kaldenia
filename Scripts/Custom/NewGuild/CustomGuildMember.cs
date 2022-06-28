using Server.Custom.System;
using Server.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Mobiles
{

    // Sert seulement pour les officiels du cercle, ceux qui dirige les guildes etcs, qui doivent avoir accès au information du cercle, jouer la dednas.. Bref pas tout les membres du cercle.

    public class CustomGuildMember
    {
        private CustomPlayerMobile m_Mobile;
        private int m_identite;
        private int m_Salaire;
		private string m_Titre;



		private int m_CustomRank;

        public int Identite { get => m_identite; set => m_identite = value; }
        public CustomPlayerMobile Mobile { get => m_Mobile; set => m_Mobile = value; }
        public int Salaire { get => m_Salaire; set => m_Salaire = value; }
        public string Titre { get => m_Titre; set => m_Titre = value; }


		public int CustomRank { get => m_CustomRank; set => m_CustomRank = value; }


        public CustomGuildMember()
        {

        }

        public CustomGuildMember(CustomPlayerMobile player) :
            this (player,player.IdentiteID)
        {

        }

        public CustomGuildMember(CustomPlayerMobile player, int identite)
        {
            Mobile = player;
            Identite = identite;
			CustomRank = 0;
        }



		public string GetName()
		{
			if (Mobile != null)
			{

				Deguisement deg = Mobile.GetDeguisement(Identite);

				if (deg != null)
				{
					return deg.Name;
				}

			}
			return "";
		}

		public void IncreaseRank(GuildRecruter guild)
		{
			if (GuildRecruter.IsValidRank(CustomRank + 1))
			{
				CustomRank += 1;

				NewGuildRank rank = guild.newGuildRankList[CustomRank];

				Salaire = rank.Salary;
				Titre = rank.Title;


			}

		}

		public void DecreaseRank(GuildRecruter guild)
		{
			if (GuildRecruter.IsValidRank(CustomRank - 1))
			{
				CustomRank -= 1;

				NewGuildRank rank = guild.newGuildRankList[CustomRank];
				Salaire = rank.Salary;
				Titre = rank.Title;
			}

		}

		#region Seriliazer

		// Je veux pas me faire chier a tout marquer dans le sérializer du mobile, alors c'est plus simple de juste tout mettre ici, et de faire les rappels du mobiles.

		public void Serialize(GenericWriter writer)
        {

            writer.Write((int)0);
            writer.Write(m_Titre);
            writer.Write(m_Mobile);
            writer.Write(m_identite);
            writer.Write(m_Salaire);
			writer.Write(m_CustomRank);

    }

        public static CustomGuildMember Deserialize(GenericReader reader)
        {
			CustomGuildMember CercleMember = new CustomGuildMember();


            int version = reader.ReadInt();

            switch (version)
            {

                case 0:
                    {
						CercleMember.Titre = reader.ReadString();
						CercleMember.Mobile = (CustomPlayerMobile)reader.ReadMobile();
                        CercleMember.Identite = reader.ReadInt();
                        CercleMember.Salaire = reader.ReadInt();
						CercleMember.CustomRank = reader.ReadInt();
						

                        break;
                    }
            }

            return CercleMember;
        }
        #endregion
    }
}
