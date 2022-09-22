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
    public class ToggleButton : ButtonBase
    {
        public TextMeshProUGUI text;
        public Button button;
        public Image image;
        public bool currentState;
        public Action OnAction;
        public Action OffAction;

        public ToggleButton(Transform parent, string buttonText, string tooltip, Action onAction, Action offAction, bool defaultState, Color? buttonTextColor = null, Color? tooltipTextColor = null) =>
            InitToggleButton(parent, buttonText, tooltip, onAction, offAction, defaultState, buttonTextColor);

        public ToggleButton(NestedButton parent, string buttonText, string tooltip, Action onAction, Action offAction, bool defaultState, Color? buttonTextColor = null, Color? tooltipTextColor = null) =>
            InitToggleButton(parent.GetGameObject().transform, buttonText, tooltip, onAction, offAction, defaultState, buttonTextColor);
        public ToggleButton(ButtonGroup parent, string buttonText, string tooltip, Action onAction, Action offAction, bool defaultState, Color? buttonTextColor = null, Color? tooltipTextColor = null) =>
            InitToggleButton(parent.GetGameObject().transform, buttonText, tooltip, onAction, offAction, defaultState, buttonTextColor);
        public ToggleButton(MenuPage parent, string buttonText, string tooltip, Action onAction, Action offAction, bool defaultState, Color? buttonTextColor = null, Color? tooltipTextColor = null) =>
            InitToggleButton(parent.contentHolder.transform, buttonText, tooltip, onAction, offAction, defaultState, buttonTextColor);

        private void InitToggleButton(Transform parent, string buttonText, string tooltip, Action onAction, Action offAction, bool defaultState, Color? buttonTextColor = null, Color? tooltipTextColor = null)
        {
            buttonType = ButtonType.ToggleButton;
            randomNumber = APIUtils.RandomNumber();

            gameObject = GameObject.Instantiate(APIUtils.SingleButtonTemplate(), parent);
            gameObject.name = $"{ButtonAPI.Identifier}-{buttonText}-{randomNumber}-ToggleButton";
            image = gameObject.transform.Find("Icon").GetComponent<Image>();
            text = gameObject.transform.Find("Text_H4").GetComponent<TextMeshProUGUI>();
            button = gameObject.GetComponent<Button>();
            button.onClick = new Button.ButtonClickedEvent();
            button.onClick.AddListener(new Action(HandleClick));
            text.fontSize = 24;

            SetButtonText(buttonText);
            SetTooltip(tooltip);
            SetActions(onAction, offAction);

            if (buttonTextColor != null)
                SetTextColor((Color)buttonTextColor);

            SetActive(true);


            currentState = defaultState;
            var tmpIcon = currentState ? APIUtils.GetOnIconSprite() : APIUtils.GetOffIconSprite();
            image.sprite = tmpIcon;
            image.overrideSprite = tmpIcon;

            ButtonAPI.allQMToggleButtons.Add(this);
        }

        public void SetButtonText(string buttonText) =>
            text.text = buttonText;

        public void SetActions(Action onAction, Action offAction)
        {
            OnAction = onAction;
            OffAction = offAction;
        }

        private void HandleClick()
        {
            currentState = !currentState;
            var stateIcon = currentState ? APIUtils.GetOnIconSprite() : APIUtils.GetOffIconSprite();
            image.sprite = stateIcon;
            image.overrideSprite = stateIcon;
            if (currentState)
            {
                OnAction.Invoke();
            }
            else
            {
                OffAction.Invoke();
            }
        }

        public void SetToggleState(bool newState, bool shouldInvoke = false)
        {
            try
            {
                var newIcon = newState ? APIUtils.GetOnIconSprite() : APIUtils.GetOffIconSprite();
                image.sprite = newIcon;
                image.overrideSprite = newIcon;
                currentState = newState;

                if (shouldInvoke)
                {
                    if (newState)
                        OnAction.Invoke();
                    else
                        OffAction.Invoke();
                }
            }
            catch { }
        }

    }
}
