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
    public class QMSlider : ButtonBase // named it QMSlider so it doesnt get confused with GUI.Slider
    {
        public TextMeshProUGUI sliderText;
        public TextMeshProUGUI sliderAmountText;
        public UnityEngine.UI.Slider sliderComponent;

        public VRC.UI.Elements.Tooltips.UiTooltip sliderTooltip;

        public QMSlider(Transform parent, string text, string tooltip, Action<float> onAdjust, float minValue = 0f, float maxValue = 100f, float defaultValue = 50f, bool wholeNumbers = true) =>
            Initialize(parent, text, tooltip, onAdjust, minValue, maxValue, defaultValue, wholeNumbers); 
        public QMSlider(MenuPage parent, string text, string tooltip, Action<float> onAdjust, float minValue = 0f, float maxValue = 100f, float defaultValue = 50f, bool wholeNumbers = true) =>
            Initialize(parent.contentHolder.transform, text, tooltip, onAdjust, minValue, maxValue, defaultValue, wholeNumbers); 
        public QMSlider(ButtonGroup parent, string text, string tooltip, Action<float> onAdjust, float minValue = 0f, float maxValue = 100f, float defaultValue = 50f, bool wholeNumbers = true) =>
            Initialize(parent.GetGameObject().transform, text, tooltip, onAdjust, minValue, maxValue, defaultValue, wholeNumbers);

        public void Initialize(Transform parent, string text, string tooltip, Action<float> onAdjust, float minValue = 0f, float maxValue = 100f, float defaultValue = 50f, bool wholeNumbers = true)
        {
            buttonType = ButtonType.Slider;
            randomNumber = APIUtils.RandomNumber();
            buttonLocation = parent;

            var parentObject = GameObject.Instantiate<GameObject>(new GameObject(), parent.transform); // ty Xavi#2469 for this fix (prevents something that i forgot about)
            parentObject.name = $"{ButtonAPI.Identifier}-SliderHolder-{randomNumber}";
            parentObject.layer = LayerMask.NameToLayer("InternalUI");
            parentObject.AddComponent<RectTransform>();
            var vlg = parentObject.AddComponent<VerticalLayoutGroup>();
            vlg.childControlHeight = false;
            vlg.childForceExpandHeight = false;
            vlg.padding.top = 20;
            vlg.padding.bottom = 20;
            vlg.padding.left = 64;
            vlg.padding.right = 64;

            gameObject = GameObject.Instantiate(APIUtils.GetSliderTemplate(), parentObject.transform);
            gameObject.name = $"{ButtonAPI.Identifier}-{text}-{randomNumber}-Slider";
            gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(900, 100);

            Component.DestroyImmediate(gameObject.GetComponent<UIInvisibleGraphic>());

            gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = text;
            sliderAmountText = gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            sliderAmountText.text = "_";
            sliderAmountText.color = Color.white;

            sliderComponent = gameObject.GetComponentInChildren<Slider>();
            sliderComponent.onValueChanged = new Slider.SliderEvent();
            sliderComponent.onValueChanged.AddListener(new Action<float>(onAdjust));
            sliderComponent.onValueChanged.AddListener(new Action<float>(val =>
            {
                sliderAmountText.text = (val).ToString();
            }));
            sliderComponent.minValue = minValue;
            sliderComponent.maxValue = maxValue;
            sliderComponent.value = defaultValue;
            if (wholeNumbers)
                sliderComponent.wholeNumbers = true;

            gameObject.GetComponentInChildren<VRC.UI.Elements.Tooltips.UiTooltip>(true).field_Public_String_0 = tooltip;

            sliderComponent.Set(defaultValue, false);

    

            var objectHandler = sliderAmountText.gameObject.AddComponent<ObjectHandler>();

            objectHandler.OnEnabled += (obj) =>
            {
                sliderAmountText.text = sliderComponent.value.ToString();
            };

            ButtonAPI.allQMSliders.Add(this);
        }

        public void SetAction(Action<float> newAction)
        {
            sliderComponent.onValueChanged = new UnityEngine.UI.Slider.SliderEvent();
            sliderComponent.onValueChanged.AddListener((Action<float>)delegate (float val)
            {
                sliderAmountText.text = Math.Floor(val).ToString();
                newAction(val);
            });
        }

        public void SetText(string newText)
        {
            sliderText.text = $"<b>{newText}</b>";
        }

        public void SetInteractable(bool val)
        {
            sliderComponent.interactable = val;
        }

        public void SetValue(float newValue, bool invoke = false)
        {
            sliderAmountText.text = Math.Floor(newValue).ToString();

            var onValueChanged = sliderComponent.onValueChanged;
            sliderComponent.onValueChanged = new UnityEngine.UI.Slider.SliderEvent();
            sliderComponent.value = newValue;
            sliderComponent.onValueChanged = onValueChanged;
            if (invoke)
            {
                sliderComponent.onValueChanged.Invoke(newValue);
            }
        }
    }
}
