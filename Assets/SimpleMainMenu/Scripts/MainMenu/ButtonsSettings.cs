using UnityEngine;
using System.Collections;
// By @JavierBullrich

namespace SimpleMainMenu
{
    [System.Serializable]
	public class ButtonsSettings {

        public enum ButtonType
        {
            LoadLevel,
            Options,
            Quit,
            Custom
        }

        public string buttonText = "Start";

        public ButtonType buttonType;

        public string levelName;

        public CustomButton custom;

        public Color buttonColor = Color.white;
        [HideInInspector]
        public Color selectedColor;
        [HideInInspector]
        public Sprite selectedSprite;
        [HideInInspector]
        public bool canClick;
        [HideInInspector]
        public Font textFont;

        public void QuitGame()
        {
            Application.Quit();
        }

        public void LoadGame()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
        }
		
	}
}