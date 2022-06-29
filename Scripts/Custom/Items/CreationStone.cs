using System;
using Server;
using Server.Gumps;
using Server.Mobiles;
using System.Collections.Generic;
using Server.Accounting;

namespace Server.Items
{
  public class CreationStone : Item
  {

    [Constructable]
    public CreationStone()
        : base(3796)
    {
      Movable = false;
      Name = "Création";
    }

    public override void OnDoubleClickDead(Mobile from)
    {
      OnDoubleClick(from);
    }

    public override void OnDoubleClick(Mobile from)
    {
      if (from is CustomPlayerMobile && from.InRange(Location, 4))
      {
				CustomPlayerMobile cPlayer = from as CustomPlayerMobile;

				from.CloseGump(typeof(CreationBaseGump));

				from.SendGump(new CreationRaceGump(cPlayer, new CreationPerso(cPlayer)));
      }
      else
      {
        from.SendLocalizedMessage(500446); // That is too far away.
      }
    }

    public CreationStone(Serial serial)
        : base(serial)
    {
    }

    public override void Serialize(GenericWriter writer)
    {
      base.Serialize(writer);

      writer.Write((int)0); // version
    }

    public override void Deserialize(GenericReader reader)
    {
      base.Deserialize(reader);

      int version = reader.ReadInt();
    }
  }
}

