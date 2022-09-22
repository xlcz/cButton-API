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
    public class Header : ButtonBase
    {
        public Header(Transform parent, string title) =>
            InitHeader(parent, title);

        public Header(MenuPage parent, string title) =>
            InitHeader(parent.contentHolder.transform, title);

        public TextMeshProUGUI text;

        public void InitHeader(Transform parent, string title)
        {
            buttonType = ButtonType.Header;
            randomNumber = APIUtils.RandomNumber();
            buttonLocation = parent;

            gameObject = GameObject.Instantiate(APIUtils.GetHeaderTemplate(), parent.transform);
            gameObject.name = $"{ButtonAPI.Identifier}-{title}-{randomNumber}-Header";
            text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
            SetTitle(title);

            text.transform.parent.GetComponent<HorizontalLayoutGroup>().childControlWidth = true;

            ButtonAPI.allQMHeaderPages.Add(this);
        }

        public void SetTitle(string title) =>
            text.text = title;
    }
}
