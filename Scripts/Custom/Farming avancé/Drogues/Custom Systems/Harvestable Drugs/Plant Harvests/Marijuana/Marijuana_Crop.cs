#region About This Script - Do Not Remove This Header

#endregion About This Script - Do Not Remove This Header

using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Network;
using Server.Items;
using Server.Gumps;
using Server.Mobiles;
using Server.Engines.Quests;
using Server.Regions;

namespace Server.Items.Crops
{
    public class Marijuana_Crop : DrugSystem_Engine
    {
        private const int max = 3;
        private int fullGraphic;
        private int pickedGraphic;
        private DateTime lastpicked;
        private Mobile m_sower;
        private int m_yield;
        public Timer regrowTimer;
        private DateTime m_lastvisit;
        private bool m_Picked;

        [CommandProperty(AccessLevel.GameMaster)]
        public DateTime LastSowerVisit { get { return m_lastvisit; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool Growing { get { return regrowTimer.Running; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public Mobile Sower { get { return m_sower; } set { m_sower = value; } }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Yield { get { return m_yield; } set { m_yield = value; } }

        public int Capacity { get { return max; } }
        public int FullGraphic { get { return fullGraphic; } set { fullGraphic = value; } }
        public int PickGraphic { get { return pickedGraphic; } set { pickedGraphic = value; } }
        public DateTime LastPick { get { return lastpicked; } set { lastpicked = value; } }

        [Constructable]
        public Marijuana_Crop() : this(null) { }

        [Constructable]
        public Marijuana_Crop(Mobile sower): base(Utility.RandomList(0x0C63, 0x0C62))
        {
            Name = "Budding Marijuana Plant";
            Weight = 0.2;
            Hue = 167;
            Movable = false;
            Stackable = false;
            m_sower = sower;
            m_lastvisit = DateTime.Now;
            m_Picked = false;
            Timer.DelayCall(TimeSpan.FromHours(.5), new TimerCallback(Delete));
            init(this, false);
        }

        public static void init(Marijuana_Crop plant, bool full)
        {
            plant.PickGraphic = (0x0DED);
            plant.FullGraphic = (0x0DEE);
            plant.LastPick = DateTime.Now;
            plant.regrowTimer = new Marijuana_CropTimer(plant);

            if (full)
            {
                plant.Yield = plant.Capacity; ((Item)plant).ItemID = plant.FullGraphic;
            }
            else
            {
                plant.Yield = 0; ((Item)plant).ItemID = plant.PickGraphic; plant.regrowTimer.Start();
            }
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (m_sower == null || m_sower.Deleted) m_sower = from;
            if (from != m_sower) { from.SendMessage("You Do Not Own This Plant!"); return; }

            if (from.Mounted && !DrugSystem_Helper.CanWorkMounted) { from.SendMessage("You Cannot Harvest This Crop While Mounted."); return; }
            if (DateTime.Now > lastpicked.AddSeconds(3))
            {
                lastpicked = DateTime.Now;
                int alchemyValue = (int)from.Skills[SkillName.Alchemy].Value / 20;
                //if (alchemyValue == 0) { from.SendMessage("You Have No Idea How To Harvest This Crop."); return; }
                if (alchemyValue < 1)
                    alchemyValue = 1;
                if (from.InRange(this.GetWorldLocation(), 1))
                {
                    if (m_yield < 1) {
                        from.SendMessage("There Is Nothing Here To Harvest.");
                    } else {
                        from.Direction = from.GetDirectionTo(this);
                        from.Animate(from.Mounted ? 29 : 32, 5, 1, true, false, 0);
                        m_lastvisit = DateTime.Now;
                        if (alchemyValue > m_yield) alchemyValue = m_yield + 1;
                        int pick = Utility.RandomMinMax(0, alchemyValue);
                        if (pick < 1)
                        {
                            from.SendMessage("You Fail To Harvest Any Crops!");
                            return;
                        }
                        m_yield -= pick;
                        from.SendMessage("You Harvested {0} Crop{1}", pick, (pick == 1 ? "" : "s"));
                        Marijuana_Crop crop = new Marijuana_Crop(pick);
                        for (int i = 1; i <= pick; i++)
                        {
                            from.AddToBackpack(new Marijuana_Nugz(from));
                        }

                        #region Quests
                        PlayerMobile pm = from as PlayerMobile;
                        if (pm != null)
                        {
                            foreach (BaseQuest quest in pm.Quests)
                            {
                               
                            }
                        }
                        #endregion

                        if (m_yield < 1)
                        {
                            m_Picked = true;
                            this.Delete();
                        }
                    }
                }
                else { from.SendMessage("You Are Too Far Away From A Plant To Harvest Anything!"); }
            }
        }
        
        private class Marijuana_CropTimer : Timer
        {
            private Marijuana_Crop i_plant;
            public Marijuana_CropTimer(Marijuana_Crop plant)
                : base(TimeSpan.FromSeconds(30), TimeSpan.FromSeconds(15))
            {
                Priority = TimerPriority.OneSecond;
                i_plant = plant;
            }
            protected override void OnTick()
            {
                if (Utility.RandomBool())
                {
                    if ((i_plant != null) && (!i_plant.Deleted))
                    {
                        int current = i_plant.Yield;
                        if (current < i_plant.Capacity)
                            i_plant.Yield = i_plant.Yield + 1;
                        else
                        {
                            i_plant.Yield = i_plant.Capacity;
                            ((Item)i_plant).ItemID = i_plant.FullGraphic;
                            ((Item)i_plant).Name = "Mature Marijuana Plant";
                            ((Item)i_plant).Hue = 572;
                            Stop();
                        }
                    }
                    else Stop();
                }
            }
        }

        public Marijuana_Crop(Serial serial): base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);
            writer.Write(m_lastvisit);
            writer.Write(m_sower);
            writer.Write(this.m_Picked);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
            m_lastvisit = reader.ReadDateTime();
            m_sower = reader.ReadMobile();
            bool m_Picked = reader.ReadBool();

            //if (m_Picked == true)
            //{
                //this.Delete();
            //}
        }
    }
}