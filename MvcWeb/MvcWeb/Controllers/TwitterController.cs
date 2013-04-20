using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using MvcWeb.Models;

using Newtonsoft.Json;

namespace MvcWeb.Controllers
{
    public class TwitterController : Controller
    {
        public ActionResult Index()
        {
            Tweets tweets = new Tweets();
            var client = new HttpClient();

            var task =
                client.GetAsync("http://search.twitter.com/search.json?q=kingjames").ContinueWith(
                    taskWithResponse =>
                        {
                            HttpResponseMessage response = taskWithResponse.Result;
                            var readTask = response.Content.ReadAsAsync<Tweets>();
                            //readTask.Wait();

                            tweets = readTask.Result; // asking for the Result - automatically waits (it is a blocking call)
                        });


            task.Wait();

            return View(tweets.Results);
        }

        public async Task<ActionResult> IndexAsync()
        {
            var httpClient = new HttpClient();

            HttpResponseMessage response= await httpClient.GetAsync("http://search.twitter.com/search.json?q=kingjames");

            Tweets tweets = await response.Content.ReadAsAsync<Tweets>();

            return View("Index", tweets.Results);
        }

    }

   
}
