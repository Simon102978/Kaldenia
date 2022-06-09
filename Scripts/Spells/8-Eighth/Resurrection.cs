using Server.Gumps;
using Server.Targeting;
using Server.Items;
using Server.Mobiles;

namespace Server.Spells.Eighth
{
    public class ResurrectionSpell : MagerySpell
    {
        private static readonly SpellInfo m_Info = new SpellInfo(
            "Resurrection", "An Corp",
            245,
            9062,
            Reagent.Bloodmoss,
            Reagent.Garlic,
            Reagent.Ginseng);
        public ResurrectionSpell(Mobile caster, Item scroll)
            : base(caster, scroll, m_Info)
        {
        }

		public override MagicAptitudeRequirement[] AffinityRequirements { get { return new MagicAptitudeRequirement[] { new MagicAptitudeRequirement(MagieType.Obeissance, 16) }; } }

		public override SpellCircle Circle => SpellCircle.Eighth;

		private bool m_Corpse = false;

        public override void OnCast()
        {
            Caster.Target = new InternalTarget(this);
        }

        public void Target(Mobile m)
        {
            if (!Caster.CanSee(m) && !m_Corpse)
            {
                Caster.SendLocalizedMessage(500237); // Target can not be seen.
            }
            else if (m == Caster)
            {
                Caster.SendLocalizedMessage(501039); // Thou can not resurrect thyself.
            }
            else if (!Caster.Alive)
            {
                Caster.SendLocalizedMessage(501040); // The resurrecter must be alive.
            }
            else if (m.Alive)
            {
                Caster.SendLocalizedMessage(501041); // Target is not dead.
            }
            else if (!Caster.InRange(m, 5) && !m_Corpse)
            {
                Caster.SendLocalizedMessage(501042); // Target is not close enough.
            }
            else if (!m.Player)
            {
                Caster.SendLocalizedMessage(501043); // Target is not a being.
            }
            else if (m.Map == null || !m.Map.CanFit(m.Location, 16, false, false))
            {
                Caster.SendLocalizedMessage(501042); // Target can not be resurrected at that location.
                m.SendLocalizedMessage(502391); // Thou can not be resurrected there!
            }
            else if (m.Region != null && m.Region.IsPartOf("Khaldun"))
            {
                Caster.SendLocalizedMessage(1010395); // The veil of death in this area is too strong and resists thy efforts to restore life.
            }
            else if (CheckBSequence(m, true))
            {
                SpellHelper.Turn(Caster, m);

                m.PlaySound(0x214);
                m.FixedEffect(0x376A, 10, 16);


				if (m is CustomPlayerMobile)
				{
					CustomPlayerMobile cm = (CustomPlayerMobile)m;

					if (m_Corpse)
					{
						cm.MoveToWorld(cm.Corpse.Location, cm.Corpse.Map);
					}

					cm.PlaySound(0x214);
					cm.FixedEffect(0x376A, 10, 16);
					cm.Resurrect();
				}
				else
				{
					m.CloseGump(typeof(ResurrectGump));
					m.SendGump(new ResurrectGump(m, Caster));
				}

              
            }

            FinishSequence();
        }

        private class InternalTarget : Target
        {
            private readonly ResurrectionSpell m_Owner;
            public InternalTarget(ResurrectionSpell owner)
                : base(1, false, TargetFlags.Beneficial)
            {
                m_Owner = owner;
            }

            protected override void OnTarget(Mobile from, object o)
            {
                if (o is Mobile)
                {
                    m_Owner.Target((Mobile)o);
                }
				else if (o is Corpse)
				{
					Corpse c = (Corpse)o;

					if (c.Owner is CustomPlayerMobile)
					{
						m_Owner.m_Corpse = true;
						m_Owner.Target((Mobile)c.Owner);
					}
				}
            }

            protected override void OnTargetFinish(Mobile from)
            {
                m_Owner.FinishSequence();
            }
        }
    }
}
