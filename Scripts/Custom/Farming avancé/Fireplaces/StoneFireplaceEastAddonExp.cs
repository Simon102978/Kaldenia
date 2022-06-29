using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Network;
using Server.Mobiles;
using Server.Gumps;

namespace Server.Items
{
    public class StoneFireplaceEastAddonExp : BaseAddon
    {
        public override BaseAddonDeed Deed
        {
            get
            {
                return new StoneFireplaceEastDeedExp();
            }
        }

        [Constructable]
        public StoneFireplaceEastAddonExp()
        {
            AddonComponent ac = null;
            ac = new

            AddonComponent(0x959);
            ac.Name = "Chemin??#$?&*e en pierre";
            AddComponent(ac, 0, 0, 0);

            ac = new AddonComponent(0x8DA);
            ac.Name = "Chemin??#$?&*e en pierre";
            AddComponent(ac, 0, 1, 0);
             
        }

        public StoneFireplaceEastAddonExp(Serial serial)
            : base(serial)
        {
        }

        public override void OnComponentUsed(AddonComponent ac, Mobile from)
        {
            if (!from.InRange(GetWorldLocation(), 2))
                from.SendMessage("Vous êtes trop loin pour l'utiliser !");
            else
            {
                if (ac.ItemID == 0x953)
                {
                    ac.ItemID = 0x8DA;
                    Effects.PlaySound(from.Location, from.Map, 0x4B9);
                    from.SendMessage("Vous ??#$?&*teignez le feu dans la chemin??#$?&*e !");
                }
                else if (ac.ItemID == 0x8DA)
                {
                    Container pack = from.Backpack;

                    if (pack == null)
                        return;

                    int res = pack.ConsumeTotal(new Type[]{typeof( Log )}, new int[]{ 3 });

                    switch (res)
                    {
                        case 0:
                            {
                                from.SendMessage("Vous devez avoir 3 bûches à mettre dans la chemin??#$?&*e");
                                break;
                            }
                        default:
                            {
                                Effects.PlaySound(from.Location, from.Map, 0x137);
                                from.SendMessage("Vous mettez les bûches dans la chemin??#$?&*e !");
                                ac.ItemID = 0x951;
                                break;
                            }
                    }
                }
                else if (ac.ItemID == 0x951)
                {
                    Item matchlight = from.Backpack.FindItemByType(typeof(MatchLight));

                    if (matchlight != null)
                    {
                        matchlight.Delete();
                        ac.ItemID = 0x953;
                        ac.Light = LightType.Circle225;
                        Effects.PlaySound(from.Location, from.Map, 0x4BA);
                        from.SendMessage("Vous allumez un feu dans la chemin??#$?&*e.");
                    }
                    else
                    {
                        if (matchlight == null)
                        {
                            from.SendMessage("Vous devez avoir une allumette pour allumer un feu dans la chemin??#$?&*e");
                        }
                    }
                }
                else
                    return;
            }
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

    public class StoneFireplaceEastDeedExp : BaseAddonDeed
    {
        public override BaseAddon Addon
        {
            get
            {
                return new StoneFireplaceEastAddonExp();
            }
        }

        public override int LabelNumber
        {
            get
            {
                return 1061848;
            }
        }// stone fireplace (east)

        [Constructable]
        public StoneFireplaceEastDeedExp()
        {
        }

        public StoneFireplaceEastDeedExp(Serial serial)
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
