using System;
using System.Linq;
using System.Runtime.InteropServices;
using Server.Items;
using System.Collections.Generic;

namespace Server.Misc
{
	public class Coiffure
	{
		public static List<Coiffure> coiffure = new List<Coiffure>();


		private int m_Id;
		private int m_itemId;
		private double m_Skill;
		private bool m_Barbe = false;


		public int Id { get => m_Id; set => m_Id = value; }
		public int ItemId { get => m_itemId; set => m_itemId = value; }

		public double SkillRequis { get => m_Skill; set => m_Skill = value; }

		public bool Barbe { get => m_Barbe; set => m_Barbe = value; }

		public static Coiffure GetCoiffure(int itemId)
		{
			foreach (Coiffure item in coiffure)
			{
				if (item.ItemId == itemId)
				{
					return item;
				}
			}

			return null;

		}


		public static void Configure()
		{
			Coiffure.Register(new Coiffure(41861, 0, false));
			Coiffure.Register(new Coiffure(41862, 15, false));
			Coiffure.Register(new Coiffure(41863, 20, false));
			Coiffure.Register(new Coiffure(41864, 20, false));
			Coiffure.Register(new Coiffure(41865, 75, false));
			Coiffure.Register(new Coiffure(41866, 50, false));
			Coiffure.Register(new Coiffure(41867, 65, false));
			Coiffure.Register(new Coiffure(41868, 60, false));
			Coiffure.Register(new Coiffure(41869, 20, false));
			Coiffure.Register(new Coiffure(41870, 30, false));
			Coiffure.Register(new Coiffure(41871, 72, false));
			Coiffure.Register(new Coiffure(41872, 33, false));
			Coiffure.Register(new Coiffure(41873, 67, false));
			Coiffure.Register(new Coiffure(41874, 74, false));
			Coiffure.Register(new Coiffure(41875, 63, false));
			Coiffure.Register(new Coiffure(41876, 64, false));
			Coiffure.Register(new Coiffure(41877, 51, false));
			Coiffure.Register(new Coiffure(41878, 53, false));
			Coiffure.Register(new Coiffure(41879, 54, false));
			Coiffure.Register(new Coiffure(41880, 45, false));
			Coiffure.Register(new Coiffure(41881, 66, false));
			Coiffure.Register(new Coiffure(41882, 57, false));
			Coiffure.Register(new Coiffure(41883, 59, false));
			Coiffure.Register(new Coiffure(41884, 47, false));
			Coiffure.Register(new Coiffure(41885, 75, false));
			Coiffure.Register(new Coiffure(41886, 55, false));
			Coiffure.Register(new Coiffure(41887, 72, false));
			Coiffure.Register(new Coiffure(41888, 42, false));
			Coiffure.Register(new Coiffure(41889, 49, false));
			Coiffure.Register(new Coiffure(41890, 120, false));
			Coiffure.Register(new Coiffure(41891, 68, false));
			Coiffure.Register(new Coiffure(41892, 43, false));
			Coiffure.Register(new Coiffure(41893, 46, false));
			Coiffure.Register(new Coiffure(41894, 64, false));
			Coiffure.Register(new Coiffure(41895, 43, true));
			Coiffure.Register(new Coiffure(41896, 45, true));
			Coiffure.Register(new Coiffure(41897, 51, true));
			Coiffure.Register(new Coiffure(41898, 55, true));
			Coiffure.Register(new Coiffure(41899, 59, true));
			Coiffure.Register(new Coiffure(41900, 71, true));
			Coiffure.Register(new Coiffure(41901, 69, true));
			Coiffure.Register(new Coiffure(41902, 68, true));
			Coiffure.Register(new Coiffure(41903, 75, true));
			Coiffure.Register(new Coiffure(41904, 73, true));
			Coiffure.Register(new Coiffure(41905, 62, true));
			Coiffure.Register(new Coiffure(41906, 72, true));
			Coiffure.Register(new Coiffure(41907, 70, true));
			Coiffure.Register(new Coiffure(41908, 69, true));
			Coiffure.Register(new Coiffure(41909, 68, true));
			Coiffure.Register(new Coiffure(41910, 67, true));
			Coiffure.Register(new Coiffure(41911, 66, true));
			Coiffure.Register(new Coiffure(41912, 65, true));
			Coiffure.Register(new Coiffure(41913, 45, true));
			Coiffure.Register(new Coiffure(41914, 40, true));
			Coiffure.Register(new Coiffure(41915, 35, true));
			Coiffure.Register(new Coiffure(41916, 25, true));
			Coiffure.Register(new Coiffure(41917, 10, true));




			Coiffure.Register(new Coiffure(0x2044, 30, false));
			Coiffure.Register(new Coiffure(0x2045, 30, false));
			Coiffure.Register(new Coiffure(0x2046, 30, false));
			Coiffure.Register(new Coiffure(0x203C, 30, false));
			Coiffure.Register(new Coiffure(0x203B, 30, false));
			Coiffure.Register(new Coiffure(0x203D, 30, false));
			Coiffure.Register(new Coiffure(0x2047, 30, false));
			Coiffure.Register(new Coiffure(0x2048, 30, false));
			Coiffure.Register(new Coiffure(0x2049, 30, false));
			Coiffure.Register(new Coiffure(0x204A, 30, false));




			Coiffure.Register(new Coiffure(0x203E, 30, true));
			Coiffure.Register(new Coiffure(0x203f, 30, true));
			Coiffure.Register(new Coiffure(0x2040, 30, true));
			Coiffure.Register(new Coiffure(0x2041, 30, true));
			Coiffure.Register(new Coiffure(0x204B, 30, true));
			Coiffure.Register(new Coiffure(0x204C, 30, true));
			Coiffure.Register(new Coiffure(0x204D, 30, true));





		}









		public Coiffure(int itemId, double skillsRequis, bool barbe)
		{	
			m_itemId = itemId;
			m_Skill = skillsRequis;
			m_Barbe = barbe;
		}

		public static void Register(Coiffure coif)
		{
			coif.Id = coiffure.Count;

			Coiffure.coiffure.Add(coif);
		}



	}



	










}
