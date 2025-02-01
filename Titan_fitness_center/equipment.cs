using System;
//using System.Windows.Forms; // For Windows Forms compatibility

namespace Titan_fitness_center
{
    /// <summary>
    /// Represents a gym equipment item.
    /// Implements OOP principles such as encapsulation and data validation.
    /// </summary>
    public class Equipment
    {
        // Properties with encapsulation for data safety
        public string EquipmentID { get; private set; } // Should not change after initialization
        public string Name { get; private set; } // Equipment name
        public string Type { get; private set; } // Type/category of equipment
        public int Quantity { get; private set; } // Number of available equipment
        public double Cost { get; private set; } // Cost per unit

        /// <summary>
        /// Constructor for initializing an Equipment object with validation.
        /// </summary>
        public Equipment(string equipmentID, string name, string type, int quantity, double cost)
        {
            if (string.IsNullOrWhiteSpace(equipmentID))
                throw new ArgumentException("Equipment ID cannot be empty.");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Equipment name cannot be empty.");
            if (string.IsNullOrWhiteSpace(type))
                throw new ArgumentException("Equipment type cannot be empty.");
            if (quantity < 0)
                throw new ArgumentException("Quantity cannot be negative.");
            if (cost < 0)
                throw new ArgumentException("Cost cannot be negative.");

            EquipmentID = equipmentID;
            Name = name;
            Type = type;
            Quantity = quantity;
            Cost = cost;
        }

        /// <summary>
        /// Adds equipment to inventory with error handling.
        /// </summary>
        public void AddEquipment(int quantity)
        {
            if (quantity <= 0)
            {
                MessageBox.Show("Quantity must be greater than zero.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Quantity += quantity;
            MessageBox.Show($"{quantity} units of {Name} added.", "Equipment Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Removes equipment from inventory with validation.
        /// </summary>
        public void RemoveEquipment(int quantity)
        {
            if (quantity <= 0)
            {
                MessageBox.Show("Quantity must be greater than zero.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Quantity >= quantity)
            {
                Quantity -= quantity;
                MessageBox.Show($"{quantity} units of {Name} removed.", "Equipment Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Insufficient quantity to remove.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Displays equipment details using MessageBox for Windows Forms UI.
        /// </summary>
        public void GetEquipmentDetails()
        {
            MessageBox.Show($"ID: {EquipmentID}\nName: {Name}\nType: {Type}\nQuantity: {Quantity}\nCost: {Cost:C}",
                "Equipment Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
