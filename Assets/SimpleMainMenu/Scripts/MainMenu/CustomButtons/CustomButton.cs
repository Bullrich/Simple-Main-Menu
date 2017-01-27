using UnityEngine;
using UnityEngine.UI;
//By @JavierBullrich

namespace SimpleMainMenu
{
	public abstract class CustomButton : MonoBehaviour {
        protected Text buttonText;

        public abstract void OnClickAction();

        public void GiveText(Text txt)
        {
            buttonText = txt;
        }
	}
}