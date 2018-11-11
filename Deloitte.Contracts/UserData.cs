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
            LogoPath = user.LogoPath;
            Name = user.Name;
            Gender = user.Gender;
            Company = user.Company;
            Email = user.Email;
            Phone = user.Phone;
            Address = user.Address;
            About = user.About;
            Tags = user.Tags;
        }

        public Guid Id { get; set; }

        public String LogoPath { get; set; }

        public String Name { get; set; }

        public Gender Gender { get; set; }

        public string Company { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string About { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string[] Tags { get; set; }
    }
}
