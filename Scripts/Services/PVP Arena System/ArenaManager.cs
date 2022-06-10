using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using System.Collections.Generic;

namespace Server.Engines.ArenaSystem
{
	[DeleteConfirm("Are you sure you want to delete this? Deleting this stone will remove this arena from the system.")]
	public class ArenaManager : AnimalTrainer
    {
        public override bool IsActiveVendor => false;
        public override bool IsActiveBuyer => false;
        public override bool IsActiveSeller => false;
        public override bool CanTeach => false;

        [CommandProperty(AccessLevel.GameMaster)]
        public PVPArena Arena { get; set; }

		[CommandProperty(AccessLevel.GameMaster)]
		public bool ShowArenaEffects
		{
			get { return false; }
			set { if (value) DoArenaEffects(); if (!value) HideArenaEffects(); }
		}

		
		[Constructable]
        public ArenaManager(PVPArena arena)
        {
            Title = "Commis";

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

		public override void OnSpeech(SpeechEventArgs e)
		{
			if (e.Speech.Contains("arena"))
			{
				OpenArena(e.Mobile);

			}


				base.OnSpeech(e);
		}

		public void OpenArena(Mobile from)
		{
			if (from is PlayerMobile && from.InRange(Location, 10))
			{
				PlayerMobile pm = from as PlayerMobile;

				if (pm.Young)
				{
					from.SendLocalizedMessage(1116002); // Young players and Trial Account users may not participate in duels.
				}
				else if (Arena != null && PVPArenaSystem.Enabled)
				{
					if (Arena.CurrentDuel != null && Arena.CurrentDuel.IsParticipant(pm))
					{
						if (Arena.CurrentDuel.InPreFight)
						{
							BaseGump.SendGump(new OfferDuelGump(pm, Arena.CurrentDuel, Arena, false, true));
						}
						else
						{
							from.SendLocalizedMessage(1116387); // Please wait until the session which you participated is finished completely.
						}
					}
					else
					{
						ArenaDuel duel = Arena.GetPendingDuel(from);

						if (duel == null)
						{
							ArenaDuel booked = PVPArenaSystem.Instance.GetBookedDuel(pm);

							if (booked != null)
							{
								BaseGump.SendGump(new OfferDuelGump(pm, booked, booked.Arena, true));
							}
							else
							{
								BaseGump.SendGump(new ArenaStoneGump(pm, Arena));
							}
						}
						else
						{
							BaseGump.SendGump(new PendingDuelGump(pm, duel, Arena));
						}
					}
				}
			}
			else
			{
				from.SendLocalizedMessage(502138); // That is too far away for you to use.
			}
		}



		private List<Item> _Items;

		public void DoArenaEffects()
		{
			if (Arena == null)
				return;

			_Items = new List<Item>();

			foreach (Rectangle2D rec in Arena.Definition.EffectAreas)
			{
				for (int x = rec.X; x < rec.X + rec.Width; x++)
				{
					for (int y = rec.Y; y < rec.Y + rec.Height; y++)
					{
						Static st = new Static(0x3709);
						st.MoveToWorld(new Point3D(x, y, Arena.Definition.ArenaZ), Map);
						_Items.Add(st);
					}
				}
			}
		}

		public void HideArenaEffects()
		{
			if (_Items == null)
				return;

			_Items.ForEach(s =>
			{
				s.Delete();
			});

			ColUtility.Free(_Items);
			_Items = null;
		}

		public override void Delete()
		{
			base.Delete();

			Timer.DelayCall(() =>
			{
				if (Arena != null && PVPArenaSystem.Instance != null)
				{
					PVPArenaSystem.Instance.AddBlockedArena(Arena);
				}
			});
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