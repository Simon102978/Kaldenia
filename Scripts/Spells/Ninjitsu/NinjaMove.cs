using Server.Mobiles;

namespace Server.Spells
{
    public class NinjaMove : SpecialMove
    {
		public virtual MagicAptitudeRequirement[] AffinityRequirements { get { return new MagicAptitudeRequirement[] { new MagicAptitudeRequirement(MagieType.Arcane, 99) }; } }

		public override SkillName MoveSkill => SkillName.Magery;
        public override void CheckGain(Mobile m)
        {
            m.CheckSkill(MoveSkill, RequiredSkill - 12.5, RequiredSkill + 37.5);	//Per five on friday 02/16/07
        }

		public override bool Validate(Mobile from)
		{

			if (from is CustomPlayerMobile)
			{
				CustomPlayerMobile cp = (CustomPlayerMobile)from;

				if (cp != null && !VerifyAffinity(cp, AffinityRequirements))
				{
					cp.SendMessage("Vous n'avez pas les affinit??#$?&*s requises.");

					if (cp.AccessLevel > AccessLevel.Counselor)
					{
						foreach (MagicAptitudeRequirement item in AffinityRequirements)
						{
							cp.SendMessage(item.RequiredAffinity + ":" + item.RequiredValue.ToString());
						}
					}
					return false;
				}
			}


			return base.Validate(from);
		}

		public virtual bool VerifyAffinity(CustomPlayerMobile pm, MagicAptitudeRequirement[] affinity)
		{
			bool valid = false;

			for (int i = 0; !valid && i < affinity.Length; ++i)
			{
				MagieType affinite = affinity[i].RequiredAffinity;

				valid = (pm.GetAffinityValue(affinite) >= affinity[i].RequiredValue);
			}


			return valid;
		}


	}
}