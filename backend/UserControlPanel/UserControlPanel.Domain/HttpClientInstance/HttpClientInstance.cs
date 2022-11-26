using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlPanel.Domain.HttpClientInstance
{
    public class HttpClientInstance
    {
        public HttpClientInstance()
        {

        }
        public static HttpClient GetHttpClientInstance()
        {
            HttpClient httpClient = new HttpClient();
            return httpClient;
        }
    }
}
