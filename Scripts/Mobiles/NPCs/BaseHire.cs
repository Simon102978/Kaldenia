using Server.ContextMenus;
using Server.Items;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Mobiles
{
	public class BaseHire : BaseCreature
	{

		private GrandeurEnum m_Grandeur;
		private GrosseurEnum m_Grosseur;
		private AppearanceEnum m_Beaute;





		public override bool IsBondable => true;
		public override bool CanAutoStable => false;
		public override bool CanDetectHidden => false;
		public override bool KeepsItemsOnDeath => true;

		private bool _IsHired;

		[CommandProperty(AccessLevel.GameMaster)]
		public DateTime NextPay { get; set; }

		[CommandProperty(AccessLevel.GameMaster)]
		public int Pay => PerDayCost();

		[CommandProperty(AccessLevel.GameMaster)]
		public int HoldGold { get; set; }

		public int GoldOnDeath { get; set; }

		[CommandProperty(AccessLevel.GameMaster)]
		public bool IsHired
		{
			get { return _IsHired; }
			set
			{
				_IsHired = value;

				Delta(MobileDelta.Noto);
				InvalidateProperties();
			}
		}

		[CommandProperty(AccessLevel.GameMaster)]
		public GrosseurEnum Grosseur { get => m_Grosseur; set => m_Grosseur = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public GrandeurEnum Grandeur { get => m_Grandeur; set => m_Grandeur = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public AppearanceEnum Beaute { get => m_Beaute; set => m_Beaute = value; }

		[CommandProperty(AccessLevel.GameMaster)]
		public string customTitle { get; set; }





		public BaseHire(AIType AI)
			: base(AI, FightMode.Aggressor, 10, 1, 0.1, 4.0)
		{


			Grosseur = (GrosseurEnum)Utility.Random(1,8);
			Grandeur = (GrandeurEnum)Utility.Random(1,8);
			Beaute =  (AppearanceEnum)Utility.Random(1,18);

			Race = BaseRace.GetRace(Utility.Random(4));



			Race.AddRace(this);
			ControlSlots = 2;
			HoldGold = 8;





		}

		public BaseHire()
			: base(AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.1, 4.0)
		{
			Grosseur = (GrosseurEnum)Utility.Random(1,8);
			Grandeur = (GrandeurEnum)Utility.Random(1,8);
			Beaute = (AppearanceEnum)Utility.Random(1,18);

			Race = BaseRace.GetRace(Utility.Random(4));

			ControlSlots = 2;
			Race.AddRace(this);
		}

		public BaseHire(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write(2);// version

			writer.Write(customTitle);
			writer.Write((int)m_Grandeur);
			writer.Write((int)m_Grosseur);
			writer.Write((int)m_Beaute);

			writer.Write(NextPay);
			writer.Write(IsHired);
			writer.Write(HoldGold);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();

			switch (version)
			{
				case 2:
					{
						customTitle = reader.ReadString();
						m_Grandeur = (GrandeurEnum)reader.ReadInt();
						m_Grosseur = (GrosseurEnum)reader.ReadInt();
						m_Beaute = (AppearanceEnum)reader.ReadInt();
						goto case 1;
					}
				case 1:
					NextPay = reader.ReadDateTime();
					goto case 0;
				case 0:
					IsHired = reader.ReadBool();
					HoldGold = reader.ReadInt();
					break;
			}

			if (IsHired)
			{
				PayTimer.RegisterTimer(this);
			}
		}

		public override bool OnBeforeDeath()
		{
			if (Backpack != null)
			{
				Item[] AllGold = Backpack.FindItemsByType(typeof(Gold), true);

				if (AllGold != null)
				{
					foreach (Gold g in AllGold)
					{
						GoldOnDeath += g.Amount;
					}
				}
			}

			return base.OnBeforeDeath();
		}

		public override void Delete()
		{
			base.Delete();

			PayTimer.RemoveTimer(this);
		}

		public override void OnDeath(Container c)
		{
			if (GoldOnDeath > 0)
			{
				c.DropItem(new Gold(GoldOnDeath));
			}

			base.OnDeath(c);
		}

		public override bool AllowEquipFrom(Mobile from)
		{
			if (from == GetOwner())
				return true;

			return base.AllowEquipFrom(from);
		}


		public override bool CheckNonlocalLift(Mobile from, Item item)
		{
			if (IsOwner(from))
			{
				return true;
			}

			return base.CheckNonlocalLift(from, item);
		}

		public override bool IsSnoop(Mobile from)
		{
			return IsOwner(from);
		}


		public bool IsOwner(Mobile from)
		{
			return from == GetOwner();

		}




		#region [Apparence]

		public string Apparence()
		{
			AppearanceEnum gros = m_Beaute;
		
			if (gros < 0)
			{
				gros = 0;
			}
			else if ((int)gros > 19)
			{
				gros = (AppearanceEnum)19;
			}

			var type = typeof(AppearanceEnum);
			MemberInfo[] memberInfo = type.GetMember(gros.ToString());
			Attribute attribute = memberInfo[0].GetCustomAttribute(typeof(AppearanceAttribute), false);
			return (Female ? ((AppearanceAttribute)attribute).FemaleAdjective : ((AppearanceAttribute)attribute).MaleAdjective);
		}


		public string GrosseurString()
		{

			GrosseurEnum gros = m_Grosseur;

			if (gros < 0)
			{
				gros = 0;
			}
			else if ((int)gros > 8)
			{
				gros = (GrosseurEnum)8;
			}

			var type = typeof(GrosseurEnum);
			MemberInfo[] memberInfo = type.GetMember(gros.ToString());
			Attribute attribute = memberInfo[0].GetCustomAttribute(typeof(AppearanceAttribute), false);
			return (Female ? ((AppearanceAttribute)attribute).FemaleAdjective : ((AppearanceAttribute)attribute).MaleAdjective);
		}

		public string GrandeurString()
		{

			GrandeurEnum gros = m_Grandeur;

			var type = typeof(GrandeurEnum);
			MemberInfo[] memberInfo = type.GetMember(gros.ToString());
			Attribute attribute = memberInfo[0].GetCustomAttribute(typeof(AppearanceAttribute), false);
			return (Female ? ((AppearanceAttribute)attribute).FemaleAdjective : ((AppearanceAttribute)attribute).MaleAdjective);

		}
		#endregion







		public override void GetProperties(ObjectPropertyList list)
		{
			base.GetProperties(list);

			if (NameMod == null)
			{
				list.Add(1050045, "{0}, \t{1}\t", Race.Name, Apparence()); // ~1_PREFIX~~2_NAME~~3_SUFFIX~
				list.Add(1050045, "{0}, \t{1}\t", GrandeurString(), GrosseurString());
			}

		}







		#region [ GetOwner ]
		public virtual Mobile GetOwner()
        {
            if (!Controlled)
            {
                return null;
            }

            var owner = ControlMaster;
            IsHired = true;

            if (owner == null)
            {
                return null;
            }

            if (owner.Deleted)
            {
                Say(1005653, 0x3B2);// Hmmm.  I seem to have lost my master.
                SetControlMaster(null);
                return null;
            }

            return owner;
        }

        #endregion 

        #region [ AddHire ] 
        public virtual bool AddHire(Mobile m)
        {
            Mobile owner = GetOwner();

            if (owner != null)
            {
                m.SendLocalizedMessage(1043283, owner.Name);// I am following ~1_NAME~. 
                return false;
            }

            if (SetControlMaster(m))
            {
                IsHired = true;

                return true;
            }

            return false;
        }

        #endregion 

        #region [ PerDayCost ] 
        public int PerDayCost()
        {
            var pay = (int)Skills[SkillName.Anatomy].Value + (int)Skills[SkillName.Tactics].Value;
            pay += (int)Skills[SkillName.Macing].Value + (int)Skills[SkillName.Swords].Value;
            pay += (int)Skills[SkillName.Fencing].Value + (int)Skills[SkillName.Archery].Value;
            pay += (int)Skills[SkillName.MagicResist].Value + (int)Skills[SkillName.Healing].Value;
            pay += (int)Skills[SkillName.Magery].Value + (int)Skills[SkillName.Parry].Value;
            pay /= 35;
            pay += 1;

            return pay;
        }

        #endregion 

        #region [ OnDragDrop ]
        public override bool OnDragDrop(Mobile from, Item item)
        {
            if (Pay != 0)
            {
                // Is the creature already hired
                if (!Controlled)
                {
                    // Is the item the payment in gold
                    if (item is Gold)
                    {
                        // Is the payment in gold sufficient
                        if (item.Amount >= Pay)
                        {
                            if (from.Followers + ControlSlots > from.FollowersMax)
                            {
                                SayTo(from, 500896, 0x3B2); // I see you already have an escort.
                                return false;
                            }

                            // Try to add the hireling as a follower
                            if (AddHire(from))
                            {
                                SayTo(from, 1043258, string.Format("{0}", item.Amount / Pay), 0x3B2);//"I thank thee for paying me. I will work for thee for ~1_NUMBER~ days.", (int)item.Amount / Pay );
                                HoldGold += item.Amount;

                                NextPay = DateTime.UtcNow + PayTimer.GetInterval();

                                PayTimer.RegisterTimer(this);
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            SayHireCost();
                        }
                    }
                    else
                    {
                        SayTo(from, 1043268, 0x3B2);// Tis crass of me, but I want gold
                    }
                }
                else
                {
                    SayTo(from, 1042495, 0x3B2);// I have already been hired.
                }
            }
            else
            {
                SayTo(from, 500200, 0x3B2);// I have no need for that.
            }

            return base.OnDragDrop(from, item);
        }

        #endregion 

        #region [ OnSpeech ] 
        internal void SayHireCost()
        {
            Say(1043256, string.Format("{0}", Pay), 0x3B2);// "I am available for hire for ~1_AMOUNT~ gold coins a day. If thou dost give me gold, I will work for thee."
        }

        public override void OnSpeech(SpeechEventArgs e)
        {
            if (!e.Handled && e.Mobile.InRange(this, 6))
            {
                int[] keywords = e.Keywords;
                string speech = e.Speech;

                // Check for a greeting, a 'hire', or a 'servant'
                if (e.HasKeyword(0x003B) || e.HasKeyword(0x0162) || e.HasKeyword(0x000C))
                {
                    if (!Controlled)
                    {
                        e.Handled = true;
                        SayHireCost();
                    }
                    else
                    {
                        Say(1042495, 0x3B2);// I have already been hired.
                    }
                }
            }

            base.OnSpeech(e);
        }

        #endregion	

        #region [ GetContextMenuEntries ] 
        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            if (Deleted)
                return;

            if (!Controlled)
            {
                if (CanPaperdollBeOpenedBy(from))
                    list.Add(new PaperdollEntry(this));

                list.Add(new HireEntry(from, this));
            }
            else
            {
                base.GetContextMenuEntries(from, list);
            }
        }

        #endregion

        #region [ Class PayTimer ]
        public class PayTimer : Timer
        {
            public static PayTimer Instance { get; set; }

            public List<BaseHire> Hires { get; set; } = new List<BaseHire>();

            public PayTimer()
                : base(TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(1))
            {
            }

            public static TimeSpan GetInterval()
            {
                return TimeSpan.FromMinutes(30.0);
            }

            protected override void OnTick()
            {
                var list = Hires.Where(v => v.NextPay <= DateTime.UtcNow).ToList();

                for (int i = 0; i < list.Count; i++)
                {
                    var hire = list[i];
                    hire.NextPay = DateTime.UtcNow + GetInterval();

                    int pay = hire.Pay;

                    if (hire.HoldGold <= pay)
                    {
                        hire.GetOwner();

                        hire.Say(503235, 0x3B2);// I regret nothing! 
                        hire.Delete();
                    }
                    else
                    {
                        hire.HoldGold -= pay;
                    }
                }

                ColUtility.Free(list);
            }

            public static void RegisterTimer(BaseHire hire)
            {
                if (Instance == null)
                {
                    Instance = new PayTimer();
                }

                if (!Instance.Running)
                {
                    Instance.Start();
                }

                if (!Instance.Hires.Contains(hire))
                {
                    Instance.Hires.Add(hire);
                }
            }

            public static void RemoveTimer(BaseHire hire)
            {
                if (Instance == null)
                {
                    return;
                }

                if (Instance.Hires.Contains(hire))
                {
                    Instance.Hires.Remove(hire);

                    if (Instance.Hires.Count == 0)
                    {
                        Instance.Stop();
                    }
                }
            }
        }
        #endregion 

        #region [ Class HireEntry ]
        public class HireEntry : ContextMenuEntry
        {
            private readonly Mobile m_Mobile;
            private readonly BaseHire m_Hire;

            public HireEntry(Mobile from, BaseHire hire)
                : base(6120, 3)
            {
                m_Hire = hire;
                m_Mobile = from;
            }

            public override void OnClick()
            {
                m_Hire.SayHireCost();
            }
        }
        #endregion
    }
}
