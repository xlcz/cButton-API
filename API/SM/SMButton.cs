using Eclipse.API.QM;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Eclipse.API.SM
{
    public class SMButton
    {
        protected GameObject gameObject;
        protected RectTransform btnRect;
        protected Text btnText;
        protected Button btnComponent;

        public SMButton(string text, float posX, float posY, Action action, bool layoutElement = true, GameObject parent = null, Color? btnColor = null, Color? textColor = null)
        {
            if (parent == null)
                gameObject = GameObject.Instantiate(SMAPI.GetButtonBase(), SMAPI.GetButtonContainer().transform);
            else
                gameObject = GameObject.Instantiate(SMAPI.GetButtonBase(), parent.transform);
            gameObject.name = $"{ButtonAPI.Identifier}-SMButton-{APIUtils.RandomNumber()}";
            btnText = gameObject.GetComponentInChildren<Text>();
            btnComponent = gameObject.GetComponent<Button>();
            btnRect = gameObject.GetComponent<RectTransform>();

            if (!layoutElement)
                Component.Destroy(gameObject.GetComponent<LayoutElement>()); 


            SetAction(action);
            SetPosition(posX, posY);
            SetText(text);
            if (btnColor != null)
                SetButtonColor((Color)btnColor);
            if (textColor != null)
                SetButtonColor((Color)textColor);
        }

        public void SetAction(Action action)
        {
            btnComponent.onClick = new Button.ButtonClickedEvent();
            btnComponent.onClick.AddListener(action);
        }

        public void SetPosition(float posX, float posY)
        {
            btnRect.anchoredPosition = new Vector2(posX, posY);
        }

        public void SetButtonColor(Color color)
        {
            gameObject.GetComponentInChildren<Image>().color = color;
        }

        public void SetTextColor(Color color)
        {
            btnText.color = color;
        }

        public void SetText(string text)
        {
            btnText.text = text;
        }

        public void SetInteractable(bool b)
        {
            btnComponent.interactable = b;
        }
    }
}