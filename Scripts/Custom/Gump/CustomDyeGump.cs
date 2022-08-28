using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Mobiles;
using Server.Items;
using Server.Misc;
using System.Collections.Generic;


namespace Server.Gumps
{
    public class CustomDyeGump : BaseProjectMGump
	{

		public static Dictionary<int, CouleurSet> ColorIndex = new Dictionary<int, CouleurSet>()
		{
			 { 0, new CouleurSet("Rose", 1201,   new List<int>(){1201, 1202, 1203, 1204, 1205, 1206, 1207, 1208, 1209, 1210, 1211, 1212, 1213, 1214, 1215, 1216, 1217, 1218, 1219, 1220, 1221, 1222, 1223, 1224, 1225, 1226, 1227, 1228, 1229, 1230, 1231, 1232, 1233, 1234, 1235, 1236, 1237, 1238, 1239, 1240, 1241, 1242, 1243, 1244, 1245, 1246, 1247, 1248, 1249, 1250, 1251, 1252, 1253, 1254 } )},
			 { 1, new CouleurSet("Bleu", 1301,   new List<int>(){1301, 1302, 1303, 1304, 1305, 1306, 1307, 1308, 1309, 1310, 1311, 1312, 1313, 1314, 1315, 1316, 1317, 1318, 1319, 1320, 1321, 1322, 1323, 1324, 1325, 1326, 1327, 1328, 1329, 1330, 1331, 1332, 1333, 1334, 1335, 1336, 1337, 1338, 1339, 1340, 1341, 1342, 1343, 1344, 1345, 1346, 1347, 1348, 1349, 1350, 1351, 1352, 1353, 1354} )},
		     { 2, new CouleurSet("Vert", 1401,   new List<int>(){1401, 1402, 1403, 1404, 1405, 1406, 1407, 1408, 1409, 1410, 1411, 1412, 1413, 1414, 1415, 1416, 1417, 1418, 1419, 1420, 1421, 1422, 1423, 1424, 1425, 1426, 1427, 1428, 1429, 1430, 1431, 1432, 1433, 1434, 1435, 1436, 1437, 1438, 1439, 1440, 1441, 1442, 1443, 1444, 1445, 1446, 1447, 1448, 1449, 1450, 1451, 1452, 1453, 1454} )},
			 { 3, new CouleurSet("Orange", 1501,   new List<int>(){1501, 1502, 1503, 1504, 1505, 1506, 1507, 1508, 1509, 1510, 1511, 1512, 1513, 1514, 1515, 1516, 1517, 1518, 1519, 1520, 1521, 1522, 1523, 1524, 1525, 1526, 1527, 1528, 1529, 1530, 1531, 1532, 1533, 1534, 1535, 1536, 1537, 1538, 1539, 1540, 1541, 1542, 1543, 1544, 1545, 1546, 1547, 1548, 1549, 1550, 1551, 1552, 1553, 1554} )},
			 { 4, new CouleurSet("Rouge", 1601,   new List<int>(){1601, 1602, 1603, 1604, 1605, 1606, 1607, 1608, 1609, 1610, 1611, 1612, 1613, 1614, 1615, 1616, 1617, 1618, 1619, 1620, 1621, 1622, 1623, 1624, 1625, 1626, 1627, 1628, 1629, 1630, 1631, 1632, 1633, 1634, 1635, 1636, 1637, 1638, 1639, 1640, 1641, 1642, 1643, 1644, 1645, 1646, 1647, 1648, 1649, 1650, 1651, 1652, 1653, 1654} )},
			 { 5, new CouleurSet("Jaune", 1701,   new List<int>(){1701, 1702, 1703, 1704, 1705, 1706, 1707, 1708, 1709, 1710, 1711, 1712, 1713, 1714, 1715, 1716, 1717, 1718, 1719, 1720, 1721, 1722, 1723, 1724, 1725, 1726, 1727, 1728, 1729, 1730, 1731, 1732, 1733, 1734, 1735, 1736, 1737, 1738, 1739, 1740, 1741, 1742, 1743, 1744, 1745, 1746, 1747, 1748, 1749, 1750, 1751, 1752, 1753, 1754} )},
			 { 6, new CouleurSet("Gris/noir", 1882,   new List<int>(){1882, 1883, 1884, 1885, 1886, 1887, 1888, 1889, 1890, 1891, 1892, 1893, 1894, 1895, 1896, 1897, 1898, 1899, 1900, 1901, 1902, 1903, 1904} )}, 
			 { 7, new CouleurSet("Hue coloré", 2101,   new List<int>(){2101, 2102, 2103, 2104, 2105, 2106, 2107, 2108, 2109, 2110, 2111, 2112, 2113, 2114, 2115, 2116, 2117, 2118} )}

		};

