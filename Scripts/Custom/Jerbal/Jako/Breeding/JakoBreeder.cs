using System;
using System.Collections.Generic;
using System.Text;
using Server.Mobiles;
using Server.ContextMenus;
using Server;
using Custom.Jerbal.Jako.Gumps;
using Server.Gumps;
using System.Collections;
using Custom.Jerbal.Jako.Breeding;
using Server.Misc;


namespace Custom.Jerbal.Jako.Breeding
{
    class JakoBreeder : AnimalTrainer
    {

        private static ArrayList m_PendingOffers = new ArrayList();
        public static ArrayList PendingOffers { get { return m_PendingOffers; } set { m_PendingOffers = value; } }

        [Constructable]
        public JakoBreeder()
        {
            Title = "the animal breeder";
            CantWalk = true;
        }

        public override void AddCustomContextEntries(Server.Mobile from, List<Server.ContextMenus.ContextMenuEntry> list)
        {
            list.Add(new BreedEntry(this,from));
            base.AddCustomContextEntries(from, list);
        }


        private class BreedEntry : ContextMenuEntry
        {
            private JakoBreeder m_Trainer;
            private PlayerMobile m_From;

            public BreedEntry(JakoBreeder trainer, Mobile from)
                : base(6146, 10)
            {
                if (from is PlayerMobile)
                    m_From = (PlayerMobile)from;
                m_Trainer = trainer;               
            }

            public override void OnClick()
            {
                if (m_From == null)
                    return;
                JakoBreeder.BreedClick(m_From, m_Trainer);
                
            }
        }

        public static void DoBreeding(Mobile from, int DictID)
        {
            BreedingRequest req = (BreedingRequest)m_PendingOffers[DictID];
            if (!req.Accepted && (((BaseCreature)req.Creature1).ControlMaster != ((BaseCreature)req.Creature2).ControlMaster))
            {
                req.Accepted = true;
                from.SendMessage("They have been notified you accepted the offer.");
                if (((BaseCreature)req.Creature2).ControlMaster == from)
                    ((BaseCreature)req.Creature1).ControlMaster.SendMessage("They have accepted the breeding offer.");
                else
                    ((BaseCreature)req.Creature2).ControlMaster.SendMessage("They have accepted the breeding offer.");
                return;
            }
            JakoBreeder.EndBreeding(req);
            m_PendingOffers.RemoveAt(DictID);

        }

        public static void EndBreeding(BreedingRequest request)
        {
            BaseCreature c1 = ((BaseCreature)request.Creature1);
            BaseCreature c2 = ((BaseCreature)request.Creature2);
            PlayerMobile pm1 = (PlayerMobile)c1.ControlMaster;
            PlayerMobile pm2 = (PlayerMobile)c2.ControlMaster;
            int gp1 = JakoBreeder.GoldPrice(request.Creature1, request.Creature2);
            int gp2 = JakoBreeder.GoldPrice(request.Creature1, request.Creature2);

            if (Banker.GetBalance(pm1) < gp1 || Banker.GetBalance(pm2) < gp2)
            {
                pm1.SendMessage("The breeding has been canceled due to insufficient funds.");
                if (pm1 != pm2)
                    pm2.SendMessage("The breeding has been canceled due to insufficient funds.");
                return;
            }

            Banker.Withdraw((Mobile)pm1, gp1);
            Banker.Withdraw((Mobile)pm2, gp2);

            ReadyPetForBreed(c1);
            ReadyPetForBreed(c2);
            
            pm1.AddToBackpack(new BreedingParentTicket(pm1, pm2, c1, c2, DateTime.Now + c1.NextMateIn));
            pm2.AddToBackpack(new BreedingParentTicket(pm2, pm1, c2, c1, DateTime.Now + c2.NextMateIn));

        }

        private static void ReadyPetForBreed(BaseCreature pet)
        {
            pet.ControlTarget = null;
            pet.ControlOrder = OrderType.Stay;
            pet.Internalize();
            pet.SetControlMaster(null);
        }

        private static void ReadyPetForReturn(Mobile owner, Mobile pet)
        {
            if (!(pet is BaseCreature))
                return;
            BaseCreature bc = pet as BaseCreature;
            bc.NextMate = DateTime.Now + bc.NextMateIn;
            bc.ControlTarget = null;
            bc.ControlOrder = OrderType.Stay;
            bc.Map = owner.Map;
            bc.Location = owner.Location;
            bc.SetControlMaster(owner);
        }

