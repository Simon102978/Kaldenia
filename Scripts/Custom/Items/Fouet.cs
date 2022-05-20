using System;
using Server;
using Server.Items;
using Server.Network;
using Server.Mobiles;
using Server.Targeting;
using Server.Spells;
using Server.Gumps;
///using Server.Custom.Enums;
using Server.Custom;

namespace Server.Items
{
	public abstract class BaseFouet : Item //BaseJet
    {
        public BaseFouet() : base(5742)
		{
			Layer = Layer.TwoHanded;
			Name = "Fouet";
			Weight = 2.0;
        }

		public BaseFouet( Serial serial ) : base( serial )
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

        //public override void OnMiss(Mobile attacker, Mobile defender)
        //{
        //    return;
        //}

        public override bool CanEquip(Mobile from)
        {
            Item item = from.FindItemOnLayer(Layer.TwoHanded);

            if (item != null && item is BaseShield)
            {
                from.SendMessage("Vous ne pouvez pas équipper un fouet en ayant un bouclier à la main.");
                return false;
            }

            return true;
        }

        //public override bool OnFired(Mobile attacker, Mobile defender)
        //{
        //    attacker.MovingEffect(defender, EffectID, 18, 1, false, false);

        //    return true;
        //}

     //   public virtual void Fouetage(Mobile from, Mobile receveur)
     //   {
     //       CustomPlayerMobile pm = from as CustomPlayerMobile;

     //       if (pm != null)
     //       {
     //           pm.RevealingAction();

     //           //pm.CheckPraying();
     //           //pm.CheckEtude();

     //           if (!pm.CheckEquitation(EquitationType.RangedAttacking))
     //               return;

     //           SpellHelper.Turn(from, receveur);

     //           Item handOne = receveur.FindItemOnLayer(Layer.OneHanded);
     //           Item handTwo = receveur.FindItemOnLayer(Layer.TwoHanded);

     //           if (handTwo != null && handTwo is BaseArmor)
     //               handTwo = null;

     //           double snooping = pm.Skills[SkillName.Archery].Value;
     //           double stealing = pm.Skills[SkillName.Archery].Value;

     //           int chanceDeVoler = (pm.GetAptitudeValue(NAptitude.Musique) * 2) + (int)((snooping + stealing) / 20);
     //           int chanceDeDesarmer = (pm.GetAptitudeValue(NAptitude.Musique) * 3) + (int)((snooping + stealing) / 15);
     //           int chanceDeFizzle = (pm.GetAptitudeValue(NAptitude.Musique) * 3) + (int)((snooping + stealing) / 15);

     //           bool goodtarget = !(receveur is BaseCreature);

     //           if (receveur.Spell != null)
     //           {
     //               if (receveur is CustomPlayerMobile && ((CustomPlayerMobile)receveur).Aptitudes != null)
     //               {
     //                   ClasseInfo info = Classes.GetInfos(((CustomPlayerMobile)receveur).Classe);

     //                   if (info != null && info.ClasseMode == ClasseMode.Mages)
     //                       chanceDeFizzle -= ((CustomPlayerMobile)receveur).GetAptitudeValue(NAptitude.Concentration) * 3;
     //                   else
     //                       chanceDeFizzle -= ((CustomPlayerMobile)receveur).GetAptitudeValue(NAptitude.Concentration) * 2;
     //               }

     //               chanceDeFizzle -= (int)(receveur.Skills[SkillName.Wrestling].Value * 0.15);

