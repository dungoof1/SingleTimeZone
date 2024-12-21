using System.Reflection;
using EFT.UI.Matchmaker;
using EFT;
using SPT.Reflection.Patching;
using HarmonyLib;
using SingleTimeZone.Helpers;
using JsonType;
using UnityEngine;

namespace SingleTimeZone.Patches
{
    internal class RaidSettingsPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(LocationConditionsPanel), nameof(LocationConditionsPanel.Set));
        }

        [PatchPostfix]
        public static void Postfix(LocationConditionsPanel __instance, RaidSettings raidSettings)
        {
            if (Utils.IsFactory(raidSettings))
            {
                if (Utils.IsDay(__instance))
                {
                    // If day, set factory day raid
                    raidSettings.SelectedDateTime = EDateTime.CURR;
                }
                else
                {
                    // If night, set factory night raid
                    raidSettings.SelectedDateTime = EDateTime.PAST;
                }
            }
            else
            {
                raidSettings.SelectedDateTime = EDateTime.CURR;
                // DateTime_2
            }
        }
    }
}