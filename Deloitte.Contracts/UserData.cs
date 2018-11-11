using System;
using Deloitte.Entities;

namespace Deloitte.Contracts
{
    public class UserData
    {
        public UserData()
        {
        }

        public UserData(User user)
        {
            Id = user.Id;
            Name = user.Name;
            Company = user.Company;
            Email = user.Email;
            Phone = user.Phone;
            Tags = user.Tags;
        }

        public Guid Id { get; set; }

        public String Name { get; set; }

        public string Company { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string[] Tags { get; set; }
    }
}
