using System.Text.RegularExpressions;

namespace Wikipedia
{
    class Program
    {
        static void Main(string[] arg)
        {
            int numberOfCycles;
            string link;
            List<string> foundLinks = new List<string>();
            List<string> visitedLinks = new List<string>();

            try
            {

                Console.WriteLine("Please, enter url from Wikipedia: ");
                link = Console.ReadLine();

                if (IsWikiLink(link))
                {
                    foundLinks.Add(link);
                    Console.WriteLine("Please, enter an integer from 1 to 20: ");
                    numberOfCycles = Convert.ToInt32(Console.ReadLine());
                    if (numberOfCycles <= 0 || numberOfCycles > 20)
                    {
                        Console.WriteLine("You entered a wrong value.");
                    }
                    else
                    {
                        /*
                        Tried to initilize webDriver once. But failed due to error with session id
                        var webDriverApi = new WebDriverApi();
                        for (int i = 0; i < numberOfCycles; i++)
                        {
                            webDriverApi.GetAllLinksFromPage(foundLinks[i], foundLinks, visitedLinks);
                        }
                        webDriverApi.QuitWebdriver();
                        */
                        for (int i = 0; i < numberOfCycles; i++)
                        {
                            var webDriverApi = new WebDriverApi();
                            webDriverApi.GetAllLinksFromPage(foundLinks[i], foundLinks, visitedLinks);
                            webDriverApi.QuitWebdriver();
                        }
                        JsonApi.ExportResults(foundLinks);
                    }
                }

                static bool IsWikiLink(string linkText)
                {
                    Regex rx = new Regex(@"^https?://([\w\.]+)wikipedia.org/wiki/([\w]+_?)+");
                    if (rx.IsMatch(linkText))
                        return true;
                    else throw new InvalidLinkException("It is an invalid link.");
                }
            }

            catch (InvalidLinkException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}


