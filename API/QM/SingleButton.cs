using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Eclipse.API.QM
{
    public class SingleButton : ButtonBase
    {
        public TextMeshProUGUI text;
        public Image image;
        public Button button;

        public SingleButton(Transform parent, string buttonText, string tooltip, Action action, Sprite icon = null, bool halfButton = false, Color? buttonTextColor = null, Color? tooltipTextColor = null) =>
            InitButton(parent, buttonText, tooltip, action, icon, halfButton, buttonTextColor, tooltipTextColor);

        public SingleButton(NestedButton parent, string buttonText, string tooltip, Action action, Sprite icon = null, bool halfButton = false, Color? buttonTextColor = null, Color? tooltipTextColor = null) =>
            InitButton(parent.GetGameObject().transform, buttonText, tooltip, action, icon, halfButton, buttonTextColor, tooltipTextColor);

        public SingleButton(ButtonGroup parent, string buttonText, string tooltip, Action action, Sprite icon = null, bool halfButton = false, Color? buttonTextColor = null, Color? tooltipTextColor = null) =>
            InitButton(parent.GetGameObject().transform, buttonText, tooltip, action, icon, halfButton, buttonTextColor, tooltipTextColor);

        public SingleButton(MenuPage parent, string buttonText, string tooltip, Action action, Sprite icon = null, bool halfButton = false, Color? buttonTextColor = null, Color? tooltipTextColor = null) =>
            InitButton(parent.contentHolder.transform, buttonText, tooltip, action, icon, halfButton, buttonTextColor, tooltipTextColor);

        public void InitButton(Transform parent, string buttonText, string tooltip, Action action, Sprite icon = null, bool halfButton = false, Color? buttonTextColor = null, Color? tooltipTextColor = null)
        {
            buttonType = ButtonType.SingleButton;
            randomNumber = APIUtils.RandomNumber();
            buttonLocation = parent;

            gameObject = GameObject.Instantiate(APIUtils.SingleButtonTemplate(), buttonLocation);
            gameObject.name = $"{ButtonAPI.Identifier}-{buttonText}-{randomNumber}-SingleButton";

            image = gameObject.transform.Find("Icon").GetComponent<Image>();
            text = gameObject.transform.Find("Text_H4").GetComponent<TextMeshProUGUI>();
            button = gameObject.GetComponent<Button>();
            text.fontSize = 30;

            if (icon == null)
            {
                image.gameObject.SetActive(false);
                text.rectTransform.anchoredPosition += new Vector2(0, 50);
            }
            else
                SetIcon(icon);

            SetButtonText(buttonText);
            SetTooltip(tooltip);
            SetAction(action);

            if (buttonTextColor != null)
                SetTextColor((Color)buttonTextColor);

            SetActive(true);
            ButtonAPI.allQMSingleButtons.Add(this);
        }

        public void SetButtonText(string buttonText) =>
            text.text = buttonText;

        public void SetAction(Action buttonAction)
        {
            button.onClick = new Button.ButtonClickedEvent();
            if (buttonAction != null)
                button.onClick.AddListener(UnhollowerRuntimeLib.DelegateSupport.ConvertDelegate<UnityAction>(buttonAction));
        }

        public void Invoke()
        {
            button.GetComponent<Button>().onClick.Invoke();
        }

        public void SetIcon(Sprite icon) =>
            image.sprite = icon;
    }
}
