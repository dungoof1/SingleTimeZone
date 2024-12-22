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
        public static bool IsDay(DateTime time)
        {
            if (time.Hour > 5 && time.Hour < 21)
            {
                return true;
            }
            else
            {
                return false;
            }

            
        }

        public static bool IsFactory(string location)
        {
            if (location == "factory4_day" || location == "factory4_night")
            {
                return true;
            } 
            else
            {
                return false;
            }
        }

        public static DateTime GetDateTime()
        {
            TarkovApplication.Exist(out TarkovApplication tarkovApplication);
            DateTime dateTime = tarkovApplication.Session.GetCurrentLocationTime;
            return dateTime;
        }
    }   
}
