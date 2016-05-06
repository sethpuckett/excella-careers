using System.Threading.Tasks;

namespace ExcellaCareers.Services
{
    public interface IHtmlScraper
    {
        Task<string> Scrape(string url);
    }
}