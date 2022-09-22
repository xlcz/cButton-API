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
    public class ButtonBase
    {
        public GameObject gameObject;
        public int randomNumber;
        public Enum buttonType;
        public Transform buttonLocation;

        protected int[] initShift = { 0, 0 };

        public GameObject GetGameObject()
        {
            return gameObject;
        }

        public void SetActive(bool active) =>
            gameObject.SetActive(active);

        public void SetTooltip(string text)
        {
            gameObject.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = text;
            gameObject.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_1 = text;
        }

        public void Destroy()
        {
            GameObject.Destroy(gameObject);
        }

        public void SetTextColor(Color buttonTextColor)
        {
            Component.Destroy(gameObject.transform.Find("Text_H4").GetComponent<StyleElement>());
            gameObject.transform.Find("Text_H4").GetComponent<TextMeshProUGUI>().color = buttonTextColor;
        }

        public void SetTooltipColor(string tooltipColor)
        {
            var cachedOne = gameObject.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0;
            var cachedTwo = gameObject.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_1;
            gameObject.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = $"<color={tooltipColor}>{cachedOne}</color>";
            gameObject.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_1 = $"<color={tooltipColor}>{cachedTwo}</color>";
        }
    }
}
