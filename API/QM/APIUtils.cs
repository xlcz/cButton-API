using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Core;
using VRC.UI.Elements;
using VRC.UI.Elements.Menus;

namespace Eclipse.API.QM
{
    public static class APIUtils
    {
        private static System.Random random = new();

        private static MenuStateController menuStateControllerInstance { get; set; }
        private static VRC.UI.Elements.QuickMenu quickMenuInstance;
        private static GameObject menuPageTemplate;
        private static GameObject qmParent;
        private static GameObject singleButtonTemplate;
        private static GameObject menuTabTemplate;
        private static GameObject headerTemplate;
        private static GameObject foldoutTemplate;
        private static GameObject buttonGroupTemplate;
        private static GameObject sliderContainerTemplate;
        private static GameObject sliderTemplate;
        private static GameObject textTemplate;
        private static GameObject checkBoxTemplate;
        private static SelectedUserMenuQM selectedUserMenuQM;
        private static GameObject panelTemplate;
        private static GameObject panelParent;
        private static GameObject qmPopupTemplate;
        private static Sprite onIconTemplate;
        private static Sprite offIconTemplate;

        public static GameObject GetCheckBoxTemplate()
        {
            if (checkBoxTemplate == null)
            {
                checkBoxTemplate = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_QM_Report_Issue/Panel/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup/Cell_QM_Modal_ListItem(Clone)/").gameObject;
            }
            return checkBoxTemplate;
        }

        public static GameObject GetQMPopupTemplate()
        {
            if (qmPopupTemplate == null)
            {
                qmPopupTemplate = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Modal_Alert/").gameObject;
            }
            return qmPopupTemplate;
        }

        public static GameObject GetPanelTemplate()
        {
            if (panelTemplate == null)
            {
                panelTemplate = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMNotificationsArea/DebugInfoPanel/").gameObject;
            }
            return panelTemplate;
        }

        public static GameObject GetPanelParent()
        {
            if (panelParent == null)
            {
                panelParent = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMNotificationsArea/").gameObject;
            }
            return panelParent;
        }

        public static SelectedUserMenuQM GetSelectedUserMenuQM
        {
            get
            {
                if (selectedUserMenuQM == null)
                {
                    selectedUserMenuQM = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_SelectedUser_Local").GetComponent<SelectedUserMenuQM>();
                }

                return selectedUserMenuQM;
            }
        }

        public static GameObject GetTabBase()
        {
            if (menuTabTemplate == null)
            {
                menuTabTemplate = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Settings").gameObject;
            }
            return menuTabTemplate;
        }

        public static GameObject SingleButtonTemplate()
        {
            if (singleButtonTemplate == null)
            {
                var Buttons = GetQuickMenuInstance().GetComponentsInChildren<Button>(true);
                foreach (var button in Buttons)
                {
                    if (button.name == "Button_Screenshot")
                    {
                        singleButtonTemplate = button.gameObject;
                    }
                };
            }
            return singleButtonTemplate;
        }

        public static MenuStateController GetMenuStateControllerInstance()
        {
            if (menuStateControllerInstance == null)
            {
                menuStateControllerInstance = GetQuickMenuInstance().transform.GetComponent<MenuStateController>();
            }
            return menuStateControllerInstance;
        }

        public static VRC.UI.Elements.QuickMenu GetQuickMenuInstance()
        {
            if (quickMenuInstance == null)
                quickMenuInstance = Resources.FindObjectsOfTypeAll<VRC.UI.Elements.QuickMenu>()[0];
            return quickMenuInstance;
        }

        public static GameObject GetQMParent()
        {
            if (qmParent == null)
                qmParent = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent").gameObject;
            return qmParent;
        }

        public static GameObject GetSliderTemplate()
        {
            if (sliderTemplate == null)
                sliderTemplate = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_AudioSettings/Content/Audio/VolumeSlider_Master").gameObject;

            return sliderTemplate;
        }

        public static GameObject GetSliderContainerTemplate()
        {
            if (sliderContainerTemplate == null)
                sliderContainerTemplate = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_AudioSettings/Content/Audio/").gameObject;

            return sliderContainerTemplate;
        }

        public static GameObject GetMenuPageTemplate()
        {
            if (menuPageTemplate == null)
                menuPageTemplate = GetQMParent().transform.Find("Menu_Dashboard").gameObject;

            return menuPageTemplate;
        }

        public static GameObject GetHeaderTemplate()
        {
            if (headerTemplate == null)
                headerTemplate = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Header_QuickLinks/").gameObject;

            return headerTemplate;
        }

        public static GameObject GetFoldoutTemplate()
        {
            if (foldoutTemplate == null)
                foldoutTemplate = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup/QM_Foldout_Comfort/").gameObject;

            return foldoutTemplate;
        }

        public static GameObject GetButtonGroupTemplate()
        {
            if (buttonGroupTemplate == null)
                buttonGroupTemplate = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickLinks/").gameObject;

            return buttonGroupTemplate;
        }

        public static Sprite GetOnIconSprite()
        {
            if (onIconTemplate == null)
            {
                onIconTemplate = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Notifications/Panel_NoNotifications_Message/Icon").GetComponent<Image>().sprite;
            }
            return onIconTemplate;
        }

        public static Sprite GetOffIconSprite()
        {
            if (offIconTemplate == null)
            {
                offIconTemplate = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup/Buttons_UI_Elements_Row_1/Button_ToggleQMInfo/Icon_Off").GetComponent<Image>().sprite;
            }
            return offIconTemplate;
        }

        public static GameObject GetTextTemplate()
        {
            if (textTemplate == null)
            {
                textTemplate = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/Header_H1/LeftItemContainer/Text_Title").gameObject;
            }
            return textTemplate;
        }

        public static int RandomNumber()
        {
            return random.Next(1, 9999);
        }


        internal static void DestroyChildren(this Transform transform)
        {
            for (var i = transform.childCount - 1; i >= 0; i--)
            {
                UnityEngine.Object.DestroyImmediate(transform.GetChild(i).gameObject);
            }
        }


        public static GameObject FindInactive(string path)
        {
            string[] split = path.Split(new char[] { '/' }, 2);
            Transform rootObject = GameObject.Find($"/{split[0]}")?.transform;

            if (rootObject == null) return null;
            return Transform.FindRelativeTransformWithPath(rootObject, split[1], false)?.gameObject;
        }
    }
}
