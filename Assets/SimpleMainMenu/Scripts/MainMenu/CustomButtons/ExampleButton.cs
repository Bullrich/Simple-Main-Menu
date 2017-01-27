// By @JavierBullrich

namespace SimpleMainMenu
{
	public class ExampleButton : SimpleMainMenu.CustomButton
    {
        int exampleInt = 0;
        public override void OnClickAction()
        {
            exampleInt++;
            buttonText.text = "Example: " + exampleInt;
        }
    }
}