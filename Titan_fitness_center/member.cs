using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan_fitness_center
{
    public class Member
    {
        // Attributes for member class
        public string MemberID { get; set; }
        public string MemberName { get; set; }
        public string JoinedDate { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string MembershipType { get; set; }
        public string PaymentDetails { get; set; }

        // Constructor
        public Member(string memberID, string memberName, string joinedDate, string email, string contactNumber, string membershipType, string paymentDetails)
        {
            MemberID = memberID;
            MemberName = memberName;
            JoinedDate = joinedDate;
            Email = email;
            ContactNumber = contactNumber;
            MembershipType = membershipType;
            PaymentDetails = paymentDetails;
        }

        // Methods
        public void Register()
        {
            Console.WriteLine($"{MemberName} has been registered.");
        }

        public void UpdateDetails(string newEmail, string newContactNumber, string newMembershipType)
        {
            Email = newEmail;
            ContactNumber = newContactNumber;
            MembershipType = newMembershipType;
            Console.WriteLine("Member details updated.");
        }

        public void DeleteAccount()
        {
            Console.WriteLine($"Member {MemberID} ({MemberName}) account deleted.");
        }

        public void RemoveMembership()
        {
            Console.WriteLine($"{MemberName}'s membership has been removed.");
        }

        public void ViewClassSchedule()
        {
            Console.WriteLine($"{MemberName} is viewing the class schedule.");
        }

        public void ChangeMemberType(string newType)
        {
            MembershipType = newType;
            Console.WriteLine($"Membership type updated to {newType}.");
        }

        public void MakePayment(double amount)
        {
            Console.WriteLine($"Payment of {amount} made by {MemberName}.");
        }

        public void ViewProfile()
        {
            Console.WriteLine($"\nMember Profile:\nID: {MemberID}\nName: {MemberName}\nJoined Date: {JoinedDate}\nEmail: {Email}\nContact: {ContactNumber}\nMembership Type: {MembershipType}\nPayment Details: {PaymentDetails}\n");
        }
    }
}
