using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Eclipse.API.QM
{
    public class ButtonGroup : ButtonBase
    {
        public ButtonGroup(Transform parent) =>
            InitGroup(parent);

        public ButtonGroup(MenuPage parent) =>
            InitGroup(parent.contentHolder.transform);
        public ButtonGroup(NestedButton parent) =>
            InitGroup(parent.menuPage.contentHolder.transform);


        public void InitGroup(Transform parent)
        {
            buttonType = ButtonType.Header;
            randomNumber = APIUtils.RandomNumber();
            buttonLocation = parent;

            gameObject = GameObject.Instantiate(APIUtils.GetButtonGroupTemplate(), parent.transform);
            gameObject.name = $"{ButtonAPI.Identifier}-{buttonLocation.name}-{randomNumber}-ButtonGroup";

            gameObject.transform.DestroyChildren();

            ButtonAPI.allQMButtonGroups.Add(this);
        }
    }
}
