using BepInEx.Logging;
using BepInEx;
using SingleTimeZone.Patches;

namespace SingleTimeZone
{
    [BepInPlugin("dev.dungoof.SingleTimeZone", "SingleTimeZone", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public void Awake()
        {
            Plugin.LogSource = base.Logger;
            Plugin.LogSource.LogInfo("Single Time Zone enabled.");
            new ConditionsPanelPatch().Enable();
            new DefaultTimeZonePatch().Enable();
        }
        public static ManualLogSource LogSource;
    }
}
