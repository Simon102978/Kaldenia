using Server.Items;
using Server.Spells;
using System.Collections.Generic;
using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	public class TitusFanatiqueBase : BaseCreature
	{
		public static List<string> RouxParole = new List<string>()
		{
			"Rejoins nous dans la ROUX-Volution !",
			"Traitre ! Cesse de vivre parmis les roux-étiques !",
			"La rousseur est la vie !",
			"Titus te sauveras !",
			"Tu pourriras avec les roux-étiques !",
			"Gloire à Titus et à la Roux-volution !"


		};

		public static List<string> NonRouxParole = new List<string>()
		{
			"La ROUX-Volution ne peux plus être arrêter !",
			"Meurt roux-étique !",
			"Tu as penser à te teindre les cheveux?! Le roux t'irait mieux ?",
			"Titus vous tueras tous !",
			"Gloire à Titus et à la Roux-volution !",
			"ROUCISTE !"
		};

		public override TribeType Tribe => TribeType.Titusien;

		public override bool CanBeParagon => false;
		public DateTime m_LastParole = DateTime.MinValue;

		public TitusFanatiqueBase(Serial serial)
			: base(serial)
		{
		}

		public override void OnThink()
		{
			base.OnThink();
			Parole();

		}

		public override void OnDeath(Container c)
		{
			base.OnDeath(c);
			Parole();

		}

		public override void OnDamage(int amount, Mobile from, bool willKill)
		{
			Parole();

			if (willKill && HairItemID != 0)
			{
				for (int i = 0; i < Utility.Random(5); i++)
				{
					SpawnHelper(new CheveuxRoux(), Location);
				}
			}
			else if (HairItemID != 0)
			{

				for (int i = 0; i < Utility.Random(1,2); i++)
				{
					SpawnHelper(new CheveuxRoux(), Location);
				}

				HairItemID = 0;

				Say("*Perd ses cheveux* MES CHEVEUX !!!");
			}

			base.OnDamage(amount, from, willKill);
		}

		public override void AlterMeleeDamageTo(Mobile to, ref int damage)
		{

			Parole();
			base.AlterMeleeDamageTo(to, ref damage);
		}


		public override void Attack(IDamageable e)
		{
			Parole();
			base.Attack(e);
		}

		public void SpawnHelper(BaseCreature helper, Point3D location)
		{
			if (helper == null)
				return;

			helper.Home = location;
			helper.RangeHome = 4;

			if (Combatant != null)
			{
				helper.Warmode = true;
				helper.Combatant = Combatant;
			}


			BaseCreature.Summon(helper, false, this, this.Location, -1, TimeSpan.FromMinutes(2));
			helper.MoveToWorld(location, Map);
		}

		public override void DoHarmful(IDamageable target, bool indirect)
		{
			Parole();

			base.DoHarmful(target, indirect);
		}

		public void Parole()
		{

			if (m_LastParole < DateTime.Now && Combatant != null)
			{
				if (Combatant is CustomPlayerMobile cp)
					if (cp.CheckRoux())
						Say(RouxParole[Utility.Random(RouxParole.Count)]);
					else
						Say(NonRouxParole[Utility.Random(NonRouxParole.Count)]);

				m_LastParole = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(60, 90));
			}





		}





		public TitusFanatiqueBase(AIType aiType, FightMode fightMode, int rangePerception, int rangeFight, double activeSpeed, double passiveSpeed)
			: base(aiType, fightMode, rangePerception, rangeFight, activeSpeed, passiveSpeed)
		{

		}






		public int RouxCouleur()
		{
			var roux = 1602;

			switch (Utility.Random(3))
			{
				case 0:
					Utility.Random(1602, 52);
					break;
				case 1:
					Utility.Random(1502, 31);
					break;
				case 2:
					Utility.Random(1202, 23);
					break;

				default:
					break;
			}

			return roux;
		}






		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(0); // version


		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			var version = reader.ReadInt();


		}

	}
}
