using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ExcellaCareers.Services.Impl
{
    public class HtmlScraper : IHtmlScraper
    {
        private IWebRequestService WebRequestService { get; }

        public HtmlScraper(IWebRequestService webRequestService)
        {
            this.WebRequestService = webRequestService;
        }

        public async Task<string> Scrape(string url)
        {
            var request = WebRequest.Create(url);

            var response = await this.WebRequestService.GetResponseAsync(request);

            var stream = response.GetResponseStream();
            var streamReader = new StreamReader(stream, Encoding.UTF8);
            var responseText = streamReader.ReadToEnd();

            streamReader.Dispose();
            stream.Dispose();
            response.Dispose();

            return responseText;
        }
    }
}
