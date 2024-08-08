using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NiggaHack.Framework
{
    public class Settings
    {
        // Window
        public static Rect WindowRect = new Rect(100, 100, 550, 370);
        public static string[] Tabs = new string[] { "Room", "Freecam", "Tracker", "Mods" };
        public static int Tab = 0;
        public static bool Toggled = true;
        public static float ToggleDelay;
    }
}
