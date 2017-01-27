using UnityEngine;
using System.Collections.Generic;
// By @JavierBullrich
namespace SimpleMainMenu
{
    public class SimpleMenuManager : MonoBehaviour
    {
        [Header("Title Text")]
        public string GameName;
        public string CopyrightText;
        public Color textColor = Color.white;
        public Font textFont;
        [Header("Menu Controlls")]
        public string InputName = "Fire1";
        public string VerticalAxisName = "Vertical", ReturnKey = "Fire3";
        public static string inputKey = "Fire1", vAxis = "Vertical", returnKey = "Fire3";
        [Header("Menu interaction")]
        public Sprite ArrowSprite;
        public Color SelectedColor = Color.yellow;
        
        [Header("Buttons options")]
        public bool canBeClicked = true;
        [SerializeField]
        public ButtonsSettings[] buttons;
        MenuController mController;
        IntroScreen intro;
        List<InformationText> infoTxt = new List<InformationText>();

        public void Awake()
        {
            GetControllers();
            foreach(ButtonsSettings b in buttons)
            {
                b.selectedColor = SelectedColor;
                b.selectedSprite = ArrowSprite;
                b.canClick = canBeClicked;
                b.textFont = textFont;
            }
            mController.PopulateMenu(buttons);
            inputKey = InputName;
            vAxis = VerticalAxisName;
            IntroStatus(true);
            Cursor.visible = canBeClicked;
        }

        public void IntroStatus(bool activeIntro)
        {
            mController.transform.gameObject.SetActive(!activeIntro);
            foreach(InformationText txt in infoTxt)
            {
                txt.transform.gameObject.SetActive(!activeIntro);
            }
            intro.transform.gameObject.SetActive(activeIntro);
        }

        void GetControllers()
        {
            foreach(Transform t in transform)
            {
                if (t.GetComponent<MenuController>())
                    mController = t.GetComponent<MenuController>();
                else if (t.GetComponent<InformationText>())
                {
                    infoTxt.Add(t.GetComponent<InformationText>());
                    SetTitleText(t.GetComponent<InformationText>());
                }
                else if (t.GetComponent<IntroScreen>())
                {
                    intro = t.GetComponent<IntroScreen>();
                    intro.SetUp(this);
                }
            }
        }

        private void SetTitleText(InformationText infoText)
        {
            string infoString = "";
            switch (infoText.InfoType)
            {
                case InformationText.typeOfText.Title:
                    infoString = GameName;
                    break;
                case InformationText.typeOfText.Copyright:
                    infoString = CopyrightText;
                    break;
                case InformationText.typeOfText.Version:
                    // You can change the version text to whatever string you want.
                    infoString = VersionText();
                    break;
                default:
                    break;
            }
            infoText.SetText(infoString, textColor, textFont);
        }

        string VersionText()
        {
            string version = "Version " + Application.version;
            return version;
        }
    }
}