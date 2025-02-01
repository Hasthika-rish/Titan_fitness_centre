using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan_fitness_center
{
    public class Equipment
    {
        public List<string> EquipmentID { get; set; }
        public List<string> Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public double Cost { get; set; }

        public Equipment(List<string> equipmentID, List<string> name, string type, int quantity, double cost)
        {
            EquipmentID = equipmentID;
            Name = name;
            Type = type;
            Quantity = quantity;
            Cost = cost;
        }

        public void AddEquipments() { }
        public void RemoveEquipment() { }
        public void GetEquipmentDetails() { }
        public void AddQuantity() { }
    }

}
