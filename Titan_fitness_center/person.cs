using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan_fitness_center
{
    public abstract class Person
    {
        public string PersonID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }

        public Person(string personID, string name, string email, string contactNumber)
        {
            PersonID = personID;
            Name = name;
            Email = email;
            ContactNumber = contactNumber;



        }
        public virtual void ViewDetails()
        {
            Console.WriteLine($"ID : {PersonID}, Name : {Name} , Email : {Email}, Contact : {ContactNumber}");

        }
        public void UpdateContactInfo(string newContact)
        {
            ContactNumber = newContact;
            Console.WriteLine($"Contact updated to : {newContact}");
        }
    }
}
