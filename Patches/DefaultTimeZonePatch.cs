using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EFT.UI.Matchmaker;
using EFT;
using JsonType;
using SPT.Reflection.Patching;

namespace SingleTimeZone.Patches
{
    internal class DefaultTimeZonePatch : ModulePatch
    {
        protected override MethodBase GetTargetMethod()
        {
            return typeof(LocationConditionsPanel).GetMethod("Set");
        }

        [PatchPostfix]
        public static void Postfix(ref RaidSettings raidSettings)
        {
            if (raidSettings == null)
            {
                return;
            }
            bool flag = raidSettings.LocationId == "factory4_day" || raidSettings.LocationId == "factory4_night";
            if (!flag)
            {
                raidSettings.SelectedDateTime = EDateTime.CURR;
            }
        }
    }
}