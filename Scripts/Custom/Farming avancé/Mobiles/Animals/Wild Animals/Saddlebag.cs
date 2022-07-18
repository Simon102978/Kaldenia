using System;
using Server;
using Server.Items;
using Server.Targeting;
using Server.Mobiles;
using System.Collections;

namespace Server.Items
{
	public class Saddlebag : Item
	{
		[Constructable]
		public Saddlebag() : base( 0x9B2 )
		{
			Name = "Sacoche de selle";
			Weight = 5.0;
		}

		public override void OnDoubleClick( Mobile from )
		{
			bool CanUse = from.CheckSkill( SkillName.AnimalTaming, 30, 80 );

			if (CanUse)
			{
				if (this.IsChildOf( from.Backpack ))
				{
					from.SendMessage("Choisir un cheval ou un llama");
					from.Target = new BagTarget(this);
				}
				else
					from.SendMessage("Cela doit être dans votre sac.");
			}
			else
			{
				from.SendMessage("Vous êtes trop bête pour savoir à quoi cela sert.");
			}
		}

		private class BagTarget : Target
		{
			private Saddlebag sb;

			public BagTarget(Saddlebag s) : base( 10, false, TargetFlags.None )
			{
				sb = s;
			}
			
			public virtual void ConvertAnimal(BaseCreature from, BaseCreature to)
			{
				to.Location = from.Location;
				to.Name = from.Name;
				to.Title = from.Title;
				to.Hits = from.HitsMax;
				to.DamageMin = from.DamageMin;
				to.DamageMax = from.DamageMax;
				to.Str = from.Str;
				to.Dex = from.Dex;
				to.Int = from.Int;
				to.Level = from.Level;
				to.RealLevel = from.RealLevel;
				to.MaxLevel = from.MaxLevel;
				to.Experience = from.Experience;
				to.Traits = from.Traits;
				to.NextMate = from.NextMate;
				to.Female = from.Female;
				to.IsBonded = from.IsBonded;



				for ( int i = 0; i < from.Skills.Length; ++i )
				{
					to.Skills[i].Base = from.Skills[i].Base;
					to.Skills[i].Cap = from.Skills[i].Cap;
				}
				to.ControlOrder = from.ControlOrder;
				to.ControlTarget = from.ControlTarget;
				to.Controlled = from.Controlled;
				to.ControlMaster = from.ControlMaster;
				to.MoveToWorld(from.Location, from.Map);
				from.Delete();
			}
	
			protected override void OnTarget( Mobile from, object targ )
			{
				if (targ is BaseCreature)
				{
					BaseCreature bc = (BaseCreature) targ;
					if ( from.InRange( bc, 1 ) )
					{
						if (bc.ControlMaster != from)
							from.SendMessage("Vous pouvez seulement le mettre sur un de vos animaux!");
						else
						{
							if (targ is Horse)
							{
								PackHorse ph = new PackHorse();
								ConvertAnimal(bc, ph);
								sb.Consume();
							}
							else if (targ is Llama)
							{
								PackLlama pl = new PackLlama();
								ConvertAnimal(bc, pl);
								sb.Consume();
							}
							else
								from.SendMessage("Vous pouvez pas mettre cela sur cette animal.");
						}
					}
					else
						from.SendMessage("C'est trop loin.");
				}
				else
					from.SendMessage("Vous pouvez pas mettre une sacoche sur cette animal.");
			}
		}

		public Saddlebag( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}

		
	}
}