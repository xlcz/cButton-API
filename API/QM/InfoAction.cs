using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Core.Styles;

namespace Eclipse.API.QM
{
    public class InfoAction : ButtonBase
    {
        public SingleButton baseButton;
        public RectTransform rectTransform;
        public readonly GameObject iconObject;
        public InfoAction(Transform parent, Vector2 position, Vector2 sizeDelta, string tooltip, Action action, Sprite sprite = null, bool bgEnabled = false, string text = "")
        {
            buttonType = ButtonType.InfoAction;
            randomNumber = APIUtils.RandomNumber();

            baseButton = new SingleButton(parent, text, tooltip, action, sprite);
            gameObject = baseButton.gameObject;
            gameObject.name = $"{ButtonAPI.Identifier}-{text}-{randomNumber}-InfoAction";
            iconObject = gameObject.transform.Find("Icon").gameObject;

            Component.Destroy(gameObject.GetComponent<LayoutElement>());

            baseButton.SetAction(action);

            if (sprite != null && bgEnabled)
                gameObject.transform.Find("Background").GetComponent<Image>().sprite = sprite;

            if (!bgEnabled)
                gameObject.transform.Find("Background").GetComponent<Image>().enabled = false;

            rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = position;
            rectTransform.sizeDelta = sizeDelta;

            if (text == "") GameObject.Destroy(gameObject.transform.Find("Text_H4").gameObject);
            ButtonAPI.allInfoActions.Add(this);
        }
    }
}