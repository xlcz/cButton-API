using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Eclipse.API.QM;
using Object = UnityEngine.Object;

namespace Eclipse.API.HUD
{
    public class HUDIcon
    {
        public static List<GameObject> hudIconList = new();
        public static int hudIconCount = 0;

        public GameObject gameObject;
        public RectTransform rectTransform;
        public Image image;
        public HUDIcon(Sprite icon, Color? color = null)
        {
            gameObject = Object.Instantiate(HUDAPI.GetBaseHUDIcon(), HUDAPI.GetHUDIconParent());
            gameObject.name = $"{ButtonAPI.Identifier}-HUDIcon-{APIUtils.RandomNumber()}";
            Component.Destroy(gameObject.GetComponent<FadeCycleEffect>());
            image = gameObject.GetComponent<Image>();
            SetIcon(icon);
            if (color != null)
                SetColor((Color)color);

            image.enabled = true;

            gameObject.active = false;
            
            rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(125, 125);
            rectTransform.anchoredPosition = new Vector2(175 * hudIconCount, 0);

            hudIconCount++;
            hudIconList.Add(gameObject);
        }

        public void SetIcon(Sprite icon) =>
            image.sprite = icon;

        public void SetColor(Color color) =>
            image.color = color;

        public void Toggle(bool toggle)
        {
            gameObject.active = toggle;
            Reposition();
        }

        public void Reposition()
        {
            hudIconCount = 0;
            foreach (GameObject go in hudIconList)
            {
                if (go.active)
                {
                    go.GetComponent<RectTransform>().anchoredPosition = new Vector2(175 * hudIconCount, 800);
                    hudIconCount++;
                }
            }
        }
    }
}
