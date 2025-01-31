using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan_fitness_center
{
    public class Payment
    {
        // Properties
        public string PaymentID { get; set; }           // Unique ID for the payment
        public string UserID { get; set; }             // ID of the user making the payment
        public double Amount { get; set; }             // Payment amount
        public DateTime PaymentDate { get; set; }      // Date of payment
        public string PaymentMethod { get; set; }      // Method of payment (e.g., Credit Card, Cash)
        public string Status { get; set; }             // Payment status (e.g., Paid, Pending)
        public string MembershipType { get; set; }     // Membership type (e.g., Basic, Premium)
        public string Notes { get; set; }              // Optional notes for the payment

        // Constructor
        public Payment(string paymentID, string userID, double amount, DateTime paymentDate, string paymentMethod, string status, string membershipType, string notes = "")
        {
            PaymentID = paymentID;
            UserID = userID;
            Amount = amount;
            PaymentDate = paymentDate;
            PaymentMethod = paymentMethod;
            Status = status;
            MembershipType = membershipType;
            Notes = notes;
        }

        // Method to validate the payment details
        public bool ValidatePaymentDetails()
        {
            if (Amount <= 0)
            {
                Console.WriteLine("Invalid payment amount.");
                return false;
            }

            if (string.IsNullOrEmpty(UserID) || string.IsNullOrEmpty(PaymentMethod))
            {
                Console.WriteLine("User ID or Payment Method cannot be empty.");
                return false;
            }

            Console.WriteLine("Payment details validated successfully.");
            return true;
        }

        // Method to process the payment
        public bool ProcessPayment()
        {
            if (Status == "Pending")
            {
                Status = "Paid";
                Console.WriteLine("Payment has been successfully processed.");
                return true;
            }
            else
            {
                Console.WriteLine("Payment is already completed.");
                return false;
            }
        }

        // Method to generate a payment receipt
        public string GenerateReceipt()
        {
            return $"--- Payment Receipt ---\n" +
                   $"Payment ID: {PaymentID}\n" +
                   $"User ID: {UserID}\n" +
                   $"Amount: {Amount:C}\n" +
                   $"Payment Date: {PaymentDate:yyyy-MM-dd}\n" +
                   $"Payment Method: {PaymentMethod}\n" +
                   $"Status: {Status}\n" +
                   $"Membership Type: {MembershipType}\n" +
                   $"Notes: {Notes}\n" +
                   $"------------------------";
        }

        // Method to display payment details
        public void DisplayPaymentDetails()
        {
            Console.WriteLine("Payment Details:");
            Console.WriteLine($"Payment ID: {PaymentID}");
            Console.WriteLine($"User ID: {UserID}");
            Console.WriteLine($"Amount: {Amount:C}");
            Console.WriteLine($"Payment Date: {PaymentDate:yyyy-MM-dd}");
            Console.WriteLine($"Payment Method: {PaymentMethod}");
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine($"Membership Type: {MembershipType}");
            Console.WriteLine($"Notes: {Notes}");
        }
    }
}
