using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan_fitness_center
{
    public class Attendance
    {
        // Fields (Private)
        private List<string> memberIDs;
        private DateTime date; // Changed to DateTime
        private string time;
        private string status;

        // Properties
        public List<string> MemberIDs
        {
            get { return memberIDs; }
            set { memberIDs = value; }
        }

        public DateTime Date // Changed to DateTime
        {
            get { return date; }
            set { date = value; }
        }

        public string Time
        {
            get { return time; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    time = value;
                else
                    throw new ArgumentException("Time cannot be empty.");
            }
        }

        public string Status
        {
            get { return status; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    status = value;
                else
                    throw new ArgumentException("Status cannot be empty.");
            }
        }

        // Constructor
        public Attendance()
        {
            memberIDs = new List<string>();
            date = DateTime.Now; // Default to current date and time
            time = string.Empty;
            status = string.Empty;
        }

        public Attendance(List<string> memberIDs, DateTime date, string time, string status)
        {
            this.memberIDs = memberIDs;
            this.date = date;
            this.time = time;
            this.status = status;
        }

        // Methods
        public void MarkAttendance(string memberID)
        {
            if (!memberIDs.Contains(memberID))
            {
                memberIDs.Add(memberID);
                Console.WriteLine($"Attendance marked for Member ID: {memberID}");
            }
            else
            {
                Console.WriteLine($"Member ID: {memberID} already marked.");
            }
        }

        public void CancelAttendance(string memberID)
        {
            if (memberIDs.Contains(memberID))
            {
                memberIDs.Remove(memberID);
                Console.WriteLine($"Attendance cancelled for Member ID: {memberID}");
            }
            else
            {
                Console.WriteLine($"Member ID: {memberID} not found in attendance list.");
            }
        }

        public void ViewAttendance()
        {
            Console.WriteLine("Attendance List:");
            Console.WriteLine($"Date: {date.ToShortDateString()}"); // Using ToShortDateString on DateTime
            foreach (var id in memberIDs)
            {
                Console.WriteLine($"- Member ID: {id}");
            }
        }

        public void UpdateAttendance(string oldMemberID, string newMemberID)
        {
            if (memberIDs.Contains(oldMemberID))
            {
                int index = memberIDs.IndexOf(oldMemberID);
                memberIDs[index] = newMemberID;
                Console.WriteLine($"Updated Member ID: {oldMemberID} to {newMemberID}");
            }
            else
            {
                Console.WriteLine($"Member ID: {oldMemberID} not found.");
            }
        }
    }
}
