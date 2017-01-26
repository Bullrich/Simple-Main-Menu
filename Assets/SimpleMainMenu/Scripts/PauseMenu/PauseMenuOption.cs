using UnityEngine;
using System.Collections;
using UnityEngine.UI;
// By @JavierBullrich

namespace SimpleMainMenu
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(Text))]
    public class PauseMenuOption : MonoBehaviour {
        Button optionButton;
        Text optionText;
        Image arrowImage;
        Sprite selectedImage;
        Color sColor, bColor;
        string sceneToChange;

        public void SetButton(PauseMenuController.PauseOptions options)
        {
            if (type == ButtonType.Continue)
            {
                getOptionText().text = options.continueText;
                getOptionButton().onClick.AddListener(delegate () { options.unpause(); });
            }
            else if (type == ButtonType.Exit)
            {
                getOptionText().text = options.pauseText;
                sceneToChange = options.exitScene;
                getOptionButton().onClick.AddListener(delegate () { ChangeScene(); });
            }
            selectedImage = options.selectedImage;
            sColor = options.sColor;
            bColor = options.bColor;
            getArrowImage().enabled = false;
        }

        private void ChangeScene()
        {
            print(sceneToChange);
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToChange);
        }

        public void ExecuteButton()
        {
            getOptionButton().onClick.Invoke();
        }

        public void Selection(bool isSelected)
        {
            arrowImage.enabled = false;
            if (isSelected)
            {
                if (selectedImage != null)
                {
                    getArrowImage().enabled = true;
                    getArrowImage().sprite = selectedImage;
                }
                else
                    getOptionText().color = sColor;
            }
            else
                getOptionText().color = bColor;
        }

        public enum ButtonType
        {
            Continue,
            Exit
        }
        public ButtonType type;

        #region Getters
        private Text getOptionText()
        {
            if (optionText == null)
                optionText = GetComponent<Text>();
            return optionText;
        }

        private Button getOptionButton()
        {
            if (optionButton == null)
                optionButton = GetComponent<Button>();
            return optionButton;
        }

        private Image getArrowImage()
        {
            if (arrowImage == null)
                arrowImage = transform.GetChild(0).GetComponent<Image>();
            return arrowImage;
        }
        #endregion


        
    }
}