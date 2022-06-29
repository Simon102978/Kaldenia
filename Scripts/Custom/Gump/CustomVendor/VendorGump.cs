using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Mobiles;
using Server.Items;
using Server.Misc;
using Server.Custom;


namespace Server.Gumps
{

	public class VendorGump : BaseProjectMGump
	{
		private CustomVendor m_Stone;
		private ArrayList m_SubmitData;

		protected ArrayList SubmitData { get { return m_SubmitData; } }

		public VendorGump(Mobile from, CustomVendor stone) : base(stone.Name,530, 480, true)
		{
			m_SubmitData = new ArrayList();

			m_Stone = stone;
			int x = XBase;
			int y = YBase;
			int line = 0;
			int scale = 25;
			int space = 115;

			AddPage(0);

			from.CloseGump(typeof(VendorGump));
			from.CloseGump(typeof(EditVendorGump));

			if (m_SubmitData.Count == 0)
			{
				m_SubmitData.Add(m_Stone.Hued);
				m_SubmitData.Add(m_Stone.Blessed);
				m_SubmitData.Add(m_Stone.Bonded);
			}

			AddLabel(x+420,y+60, 5, "Monnaie d'??#$?&*change:");
			if (m_Stone.Currency != null)
			{
				if (m_Stone.Currency.Name != null)
				{
					AddLabel(x+420,y+80, 5, m_Stone.Currency.Name);
				}
				else
				{
					AddLabel(x+420, y + 80, 33, "" + m_Stone.Currency);
				}
			}
			else
			{
				AddLabel(x+420, y + 80, 33, "None");
			}

			if (m_Stone.HuedPrice > 0)
			{
				AddCheck(x+400, y + 160, 0x2342, 0x2343, (bool)m_SubmitData[0], 1);
				AddLabel(x+430, y + 160, 1152, "Hue: " + m_Stone.HuedPrice);
			}
			if (m_Stone.BlessedPrice > 0)
			{
				AddCheck(x+400, y + 180, 0x2342, 0x2343, (bool)m_SubmitData[1], 2);
				AddLabel(+430, y + 180, 1152, "Bless: " + m_Stone.BlessedPrice);
			}
			if (m_Stone.BondedPrice > 0)
			{
				AddCheck(x+400, y + 200, 0x2342, 0x2343, (bool)m_SubmitData[2], 3);
				AddLabel(x + 430, y + 200, 1152, "Bond: " + m_Stone.BondedPrice);
			}

			if (from.AccessLevel >= AccessLevel.Seer)
			{
				AddButton(x + 400, y + 240, 4005, 4007, 41, GumpButtonType.Reply, 0);
				AddLabel(x + 430, y + 240, 1152, "Edit");
			}

			

			AddButton(x + 420, y + 440, 4005, 4007, 0, GumpButtonType.Reply, 0);
			AddLabel(x + 450, y + 440, 33, "Fermer");

			AddPage(1);

			if (m_Stone.GumpName1 != null && m_Stone.Item1 != null && m_Stone.GumpName1 != "" && m_Stone.Item1 != "")
			{
				AddButton(x + 20, y + 60, 4005, 4007, 1, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 60, 1152, m_Stone.GumpName1);
				AddLabel(x + 300, y + 60, 1152, "" + m_Stone.Price1);
			}

			if (m_Stone.GumpName2 != null && m_Stone.Item2 != null && m_Stone.GumpName2 != "" && m_Stone.Item2 != "")
			{
				AddButton(x + 20, y + 80, 4005, 4007, 2, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 80, 1152, m_Stone.GumpName2);
				AddLabel(x + 300, y + 80, 1152, "" + m_Stone.Price2);
			}

			if (m_Stone.GumpName3 != null && m_Stone.Item3 != null && m_Stone.GumpName3 != "" && m_Stone.Item3 != "")
			{
				AddButton(x + 20, y + 100, 4005, 4007, 3, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 100, 1152, m_Stone.GumpName3);
				AddLabel(x + 300, y + 100, 1152, "" + m_Stone.Price3);
			}

			if (m_Stone.GumpName4 != null && m_Stone.Item4 != null && m_Stone.GumpName4 != "" && m_Stone.Item4 != "")
			{
				AddButton(x + 20, y + 120, 4005, 4007, 4, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 120, 1152, m_Stone.GumpName4);
				AddLabel(x + 300, y + 120, 1152, "" + m_Stone.Price4);
			}

			if (m_Stone.GumpName5 != null && m_Stone.Item5 != null && m_Stone.GumpName5 != "" && m_Stone.Item5 != "")
			{
				AddButton(x + 20, y + 140, 4005, 4007, 5, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 140, 1152, m_Stone.GumpName5);
				AddLabel(x + 300, y + 140, 1152, "" + m_Stone.Price5);
			}

			if (m_Stone.GumpName6 != null && m_Stone.Item6 != null && m_Stone.GumpName6 != "" && m_Stone.Item6 != "")
			{
				AddButton(x + 20, y + 160, 4005, 4007, 6, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 160, 1152, m_Stone.GumpName6);
				AddLabel(x + 300, y + 160, 1152, "" + m_Stone.Price6);
			}

			if (m_Stone.GumpName7 != null && m_Stone.Item7 != null && m_Stone.GumpName7 != "" && m_Stone.Item7 != "")
			{
				AddButton(x + 20, y + 180, 4005, 4007, 7, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 180, 1152, m_Stone.GumpName7);
				AddLabel(x + 300, y + 180, 1152, "" + m_Stone.Price7);
			}

			if (m_Stone.GumpName8 != null && m_Stone.Item8 != null && m_Stone.GumpName8 != "" && m_Stone.Item8 != "")
			{
				AddButton(x + 20, y + 200, 4005, 4007, 8, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 200, 1152, m_Stone.GumpName8);
				AddLabel(x + 300, y + 200, 1152, "" + m_Stone.Price8);
			}

			if (m_Stone.GumpName9 != null && m_Stone.Item9 != null && m_Stone.GumpName9 != "" && m_Stone.Item9 != "")
			{
				AddButton(x + 20, y + 220, 4005, 4007, 9, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 220, 1152, m_Stone.GumpName9);
				AddLabel(x + 300, y + 220, 1152, "" + m_Stone.Price9);
			}

			if (m_Stone.GumpName10 != null && m_Stone.Item10 != null && m_Stone.GumpName10 != "" && m_Stone.Item10 != "")
			{
				AddButton(x + 20, y + 240, 4005, 4007, 10, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 240, 1152, m_Stone.GumpName10);
				AddLabel(x + 300, y + 240, 1152, "" + m_Stone.Price10);
			}

			if (m_Stone.GumpName11 != null && m_Stone.Item11 != null && m_Stone.GumpName11 != "" && m_Stone.Item11 != "")
			{
				AddButton(x + 20, y + 260, 4005, 4007, 11, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 260, 1152, m_Stone.GumpName11);
				AddLabel(x + 300, y + 260, 1152, "" + m_Stone.Price11);
			}

			if (m_Stone.GumpName12 != null && m_Stone.Item12 != null && m_Stone.GumpName12 != "" && m_Stone.Item12 != "")
			{
				AddButton(x + 20, y + 280, 4005, 4007, 12, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 280, 1152, m_Stone.GumpName12);
				AddLabel(x + 300, y + 280, 1152, "" + m_Stone.Price12);
			}

			if (m_Stone.GumpName13 != null && m_Stone.Item13 != null && m_Stone.GumpName13 != "" && m_Stone.Item13 != "")
			{
				AddButton(x + 20, y + 300, 4005, 4007, 13, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 300, 1152, m_Stone.GumpName13);
				AddLabel(x + 300, y + 300, 1152, "" + m_Stone.Price13);
			}

			if (m_Stone.GumpName14 != null && m_Stone.Item14 != null && m_Stone.GumpName14 != "" && m_Stone.Item14 != "")
			{
				AddButton(x + 20, y + 320, 4005, 4007, 14, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 320, 1152, m_Stone.GumpName14);
				AddLabel(x + 300, y + 320, 1152, "" + m_Stone.Price14);
			}

			if (m_Stone.GumpName15 != null && m_Stone.Item15 != null && m_Stone.GumpName15 != "" && m_Stone.Item15 != "")
			{
				AddButton(x + 20, y + 340, 4005, 4007, 15, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 340, 1152, m_Stone.GumpName15);
				AddLabel(x + 300, y + 340, 1152, "" + m_Stone.Price15);
			}

			if (m_Stone.GumpName16 != null && m_Stone.Item16 != null && m_Stone.GumpName16 != "" && m_Stone.Item16 != "")
			{
				AddButton(x + 20, y + 360, 4005, 4007, 16, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 360, 1152, m_Stone.GumpName16);
				AddLabel(x + 300, y + 360, 1152, "" + m_Stone.Price16);
			}

			if (m_Stone.GumpName17 != null && m_Stone.Item17 != null && m_Stone.GumpName17 != "" && m_Stone.Item17 != "")
			{
				AddButton(x + 20, y + 380, 4005, 4007, 17, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 380, 1152, m_Stone.GumpName17);
				AddLabel(x + 300, y + 380, 1152, "" + m_Stone.Price17);
			}

			if (m_Stone.GumpName18 != null && m_Stone.Item18 != null && m_Stone.GumpName18 != "" && m_Stone.Item18 != "")
			{
				AddButton(x + 20, y + 400, 4005, 4007, 18, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 400, 1152, m_Stone.GumpName18);
				AddLabel(x + 300, y + 400, 1152, "" + m_Stone.Price18);
			}

			if (m_Stone.GumpName19 != null && m_Stone.Item19 != null && m_Stone.GumpName19 != "" && m_Stone.Item19 != "")
			{
				AddButton(x + 20, y + 420, 4005, 4007, 19, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 420, 1152, m_Stone.GumpName19);
				AddLabel(x + 300, y + 420, 1152, "" + m_Stone.Price19);
			}

			if (m_Stone.GumpName20 != null && m_Stone.Item20 != null && m_Stone.GumpName20 != "" && m_Stone.Item20 != "")
			{
				AddButton(x + 20, y + 440, 4005, 4007, 20, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 440, 1152, m_Stone.GumpName20);
				AddLabel(x + 300, y + 440, 1152, "" + m_Stone.Price20);
			}

			AddLabel(x + 420, y + 260, 1152, "Page 2");
			AddButton(x + 420, y + 280, 0x1196, 0x1196, 2, GumpButtonType.Page, 2);

			AddPage(2);

			if (m_Stone.GumpName21 != null && m_Stone.Item21 != null && m_Stone.GumpName21 != "" && m_Stone.Item21 != "")
			{
				AddButton(x + 20, y + 60, 4005, 4007, 21, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 60, 1152, m_Stone.GumpName21);
				AddLabel(x + 300, y + 60, 1152, "" + m_Stone.Price21);
			}

			if (m_Stone.GumpName22 != null && m_Stone.Item22 != null && m_Stone.GumpName22 != "" && m_Stone.Item22 != "")
			{
				AddButton(x + 20, y + 80, 4005, 4007, 22, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 80, 1152, m_Stone.GumpName22);
				AddLabel(x + 300, y + 80, 1152, "" + m_Stone.Price22);
			}

			if (m_Stone.GumpName23 != null && m_Stone.Item23 != null && m_Stone.GumpName23 != "" && m_Stone.Item23 != "")
			{
				AddButton(x + 20, y + 100, 4005, 4007, 23, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 100, 1152, m_Stone.GumpName23);
				AddLabel(x + 300, y + 100, 1152, "" + m_Stone.Price23);
			}

			if (m_Stone.GumpName24 != null && m_Stone.Item24 != null && m_Stone.GumpName24 != "" && m_Stone.Item24 != "")
			{
				AddButton(x + 20, y + 120, 4005, 4007, 24, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 120, 1152, m_Stone.GumpName24);
				AddLabel(x + 300, y + 120, 1152, "" + m_Stone.Price24);
			}

			if (m_Stone.GumpName25 != null && m_Stone.Item25 != null && m_Stone.GumpName25 != "" && m_Stone.Item25 != "")
			{
				AddButton(x + 20, y + 140, 4005, 4007, 25, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 140, 1152, m_Stone.GumpName25);
				AddLabel(x + 300, y + 140, 1152, "" + m_Stone.Price25);
			}

			if (m_Stone.GumpName26 != null && m_Stone.Item26 != null && m_Stone.GumpName26 != "" && m_Stone.Item26 != "")
			{
				AddButton(x + 20, y + 160, 4005, 4007, 26, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 160, 1152, m_Stone.GumpName26);
				AddLabel(x + 300, y + 160, 1152, "" + m_Stone.Price26);
			}

			if (m_Stone.GumpName27 != null && m_Stone.Item27 != null && m_Stone.GumpName27 != "" && m_Stone.Item27 != "")
			{
				AddButton(x + 20, y + 180, 4005, 4007, 27, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 180, 1152, m_Stone.GumpName27);
				AddLabel(x + 300, y + 180, 1152, "" + m_Stone.Price27);
			}

			if (m_Stone.GumpName28 != null && m_Stone.Item28 != null && m_Stone.GumpName28 != "" && m_Stone.Item28 != "")
			{
				AddButton(x + 20, y + 200, 4005, 4007, 28, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 200, 1152, m_Stone.GumpName28);
				AddLabel(x + 300, y + 200, 1152, "" + m_Stone.Price28);
			}

			if (m_Stone.GumpName29 != null && m_Stone.Item29 != null && m_Stone.GumpName29 != "" && m_Stone.Item29 != "")
			{
				AddButton(x + 20, y + 220, 4005, 4007, 29, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 220, 1152, m_Stone.GumpName29);
				AddLabel(x + 300, y + 220, 1152, "" + m_Stone.Price29);
			}

			if (m_Stone.GumpName30 != null && m_Stone.Item30 != null && m_Stone.GumpName30 != "" && m_Stone.Item30 != "")
			{
				AddButton(x + 20, y + 240, 4005, 4007, 30, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 240, 1152, m_Stone.GumpName30);
				AddLabel(x + 300, y + 240, 1152, "" + m_Stone.Price30);
			}

			if (m_Stone.GumpName31 != null && m_Stone.Item31 != null && m_Stone.GumpName31 != "" && m_Stone.Item31 != "")
			{
				AddButton(x + 20, y + 260, 4005, 4007, 31, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 260, 1152, m_Stone.GumpName31);
				AddLabel(x + 300, y + 260, 1152, "" + m_Stone.Price31);
			}

			if (m_Stone.GumpName32 != null && m_Stone.Item32 != null && m_Stone.GumpName32 != "" && m_Stone.Item32 != "")
			{
				AddButton(x + 20, y + 280, 4005, 4007, 32, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 280, 1152, m_Stone.GumpName32);
				AddLabel(x + 300, y + 280, 1152, "" + m_Stone.Price32);
			}

			if (m_Stone.GumpName33 != null && m_Stone.Item33 != null && m_Stone.GumpName33 != "" && m_Stone.Item33 != "")
			{
				AddButton(x + 20, y + 300, 4005, 4007, 33, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 300, 1152, m_Stone.GumpName33);
				AddLabel(x + 300, y + 300, 1152, "" + m_Stone.Price33);
			}

			if (m_Stone.GumpName34 != null && m_Stone.Item34 != null && m_Stone.GumpName34 != "" && m_Stone.Item34 != "")
			{
				AddButton(x + 20, y + 320, 4005, 4007, 34, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 320, 1152, m_Stone.GumpName34);
				AddLabel(x + 300, y + 320, 1152, "" + m_Stone.Price34);
			}

			if (m_Stone.GumpName35 != null && m_Stone.Item35 != null && m_Stone.GumpName35 != "" && m_Stone.Item35 != "")
			{
				AddButton(x + 20, y + 340, 4005, 4007, 35, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 340, 1152, m_Stone.GumpName35);
				AddLabel(x + 300, y + 340, 1152, "" + m_Stone.Price35);
			}

			if (m_Stone.GumpName36 != null && m_Stone.Item36 != null && m_Stone.GumpName36 != "" && m_Stone.Item36 != "")
			{
				AddButton(x + 20, y + 360, 4005, 4007, 36, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 360, 1152, m_Stone.GumpName36);
				AddLabel(x + 300, y + 360, 1152, "" + m_Stone.Price36);
			}

			if (m_Stone.GumpName37 != null && m_Stone.Item37 != null && m_Stone.GumpName37 != "" && m_Stone.Item37 != "")
			{
				AddButton(x + 20, y + 380, 4005, 4007, 37, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 380, 1152, m_Stone.GumpName37);
				AddLabel(x + 300, y + 380, 1152, "" + m_Stone.Price37);
			}

			if (m_Stone.GumpName38 != null && m_Stone.Item38 != null && m_Stone.GumpName38 != "" && m_Stone.Item38 != "")
			{
				AddButton(x + 20, y + 400, 4005, 4007, 38, GumpButtonType.Reply, 0);
				AddLabel(50, y + 400, 1152, m_Stone.GumpName38);
				AddLabel(x + 300, y + 400, 1152, "" + m_Stone.Price38);
			}

			if (m_Stone.GumpName39 != null && m_Stone.Item39 != null && m_Stone.GumpName39 != "" && m_Stone.Item39 != "")
			{
				AddButton(x + 20, y + 420, 4005, 4007, 39, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 420, 1152, m_Stone.GumpName39);
				AddLabel(x + 300, y + 420, 1152, "" + m_Stone.Price39);
			}

			if (m_Stone.GumpName40 != null && m_Stone.Item40 != null && m_Stone.GumpName40 != "" && m_Stone.Item40 != "")
			{
				AddButton(x + 20, y + 440, 4005, 4007, 40, GumpButtonType.Reply, 0);
				AddLabel(x + 50, y + 440, 1152, m_Stone.GumpName40);
				AddLabel(x + 300, y + 440, 1152, "" + m_Stone.Price40);
			}

			AddLabel(x + 420, y + 260, 1152, "Page 1");
			AddButton(x + 420, y + 280, 0x119a, 0x119a, 1, GumpButtonType.Page, 1);
		}

