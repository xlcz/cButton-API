using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Elements;

namespace Eclipse.API.QM
{
    public class FoldoutHeader : ButtonBase
    {
        public FoldoutHeader(Transform parent, string title) =>
            InitHeader(parent, title);

        public FoldoutHeader(MenuPage parent, string title) =>
            InitHeader(parent.contentHolder.transform, title);

        public TextMeshProUGUI text;
        public QMFoldout qmFoldout;

        public Action<bool> onToggle;

        public void InitHeader(Transform parent, string title, bool defaultState = true)
        {
            buttonType = ButtonType.FoldoutHeader;
            randomNumber = APIUtils.RandomNumber();
            buttonLocation = parent;

            gameObject = GameObject.Instantiate(APIUtils.GetFoldoutTemplate(), parent.transform);
            gameObject.name = $"{ButtonAPI.Identifier}-{title}-{randomNumber}-CollapsableHeader";

            qmFoldout = gameObject.GetComponent<QMFoldout>();
            qmFoldout.field_Private_String_0 = $"{randomNumber}.{ButtonAPI.Identifier}.{title}";
            qmFoldout.field_Private_Action_1_Boolean_0 = new Action<bool>(b => onToggle?.Invoke(b));
            ToggleState(defaultState);

            text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
            SetTitle(title);

            ButtonAPI.allQMFoldoutHeaderPages.Add(this);
        }

        public void ToggleState(bool state)
        {
            qmFoldout.Method_Private_Void_Boolean_0(state);
        }

        public void SetTitle(string title) =>
            text.text = $"<b>{title}</b>";

        public ButtonGroup AddButtonGroup()
        {
            var btn = new ButtonGroup(buttonLocation);
            onToggle += b => btn!.GetGameObject().SetActive(b);
            return btn;
        }

        public QMSlider AddSlider(string text, string tooltip, Action<float> onAdjust, float minValue = 0f, float maxValue = 100f, float defaultValue = 50f, bool wholeNumber = true)
        {
            var slider = new QMSlider(buttonLocation, text, tooltip, onAdjust, minValue, maxValue, defaultValue, wholeNumber);
            onToggle += b => slider!.GetGameObject().SetActive(b);
            return slider;
        }
    }
}
