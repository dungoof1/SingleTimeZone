using System;
using System.Reflection;
using EFT.UI;
using EFT.UI.Matchmaker;
using HarmonyLib;
using SPT.Reflection.Patching;
using TMPro;
using SingleTimeZone.Helpers;
using EFT;
using JsonType;

namespace SingleTimeZone.Patches
{
    internal class LocationInfoPanelPatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return AccessTools.Method(typeof(LocationInfoPanel), nameof(LocationInfoPanel.Set));
        }

        [PatchPostfix]
        public static void Postfix(LocationInfoPanel __instance, ref TextMeshProUGUI ____playTime, LocationSettingsClass.Location location)
        {
            DateTime dateTime;
            if(location == null) { return; }

            if(Utils.IsFactory(location.Id))
            {
                DateTime backendTime = Utils.GetDateTime();
                if (Utils.IsDay(backendTime)) 
                {
                    dateTime = LocationConditionsPanel.DateTime_0;
                }
                else 
                {
                    dateTime = LocationConditionsPanel.DateTime_1;
                }
            }
            else
            {
                dateTime = Utils.GetDateTime();
            }

            ____playTime.text = dateTime.ToString("HH:mm:ss");


        }
    }
}
