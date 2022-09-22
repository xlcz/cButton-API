using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Core.Styles;

namespace Eclipse.API.QM
{
    public class InfoMenu : ButtonBase
    {
        public RectTransform rectTransform;
        public TextMeshProUGUI tmp;
        public InfoMenu(Transform parent, Vector2 position, Vector2 sizeDelta, Sprite sprite = null, bool bgEnabled = false, string text = "", bool enableText = false)
        {
            buttonType = ButtonType.InfoMenu;
            randomNumber = APIUtils.RandomNumber();

            gameObject = GameObject.Instantiate(APIUtils.SingleButtonTemplate(), parent);
            gameObject.name = $"{ButtonAPI.Identifier}-{text}-{randomNumber}-InfoMenu";
            GameObject.Destroy(gameObject.transform.Find("Icon").gameObject);
            GameObject.Destroy(gameObject.transform.Find("Badge_MMJump").gameObject);
            Component.Destroy(gameObject.GetComponent<Button>());
            Component.Destroy(gameObject.GetComponent<StyleElement>());
            Component.Destroy(gameObject.GetComponent<UiTooltip>());
            if (sprite != null && bgEnabled)
                gameObject.transform.Find("Background").GetComponent<Image>().sprite = sprite;

            if (!bgEnabled)
                gameObject.transform.Find("Background").GetComponent<Image>().enabled = false;

            rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = position;
            rectTransform.sizeDelta = sizeDelta;

            if (enableText)
                tmp = gameObject.transform.Find("Text_H4").GetComponent<TextMeshProUGUI>();
            else
                GameObject.Destroy(gameObject.transform.Find("Text_H4").gameObject);



            ButtonAPI.allInfoMenus.Add(this);
        }
    }
}