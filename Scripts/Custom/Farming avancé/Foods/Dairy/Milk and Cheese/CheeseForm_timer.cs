using System;
using Server;
using Server.Items;
using Server.Prompts;

namespace Server.Items
{
	public class FromQuiFermente : Timer
	{
		private CheeseForm m_TimerMoulVar;
		//private int QualityContest;

		public FromQuiFermente( CheeseForm m_TimerCheeseForm ) : base( TimeSpan.FromSeconds(1),TimeSpan.FromSeconds(72),100)
		{
			Priority = TimerPriority. FiftyMS ;
			m_TimerMoulVar = m_TimerCheeseForm;
		}

		protected override void OnTick()
		{
			if (m_TimerMoulVar.m_StadeFermentation <= 99 )
			{
				++m_TimerMoulVar.m_StadeFermentation;
			}
			if (m_TimerMoulVar.m_StadeFermentation == 100 )
			{
				m_TimerMoulVar.Name = m_TimerMoulVar.Name + " *READY*";
				m_TimerMoulVar.m_StadeFermentation = 0;
				m_TimerMoulVar.m_Fermentation = false;
				m_TimerMoulVar.m_ContientUnFromton = true;
				m_TimerMoulVar.m_CheeseWhich = Utility.Random( 1, 100 );
			}
		}

	}
}
