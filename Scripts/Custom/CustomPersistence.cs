using Server.Mobiles;
using System.Collections.Generic;
using System.IO;
using System;

namespace Server.Custom
{
    public static class CustomPersistence
    {
        public static string FilePath = Path.Combine("Saves/", "CustomPersistence.bin");

        public static DateTime Ouverture { get; set; }
		public static int TaxesMoney { get; set; }
		public static int Salaire { get; set; }

		public static DateTime ProchainePay { get; set; }

		public static Dictionary<string, double> SellItems = new Dictionary<string, double>();


		public static void AddSellItem(string items, double value)
		{
			if (SellItems.ContainsKey(items))
			{
				SellItems[items] += value;
			}
			else
			{
				SellItems.Add(items, value);
			}


		}








		public static void Configure()
        {
            EventSink.WorldSave += OnSave;
            EventSink.WorldLoad += OnLoad;

			Ouverture = DateTime.Now;
			ProchainePay = Ouverture.AddDays(7);
			TaxesMoney = 0;
			Salaire = 0;

		}

        public static void OnSave(WorldSaveEventArgs e)
        {
            Persistence.Serialize(
                FilePath,
                writer =>
                {
                    writer.Write(3);

					writer.Write(SellItems.Count);

					foreach (KeyValuePair<string, double> item in SellItems)
					{
						writer.Write(item.Key);
						writer.Write(item.Value);
					}

					writer.Write(ProchainePay);
					writer.Write(Salaire);
					writer.Write(TaxesMoney);

					writer.Write(Ouverture);
                });
        }

        public static void OnLoad()
        {
            Persistence.Deserialize(
                FilePath,
                reader =>
                {
                    int version = reader.ReadInt();

					switch (version)
					{

						case 3:
							{
								int count = reader.ReadInt();

								for (int i = 0; i < count; i++)
								{
									SellItems.Add(reader.ReadString(), reader.ReadDouble());
								}
								goto case 2;
							}

						case 2:
							{
								ProchainePay = reader.ReadDateTime();
								goto case 1;
							}
						case 1:
							{
								Salaire = reader.ReadInt();
								TaxesMoney = reader.ReadInt();
								goto case 0;
							}
						case 0:
							{
								Ouverture = reader.ReadDateTime();
								break;
							}
					}


				});
        }
    }
}
