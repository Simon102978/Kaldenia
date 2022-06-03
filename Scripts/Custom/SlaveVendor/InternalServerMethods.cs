using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Items;

namespace Server.Custom
{
	public class ConsumeFromBank
	{
		public static int GoldCount(Mobile m)
		{
			if (m.BankBox == null)
			{
				m.SendMessage("Vous devez déposer les pièces d'or ou les chèques dans votre coffre de banque.");
				return 0;
			}

			var count = 0;

			var coins = m.BankBox.FindItemsByType(typeof(Gold));

			if (coins != null)
			{
				foreach (Gold coin in coins)
					count += coin.Amount;
			}

			var checks = m.BankBox.FindItemsByType(typeof(BankCheck));

			if (checks != null)
			{
				foreach (BankCheck check in checks)
					count += check.Worth;
			}

			return count;
		}

		public static bool GoldConsumption(Mobile m, int price)
		{
			if (GoldCount(m) >= price)
			{
				var count = price;

				var coins = m.BankBox.FindItemsByType(typeof(Gold));

				if (coins != null)
				{
					foreach (Gold coin in coins)
					{
						var amount = coin.Amount;

						if (amount >= count)
						{
							coin.Consume(count);
							count -= count;
						}
						else
						{
							coin.Consume(amount);
							count -= amount;
						}

						if (count <= 0)
							return true;
					}
				}

				var checks = m.BankBox.FindItemsByType(typeof(BankCheck));

				foreach (BankCheck check in checks)
				{
					var amount = check.Worth;

					if (amount >= count)
					{
						check.Worth -= count;
						count -= count;
					}
					else
					{
						check.Consume();
						count -= amount;
					}

					if (count <= 0)
						return true;
				}
			}

			return false;
		}
	}
}