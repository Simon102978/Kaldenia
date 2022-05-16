namespace Server.Items
{
    public enum MeadQuality
    {
        Low,
        Regular,
        Exceptional
    }

    public enum AleQuality
    {
        Low,
        Regular,
        Exceptional
    }

    public enum CiderQuality
    {
        Low,
        Regular,
        Exceptional
    }

    public enum TeaQuality
    {
        Low,
        Regular,
        Exceptional
    }

    public enum CoffeeQuality
    {
        Low,
        Regular,
        Exceptional
    }

    public enum CocoaQuality
    {
        Low,
        Regular,
        Exceptional
    }

    class BrewMsgs
    {
        public static string extremely = "You drink the beverage, but are still extremely thirsty.";
        public static string satiated = "You drink the beverage, and begin to feel more satiated.";
        public static string less = "After drinking the beverage, you feel much less thirsty.";
        public static string full = "You feel quite full after consuming the beverage.";
        public static string defualtfull = "You manage to drink the beverage, but you are full!";
    }
}