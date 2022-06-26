using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Server.Mobiles;
using Server.Items;
using Server.Commands;
using Server.Custom.Misc;

namespace Server.Custom.System
{
    class NewGuildRankCommand
    {
        public static void Initialize()
        {
            CommandSystem.Register("TestPay", AccessLevel.Owner, new CommandEventHandler(Pay_OnCommand));
        }

        [Usage("TestPay")]
        [Description("Vous payez les membres des guildes")]
        public static void Pay_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;
            NewGuildRecruterStone.Pay();
            from.SendMessage(HueManager.GetHue(HueManagerList.Green), "Vous payez les membres des guildes.");
        }
    }

    class NewGuildRank
    {
        int m_Rank;
        string m_Title;
        int m_Salary;

        public int Rank
        {
            get { return m_Rank; }
            set { m_Rank = value; }
        }

        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }

        public int Salary
        {
            get { return m_Salary; }
            set { m_Salary = value; }
        }

        public NewGuildRank() : base()
        {
            m_Rank = 0;
            m_Title = "";
            m_Salary = 0;
        }
    }

    class NewGuildRecruterStone : BaseVendor
    {
        #region Variables

        private readonly List<SBInfo> m_SBInfos = new List<SBInfo>();

        protected override List<SBInfo> SBInfos => m_SBInfos;
        public override bool IsActiveVendor => false;
        public override bool IsActiveBuyer => false;
        public override bool IsActiveSeller => false;
        public override bool CanTeach => false;

         public override void InitSBInfo()
        { }




        private Dictionary<Mobile, NewGuildRank> m_RankMobiles;

        public static ArrayList m_NewGuildsList;
                                                         
        public string NewGuildTitle         = "Nouvelle Guilde";
        public string NewGuildDescription   = "Veuillez écrire la description de votre guilde ici";
        public string NewGuildSalary        = "Veuillez écrire le salaire du rang ici";

        public const int _RANKMAX = 8;
        public List<NewGuildRank> newGuildRankList;
        #endregion

        #region Get

        public List<Mobile> GetMemberList()
        {
            return m_RankMobiles.Keys.ToList<Mobile>();
        }

        /// <summary>
        /// Retourne le titre lié au rang
        /// </summary>
        /// <param name="rank">Le rang, doit être entre 0 et _RANKMAX.</param>
        /// <returns>Le titre en string du rang. Si invalide, retourne No Title.</returns>
        public String GetTitleByRank(int rank)
        {
            if (IsValidRank(rank))
            {
                try
                {
                    return newGuildRankList[rank].Title;
                }
                catch (Exception)
                {
                }
            }
            return newGuildRankList[0].Title;
        }

        /// <summary>
        /// Retourne le salaire lié au rang
        /// </summary>
        /// <param name="rank">Le rang, doit être entre 0 et _RANKMAX.</param>
        /// <returns>Une string contenant le salaire lié au rang. Si le salaire est invalide, il retourne le salaire[0] par défaut.</returns>
        public int GetSalaryByRank(int rank)
        {
            if (IsValidRank(rank))
            {
                try
                {
                    return newGuildRankList[rank].Salary;
                }
                catch (Exception)
                {
                }
            }
            return 1;
        }

        /// <summary>
        /// Retourne le rang du mobile
        /// </summary>
        /// <param name="m">Mobile dont on veut le rang</param>
        /// <returns>Rang du mobile. Si ne troune pas, retourne le rang 0.</returns>
        public int GetMobileRank(Mobile m)
        {
            if (m_RankMobiles.ContainsKey(m))
            {
                return m_RankMobiles[m].Rank;
            }
            return -1;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Donne le salaire à tous les membres de la guilde. Si un membre est dans plusieurs guildes, il touche le salaire de son rang le plus élevé, mais aucun des autres.
        /// </summary>
        public static void Pay()
        {

            if (m_NewGuildsList != null)
            {
                if (m_NewGuildsList.Count > 0)
                {
                    Dictionary<Mobile, int> MemberSalaryDict = new Dictionary<Mobile, int>();

                    foreach (NewGuildRecruterStone guild in m_NewGuildsList)
                    {
                        if (guild != null)
                        {
                            foreach (KeyValuePair<Mobile, NewGuildRank> kvp in guild.m_RankMobiles)
                            {
                                if (!MemberSalaryDict.ContainsKey(kvp.Key))
                                    MemberSalaryDict.Add(kvp.Key, guild.GetSalaryByRank(guild.GetMobileRank(kvp.Key)));
                                else
                                    MemberSalaryDict[kvp.Key] = Math.Max(MemberSalaryDict[kvp.Key], guild.GetSalaryByRank(guild.GetMobileRank(kvp.Key)));
                            }
                        }
                    }

                    foreach (KeyValuePair<Mobile, int> kvp in MemberSalaryDict)
                    {
                        //Paie en or
                        if (Banker.Deposit(kvp.Key, kvp.Value))
                        {
                            kvp.Key.SendMessage(HueManager.GetHue(HueManagerList.Green), "Votre guilde a déposé votre salaire de " + kvp.Value + " pièces d'or dans votre coffre de banque.");
                        }
                        else
                        {
                            kvp.Key.SendMessage(HueManager.GetHue(HueManagerList.Green), "Un messager de votre guilde a déposé votre salaire de " + kvp.Value + " pièces d'or dans votre sac.");
                            kvp.Key.AddToBackpack(new BankCheck(kvp.Value));
                        }

                        PayLog(kvp.Key, kvp.Value);
                    }
                }
            }
        }

        /// <summary>
        /// Imprimer dans un fichier la liste des salaires donnés aux mobiles.
        /// </summary>
        private static void PayLog(Mobile m, int amount)
        {
            if (m != null && m.Account != null)
            {
                string path = "Logs/PayLogs/";
                string fileName = path + m.Account.Username + ".txt";

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                using (StreamWriter sw = new StreamWriter(fileName, true))
                    sw.WriteLine(DateTime.Now.ToString() + ","  + m.Name + "," + amount.ToString() + "\n");  // CSV fIle type..
            }
        }

        /// <summary>
        /// Retourne tous les titres que possèdent le mobile dans toutes les guildes
        /// </summary>
        /// <param name="m">Mobile dont on veut tous les titres</param>
        /// <returns>Tableau de strings avec tous les titres à l'intérieur</returns>
        public static List<String> GetTitreList(Mobile from)
        {
            List<String> titlesTable = new List<String>();

            foreach (NewGuildRecruterStone guild in m_NewGuildsList)
            {
                if (guild.m_RankMobiles.ContainsKey(from))
                {
                    titlesTable.Add(guild.GetTitleByRank((int)guild.m_RankMobiles[from].Rank));
                }
            }

            return titlesTable;
        }

        /// <summary>
        /// Retourne toutes les guildes du mobile
        /// </summary>
        /// <param name="m">Mobile dont on veut toutes les guildes</param>
        /// <returns>Tableau de NewGuildHandler avec tous les NewGuildHandler à l'intérieur</returns>
        public static List<NewGuildRecruterStone> GetGuilds(Mobile from)
        {
            List<NewGuildRecruterStone> guildTable = new List<NewGuildRecruterStone>();

            foreach (NewGuildRecruterStone guild in m_NewGuildsList)
            {
                if (guild.m_RankMobiles.ContainsKey(from))
                    guildTable.Add(guild);
            }
            return guildTable;
        }

        #endregion

        #region Actions
        /// <summary>
        /// Ajouter un mobile, avec un rang 0 par défaut, puisque n'importe qui peut s'ajouter
        /// </summary>
        /// <param name="m">Le mobile qu'on veut ajouter.</param>
        public void AddGuildMember(Mobile m)
        {
            if (m != null)
            {
                NewGuildRank rank = new NewGuildRank();

                if (!m_RankMobiles.ContainsKey(m))
                    m_RankMobiles.Add(m, rank);
            }
        }

        /// <summary>
        /// Retirer un mobile, s'il est membre de cette guilde.
        /// </summary>
        /// <param name="m">Le mobile à retirer.</param>
        public void RemoveGuildMember(Mobile m)
        {
            if (m != null)
            {
                if (m_RankMobiles.ContainsKey(m))
                    m_RankMobiles.Remove(m);
            }
        }

        /// <summary>
        /// Vérifier si le rang existe
        /// </summary>
        /// <param name="m">Le rang à vérifier</param>
        private static bool IsValidRank(int rank)
        {
            return (rank >= 0 && rank <= _RANKMAX);
        }

        /// <summary>
        /// Augmenter le rang du mobile si c'est possible, rang + 1
        /// </summary>
        /// <param name="m">Mobile dont on veut augmenter le rang.</param>
        public void RankUp(Mobile m)
        {
            if (m_RankMobiles.ContainsKey(m))
            {
                if (m_RankMobiles[m].Rank >= 0 && m_RankMobiles[m].Rank < _RANKMAX)
                    m_RankMobiles[m].Rank++;
            }
        }

        /// <summary>
        /// Diminuer le rang du mobile si c'est possible, rang - 1
        /// </summary>
        /// <param name="m">Mobile dont on veut diminuer le rang.</param>
        public void RankDown(Mobile m)
        {
            if (m_RankMobiles.ContainsKey(m))
            {
                if (m_RankMobiles[m].Rank > 0 && m_RankMobiles[m].Rank <= _RANKMAX)
                    m_RankMobiles[m].Rank--;
            }
        }

        #endregion

        #region Constructor
        [Constructable]
        public NewGuildRecruterStone() : base("Ressource Humaine")
        {
           // Name = "Pierre de guilde";
            //Movable = false;

            if (m_NewGuildsList == null)
                m_NewGuildsList = new ArrayList();

            m_NewGuildsList.Add(this);

            m_RankMobiles = new Dictionary<Mobile, NewGuildRank>();

            newGuildRankList = new List<NewGuildRank>();

            for (int i = 0; i <= _RANKMAX; i++)
            {
                NewGuildRank newGuildRank = new NewGuildRank();
                newGuildRank.Rank = i;
                if (i > 0)
                {
                    newGuildRank.Title = "Écrivez le nom du titre " + i + " ici.";
                    newGuildRank.Salary = 100;
                }
                else
                {
                    newGuildRank.Rank = i;
                    newGuildRank.Title = "Non-confirmé";
                    newGuildRank.Salary = 0;
                }
                    
                newGuildRankList.Add(newGuildRank);
            }
        }

        public NewGuildRecruterStone(Serial serial) : base( serial )
        {

        }

        public override void OnDoubleClick(Mobile from)
        {
            from.SendGump(new NewGuildGump(from, this));
        }

        public override void Delete()
        {
            if (m_NewGuildsList != null)
                m_NewGuildsList.Remove(this);

            base.Delete();
        }
        #endregion

        #region Serialize/Deserialize
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version

            writer.Write(m_RankMobiles.Count);

            foreach (KeyValuePair<Mobile, NewGuildRank> pair in m_RankMobiles)
            {
                writer.Write(pair.Key);
                writer.Write(pair.Value.Rank);
                writer.Write(pair.Value.Salary);
                writer.Write(pair.Value.Title);
            }

            writer.Write(NewGuildTitle);

            writer.Write(NewGuildDescription);

            writer.Write(newGuildRankList.Count);

            foreach (NewGuildRank ngr in newGuildRankList)
            {
                writer.Write(ngr.Rank);
                writer.Write(ngr.Salary);
                writer.Write(ngr.Title);
            }
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            if (m_RankMobiles == null)
                m_RankMobiles = new Dictionary<Mobile, NewGuildRank>();

            int count = reader.ReadInt();

            for (int i = 0; i < count; ++i)
            {
                Mobile key = reader.ReadMobile();
                int rank = reader.ReadInt();
                int salary = reader.ReadInt();
                string title = reader.ReadString();

                NewGuildRank newGuildRank = new NewGuildRank();

                newGuildRank.Rank = rank;
                newGuildRank.Salary = salary;
                newGuildRank.Title = title;

                if (key != null)
                    m_RankMobiles.Add(key, newGuildRank);
            }

            NewGuildTitle = reader.ReadString();

            NewGuildDescription = reader.ReadString();

            if (newGuildRankList == null)
                newGuildRankList = new List<NewGuildRank>();

            count = reader.ReadInt();

            for (int i = 0; i < count; ++i)
            {
                int rank = reader.ReadInt();
                int salary = reader.ReadInt();
                string title = reader.ReadString();

                NewGuildRank newGuildRank = new NewGuildRank();

                newGuildRank.Rank = rank;
                newGuildRank.Salary = salary;
                newGuildRank.Title = title;

                if (newGuildRank != null)
                    newGuildRankList.Add(newGuildRank);
            }

            if (m_NewGuildsList == null)
                m_NewGuildsList = new ArrayList();

            m_NewGuildsList.Add(this);
        }
        #endregion
    }    
}
        