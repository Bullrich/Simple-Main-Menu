using UnityEngine;
using System.Collections;
// By @JavierBullrich

namespace SimpleMainMenu
{
	public class IntroScreen : MonoBehaviour {
        SimpleMenuManager menuManager;

        public void SetUp(SimpleMenuManager menu)
        {
            menuManager = menu;
        }

        public void Update()
        {
            if (Input.anyKeyDown)
            {
                menuManager.IntroStatus(false);
            }
        }

    }
}