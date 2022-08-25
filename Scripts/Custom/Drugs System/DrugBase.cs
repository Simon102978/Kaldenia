using System;
using System.Collections;
using Server.Multis;
using Server.Items;
using Server.Network;
using Server.Targeting;
using Server.Mobiles;

namespace Server.Items
{
    public class DrugBase : Item
    {
        private Item m;
        private DrugPlantType m_DrugPlant;
        private DrugType m_Type;

        [Constructable]
        public DrugBase()
            : this(DrugPlantType.Shimyshisha, DrugType.Light)
        {
        }

        [Constructable]
        public DrugBase(DrugPlantType drugPlant, DrugType type)
            : base(0x423A)
        {
            Stackable = true;
            Amount = 5;
            Weight = 0.5;
            m_DrugPlant = drugPlant;
            m_Type = type;
            Name = "Drogue";
            Hue = 0x7B8;
        }

        public DrugBase(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
            writer.Write((int)m_DrugPlant);
            writer.Write((int)m_Type);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
            m_DrugPlant = (DrugPlantType)reader.ReadInt();
            m_Type = (DrugType)reader.ReadInt();
        }

        public override void OnDoubleClick(Mobile from)
        {
            CustomPlayerMobile pm = from as CustomPlayerMobile;
            if (pm.Hallucinating)
            {
                pm.Hits -= (1 + (int)m_Type) * (1 + (int)m_DrugPlant);
            }
            else
            {
                this.Consume();
                pm.Hallucinating = true;
                pm.SendMessage("Vous consummez la drogue et sentez ses effets");
                HallucinationTimer hallucinationTimer = new HallucinationTimer(from, 1 + (int)m_DrugPlant);
                hallucinationTimer.Start();
                pm.Hits -= (1 + (int)m_Type) * (1 + (int)m_DrugPlant);
                pm.PlaySound(pm.Female ? 781 : 1052);
                pm.Emote("*consomme*");
                if (!pm.Mounted)
                    pm.Animate(34, 5, 1, true, false, 0);
            }
        }

        public static void SendHallucinationItem(IEntity e, int itemID, int speed, int duration, int renderMode, int hue)
        {
            Map map = e.Map;

            if (map != null)
            {
                Packet regular = null;

                IPooledEnumerable eable = map.GetClientsInRange(e.Location);

                foreach (NetState state in eable)
                {
                    CustomPlayerMobile pm = state.Mobile as CustomPlayerMobile;
                    state.Mobile.ProcessDelta();

                    if (state.Mobile is PlayerMobile)
                    {
                        if (pm.Hallucinating)
                        {
                            switch (Utility.Random(4))
                            {
                                case 0: pm.FixedParticles(0x373A, 10, 15, 5018, EffectLayer.Waist); break;
                               case 1: pm.FixedParticles(0x374A, 10, 15, 5018, EffectLayer.Head); break;
                                case 2: pm.FixedParticles(0x375A, 10, 15, 5018, EffectLayer.Waist); break;
                                case 3: pm.FixedParticles(0x376A, 10, 15, 5018, EffectLayer.Head); break;
                            }

                            if (regular == null)
                                regular = new LocationEffect(e, itemID, speed, duration, renderMode, hue);

                            state.Send(regular);
                        }
                    }
                }

                eable.Free();
            }
        }

        public class HallucinationTimer : Timer
        {
            private Mobile m;
            private int Duration = 3;
            //Timespan between visual changes
            public HallucinationTimer(Mobile from, int duration)
                : base(TimeSpan.FromSeconds(2))
            {
                Priority = TimerPriority.OneSecond;
                Duration = duration;
                m = from;
            }

            protected override void OnTick()
            {
                HallucinationTimer hallucinationTimer = new HallucinationTimer(m, Duration);
                SoberTimer soberTimer = new SoberTimer(m, Duration);
                CustomPlayerMobile pm = m as CustomPlayerMobile;
               //int id = Utility.Random( 1, 1026 );
                int hhue = Utility.Random(2, 1200);

                if (pm.Hallucinating)
                {
                    ArrayList targets = new ArrayList();

                    IPooledEnumerable eable = pm.GetItemsInRange(50);

                    foreach (Item t in eable)
                    {
                        int id = t.ItemID;
                        if (t.Visible)
                        {
                            targets.Add(t);
                            SendHallucinationItem(t, id, 5, 5000, 4410, hhue);
                        }
                    }
                    eable.Free();

                    hallucinationTimer.Start();
                    soberTimer.Start();
                }
                else
                {
                    Stop();
                }
            }
        }


        public class SoberTimer : Timer
        {
            private Mobile m;
            private int Duration;
            public SoberTimer(Mobile from, int duration)
                : base(TimeSpan.FromMinutes(duration))
            {
                Duration = duration;
                Priority = TimerPriority.FiveSeconds;
                m = from;
            }

            protected override void OnTick()
            {
                SoberTimer soberTimer = new SoberTimer(m, Duration);
                CustomPlayerMobile pm = m as CustomPlayerMobile;

                if (pm.Hallucinating)
                {
                    pm.Hallucinating = false;
                    pm.SendMessage("Les effets se dissipent...");
                    Stop();
                }
            }
        }


    }
}