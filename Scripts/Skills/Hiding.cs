using Server.Multis;
using Server.Network;
using System;
using Server.Items;


namespace Server.SkillHandlers
{
    public class Hiding
    {

		private static readonly int[,] m_ArmorTable =
		{
            //	Gorget	Gloves	Helmet	Arms	Legs	Chest	Shield
            /* Cloth	*/ { 0, 0, 0, 0, 0, 0, 0 },
            /* Leather	*/ { 0, 0, 0, 0, 0, 0, 0 },
            /* Studded	*/ { 2, 2, 0, 4, 6, 10, 0 },
            /* Bone		*/ { 0, 5, 10, 10, 15, 25, 0 },
            /* Spined	*/ { 0, 0, 0, 0, 0, 0, 0 },
            /* Horned	*/ { 0, 0, 0, 0, 0, 0, 0 },
            /* Barbed	*/ { 0, 0, 0, 0, 0, 0, 0 },
            /* Ring		*/ { 0, 5, 0, 10, 15, 25, 0 },
            /* Chain	*/ { 0, 0, 10, 0, 15, 25, 0 },
            /* Plate	*/ { 5, 5, 10, 10, 15, 25, 0 },
            /* Dragon	*/ { 0, 5, 10, 10, 15, 25, 0 }
		};

		public static double HidingRequirement => 30;

		public static int[,] ArmorTable => m_ArmorTable;


		private static bool m_CombatOverride;
        public static bool CombatOverride
        {
            get
            {
                return m_CombatOverride;
            }
            set
            {
                m_CombatOverride = value;
            }
        }

		public static int GetArmorRating(Mobile m)
		{
			int ar = 0;

			for (int i = 0; i < m.Items.Count; i++)
			{
				BaseArmor armor = m.Items[i] as BaseArmor;

				if (armor == null)
					continue;

				int materialType = (int)armor.MaterialType;
				int bodyPosition = (int)armor.BodyPosition;

				if (materialType >= m_ArmorTable.GetLength(0) || bodyPosition >= m_ArmorTable.GetLength(1))
					continue;

				if (armor.ArmorAttributes.MageArmor == 0)
					ar += m_ArmorTable[materialType, bodyPosition];
			}

			return ar;
		}


		public static void Initialize()
        {
            SkillInfo.Table[21].Callback = OnUse;

			//SkillInfo.Table[(int)SkillName.Hiding].Callback = OnUse;
		}

        public static TimeSpan OnUse(Mobile m)
        {

			if (m.Hidden)
			{
				if (m.Skills[SkillName.Hiding].Base < HidingRequirement)
				{
					m.SendLocalizedMessage(502726); // You are not hidden well enough.  Become better at hiding.
					m.RevealingAction();
					BuffInfo.RemoveBuff(m, BuffIcon.HidingAndOrStealth);
				}
				else if (!m.CanBeginAction(typeof(Stealth)))
				{
					m.SendLocalizedMessage(1063086); // You cannot use this skill right now.
					m.RevealingAction();
					BuffInfo.RemoveBuff(m, BuffIcon.HidingAndOrStealth);
				}
				else
				{
					int armorRating = GetArmorRating(m);

					if (armorRating >= 42) //I have a hunch '42' was chosen cause someone's a fan of DNA
					{
						m.SendLocalizedMessage(502727); // You could not hope to move quietly wearing this much armor.
						m.RevealingAction();
						BuffInfo.RemoveBuff(m, BuffIcon.HidingAndOrStealth);
					}
					else if (m.CheckSkill(SkillName.Hiding, -20.0 + (armorRating * 2), 60.0 + (armorRating * 2)))
					{
						int steps = (int)(m.Skills[SkillName.Hiding].Value / 5.0);

						if (steps < 1)
							steps = 1;

						m.AllowedStealthSteps = steps;

						m.IsStealthing = true;

						m.SendLocalizedMessage(502730); // You begin to move quietly.

						BuffInfo.AddBuff(m, new BuffInfo(BuffIcon.HidingAndOrStealth, 1044107, 1075655));
						return TimeSpan.FromSeconds(10.0);
					}
					else
					{
						m.SendLocalizedMessage(502731); // You fail in your attempt to move unnoticed.
						m.RevealingAction();
						BuffInfo.RemoveBuff(m, BuffIcon.HidingAndOrStealth);
					}
				}

				return TimeSpan.FromSeconds(10.0);
			}
			else
			{
				if (m.Spell != null)
				{
					m.SendLocalizedMessage(501238); // You are busy doing something else and cannot hide.
					return TimeSpan.FromSeconds(1.0);
				}

				if (Engines.VvV.ManaSpike.UnderEffects(m))
				{
					return TimeSpan.FromSeconds(1.0);
				}

				if (m.Target != null)
				{
					Targeting.Target.Cancel(m);
				}

				double bonus = 0.0;

				BaseHouse house = BaseHouse.FindHouseAt(m);

				if (house != null && house.IsFriend(m))
				{
					bonus = 100.0;
				}

				//int range = 18 - (int)(m.Skills[SkillName.Hiding].Value / 10);
				int skill = Math.Min(100, (int)m.Skills[SkillName.Hiding].Value);
				int range = Math.Min((100 - skill) / 2 + 8, 18);    //Cap of 18 not OSI-exact, intentional difference

				bool badCombat = (!m_CombatOverride && m.Combatant is Mobile && m.InRange(m.Combatant.Location, range) && ((Mobile)m.Combatant).InLOS(m.Combatant));
				bool ok = (!badCombat /*&& m.CheckSkill( SkillName.Hiding, 0.0 - bonus, 100.0 - bonus )*/);

				if (ok)
				{
					if (!m_CombatOverride)
					{
						IPooledEnumerable eable = m.GetMobilesInRange(range);

						foreach (Mobile check in eable)
						{
							if (check.InLOS(m) && check.Combatant == m)
							{
								badCombat = true;
								ok = false;
								break;
							}
						}

						eable.Free();
					}

					ok = (!badCombat && m.CheckSkill(SkillName.Hiding, 0.0 - bonus, 100.0 - bonus));
				}

				if (badCombat)
				{
					m.RevealingAction();

					m.LocalOverheadMessage(MessageType.Regular, 0x22, 501237); // You can't seem to hide right now.

					return TimeSpan.Zero;
				}

				if (ok)
				{
					m.Hidden = true;
					m.Warmode = false;
					Spells.Sixth.InvisibilitySpell.RemoveTimer(m);
					Items.InvisibilityPotion.RemoveTimer(m);
					m.LocalOverheadMessage(MessageType.Regular, 0x1F4, 501240); // You have hidden yourself well.
				}
				else
				{
					m.RevealingAction();

					m.LocalOverheadMessage(MessageType.Regular, 0x22, 501241); // You can't seem to hide here.
				}

				return TimeSpan.FromSeconds(10.0);
			}

           
        }
    }
}
