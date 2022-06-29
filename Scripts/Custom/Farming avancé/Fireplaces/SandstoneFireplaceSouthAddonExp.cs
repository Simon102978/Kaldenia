using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Network;
using Server.Mobiles;
using Server.Gumps;

namespace Server.Items
{
    public class SandstoneFireplaceSouthAddonExp : BaseAddon
    {
        public override BaseAddonDeed Deed
        {
            get
            {
                return new SandstoneFireplaceSouthDeedExp();
            }
        }

        [Constructable]
        public SandstoneFireplaceSouthAddonExp()
        {
            AddonComponent ac = null;
            ac = new

            AddonComponent(0x45F);
            ac.Name = "Cheminée en gr%%%#$%?%$#@!s";
            AddComponent(ac, 0, 0, 0);

            ac = new AddonComponent(0x482);
            ac.Name = "Cheminée en gr%%%#$%?%$#@!s";
            AddComponent(ac, -1, 0, 0);
             
        }

        public SandstoneFireplaceSouthAddonExp(Serial serial)
            : base(serial)
        {
        }

        public override void OnComponentUsed(AddonComponent ac, Mobile from)
        {
            if (!from.InRange(GetWorldLocation(), 2))
                from.SendMessage("Vous êtes trop loin pour l'utiliser !");
            else
            {
                if (ac.ItemID == 0x47B)
                {
                    ac.ItemID = 0x45F;
                    Effects.PlaySound(from.Location, from.Map, 0x4B9);
                    from.SendMessage("Vous éteignez le feu dans la cheminée !");
                }
                else if (ac.ItemID == 0x45F)
                {
                    Container pack = from.Backpack;

                    if (pack == null)
                        return;

                    int res = pack.ConsumeTotal(new Type[] { typeof(Log), typeof(MatchLight) }, new int[] { 3, 1 });

                    switch (res)
                    {
                        case 0:
                            {
                                from.SendMessage("Vous devez avoir 3 bûches à mettre dans la cheminée");
                                break;
                            }
                        case 1:
                            {
                                from.SendMessage("Vous devez avoir une allumette pour allumer un feu dans la cheminée");
                                break;
                            }
                        default:
                            {
                                Effects.PlaySound(from.Location, from.Map, 0x137);
                                from.SendMessage("Vous allumez un feu dans la cheminée.");
                                ac.ItemID = 0x47B;
                                ac.Light = LightType.Circle225;
                                Effects.PlaySound(from.Location, from.Map, 0x4BA);
                                break;
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

    public class SandstoneFireplaceSouthDeedExp : BaseAddonDeed
    {
        public override BaseAddon Addon
        {
            get
            {
                return new SandstoneFireplaceSouthAddonExp();
            }
        }

        public override int LabelNumber
        {
            get
            {
                return 1061845;
            }
        }// sandstone fireplace (South)

        [Constructable]
        public SandstoneFireplaceSouthDeedExp()
        {
        }

        public SandstoneFireplaceSouthDeedExp(Serial serial)
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
