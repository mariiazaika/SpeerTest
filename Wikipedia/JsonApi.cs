using System.Text.Json;

namespace Wikipedia
{
    internal class JsonApi
    {
        private static string pathToExport = @"D:\path.json";
        
        public static void ExportResults(List<string> links)
        {
            List<LinksResult> _data = new List<LinksResult>();
            _data.Add(new LinksResult()
            {
                TotalFoundLinks = links.Count,
                UniqueLinks = links.Distinct().Count(),
                AllFoundLinks = links
            });

            using FileStream createStream = File.Create(pathToExport);
            JsonSerializer.SerializeAsync(createStream, _data);
        }
    }
}