		public override void OnResponse(NetState state, RelayInfo info)
		{
			Mobile from = state.Mobile;

			if (m_Stone.Deleted)
				return;

			m_SubmitData[0] = info.IsSwitched(1);
			m_SubmitData[1] = info.IsSwitched(2);
			m_SubmitData[2] = info.IsSwitched(3);

			m_Stone.Hued = (bool)m_SubmitData[0];
			m_Stone.Blessed = (bool)m_SubmitData[1];
			m_Stone.Bonded = (bool)m_SubmitData[2];

			switch (info.ButtonID)
			{
				case 0:
					{
						from.SendMessage("You decide not to buy anything.");
						m_Stone.Hued = false;
						m_Stone.Blessed = false;
						m_Stone.Bonded = false;
						break;
					}
				case 1:
					{
						if (m_Stone.Item1 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price1, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item1);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price1, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item1);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 2:
					{
						if (m_Stone.Item2 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price2, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item2);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price2, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item2);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 3:
					{
						if (m_Stone.Item3 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price3, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item3);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price3, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item3);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 4:
					{
						if (m_Stone.Item4 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price4, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item4);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price4, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item4);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 5:
					{
						if (m_Stone.Item5 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price5, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item5);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price5, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item5);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 6:
					{
						if (m_Stone.Item6 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price6, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item6);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price6, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item6);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 7:
					{
						if (m_Stone.Item7 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price7, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item7);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price7, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item7);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 8:
					{
						if (m_Stone.Item8 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price8, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item8);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price8, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item8);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 9:
					{
						if (m_Stone.Item9 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price9, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item9);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price9, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item9);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 10:
					{
						if (m_Stone.Item10 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price10, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item10);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price10, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item10);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 11:
					{
						if (m_Stone.Item11 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price11, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item11);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price11, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item11);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 12:
					{
						if (m_Stone.Item12 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price12, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item12);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price12, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item12);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 13:
					{
						if (m_Stone.Item13 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price13, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item13);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price13, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item13);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 14:
					{
						if (m_Stone.Item14 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price14, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item14);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price14, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item14);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 15:
					{
						if (m_Stone.Item15 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price15, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item15);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price15, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item15);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 16:
					{
						if (m_Stone.Item16 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price16, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item16);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price16, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item16);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 17:
					{
						if (m_Stone.Item17 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price17, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item17);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price17, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item17);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 18:
					{
						if (m_Stone.Item18 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price18, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item18);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price18, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item18);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 19:
					{
						if (m_Stone.Item19 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price19, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item19);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price19, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item19);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 20:
					{
						if (m_Stone.Item20 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price20, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item20);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price20, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item20);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 21:
					{
						if (m_Stone.Item21 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price21, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item21);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price21, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item21);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 22:
					{
						if (m_Stone.Item22 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price22, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item22);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price22, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item22);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 23:
					{
						if (m_Stone.Item23 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price23, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item23);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price23, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item23);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 24:
					{
						if (m_Stone.Item24 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price24, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item24);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price24, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item24);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 25:
					{
						if (m_Stone.Item25 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price25, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item25);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price25, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item25);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 26:
					{
						if (m_Stone.Item26 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price26, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item26);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price26, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item26);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 27:
					{
						if (m_Stone.Item27 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price27, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item27);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price27, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item27);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 28:
					{
						if (m_Stone.Item28 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price28, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item28);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price28, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item28);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 29:
					{
						if (m_Stone.Item29 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price29, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item29);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price29, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item29);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 30:
					{
						if (m_Stone.Item30 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price30, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item30);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price30, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item30);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 31:
					{
						if (m_Stone.Item31 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price31, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item31);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price31, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item31);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 32:
					{
						if (m_Stone.Item32 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price32, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item32);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price32, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item32);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 33:
					{
						if (m_Stone.Item33 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price33, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item33);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price33, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item33);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 34:
					{
						if (m_Stone.Item34 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price34, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item34);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price34, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item34);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 35:
					{
						if (m_Stone.Item35 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price35, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item35);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price35, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item35);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 36:
					{
						if (m_Stone.Item36 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price36, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item36);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price36, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item36);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 37:
					{
						if (m_Stone.Item37 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price37, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item37);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price37, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item37);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 38:
					{
						if (m_Stone.Item38 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price38, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item38);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price38, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item38);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 39:
					{
						if (m_Stone.Item39 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price39, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item39);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price39, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item39);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 40:
					{
						if (m_Stone.Item40 == null)
							return;

						if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.Price40, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item40);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else if (from.BankBox.ConsumeTotal(m_Stone.Currency, m_Stone.Price40, true))
						{
							try
							{
								Type type = VendorType.GetType(m_Stone.Item40);
								if (type != null)
								{
									try
									{
										object o = Activator.CreateInstance(type);

										if (o is Mobile)
										{
											Mobile m = (Mobile)o;

											m.Map = from.Map;
											m.Location = from.Location;
											if (m is BaseCreature)
											{
												BaseCreature c = (BaseCreature)m;
												c.ControlMaster = from;
												c.Controlled = true;
												c.ControlOrder = OrderType.Follow;
												c.ControlTarget = from;
												if (m_Stone.Bonded == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BondedPrice, true))
													{
														c.IsBonded = true;
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;
													}
													else
													{
														m_Stone.Blessed = false;
														m_Stone.Bonded = false;

														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bond the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to bond the creature.");
													}
												}
												if (m_Stone.Hued == true)
												{
													if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
													{
														from.SendHuePicker(new CreatureHuePicker(c, this));
														m_Stone.Hued = false;
														m_Stone.Blessed = false;
													}
													else
													{
														if (m_Stone.Currency.Name != null)
															from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the creature.");
														else
															from.SendMessage("You do not have enough of this stone's currency to hue the creature.");
													}
												}

												if (c.Name != null)
													from.SendMessage("You have bought " + c.Name + ".");
												else
													from.SendMessage("You have bought a creature");
											}
										}
										if (o is Item)
										{
											Item item = (Item)o;
											if (m_Stone.Blessed == true)
											{
												if (item.LootType == LootType.Blessed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item already comes blessed.");
												}
												else if (item.LootType == LootType.Cursed)
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													from.SendMessage("This item is of the loot type 'cursed' you may not bless it.");
												}
												else if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.BlessedPrice, true))
												{
													item.LootType = LootType.Blessed;
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;
												}
												else
												{
													m_Stone.Blessed = false;
													m_Stone.Bonded = false;

													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to bless the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to bless the item.");
												}
											}
											if (m_Stone.Hued == true)
											{
												if (from.Backpack.ConsumeTotal(m_Stone.Currency, m_Stone.HuedPrice, true))
												{
													from.SendHuePicker(new ItemHuePicker(item, this));
													m_Stone.Hued = false;
													m_Stone.Bonded = false;
												}
												else
												{
													if (m_Stone.Currency.Name != null)
														from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " to hue the item.");
													else
														from.SendMessage("You do not have enough of this stone's currency to hue the item.");
												}
											}

											from.Backpack.DropItem(item);

											if (item.Name != null)
												from.SendMessage("You have bought " + item.Name + ".");
											else
												from.SendMessage("You have bought an item.");
										}
									}
									catch
									{
										from.SendMessage("This item doesn't seem to be constructable, please call the shard staff to come and fix this problem.");
									}
								}
							}
							catch
							{
								from.SendMessage("This is not an item, please call the shard staff to come and fix this problem.");
							}
						}
						else
						{
							if (m_Stone.Currency.Name != null)
								from.SendMessage("You do not have enough " + m_Stone.Currency.Name + " for that.");
							else
								from.SendMessage("You do not have enough of this stone's currency for that.");
						}
						break;
					}
				case 41:
					{
						from.SendGump(new EditVendorGump(from, m_Stone));
						break;
					}
			}
		}
		private class ItemHuePicker : HuePickers.HuePicker
		{
			private Item m_Item;
			private VendorGump m_Gump;

			public ItemHuePicker(Item item, VendorGump gump) : base(0x1018)
			{
				m_Item = item;
				m_Gump = gump;
			}

			public override void OnResponse(int hue)
			{
				if (m_Item != null)
					m_Item.Hue = hue;
			}
		}
		private class CreatureHuePicker : HuePickers.HuePicker
		{
			private BaseCreature m_Creature;
			private VendorGump m_Gump;

			public CreatureHuePicker(BaseCreature creature, VendorGump gump) : base(0x1018)
			{
				m_Creature = creature;
				m_Gump = gump;
			}

			public override void OnResponse(int hue)
			{
				if (m_Creature != null)
					m_Creature.Hue = hue;
			}
		}
	}


}
