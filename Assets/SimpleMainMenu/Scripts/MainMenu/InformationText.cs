using UnityEngine;
using UnityEngine.UI;
// By @JavierBullrich

namespace SimpleMainMenu
{
	public class InformationText : MonoBehaviour {
        Text infoText;
        public enum typeOfText
        {
            Title,
            Copyright,
            Version
        }
        public typeOfText InfoType;
		
        public void SetText(string text, Color textColor, Font ffont)
        {
            infoText = GetComponent<Text>();
            infoText.text = text;
            infoText.color = textColor;
            infoText.font = ffont;
        }

	}
}