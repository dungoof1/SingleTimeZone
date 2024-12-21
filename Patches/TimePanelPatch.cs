using System.Reflection;
using EFT.UI.Matchmaker;
using HarmonyLib;
using SPT.Reflection.Patching;

namespace SingleTimeZone.Patches
{
    public class TimePanelPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(MatchMakerSelectionLocationScreen), "method_6");
        }

        [PatchPostfix]
        public static void Postfix(MatchMakerSelectionLocationScreen __instance, LocationConditionsPanel ____conditions)
        {
            ____conditions.Close();

        }
    }
}
