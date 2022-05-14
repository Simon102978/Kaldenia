#region References
using Server.Accounting;
using Server.Services.TownCryer;
#endregion

namespace Server
{
    public static class ShardSettings
    {
        [CallPriority(int.MinValue)]
        public static void Configure()
        {
            AccountGold.Enabled = false;
            AccountGold.ConvertOnBank = false;
            AccountGold.ConvertOnTrade = false;
            VirtualCheck.UseEditGump = false;

            TownCryerSystem.Enabled = true;

            Mobile.InsuranceEnabled = false;
            Mobile.VisibleDamageType = VisibleDamageType.Related;

            AOS.DisableStatInfluences();

            Mobile.AOSStatusHandler = AOS.GetStatus;
        }
    }
}
