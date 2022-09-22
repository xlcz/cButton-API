using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

using Eclipse.API.QM;
using Eclipse.Utils.Objects;
using Eclipse.GUI.SM;
using Eclipse.Utils;
using System.Linq;

namespace Eclipse.API.SM
{
    public class AvatarList
    {
        public GameObject gameObject;
        public Transform content;
        public Text titleText;
        public UiAvatarList uiAvatarList;

        public List<string> FavoriteIds { get; } = new();

        public AvatarList(string title)
        {
            gameObject = Object.Instantiate(SMAPI.GetAvatarListBase(), SMAPI.GetAvatarPageParent().transform);
            gameObject.name = $"{ButtonAPI.Identifier}-AvatarList-{APIUtils.RandomNumber()}";

            uiAvatarList = gameObject.GetComponent<UiAvatarList>();
            uiAvatarList.clearUnseenListOnCollapse = false;

            uiAvatarList.field_Public_Category_0 = UiAvatarList.Category.SpecificList;
            uiAvatarList.StopAllCoroutines();

            content = gameObject.transform.Find("ViewPort").Find("Content");

            titleText = gameObject.transform.Find("Button").GetComponentInChildren<Text>();
            titleText.text = title;

            GameObject.Destroy(gameObject.transform.Find("GetMoreFavorites"));
        }

        public void AddAvatar(AvatarObject avatar)
        {
            new AvatarButton(this, avatar);
            FavoriteIds.Add(avatar.AvatarId);

            Refresh(FavoriteIds);
        }

        public void Refresh(List<string> ids)
        {
            uiAvatarList.field_Private_Dictionary_2_String_ApiAvatar_0.Clear();
            foreach (var (id, index) in ids.Select((id, index) => (id, index)))
            {
                if (index > 0 && !id.Equals(ids[index - 1]))
                    ConsoleUtils.Log(id);
            }
        }
    }
}
