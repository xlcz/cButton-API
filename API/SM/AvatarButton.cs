using Eclipse.Utils.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Eclipse.API.SM // avatar stuff is unfinished.
{
    public class AvatarButton
    {
        GameObject gameObject;
        Text titleText;
        VRCUiContentButton contentButton;
        Transform overlayIcons;
        
        public AvatarButton(AvatarList parent, AvatarObject avatar)
        {
            gameObject = GameObject.Instantiate(SMAPI.GetAvatarContainerBase(), parent.content);

            overlayIcons = gameObject.transform.Find("RoomImageShape").Find("OverlayIcons").Find("MobileIcons");

            contentButton = gameObject.GetComponent<VRCUiContentButton>();
            titleText = contentButton.field_Public_Text_0;

            contentButton.field_Public_String_0 = avatar.AvatarId;
            contentButton.field_Public_String_1 = avatar.ImageUrl;
            
            titleText.text = avatar.Name;

            switch (avatar.Platform)
            {
                case AvatarPlatform.Both:
                    overlayIcons.GetChild(2).gameObject.active = true;
                    overlayIcons.GetChild(0).gameObject.active = false;
                    overlayIcons.GetChild(1).gameObject.active = false;
                    break;
                case AvatarPlatform.PC:
                    overlayIcons.GetChild(0).gameObject.active = true;
                    overlayIcons.GetChild(1).gameObject.active = false;
                    overlayIcons.GetChild(2).gameObject.active = false;
                    break;
                case AvatarPlatform.Quest:
                    overlayIcons.GetChild(1).gameObject.active = true;
                    overlayIcons.GetChild(0).gameObject.active = false;
                    overlayIcons.GetChild(2).gameObject.active = false;
                    break;
            }
            gameObject.active = true;

        }
    }
}
