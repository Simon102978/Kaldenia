using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
    
    public class BaseCeosSpawn : BaseCreature
    {

		public virtual Poison pet => Poison.Lesser;




		[Constructable]
        public BaseCeosSpawn(AIType aiType, FightMode fightMode, int rangePerception, int rangeFight, double activeSpeed, double passiveSpeed)
            : base(aiType, fightMode, rangePerception, rangeFight, activeSpeed, passiveSpeed)
        {
        
		}

        public BaseCeosSpawn(Serial serial)
            : base(serial)
        {
        }

		public override void OnDamage(int amount, Mobile from, bool willKill)
		{
		
			if (!willKill)
			{
				if (Utility.Random(100) <= 10)
				{
					switch (Utility.Random(3))
					{
						case 0:
							{
								Say("Oupsie!");
								break;
							}
						case 1:
							{
								Say("C'est pas moi, c'est lui ! *Pointant quelqu'un d'autre au hasard*");
								break;
							}
						case 2:
							{
								Say("Quoi ?! ");
								break;
							}
						default:
							{
								Say("*roule les yeux*");
								break;

							}
					}

							Effects.SendLocationParticles(EffectItem.Create(Location, Map, EffectItem.DefaultDuration), 0x36B0, 1, 14, 63, 7, 9915, 0);
							Effects.PlaySound(Location, Map, 0x229);

							List<Mobile> targets = new List<Mobile>();

							if (Map != null)
							{

								int Range = 3;


								IPooledEnumerable eable = Map.GetMobilesInRange(Location, Range);

								foreach (Mobile m in eable)
								{
									if (this != m && CanBeHarmful(m, false) && !(m is BaseCeosSpawn))
									{
										targets.Add(m);
									}
								}

								eable.Free();
							}


							if (targets.Count > 0)
							{
								for (int i = 0; i < targets.Count; ++i)
								{
									Mobile m = targets[i];

									DoHarmful(m);



									m.ApplyPoison(this, pet);
								}
							}














					}

			}
			
			
			base.OnDamage(amount, from, willKill);
		}





		public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}