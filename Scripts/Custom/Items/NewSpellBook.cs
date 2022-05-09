using System.Collections;
using Server.Network;
using Server.Gumps;

namespace Server.Items
{
	public class NewSpellbook : Spellbook
	{
		public override SpellbookType SpellbookType { get { return SpellbookType.Regular; } }
		public override int BookOffset { get { return 600; } }
		public override int BookCount { get { return 200; } }

		public ArrayList Contents = new ArrayList();

		[Constructable]
		public NewSpellbook()
			: this((ulong)0, 0xEFA)
		{
		}

		[Constructable]
		public NewSpellbook(ulong content, int itemid)
			: base(content, itemid)
		{
			Name = "Grimoire";
			Layer = Layer.OneHanded;
		}

		public override void OnDoubleClick(Mobile from)
		{
			Container pack = from.Backpack;

			if (Parent == from || (pack != null && Parent == pack))
			{
				from.CloseGump(typeof(NewSpellbookGump));
				from.SendGump(new NewSpellbookGump(from, this));
			}
			else
			{
				from.SendMessage("Le grimoire doit être dans votre sac principal pour l'ouvrir.");
			}
		}

		public override bool OnDragDrop(Mobile from, Item dropped)
		{
			if (dropped is SpellScroll && dropped.Amount == 1)
			{
				SpellScroll scroll = (SpellScroll)dropped;

				if (HasSpell(scroll.SpellID))
				{
					from.SendLocalizedMessage(500179); // That spell is already present in that spellbook.
					return false;
				}
				else
				{
					int val = scroll.SpellID;

					if (val >= 600)
					{
						Contents.Add(val);

						scroll.Delete();

						from.Send(new PlaySound(0x249, GetWorldLocation()));
						return true;
					}

					return false;
				}
			}
			else
			{
				return false;
			}
		}

		public void AddSpell(int SpellID)
		{

			if (HasSpell(SpellID))
			{		
				return;
			}
			else
			{
				int val = SpellID;

				if (val >= 600)
				{
					Contents.Add(val);				
					return;
				}

				return;
			}




		}



        public override bool HasSpell(int spellID)
        {
            return Contents.Contains(spellID);
        }

        public NewSpellbook(Serial serial) : base(serial)
        {
        }

        public override void Serialize( GenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int) 0 ); // version

            writer.Write(Contents.Count);

            for (int i = 0; i < Contents.Count; i++)
            {
                int spellID = (int)Contents[i];
                writer.Write(spellID);
            }
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();

            int count = reader.ReadInt();

            for (int i = 0; i < count; i++)
            {
                Contents.Add(reader.ReadInt());
            }
        }
    }
}
