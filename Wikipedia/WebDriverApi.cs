using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Wikipedia
{
    public class WebDriverApi
    {
        IWebDriver driver;
        public WebDriverApi()
        {
            driver = new ChromeDriver();
        }

        public List<string> GetAllLinksFromPage(string wikiPage, List<string> foundLinks, List<string> visitedLinks)
        {
            this.driver.Navigate().GoToUrl(wikiPage);
            //Find all links within content block
            var numberOfLinks = driver.FindElements(By.CssSelector("div[id=bodyContent] a"));
            foreach (var element in numberOfLinks)
            {
                foundLinks.Add(element.GetAttribute("href"));
            }
            visitedLinks.Add(wikiPage);
            driver.Close();
            return foundLinks;
        }

        public void QuitWebdriver()
        {
            driver.Quit();
        }
    }
}
