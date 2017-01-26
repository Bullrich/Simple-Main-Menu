using UnityEngine;
using System.Collections;
// By @JavierBullrich

namespace SimpleMainMenu
{
	public class ExampleButton : CustomButton {
        string exampleString = "Example: ";
        int exampleInt = 0;
        public override void OnClickAction()
        {
            exampleInt++;
            buttonText.text = exampleString + exampleInt;
        }

    }
}