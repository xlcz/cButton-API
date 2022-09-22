using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Core.Styles;
using VRC.UI.Elements.Controls;

namespace Eclipse.API.QM
{
    public class Tab : ButtonBase
    {
        public Transform parent;
        public MenuTab menuTab;
        public Image tabIcon;

        public Tab(string tooltip, MenuPage menuPage ,Sprite icon = null)
        {
            randomNumber = APIUtils.RandomNumber();
            parent = APIUtils.GetTabBase().transform.parent;

            gameObject = GameObject.Instantiate(APIUtils.GetTabBase(), parent);
            gameObject.name = $"{ButtonAPI.Identifier}-{parent.name}-{randomNumber}-Tab";

            tabIcon = gameObject.transform.Find("Icon").GetComponent<Image>();
            tabIcon.sprite = icon;
            tabIcon.overrideSprite = icon;
            menuTab = gameObject.GetComponent<MenuTab>();
            menuTab.field_Private_MenuStateController_0 = APIUtils.GetMenuStateControllerInstance();
            menuTab.field_Public_String_0 = menuPage.menuName;
            GameObject.Destroy(gameObject.transform.FindChild("Badge"));
            menuTab.gameObject.GetComponent<StyleElement>().field_Private_Selectable_0 = menuTab.gameObject.GetComponent<Button>();
            menuTab.gameObject.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = tooltip;
            menuTab.gameObject.GetComponent<Button>().onClick.AddListener((Action)delegate
            {
                menuTab.gameObject.GetComponent<StyleElement>().field_Private_Selectable_0 = menuTab.gameObject.GetComponent<Button>();
            });

            ButtonAPI.allQMTabs.Add(this);
        }
    }
}
