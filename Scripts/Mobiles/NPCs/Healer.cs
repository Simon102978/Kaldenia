using Server.Gumps;
using Server.Items;
using Server.Network;
using System;
using System.Collections.Generic;

namespace Server.Mobiles
{
    public class Healer : BaseHealer
    {
        [Constructable]
        public Healer()
        {
            Title = "Soigneur";

            SetSkill(SkillName.Forensics, 80.0, 100.0);
            SetSkill(SkillName.SpiritSpeak, 80.0, 100.0);
            SetSkill(SkillName.Swords, 80.0, 100.0);
        }

        public Healer(Serial serial)
            : base(serial)
        {
        }

        public override bool CanTeach => true;
        public override bool IsActiveVendor => true;
        public override bool IsInvulnerable => true;
        public override bool CheckTeach(SkillName skill, Mobile from)
        {
            if (!base.CheckTeach(skill, from))
                return false;

            return (skill == SkillName.Forensics) ||
                   (skill == SkillName.Healing) ||
                   (skill == SkillName.SpiritSpeak) ||
                   (skill == SkillName.Swords);
        }

        public override void InitSBInfo()
        {
            SBInfos.Add(new SBHealer());
        }

        public override bool CheckResurrect(Mobile m)
        {
            if (m.Criminal)
            {
                Say(501222); // Thou art a criminal.  I shall not resurrect thee.
                return false;
            }
            else if (m.Murderer)
            {
                Say(501223); // Thou'rt not a decent and good person. I shall not resurrect thee.
                return false;
            }
            else if (m.Karma < 0)
            {
                Say(501224); // Thou hast strayed from the path of virtue, but thou still deservest a second chance.
            }

            return true;
        }

		private static readonly Dictionary<Mobile, Timer> m_ExpireTable = new Dictionary<Mobile, Timer>();
		public static BaseCreature[] GetDeadPets(Mobile from)
		{
			List<BaseCreature> pets = new List<BaseCreature>();
			IPooledEnumerable eable = from.GetMobilesInRange(12);

			foreach (Mobile m in eable)
			{
				BaseHire bc = m as BaseHire;
				

				if (bc != null && bc.IsDeadBondedPet && bc.ControlMaster == from && from.InLOS(bc))
					pets.Add(bc);			
			}
			eable.Free();

			if (from.Backpack != null)
			{
				BrokenAutomatonHead head = from.Backpack.FindItemByType(typeof(BrokenAutomatonHead)) as BrokenAutomatonHead;

				if (head != null && head.Automaton != null && !head.Automaton.Deleted)
					pets.Add(head.Automaton);
			}

			return pets.ToArray();
		}

		public static int GetResurrectionFee(BaseCreature bc)
		{
			if (bc is KotlAutomaton)
				return 0;

			int fee = (int)(100 + Math.Pow(1.1041, bc.MinTameSkill));

			if (fee > 100)
				fee = 50;
			else if (fee < 100)
				fee = 50;

			return fee;
		}
		public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}