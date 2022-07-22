using Server.Items;
using Server.Misc;
using System;
using System.Collections.Generic;

namespace Server.Mobiles
{
	[CorpseName("Le corps d'un Kuya")]
	public class Kuya : BaseCreature
    {
		public DateTime DelayCharge;
		private DateTime m_GlobalTimer;

		[Constructable]
        public Kuya()
            : base(AIType.AI_Samurai, FightMode.Aggressor, 10, 1, 0.2, 0.4)
        {
            Title = "Un Kuya";

			SetStr(200, 250);
			SetDex(31, 45);
			SetInt(75, 100);

			SetSkill(SkillName.ArmsLore, 64.0, 80.0);
            SetSkill(SkillName.Bushido, 80.0, 100.0);
            SetSkill(SkillName.Parry, 80.0, 100.0);
            SetSkill(SkillName.Swords, 80.0, 100.0);

            SpeechHue = Utility.RandomDyedHue();
			Race = BaseRace.GetRace(Utility.Random(4));

			Hue = Utility.RandomSkinHue();

			if (Female = Utility.RandomBool())
			{
				Body = 0x191;
				Name = NameList.RandomName("tokuno female");
			}
			else
			{
				Body = 0x190;
				Name = NameList.RandomName("tokuno male");
			}

			switch (Utility.Random(3))
            {
                case 0:
                    AddItem(new Lajatang());
                    break;
                case 1:
                    AddItem(new Wakizashi());
                    break;
                case 2:
                    AddItem(new NoDachi());
                    break;
            }

            switch (Utility.Random(3))
            {
                case 0:
                    AddItem(new LeatherSuneate());
                    break;
                case 1:
                    AddItem(new PlateSuneate());
                    break;
                case 2:
                    AddItem(new StuddedHaidate());
                    break;
            }

            switch (Utility.Random(4))
            {
                case 0:
                    AddItem(new LeatherJingasa());
                    break;
                case 1:
                    AddItem(new ChainHatsuburi());
                    break;
                case 2:
                    AddItem(new HeavyPlateJingasa());
                    break;
                case 3:
                    AddItem(new DecorativePlateKabuto());
                    break;
            }

            AddItem(new LeatherDo());
            AddItem(new LeatherHiroSode());
            AddItem(new SamuraiTabi(Utility.RandomNondyedHue())); // TODO: Hue

            int hairHue = Utility.RandomNondyedHue();

            Utility.AssignRandomHair(this, hairHue);

            if (Utility.Random(7) != 0)
                Utility.AssignRandomFacialHair(this, hairHue);
        }

        public override void GenerateLoot()
        {
			AddLoot(LootPack.Rich);
			AddLoot(LootPack.Others, Utility.RandomMinMax(1, 2));

		}


		public override void OnThink()
		{
			base.OnThink();

			if (Combatant != null)
			{
				if (m_GlobalTimer < DateTime.UtcNow)
				{

					if (!this.InRange(Combatant.Location, 3))
					{
						Charge();
					}
					

					m_GlobalTimer = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(10, 15));
				}


			}
		}

		public override void OnDamage(int amount, Mobile from, bool willKill)
		{

			if (Hits / HitsMax < 0.25 && GetDistanceToSqrt(Home) > 10)
			{

				int Range = 10;
				List<KuyaMage> targets = new List<KuyaMage>();

				IPooledEnumerable eable =  Map.GetMobilesInRange(Home);

				foreach (Mobile m in eable)
				{
					if (this != m && (m is KuyaMage km))
					{
						targets.Add(km);
					}
				}

				eable.Free();



				if (targets.Count > 0)
				{





					for (int i = 0; i < targets.Count; ++i)
					{
						KuyaMage m = targets[i];

						if (m.Hits == m.HitsMax)
						{
							Point3D location = this.Location;

							FixedParticles(0x3709, 1, 30, 9904, 1108, 6, EffectLayer.RightFoot);
							PlaySound(0x22F);

							this.Location = m.Location;


							m.FixedParticles(0x3709, 1, 30, 9904, 1108, 6, EffectLayer.RightFoot);
							m.PlaySound(0x22F);

							m.Location = location;
							m.Warmode = true;
							m.Combatant = this.Combatant;

							m.Say("Substitution !");

						}




					}
				}
			}

				base.OnDamage(amount, from, willKill);

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


		public override TribeType Tribe => TribeType.Kuya;

		public Kuya(Serial serial)
            : base(serial)
        {
        }

		public override bool ClickTitle => false;
		public override bool AlwaysMurderer => true;

		public override bool ShowFameTitle => false;

		public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.WriteEncodedInt(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadEncodedInt();
        }
    }
}
