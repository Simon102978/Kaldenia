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



		public static void Configure()
        {
            EventSink.WorldSave += OnSave;
            EventSink.WorldLoad += OnLoad;

			Ouverture = DateTime.Now;
			TaxesMoney = 0;
			Salaire = 0;

		}

        public static void OnSave(WorldSaveEventArgs e)
        {
            Persistence.Serialize(
                FilePath,
                writer =>
                {
                    writer.Write(1);

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
