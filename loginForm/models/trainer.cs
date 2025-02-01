using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan_fitness_center
{
    namespace GymManagementSystem.Models
    {
        public class Trainer : Person
        {
            public string Specialization { get; set; }

            public Trainer(string trainerID, List<string> name, string email, string contactNumber, string specialization)
                : base(null, trainerID, name, email, contactNumber, "Trainer", "N/A")
            {
                Specialization = specialization;
            }

            public void CreateProfile() { }
            public void ManageProfile() { }
            public void ViewAssignClass() { }
        }
    }

}
