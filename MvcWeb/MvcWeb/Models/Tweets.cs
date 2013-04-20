using System.Collections.Generic;

using MvcWeb.Controllers;

using Newtonsoft.Json;

namespace MvcWeb.Models
{
    public class Tweets
    {
        public IEnumerable<Tweet> Results { get; set; }
    }

    public class Tweet
    {
        [JsonProperty("from_user")]
        public string UserName { get; set; }

        [JsonProperty("text")]
        public string TweetText { get; set; }
    }
}