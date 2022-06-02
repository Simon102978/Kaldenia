using System;
using System.Collections;
using Server.Gumps;
using Server.Items;
using Server.Network;
using Server.Mobiles;

namespace Server
{
    public enum Month
    {
        Germinal,
        Floreal,
        Thermidor,
        Fructidor,
        Brumaire,
        Frimaire,
        Pluviose,
        Nivose,
        Ventor,
        Mortor
    }

    public enum Day
    {
        Primidi,
        Duodi,
        Tridi,
        Quartidi,
        Quintidi,
        Sextidi,
        Septidi,
        Octidi,
        Novindi
    }

    public enum Season
    {
        Spring,
        Summer,
        Automn,
        Winter,
        Abyss
    }
}

namespace Server.Items
{
	public class Calendrier : Item
	{
		[Constructable]
		public Calendrier() : base( 7187 )
		{
			Name = "calendrier";
			Weight = 1.0;
        }

        public class CalendrierEntry
        {
            private Month m_Month;
            private Season m_Season;
            private int m_Days;

            public Month Month { get { return m_Month; } }
            public Season Season { get { return m_Season; } }
            public int Days { get { return m_Days; } }

            public CalendrierEntry(Month month, Season season, int days)
            {
                m_Month = month;
                m_Season = season;
                m_Days = days;
            }
        }

        public static CalendrierEntry[] m_Entries = new CalendrierEntry[]
			{
				new CalendrierEntry( Month.Germinal, Season.Spring, 36 ),
				new CalendrierEntry( Month.Floreal, Season.Spring, 37 ),
				new CalendrierEntry( Month.Thermidor, Season.Summer, 36 ),
				new CalendrierEntry( Month.Fructidor, Season.Summer, 37 ),
				new CalendrierEntry( Month.Brumaire, Season.Automn, 36 ),
				new CalendrierEntry( Month.Frimaire, Season.Automn, 36 ),
				new CalendrierEntry( Month.Pluviose, Season.Winter, 35 ),
				new CalendrierEntry( Month.Nivose, Season.Winter, 36 ),
				new CalendrierEntry( Month.Ventor, Season.Abyss, 35 ),
				new CalendrierEntry( Month.Mortor, Season.Abyss, 35 )
			};

        public static int GetMonth(int totalDays)
        {
            totalDays %= 360;
            int month = 0;

            for (int i = 0; i < m_Entries.Length; ++i)
            {
                if (totalDays >= m_Entries[i].Days)
                {
                    totalDays -= m_Entries[i].Days;
                    month++;
                }
                else
                {
                    break;
                }
            }

            return month + 1;
        }

        public static int GetDay(int totalDays)
        {
            totalDays %= 360;
            int month = GetMonth(totalDays) - 1;

            //Console.WriteLine(totalDays);
            //Console.WriteLine(month);

            for (int i = 0; i < m_Entries.Length; ++i)
            {
                if (month > 0 && totalDays > m_Entries[i].Days)
                {
                    totalDays -= m_Entries[i].Days;
                    month--;
                }
                else
                {
                    break;
                }
            }

            return totalDays;
        }

        public static void GetDate(out int year, out int month, out int day)
        {
            TimeSpan timeSpan = DateTime.Now - Clock.ServerStart;

            int totalMinutes = (int)(timeSpan.TotalSeconds / Clock.SecondsPerUOMinute);
            int totalDays = totalMinutes / 1440;

            year = (totalMinutes / 518400) + 15 ;
            month = GetMonth(totalDays);
            day = GetDay(totalDays);
        }

        public static void OnSeasonChange(Season seacon)
        {
            ArrayList items = new ArrayList(World.Items.Values);

            for (int i = 0; i < items.Count; ++i)
            {
                if (items[i] is Item)
                {
                    Item item = (Item)items[i];

               
                }
            }
        }

        public override void OnDoubleClick(Mobile from)
        {
            try
            {
                int year;
                int month;
                int day;

                GetDate(out year, out month, out day);

                LabelTo(from, String.Format("{0} {1} de l'an {2}", day, m_Entries[month - 1].Month, year));
				
				from.SendGump(new CalendrierGump(from, CalGumpPage.Page1, this));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public Calendrier(Serial serial) : base(serial)
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