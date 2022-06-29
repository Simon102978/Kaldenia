using System;

namespace Server.Items
{
    public class GrayBrickFireplaceEastAddonExp : BaseAddon
    {
        public override BaseAddonDeed Deed
        {
            get
            {
                return new GrayBrickFireplaceEastDeedExp();
            }
        }

        [Constructable]
        public GrayBrickFireplaceEastAddonExp()
        {
            AddonComponent ac = null;
            ac = new

            AddonComponent(0x93D);
            ac.Name = "Cheminee en brique grise";
            AddComponent(ac, 0, 0, 0);

            ac = new AddonComponent(0x8CF);
            ac.Name = "Cheminee en brique grise";
            AddComponent(ac, 0, 1, 0);
             
        }

        public GrayBrickFireplaceEastAddonExp(Serial serial)
            : base(serial)
        {
        }

        public override void OnComponentUsed(AddonComponent ac, Mobile from)
        {
            if (!from.InRange(GetWorldLocation(), 2))
                from.SendMessage("Vous êtes trop loin pour l'utiliser !");
            else
            {
                if (ac.ItemID == 0x937)
                {
                    ac.ItemID = 0x8CF;
                    Effects.PlaySound(from.Location, from.Map, 0x4B9);
                    from.SendMessage("Vous éteignez la cheminée !");
                }
                else if (ac.ItemID == 0x8CF)
                {
                    Container pack = from.Backpack;

                    if (pack == null)
                        return;

                    int res = pack.ConsumeTotal(new Type[]{typeof( Log )}, new int[]{ 3 });

                    switch (res)
                    {
                        case 0:
                            {
                                from.SendMessage("You must have 3 logs to put in fireplace");
                                break;
                            }
                        default:
                            {
                                Effects.PlaySound(from.Location, from.Map, 0x137);
                                from.SendMessage("Vous devez avoir 3 bûches %%%#$%?%$#@! mettre dans le foyer");
                                ac.ItemID = 0x935;
                                break;
                            }
                    }
                }
                else if (ac.ItemID == 0x935)
                {
                    Item matchlight = from.Backpack.FindItemByType(typeof(MatchLight));

                    if (matchlight != null)
                    {
                        matchlight.Delete();
                        ac.ItemID = 0x937;
                        ac.Light = LightType.Circle225;
                        Effects.PlaySound(from.Location, from.Map, 0x4BA);
                        from.SendMessage("Vous allumez la cheminée !");
                    }
                    else
                    {
                        if (matchlight == null)
                        {
                            from.SendMessage("Vous devez avoir une allumette pour allumer la cheminée");
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

    public class GrayBrickFireplaceEastDeedExp : BaseAddonDeed
    {
        public override BaseAddon Addon
        {
            get
            {
                return new GrayBrickFireplaceEastAddonExp();
            }
        }

        public override int LabelNumber
        {
            get
            {
                return 1061846;
            }
        }// grey brick fireplace (east)

        [Constructable]
        public GrayBrickFireplaceEastDeedExp()
        {
        }

        public GrayBrickFireplaceEastDeedExp(Serial serial)
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
