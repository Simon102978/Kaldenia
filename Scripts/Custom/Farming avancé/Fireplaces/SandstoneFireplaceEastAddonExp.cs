using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Network;
using Server.Mobiles;
using Server.Gumps;

namespace Server.Items
{
    public class SandstoneFireplaceEastAddonExp : BaseAddon
    {
        public override BaseAddonDeed Deed
        {
            get
            {
                return new SandstoneFireplaceEastDeedExp();
            }
        }

        [Constructable]
        public SandstoneFireplaceEastAddonExp()
        {
            AddonComponent ac = null;
            ac = new

            AddonComponent(0x489);
            ac.Name = "Sandstone Fireplace";
            AddComponent(ac, 0, 0, 0);

            ac = new AddonComponent(0x45D);
            ac.Name = "Sandstone Fireplace";
            AddComponent(ac, 0, 1, 0);
             
        }

        public SandstoneFireplaceEastAddonExp(Serial serial)
            : base(serial)
        {
        }

        public override void OnComponentUsed(AddonComponent ac, Mobile from)
        {
            if (from.InRange(GetWorldLocation(), 2))
            {
                if (ac.ItemID != 0x475)
                {
                    if (ac.ItemID == 0x45D)
                    {
                        Container pack = from.Backpack;

                        if (pack != null)
                        {
                            int res = pack.ConsumeTotal(new Type[] { typeof(Log), typeof(MatchLight) }, new int[] { 3, 1 });

                            switch (res)
                            {
                                case 0:
                                    {
                                        from.SendMessage("You must have 3 logs to put in the fireplace");
                                        break;
                                    }
                                case 1:
                                    {
                                        from.SendMessage("You must have a match to light a fire in the fireplace");
                                        break;
                                    }
                                default:
                                    {
                                        Effects.PlaySound(from.Location, from.Map, 0x137);
                                        from.SendMessage("You light a fire in the fireplace.");
                                        ac.ItemID = 0x475;
                                        ac.Light = LightType.Circle225;
                                        Effects.PlaySound(from.Location, from.Map, 0x4BA);
                                        break;
                                    }
                            }
                        }
                    }
                    else
                        return;
                }
                else
                {
                    ac.ItemID = 0x45D;
                    Effects.PlaySound(from.Location, from.Map, 0x4B9);
                    from.SendMessage("You put out the fire in the fireplace!");
                }
            }
            else
                from.SendMessage("You are too far away to use that!");
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // Version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }

    }

    public class SandstoneFireplaceEastDeedExp : BaseAddonDeed
    {
        public override BaseAddon Addon
        {
            get
            {
                return new SandstoneFireplaceEastAddonExp();
            }
        }

        public override int LabelNumber
        {
            get
            {
                return 1061844;
            }
        }// sandstone fireplace (east)

        [Constructable]
        public SandstoneFireplaceEastDeedExp()
        {
        }

        public SandstoneFireplaceEastDeedExp(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // Version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }
}
