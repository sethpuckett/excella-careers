using System.Net;
using System.Threading.Tasks;

namespace ExcellaCareers.Services
{
    public interface IWebRequestService
    {
        Task<WebResponse> GetResponseAsync(WebRequest request);
    }
}
