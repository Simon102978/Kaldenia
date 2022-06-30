using System;
using Server;
using Server.Commands;
using Server.Gumps;
using Server.Mobiles;
using Server.Items;
using Server.Targeting;
using Server.Network;


namespace Server.Scripts.Commands
{
    public class SacocheAnimal
	{
        public static void Initialize()
        {
			CommandSystem.Register("SacocheAnimal", AccessLevel.Player, new CommandEventHandler(SacocheAnimal_OnCommand));
		}

		[Usage("SacocheAnimal")]
		[Description("Permet de retirer une Sacoche de selle.")]
		public static void SacocheAnimal_OnCommand(CommandEventArgs e)
		{
			Mobile from = e.Mobile;

			if (!from.Alive)
				return;

			if (from is CustomPlayerMobile)
			{
				from.Target = new SacocheTarget();
				from.SendMessage("Veuillez selectionner un cheval porteur ou un llama porteur.");
			}
		}

		private class SacocheTarget : Target
		{
			private double m_Skills;


			public SacocheTarget()
				: base(15, true, TargetFlags.None)
			{
				
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
				for (int i = 0; i < from.Skills.Length; ++i)
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

			protected override void OnTarget(Mobile from, object targeted)
			{

				if (targeted is BaseCreature bc)
				{
					if (from.InRange(bc, 1))
					{
						if (bc.ControlMaster != from)
							from.SendMessage("Vous pouvez seulement le mettre sur un de vos animaux!");
						else
						{
							if (targeted is PackHorse ph1)
							{
								if (ph1.Backpack.TotalItems == 0)
								{
									Horse ph = new Horse();
									ConvertAnimal(bc, ph);

									from.AddToBackpack(new Saddlebag());
								}
								else
								{
									from.SendMessage("La saccoche doit être vide.");
								}



								
							}
							else if (targeted is PackLlama pl1)
							{
								if (pl1.Backpack.TotalItems == 0)
								{
									Llama pl = new Llama();
									ConvertAnimal(bc, pl);
									from.AddToBackpack(new Saddlebag());
								}
								else
								{
									from.SendMessage("La saccoche doit être vide.");
								}
							}
							else
								from.SendMessage("Vous devez cibler un cheval porteur ou un llama porteur.");
						}
					}
					else
						from.SendMessage("C'est trop loin.");

				}
				else
				{
					from.SendMessage("Vous devez cibler un cheval porteur ou un llama porteur.");
				}

			}
		}
	}
}