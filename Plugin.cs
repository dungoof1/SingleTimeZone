using BepInEx.Logging;
using BepInEx;
using SingleTimeZone.Patches;

namespace SingleTimeZone
{
    [BepInPlugin("dev.dungoof.SingleTimeZone", "SingleTimeZone", "1.2.0")]
    public class Plugin : BaseUnityPlugin
    {
        public void Awake()
        {
            Plugin.LogSource = base.Logger;
            Plugin.LogSource.LogInfo("Single Time Zone enabled.");
            new TimePanelPatch().Enable();
            new RaidSettingsPatch().Enable();
            new LocationInfoPanelPatch().Enable();
        }
        public static ManualLogSource LogSource;
    }
}
