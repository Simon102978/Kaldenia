
using System;
using Server.Network;

namespace Server.Items
{
    public class RawChickenExp : BaseFood, ICarvable
    {
        public virtual Item GetCarved { get { return new RawChickenLegExp(); } }
        public virtual int GetCarvedAmount { get { return 2; } }

        [Constructable]
        public RawChickenExp() : this(1) { }

        [Constructable]
        public RawChickenExp(int amount)
            : base(amount, 0x9B9)
        {
            Stackable = true;
            Amount = amount;
            Raw = true;
        }

        public bool Carve(Mobile from, Item item)
        {
            if (Parent is ShippingCrate && !((ShippingCrate)Parent).CheckCarve(this))
                return false;

            Item newItem = GetCarved;

            if (newItem == null)
            {
                newItem = new RawChickenLegExp();
            }

            if (newItem != null && HasSocket<Caddellite>())
            {
                newItem.AttachSocket(new Caddellite());
            }

            if (newItem != null)
                base.ScissorHelper(from, newItem, GetCarvedAmount);
                from.SendMessage("You cut the Chicken.");

            return true;
        }

        public RawChickenExp(Serial serial) : base(serial) { }
        public override void Serialize(GenericWriter writer) { base.Serialize(writer); writer.Write((int)0); }
        public override void Deserialize(GenericReader reader) { base.Deserialize(reader); int version = reader.ReadInt(); }
    }
}
