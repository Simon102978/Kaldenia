namespace Server.Mobiles
{
    public class MaritimeMageAI : MageAI
	{
        public MaritimeMageAI(BaseCreature m)
            : base(m)
        { }


		public override void WalkRandom(int iChanceToNotMove, int iChanceToDir, int iSteps)
		{
			if (!m_Mobile.Hidden)
			{
				m_Mobile.Hidden = true;
			}
		}

		public override void Deactivate()
		{
			base.Deactivate();

			if (!m_Mobile.Hidden)
			{
				m_Mobile.Hidden = true;
			}
		}
	}
}
