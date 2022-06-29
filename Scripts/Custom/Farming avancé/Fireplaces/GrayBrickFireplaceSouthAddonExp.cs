using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Network;
using Server.Mobiles;
using Server.Gumps;

namespace Server.Items
{
    public class GrayBrickFireplaceSouthAddonExp : BaseAddon
    {
        public override BaseAddonDeed Deed
        {
            get
            {
                return new GrayBrickFireplaceSouthDeedExp();
            }
        }

        [Constructable]
        public GrayBrickFireplaceSouthAddonExp()
        {
            AddonComponent ac = null;
            ac = new

            AddonComponent(0x8D4);
            ac.Name = "Cheminee en brique grise";
            AddComponent(ac, 0, 0, 0);

            ac = new AddonComponent(0x94B);
            ac.Name = "Cheminee en brique grise";
            AddComponent(ac, -1, 0, 0);
             
        }

        public GrayBrickFireplaceSouthAddonExp(Serial serial)
            : base(serial)
        {
        }

        public override void OnComponentUsed(AddonComponent ac, Mobile from)
        {
            if (!from.InRange(GetWorldLocation(), 2))
                from.SendMessage("Vous êtes trop loin pour l'utiliser !");
            else
            {
                if (ac.ItemID == 0x945)
                {
                    ac.ItemID = 0x8D4;
                    Effects.PlaySound(from.Location, from.Map, 0x4B9);
                    from.SendMessage("Vous éteignez la cheminée !");
                }
                else if (ac.ItemID == 0x8D4)
                {
                    Container pack = from.Backpack;

                    if (pack == null)
                        return;

                    int res = pack.ConsumeTotal(
                    new Type[]
				    {
					   typeof( Log )
				    },
                    new int[]
				    {
                        3
                    });
                    switch (res)
                    {
                        case 0:
                            {
                                from.SendMessage("Vous devez avoir 3 bûches %%%#$%?%$#@! mettre dans le foyer");
                                break;
                            }
                            default:
                            {
                                Effects.PlaySound(from.Location, from.Map, 0x137);
                                from.SendMessage("Vous mettez les bûches dans la cheminée !");
                                ac.ItemID = 0x943;
                                break;
                            }
                    }
                }
                else if (ac.ItemID == 0x943)
                {
                    Item matchlight = from.Backpack.FindItemByType(typeof(MatchLight));

                    if (matchlight != null)
                    {
                        matchlight.Delete();
                        ac.ItemID = 0x945;
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

    public class GrayBrickFireplaceSouthDeedExp : BaseAddonDeed
    {
        public override BaseAddon Addon
        {
            get
            {
                return new GrayBrickFireplaceSouthAddonExp();
            }
        }

        public override int LabelNumber
        {
            get
            {
                return 1061847;
            }
        }// grey brick fireplace (South)

        [Constructable]
        public GrayBrickFireplaceSouthDeedExp()
        {
        }

        public GrayBrickFireplaceSouthDeedExp(Serial serial)
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
