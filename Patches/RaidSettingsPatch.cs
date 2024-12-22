using System.Reflection;
using EFT.UI.Matchmaker;
using EFT;
using SPT.Reflection.Patching;
using HarmonyLib;
using SingleTimeZone.Helpers;
using JsonType;
using System;

namespace SingleTimeZone.Patches
{
    internal class RaidSettingsPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(LocationConditionsPanel), nameof(LocationConditionsPanel.Set));
        }

        [PatchPostfix]
        public static void Postfix(LocationConditionsPanel __instance, ref RaidSettings raidSettings)
        {
            if (Utils.IsFactory(raidSettings.LocationId))
            {
                if (Utils.IsDay(__instance.DateTime_2))
                {
                    raidSettings.SelectedDateTime = EDateTime.CURR;
                }
                else
                {
                    raidSettings.SelectedDateTime = EDateTime.PAST;
                }
            }
            else
            {
                raidSettings.SelectedDateTime = EDateTime.CURR;
            }
        }
    }
}