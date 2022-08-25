using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server.Items
{
    public enum DrugType
    {
        Light,
        Medium,
        Hard
    }

    public enum DrugPlantType
    {
        Shimyshisha,
        Shenyr,
        Amaesha,
        Astishys, 
        Gwelalith, 
        Frilar, 
        Thomahar, 
        Thiseth, 
        Etherawin,
        Eralirid
    }

    public class DrugHelper
    {
        public static Dictionary<DrugPlantType, int> DrugItemIDs = new Dictionary<DrugPlantType, int>();

        public static void Initialize()
        {
            DrugItemIDs.Add(DrugPlantType.Shimyshisha, 0x0D06);
            DrugItemIDs.Add(DrugPlantType.Shenyr, 0x0D0C);
            DrugItemIDs.Add(DrugPlantType.Amaesha, 0x0D10);
            DrugItemIDs.Add(DrugPlantType.Astishys, 0x0D16);
            DrugItemIDs.Add(DrugPlantType.Gwelalith, 0x3B0C);
            DrugItemIDs.Add(DrugPlantType.Frilar, 0x3B07);
            DrugItemIDs.Add(DrugPlantType.Thomahar, 0x3C06);
            DrugItemIDs.Add(DrugPlantType.Thiseth, 0x3C29);
            DrugItemIDs.Add(DrugPlantType.Etherawin, 0x0D15);
            DrugItemIDs.Add(DrugPlantType.Eralirid, 0x3ACF);
        }

    }
}