        public static void CancelBreeding(int DictID)
        {
            BreedingRequest req = (BreedingRequest)m_PendingOffers[DictID];
            m_PendingOffers.RemoveAt(DictID);
            ((BaseCreature)req.Creature1).ControlMaster.SendMessage("The Breeding has been canceled.");
            ((BaseCreature)req.Creature1).ControlMaster.CloseGump(typeof(JakoBreederAcceptGump));

            if (((BaseCreature)req.Creature1).ControlMaster == ((BaseCreature)req.Creature2).ControlMaster)
                return;
            ((BaseCreature)req.Creature2).ControlMaster.SendMessage("The Breeding has been canceled.");
            ((BaseCreature)req.Creature2).ControlMaster.CloseGump(typeof(JakoBreederAcceptGump));
        }

        public static void SendMasterOkayGumps(Mobile targeter, BaseCreature bc1, BaseCreature bc2)
        {
            CleanUpPendingOffers();
            int dictID = PendingOffers.Add(new BreedingRequest(bc1,bc2));
            bc1.ControlMaster.SendGump(new JakoBreederAcceptGump(targeter,bc1,bc2,dictID));
            if (bc1.ControlMaster != bc2.ControlMaster)
                bc2.ControlMaster.SendGump(new JakoBreederAcceptGump(targeter,bc2,bc1,dictID));
        }

        private static void CleanUpPendingOffers()
        {
            PlayerMobile pm1;
            PlayerMobile pm2;
            foreach (BreedingRequest br in m_PendingOffers)
            {
                pm1 = (PlayerMobile)((BaseCreature)br.Creature1).ControlMaster;
                pm2 = (PlayerMobile)((BaseCreature)br.Creature2).ControlMaster;
                if (pm1.NetState == null || pm2.NetState == null || (!br.Accepted && (!pm1.HasGump(typeof(JakoBreederAcceptGump)) || !pm2.HasGump(typeof(JakoBreederAcceptGump)))))
                    m_PendingOffers.Remove(br);
            }
        }

        public static void BreedClick(PlayerMobile pm, Mobile breeder)
        {

            if (pm.Skills[SkillName.AnimalTaming].Value < 95.0)
            {
                breeder.SayTo(pm, "I refuse to waste my time with someone who is not skilled in taming.");
                return;
            }
            pm.SendGump(new JakoBreederTalkGump(pm, breeder));
        }

        public static string CanBreed(Mobile animal)
        {

            BaseCreature bc;
            if (animal.Deleted)
                return "That has been deleted";

            if (animal is PlayerMobile)
                return String.Format("I don't specialize in that but I know a {0} who might be able to help.", (animal.Female ? "guy" : "girl"));

            bc = animal as BaseCreature;
            if (bc == null || !bc.JakoIsEnabled)
                return "You can't breed that!";

            if (bc is JakoBreeder)
            {
                bc.Emote("scoffs");
                return String.Format("I should {0} you...",(bc.Female?"slap":"hit"));
            }
            if (bc.Body.IsHuman)
                return "You'll need to find an inn keeper for that.";
            if (!bc.Tamable)
                return "I specialize only in tameable pets.";
            if (bc.ControlMaster == null)
                return "That's not tame to anyone!"; //502674
            if (bc.NextMate > DateTime.Now)
                return "That animal is still recovering from breeding.";
            if (bc.IsDeadBondedPet)
                return "Living pets only, please."; //1049668
            if (bc.RealLevel < bc.MatingLevel)
                return "That pet is to young to mate.";
            return null;
        }

        public static string CanBreed(Mobile animal1, Mobile animal2)
        {
            BaseCreature bc1, bc2;
            if (animal1.Deleted || animal2.Deleted)
                return "One of those has been deleted.";
            bc1 = animal1 as BaseCreature;
            bc2 = animal2 as BaseCreature;
            if (bc1 == null || bc2 == null)
                return "Unexpected error.  One of these isn't an animal!"; //shouldn't happen.  Caught before called
            if (bc1 == bc2)
                return (bc1.Female ? "I'm all out of magic juice and haven't been to THAT bank for awhile, sorry." : "I don't think it's long enough, and won't produce the results you want anyways.");
            if (bc1.GetType() != bc2.GetType())
                return "That seems complicated.";
            if (bc1.Female == bc2.Female)
                return "I think it would be best to not push your beliefs on these creatures.";
            if (Math.Abs((int)(bc1.RealLevel - bc2.RealLevel)) > 5)
                return "These creatures are to different in level to mate them safely.";
            return null;
        }

