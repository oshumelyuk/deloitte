using System;
using Newtonsoft.Json;

namespace Deloitte.Entities
{
    [Serializable]
    public class User
    {
        [JsonProperty("guid")]
        public Guid Id { get; set; }

        [JsonProperty("picture")]
        public String PhotoName { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("gender")]
        public Gender Gender { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("about")]
        public string About { get; set; }

        [JsonProperty("registered")]
        public DateTime RegistrationDate { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }
    }
}
