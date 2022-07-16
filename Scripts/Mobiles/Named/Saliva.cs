using Server.Items;
using System.Collections.Generic;
using System.Collections;
using System;

namespace Server.Mobiles
{





    [CorpseName("Corps de Saliva")]
    public class Saliva : Harpy
    {
		public DateTime DelayHurlement;
		public DateTime DelayCoupVent;
		public DateTime DelayAttraction;
		private DateTime m_GlobalTimer;


		[Constructable]
        public Saliva()
            : base()
        {
            Name = "Saliva";
            Hue = 0x11E;

            SetStr(136, 206);
            SetDex(123, 222);
            SetInt(118, 127);

            SetHits(409, 842);

            SetDamage(17, 25);

            SetDamageType(ResistanceType.Physical, 100);

            SetResistance(ResistanceType.Physical, 46, 47);
            SetResistance(ResistanceType.Fire, 32, 40);
            SetResistance(ResistanceType.Cold, 34, 49);
            SetResistance(ResistanceType.Poison, 40, 48);
            SetResistance(ResistanceType.Energy, 35, 39);

            SetSkill(SkillName.Wrestling, 106.4, 128.8);
            SetSkill(SkillName.Tactics, 129.9, 141.0);
            SetSkill(SkillName.MagicResist, 84.3, 90.1);
        }

        public Saliva(Serial serial)
            : base(serial)
        {
        }

        public override void GenerateLoot()
        {
            AddLoot(LootPack.UltraRich, 2);

            AddLoot(LootPack.Parrot);
			AddLoot(LootPack.LootItem<Items.Gold>(100, 175));
			AddLoot(LootPack.RandomLootItem(new System.Type[] { typeof(SilverRing), typeof(Necklace), typeof(SilverNecklace), typeof(Collier), typeof(Collier2),  typeof(Collier3), typeof(Couronne3),  typeof(Collier4), typeof(Tiare), }, 10.0, 1, false, true));
		}

		public override void OnThink()
		{



			base.OnThink();

			if (Combatant != null)
			{
				if (m_GlobalTimer < DateTime.UtcNow)
				{

					if (!this.InRange(Combatant.Location,3))
					{
						switch (Utility.Random(3))
						{
							case 0:
								Hurlement();
								break;
							case 1:
								CoupVent();
								break;
							case 2:
								Attraction();
								break;

							default:
								break;
						}
					}

					m_GlobalTimer = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(10, 20));
				}
			

			}
		}

		

