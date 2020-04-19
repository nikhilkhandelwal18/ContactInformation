using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ContactInformation.Helper
{
    public class ContactAPI
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:44341/");
            return client;
        }
    }
}
