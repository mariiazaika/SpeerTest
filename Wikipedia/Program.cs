using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.Json;
using System.Text.RegularExpressions;
using Wikipedia;

namespace Wikipedia
{
    class Program
    {
        static void Main(string[] arg)
        {
            try
            {
                int numberOfCycles;
                string link = "";
                List<string> foundLinks = new List<string>();
                List<string> visitedLinks = new List<string>();

                Console.WriteLine("Enter url from Wikipedia: ");
                link = Console.ReadLine();
                foundLinks.Add(link);

                if (isWikiLink(link))
                {
                    Console.WriteLine("Please enter integer from 1 to 20: ");
                    numberOfCycles = Convert.ToInt32(Console.ReadLine());
                    if (numberOfCycles <= 0 || numberOfCycles > 20)
                        Console.WriteLine("You entered a wrong value.");
                    else
                    {
                        for (int i = 0; i < numberOfCycles; i++)
                        {
                            getAllWikiLinks(foundLinks[i]);
                        }
                        exportResults();
                    }
                }
                bool isWikiLink(string linkText)
                {
                    Regex rx = new Regex(@"^https?://([\w\.]+)wikipedia.org/wiki/([\w]+_?)+");
                    if (rx.IsMatch(linkText))
                        return true;
                    else throw new InvalidLinkException("It is an invalid link.");
                }

                List<string> getAllWikiLinks(string wikiPage)

                {
                    if (visitedLinks.Contains(wikiPage))
                    {
                        return foundLinks;
                    }
                    else
                    {
                        IWebDriver driver = new ChromeDriver();
                        driver.Navigate().GoToUrl(wikiPage);
                        //Find all links within content block
                        var numberOfLinks = driver.FindElements(By.CssSelector("div[id=bodyContent] a"));
                        foreach (var element in numberOfLinks)
                        {
                            foundLinks.Add(element.GetAttribute("href"));
                        }
                        visitedLinks.Add(wikiPage);
                        driver.Close();
                        driver.Quit();
                        return foundLinks;
                    }
                }

                void exportResults()
                {
                    List<Result> _data = new List<Result>();
                    _data.Add(new Result()
                    {
                        totalFoundLinks = foundLinks.Count,
                        uniqueLinks = foundLinks.Distinct().Count(),
                        allFoundLinks = foundLinks
                    });

                    using FileStream createStream = File.Create(@"D:\path.json");
                    JsonSerializer.SerializeAsync(createStream, _data);
                }

            }

            catch (InvalidLinkException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}


