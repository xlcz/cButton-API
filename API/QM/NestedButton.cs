using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Eclipse.API.QM
{
    public class NestedButton : ButtonBase
    {
        public MenuPage menuPage;
        public SingleButton singleButton;
        public bool isRoot;

        public NestedButton(Transform parent, string title, string buttonText, string tooltip, bool isRoot = false, Sprite icon = null, bool halfButton = false, Color? buttonTextColor = null, Color? tooltipTextColor = null) =>
            InitButton(parent, isRoot, title, buttonText, tooltip, icon, halfButton, buttonTextColor, tooltipTextColor);

        public NestedButton(ButtonGroup parent, string title, string buttonText, string tooltip, bool isRoot = false, Sprite icon = null, bool halfButton = false, Color? buttonTextColor = null, Color? tooltipTextColor = null) =>
            InitButton(parent.GetGameObject().transform, isRoot, title, buttonText, tooltip, icon, halfButton, buttonTextColor, tooltipTextColor);

        public NestedButton(MenuPage parent, string title, string buttonText, string tooltip, bool isRoot = false, Sprite icon = null, bool halfButton = false, Color? buttonTextColor = null, Color? tooltipTextColor = null) =>
            InitButton(parent.contentHolder.transform, isRoot, title, buttonText, tooltip, icon, halfButton, buttonTextColor, tooltipTextColor);

        public void InitButton(Transform parent, bool isRoot, string title, string buttonText, string tooltip, Sprite icon = null, bool halfButton = false, Color? buttonTextColor = null, Color? tooltipTextColor = null)
        {
            buttonType = ButtonType.NestedButton;
            buttonLocation = parent;

            menuPage = new MenuPage(isRoot, title);

            singleButton = new SingleButton(parent, buttonText, tooltip, () =>
            {
                menuPage.Open();
            }, icon, halfButton, buttonTextColor, tooltipTextColor);

            ButtonAPI.allQMNestedButtons.Add(this);
        }
    }
}
