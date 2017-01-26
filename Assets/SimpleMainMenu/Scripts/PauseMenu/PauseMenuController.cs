using UnityEngine;
using System.Collections;
using System.Collections.Generic;
// By @JavierBullrich

namespace SimpleMainMenu
{
	public class PauseMenuController : MonoBehaviour {

        List<PauseMenuOption> pauseOptions;
        bool inputDown, inputUp;
        string verticalAxis, selection;
        int currentOption;

        private void GetOptions()
        {
            pauseOptions = new List<PauseMenuOption>();
                pauseOptions = GetChildInOrder(transform);
        }

        private List<PauseMenuOption> GetChildInOrder(Transform _tran)
        {
            int childs = _tran.childCount;
            List<PauseMenuOption> options = new List<PauseMenuOption>();

            for (int i = 0; i < childs; i++)
            {
                options.Add(_tran.GetChild(i).GetComponent<PauseMenuOption>());
            }

            return options;
        }

        public void SelectOption(int index)
        {
            pauseOptions[currentOption].Selection(false);

            pauseOptions[index].Selection(true);
            currentOption = index;
        }

        public void SetOptions(PauseOptions options, string axis, string select)
        {
            GetOptions();
            verticalAxis = axis;
            selection = select;
            foreach(PauseMenuOption opt in pauseOptions)
            {
                opt.SetButton(options);
            }
            pauseOptions[currentOption].Selection(true);
        }

        public struct PauseOptions
        {
            public string continueText, pauseText;
            public string exitScene;
            public Sprite selectedImage;
            public Color sColor, bColor;
            public delegate void unPause();
            public unPause unpause;

            public void SetUp(string cont, string pause, string exitscene, Sprite arrowSprite, Color selectedColor, Color baseColor, unPause resumeGame)
            {
                continueText = cont;
                pauseText = pause;
                unpause = resumeGame;
                exitScene = exitscene;
                selectedImage = arrowSprite;
                sColor = selectedColor;
                bColor = baseColor;
            }
        }

        private void Update()
        {
            if (pauseOptions != null)
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
                pauseOptions[currentOption].ExecuteButton();
        }

        void MoveOption(int newOption)
        {
            pauseOptions[currentOption].Selection(false);

            currentOption = currentOption + newOption;

            if (currentOption < 0)
                currentOption = pauseOptions.Count - 1;
            else if (currentOption > pauseOptions.Count - 1)
                currentOption = 0;
            print(currentOption);

            pauseOptions[currentOption].Selection(true);
        }

    }
}