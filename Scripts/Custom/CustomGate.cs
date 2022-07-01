using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Server.Items
{
	public class CustomGate : Moongate
	{


		public CustomGate(Point3D target, Map map)
			: base(target, map)
		{
			Map = map;
			//Hue = 1795;
			Name = "Passage";

			Dispellable = true;

			InternalTimer t = new InternalTimer(this);
			t.Start();
		}




		public CustomGate(Serial serial)
			: base(serial)
		{
		}

		public override bool ShowFeluccaWarning => false;
		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			Delete();
		}

		private class InternalTimer : Timer
		{
			private readonly Item m_Item;

			public InternalTimer(Item item)
				: base(TimeSpan.FromSeconds(30.0))
			{
				Priority = TimerPriority.OneSecond;
				m_Item = item;
			}

			protected override void OnTick()
			{
				m_Item.Delete();
			}
		}
	}
}