        public static int GoldPrice(Mobile creature1, Mobile creature2)
        {
            if (creature1.Deleted || creature2.Deleted)
                return 0;
            double mult =1;
            if (((BaseCreature)creature1).ControlMaster == ((BaseCreature)creature2).ControlMaster)
                mult = 2;
            return (int)(((BaseCreature)creature1).Level * ((BaseCreature)creature1).Level * 500*mult);
        }


        public override bool OnDragDrop(Mobile from, Item dropped)
        {
            if (dropped is BreedingParentTicket)
            {
                BreedingParentTicket bt = (BreedingParentTicket)dropped;
                if (bt.Creature == null || bt.Creature.Deleted)
                {
                    from.SendMessage("Your pet has been lost forever.  I have added to your bank a level 50 rabbit deed and turned this one worthless.  Please page a GM with details of this error.");
                    bt.NullifyDeed();
                    BaseCreature rab = new Rabbit();
                    rab.MaxLevel = 50;
                    rab.Level = 50;
                    from.BankBox.AddItem(new BreedingParentTicket(bt.Owner, bt.OtherParent, rab, rab, DateTime.MinValue));
                    return false;
                }
                if (bt.Owner != from && (bt.DoneReal == DateTime.MinValue && bt.OtherParent != from))
                {
                    from.SendMessage("This ticket is not yours! You can not claim it!");
                    return false;
                }
                if (bt.DoneReal >= DateTime.Now)
                {
                    from.SendMessage("Your pet is not ready yet.");
                    //from.SendMessage("But this is testing, so I'm moving on anyway.");
                    return false;
                }

                if (((BaseCreature)bt.Creature).ControlSlots > (from.FollowersMax - from.Followers))
                {
                    from.SendMessage("You have to many followers to collect this creature");
                    return false;
                }


                ReadyPetForReturn(from, bt.Creature);
                if (bt.DoneReal == DateTime.MinValue)
                    return true;
                if (bt.Failed)
                {
                    bt.Owner.SendMessage("The breeding has failed! Some of your money has been returned.");
                    bt.OtherParent.SendMessage("The breeding has failed! Some of your money has been returned.");
                    Banker.Deposit(bt.Owner, (int)(JakoBreeder.GoldPrice(bt.Creature, bt.OtherCreature) * .75));
                    Banker.Deposit(bt.OtherParent, (int)(JakoBreeder.GoldPrice(bt.OtherCreature, bt.Creature) * .75));
                    return true;
                }

                if (bt.Creature.Female)
                {
                    BaseCreature baby1 = Activator.CreateInstance(bt.Creature.GetType()) as BaseCreature;
                    baby1.MaxLevel = (uint)Math.Ceiling((double)((((BaseCreature)bt.Creature).Level + ((BaseCreature)bt.OtherCreature).Level) / 2) + 1);
                    from.SendMessage("Adding Baby ticket to bank");
                    from.BankBox.AddItem(new BreedingParentTicket(bt.Owner, bt.OtherParent, baby1, DateTime.MinValue));
                    if (bt.Twins)
                    {
                        BaseCreature baby2 = Activator.CreateInstance(bt.Creature.GetType()) as BaseCreature;
                        baby2.Female = baby1.Female;
                        baby2.MaxLevel = baby1.MaxLevel;
                        bt.Owner.SendMessage("Congradulations, your pet has just had twins! The father of the child has received the additional ticket.");
                        if (bt.Owner != bt.OtherParent)
                            bt.OtherParent.SendMessage(" Good news, it's twins! {0} has just recieved the second baby. Your ticket to redeem has been placed in your bank.", bt.Owner.Name);
                        bt.OtherParent.BankBox.AddItem(new BreedingParentTicket(bt.OtherParent, bt.Owner, baby2, DateTime.MinValue));
                    }
                }
                return true;
            }
            return false;
        }

        public override void OnSpeech(SpeechEventArgs e)
        {
            if (e.Speech.ToLower().Equals("i wish to mate"))
                SayTo(e.Mobile,String.Format("I'm not that type of {0}.",(Female?"girl":"guy")));
            else if (e.Speech.ToLower().Contains("i wish to mate animals") || e.Speech.ToLower().Contains("talk"))
                JakoBreeder.BreedClick((PlayerMobile)e.Mobile, this);
            base.OnSpeech(e);
        }

		public JakoBreeder( Serial serial ) : base( serial )
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


        public class BreedingRequest
        {
            public Mobile Creature1;
            public Mobile Creature2;
            public bool Accepted;

            public BreedingRequest(Mobile c1, Mobile c2)
            {
                Creature1 = c1;
                Creature2 = c2;
                Accepted = false;
            }
        }
    }
}