		public void Hurlement()
		{


			if (DelayHurlement < DateTime.UtcNow)
			{
					int Range = 10;
					List<Mobile> targets = new List<Mobile>();

					IPooledEnumerable eable = this.GetMobilesInRange(Range);

					foreach (Mobile m in eable)
					{
						if (this != m && !(m is Harpy) && !(m is StoneHarpy) && !m.IsStaff())
						{


							if (Core.AOS && !InLOS(m))
								continue;

							targets.Add(m);
						}
					}

					eable.Free();

					Effects.PlaySound(this, this.Map, 0x1FB);
					Effects.PlaySound(this, this.Map, 0x10B);
					Effects.SendLocationParticles(EffectItem.Create(this.Location, this.Map, EffectItem.DefaultDuration), 0x37CC, 1, 15, 97, 3, 9917, 0);

					Emote("*Lance un hurlement effroyable*");

					if (targets.Count > 0)
					{

			



						for (int i = 0; i < targets.Count; ++i)
						{
							Mobile m = targets[i];


							DoHarmful(m);

							m.Paralyze(TimeSpan.FromSeconds(10));

						}
					}

				DelayHurlement = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(10, 50));

			}
		}



		public void CoupVent()
		{

			if (DelayCoupVent < DateTime.UtcNow) 
			{
				int dmg = 35;

				Combatant.FixedParticles(0x374A, 10, 30, 5013, 1153, 2, EffectLayer.Waist);

				AOS.Damage(Combatant, this, dmg, 100, 0, 0, 0, 0); // C'est un coup de vent, donc rien d'electrique...

				Emote($"*Attire une bourasque provenant de {Combatant.Name}*");

				KnockBack(this.Location, Combatant as Mobile, -5);

				DelayCoupVent = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(10, 60));
			}




		}

		public void Attraction()
		{
			if (DelayAttraction < DateTime.UtcNow)
			{
				int Range = 10;
				List<Mobile> targets = new List<Mobile>();

				IPooledEnumerable eable = this.GetMobilesInRange(Range);

				foreach (Mobile m in eable)
				{
					if (this != m && !(m is Harpy) && !(m is StoneHarpy) && !m.IsStaff())
					{


						if (Core.AOS && !InLOS(m))
							continue;

						targets.Add(m);
					}
				}

				eable.Free();

				Effects.PlaySound(this, this.Map, 0x1FB);
				Effects.PlaySound(this, this.Map, 0x10B);
				Effects.SendLocationParticles(EffectItem.Create(this.Location, this.Map, EffectItem.DefaultDuration), 0x37CC, 1, 15, 97, 3, 9917, 0);

				Emote("*Aspire l'air autour d'elle*");

				if (targets.Count > 0)
				{

					int dmg = 15;



					for (int i = 0; i < targets.Count; ++i)
					{
						Mobile m = targets[i];


						DoHarmful(m);
						AOS.Damage(this, m, dmg, 100, 0, 0, 0, 0); // C'est un coup de vent, donc rien d'electrique...

						int Distance = 3;

						if (m.GetDistanceToSqrt(this.Location) < Distance)
						{
							Distance = (int)m.GetDistanceToSqrt(this.Location);
						}


						KnockBack(this.Location, m, Distance * -1); // Si sur le centre de la tornade...
					}
				}


				DelayAttraction = DateTime.UtcNow + TimeSpan.FromSeconds(Utility.RandomMinMax(10, 120));

			}

			
		}

		public void KnockBack(Point3D destination, Mobile target, int Distance)
		{



			if (target.Alive)
			{

				int Distance2 = Distance;
				int Neg = 1;

				if (Distance < 0)
				{
					Distance2 = -Distance;   // Sert a faire en sorte, que si c'est n�gative, ca va avancer.
					Neg = -1;
				}




				for (int i = 0; i < Distance2; i++)  // Le script valide toute les tiles jusqu'a la distance maximum. Si une d'entre elle est bloquer, il revient a la pr�c�dente (ou player location du d�part) et stun la target.
				{
					Point3D point = KnockBackCalculation(destination, target, i * Neg);

					if (!target.Map.CanFit(point, 16, false, false) && i != Distance2)
					{
						target.Paralyze(TimeSpan.FromSeconds((Distance2 - i + 1)));
						break;
					}
					else
					{
						target.MoveToWorld(point, target.Map);
					}
				}
			}
		}
		public Point3D KnockBackCalculation(Point3D Loc, Mobile target, int Distance)
		{

			return KnockBackCalculation(Loc, new Point3D(target.Location), Distance);



		}

		public Point3D KnockBackCalculation(Point3D Loc, Point3D point, int Distance)
		{

			Direction d = Utility.GetDirection(point, Loc);

			switch (d)
			{
				case (Direction)0x0: case (Direction)0x80: point.Y += Distance; break; //North
				case (Direction)0x1: case (Direction)0x81: { point.X -= Distance; point.Y += Distance; break; } //Right
				case (Direction)0x2: case (Direction)0x82: point.X -= Distance; break; //East
				case (Direction)0x3: case (Direction)0x83: { point.X -= Distance; point.Y -= Distance; break; } //Down
				case (Direction)0x4: case (Direction)0x84: point.Y -= Distance; break; //South
				case (Direction)0x5: case (Direction)0x85: { point.X += Distance; point.Y -= Distance; break; } //Left
				case (Direction)0x6: case (Direction)0x86: point.X += Distance; break; //West
				case (Direction)0x7: case (Direction)0x87: { point.X += Distance; point.Y += Distance; break; } //Up
				default: { break; }
			}
			return point;
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
