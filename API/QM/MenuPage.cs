using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Elements;
using VRC.UI.Elements.Menus;

namespace Eclipse.API.QM
{
    public class MenuPage : ButtonBase
    {
        private static int siblingIndex => APIUtils.GetQuickMenuInstance().field_Public_Transform_0.Find("Window/QMParent/Modal_AddMessage").GetSiblingIndex();
        public string menuName;
        public RectTransform rectTransform;
        public TextMeshProUGUI text;
        public GameObject contentHolder;
        public GameObject header;
        public GameObject backButton;
        public UIPage menuPage;

        public MenuPage(bool isRoot, string title)
        {
            buttonType = ButtonType.MenuPage;
            randomNumber = APIUtils.RandomNumber();

            gameObject = GameObject.Instantiate(APIUtils.GetMenuPageTemplate(), APIUtils.GetQMParent().transform);
            menuName = $"{ButtonAPI.Identifier}-{title}-{randomNumber}-MenuPage";
            gameObject.name = menuName;
            rectTransform = gameObject.GetComponent<RectTransform>();

            rectTransform.SetSiblingIndex(siblingIndex);

            if (!fixedScrolling)
            {
                FixLaunchpadScrolling();
                fixedScrolling = true;

 
                var scrollRect = gameObject.GetComponentInChildren<ScrollRect>();
                scrollRect.content.GetComponent<VerticalLayoutGroup>().childControlHeight = true;
                scrollRect.enabled = true;
                scrollRect.verticalScrollbar = scrollRect.transform.Find("Scrollbar").GetComponent<Scrollbar>();
                scrollRect.viewport.GetComponent<RectMask2D>().enabled = true;
            }

            header = gameObject.transform.GetChild(0).gameObject;
            GameObject.DestroyImmediate(header.transform.Find("RightItemContainer/Button_QM_Expand").gameObject);

            if (!isRoot)
            {
                var backButton = header.GetComponentInChildren<Button>(true);
                backButton.gameObject.SetActive(true);
            }

            GameObject.DestroyImmediate(gameObject.GetComponent<LaunchPadQMMenu>());

            menuPage = gameObject.AddComponent<UIPage>();
            menuPage.field_Public_String_0 = menuName;
            menuPage.field_Private_Boolean_1 = true;
            menuPage.field_Protected_MenuStateController_0 = APIUtils.GetMenuStateControllerInstance();
            menuPage.field_Private_List_1_UIPage_0 = new Il2CppSystem.Collections.Generic.List<UIPage>();
            menuPage.field_Private_List_1_UIPage_0.Add(menuPage);

            APIUtils.GetMenuStateControllerInstance().field_Private_Dictionary_2_String_UIPage_0.Add(menuName, menuPage);

            if (isRoot)
            {
                var rootPages = APIUtils.GetMenuStateControllerInstance().field_Public_ArrayOf_UIPage_0.ToList();
                rootPages.Add(menuPage);
                APIUtils.GetMenuStateControllerInstance().field_Public_ArrayOf_UIPage_0 = rootPages.ToArray();
            }



            text = header.GetComponentInChildren<TextMeshProUGUI>();
            SetTitle(title);

            contentHolder = gameObject.transform.Find("ScrollRect/Viewport/VerticalLayoutGroup/").gameObject;
            contentHolder.transform.DestroyChildren();

            ButtonAPI.allQMMenuPages.Add(this);
        }

        public void SetTitle(string title)
        {
            text.text = title;
        }

        public void Open()
        {
            APIUtils.GetMenuStateControllerInstance().Method_Public_Void_String_UIContext_Boolean_TransitionType_0(menuPage.field_Public_String_0);
        }


        private bool fixedScrolling;
        private void FixLaunchpadScrolling()
        {
            var scrollRect = gameObject.GetComponentInChildren<ScrollRect>();

            scrollRect.content.GetComponent<VerticalLayoutGroup>().childControlHeight = true;
            scrollRect.enabled = true;
            scrollRect.verticalScrollbar = scrollRect.transform.Find("Scrollbar").GetComponent<Scrollbar>(); ;
            scrollRect.viewport.GetComponent<RectMask2D>().enabled = true;
        }
    }
}
