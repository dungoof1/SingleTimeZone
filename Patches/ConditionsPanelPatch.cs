using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EFT.UI.Matchmaker;
using HarmonyLib;
using SPT.Reflection.Patching;

namespace SingleTimeZone.Patches
{
    public class ConditionsPanelPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(MatchMakerSelectionLocationScreen), "method_6");
        }

        [PatchPostfix]
        public static void Postfix(MatchMakerSelectionLocationScreen __instance, LocationConditionsPanel ____conditions, LocationSettingsClass.Location ___location_0)
        {
            if (___location_0 == null)
            {
                return;
            }
            bool flag = ___location_0.Id == "factory4_day" || ___location_0.Id == "factory4_night";
            if (!flag)
            {
                ____conditions.Close();
            }

        }
    }
}
