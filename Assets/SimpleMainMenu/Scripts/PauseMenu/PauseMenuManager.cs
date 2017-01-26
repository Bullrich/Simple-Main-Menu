using UnityEngine;
using System.Collections;
using UnityEngine.UI;
// By @JavierBullrich

namespace SimpleMainMenu
{
	public class PauseMenuManager : MonoBehaviour {

        [Header("Options")]
        public string PauseTitle = "--PAUSE--";
        public string ContinueButton = "CONTINUE GAME", ExitButton = "EXIT GAME";
        [Header("Menu controlls")]
        public string pauseInputKey = "Cancel";
        public string SceneToExit = "SimpleMenuDemo";

        [Header("Menu interaction")]
        public Sprite ArrowSprite;
        public Color textColor = Color.white;
        public Color SelectedColor = Color.yellow;

        bool menuActive;
        public bool pauseTime = true;
        GameObject[] menuItems;
        Image backgroundImage;
        PauseMenuController pMenuController;
        

        private void Start()
        {
            PauseMenuController.PauseOptions options = new PauseMenuController.PauseOptions();
            options.SetUp(ContinueButton, ExitButton, SceneToExit, ArrowSprite, SelectedColor, textColor, ResumeGame);

            menuItems = new GameObject[transform.childCount];
            int i = 0;
            foreach (Transform t in transform)
            {
                if (t.GetComponent<PauseMenuController>() != null)
                {
                    pMenuController = t.GetComponent<PauseMenuController>();
                    pMenuController.SetOptions(options, SimpleMenuManager.vAxis, SimpleMenuManager.inputKey);
                }
                else if (t.GetComponent<UnityEngine.UI.Text>() != null)
                {
                    UnityEngine.UI.Text pauseTitle = t.GetComponent<UnityEngine.UI.Text>();
                    pauseTitle.color = textColor;
                    pauseTitle.text = PauseTitle;
                }
                menuItems[i] = t.gameObject;
                i++;
            }
            backgroundImage = GetComponent<Image>();
            SetMenuState(false);
        }

        private void Update()
        {
            if (Input.GetButtonDown(pauseInputKey))
            {
                SetMenuState(!menuActive);
            }
        }

        private void ResumeGame()
        {
            SetMenuState(false);
        }

        private void SetMenuState(bool menuState)
        {
            menuActive = menuState;
            foreach (GameObject m in menuItems)
                m.SetActive(menuState);
            backgroundImage.enabled = menuState;
            if (pauseTime)
                Time.timeScale = menuState ? 0 : 1;
            pMenuController.SelectOption(0);
        }

    }
}