using Eclipse.API.QM;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Eclipse.API.SM
{
    public class SMToolBox
    {
        GameObject gameObject;
        GameObject panel;
        GameObject buttonHolder;
        GameObject actionHolder;
        Button closeButton;
        Text titleText;
        GridLayoutGroup gridLayoutGroup;
        VerticalLayoutGroup verticalLayoutGroup;

        public SMToolBox(string title, Color? btnColor = null, Color? textColor = null, Transform parent = null) // this should prob be rewritten to auto close, and be animated on open / close. (like default)
        {
            if (parent == null)
                gameObject = GameObject.Instantiate(SMAPI.GetToolBoxBase(), SMAPI.GetSM().transform);
            else
                gameObject = GameObject.Instantiate(SMAPI.GetToolBoxBase(), parent);
            gameObject.name = $"{ButtonAPI.Identifier}-Toolbox-{APIUtils.RandomNumber()}";
            gameObject.SetActive(false);
            Component.Destroy(gameObject.GetComponent<VRCUiPage>());

            panel = gameObject.transform.Find("Panel").gameObject;
            titleText = panel.transform.Find("TitleText").GetComponent<Text>();
            SetTitleText(title);

            panel.transform.Find("GeneralModerationTitleText").gameObject.SetActive(false);
            panel.transform.Find("GeneralModeration").gameObject.SetActive(false);
            panel.transform.Find("AdminModerationTitleText").gameObject.SetActive(false);
            panel.transform.Find("InstanceOwnerModerationTitleText").gameObject.SetActive(false);

            buttonHolder = panel.transform.Find("ModerateButtons").gameObject;
            buttonHolder.name = $"{ButtonAPI.Identifier}-ButtonHolder-{APIUtils.RandomNumber()}";
            verticalLayoutGroup = buttonHolder.GetComponent<VerticalLayoutGroup>();

            verticalLayoutGroup.enabled = false;
            verticalLayoutGroup.padding.top = -225;
            verticalLayoutGroup.padding.right = -35;
            verticalLayoutGroup.padding.left = 30;
            verticalLayoutGroup.enabled = true;


            actionHolder = buttonHolder.transform.Find("Actions").gameObject;


            for (int i = 0; i < actionHolder.transform.childCount; i++)
            {
                GameObject.Destroy(actionHolder.transform.GetChild(i).gameObject);
            }

            gridLayoutGroup = actionHolder.GetComponent<GridLayoutGroup>();

            gridLayoutGroup.cellSize = new Vector2(230, 100);
            gridLayoutGroup.constraintCount = 4;
            gridLayoutGroup.spacing = new Vector2(-15, -15);

            closeButton = panel.transform.Find("ExitButton").GetComponent<Button>();
            SetAction(delegate
            {
                gameObject.SetActive(false);
            });


            new SMButton(title, 0, 0, () =>
            {
                Open();
            }, true, default, btnColor, textColor);
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void SetTitleText(string title)
        {
            titleText.text = title;
        }

        public void SetAction(Action action)
        {
            closeButton.onClick = new Button.ButtonClickedEvent();
            closeButton.onClick.AddListener(action);
        }

        public SMButton AddButton(string text, Action action, Color? btnColor = null, Color? textColor = null)
        {
            return new SMButton(text, 0, 0, action, default, actionHolder, btnColor, textColor);
        }

    }
}
