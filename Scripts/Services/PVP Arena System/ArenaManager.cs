using Server.Gumps;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.ArenaSystem
{
    public class ArenaManager : AnimalTrainer
    {
        public override bool IsActiveVendor => false;
        public override bool IsActiveBuyer => false;
        public override bool IsActiveSeller => false;
        public override bool CanTeach => false;

        [CommandProperty(AccessLevel.GameMaster)]
        public PVPArena Arena { get; set; }

        [Constructable]
        public ArenaManager(PVPArena arena)
        {
            Title = "Commis de l'arene";

            Arena = arena;
            CantWalk = true;
        }

        public override void InitBody()
        {
            Female = true;
			Body = 0x191;

			base.Race.RemoveRace(this);

			Race.GetRace(0).AddRace(this, 1017);


			Name = "Lucia"; /*NameList.RandomName("female");*/

			HairItemID = 41883; /* Race.RandomHair(true);*/
			HairHue = 1154; /*Race.RandomHairHue();*/
           // Hue = Race.RandomSkinHue();

            SetStr(100);
            SetInt(100);
            SetDex(100);
        }

        public override void InitOutfit()
        {
			Bustier bust = new Bustier(1326);
			bust.Layer = Layer.MiddleTorso;
			SetWearable(bust);

			RobeProvocante2 robe = new RobeProvocante2(1237);
			robe.Layer = Layer.InnerTorso;
			SetWearable(robe);

			SetWearable(new Bottes10(), 1326);


			/* SetWearable(new PlateHaidate(), 1173);
			 SetWearable(new FemalePlateChest(), 1173);
			 SetWearable(new PlateGloves(), 1173);
			 SetWearable(new Bonnet(), 1173);
			 SetWearable(new Sandals(), 1173);
			 SetWearable(new Spellbook(), 1168);*/
		}

		public virtual void OfferResurrection(Mobile m)
        {
            Direction = GetDirectionTo(m);

            m.PlaySound(0x1F2);
            m.FixedEffect(0x376A, 10, 16);

            m.CloseGump(typeof(ResurrectGump));
            m.SendGump(new ResurrectGump(m, ResurrectMessage.Healer));
        }

        public override void OnMovement(Mobile m, Point3D oldLocation)
        {
            if (!m.Alive && !m.Frozen && InRange(m, 4) && !InRange(oldLocation, 4) && InLOS(m))
            {
                if (m.Map == null || !m.Map.CanFit(m.Location, 16, false, false))
                {
                    m.SendLocalizedMessage(502391); // Thou can not be resurrected there!
                }
                else
                {
                    OfferResurrection(m);
                }
            }
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (CanPaperdollBeOpenedBy(from))
            {
                DisplayPaperdollTo(from);
            }
        }

        public ArenaManager(Serial serial)
            : base(serial)
        {
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