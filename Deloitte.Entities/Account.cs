using System;
using Newtonsoft.Json;

namespace Deloitte.Entities
{
    [Serializable]
    public class Account
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("login")]
        public string Login { get; set; }
    }
}
