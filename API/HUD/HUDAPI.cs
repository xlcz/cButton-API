using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Eclipse.API.HUD
{
    public class HUDAPI
    {
        private static GameObject baseHUDIcon;
        private static Transform hudIconParent;

        public static GameObject GetBaseHUDIcon()
        {
            if (baseHUDIcon == null)
                baseHUDIcon = GameObject.Find("UserInterface/UnscaledUI/HudContent_Old/Hud/VoiceDotParent/VoiceDotDisabled");
            return baseHUDIcon;
        }

        public static Transform GetHUDIconParent()
        {
            if (hudIconParent == null)
                hudIconParent = GameObject.Find("UserInterface/UnscaledUI/HudContent_Old/Hud/VoiceDotParent").transform;
            return hudIconParent;
        }
    }
}