     //               if (chanceDeFizzle > Utility.Random(100))
     //               {
     //                   receveur.Spell.OnCasterHurt();
     //                   from.SendMessage("Vous dérangez votre cible !");
     //                   Animation(from, receveur);
     //               }
     //           }
     //           else if (handOne != null && handTwo == null)
     //           {
     //               if (goodtarget && chanceDeVoler > Utility.Random(100))
     //               {
     //                   if (handOne != null)
     //                   {
     //                       if (from.AddToBackpack(handOne))
     //                       {
     //                           from.SendMessage("Vous volez l'arme de votre cible !");
     //                       }
     //                       else
     //                       {
     //                           handOne.MoveToWorld(from.Location);
     //                           from.SendMessage("Vous faites tomber l'arme de votre cible !");
     //                       }
     //                   }
     //                   else if (handTwo != null)
     //                   {
     //                       if (from.AddToBackpack(handTwo))
     //                       {
     //                           from.SendMessage("Vous volez l'arme de votre cible !");
     //                       }
     //                       else
     //                       {
     //                           handTwo.MoveToWorld(from.Location);
     //                           from.SendMessage("Vous faites tomber l'arme de votre cible !");
     //                       }
     //                   }
     //                   Animation(from, receveur);
     //               }
     //               else if (goodtarget && chanceDeDesarmer > Utility.Random(100))
     //               {
     //                   handOne.MoveToWorld(receveur.Location);
     //                   from.SendMessage("Vous faites tomber l'arme de votre cible !");
     //                   Animation(from, receveur);
     //               }
					//else
     //               {
     //                   from.SendMessage("Vous échouez à voler ou à faire tomber l'arme de votre cible !");
     //               }
     //           }
     //       }
     //   }

        //public void Animation(Mobile from, Mobile receveur)
        //{
        //    if (receveur is CustomPlayerMobile)
        //    {
        //        CustomPlayerMobile rec = (CustomPlayerMobile)receveur;

        //        //rec.CheckPraying();
        //        rec.CheckEquitation(EquitationType.BeingAttacked);
        //        //rec.CheckEtude();
        //    }

        //    receveur.PlaySound(0x145);
        //    receveur.SendMessage("Quelque chose vous heurte !");
        //    from.SendMessage("Vous fouetez votre cible !");
        //    receveur.RevealingAction();

        //    if (!receveur.Mounted && receveur.Body.IsHuman)
        //        receveur.Animate(20, 5, 1, true, false, 0);
        //}

        //public override void OnSingleClick(Mobile from)
        //{
        //    LabelTo(from, Name);
        //    LabelTo(from, String.Format("[{0} mêtres]", MaxRange));
        //}

  //      private void Fouet_OnTick(object state)
  //      {
  //          Mobile from = (Mobile)state;

  //          if (from != null)
  //          {
  //              from.EndAction(typeof(BaseFouet));
  //          }
  //      }

		//private class TargetSystem : Target
		//{
		//	private BaseFouet m_Fouet;

		//	public TargetSystem( BaseFouet fouet ) : base( 12, false, TargetFlags.None )
		//	{
		//		m_Fouet = fouet;
		//	}

  //          protected override void OnTarget(Mobile from, object targeted)
  //          {
  //              if (!from.CanBeginAction(typeof(BaseFouet)))
  //              {
  //                  from.SendMessage("Vous devez attendre avant d'utiliser le fouet à nouveau.");
  //              }
  //              else if (!from.Items.Contains(m_Fouet))
  //              {
  //                  from.SendMessage("Vous devez avoir le fouet en main pour l'utiliser.");
  //              }
  //              else if (targeted is Mobile)
  //              {
  //                  Mobile m = (Mobile)targeted;

  //                  if (m == from)
  //                  {
  //                      from.SendMessage("Vous ne pouvez pas vous foueter.");
  //                  }
  //                  else if (!from.InRange(m.Location, m_Fouet.MaxRange))
  //                  {
  //                      from.SendMessage("Votre fouet n'est pas assez long.");
  //                  }
  //                  else if (from is OrderGuard)
  //                  {
  //                      from.SendMessage("Vous ne pouvez pas fouetter un garde.");
  //                  }
  //                  else
  //                  {
  //                      m_Fouet.Fouetage(from, m);

  //                      if (!from.Mounted)
  //                          from.Animate(9, 5, 1, true, false, 0);
  //                      else
  //                          from.Animate(26, 5, 1, true, false, 0);

  //                      from.BeginAction(typeof(BaseFouet));

  //                      double bonus = 0;

  //                      Timer.DelayCall(TimeSpan.FromSeconds(12.0 - bonus), new TimerStateCallback(m_Fouet.Fouet_OnTick), from);
  //                  }
  //              }
  //              else
  //              {
  //                  from.SendMessage("Vous ne pouvez pas foueter cette cible.");
  //              }
  //          }
		//}
	}
}