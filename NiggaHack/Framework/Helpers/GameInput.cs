using BepInEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NiggaHack.Framework.Helpers
{
    public class GameInput
    {
        public static bool GetKey(KeyCode keyCode)
        {
            if (UnityInput.Current.GetKey(keyCode))
            {
                return true;
            }
            return false;
        }
    }
}
