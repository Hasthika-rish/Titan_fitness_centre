using System;
//using System.Windows.Forms; // For Windows Forms compatibility

namespace Titan_fitness_center
{
    /// <summary>
    /// Represents a gym member with attributes and functionalities.
    /// Implements OOP principles such as encapsulation and data validation.
    /// </summary>
    public class Member
    {
        // Properties with encapsulation for data safety
        public string MemberID { get; private set; } // Should not be changed after initialization
        public string MemberName { get; private set; } // Member's full name
        public DateTime JoinedDate { get; private set; } // Date of joining stored as DateTime
        public string Email { get; private set; } // Email address
        public string ContactNumber { get; private set; } // Contact number
        public string MembershipType { get; private set; } // Type of membership (e.g., Gold, Silver)
        public string PaymentDetails { get; private set; } // Payment information

        /// <summary>
        /// Constructor for initializing a Member object with validation.
        /// </summary>
        public Member(string memberID, string memberName, DateTime joinedDate, string email, string contactNumber, string membershipType, string paymentDetails)
        {
            if (string.IsNullOrWhiteSpace(memberID))
                throw new ArgumentException("Member ID cannot be empty.");
            if (string.IsNullOrWhiteSpace(memberName))
                throw new ArgumentException("Member name cannot be empty.");
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new ArgumentException("Invalid email format.");
            if (string.IsNullOrWhiteSpace(contactNumber) || contactNumber.Length < 10)
                throw new ArgumentException("Invalid contact number.");
            if (string.IsNullOrWhiteSpace(membershipType))
                throw new ArgumentException("Membership type cannot be empty.");
            if (joinedDate > DateTime.Now)
                throw new ArgumentException("Joined date cannot be in the future.");

            MemberID = memberID;
            MemberName = memberName;
            JoinedDate = joinedDate;
            Email = email;
            ContactNumber = contactNumber;
            MembershipType = membershipType;
            PaymentDetails = paymentDetails;
        }

        /// <summary>
        /// Registers a new member with a confirmation message.
        /// </summary>
        public void Register()
        {
            MessageBox.Show($"{MemberName} has been successfully registered.", "Registration Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Updates member details with validation.
        /// </summary>
        public void UpdateDetails(string newEmail, string newContactNumber, string newMembershipType)
        {
            if (string.IsNullOrWhiteSpace(newEmail) || !newEmail.Contains("@"))
            {
                MessageBox.Show("Invalid email format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(newContactNumber) || newContactNumber.Length < 10)
            {
                MessageBox.Show("Invalid contact number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(newMembershipType))
            {
                MessageBox.Show("Membership type cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Email = newEmail;
            ContactNumber = newContactNumber;
            MembershipType = newMembershipType;

            MessageBox.Show("Member details updated successfully.", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Deletes a member account with a confirmation message.
        /// </summary>
        public void DeleteAccount()
        {
            MessageBox.Show($"Member {MemberID} ({MemberName}) account deleted.", "Account Deleted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Removes membership while retaining the member's data.
        /// </summary>
        public void RemoveMembership()
        {
            MembershipType = "Inactive";
            MessageBox.Show($"{MemberName}'s membership has been removed.", "Membership Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Displays a class schedule for the member.
        /// </summary>
        public void ViewClassSchedule()
        {
            MessageBox.Show($"{MemberName} is viewing the class schedule.", "Class Schedule", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Changes the membership type with validation.
        /// </summary>
        public void ChangeMemberType(string newType)
        {
            if (string.IsNullOrWhiteSpace(newType))
            {
                MessageBox.Show("Membership type cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MembershipType = newType;
            MessageBox.Show($"Membership type updated to {newType}.", "Membership Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Processes a payment and displays confirmation.
        /// </summary>
        public void MakePayment(double amount)
        {
            if (amount <= 0)
            {
                MessageBox.Show("Payment amount must be greater than zero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"Payment of {amount:C} made by {MemberName}.", "Payment Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Displays member profile details in a message box.
        /// </summary>
        public void ViewProfile()
        {
            MessageBox.Show(
                $"Member Profile:\nID: {MemberID}\nName: {MemberName}\nJoined Date: {JoinedDate:yyyy-MM-dd}\nEmail: {Email}\nContact: {ContactNumber}\nMembership Type: {MembershipType}\nPayment Details: {PaymentDetails}",
                "Member Profile",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
