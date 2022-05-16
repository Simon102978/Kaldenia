using Server.Targeting;
using Server.Network;
using Server.Gumps;

namespace Server.Items
{
	public class CheeseForm : Item
	{
		private int FromToDo;
		private int CheeseWhich;
		private int StadeFermentation;
		private bool FullMold;
		private bool Fermentation;
		private bool ContientUnFromton;
		public int m_FromBonusSkill;

		[CommandProperty( AccessLevel.GameMaster )]
		public int m_FromToDo
        {
			get { return FromToDo; }
			set { FromToDo = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int m_CheeseWhich
        {
			get { return CheeseWhich; }
			set { CheeseWhich = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int m_StadeFermentation
		{
			get { return StadeFermentation; }
			set { StadeFermentation = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public bool m_FullMold
        {
			get { return FullMold; }
			set { FullMold = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public bool m_Fermentation
		{
			get { return Fermentation; }
			set { Fermentation = value; }
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public bool m_ContientUnFromton
		{
			get { return ContientUnFromton; }
			set { ContientUnFromton = value; }
		}

		[Constructable]
		public CheeseForm() : base( 0x0E78 )
		{
			Weight = 10.0;
			Name = "Cheese Form: Empty";
			Hue = 0x481;
		}

		public override void OnDoubleClick (Mobile from )
		{
			Container pack = from.Backpack;
			m_FromBonusSkill =(m_CheeseWhich + ((int)(from.Skills[SkillName.Cooking].Value)/5));
			if (! from.InRange( this.GetWorldLocation(), 2 ))
			{
				from.LocalOverheadMessage( MessageType.Regular, 906, 1019045 );
			}
			else
			{
				if ((Fermentation == false) && (FullMold == false) && (ContientUnFromton == false))
				{
					from.Target = new OnRempliMouleFromton( this );
					from.SendMessage(0x84C, "Choose the milk bucket for filling the cheese form." );
				}
				else if ((FullMold == true) && (Fermentation == false) && (ContientUnFromton == false))
				{
					new FromQuiFermente(this).Start();
					Fermentation = true;
					from.SendMessage("You start the fermentation process.");
					if ( from.CheckSkill( SkillName.Cooking, 0, 100 ) )
						m_StadeFermentation = 5;
					else
						m_StadeFermentation = 0;
				}
				else if ((Fermentation == true) && (ContientUnFromton == false) && (FullMold == true))
				{
					this.PublicOverheadMessage( MessageType.Regular, 1151, false, string.Format("Fermentation process: " + StadeFermentation.ToString() + " %" ));
				}
				else if ((Fermentation == false) && (ContientUnFromton == true) && (FullMold == true))
				{
					if (m_FromBonusSkill < 10)
					{
						this.PublicOverheadMessage( MessageType.Regular, 1152, false, string.Format("Fermentation failed, the milk is lost." ) );
						m_ContientUnFromton = false;
                        m_FullMold = false;
                        m_CheeseWhich = 0;
                        m_FromToDo = 0;
						this.Name = "Cheese Form: Empty";
					}
					else if ( (m_FromBonusSkill > 95 ) && Utility.RandomBool() )
					{
						if ( FromToDo == 1 )
						{
							from.SendMessage(0x84C, "You obtain a wonderful Sheep Cheese from the form." );
							from.AddToBackpack( new SheepCheeseMagic() );
							m_ContientUnFromton = false;
                            m_FullMold = false;
                            m_CheeseWhich = 0;
                            m_FromToDo = 0;
							this.Name = "Cheese Form: Empty";
						}
						else if ( FromToDo == 2 )
						{
							from.SendMessage(0x84C, "You obtain a wonderful Goat Cheese from the form." );
							from.AddToBackpack( new GoatCheeseMagic() );
							m_ContientUnFromton = false;
                            m_FullMold = false;
                            m_CheeseWhich = 0;
                            m_FromToDo = 0;
							this.Name = "Cheese Form: Empty";
						}
						else
						{
							from.SendMessage(0x84C, "You obtain a wonderful Cow Cheese from the form." );
							from.AddToBackpack( new CowCheeseMagic() );
							m_ContientUnFromton = false;
                            m_FullMold = false;
                            m_CheeseWhich = 0;
                            m_FromToDo = 0;
							this.Name = "Cheese Form: Empty";
						}
					}
					else
					{
						if ( FromToDo == 1 )
						{
							from.SendMessage(0x84C, "You obtain a sheep cheese from the form." );
							from.AddToBackpack( new SheepCheese() );
							m_ContientUnFromton = false;
                            m_FullMold = false;
                            m_CheeseWhich = 0;
                            m_FromToDo = 0;
							this.Name = "Cheese Form: Empty";
						}
						else if ( FromToDo == 2 )
						{
							from.SendMessage(0x84C, "You obtain a goat cheese from the form." );
							from.AddToBackpack( new GoatCheese() );
							m_ContientUnFromton = false;
                            m_FullMold = false;
                            m_CheeseWhich = 0;
                            m_FromToDo = 0;
							this.Name = "Cheese Form: Empty";
						}
						else
						{
							from.SendMessage(0x84C, "You obtain a cow cheese from the form." );
							from.AddToBackpack( new CowCheese() );
							m_ContientUnFromton = false;
                            m_FullMold = false;
                            m_CheeseWhich = 0;
                            m_FromToDo = 0;
							this.Name = "Cheese Form: Empty";
						}
					}
				}
				else
				{
					from.SendMessage(0x84C, "*gasp* A bug!");
				}
			}
		}

		public CheeseForm( Serial serial ) : base( serial ) { }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
			writer.Write( (int) FromToDo);
			writer.Write( (int) CheeseWhich);
			writer.Write( (int) StadeFermentation );
			writer.Write( (bool) FullMold);
			writer.Write( (bool) Fermentation);
			writer.Write( (bool) ContientUnFromton);
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
			switch ( version )
			{
				case 0:
					{
                        FromToDo = reader.ReadInt();
                        CheeseWhich = reader.ReadInt();
						StadeFermentation = reader.ReadInt();
                        FullMold = reader.ReadBool();
						Fermentation = reader.ReadBool();
						ContientUnFromton = reader.ReadBool();

						if ( Fermentation == true )
							new FromQuiFermente(this).Start();

						break;
					}
			}
		}
	}
	public class OnRempliMouleFromton : Target
	{
		private CheeseForm m_MouleVar;
		MilkBucket m_SautFromage = null;

		public OnRempliMouleFromton( CheeseForm m_CheeseForm ) : base( 3, false, TargetFlags.None )
		{
			m_MouleVar = m_CheeseForm;

		}

		protected override void OnTarget( Mobile from, object o )
		{
			if (o is MilkBucket )
			{
				m_SautFromage =(MilkBucket)o;
				if (m_SautFromage.Milking >= 15)
				{
					m_SautFromage.Milking = m_SautFromage.Milking - 15;

					if (m_SautFromage.m_beast == 1 )
					{
						m_SautFromage.Name ="Milk Bucket: " + m_SautFromage.Milking.ToString() + "/50 liters of sheep milk.";
						m_MouleVar.m_FromToDo = 1;
						m_MouleVar.Name="Cheese form: Sheep cheese";
						m_MouleVar.m_FullMold = true;
					}
					else if (m_SautFromage.m_beast == 2 )
					{
						m_SautFromage.Name ="Milk Bucket: " + m_SautFromage.Milking.ToString() + "/50 liters of goat milk.";
						m_MouleVar.m_FromToDo = 2;
						m_MouleVar.Name="Cheese form: Goat cheese";
						m_MouleVar.m_FullMold = true;
					}
					else if (m_SautFromage.m_beast == 3 )
					{
						m_SautFromage.Name ="Milk Bucket: " + m_SautFromage.Milking.ToString() + "/50 liters of cow milk.";
						m_MouleVar.m_FromToDo = 3;
						m_MouleVar.Name="Cheese form: Cow cheese";
						m_MouleVar.m_FullMold = true;
					}
					else
					{
						from.SendMessage(0x84C, "This isn't a good milk bucket." );
						from.CloseGump( typeof( CheeseFormHelpGump ) );
						from.SendGump( new CheeseFormHelpGump ( from ) );

					}
				}
				else
				{
					from.SendMessage(0x84C, "The milk bucket didn't contain enough milk." );
					from.CloseGump( typeof( CheeseFormHelpGump ) );
					from.SendGump( new CheeseFormHelpGump ( from ) );

				}

				if ( m_SautFromage.Milking <= 0 )
				{
					m_SautFromage.Milking = 0;
					m_SautFromage.m_beast = 0;
					m_SautFromage.Name = "Milk Bucket: (Empty)";
				}
			}
			else
			{
				from.SendMessage(0x84C, "Use a milk bucket with at least 15 liters." );
				from.CloseGump( typeof( CheeseFormHelpGump ) );
				from.SendGump( new CheeseFormHelpGump ( from ) );
			}
		}
	}
}
