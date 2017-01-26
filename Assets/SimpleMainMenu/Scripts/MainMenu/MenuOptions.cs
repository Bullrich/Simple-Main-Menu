using UnityEngine;
using System.Collections;
using UnityEngine.UI;
// By @JavierBullrich

namespace SimpleMainMenu
{
	public class MenuOptions : MonoBehaviour {
        Text optionText;
        Button optionButton;
        Color bColor = Color.white, sColor = Color.yellow;
        Image arrowImage;
        Sprite selectedImage;

        public void SetButton(ButtonsSettings settings)
        {
            getOptionText().text = settings.buttonText;
            arrowImage = transform.GetChild(0).GetComponent<Image>();
            selectedImage = settings.selectedSprite;
            arrowImage.enabled = false;
            bColor = settings.buttonColor;
            getOptionText().color = bColor;
            sColor = settings.selectedColor;
            getOptionText().font = settings.textFont;
            switch (settings.buttonType)
            {
                case ButtonsSettings.ButtonType.LoadLevel:
                    getOptionButton().onClick.AddListener(delegate () { settings.LoadGame(); });
                    break;
                case ButtonsSettings.ButtonType.Options:
                    break;
                case ButtonsSettings.ButtonType.Quit:
                    getOptionButton().onClick.AddListener(delegate () { settings.QuitGame(); });
                    break;
                case ButtonsSettings.ButtonType.Custom:
                    System.Type component = settings.custom.GetType();
                    gameObject.AddComponent(component);
                    settings.custom.GiveText(GetComponent<Text>());
                    getOptionButton().onClick.AddListener(delegate () { settings.custom.OnClickAction(); });
                    break;
                default:
                    break;
            }
            getOptionButton().enabled = settings.canClick;
        }

        public void ExecuteButton()
        {
            getOptionButton().onClick.Invoke();
        }

        private Text getOptionText()
        {
            if (optionText == null)
                optionText = GetComponent<Text>();
            return optionText;
        }

        private Button getOptionButton()
        {
            if(optionButton==null)
            optionButton = GetComponent<Button>();
            return optionButton;
        }

        public void Selection(bool isSelected)
        {
            arrowImage.enabled = false;
            if (isSelected)
            {
                if (selectedImage != null)
                {
                    arrowImage.enabled = true;
                    arrowImage.sprite = selectedImage;
                }
                else
                    getOptionText().color = sColor;
            }
            else
                getOptionText().color = bColor;
        }

    }
}