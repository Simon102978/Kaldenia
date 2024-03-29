using Server.Items;
using Server.Mobiles;
using Server.Targeting;
using System.Collections;

namespace Server.Commands
{
    public class GMbody
    {
        public static void Initialize()
        {
            CommandSystem.Register("GMbody", AccessLevel.Counselor, GM_OnCommand);
        }

        [Usage("GMbody")]
        [Description("Helps staff members get going.")]
        public static void GM_OnCommand(CommandEventArgs e)
        {
            e.Mobile.Target = new GMmeTarget();
        }

        private class GMmeTarget : Target
        {
            private static Mobile m_Mobile;
            public GMmeTarget()
                : base(-1, false, TargetFlags.None)
            {
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is Mobile)
                {
                    Mobile targ = (Mobile)targeted;
                    if (from != targ)
                        from.SendMessage("You may only set your own body to GM style.");

                    else
                    {
                        m_Mobile = from;

                        if (Config.Get("Staff.Staffbody", true))
                        {
                            m_Mobile.BodyValue = 987;

                            if (Config.Get("Staff.UseColoring", true))
                            {
                                switch (m_Mobile.AccessLevel)
                                {
                                    case AccessLevel.Owner: m_Mobile.Hue = Config.Get("Staff.Owner", 1001); break;
                                    case AccessLevel.Developer: m_Mobile.Hue = Config.Get("Staff.Developer", 1001); break;
                                    case AccessLevel.Administrator: m_Mobile.Hue = Config.Get("Staff.Administrator", 1001); break;
                                    case AccessLevel.Seer: m_Mobile.Hue = Config.Get("Staff.Seer", 467); break;
                                    case AccessLevel.GameMaster: m_Mobile.Hue = Config.Get("Staff.GameMaster", 39); break;
                                    case AccessLevel.Counselor: m_Mobile.Hue = Config.Get("Staff.Counselor", 3); break;
                                }
                            }
                        }

                        if (Config.Get("Staff.CutHair", true))
                            m_Mobile.HairItemID = 0;

                        if (Config.Get("Staff.CutFacialHair", true))
                            m_Mobile.FacialHairItemID = 0;

                        CommandLogging.WriteLine(from, "{0} {1} is assuming a GM body", from.AccessLevel, CommandLogging.Format(from));

                        Container pack = from.Backpack;

                        ArrayList ItemsToDelete = new ArrayList();

                        foreach (Item item in from.Items)
                        {
                            if (item.Layer != Layer.Bank && item.Layer != Layer.Hair && item.Layer != Layer.FacialHair && item.Layer != Layer.Mount && item.Layer != Layer.Backpack)
                            {
                                ItemsToDelete.Add(item);
                            }
                        }
                        foreach (Item item in ItemsToDelete)
                            item.Delete();

                        if (pack == null)
                        {
                            pack = new Backpack
                            {
                                Movable = false
                            };

                            from.AddItem(pack);
                        }
                        else
                        {
                            pack.Delete();
                            pack = new Backpack
                            {
                                Movable = false
                            };

                            from.AddItem(pack);
                        }

                        from.Hunger = 20;
                        from.Thirst = 20;
                        from.Fame = 0;
                        from.Karma = 0;
                        from.Kills = 0;
                        from.Hidden = true;
                        from.Blessed = true;
                        from.Hits = from.HitsMax;
                        from.Mana = from.ManaMax;
                        from.Stam = from.StamMax;

                        if (from.IsStaff())
                        {
                            EquipItem(new StaffRing());

                            PackItem(new GMHidingStone());
                            PackItem(new GMEthereal());
                            PackItem(new StaffOrb());

                            from.RawStr = 100;
                            from.RawDex = 100;
                            from.RawInt = 100;

                            from.Hits = from.HitsMax;
                            from.Mana = from.ManaMax;
                            from.Stam = from.StamMax;

                            for (int i = 0; i < targ.Skills.Length; ++i)
                                targ.Skills[i].Base = 120;
                        }

                        if (Config.Get("Staff.GiveBoots", true))
                        {
                            int color = 0;
                            if (Config.Get("Staff.UseColoring", true))
                            {
                                switch (m_Mobile.AccessLevel)
                                {
                                    case AccessLevel.Owner: color = Config.Get("Staff.Owner", 1001); break;
                                    case AccessLevel.Developer: color = Config.Get("Staff.Developer", 1001); break;
                                    case AccessLevel.Administrator: color = Config.Get("Staff.Administrator", 1001); break;
                                    case AccessLevel.Seer: color = Config.Get("Staff.Seer", 467); break;
                                    case AccessLevel.GameMaster: color = Config.Get("Staff.GameMaster", 39); break;
                                    case AccessLevel.Counselor: color = Config.Get("Staff.Counselor", 3); break;
                                }
                            }

                        }
                    }
                }
            }

            private static void EquipItem(Item item)
            {
                EquipItem(item, false);
            }

            private static void EquipItem(Item item, bool mustEquip)
            {
                if (m_Mobile == null || m_Mobile.EquipItem(item))
                    return;

                Container pack = m_Mobile.Backpack;

                if (!mustEquip && pack != null)
                    pack.DropItem(item);
                else
                    item.Delete();
            }

            private static void PackItem(Item item)
            {
                Container pack = m_Mobile.Backpack;

                if (pack != null)
                    pack.DropItem(item);
                else
                    item.Delete();
            }
        }
    }
}
