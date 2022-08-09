using System;

namespace Server.Items
{
    [Flipable]
    public class WallTorch : BaseLight
    {
        [Constructable]
        public WallTorch()
            : base(0xA05)
        {
            Movable = true;
            Duration = TimeSpan.Zero; // Never burnt out
            Burning = false;
            Light = LightType.WestBig;
            Weight = 3.0;
        }

        public WallTorch(Serial serial)
            : base(serial)
        {
        }

        public override int LitItemID
        {
            get
            {
                if (ItemID == 0xA05)
                    return 0xA07;
                else
                    return 0xA0C;
            }
        }
        public override int UnlitItemID
        {
            get
            {
                if (ItemID == 0xA07)
                    return 0xA05;
                else
                    return 0xA0A;
            }
        }
        public void Flip()
        {
            if (Light == LightType.WestBig)
                Light = LightType.NorthBig;
            else if (Light == LightType.NorthBig)
                Light = LightType.WestBig;

            switch (ItemID)
            {
                case 0xA05:
                    ItemID = 0xA0A;
                    break;
                case 0xA07:
                    ItemID = 0xA0C;
                    break;
                case 0xA0A:
                    ItemID = 0xA05;
                    break;
                case 0xA0C:
                    ItemID = 0xA07;
                    break;
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }

	[Flipable]
	public class LanterneMurale : BaseLight
	{
		[Constructable]
		public LanterneMurale()
			: base(0x99AB)
		{
			Movable = true;
			Duration = TimeSpan.Zero; // Never burnt out
			Burning = false;
			Light = LightType.WestBig;
			Weight = 3.0;
		}

		public LanterneMurale(Serial serial)
			: base(serial)
		{
		}

		public override int LitItemID
		{
			get
			{
				if (ItemID == 0x99AB)
					return 0x99AC;
				else
					return 0x99AE;
			}
		}
		public override int UnlitItemID
		{
			get
			{
				if (ItemID == 0x99AC)
					return 0x99AB;
				else
					return 0x909AD;
			}
		}
		public void Flip()
		{
			if (Light == LightType.WestBig)
				Light = LightType.NorthBig;
			else if (Light == LightType.NorthBig)
				Light = LightType.WestBig;

			switch (ItemID)
			{
				case 0x99AB:
					ItemID = 0x99AC;
					break;
				case 0x909AD:
					ItemID = 0x99AE;
					break;
				
					
			}
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
			writer.Write(0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();
		}
	}
}