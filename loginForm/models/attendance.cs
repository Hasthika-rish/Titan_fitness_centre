using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan_fitness_center
{
    public class Attendance
    {
        public List<string> MemberID { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }

        public Attendance(List<string> memberID, string date, string time, string status)
        {
            MemberID = memberID;
            Date = date;
            Time = time;
            Status = status;
        }

        public void MarkAttendance() { }
        public void CancelAttendance() { }
        public void ViewAttendance() { }
        public void UpdateAttendance() { }
    }
}
