using Eclipse.API.QM;
using Eclipse.Utils;
using System;
using UnityEngine;

namespace Eclipse.API.SM
{
    public static class SMAPI
    {
        public static GameObject labelBase;
        public static GameObject buttonBase;
        public static GameObject smBase;
        public static GameObject toolBoxBase;
        public static GameObject buttonContainer;
        public static GameObject avatarPage;
        public static GameObject avatarListBase;
        public static GameObject avatarPageParent;
        public static GameObject avatarContainerBase;

        public static GameObject GetSM()
        {
            if (smBase == null)
            {
                smBase = GeneralUtils.FindInactive("UserInterface/MenuContent/Screens/UserInfo");
            }

            return smBase;
        }

        public static GameObject GetLabelBase()
        {
            if (labelBase == null)
            {
                labelBase = GeneralUtils.FindInactive("UserInterface/MenuContent/Screens/UserInfo/User Panel/TrustLevel/TrustText");
            }

            return labelBase;
        }

        public static GameObject GetButtonBase()
        {
            if (buttonBase == null)
            {
                buttonBase = GeneralUtils.FindInactive("UserInterface/MenuContent/Screens/UserInfo/Buttons/RightSideButtons/RightUpperButtonColumn/EditStatusButton/");
            }

            return buttonBase;
        }

        public static GameObject GetToolBoxBase()
        {
            if (toolBoxBase == null)
            {
                toolBoxBase = GeneralUtils.FindInactive("UserInterface/MenuContent/Screens/UserInfo/ModerateDialog/");
            }

            return toolBoxBase;
        }

        public static GameObject GetButtonContainer()
        {
            if (buttonContainer == null)
            {
                buttonContainer = GeneralUtils.FindInactive("UserInterface/MenuContent/Screens/UserInfo/Buttons/RightSideButtons/RightUpperButtonColumn/");
            }

            return buttonContainer;
        }

        public static GameObject GetAvatarPage()
        {
            if (avatarPage == null)
            {
                avatarPage = GeneralUtils.FindInactive("UserInterface/MenuContent/Screens/Avatar");
            }
            return avatarPage;
        }

        public static GameObject GetAvatarListBase()
        {
            if (avatarListBase == null)
            {
                avatarListBase = GetAvatarPage().transform.Find("Vertical Scroll View/Viewport/Content/Public Avatar List").gameObject;
            }
            return avatarListBase;
        }

        public static GameObject GetAvatarPageParent()
        {
            if (avatarPageParent == null)
                avatarPageParent = GeneralUtils.FindInactive("UserInterface/MenuContent/Screens/Avatar/Vertical Scroll View/Viewport/Content/FavoriteContent");
            return avatarPageParent;
        }

        public static GameObject GetAvatarContainerBase()
        {
            if (avatarContainerBase == null)
                avatarContainerBase = GeneralUtils.FindInactive("UserInterface/MenuContent/Screens/Avatar/Vertical Scroll View/Viewport/Content/FavoriteContent/avatars1/ViewPort/Content/AvatarUiPrefab2(Clone) 1");
            return avatarContainerBase;
        }
    }
}