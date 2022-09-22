using Eclipse.API.QM;
using UnityEngine;
using UnityEngine.UI;

namespace Eclipse.API.SM
{
    public class SMLabel
    {
        protected GameObject gameObject;
        protected Text labelText;
        protected RectTransform labelRect;


        public SMLabel(string text, float posX, float posY, Color? textColor = null)
        {
            gameObject = GameObject.Instantiate(SMAPI.GetLabelBase(), SMAPI.GetSM().transform);
            gameObject.name = $"{ButtonAPI.Identifier}-SMLabel-{APIUtils.RandomNumber()}";
            labelText = gameObject.GetComponent<Text>();
            labelRect = gameObject.GetComponent<RectTransform>();

            SetLabelText(text);
            SetPosition(posX, posY);

            if (textColor != null)
                SetLabelColor((Color)textColor);
        }

        public void SetLabelText(string text)
        {
            labelText.text = text;
        }

        public void SetLabelColor(Color textColor)
        {
            labelText.color = textColor;
        }

        public void SetPosition(float posX, float posY)
        {
            labelRect.anchoredPosition = new Vector2(posX, posY);
        }
    }
}