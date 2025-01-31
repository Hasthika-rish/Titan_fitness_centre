using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan_fitness_center
{
    public class Trainer : Person
    {
        public Trainer(string personID, string name, string email, string contactNumber) : base(personID, name, email, contactNumber)
        {



        }
        public string Specialization { get; set; }




        public void ViewAssignClass()
        {
            Console.WriteLine("You have been assigned to multiple classes");
        }
        public void ViewDetails()
        {
            base.ViewDetails();
            Console.WriteLine($"Specialization : {Specialization}");
        }
    }
}
