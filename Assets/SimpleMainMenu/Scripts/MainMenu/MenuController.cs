using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
// By @JavierBullrich

namespace SimpleMainMenu
{
    public class MenuController : MonoBehaviour {
        bool inputDown, inputUp;
        List<MenuOptions> buttons;
        int currentOption;
        string verticalAxis = "Vertical", selection = "Fire1";
        public MenuOptions optionPrefab;
        Transform optionsTransform;

        public Transform getOptionsTransform()
        {
            if (optionsTransform == null)
                optionsTransform = transform.GetChild(0);
            return optionsTransform;
        }

        public void PopulateMenu(ButtonsSettings[] settings)
        {

            foreach (ButtonsSettings bSet in settings)
            {
                GameObject optionObject = Instantiate(optionPrefab.gameObject);
                optionObject.transform.SetParent(getOptionsTransform(), false);
                optionObject.GetComponent<MenuOptions>().SetButton(bSet);
            }

            buttons = GetChildInOrder(getOptionsTransform());
            buttons[currentOption].Selection(true);
        }

        /// <summary>Get all the childs of a transform and returns them in a list in order by hierarchy</summary>
        private List<MenuOptions> GetChildInOrder(Transform _tran)
        {
            int childs = _tran.childCount;
            List<MenuOptions> options = new List<MenuOptions>();

            for (int i = 0; i < childs; i++)
            {
                options.Add(_tran.GetChild(i).GetComponent<MenuOptions>());
            }

            return options;
        }

        private void Update()
        {
            if (buttons != null)
                SelectionManager();
        }

        void SelectionManager()
        {
            if (Input.GetAxisRaw(verticalAxis) > -0.2f && inputDown)
                inputDown = false;
            else if (Input.GetAxisRaw(verticalAxis) < -0.9f && !inputDown)
            {
                inputDown = true;
                MoveOption(1);
            }
            else if (Input.GetAxisRaw(verticalAxis) < 0.2f && inputUp)
                inputUp = false;
            else if (Input.GetAxisRaw(verticalAxis) > 0.9f && !inputUp)
            {
                inputUp = true;
                MoveOption(-1);
            }

            if (Input.GetButtonDown(selection))
                buttons[currentOption].ExecuteButton();
        }

        void MoveOption(int newOption)
        {
            buttons[currentOption].Selection(false);

            currentOption = currentOption + newOption;

            if (currentOption < 0)
                currentOption = buttons.Count - 1;
            else if (currentOption > buttons.Count - 1)
                currentOption = 0;
            
            buttons[currentOption].Selection(true);

            if (buttons.Count > 4)
                ShowInTabControl();
        }

        public ScrollRect scroll;

        void ShowInTabControl()
        {
            float normalizePosition = (float)buttons[currentOption].transform.GetSiblingIndex() / (float)scroll.content.transform.childCount;
            scroll.verticalNormalizedPosition = 1 - normalizePosition;
        }

    }
}