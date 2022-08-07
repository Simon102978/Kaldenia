using Server.Items;
using Server.Spells;
using System.Collections.Generic;
using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	public class KuyaBase : BaseCreature
	{

		public DateTime DelayCharge;
		public DateTime m_GlobalTimer;

		public static List<string> ParoleKuya = new List<string>()
		{
			"Mourrez !"
		};

		public override TribeType Tribe => TribeType.Kuya;

		public override bool CanBeParagon => false;

		public DateTime m_LastParole = DateTime.MinValue;

		public KuyaBase(Serial serial)
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

			base.OnDamage(amount, from, willKill);
		}

		public override void AlterMeleeDamageTo(Mobile to, ref int damage)
		{

			Parole();
			base.AlterMeleeDamageTo(to, ref damage);
		}

		public override bool IsEnemy(Mobile m)
		{
			if (m is CustomPlayerMobile cp && cp.Race.RaceID == 5)
			{
				return false;
			}

			return base.IsEnemy(m);
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
						Say(ParoleKuya[Utility.Random(ParoleKuya.Count)]);

				m_LastParole = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(60, 90));
			}

		}

		public override bool CanRummageCorpses => true;

		public override bool AlwaysMurderer => true;

		public KuyaBase(AIType aiType, FightMode fightMode, int rangePerception, int rangeFight, double activeSpeed, double passiveSpeed)
			: base(aiType, fightMode, rangePerception, rangeFight, activeSpeed, passiveSpeed)
		{

		}

		public void Charge()
		{
			if (DelayCharge < DateTime.UtcNow)
			{
				if (Combatant is CustomPlayerMobile cp)
				{

					if (cp.CheckRoux())
					{
						Emote($"*Effectue l'attaque anti-roux vers {cp.Name}*");
						Say($"Mort aux roux !");

						cp.Damage(35);

						cp.Freeze(TimeSpan.FromSeconds(3));

						this.Location = cp.Location;
					}

				}


				DelayCharge = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(30, 50));
			}
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
