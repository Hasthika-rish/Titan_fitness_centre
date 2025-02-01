using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Titan_fitness_center;

namespace TitanFitnessCenter
{
    /// <summary>
    /// Program class following MVC principles.
    /// Acts as the entry point of the application.
    /// </summary>
    static class Program
    {
        // Model: List to store registered users (simulating a database)
        static List<User> users = new List<User>();

        [STAThread] // Required for Windows Forms applications
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // View: Starts with the Login Form (GUI)
            Application.Run(new LoginForm());
        }

        /// <summary>
        /// Authenticates a user based on email and password.
        /// Implements encapsulation by restricting direct access to user credentials.
        /// </summary>
        /// <param name="email">User's email</param>
        /// <param name="password">User's password</param>
        /// <returns>User object if authentication succeeds, otherwise null</returns>
        public static User AuthenticateUser(string email, string password)
        {
            // Error handling: Ensure credentials are not empty
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Email and password cannot be empty.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            // Search for user in the database (list)
            return users.Find(u => u.Email == email && u.Password == password);
        }
    }

    /// <summary>
    /// Model class representing a User.
    /// Inherits from Person to follow OOP principles.
    /// </summary>
    public class User : Person
    {
        public string Password { get; private set; } // Encapsulation: Password is private
        public string UserType { get; private set; } // User type (e.g., Member, Admin)

        /// <summary>
        /// Constructor initializing user data.
        /// </summary>
        public User(string personID, string name, string email, string contactNumber, string password, string userType)
            : base(personID, name, email, contactNumber) // Calls base class constructor
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password cannot be empty.");

            if (string.IsNullOrWhiteSpace(userType))
                throw new ArgumentException("User type cannot be empty.");

            Password = password;
            UserType = userType;
        }
    }

    /// <summary>
    /// View: Windows Form for user login.
    /// </summary>
    public class LoginForm : Form
    {
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Button btnLogin;

        public LoginForm()
        {
            // Set up the Login Form UI
            Text = "Login - Gym Management System";
            Size = new System.Drawing.Size(300, 200);

            Label lblEmail = new Label { Text = "Email:", Top = 20, Left = 20 };
            txtEmail = new TextBox { Top = 40, Left = 20, Width = 200 };

            Label lblPassword = new Label { Text = "Password:", Top = 70, Left = 20 };
            txtPassword = new TextBox { Top = 90, Left = 20, Width = 200, PasswordChar = '*' };

            btnLogin = new Button { Text = "Login", Top = 120, Left = 20 };
            btnLogin.Click += BtnLogin_Click; // Event handling

            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(btnLogin);
        }

        /// <summary>
        /// Event handler for login button click.
        /// Handles authentication and displays messages.
        /// </summary>
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Controller: Handles authentication logic
                User user = Program.AuthenticateUser(txtEmail.Text, txtPassword.Text);

                if (user != null)
                {
                    MessageBox.Show($"Welcome, {user.Name} ({user.UserType})!", "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Invalid credentials! Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
