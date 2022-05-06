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


        public static void Configure()
        {
            EventSink.WorldSave += OnSave;
            EventSink.WorldLoad += OnLoad;

			Ouverture = DateTime.Now;
        }

        public static void OnSave(WorldSaveEventArgs e)
        {
            Persistence.Serialize(
                FilePath,
                writer =>
                {
                    writer.Write(0);

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
