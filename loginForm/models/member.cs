using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan_fitness_center
{
    public class Member : Person
    {
        public string JoinedDate { get; set; }
        public string MembershipType { get; set; }
        public string PaymentDetails { get; set; }

        public Member(string memberID, List<string> name, string email, string contactNumber, string joinedDate, string membershipType, string paymentDetails)
            : base(memberID, null, name, email, contactNumber, "Member", "N/A")
        {
            JoinedDate = joinedDate;
            MembershipType = membershipType;
            PaymentDetails = paymentDetails;
        }

        public void Register() { }
        public void UpdateDetails() { }
        public void DeleteAccount() { }
        public void RemoveMembership() { }
        public void ViewClassSchedule() { }
        public void ChangeMemberType(string newType) { MembershipType = newType; }
        public void MakePayment() { }
        public void ViewProfile() { }
    }
}
