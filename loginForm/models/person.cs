using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan_fitness_center
{

    public class Person
    {
        public string MemberID { get; set; }
        public string TrainerID { get; set; }
        public List<string> Name { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string Role { get; set; }
        public string Gender { get; set; }

        public Person(string memberID, string trainerID, List<string> name, string email, string contactNumber, string role, string gender)
        {
            MemberID = memberID;
            TrainerID = trainerID;
            Name = name;
            Email = email;
            ContactNumber = contactNumber;
            Role = role;
            Gender = gender;
        }

        public void UpdateContactInfo(string newContact)
        {
            ContactNumber = newContact;
        }

        public void ViewDetails()
        {
            // Display person details
        }

        public void DeleteProfile()
        {
            // Delete person profile
        }

        public void SearchPerson()
        {
            // Search logic
        }
    }
    

}
