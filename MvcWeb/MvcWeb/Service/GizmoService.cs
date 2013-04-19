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
    public class GizmoService : IGizmoService
    {
        public async Task<List<Gizmo>> GetGizmosAsync(CancellationToken cancellation)
        {
            string uri = Util.GetServiceUri("Gizmos");
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(uri, cancellation);
                return await response.Content.ReadAsAsync<List<Gizmo>>();
            }
        }

        // Simpler API, no CancellationToken
        public async Task<List<Gizmo>> GetGizmosAsync()
        {
            string uri = Util.GetServiceUri("Gizmos");
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(uri);
                return await response.Content.ReadAsAsync<List<Gizmo>>();
            }
        }

        // Synchronous
        public List<Gizmo> GetGizmos()
        {
            var uri = Util.GetServiceUri("Gizmos");
            using (WebClient webClient = new WebClient())
            {
                string value = webClient.DownloadString(uri);
                var result = JsonConvert.DeserializeObject<List<Gizmo>>(value);

                return result;
            }
        }
    }
}