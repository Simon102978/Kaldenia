using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
    public class MissiveContent
    {

		private string[] m_Lignes;
		private bool m_Vierge;
		private CustomPlayerMobile m_Destinataire;
		private Mobile m_Destinateur;
		private string m_DestinataireName;
		private string m_DestinateurName;

		public string[] Lignes
		{
			get { return m_Lignes; }
			set { m_Lignes = value; }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public bool Vierge
		{
			get { return m_Vierge; }
			set { m_Vierge = value; }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public CustomPlayerMobile Destinataire
		{
			get { return m_Destinataire; }
			set { m_Destinataire = value; }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public Mobile Destinateur
		{
			get { return m_Destinateur; }
			set { m_Destinateur = value; }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public string DestinataireName
		{
			get { return m_DestinataireName; }
			set { m_DestinataireName = value; }
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public string DestinateurName
		{
			get { return m_DestinateurName; }
			set { m_DestinateurName = value; }
		}


		public MissiveContent()
		{
			m_Vierge = true;

			m_Lignes = new string[13];
		}



		public void Serialize(GenericWriter writer)
		{

			writer.Write((int)0);

			writer.Write((int)m_Lignes.Length);

			for (int i = 0; i < m_Lignes.Length; ++i)
				writer.Write((string)m_Lignes[i]);

			writer.Write(m_Vierge);
			writer.Write(m_Destinataire);
			writer.Write(m_Destinateur);
			writer.Write((string)m_DestinataireName);
			writer.Write((string)m_DestinateurName);

		}

		public static MissiveContent Deserialize(GenericReader reader)
		{
			MissiveContent mc = new MissiveContent();


			int version = reader.ReadInt();

			switch (version)
			{

				case 0:
					{



						mc.m_Lignes = new string[reader.ReadInt()];

						for (int i = 0; i < mc.m_Lignes.Length; ++i)
							mc.m_Lignes[i] = reader.ReadString();

						mc.m_Vierge = reader.ReadBool();
						mc.m_Destinataire = (CustomPlayerMobile)reader.ReadMobile();
						mc.m_Destinateur = (CustomPlayerMobile)reader.ReadMobile();
						mc.m_DestinataireName = reader.ReadString();
						mc.m_DestinateurName = reader.ReadString();

						break;
					}
			}
			return mc;
		}




	}
}
