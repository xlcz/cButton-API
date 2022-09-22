using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Eclipse.API.QM
{
    public class ScrollMenu
    {
        public NestedButton nestedButton;
        public MenuPage menuPage;
        private Action<ScrollMenu> action;
        public List<ScrollObject> allButtons = new();

        public int currentIndex = 0;

        public ScrollMenu(NestedButton nestedMenu)
        {
            nestedButton = nestedMenu;
            menuPage = nestedButton.menuPage;
        }

        public void SetAction(Action<ScrollMenu> open)
        {
            action = open;
            nestedButton.singleButton.GetGameObject().GetComponent<Button>().onClick.AddListener(UnhollowerRuntimeLib.DelegateSupport.ConvertDelegate<UnityAction>(new Action(delegate
            {
                Clear();
                action(this);
            })));
        }

        public void Add(ButtonBase button)
        {
            allButtons.Add(new ScrollObject
            {
                buttonBase = button
            });
        }

        public void Clear()
        {
            foreach (var obj in allButtons) GameObject.Destroy(obj.buttonBase.GetGameObject());
            allButtons.Clear();
            currentIndex = 0;
        }
    }

    public class ScrollObject
    {
        public ButtonBase buttonBase;
    }
}
