using Server.Prompts;
using Server.Targeting;
using System;

namespace Server.Items
{
    public class Baits : Item
    {
        public static readonly bool UsePrompt = true;

        private Type m_BaitsType;
        private object m_Label;
        private int m_UsesRemaining;
        private int m_Index;
        private bool m_Enhanced;

        [CommandProperty(AccessLevel.GameMaster)]
        public Type BaitsType => m_BaitsType;

        [CommandProperty(AccessLevel.GameMaster)]
        public int UsesRemaining { get { return m_UsesRemaining; } set { m_UsesRemaining = value; InvalidateProperties(); } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Index
        {
            get { return m_Index; }
            set
            {
                m_Index = value;

                if (value < 0)
                    m_Index = 0;
                if (value >= FishInfo.FishInfos.Count)
                    m_Index = FishInfo.FishInfos.Count - 1;

                m_BaitsType = FishInfo.GetTypeFromIndex(m_Index);
                Hue = FishInfo.GetFishHue(m_Index);
                m_Label = FishInfo.GetFishLabel(m_Index);
                InvalidateProperties();
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Enhanced { get { return m_Enhanced; } set { m_Enhanced = value; InvalidateProperties(); } }

        [Constructable]
        public Baits(int index) : base(2454)
        {
            Index = index;
            m_UsesRemaining = 1;
        }

        [Constructable]
        public Baits() : base(0xDCF)
        {
            m_UsesRemaining = 1;
        }

 /*       public override void OnDoubleClick(Mobile from)
        {
            if (IsChildOf(from.Backpack))
            {
                if (UsePrompt && m_UsesRemaining > 1)
                {
                    from.SendMessage("How much Baits would you like to use?");
                    from.Prompt = new InternalPrompt(this);
                }
                else
                {
                    from.Target = new InternalTarget(this, 1);
                    from.SendMessage("Target the fishing pole or lobster trap that you would like to apply the Baits to.");
                }
            }
        }

        public void TryBeginTarget(Mobile from, int amount)
        {
            if (amount < 0) amount = 1;
            if (amount > m_UsesRemaining) amount = m_UsesRemaining;

            from.Target = new InternalTarget(this, amount);
            from.SendMessage("Target the fishing pole or lobster trap that you would like to apply the Baits to.");
        }

        public override void AddNameProperty(ObjectPropertyList list)
        {
            object label = FishInfo.GetFishLabel(m_Index);

            if (m_Enhanced)
            {
                //~1_token~ ~2_token~ Baits
                if (label is int)
                    list.Add(1116464, "#{0}\t#{1}", 1116470, (int)label);
                else if (label is string)
                    list.Add(1116464, "#{0}\t{1}", 1116470, (string)label);
            }
            else if (label is int)
                list.Add(1116465, string.Format("#{0}", (int)label)); //~1_token~ Baits
            else if (label is string)
                list.Add(1116465, (string)label);
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            list.Add(1116466, m_UsesRemaining.ToString());  //amount: ~1_val~
        }

  /*      private class InternalPrompt : Prompt
        {
            private readonly Baits m_Baits;

            public InternalPrompt(Baits Baits)
            {
                m_Baits = Baits;
            }

            public override void OnResponse(Mobile from, string text)
            {
                int amount = Utility.ToInt32(text);
                m_Baits.TryBeginTarget(from, amount);
            }

            public override void OnCancel(Mobile from)
            {
                from.SendMessage("Not applying Baits...");
            }
        }

        private class InternalTarget : Target
        {
            private readonly Baits m_Baits;
            private readonly int m_Amount;

            public InternalTarget(Baits Baits, int amount)
                : base(0, false, TargetFlags.None)
            {
                m_Baits = Baits;
                m_Amount = amount;
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted == m_Baits)
                    return;

                if (targeted is FishingPole)
                {
                    if (!m_Baits.IsFishBaits())
                    {
                        from.SendMessage("Think again before applying lobster or crab Baits to a fishing pole!");
                        return;
                    }

                    FishingPole pole = (FishingPole)targeted;

                    bool hasBaits = pole.BaitsType != null;

                    if (hasBaits && pole.BaitsType != m_Baits.BaitsType)
                        from.SendMessage("You swap out the old Baits for new.");

                    if (pole.BaitsType == m_Baits.BaitsType)
                        pole.BaitsUses += m_Amount;
                    else
                    {
                        pole.BaitsType = m_Baits.BaitsType;
                        pole.BaitsUses += m_Amount;
                    }

                    if (m_Baits.Enhanced)
                        pole.EnhancedBaits = true;

                    from.SendLocalizedMessage(1149759);  //You Baits the hook.
                    m_Baits.UsesRemaining -= m_Amount;
                }
                else if (targeted is LobsterTrap)
                {
                    if (m_Baits.IsFishBaits())
                    {
                        from.SendMessage("Think again before applying fish Baits to a lobster trap!");
                        return;
                    }

                    LobsterTrap trap = (LobsterTrap)targeted;

                    bool hasBaits = trap.BaitsType != null;

                    trap.BaitsType = m_Baits.BaitsType;
                    //trap.Hue = m_Baits.Hue;

                    if (hasBaits && trap.BaitsType != m_Baits.BaitsType)
                        from.SendMessage("You swap out the old Baits for new.");

                    if (trap.BaitsType == m_Baits.BaitsType)
                        trap.BaitsUses += m_Amount;
                    else
                    {
                        trap.BaitsType = m_Baits.BaitsType;
                        trap.BaitsUses += m_Amount;
                    }

                    if (m_Baits.Enhanced)
                        trap.EnhancedBaits = true;

                    from.SendLocalizedMessage(1149760); //You Baits the trap.
                    m_Baits.UsesRemaining -= m_Amount;
                }
                else if (targeted is Baits && ((Baits)targeted).IsChildOf(from.Backpack) && ((Baits)targeted).BaitsType == m_Baits.BaitsType)
                {
                    Baits Baits = (Baits)targeted;

                    Baits.UsesRemaining += m_Amount;
                    m_Baits.UsesRemaining -= m_Amount;

                    if (m_Baits.UsesRemaining <= 0)
                    {
                        m_Baits.Delete();
                        from.SendLocalizedMessage(1116469); //You combine these Baitss into one cup and destroy the other cup.
                    }
                    else
                        from.SendMessage("You combine these Baitss into one cup.");

                    return;
                }

                if (m_Baits.UsesRemaining <= 0)
                {
                    m_Baits.Delete();
                    from.SendLocalizedMessage(1116467); //Your Baits is used up so you destroy the container.
                }
            }
        }
*/
        public bool IsFishBaits()
        {
            if (m_BaitsType == null)
                Index = Utility.RandomMinMax(0, 34);

            return !m_BaitsType.IsSubclassOf(typeof(BaseCrabAndLobster));
        }

        public Baits(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);

            writer.Write(m_UsesRemaining);
            writer.Write(m_Index);
            writer.Write(m_Enhanced);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            m_UsesRemaining = reader.ReadInt();
            m_Index = reader.ReadInt();
            m_Enhanced = reader.ReadBool();

            if (m_Index < 0)
                m_Index = 0;
            if (m_Index >= FishInfo.FishInfos.Count)
                m_Index = FishInfo.FishInfos.Count - 1;

            m_BaitsType = FishInfo.FishInfos[m_Index].Type;
            //Hue = FishInfo.FishInfos[m_Index].Hue;
            m_Label = FishInfo.GetFishLabel(m_Index);
        }
    }
}