using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan_fitness_center
{
    public class equipment
    {
        public string EquipmentID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public double Cost { get; set; }

        public void AddEquipment(string equipmentName, int quantity)
        {
            Quantity += quantity;
            Console.WriteLine("hhh");
        }
        public void RemoveEquipment(string equipmentName, int quantity)
        {

            if (Quantity >= quantity)
            {
                Quantity -= quantity;
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("");

            }

        }
        public void GetEquipmentDetails()
        {
            Console.WriteLine("");
        }
    }
}
