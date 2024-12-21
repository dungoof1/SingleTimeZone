using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using JsonType;
using EFT;
using EFT.UI.Matchmaker;

namespace SingleTimeZone.Helpers
{
    internal class Utils
    {
        public static bool IsDay(LocationConditionsPanel locationConditionsPanel)
        {
            DateTime time = locationConditionsPanel.DateTime_2;

            if (time.Hour > 5 && time.Hour < 21)
            {
                return true;
            }
            else
            {
                return false;
            }

            
        }

        public static bool IsFactory(RaidSettings raidSettings)
        {
            if (raidSettings.LocationId == "factory4_day" || raidSettings.LocationId == "factory4_night")
            {
                Plugin.LogSource.LogInfo("Factory");
                return true;
            } 
            else
            {
                return false;
            }
        }
    }   
}
