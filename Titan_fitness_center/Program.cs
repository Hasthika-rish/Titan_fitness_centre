using System;
using System.Collections.Generic;

namespace Titan_fitness_center
{
    class Program
    {
        static List<User> users = new List<User>();

        static void Main()
        {
            Console.WriteLine("🏋️ Welcome to the Gym Management System! 🏋️");

            while (true)
            {
                Console.WriteLine("\n Select an option:");

                Console.WriteLine("2. Login");
                Console.WriteLine("3. Update Profile");
                Console.WriteLine("4. View Attendance");
                Console.WriteLine("5. Select a Category Class");
                Console.WriteLine("6. Select a Personal Trainer");
                Console.WriteLine("7. Manage Equipments (Admin)");
                Console.WriteLine("8. Approve Trainers/Members (Admin)");
                Console.WriteLine("9. Deactivate Account (Admin)");
                Console.WriteLine("10. Exit");

                Console.Write("\n🔸 Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {

                    case "1":
                        Login();
                        break;
                    case "2":
                        UpdateProfile();
                        break;
                    case "3":
                        ViewAttendance();
                        break;
                    case "4":
                        SelectCategoryClass();
                        break;
                    case "5":
                        SelectPersonalTrainer();
                        break;
                    case "6":
                        ManageEquipments();
                        break;
                    case "7":
                        ApproveUsers();
                        break;
                    case "8":
                        DeactivateAccount();
                        break;
                    case "9":
                        Console.WriteLine("🔹 Exiting the system. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("❌ Invalid choice. Please try again.");
                        break;
                }
            }
        }




        static void Login()
        {
            Console.Write("\nEnter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            User user = users.Find(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                Console.WriteLine($"\n✅ Login successful! Welcome, {user.Name} ({user.UserType})");
            }
            else
            {
                Console.WriteLine("\n❌ Invalid credentials! Please try again.");
            }
        }

        static void UpdateProfile()
        {
            Console.WriteLine("\n📝 Updating Profile...");
            Console.WriteLine("✅ Profile Updated Successfully!");
        }

        static void ViewAttendance()
        {
            Console.WriteLine("\n📅 Viewing Attendance Records...");
            Console.WriteLine(" Attendance Data Displayed!");
        }

        static void SelectCategoryClass()
        {
            Console.WriteLine("\n📚 Selecting a class category...");
            VerifyMembership();
        }

        static void VerifyMembership()
        {
            Console.WriteLine(" Verifying Membership...");
            Console.WriteLine("Membership Verified. You can access this class.");
        }

        static void SelectPersonalTrainer()
        {
            Console.WriteLine("\n Selecting a Personal Trainer...");
            Console.WriteLine("Trainer Assigned Successfully!");
        }

        static void ManageEquipments()
        {
            Console.WriteLine("\n Managing Gym Equipment...");
            Console.WriteLine("Equipment Maintenance Updated!");
        }

        static void ApproveUsers()
        {
            Console.WriteLine("\n Approving Trainers/Members...");
            Console.WriteLine(" All pending approvals processed!");
        }

        static void DeactivateAccount()
        {
            Console.WriteLine("\n Deactivating an account...");
            Console.WriteLine("Account Deactivated Successfully!");
        }
    }

    class User
    {
        public string Name { get; }
        public string Email { get; }
        public string Password { get; }
        public string UserType { get; }

        public User(string name, string email, string password, string userType)
        {
            Name = name;
            Email = email;
            Password = password;
            UserType = userType;
        }
    }
}

