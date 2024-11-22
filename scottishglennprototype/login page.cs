using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace scottishglennprototype
{
    public partial class login_page : Form
    {
        private string connectionString = "Data Source=lochnagar.abertay.ac.uk;Initial Catalog=sql2303150;User ID=sql2303150;Password=perry-pearl-staff-floral";

        public login_page()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(usrnmBox.Text) || string.IsNullOrWhiteSpace(pswrdBox.Text))
            {
                MessageBox.Show("Please enter both email and password.");
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    
                    string query = "SELECT EmployeeID, PasswordHash FROM Employees WHERE Email = @Email";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        
                        command.Parameters.AddWithValue("@Email", usrnmBox.Text);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedHash = reader["PasswordHash"].ToString();
                                int userID = Convert.ToInt32(reader["EmployeeID"]);

                                
                                if (PasswordUtils.VerifyPassword(pswrdBox.Text, storedHash))
                                {
                                    this.Hide();

                                    
                                    prototype main = new prototype(userID);
                                    main.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Incorrect password. Please try again.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("No account found with this email.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while logging in: " + ex.Message);
                }
            }
        }

    }


    public static class PasswordUtils
    {
        public static string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            string hashOfInput = HashPassword(password);
            return hashOfInput == storedHash;
        }
    }
}
