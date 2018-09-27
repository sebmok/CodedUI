using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Input;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UITesting.DirectUIControls;
using Microsoft.VisualStudio.TestTools.UITesting.WindowsRuntimeControls;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;


namespace CodedUITestProject1
{
    /// <summary>
    /// Opis podsumowujący elementu CodedUITest1
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class CodedUITest1
    {
        public CodedUITest1()
        {
        }

        [TestMethod]
        public void addTwoNumbersAndVerifyResult()
        {
            XamlWindow appWindow = XamlWindow.Launch("Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
            XamlButton button9 = new XamlButton(appWindow);
            button9.SearchProperties.Add("AutomationId", "num9Button");
            XamlButton buttonPlus = new XamlButton(appWindow);
            buttonPlus.SearchProperties.Add("AutomationId", "plusButton");
            XamlButton buttonEquals = new XamlButton(appWindow);
            buttonEquals.SearchProperties.Add("AutomationId", "equalButton");

            Mouse.Click(button9);
            Mouse.Click(buttonPlus);
            Mouse.Click(button9);
            Mouse.Click(buttonEquals);

            XamlText resultText = new XamlText(appWindow);
            resultText.SearchProperties.Add("AutomationId", "CalculatorResults");

            string resultString = resultText.GetProperty("DisplayText").ToString();
            resultString = resultString.Replace("Wyświetlana wartość to ", " ");
            resultString = resultString.Trim();

            decimal expectedResult = 18;
            Assert.IsTrue(Decimal.Parse(resultString) == expectedResult);
        }

        #region Dodatkowe atrybuty testu

        // Można użyć następujących dodatkowych atrybutów w trakcie pisania testów:

        ////Użyj TestInitialize do uruchomienia kodu przed uruchomieniem każdego testu 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // Aby wygenerować kod dla tego testu, wybierz opcję „Generuj kod dla kodowanego testu interfejsu użytkownika” z menu skrótów i wybierz jeden z elementów menu.
        //}

        ////Użyj TestCleanup do uruchomienia kodu po wykonaniu każdego testu
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // Aby wygenerować kod dla tego testu, wybierz opcję „Generuj kod dla kodowanego testu interfejsu użytkownika” z menu skrótów i wybierz jeden z elementów menu.
        //}

        #endregion

        /// <summary>
        ///Pobiera lub ustawia kontekst testu, który udostępnia
        ///funkcjonalność i informację o bieżącym przebiegu testu.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if (this.map == null)
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
