using System.Net;
using System.Threading.Tasks;

namespace ExcellaCareers.Services.Impl
{
    public class WebRequestService : IWebRequestService
    {
        public async Task<WebResponse> GetResponseAsync(WebRequest request)
        {
            return await request.GetResponseAsync();
        }
    }
}
