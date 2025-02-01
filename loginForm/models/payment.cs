using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan_fitness_center
{
    namespace GymManagementSystem.Models
    {
        public class Payment
        {
            public string PaymentID { get; set; }
            public string MemberID { get; set; }
            public double Amount { get; set; }
            public string Date { get; set; }
            public string Method { get; set; }
            public string Status { get; set; }
            public string MembershipType { get; set; }

            public Payment(string paymentID, string memberID, double amount, string date, string method, string status, string membershipType)
            {
                PaymentID = paymentID;
                MemberID = memberID;
                Amount = amount;
                Date = date;
                Method = method;
                Status = status;
                MembershipType = membershipType;
            }

            public void ProcessPayment() { }
            public void GenerateInvoice() { }
            public void ViewDetails() { }
            public void GetPaymentHistory() { }
            public void ValidatePayment() { }
        }
    }

}
