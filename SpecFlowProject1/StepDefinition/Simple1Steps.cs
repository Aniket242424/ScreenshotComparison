using NUnit.Framework;
using SpecFlowProject1.Utility;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinition
{

    [Binding]
    public class Simple1Steps
    {
        public string url = "https://www.google.com";
        Utils utils;
        ScreebsotUtility screebsotUtility;

        public Simple1Steps()
        {
            utils = new Utils();
            screebsotUtility = new ScreebsotUtility();
        }

        [Given(@"I am on Application")]
        public void GivenIAmOnApplication()
        {
            utils.Navigate(url);
        }
        
 
        [When(@"I search the keyword '(.*)'")]
        public void WhenISearchTheKeyword(string keyword)
        {
            utils.TypeInTextBox(keyword);
        }


        [When(@"I press the search button")]
        public void WhenIPressTheSearchButton()
        {
            utils.ClickOnSearchButton();
        }
        
        [Then(@"search result should be displayed")]
        public void ThenSearchResultShouldBeDisplayed()
        {
            ScenarioContext.Current.Pending();
        }

        
        [Then(@"search result should be displayed on ""(.*)""")]
        public void ThenSearchResultShouldBeDisplayedOn(string environment)
        {
            
            if (environment.Equals("QA"))
            {
                screebsotUtility.TakeScreenshot(environment);
                screebsotUtility.CloseDriver();
            }else if (environment.Equals("Dev"))
            {
                screebsotUtility.TakeScreenshot(environment);
                screebsotUtility.CloseDriver();
                double distortionValue= screebsotUtility.Compare();
                Assert.True(distortionValue < 50, "Two screenshots are not similar. Distortion value is "+distortionValue);

            }
           
        }



    }
}
