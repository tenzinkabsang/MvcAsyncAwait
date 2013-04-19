using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

using MvcWeb.Models;
using MvcWeb.Service.Interfaces;

using Newtonsoft.Json;

namespace MvcWeb.Service
{
    public class WidgetService : IWidgetService
    {
        private readonly string _widgetUri = Util.GetServiceUri("widgets");

        public List<Widget> GetWidgets()
        {
            using (WebClient webClient = new WebClient())
            {
                var value = webClient.DownloadString(_widgetUri);
                var result = JsonConvert.DeserializeObject<List<Widget>>(value);
                return result;
            } 
        }

        public async Task<List<Widget>> GetWidgetsAsync(CancellationToken cancelToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_widgetUri, cancelToken);
                return await response.Content.ReadAsAsync<List<Widget>>();
            }
        }

        // The following method shows the simplest possible async GetAsync
        // which doesn't use the CancellationToken
        public async Task<List<Widget>> GetWidgetsAsync()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_widgetUri);
                return await response.Content.ReadAsAsync<List<Widget>>();
            }

        }
    }
}