		private CustomPlayerMobile m_From;
		private int m_Page;
		private int m_hue;
		private DyeTub m_dyeTub;

		public CustomDyeGump(CustomPlayerMobile from, DyeTub tub, int hue, int page = 0)
			: base("Couleurs", 560, 360, false)
		{

			m_From = from;
			m_hue = hue;
			m_Page = page;
			m_dyeTub = tub;

			int x = XBase;
			int y = YBase;


			int i = 0;
			int line = 0;
			int colonne = 0;


			AddSection(x - 10, y, 300, 349, "Catégories");

			foreach (KeyValuePair<int, CouleurSet> item in ColorIndex)
			{
				AddButton(x + 20, y + 25 * line + 52, 2117, 2118, item.Key + 100, GumpButtonType.Reply, 0);
				AddLabel(x + 38, y + 25 * line + 50, item.Value.NameHue, item.Value.Name);
				line++;
			}

			AddSection(x + 291, y, 309, 349, "Couleurs");


			List<int> toFill = new List<int>();

			int Nombre = 0;
			int Nombre2 = 0;
			int Nombre3 = 0;

			foreach (int item in ColorIndex[page].HueChoice)
			{

				toFill.Add(ColorIndex[page].HueChoice[Nombre]);

				Nombre2++;
				Nombre++;

				if (Nombre2 == 10 || Nombre == ColorIndex[page].HueChoice.Count - 1)
				{
					AddColorChoice(x + 350, y + 50 + Nombre3 * 40, 1000 + Nombre3 * 10, toFill.ToArray());
					Nombre3++;
					Nombre2 = 0;
					toFill = new List<int>();

				}
			}


			AddBackground(x + 250, y - 5, 75, 75, 9270);

			AddItem(x + 260, y + 20, tub.ItemID, hue);

			AddSection(x - 10, y + 350, 610, 50, ColorIndex[page].Name);

			AddButton(x + 525, y + 363, 1, 239,240);



		}

		public override void OnResponse(NetState sender, RelayInfo info)
        {



			if (info.ButtonID == 1)
			{
				m_dyeTub.DyedHue = m_hue;
				m_From.SendMessage("Vous mélangez les couleurs.");

			}
			else if (info.ButtonID >= 100 && info.ButtonID < 200)
			{
				m_From.SendGump(new CustomDyeGump(m_From, m_dyeTub, m_hue, info.ButtonID - 100));
			}
			else if (info.ButtonID >= 1000 && info.ButtonID < 5000)
			{

				int hue = ColorIndex[m_Page].HueChoice[info.ButtonID - 1000];

				m_From.SendGump(new CustomDyeGump(m_From, m_dyeTub, hue, m_Page));

				
			}


		}


		public class CouleurSet
		{
			private string m_Name;
			private int m_NameHue;
			private List<int> m_HueChoice = new List<int>();

			public string Name { get => m_Name; set => m_Name = value; }
			public int NameHue { get => m_NameHue; set => m_NameHue = value; }
			public List<int> HueChoice { get => m_HueChoice; set => m_HueChoice = value; }

			public CouleurSet(string name, int nameHue, List<int> listHue)
			{
				m_Name = name;
				m_NameHue = nameHue;
				m_HueChoice = listHue;
			}
		}



	}
}
