using System;
using Server;
using Server.Items;
using Server.Network;
using Server.Mobiles;
using Server.Targeting;
using Server.Spells;
using Server.Gumps;

namespace Server.Items
{
	public abstract class Fouet : Item
	{
		private int m_MaxRange;

		[CommandProperty(AccessLevel.GameMaster)]
		public int MaxRange
		{
			get { return m_MaxRange; }
			set { m_MaxRange = value; }
		}

		public Fouet() : this(4)
		{
		}

		public Fouet(int maxRange) : base(5742)
		{
			Layer = Layer.OneHanded;
			Name = "fouet";
			Weight = 2.0;

			m_MaxRange = maxRange;
		}

		public Fouet(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)1); // version

			writer.Write((int)m_MaxRange);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

			switch (version)
			{
				case 1:
					{
						m_MaxRange = reader.ReadInt();
						break;
					}
			}

			Layer = Layer.OneHanded;
		}

		public override bool CanEquip(Mobile from)
		{
			Item item = from.FindItemOnLayer(Layer.TwoHanded);

			if (item != null && item is BaseShield)
			{
				from.SendMessage("Vous ne pouvez pas équipper un fouet en ayant un bouclier à la main.");
				return false;
			}

			return true;
		}

		public virtual void Fouetage(Mobile from, Mobile receveur)
		{
			PlayerMobile pm = from as PlayerMobile;

			if (pm != null)
			{
				pm.RevealingAction();


				if (!pm.Mounted)
					return;

				SpellHelper.Turn(from, receveur);

				Item handOne = receveur.FindItemOnLayer(Layer.OneHanded);
				Item handTwo = receveur.FindItemOnLayer(Layer.TwoHanded);

				if (handTwo != null && handTwo is BaseArmor)
					handTwo = null;

				double snooping = pm.Skills.Snooping.Value;
				double stealing = pm.Skills.Stealing.Value;

				int chance_de_voler = (int)((snooping + stealing) / 20) * 2;
				int chance = (int)((snooping + stealing) / 15) * 2;

				bool goodtarget = !(receveur is OrderGuard) && !(receveur is Copie) && !(receveur is Fetichisme);

				if (receveur.Spell != null)
				{
					if (receveur is PlayerMobile && ((PlayerMobile)receveur) != null)
							chance -= (int)(receveur.Skills[SkillName.Wrestling].Value * 0.15);

					if (chance > Utility.Random(100))
					{
						receveur.Spell.OnCasterHurt();
						from.SendMessage("Vous dérangez votre cible !");
						Animation(from, receveur);
					}

					if (from is PlayerMobile)
						AOS.Damage(receveur, from, (int)((PlayerMobile)from).Skills[SkillName.Wrestling].Value, 100);
				}
				else if (handOne != null && handTwo == null)
				{
					if (goodtarget && chance_de_voler > Utility.Random(100))
					{
						if (from.AddToBackpack(handOne))
						{
							from.SendMessage("Vous volez l'arme de votre cible !");
						}
						else
						{
							handOne.MoveToWorld(from.Location);
							from.SendMessage("Vous faites tomber l'arme de votre cible !");
						}

						Animation(from, receveur);
					}
					else if (goodtarget && chance > Utility.Random(100))
					{
						handOne.MoveToWorld(receveur.Location);
						from.SendMessage("Vous faites tomber l'arme de votre cible !");
						Animation(from, receveur);
					}
					else
						from.SendMessage("Vous échouez à voler ou à faire tomber l'arme de votre cible !");

					if (from is PlayerMobile)
						AOS.Damage(receveur, from, (int)((PlayerMobile)from).Skills[SkillName.Wrestling].Value, 100);

				}
				else if (handOne == null && handTwo != null)
				{
					if (goodtarget && chance > Utility.Random(100))
					{
						handTwo.MoveToWorld(receveur.Location);
						from.SendMessage("Vous faites tomber l'arme de votre cible !");
						Animation(from, receveur);
					}
					else
						from.SendMessage("Vous échouez à faire tomber l'arme de votre cible !");

					if (from is PlayerMobile)
						AOS.Damage(receveur, from, (int)((PlayerMobile)from).Skills[SkillName.Wrestling].Value, 100);
				}
				else
				{
					from.SendMessage("Votre cible ne porte aucune arme !");
					receveur.PlaySound(0x238);

					if (from is PlayerMobile)
						AOS.Damage(receveur, from, (int)((PlayerMobile)from).Skills[SkillName.Wrestling].Value, 100);
				}
			}
		}

		public void Animation(Mobile from, Mobile receveur)
		{
			if (receveur is PlayerMobile)
			{
				PlayerMobile rec = (PlayerMobile)receveur;

			}

			receveur.PlaySound(0x145);
			receveur.SendMessage("Quelque chose vous heurte !");
			from.SendMessage("Vous fouetez votre cible !");
			receveur.RevealingAction();

			if (!receveur.Mounted && receveur.Body.IsHuman)
				receveur.Animate(20, 5, 1, true, false, 0);
		}

		public override void OnAosSingleClick(Mobile from)
		{
			LabelTo(from, Name);
			LabelTo(from, String.Format("[{0} mêtres]", m_MaxRange));
		}

		public override void OnDoubleClick(Mobile from)
		{
			if (!from.CanBeginAction(typeof(Fouet)))
			{
				from.SendMessage("Vous devez attendre avant d'utiliser le fouet à nouveau.");
			}
			else if (from.Items.Contains(this))
			{
				from.Target = new TargetSystem(this);
				from.SendMessage("Qui voulez-vous foueter ?");
			}
			else
				from.SendMessage("Vous devez avoir le fouet en main pour l'utiliser.");
		}

		private void Fouet_OnTick(object state)
		{
			Mobile from = (Mobile)state;

			if (from != null)
			{
				from.EndAction(typeof(Fouet));
			}
		}

		private class TargetSystem : Target
		{
			private Fouet m_Fouet;

			public TargetSystem(Fouet fouet) : base(12, false, TargetFlags.None)
			{
				m_Fouet = fouet;
			}

			protected override void OnTarget(Mobile from, object targeted)
			{
				if (!from.CanBeginAction(typeof(Fouet)))
				{
					from.SendMessage("Vous devez attendre avant d'utiliser le fouet à nouveau.");
				}
				else if (!from.Items.Contains(m_Fouet))
				{
					from.SendMessage("Vous devez avoir le fouet en main pour l'utiliser.");
				}
				else if (targeted is Mobile)
				{
					Mobile m = (Mobile)targeted;

					if (m == from)
					{
						from.SendMessage("Vous ne pouvez pas vous foueter.");
					}
					else if (!from.InRange(m.Location, m_Fouet.MaxRange))
					{
						from.SendMessage("Votre fouet n'est pas assez long.");
					}
					else if (from is OrderGuard)
					{
						from.SendMessage("Vous ne pouvez pas fouetter un garde.");
					}
					else
					{
						m_Fouet.Fouetage(from, m);

						if (!from.Mounted)
							from.Animate(9, 5, 1, true, false, 0);
						else
							from.Animate(26, 5, 1, true, false, 0);

						from.BeginAction(typeof(Fouet));

						double bonus = 0;


						Timer.DelayCall(TimeSpan.FromSeconds(12.0 - bonus), new TimerStateCallback(m_Fouet.Fouet_OnTick), from);
					}
				}
				else
				{
					from.SendMessage("Vous ne pouvez pas foueter cette cible.");
				}
			}
		}

		private class Fetichisme : Mobile
		{
		}

		private class Copie : Mobile
		{
		}

		private class OrderGuard : Mobile
		{
		}
	}
}