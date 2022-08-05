using System;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class Ecraseur : Item
	{
		[Constructable]
		public Ecraseur() : base( 4787 )
		{
			Name = "�craseur";
			Weight = 1.0;
		}

        public Ecraseur(Serial serial)
            : base(serial)
		{
		}

        public override void OnDoubleClick(Mobile from)
        {
            if (IsChildOf(from.Backpack))
            {
                from.SendMessage("Que voulez-vous �craser?");
                from.BeginTarget(1, false, TargetFlags.None, new TargetCallback(OnTarget));
            }
            else
            {
                from.SendMessage("L'objet doit �tre dans votre sac pour �tre utilis�.");
            }
        }

        private void OnTarget(Mobile from, object o)
        {
            if (o is BaseShell)
            {
                BaseShell shell = (BaseShell)o;

                shell.ScissorHelper(from, new PoudreCoquillages(), 1, false);
            }
            else
            {
                from.SendMessage("Vous ne pouvez �craser cela.");
            }
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}